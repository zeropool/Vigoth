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
using System.Reflection;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX44;
using Helpers;
using System.Globalization;

namespace BuySide
{
    /// <summary>
    /// Establishes the FIX session as Initiator.
    /// </summary>
    internal class Initiator
    {
        private static void OnInboundApplicationMsg(Object sender, InboundApplicationMsgEventArgs e)
        {
            Console.WriteLine("Incoming application-level message:\n" + e.Msg);
            // Processing of the application-level incoming message ... 
        }

        private static void Run()
        {
            try
            {
                EngineSettings settings = new EngineSettings();

                Engine.Init(settings);

                Session sn = new Session(Settings.Get("SenderCompID"),
                                         Settings.Get("TargetCompID"),
                                         Settings.GetVersion());

                sn.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(OnInboundApplicationMsg);
                sn.StateChangeEvent += new StateChangeEventHandler(OnStateChange);

				sn.LogonAsInitiator(Settings.Get("Counterparty Host"), Settings.GetInteger("Counterparty Port"));

                Console.WriteLine("Press any key to send an order.");
                Console.ReadKey();

                Message order = CreateOrderMessage();

                sn.Send(order);

                Console.WriteLine("The order (" + order + ") was sent");

                Console.WriteLine("Press any key to disconnect the session and terminate the application.");
                Console.ReadKey();

                sn.Logout("The session is disconnected by BuySide");
                sn.Dispose();

                Engine.Instance.Shutdown();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }

        private static Message CreateOrderMessage()
        {
            Message order = new Message("D", Settings.GetVersion());
            order.Set(Tags.HandlInst, "1");
            order.Set(Tags.ClOrdID, "Unique identifier for Order");
            order.Set(Tags.Symbol, "IBM");
            order.Set(Tags.Side, "1");
            order.Set(Tags.OrderQty, 1000);
            order.Set(Tags.OrdType, "1");
			order.Set(Tags.TransactTime, DateTime.UtcNow.ToString("yyyyMMdd-HH:mm:ss", CultureInfo.InvariantCulture));

            order.Validate();
            return order;
        }

        private static void OnStateChange(Object sender, StateChangeEventArgs e)
        {
            Console.WriteLine("New session state: " + e.NewState);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Run();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}