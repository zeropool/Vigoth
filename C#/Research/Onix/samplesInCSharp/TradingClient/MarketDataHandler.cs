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
using System.Globalization;
using System.Text;

using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX43;
using Onixs.FixControls;

namespace TradingClientSample
{
	/// <summary>
    /// Encapsulates Market Data Stream processing logic.
	/// </summary>
	public class MarketDataHandler : IDisposable
	{
		private Session session;
		private SessionConfiguration settings;
		private ILogger logger;
		private Dictionary<string, MarketDataUpdate> lastMD;
		private int requestsCounter = 0;
		private Dictionary<string, Message> mdId2Request;

		public MarketDataHandler(SessionConfiguration settings, ILogger logger)	
		{
			this.settings = settings;
			this.logger = logger;
			
			Debug.Assert(Engine.IsInitialized());

			lastMD = new Dictionary<string, MarketDataUpdate>();
			mdId2Request = new Dictionary<string, Message>();
			session = new Session(settings.SenderCompID, settings.TargetCompID, settings.Version, settings.KeepSequenceNumbersAfterLogout);
			if (settings.UseSslEncryption)
				session.Encryption = EncryptionMethod.SSL;
			else
				session.Encryption = EncryptionMethod.NONE;
			if (!string.IsNullOrEmpty(settings.SslCertificateFile))
			{
				session.Ssl.CertificateFile = settings.SslCertificateFile;
				session.Ssl.PrivateKeyFile = settings.SslCertificateFile;
			}
			session.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(OnInboundApplicationMsg);
		}

		#region Session Management

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

		#endregion Session Management

		#region Market Data Management

		/// <summary>
        /// Subscribes to Market Data
        /// </summary>
        /// <param name="symbol">Symbol to subscribe</param>
		/// <param name="requestUpdates">True if request snapshot and updates, False if snapshot only</param>
		/// <returns>Request ID</returns>
        public string Subscribe(string symbol, bool requestUpdates)
        {
            if (SessionState.ACTIVE != session.State)
            {
                throw new ApplicationException("Cannot subscribe to the symbol '" + symbol + "' : the market data session is in " +
                                               session.State + " state");
            }

            Message request = new Message(MsgType.Market_Data_Request, session.Version);

            request.Set(Tags.MDReqID, ++requestsCounter);
			request.Set(Tags.SubscriptionRequestType, requestUpdates ? SubscriptionRequestType.Snapshot__plus__Updates : SubscriptionRequestType.Snapshot);
            request.Set(Tags.MarketDepth, MarketDepth.Top_of_Book);
            request.Set(Tags.MDUpdateType, MDUpdateType.Incremental_Refresh);
            request.Set(Tags.AggregatedBook, "Y");

            Group entryTypes = request.SetGroup(Tags.NoMDEntryTypes, 2);
            entryTypes.Set(Tags.MDEntryType, 0, MDEntryType.Bid);
            entryTypes.Set(Tags.MDEntryType, 1, MDEntryType.Offer);

            Group relatedSymbols = request.SetGroup(Tags.NoRelatedSym, 1);
            relatedSymbols.Set(Tags.Symbol, 0, symbol);

            session.Send(request);

			lock (mdId2Request)
				mdId2Request.Add(requestsCounter.ToString(CultureInfo.InvariantCulture), request);

			return requestsCounter.ToString(CultureInfo.InvariantCulture);
        }

        public void Unsubscribe(string requestID)
        {
			lock (mdId2Request)
			{
				if (!mdId2Request.ContainsKey(requestID))
				{
					throw new ApplicationException("Unknown MD Request ID: '" + requestID + "'");
				}
				Message request = (Message)mdId2Request[requestID];
				request.Set(Tags.SubscriptionRequestType, SubscriptionRequestType.Disable_previous_Snapshot__plus__Update_Request);
				session.Send(request);
				mdId2Request.Remove(requestID);
			}
		}

		public List<string> Subscriptions
		{
			get
			{
				lock (mdId2Request)
				{
					List<string> res = new List<string>();
					foreach (KeyValuePair<string, Message> item in mdId2Request)
					{
						res.Add(item.Key + " - " + item.Value.GetGroup(Tags.NoRelatedSym).Get(Tags.Symbol, 0));
					}
					return res;
				}
			}
		}

		public void RequestSecurityDefinitions()
		{
			if (SessionState.ACTIVE != session.State)
			{
				throw new ApplicationException("Cannot request security definitions: the market data session is in " +
											   session.State + " state");
			}

			Message request = new Message(MsgType.Security_Definition_Request, session.Version);

			request.Set(Tags.SecurityReqID, ++requestsCounter);
			request.Set(Tags.SecurityRequestType, SecurityRequestType.Request_List_Securities);

			session.Send(request);

			//mdId2Request.Add(requestsCounter.ToString(), request);
		}

		#endregion Market Data Management

		#region Market Data Processing

        [CLSCompliantAttribute(false)]
		protected void OnInboundApplicationMsg(Object sender, InboundApplicationMsgEventArgs args)
		{
            Message incomingMessage = args.Msg;
            switch (incomingMessage.Type)
			{
				case MsgType.Market_Data_Incremental_Refresh: 
					ProcessMarketDataIncrementalRefresh(incomingMessage);
					break;
				case MsgType.Market_Data_Snapshot_Full_Refresh:
					ProcessMarketDataFullRefresh(incomingMessage);
					break;
				case MsgType.Security_Definition:
					ProcessSecurityDefinition(incomingMessage);
					break;
			}
		}

		private class MarketDataUpdate
		{
			public double Bid = 0;
			public double Ask = 0;
			public double BidSize = 0;
			public double AskSize = 0;
		}

		private void ProcessMarketDataIncrementalRefresh(Message msg)
		{
			Debug.Assert(MsgType.Market_Data_Incremental_Refresh == msg.Type);

			string mdReqID = msg.Get(Tags.MDReqID);

			MarketDataUpdate update;
			lock (lastMD)
			{
				if (!lastMD.TryGetValue(mdReqID, out update))
				{
					update = new MarketDataUpdate();
					lastMD.Add(mdReqID, update);
				}
			}

			string symbol = null;

			bool isPriceChanged = false;

			Group mdDEntries = msg.GetGroup(Tags.NoMDEntries);
			for (int i = 0; i < mdDEntries.NumberOfInstances; ++i)
			{
				if (null == symbol)
				{
					symbol = mdDEntries.Get(Tags.Symbol, i);
				}
				else
				{
					Debug.Assert(mdDEntries.Get(Tags.Symbol, i) == symbol);
				}
				string priceValue = mdDEntries.Get(Tags.MDEntryPx, i);
				if (null != priceValue)
				{
					double price;
					if (double.TryParse(priceValue, NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out price))
					{
						double size = 0;
						string sizeValue = mdDEntries.Get(Tags.MDEntrySize, i);
						if (!string.IsNullOrEmpty(sizeValue))
							double.TryParse(sizeValue, NumberStyles.Number, CultureInfo.InvariantCulture, out size);
						string entryType = mdDEntries.Get(Tags.MDEntryType, i);
						if (MDEntryType.Bid == entryType)
						{
							if (update.Bid != price)
							{
								update.Bid = price;
								update.BidSize = size;
								isPriceChanged = true;
							}
						}
						else if (MDEntryType.Offer == entryType)
						{
							if (update.Ask != price)
							{
								update.Ask = price;
								update.AskSize = size;
								isPriceChanged = true;
							}
						}
						else if (MDEntryType.Trade == entryType)
						{
							TradeArgs rv = new TradeArgs(symbol, price, size);
							if (TradeReceived != null)
								TradeReceived(this, rv);
						}
					}
				}
			}

			if (isPriceChanged)
			{
				PriceChangeArgs rv = new PriceChangeArgs(symbol, update.Bid, update.BidSize, update.Ask, update.AskSize);
				if (PriceChange != null)
					PriceChange(this, rv);
			}
		}

		private void ProcessMarketDataFullRefresh(Message msg)
		{
			Debug.Assert(MsgType.Market_Data_Snapshot_Full_Refresh == msg.Type);

			MarketDataUpdate update = new MarketDataUpdate();

			string symbol = msg.Get(Tags.Symbol);

			bool isPriceChanged = false;

			Group mdDEntries = msg.GetGroup(Tags.NoMDEntries);
			for (int i = 0; i < mdDEntries.NumberOfInstances; ++i)
			{
				string priceValue = mdDEntries.Get(Tags.MDEntryPx, i);
				if (null != priceValue)
				{
					double price;
					if (double.TryParse(priceValue, NumberStyles.Number, CultureInfo.InvariantCulture, out price))
					{
						double size = 0;
						string sizeValue = mdDEntries.Get(Tags.MDEntrySize, i);
						if (!string.IsNullOrEmpty(sizeValue))
							double.TryParse(sizeValue, NumberStyles.Number, CultureInfo.InvariantCulture, out size);
						string entryType = mdDEntries.Get(Tags.MDEntryType, i);
						if (MDEntryType.Bid == entryType)
						{
							if (update.Bid != price || update.BidSize != size)
							{
								update.Bid = price;
								update.BidSize = size;
								isPriceChanged = true;
							}
						}
						else if (MDEntryType.Offer == entryType)
						{
							if (update.Ask != price || update.AskSize != size)
							{
								update.Ask = price;
								update.AskSize = size;
								isPriceChanged = true;
							}
						}
						else if (MDEntryType.Trade == entryType)
						{
							TradeArgs rv = new TradeArgs(symbol, price, size);
							if (TradeReceived != null)
								TradeReceived(this, rv);
						}
					}
				}
			}

			if (isPriceChanged)
			{
				PriceChangeArgs rv = new PriceChangeArgs(symbol, update.Bid, update.BidSize, update.Ask, update.AskSize);
				if (PriceChange != null)
					PriceChange(this, rv);
			}
		}

		private void ProcessSecurityDefinition(Message msg)
		{
			Debug.Assert(MsgType.Security_Definition == msg.Type);

			if (SecurityDefinitionReceived != null)
			{
				string symbol = msg.Get(Tags.Symbol);
				SecurityDefinitionReceived(this, new SecurityDefinitionArgs(symbol));
			}
		}

		public event EventHandler<PriceChangeArgs> PriceChange;
		public event EventHandler<TradeArgs> TradeReceived;
		public event EventHandler<SecurityDefinitionArgs> SecurityDefinitionReceived;

		public class SecurityDefinitionArgs : EventArgs
		{
			public SecurityDefinitionArgs(string symbol)
			{
				Symbol = symbol;
			}

			public override string ToString()
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("MarketDataFeed.TradeArgs [");
				sb.Append("Symbol=" + Symbol);
				sb.Append("]");
				return sb.ToString();
			}

			public readonly string Symbol;
		}

		public class TradeArgs : EventArgs
		{
			public TradeArgs(string symbol, double price, double size)
			{
				Symbol = symbol;
				Price = price;
				Size = size;
			}

			public override string ToString()
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("MarketDataFeed.TradeArgs [");
				sb.Append("Symbol=" + Symbol);
				sb.Append(", Price=" + Price);
				sb.Append(", Size=" + Size);
				sb.Append("]");
				return sb.ToString();
			}

			public readonly string Symbol;
			public readonly double Price;
			public readonly double Size;
		}

		public class PriceChangeArgs : EventArgs
		{
			public PriceChangeArgs(string symbol, double bid, double bidSize, double offer, double offerSize)
			{
				Symbol = symbol;
				Bid = bid;
				Offer = offer;
				BidSize = bidSize;
				OfferSize = offerSize;
			}

			public override string ToString()
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("MarketDataFeed.PriceChangeArgs [");
				sb.Append("Symbol=" + Symbol);
				sb.Append(", Bid=" + Bid);
				sb.Append(", BidSize=" + BidSize);
				sb.Append(", Offer=" + Offer);
				sb.Append(", OfferSize=" + OfferSize);
				sb.Append("]");
				return sb.ToString();
			}


			public readonly string Symbol;
			public readonly double Bid;
			public readonly double Offer;
			public readonly double BidSize;
			public readonly double OfferSize;
		}

		#endregion Market Data Processing

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