

using System.Collections.Generic;
using System.Linq;
using com.fxcm.fix;
using com.fxcm.fix.pretrade;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Packets;

namespace VigiothCapital.QuantTrader.Brokerages.Fxcm
{
    /// <summary>
    /// FXCM brokerage - implementation of IDataQueueHandler interface
    /// </summary>
    public partial class FxcmBrokerage
    {
        private readonly List<Tick> _ticks = new List<Tick>();
        private readonly HashSet<Symbol> _subscribedSymbols = new HashSet<Symbol>(); 
        
        #region IDataQueueHandler implementation

        /// <summary>
        /// Get the next ticks from the live trading data queue
        /// </summary>
        /// <returns>IEnumerable list of ticks since the last update.</returns>
        public IEnumerable<BaseData> GetNextTicks()
        {
            lock (_ticks)
            {
                var copy = _ticks.ToArray();
                _ticks.Clear();
                return copy;
            }
        }

        /// <summary>
        /// Adds the specified symbols to the subscription
        /// </summary>
        /// <param name="job">Job we're subscribing for:</param>
        /// <param name="symbols">The symbols to be added keyed by SecurityType</param>
        public void Subscribe(LiveNodePacket job, IEnumerable<Symbol> symbols)
        {
            var symbolsToSubscribe = (from symbol in symbols 
                                      where !_subscribedSymbols.Contains(symbol) 
                                      select symbol).ToList();
            if (symbolsToSubscribe.Count == 0)
                return;

            Log.Trace("FxcmBrokerage.Subscribe(): {0}", string.Join(",", symbolsToSubscribe));

            var request = new MarketDataRequest();
            foreach (var symbol in symbolsToSubscribe)
            {
                request.addRelatedSymbol(_fxcmInstruments[_symbolMapper.GetBrokerageSymbol(symbol)]);
            }
            request.setSubscriptionRequestType(SubscriptionRequestTypeFactory.SUBSCRIBE);
            request.setMDEntryTypeSet(MarketDataRequest.MDENTRYTYPESET_ALL);

            lock (_locker)
            {
                _gateway.sendMessage(request);
            }

            foreach (var symbol in symbolsToSubscribe)
            {
                _subscribedSymbols.Add(symbol);
            }
        }

        /// <summary>
        /// Removes the specified symbols to the subscription
        /// </summary>
        /// <param name="job">Job we're processing.</param>
        /// <param name="symbols">The symbols to be removed keyed by SecurityType</param>
        public void Unsubscribe(LiveNodePacket job, IEnumerable<Symbol> symbols)
        {
            var symbolsToUnsubscribe = (from symbol in symbols 
                                        where _subscribedSymbols.Contains(symbol) 
                                        select symbol).ToList();
            if (symbolsToUnsubscribe.Count == 0)
                return;

            Log.Trace("FxcmBrokerage.Unsubscribe(): {0}", string.Join(",", symbolsToUnsubscribe));

            var request = new MarketDataRequest();
            foreach (var symbol in symbolsToUnsubscribe)
            {
                request.addRelatedSymbol(_fxcmInstruments[_symbolMapper.GetBrokerageSymbol(symbol)]);
            }
            request.setSubscriptionRequestType(SubscriptionRequestTypeFactory.UNSUBSCRIBE);
            request.setMDEntryTypeSet(MarketDataRequest.MDENTRYTYPESET_ALL);

            lock (_locker)
            {
                _gateway.sendMessage(request);
            }

            foreach (var symbol in symbolsToUnsubscribe)
            {
                _subscribedSymbols.Remove(symbol);
            }
        }

        #endregion

    }
}
