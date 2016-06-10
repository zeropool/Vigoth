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
using System.Reflection;
using System.Threading;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX44;
using Helpers;
using System.Globalization;

namespace SellSide
{
    /// <summary>
    /// Waits for incoming connections and processes incoming messages.
    /// </summary>
    internal class Acceptor : IDisposable
    {
        private const ProtocolVersion fixVersion = ProtocolVersion.FIX44;

        private void Run()
        {
            Console.WriteLine("SellSide Sample");

            EngineSettings settings = new EngineSettings();
            
            settings.SendLogoutOnException = true;
            settings.SendLogoutOnInvalidLogon = true; // E.g. to send a Logout when the sequence number of the incoming Logon (A) message is less than expected.

            Engine.Init(settings);

            Engine.Instance.Error += Instance_Error;
            Engine.Instance.Warning += Instance_Warning;

            string senderCompID = Settings.Get("SenderCompID");
            string targetCompID = Settings.Get("TargetCompID");

            Session sn = new Session(senderCompID, targetCompID, fixVersion);

            sn.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(OnInboundApplicationMsg);
            sn.StateChangeEvent += new StateChangeEventHandler(OnStateChange);
            sn.ErrorEvent += new FIXForge.NET.FIX.ErrorEventHandler(OnError);
            sn.WarningEvent += new WarningEventHandler(OnWarning);

            sn.LogonAsAcceptor();
            for (;;)
            {
                Console.WriteLine("\nAwaiting session-initiator with"
                                  + "\n SenderCompID (49) = " + targetCompID
                                  // from the counterparty's  point of view SenderCompID is TargetCompID
                                  + "\n TargetCompID (56) = " + senderCompID
                                  + "\n FIX version = " + fixVersion
                                  + "\non port " + Engine.Instance.Settings.ListenPort + " ...");

                DisconnectedEvent.WaitOne();
            }
        }

        void Instance_Warning(object sender, Engine.WarningEventArgs args)
        {
            Console.WriteLine("FIX Engine level warning: " + args.ToString());
        }

        void Instance_Error(object sender, Engine.ErrorEventArgs args)
        {
            Console.WriteLine("FIX Engine level error: " + args.ToString());
        }

        private void OnInboundApplicationMsg(Object sender, InboundApplicationMsgEventArgs e)
        {
            Console.WriteLine("Received application-level message:\n" + e.Msg.ToString());

            try
            {
                List<Message> replies = new List<Message>();
                switch (e.Msg.Type)
                {
                    case MsgType.NewOrderSingle:
                        Random rnd = new Random();
                        int x = rnd.Next(1, 5);
                        switch (x)
                        {
                            case 1:
                                replies.Add(CreateExecutionReport(e.Msg, OrdStatus.New));
                                break;

                            case 2:
                                replies.Add(CreateExecutionReport(e.Msg, OrdStatus.New));
                                replies.Add(CreateExecutionReport(e.Msg, OrdStatus.Partial));
                                break;

                            case 3:
                                replies.Add(CreateExecutionReport(e.Msg, OrdStatus.New));
                                replies.Add(CreateExecutionReport(e.Msg, OrdStatus.Filled));
                                break;

                            case 4:
                                replies.Add(CreateExecutionReport(e.Msg, OrdStatus.Rejected));
                                break;
                        }
                        break;

                    case MsgType.OrderCancelRequest:
                        replies.Add(CreateCancelledExecutionReport(e.Msg));
                        break;

                    default:
                        Message email = new Message(MsgType.Email, fixVersion);
                        email[Tags.EmailThreadID] = "SellSide reply";
                        email[Tags.EmailType] = EmailType.New;
                        email[Tags.Subject] = "Message was received";

                        email[Tags.EmailType] = EmailType.New;
                        Group group = email.SetGroup(Tags.NoLinesOfText, 1);
                        group.Set(Tags.Text, 0, "The message with MsgType=" + e.Msg[Tags.MsgType] + " was received");

                        replies.Add(email);
                        break;
                }

                Session sn = (Session) sender;

                foreach (Message reply in replies)
                {
                    reply.Validate();
                    sn.Send(reply);
                    Console.WriteLine("Sent to the counterparty:\n" + reply);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during the processing of the incoming message: " + ex);
            }
        }

        private Message CreateExecutionReport(Message order, string status)
        {
            Message execReport = new Message(MsgType.ExecutionReport, fixVersion);

            ++OrderCounter;

            execReport[Tags.ClOrdID] = order[Tags.ClOrdID];
			execReport[Tags.OrderID] = "OrderID_ " + DateTime.Now.ToString("HHmmss", CultureInfo.InvariantCulture);
            execReport[Tags.ExecID] = "ExecID_" + OrderCounter;
            execReport[Tags.OrdStatus] = status;
            execReport[Tags.ExecType] = status;
            execReport[Tags.Symbol] = order[Tags.Symbol];
            execReport[Tags.Side] = order[Tags.Side];
            execReport[Tags.OrdType] = order[Tags.OrdType];
            execReport[Tags.OrderQty] = order[Tags.OrderQty];
            execReport[Tags.CumQty] = "0";
            execReport[Tags.LeavesQty] = order[Tags.OrderQty];
            execReport[Tags.AvgPx] = "100.0";

            return execReport;
        }

        private Message CreateCancelledExecutionReport(Message cancelRequest)
        {
            Message execReport = new Message(MsgType.ExecutionReport, fixVersion);

            ++OrderCounter;

            execReport[Tags.ClOrdID] = cancelRequest[Tags.ClOrdID];
            execReport[Tags.OrigClOrdID] = cancelRequest[Tags.OrigClOrdID];
			execReport[Tags.OrderID] = "OrderID_ " + DateTime.Now.ToString("HHmmss", CultureInfo.InvariantCulture);
            execReport[Tags.ExecID] = "ExecID_" + OrderCounter;
            execReport[Tags.OrdStatus] = OrdStatus.Canceled;
            execReport[Tags.ExecType] = ExecType.Canceled;
            execReport[Tags.Symbol] = cancelRequest[Tags.Symbol];
            execReport[Tags.Side] = cancelRequest[Tags.Side];
            execReport[Tags.OrdType] = cancelRequest[Tags.OrdType];
            execReport[Tags.OrderQty] = cancelRequest[Tags.OrderQty];
            execReport[Tags.CumQty] = "0";
            execReport[Tags.LeavesQty] = "0";
            execReport[Tags.AvgPx] = "0.0";

            return execReport;
        }

        private void OnStateChange(Object sender, StateChangeEventArgs e)
        {
            Console.WriteLine("FIX session state: " + e.NewState.ToString());
            if (e.NewState == SessionState.DISCONNECTED)
            {
                DisconnectedEvent.Set();
            }
        }

        private void OnError(Object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Error: " + e.ToString());
        }

        private void OnWarning(Object sender, WarningEventArgs e)
        {
            Console.WriteLine("Warning: " + e.ToString());
        }

        private AutoResetEvent DisconnectedEvent = new AutoResetEvent(false);
        private int OrderCounter;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                Acceptor acceptor = new Acceptor();

                acceptor.Run();

                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }

		#region IDisposable Members

		public void Dispose()
		{
			DisconnectedEvent.Close();
		}

		#endregion
	}
}