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
using System.Threading;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX44;

namespace PluggableSessionStorage
{
    class Sample : IDisposable
    {
        const ProtocolVersion version = ProtocolVersion.FIX44;

        public void Run(int port)
        {
            MySessionStorage storage = new MySessionStorage();

            const string sender = "FileBasedStorage";
            const string target = "PluggableStorage";

            Session acceptor = new Session(sender, target, version, false);

            acceptor.InboundSessionMsgEvent += new InboundSessionMsgEventHandler(acceptor_InboundSessionMsgEvent);
            acceptor.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(acceptor_InboundApplicationMsgEvent);

            acceptor.LogonAsAcceptor();

            Session initiator = new Session(target, sender, version, false, storage);

            initiator.InboundSessionMsgEvent += new InboundSessionMsgEventHandler(initiator_InboundSessionMsgEvent);
            initiator.MessageResending += new MessageResendingEventHandler(initiator_MessageResending);
            
            initiator.LogonAsInitiator("localhost", port);

            Message order = CreateOrder();
            initiator.Send(order);

            inboundApplicationMessageEvent.WaitOne();
                        
            Message resendRequest = new Message(MsgType.ResendRequest, version);
            resendRequest.Set(Tags.BeginSeqNo, 1);

            acceptor.Send(resendRequest);

            inboundApplicationMessageEvent.WaitOne();

            initiator.Logout();
            acceptor.Logout();

            initiator.Dispose();
            acceptor.Dispose();
        }

        void initiator_InboundSessionMsgEvent(object sender, InboundSessionMsgEventArgs args)
        {
            Console.WriteLine("\nInitiator received " + args.Msg.ToString(Message.StringFormat.TAG_NAME, '|'));
        }

        void acceptor_InboundSessionMsgEvent(object sender, InboundSessionMsgEventArgs args)
        {
            Console.WriteLine("\nAcceptor received " + args.Msg.ToString(Message.StringFormat.TAG_NAME, '|'));
        }

        void initiator_MessageResending(object sender, MessageResendingEventArgs e)
        {
            e.AllowResending = true;
        }
        
        void acceptor_InboundApplicationMsgEvent(object sender, InboundApplicationMsgEventArgs args)
        {
            Console.WriteLine("\nAcceptor received " + args.Msg.ToString(Message.StringFormat.TAG_NAME, '|'));

            inboundApplicationMessageEvent.Set();
        }

        AutoResetEvent inboundApplicationMessageEvent = new AutoResetEvent(false);

        public static Message CreateOrder()
        {
            Message order = new Message(MsgType.NewOrderSingle, version);
            order.Set(Tags.HandlInst, HandlInst.AutoExecPriv);
            order.Set(Tags.ClOrdID, "Unique identifier for Order");
            order.Set(Tags.Symbol, "AAPL");
            order.Set(Tags.Side, Side.Buy);
            order.Set(Tags.OrderQty, 1000);
            order.Set(Tags.OrdType, OrdType.Market);
            return order;
        }

		#region IDisposable Members

		public void Dispose()
		{
			inboundApplicationMessageEvent.Close();
		}

		#endregion
	}
}
