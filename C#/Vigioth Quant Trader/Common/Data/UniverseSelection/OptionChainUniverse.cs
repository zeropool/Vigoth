using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Option;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.UniverseSelection
{
    public class OptionChainUniverse : Universe
    {
        private static readonly IReadOnlyList<TickType> QuotesAndTrades = new[] { TickType.Quote, TickType.Trade };
        private BaseData _underlying;
        private readonly Option _option;
        private readonly UniverseSettings _universeSettings;
        public OptionChainUniverse(Option option, UniverseSettings universeSettings, ISecurityInitializer securityInitializer = null)
            : base(option.SubscriptionDataConfig, securityInitializer)
        {
            _option = option;
            _universeSettings = universeSettings;
        }
        public override UniverseSettings UniverseSettings
        {
            get { return _universeSettings; }
        }
        public override IEnumerable<Symbol> SelectSymbols(DateTime utcTime, BaseDataCollection data)
        {
            var optionsUniverseDataCollection = data as OptionChainUniverseDataCollection;
            if (optionsUniverseDataCollection == null)
            {
                throw new ArgumentException(string.Format("Expected data of type '{0}'", typeof (OptionChainUniverseDataCollection).Name));
            }
            _underlying = optionsUniverseDataCollection.Underlying ?? _underlying;
            optionsUniverseDataCollection.Underlying = _underlying;
            if (_underlying == null || data.Data.Count == 0)
            {
                return Unchanged;
            }
            var availableContracts = optionsUniverseDataCollection.Data.Select(x => x.Symbol);
            var results = _option.ContractFilter.Filter(availableContracts, _underlying).ToHashSet();
            optionsUniverseDataCollection.FilteredContracts = results;
            return results;
        }
        public override IEnumerable<SubscriptionDataConfig> GetSubscriptions(Security security)
        {
            var config = security.SubscriptionDataConfig;
            if (security.Symbol == _option.Symbol)
            {
                var underlying = Symbol.Create(config.Symbol.ID.Symbol, SecurityType.Equity, config.Market);
                var resolution = config.Resolution == Resolution.Tick ? Resolution.Second : config.Resolution;
                return new[]
                {
                    new SubscriptionDataConfig(config, resolution: resolution, fillForward: true), 
                    new SubscriptionDataConfig(config, resolution: resolution, fillForward: true, symbol: underlying, objectType: typeof(TradeBar), tickType: TickType.Trade), 
                };
            }
            return QuotesAndTrades.Select(x => new SubscriptionDataConfig(config,
                tickType: x,
                objectType: GetDataType(config.Resolution, x),
                isFilteredSubscription: true
                ));
        }
        public override Security CreateSecurity(Symbol symbol, IAlgorithm algorithm, MarketHoursDatabase marketHoursDatabase, SymbolPropertiesDatabase symbolPropertiesDatabase)
        {
            var option = (Option)base.CreateSecurity(symbol, algorithm, marketHoursDatabase, symbolPropertiesDatabase);
            option.Underlying = _option.Underlying;
            option.PriceModel = _option.PriceModel;
            return option;
        }
        public override bool CanRemoveMember(DateTime utcTime, Security security)
        {
            var lastData = security.Cache.GetData();
            if (lastData == null)
            {
                return true;
            }
            var localTime = utcTime.ConvertFromUtc(security.Exchange.TimeZone);
            if (localTime.Date != lastData.Time.Date)
            {
                return true;
            }
            return false;
        }
        private static Type GetDataType(Resolution resolution, TickType tickType)
        {
            if (resolution == Resolution.Tick) return typeof(Tick);
            if (tickType == TickType.Quote) return typeof(QuoteBar);
            return typeof(TradeBar);
        }
    }
}
