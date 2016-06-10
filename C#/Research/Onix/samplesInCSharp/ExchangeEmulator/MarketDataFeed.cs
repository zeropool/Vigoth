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
using System.Threading;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX44;
using Onixs.FixControls;

namespace ExchangeEmulator
{
    class MarketDataFeed : IDisposable
    {
		Session session;
		ILogger logger;

        public MarketDataFeed(Session session, ILogger logger)
        {
			this.session = session;
			this.logger = logger;

            timer = new Timer(new TimerCallback(OnTimer), null, interval, interval);
        }

        const int interval = 1000; // in milliseconds
        
        private Timer timer;

		string[] defaultSecurityes = { "EUR/USD", "EUR/JPY", "USD/CAD" };
		int responseID = 0;

        public void Reset()
        {
            requests.Clear();
        }

		public void ProcessSecurityDefinitionRequest(Message request)
		{
			Debug.Assert(MsgType.SecurityDefinitionRequest == request.Type);
			string requestID = request.Get(Tags.SecurityReqID);

			foreach (string item in defaultSecurityes)
			{
				Message securityDefinition = new Message(MsgType.SecurityDefinition, session.Dialect);
				securityDefinition.Set(Tags.SecurityReqID, requestID);
				securityDefinition.Set(Tags.SecurityResponseID, Interlocked.Increment(ref responseID));
				securityDefinition.Set(Tags.Symbol, item);
				securityDefinition.Set(Tags.TotNoRelatedSym, defaultSecurityes.Length);

				securityDefinition.Validate();
				session.Send(securityDefinition);
			}
		}

        public void ProcessMarketDataRequest(Message request)
        {
            Debug.Assert(MsgType.MarketDataRequest == request.Type);

            string requestID = request.Get(Tags.MDReqID);

			lock (requests)
			{
				if (requests.ContainsKey(requestID))
				{
					if (request[Tags.SubscriptionRequestType] == SubscriptionRequestType.Unsubscribe)
						requests.Remove(requestID);
				}
				else
				{
					List<string> symbols = new List<string>();

					Group symbolsGroup = request.GetGroup(Tags.NoRelatedSym);
					for (int i = 0; i < symbolsGroup.NumberOfInstances; ++i)
					{
						string symbol = symbolsGroup.Get(Tags.Symbol, i);
						symbols.Add(symbol);
						SendSnapshot(requestID, symbol);
					}

					if (request[Tags.SubscriptionRequestType] == SubscriptionRequestType.SnapshotUpdate)
						requests.Add(requestID, symbols);
				}
			}
        }

		private void SendSnapshot(string mdReqID, string symbol)
		{
			Message snapshot = new Message(MsgType.MarketDataSnapshotFullRefresh, session.Dialect);
			snapshot.Set(Tags.MDReqID, mdReqID);
			snapshot.Set(Tags.Symbol, symbol);
			Group entries = snapshot.SetGroup(Tags.NoMDEntries, 2);

			entries.Set(Tags.MDEntryType, 0, MDEntryType.Bid);
			const double basePrice = 1.34;
			double price = basePrice + randomGenerator.Next(100) / 100000.0;
			entries.Set(Tags.MDEntryPx, 0, price);
			entries.Set(Tags.MDEntrySize, 0, 5000000);

			entries.Set(Tags.MDEntryType, 1, MDEntryType.Offer);
			price += randomGenerator.Next(1, 100) / 100000.0;
			entries.Set(Tags.MDEntryPx, 1, price);
			entries.Set(Tags.MDEntrySize, 1, 5000000);

			snapshot.Validate();
			session.Send(snapshot);
		}
        
        private Random randomGenerator = new Random();
        
        private void OnTimer(object data)
        {
            if(session != null && session.State == SessionState.ACTIVE && requests.Count > 0)
            {
				lock (requests)
				{
					foreach (KeyValuePair<string, List<string>> pair in requests)
					{
						Message refresh = new Message(MsgType.MarketDataIncrementalRefresh, session.Dialect);
						refresh.Set(Tags.MDReqID, pair.Key);
						Group entries = refresh.SetGroup(Tags.NoMDEntries, pair.Value.Count * 3);
						int index = 0;
						foreach (string symbol in pair.Value)
						{
							entries.Set(Tags.MDUpdateAction, index, MDUpdateAction.New);
							entries.Set(Tags.MDEntryType, index, MDEntryType.Bid);
							entries.Set(Tags.Symbol, index, symbol);
							const double basePrice = 1.34;
							double price = basePrice + randomGenerator.Next(100) / 100000.0;
							entries.Set(Tags.MDEntryPx, index, price);
							entries.Set(Tags.MDEntrySize, index, 5000000);
							entries.Set(Tags.NumberOfOrders, index, 1);
							++index;

							entries.Set(Tags.MDUpdateAction, index, MDUpdateAction.New);
							entries.Set(Tags.MDEntryType, index, MDEntryType.Offer);
							entries.Set(Tags.Symbol, index, symbol);
							price += randomGenerator.Next(1, 100) / 100000.0;
							entries.Set(Tags.MDEntryPx, index, price);
							entries.Set(Tags.MDEntrySize, index, 5000000);
							entries.Set(Tags.NumberOfOrders, index, 1);
							++index;

							entries.Set(Tags.MDUpdateAction, index, MDUpdateAction.New);
							entries.Set(Tags.MDEntryType, index, MDEntryType.Trade);
							entries.Set(Tags.Symbol, index, symbol);
							price += randomGenerator.Next(1, 100) / 100000.0;
							entries.Set(Tags.MDEntryPx, index, price);
							entries.Set(Tags.MDEntrySize, index, 1000000);
							++index;
						}
						refresh.Validate();
						session.Send(refresh);
					}
				}
            }
        }

        private Dictionary<string, List<string> > requests = new Dictionary<string, List<string>>();

		#region IDisposable Members

		public void Dispose()
		{
			timer.Dispose();
		}

		#endregion
	}
}
