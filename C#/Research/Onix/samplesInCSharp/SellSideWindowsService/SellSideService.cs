using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX44;
using Helpers;

namespace SellSideWindowsService
{
    public partial class SellSideService : ServiceBase
    {
        private int OrderCounter;
        private const ProtocolVersion fixVersion = ProtocolVersion.FIX44;
        Session sn;

        public SellSideService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            EngineSettings settings = new EngineSettings();

            settings.SendLogoutOnException = true;
            settings.SendLogoutOnInvalidLogon = true; // E.g. to send a Logout when the sequence number of the incoming Logon (A) message is less than expected.

            Engine.Init(settings);

            string senderCompID = Settings.Get("SenderCompID");
            string targetCompID = Settings.Get("TargetCompID");

            sn = new Session(senderCompID, targetCompID, fixVersion);

            sn.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(OnInboundApplicationMsg);

            sn.LogonAsAcceptor();
        }

        protected override void OnStop()
        {
            if (sn != null)
            {
                sn.Logout();
                sn = null;
            }
            Engine.Instance.Shutdown();
        }

        private void OnInboundApplicationMsg(Object sender, InboundApplicationMsgEventArgs e)
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

            Session sn = (Session)sender;

            foreach (Message reply in replies)
            {
                reply.Validate();
                sn.Send(reply);
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
    }
}
