#region Copyright
/*
* Copyright Onix Solutions Limited [OnixS]. All rights reserved.
*
* This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
* and international copyright treaties.
*
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting
* a non-assignable, non-transferable and non-exclusive license to use the software
* for it's own data processing purposes under the terms defined in the Agreement.
*
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited.
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with
* the terms of the Agreement is a violation of copyright law.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using FIXForge.NET.FIX;
using System.IO;

namespace Benchmark
{
    namespace Latency
    {
        internal class Latency
        {
			static SessionTimeMarks[] marks;
			static bool active;
			static int counter;
			static AutoResetEvent ready = new AutoResetEvent(true);

            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            private static void Main(string[] args)
            {
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

                try
                {
                    EngineSettings settings = new EngineSettings();

                    settings.SendLogoutOnInvalidLogon = true;
                    settings.ResendingQueueSize = 0;
                    settings.Dialect = "LatencyFixDictionary.xml";
                    settings.ValidateRequiredFields = false;
                    settings.ValidateUnknownFields = false;
                    settings.ValidateUnknownMessages = false;

                    Engine.Init(settings);

                    Dialect dialect = new Dialect("LatencyDictionaryId");

                    string rawMessage = "8=FIX.4.2\0019=3\00135=D\00149=OnixS\00156=CME\00134=01\00152=20120709-10:10:54\00111=90001008\001109=ClientID\00121=1\00155=ABC\00154=1\00138=100\00140=1\00160=20120709-10:10:54\00110=000\001";
                    rawMessage = rawMessage.Replace("\001", string.Empty + (char)0x01);

                    // Please note that a Serialized Message is used here to facilitate the best possible latency.
                    SerializedMessage order = new SerializedMessage(rawMessage);

                    const int listenPort = 4501;

#if DEBUG
                    const int NumberOfMessages = 1000;
#else
					const int NumberOfMessages = 50000;
#endif

					marks = new SessionTimeMarks[NumberOfMessages];

                    const string senderCompId = "Acceptor";
                    const string targetCompId = "Initiator";

                    Session acceptor = new Session(senderCompId, targetCompId, dialect, false, SessionStorageType.MemoryBasedStorage);
                    acceptor.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(InboundApplicationMsgEvent);
                    acceptor.BytesReceived += new BytesReceivedEventHandler(acceptor_BytesReceived);
                    acceptor.ReuseIncomingMessage = true;

                    acceptor.LogonAsAcceptor();

                    Session initiator = new Session(targetCompId, senderCompId, dialect, false, SessionStorageType.MemoryBasedStorage);
                    initiator.MessageSending += new MessageSendingEventHandler(OnMsgEvent);
                    initiator.ReuseIncomingMessage = true;

                    initiator.LogonAsInitiator("localhost", listenPort, 30);

                    active = true;

                    SerializedFieldRef clientIDRef = order.Find(FIXForge.NET.FIX.FIX42.Tags.ClientID);

                    if (clientIDRef == null)
                        throw new Exception("clientID field is not found");

                    SerializedFieldKey clientIDKey = order.AllocateKey(clientIDRef);

                    const string shortClientId = "ClientID";
                    const string LongClientId = "ClientIDClientIDClientIDClientID";

                    for (int i = 0; i < NumberOfMessages; ++i)
                    {
                        ready.WaitOne();

                        TimestampHelper.GetTicks(ref marks[counter].SendStart);

                        order.Set(clientIDKey, i % 2 == 0 ? shortClientId : LongClientId);

                        initiator.Send(order);
                    }

                    ready.WaitOne();

                    active = false;

                    acceptor.Logout();
                    initiator.Logout();

                    acceptor.Dispose();
                    initiator.Dispose();

                    ReportSessionTimeMarksStatistics("Latency", marks, NumberOfMessages);

                    Engine.Instance.Shutdown();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex);
                }

                Console.WriteLine("Press <enter> for exit.");
                Console.ReadLine();
            }

            static void acceptor_BytesReceived(ReceivedBytes args)
            {
                if (!active)
                    return;

                TimestampHelper.GetTicks(ref marks[counter].RecvStart);
            }

			static void InboundApplicationMsgEvent(object sender, InboundApplicationMsgEventArgs args)
			{
				if (!active)
					return;

				TimestampHelper.GetTicks(ref marks[counter].RecvFinish);
				++counter;
				ready.Set();
			}

            static void OnMsgEvent(int msgSeqNum, SendingBytes bytes)
            {
                if (!active)
                    return;

                TimestampHelper.GetTicks(ref marks[counter].SendFinish);
            }
			
			static void ProcessAndReportDurations(string durationName, List<double> durations)
            {
                durations.Sort();

                Console.WriteLine("\t{0} min: {1:F}, max: {2:F}, median: {3:F}, 99th percentile: {4:F}",
                    durationName, durations[0], durations[durations.Count - 1], durations[durations.Count / 2], durations[Convert.ToInt32(Math.Ceiling((durations.Count * 99) / 100.0)) - 1]);
            }

            static void ReportSessionTimeMarksStatistics(String testName, SessionTimeMarks[] marksArray, int count)
            {
                string baseName = testName + '_';

                StreamWriter receiveStream = new StreamWriter(baseName + "recv.csv", true);
                StreamWriter sendStream = new StreamWriter(baseName + "send.csv", true);
                StreamWriter tripStream = new StreamWriter(baseName + "trip.csv", true);
                StreamWriter sendAndReceiveStream = new StreamWriter(baseName + "sendrecv.csv", true);

                List<double> sendDurations = new List<double>();
                List<double> receiveDurations = new List<double>();
                List<double> sendAndReceiveDurations = new List<double>();
                List<double> roundtripDurations = new List<double>();

                for (int i = 0; i < count; ++i)
                {
                    SessionTimeMarks marks = marksArray[i];

                    double receiveDuration = (double)marks.RecvSpan / TimestampHelper.TicksPerMicrosecond;
                    receiveDurations.Add(receiveDuration);
                    receiveStream.WriteLine(Math.Round(receiveDuration));

                    double sendDuration = (double)marks.SendSpan / TimestampHelper.TicksPerMicrosecond;
                    sendDurations.Add(sendDuration);
                    sendStream.WriteLine(Math.Round(sendDuration));

                    double sendAndReceiveDuration = sendDuration + receiveDuration;
                    sendAndReceiveDurations.Add(sendAndReceiveDuration);
                    sendAndReceiveStream.WriteLine(Math.Round(sendAndReceiveDuration));

                    double roundtripDuration = (double)marks.RoundtripSpan / TimestampHelper.TicksPerMicrosecond;
                    roundtripDurations.Add(roundtripDuration);
                    tripStream.WriteLine(Math.Round(roundtripDuration));
                }

                Console.WriteLine("\r\n{0} (microseconds): ", testName);

                ProcessAndReportDurations("Receive", receiveDurations);

                ProcessAndReportDurations("Send", sendDurations);

                ProcessAndReportDurations("Send+Receive", sendAndReceiveDurations);
                ProcessAndReportDurations("Round Trip (includes the intrinsic network interface latency)", roundtripDurations);
            }
        }
    }
}