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
using System.Diagnostics;

using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX43;
using Onixs.FixControls;
using System.Globalization;

namespace TradingClientSample
{
    public class TradingManager : IDisposable
    {
        private Session session;
		private SessionConfiguration settings;
		private ILogger logger;
		private OrderBook orderBook;

        public TradingManager(SessionConfiguration settings, ILogger logger)
        {
			this.settings = settings;
			this.logger = logger;

			Debug.Assert(Engine.IsInitialized());

            orderBook = new OrderBook(logger);
			session = new Session(settings.SenderCompID, settings.TargetCompID, settings.Version, settings.KeepSequenceNumbersAfterLogout);

            if (!string.IsNullOrEmpty(settings.SenderSubID))
                session.SenderSubID = settings.SenderSubID;

			if (settings.UseSslEncryption)
				session.Encryption = EncryptionMethod.SSL;
			else
				session.Encryption = EncryptionMethod.NONE;
			if (!string.IsNullOrEmpty(settings.SslCertificateFile))
			{
				session.Ssl.CertificateFile = settings.SslCertificateFile;
				session.Ssl.PrivateKeyFile = settings.SslCertificateFile;
			}
			session.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(session_InboundApplicationMsgEvent);
		}

        [CLSCompliantAttribute(false)]
		public Session Session
        {
            get
            {
                return session;
            }
		}

		/// <summary>
        /// Establishes the FIX Session.
        /// </summary>
        public void Connect()
        {

            // A custom Logon message is only needed if some non-standard fields should to be used in the initial Logon(A) message, 
            // otherwise a simpler overload of Session.LogonAsInitiator method could be used.
            Message customLogon = new Message(MsgType.Logon, session.Version);

            if (!string.IsNullOrEmpty(settings.Username))
            {
				customLogon.Set(Tags.Username, settings.Username);
            }

			if (!string.IsNullOrEmpty(settings.Password))
            {
				customLogon.Set(Tags.Password, settings.Password);
            }

            if (!string.IsNullOrEmpty(settings.ClientID))
            {
				customLogon.Set(Tags.ClientID, settings.ClientID);
            }

            if (!string.IsNullOrEmpty(settings.RawData))
            {
				customLogon.Set(Tags.RawData, settings.RawData);
				customLogon.Set(Tags.RawDataLength, settings.RawData.Length);
            }

			session.LogonAsInitiator(settings.Host, settings.Port, settings.HeartbeatInterval, customLogon, settings.SetResetSeqNumFlag);
        }

        public void Disconnect()
        {
            session.Logout("Trading Client initiated the termination of the FIX Connection");
        }

		public static string GetNextClientOrderID()
		{
			return DateTime.Now.ToString("yyyyMMdd-HHmmss-fffffff", CultureInfo.InvariantCulture);
		}

		public bool IsClientOrderIdUnique(string clientOrderID)
		{
			return (null == orderBook.FindOrderByClientOrderID(clientOrderID));
		}

		public void SendNewOrder(Order order)
		{
			Message message = new Message(MsgType.Order_Single, session.Version);

			message[Tags.ClOrdID] = order.ClientOrderID;
			message[Tags.HandlInst] = HandlInst.Automated_execution_order_private_no_Broker_intervention;
			message[Tags.Symbol] = order.Symbol;
			message.Set(Tags.Side, (int)order.Side);
			message[Tags.TransactTime] = order.TransactTime.ToString("yyyyMMdd-HH:mm:ss.fff", CultureInfo.InvariantCulture);
			message.Set(Tags.OrdType, Char.ToString((char)order.Type));

			if (Order.OrderType.Market != order.Type
				&& Order.OrderType.ForeignExchangeMarketOrder != order.Type
				)
			{
				message.Set(Tags.Price, order.Price);
			}

			message.Set(Tags.OrderQty, order.Quantity);


			if (!string.IsNullOrEmpty(order.Currency))
			{
				message.Set(Tags.Currency, order.Currency);
			}

			message.Set(Tags.SettlmntTyp, SettlmntTyp.Regular);
			message.Set(Tags.MaxFloor, 0);
			message.Set(Tags.TimeInForce, TimeInForce.Day);

			if (session.Version < ProtocolVersion.FIX43)
			{
				message.Set(Tags.Rule80A, Rule80A.Individual_Investor_single_order);
			}

			if (!string.IsNullOrEmpty(settings.Account))
			{
				message[Tags.Account] = settings.Account;
			}

			if (!string.IsNullOrEmpty(order.SecurityID))
			{
				message[Tags.SecurityID] = order.SecurityID;
			}

			if (!string.IsNullOrEmpty(order.Text))
			{
				message[Tags.Text] = order.Text;
			}

			orderBook.AddOrder(order);
			session.Send(message);
		}

        public void ModifyOrder(Order order)
        {
            Message request = new Message(MsgType.Order_Cancel_Replace_Request, session.Version);

			if (!string.IsNullOrEmpty(settings.Account))
            {
				request[Tags.Account] = settings.Account;
            }
            
            request[Tags.ClOrdID] = GetNextClientOrderID();
            request[Tags.OrigClOrdID] = order.ClientOrderID;
            request[Tags.OrderID] = order.OrderID;
            request[Tags.Symbol] = order.Symbol;
            request.Set(Tags.Side, (int)order.Side);
            request.Set(Tags.OrderQty, order.Quantity);
			request[Tags.TransactTime] = DateTime.Now.ToString("yyyyMMdd-HH:mm:ss", CultureInfo.InvariantCulture);
            request.Set(Tags.OrdType, Char.ToString((char)order.Type));

            if (Order.OrderType.Market != order.Type
               && Order.OrderType.ForeignExchangeMarketOrder != order.Type
               )
            {
                request.Set(Tags.Price, order.Price);
            }

            if (session.Version < ProtocolVersion.FIX43)
            {
                request.Set(Tags.Rule80A, Rule80A.Individual_Investor_single_order);
            }            

            if (!string.IsNullOrEmpty(order.SecurityID))
            {
                request[Tags.SecurityID] = order.SecurityID;
            }

            if (!string.IsNullOrEmpty(order.Text))
            {
                request[Tags.Text] = order.Text;
            }

            session.Send(request);
		}

		public void CancelOrder(Order order)
		{
			Message request = new Message(MsgType.Order_Cancel_Request, session.Version);

			if (!string.IsNullOrEmpty(settings.Account))
			{
				request[Tags.Account] = settings.Account;
			}

			request[Tags.ClOrdID] = GetNextClientOrderID();
			request[Tags.OrigClOrdID] = order.ClientOrderID;
			request[Tags.OrderID] = order.OrderID;
			request[Tags.Symbol] = order.Symbol;
			request.Set(Tags.Side, (int)order.Side);
			request.Set(Tags.OrderQty, order.Quantity);
			request[Tags.TransactTime] = DateTime.UtcNow.ToString("yyyyMMdd-HH:mm:ss", CultureInfo.InvariantCulture);

			session.Send(request);
		}

		public event EventHandler<OrderStateChangedArgs> OrderStateChanged;

        public class OrderStateChangedArgs : EventArgs
        {
            public OrderStateChangedArgs(Order order)
            {
                this.order = order;
            }

            public Order Order
            {
                get
                {
                    return order;
                }
            }

            private Order order;
        }

        private void session_InboundApplicationMsgEvent(object sender, InboundApplicationMsgEventArgs args)
        {
            try
            {
                if (MsgType.Execution_Report != args.Msg.Type)
                {
                    return;
                }
                Order order = orderBook.UpdateOrder(args.Msg);
                if (null != order)
                {
                    OrderStateChanged(this, new OrderStateChangedArgs(order));
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Exception during the processing of incoming FIX message: " + ex);
                Trace.TraceError("Exception during the processing of incoming FIX message: " + ex);
            }
        }

		#region IDisposable Members

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (session != null)
				{
					session.Dispose();
					session = null;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
