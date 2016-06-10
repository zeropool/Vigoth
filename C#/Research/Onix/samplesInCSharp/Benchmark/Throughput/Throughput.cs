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
			static int counter;
			static AutoResetEvent ready = new AutoResetEvent(false);

			static long receiveStart;
			static long receiveFinish;

#if DEBUG
			const int WarmupNumberOfMessages = 100000;
			const int NumberOfMessages = 100000;
#else
			const int WarmupNumberOfMessages = 500000;
			const int NumberOfMessages = 1000000;
#endif

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

                    settings.TcpNoDelayOption = false;
                    settings.SendLogoutOnInvalidLogon = true;
					settings.ResendingQueueSize = 0;
					settings.Dialect = "ThroughputFixDictionary.xml";
					settings.ValidateRequiredFields = false;
					settings.ValidateUnknownFields = false;
					settings.ValidateUnknownMessages = false;

					Engine.Init(settings);

					Dialect dialect = new Dialect("ThroughputDictionaryId");

					string rawMessage =
						"8=FIX.4.2\0019=3\00135=D\00149=OnixS\00156=CME\00134=01\00152=20120709-10:10:54\001" +
						"11=90001008\00121=1\00155=ABC\00154=1\00138=100\00140=1\00160=20120709-10:10:54\00110=000\001";
					rawMessage = rawMessage.Replace("\001", string.Empty + (char)0x01);

					SerializedMessage order = new SerializedMessage(rawMessage);

					const int listenPort = 4501;

					const string senderCompId = "Acceptor";
					const string targetCompId = "Initiator";

					Session acceptor = new Session(senderCompId, targetCompId, dialect, false, SessionStorageType.MemoryBasedStorage);
					acceptor.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(InboundApplicationMsgEvent);
                    acceptor.ReuseIncomingMessage = true;

					acceptor.LogonAsAcceptor();

					Session initiator = new Session(targetCompId, senderCompId, dialect, false, SessionStorageType.MemoryBasedStorage);
                    initiator.MessageGrouping = 200;
                    initiator.ReuseIncomingMessage = true;

                    initiator.LogonAsInitiator("localhost", listenPort, 30);

					for (int i = 0; i < WarmupNumberOfMessages; ++i)
						initiator.Send(order);

					long sendStart;
					long sendFinish;

					sendStart = TimestampHelper.Ticks;

					for (int i = 0; i < NumberOfMessages; ++i)
						initiator.Send(order);

					sendFinish = TimestampHelper.Ticks;

					ready.WaitOne();

					acceptor.Logout();
					initiator.Logout();

					acceptor.Dispose();
					initiator.Dispose();

					double sendMessagesPerSec = 1000000.0 * NumberOfMessages / (sendFinish - sendStart);

					double receiveMessagesPerSec = 1000000.0 * NumberOfMessages / (receiveFinish - receiveStart);

					Console.WriteLine("\r\n");
					Console.WriteLine("Throughput on send side: " + (int)sendMessagesPerSec + " (msg/sec)");
                    Console.WriteLine("Throughput on receive side: " + (int)receiveMessagesPerSec + " (msg/sec)");

					Engine.Instance.Shutdown();
				}
				catch (Exception ex)
				{
					Console.WriteLine("Exception: " + ex);
				}

				Console.WriteLine("Press <enter> for exit.");
				Console.ReadLine();
			}

			static void InboundApplicationMsgEvent(object sender, InboundApplicationMsgEventArgs args)
			{
				++counter;

				if (counter == WarmupNumberOfMessages)
				{
					receiveStart = TimestampHelper.Ticks;
					return;
				}

				if (counter == WarmupNumberOfMessages + NumberOfMessages)
				{
					receiveFinish = TimestampHelper.Ticks;
					ready.Set();
					return;
				}
			}
		}
	}
}