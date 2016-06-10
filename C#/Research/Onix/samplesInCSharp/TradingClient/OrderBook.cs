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
using System.Diagnostics;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX44;
using Onixs.FixControls;

namespace TradingClientSample
{
    /// <summary>
    /// Orders collection.
    /// </summary>
    class OrderBook
    {
        public OrderBook(ILogger logger)
        {
            this.logger = logger;
        }

        ILogger logger;

        public void AddOrder(Order order)
        {
            clientOrderID2order.Add(order.ClientOrderID, order);
        }

        public Order UpdateOrder(Message executionReport)
        {
            Debug.Assert(MsgType.ExecutionReport == executionReport.Type);           

            string clientOrderID = executionReport[Tags.ClOrdID];
            Order order;
            if(clientOrderID2order.ContainsKey(clientOrderID))
            {
                order = clientOrderID2order[clientOrderID];
            }else{
                string origClientOrderID = executionReport[Tags.OrigClOrdID];
                if (! string.IsNullOrEmpty(origClientOrderID) && clientOrderID2order.ContainsKey(origClientOrderID))
                {
                    order = clientOrderID2order[origClientOrderID];
                    order.OriginalClientOrderID = origClientOrderID;
                    order.ClientOrderID = clientOrderID;
                    clientOrderID2order.Add(clientOrderID, order);
                }
                else
                {
                   logger.LogWarning("Received Execution Report with unknown ClOrdID(11)=" + clientOrderID);
                   Trace.TraceWarning("Received Execution Report with unknown ClOrdID(11)=" + clientOrderID);
                   return null;
                }
            }
            
             
            string lastPx = executionReport[Tags.LastPx];
            if (!string.IsNullOrEmpty(lastPx))
            {
                order.LastFillPrice = double.Parse(lastPx, System.Globalization.CultureInfo.InvariantCulture);
            }

            string originalClientOrderID = executionReport[Tags.OrigClOrdID];
            if(! string.IsNullOrEmpty(originalClientOrderID))
            {
                order.OriginalClientOrderID = originalClientOrderID;
            }

            string cumQty = executionReport[Tags.CumQty];
            if (!string.IsNullOrEmpty(cumQty))
            {
                order.FilledQuantity = double.Parse(cumQty, System.Globalization.CultureInfo.InvariantCulture);
            }

            string orderID = executionReport[Tags.OrderID];
            if (!string.IsNullOrEmpty(orderID))
            {
                order.OrderID = orderID;
            }

            string orderStatus = executionReport[Tags.OrdStatus];
            order.Status = ParseFixOrderStatus(orderStatus);

            string text = executionReport[Tags.Text];
            if (!string.IsNullOrEmpty(text))
            {
                order.Text = text;
            }

            return order;
        }

        public Order FindOrderByClientOrderID(string clientOrderID)
        {
            if (clientOrderID2order.ContainsKey(clientOrderID))
             {
                 return clientOrderID2order[clientOrderID];
             }
            else
            {
                return null;
            }
        }

        private Dictionary<string, Order> clientOrderID2order = new Dictionary<string, Order>();

        private static Order.OrderStatus ParseFixOrderStatus(string ordStatus)
        {
            switch (ordStatus)
            {                   
                case "0":
                    return Order.OrderStatus.New;

                case "1":
                    return Order.OrderStatus.PartialFill;

                case "2":
                    return Order.OrderStatus.Fill;

                case "3":
                    return Order.OrderStatus.DoneForDay;

                case "4":
                    return Order.OrderStatus.Canceled;

                case "5":
                    return Order.OrderStatus.Replace;

                case "6":
                    return Order.OrderStatus.PendingCancel;

                case "7":
                    return Order.OrderStatus.Stopped;

                case "8":
                    return Order.OrderStatus.Rejected;

                case "9":
                    return Order.OrderStatus.Suspended;

                case "A":
                    return Order.OrderStatus.PendingNew;

                case "C":
                    return Order.OrderStatus.Calculated;

                case "D":
                    return Order.OrderStatus.Restated;

                case "E":
                    return Order.OrderStatus.PendingReplace;

                default:
                    throw new ApplicationException("Unsuppported order status: '" + ordStatus + "'");
            }
        }     
    }
}