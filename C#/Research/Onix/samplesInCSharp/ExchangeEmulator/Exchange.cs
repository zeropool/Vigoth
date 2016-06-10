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

#region using Directives
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX44;
using Onixs.FixControls;
#endregion

namespace ExchangeEmulator
{
    internal class Exchange
    {
        private Session session;
        private  ILogger logger;
        private int reportsCounter;
        private EmulationMode mode;

        internal EmulationMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public Exchange(Session session, ILogger logger)
        {
            this.session = session;
            this.logger = logger;
            mode = EmulationMode.Trading;
        }

        public enum EmulationMode
        {
            Trading,
            CancelOrders,
            ConfirmOrdersOnly,
            DoNothing,
            FillOrdersPartially,
            FillOrders,            
            RejectOrders            
        }

        Dictionary<string, Message> clientOrderId2order = new Dictionary<string, Message>();

        Dictionary<string, string> clientOrderId2orderId = new Dictionary<string, string>();

        IEnumerable<Message> ProcessNewOrderSingle(Message order)
        {
            List<Message> replies = new List<Message>();
            string orderType = order[Tags.OrdType];
            if (orderType != OrdType.Market && orderType != OrdType.Limit)
            {
                Message rejectedOrderReport = CreateExecutionReport(order, OrdStatus.Rejected, "NONE",
                                                        string.Format(CultureInfo.InvariantCulture, "Cannot process the order of type '{0}'", orderType));
                rejectedOrderReport[Tags.OrdRejReason] = OrdRejReason.Unknown;
                replies.Add(rejectedOrderReport);
                return replies;
            }

            string clientOrderId = order.Get(Tags.ClOrdID);
            if (clientOrderId2order.ContainsKey(clientOrderId))
            {
                Message rejectedOrderReport = CreateExecutionReport(order, OrdStatus.Rejected, "NONE", "ClOrdID(11) field must be unique");
                rejectedOrderReport[Tags.OrdRejReason] = OrdRejReason.Duplicate;
                replies.Add(rejectedOrderReport);
                return replies;
            }
            else
            {
                clientOrderId2order.Add(clientOrderId, order);
            }

            if (EmulationMode.RejectOrders == mode)
            {
                Message rejectedOrderReport = CreateExecutionReport(order, OrdStatus.Rejected, GetNextOrderID());
                rejectedOrderReport[Tags.OrdRejReason] = OrdRejReason.BrokerOpt;
                replies.Add(rejectedOrderReport);

                return replies;
            }

            string orderId = GetNextOrderID();
            clientOrderId2orderId.Add(clientOrderId, orderId);

            Message acceptedOrderReport = CreateExecutionReport(order, OrdStatus.New, orderId);
            replies.Add(acceptedOrderReport);

            if(EmulationMode.ConfirmOrdersOnly == mode)
            {
                return replies;
            }
            else if(EmulationMode.CancelOrders == mode)
            {
                Message canceledOrderReport = CreateExecutionReport(order, OrdStatus.Canceled, acceptedOrderReport[Tags.OrderID]);                
                replies.Add(canceledOrderReport);

                return replies;
            }

            Message filledOrderReport = CreateExecutionReport(order, OrdStatus.Filled, acceptedOrderReport[Tags.OrderID]);
            double? price = null;
            switch (orderType)
            {
                case OrdType.Limit:
                    price = CalculatePriceForLimitOrder(order);
                    break;

                case OrdType.Market:
                    price = CalculatePriceForMarketOrder();
                    break;
            }

            if (EmulationMode.FillOrders == mode)
            {
                if (!price.HasValue)
                {
                    Debug.Assert(OrdType.Limit == orderType);
                    price = order.GetDouble(Tags.Price);
                }
            }
            else if(EmulationMode.FillOrdersPartially == mode)
            {
                if (! price.HasValue)
                {
                    Debug.Assert(OrdType.Limit == orderType);
                    price = order.GetDouble(Tags.Price);
                }                
                filledOrderReport[Tags.OrdStatus] = OrdStatus.Partial;
                filledOrderReport[Tags.ExecType] = ExecType.Trade;
                double orderQuantity = order.GetDouble(Tags.OrderQty);
                double filledQuantity = Math.Round(orderQuantity/2);
                double remainingQuanity = orderQuantity - filledQuantity;
                filledOrderReport.Set(Tags.CumQty, filledQuantity);
                filledOrderReport.Set(Tags.LastQty, filledQuantity);
                filledOrderReport.Set(Tags.LeavesQty, remainingQuanity);
            }

            if (price.HasValue)
            {
                filledOrderReport[Tags.LastPx] = price.Value.ToString(CultureInfo.InvariantCulture);
                filledOrderReport[Tags.AvgPx] = price.Value.ToString(CultureInfo.InvariantCulture);
                replies.Add(filledOrderReport);
            }

            return replies;
        }

        private static double? CalculatePriceForMarketOrder()
        {
            double askPrice = ConfigurationHelper.GetDouble("AskPrice");
            double bidPrice = ConfigurationHelper.GetDouble("BidPrice");
            double priceIncrement = ConfigurationHelper.GetDouble("PriceIncrement");
            Random rnd = new Random();
            double price = bidPrice + rnd.NextDouble() * (askPrice - bidPrice);

            double diff = price % priceIncrement;
            if (diff < priceIncrement / 2)
                price = price - diff;
            else
                price = price - diff + priceIncrement;

            return price;
        }

        private static double? CalculatePriceForLimitOrder(Message order)
        {
            double askPrice = ConfigurationHelper.GetDouble("AskPrice");
            double bidPrice = ConfigurationHelper.GetDouble("BidPrice");
            string side = order[Tags.Side];
            double limitPrice = double.Parse(order[Tags.Price], CultureInfo.InvariantCulture);
            switch (side)
            {
                case Side.Sell:
                    if (bidPrice >= limitPrice)
                        return bidPrice;
                    break;

                case Side.Buy:
                    if (askPrice <= limitPrice)
                        return limitPrice;
                    break;
            }
            return null;
        }

        public void ProcessIncomingMessage(Message message)
        {
            if(EmulationMode.DoNothing == mode)
            {
                return;
            }
            
            try
            {
                List<Message> replies = new List<Message>();
                switch (message.Type)
                {
                    case MsgType.NewOrderSingle:
                        replies.AddRange(ProcessNewOrderSingle(message));
                        break;

                    case MsgType.OrderCancelRequest:
                        {
                            Message reply = CreateExecutionReport(message, OrdStatus.Canceled);
                            clientOrderId2orderId.Add(message[Tags.ClOrdID], reply[Tags.OrderID]);
                            clientOrderId2order.Add(message[Tags.ClOrdID], message);
                            replies.Add(reply);
                        }
                        break;

                    case MsgType.OrderCancelReplaceRequest:
                        {
                            Message reply = CreateExecutionReport(message, OrdStatus.Replaced);
                            clientOrderId2orderId.Add(message[Tags.ClOrdID], reply[Tags.OrderID]);
                            clientOrderId2order.Add(message[Tags.ClOrdID], message);
                            replies.Add(reply);
                        }
                        break;

                    default:
                        Message email = new Message(MsgType.Email, session.Version);
                        email[Tags.EmailThreadID] = "Exchange Emulator reply";
                        email[Tags.EmailType] = EmailType.New;
                        email[Tags.Subject] = "Message was received";

                        email[Tags.EmailType] = EmailType.New;
                        Group lines = email.SetGroup(Tags.NoLinesOfText, 1);
                        lines.Set(Tags.Text, 0, "The message of MsgType=" + message[Tags.MsgType] + " was received");

                        replies.Add(email);
                        break;
                }

                foreach (Message reply in replies)
                {
                    reply.Validate();
                    session.Send(reply);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception: " + ex);
                logger.LogError("Exception during the processing of the incoming message: " + ex);
            }
        }

        int[] tagsToCopyFromOrderToExecutionReport = {
                    Tags.Account, Tags.ClOrdID, Tags.Currency, Tags.ExpireTime, Tags.ExpireDate,
                    Tags.HandlInst, Tags.MinQty, Tags.MaturityMonthYear, Tags.MaxFloor, Tags.MaturityDay, 
                    Tags.OrderID, Tags.OrderQty, Tags.OrigClOrdID, Tags.OptAttribute, Tags.OrdType, Tags.Price, Tags.PutOrCall,
                    Tags.SecurityID, Tags.SecurityType, Tags.SettlType, Tags.Side, Tags.StopPx, Tags.Symbol, Tags.StrikePrice,
                    Tags.Text, Tags.TimeInForce, Tags.TradingSessionID, Tags.TransactTime
                };

        private Message CreateExecutionReport(Message order, string status, string orderID, string text)
        {
            Message report = CreateExecutionReport(order, status);
            report[Tags.OrderID] = orderID;
            report[Tags.Text] = text;
            return report;
        }

        private Message CreateExecutionReport(Message order, string status, string orderID)
        {
            Message report = CreateExecutionReport(order, status);
            report[Tags.OrderID] = orderID;
            return report;
        }

        private static string GetNextOrderID()
        {
			return "OrderID_" + DateTime.Now.ToString("HHmmss", CultureInfo.InvariantCulture);
        }

        private Message CreateExecutionReport(Message source, string status)
        {
            Message report = new Message(MsgType.ExecutionReport, session.Version);

            ++reportsCounter;

            CopyFields(source, report, tagsToCopyFromOrderToExecutionReport);

            report[Tags.ExecID] = "ExecID_" + reportsCounter;
            report[Tags.OrdStatus] = status;
            report[Tags.ExecType] = status;
            report.Set(Tags.AvgPx, 0);
            report.Set(Tags.LastPx, 0);
			report[Tags.TransactTime] = DateTime.Now.ToString("yyyyMMdd-HH:mm:ss", CultureInfo.InvariantCulture);

            switch (status)
            {
                case OrdStatus.New:
                case OrdStatus.Replaced:
                    report.Set(Tags.CumQty, 0);
                    report.Set(Tags.LastQty, 0);
                    report[Tags.LeavesQty] = source[Tags.OrderQty];
                    break;

                case OrdStatus.Filled:
                    report[Tags.CumQty] = source[Tags.OrderQty];
                    report.Set(Tags.LastQty, source[Tags.OrderQty]);
                    report.Set(Tags.LeavesQty, 0);
                    break;

                case OrdStatus.Canceled:
                    report.Set(Tags.CumQty, 0);
                    report.Set(Tags.LastQty, 0);
                    report.Set(Tags.LeavesQty, 0);
					string origId;
					if (source.Contain(Tags.OrigClOrdID))
						origId = source[Tags.OrigClOrdID];
					else
						origId = source[Tags.ClOrdID];
					report.Set(Tags.OrderID, clientOrderId2orderId[origId]);

                    break;

                case OrdStatus.Rejected:
                    report.Set(Tags.CumQty, 0);
                    report.Set(Tags.LastQty, 0);
                    report.Set(Tags.LeavesQty, 0);
                    break;

                default:
                    Debug.Fail("Unsupported Order Status");
                    break;

            }

            return report;
        }      

        internal static void CopyFields(Message source, Message destination, int[] tags)
        {
            foreach (int tag in tags)
            {
                string value = source[tag];
                if (null != value)
                {
                    destination.Set(tag, value);
                }
            }
        }
    }
}