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
using FIXForge.NET.FIX;
using FIX42.Application.OrdersAndExecutionsTrade.SingleGeneralOrderHandling;

namespace TypedMessagesSample
{
	class Program
	{       
		static void Main(string[] args)
		{
            const string senderCompID = "Acceptor";
            const string targetCompID = "Initiator";
            const ProtocolVersion version = ProtocolVersion.FIX44;
            const string host = "localhost";
            const int port = 4500;

            Engine engine = Engine.Init(port);

            using (Session acceptor = new Session(senderCompID, targetCompID, version))
            {
                FIX42.TypedMessageListener acceptorTypedMessageListener = new FIX42.TypedMessageListener(acceptor);

                acceptorTypedMessageListener.OrderSingleReceived += new Action<OrderSingle>((order) =>
                {
                    Console.WriteLine("Acceptor has received the Order Single message:  ClOrdID=" + order.ClOrdID + "; Msg(" + ((Message)order) + ")\n");
                    Console.WriteLine("NoAllocs group size: " + order.NoAllocs.Count);

                    foreach (FIX42.OrderSingleNoAllocsInstance instance in order.NoAllocs)
                    {
                        Console.WriteLine("AllocAccount=" + instance.AllocAccount + "; AllocShares=" + instance.AllocShares);
                    }

                    ExecutionReport report = new ExecutionReport(order.ClOrdID, "Report1", FIX42.ExecTransType.New, FIX42.ExecType.Fill, FIX42.OrdStatus.Filled, order.Symbol, order.Side, 0, 10000, 100);
                    acceptor.Send(report);
                    Console.WriteLine("\n");
                });    

                acceptor.LogonAsAcceptor();

                using (Session initiator = new Session(targetCompID, senderCompID, version))
                {
                    FIX42.TypedMessageListener initiatorTypedMessageListener = new FIX42.TypedMessageListener(initiator);

                    initiatorTypedMessageListener.ExecutionReportReceived += new Action<ExecutionReport>((report) =>
                    {
                        Console.WriteLine("Initiator has received the Execution Report message: OrderID=" + report.OrderID + "; Msg(" + ((Message)report) + ")\n");
                        Console.WriteLine("Press any key to disconnect the session and terminate the application.\n");
                    });           

                    initiator.LogonAsInitiator(host, Engine.Instance.Settings.ListenPort);                   

                    OrderSingle order = new OrderSingle();

                    order.ClOrdID = "Order1";
                    order.HandlInst = FIX42.HandlInst.AutomatedExecutionNoIntervention;
                    order.Symbol = "Ticker symbol";
                    order.Side = FIX42.Side.Buy;
                    order.TransactTime = DateTime.UtcNow;
                    order.OrdType = FIX42.OrdType.Market;
                    order.OrderQty = 10000;

                    FIX42.OrderSingleNoAllocsInstance orderSingleNoAllocsInstance1 = order.NoAllocs.CreateNew();
                    orderSingleNoAllocsInstance1.AllocAccount = "AllocAccount1";
                    orderSingleNoAllocsInstance1.AllocShares = 10;
                    FIX42.OrderSingleNoAllocsInstance orderSingleNoAllocsInstance2 = order.NoAllocs.CreateNew();
                    orderSingleNoAllocsInstance2.AllocAccount = "AllocAccount2";
                    orderSingleNoAllocsInstance2.AllocShares = 20;

                    ((Message)order).Validate();

                    Console.WriteLine("Press any key to send an order.\n");
                    Console.ReadKey();

                    initiator.Send(order);

                    Console.WriteLine("The order (" + ((Message)order) + ") was sent by the Initiator\n");
                   
                    Console.ReadKey();

                    initiator.Logout();
                }

                acceptor.Logout();
            }

            engine.Shutdown();
		}
	}
}
