using System;
using System.Collections.Generic;
using NodaTime;
using VigiothCapital.QuantTrader.Data.Consolidators;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data
{
    public class SubscriptionManager
    {
        private readonly TimeKeeper _timeKeeper;
        public List<SubscriptionDataConfig> Subscriptions;
        public SubscriptionManager(TimeKeeper timeKeeper)
        {
            _timeKeeper = timeKeeper;
            Subscriptions = new List<SubscriptionDataConfig>();
        }
        public int Count 
        {
            get 
            { 
                return Subscriptions.Count; 
            }
        }
        public SubscriptionDataConfig Add(Symbol symbol, Resolution resolution, DateTimeZone timeZone, DateTimeZone exchangeTimeZone, bool isCustomData = false, bool fillDataForward = true, bool extendedMarketHours = false)
        {
            var dataType = typeof(TradeBar);
            if (resolution == Resolution.Tick) 
            {
                dataType = typeof(Tick);
            }
            return Add(dataType, symbol, resolution, timeZone, exchangeTimeZone, isCustomData, fillDataForward, extendedMarketHours, false);
        }
        public SubscriptionDataConfig Add(Type dataType, Symbol symbol, Resolution resolution, DateTimeZone dataTimeZone, DateTimeZone exchangeTimeZone, bool isCustomData, bool fillDataForward = true, bool extendedMarketHours = false, bool isInternalFeed = false, bool isFilteredSubscription = true)
        {
            if (dataTimeZone == null)
            {
                throw new ArgumentNullException("dataTimeZone", "DataTimeZone is a required parameter for new subscriptions.  Set to the time zone the raw data is time stamped in.");
            }
            if (exchangeTimeZone == null)
            {
                throw new ArgumentNullException("exchangeTimeZone", "ExchangeTimeZone is a required parameter for new subscriptions.  Set to the time zone the security exchange resides in.");
            }
            var newConfig = new SubscriptionDataConfig(dataType, symbol, resolution, dataTimeZone, exchangeTimeZone, fillDataForward, extendedMarketHours, isInternalFeed, isCustomData, isFilteredSubscription: isFilteredSubscription);
            Subscriptions.Add(newConfig);
            _timeKeeper.AddTimeZone(exchangeTimeZone);
            return newConfig;
        }
        public void AddConsolidator(Symbol symbol, IDataConsolidator consolidator)
        {
            for (var i = 0; i < Subscriptions.Count; i++)
            {
                if (Subscriptions[i].Symbol == symbol)
                {
                    if (!consolidator.InputType.IsAssignableFrom(Subscriptions[i].Type))
                    {
                        throw new ArgumentException(string.Format("Type mismatch found between consolidator and symbol. " +
                            "Symbol: {0} expects type {1} but tried to register consolidator with input type {2}", 
                            symbol, Subscriptions[i].Type.Name, consolidator.InputType.Name)
                            );
                    }
                    Subscriptions[i].Consolidators.Add(consolidator);
                    return;
                }
            }
            throw new ArgumentException("Please subscribe to this symbol before adding a consolidator for it. Symbol: " + symbol.ToString());
        }
    }      
}    
