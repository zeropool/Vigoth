using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Logging;
namespace VigiothCapital.QuantTrader.Securities
{
    public class Cash
    {
        private bool _isBaseCurrency;
        private bool _invertRealTimePrice;
        private readonly object _locker = new object();
        public Symbol SecuritySymbol { get; private set; }
        public string Symbol { get; private set; }
        public decimal Amount { get; private set; }
        public decimal ConversionRate { get; internal set; }
        public decimal ValueInAccountCurrency
        {
            get { return Amount*ConversionRate; }
        }
        public Cash(string symbol, decimal amount, decimal conversionRate)
        {
            if (symbol == null || symbol.Length != 3)
            {
                throw new ArgumentException("Cash symbols must be exactly 3 characters.");
            }
            Amount = amount;
            ConversionRate = conversionRate;
            Symbol = symbol.ToUpper();
        }
        public void Update(BaseData data)
        {
            if (_isBaseCurrency) return;
            var rate = data.Value;
            if (_invertRealTimePrice)
            {
                rate = 1/rate;
            }
            ConversionRate = rate;
        }
        public decimal AddAmount(decimal amount)
        {
            lock (_locker)
            {
                Amount += amount;
                return Amount;
            }
        }
        public void SetAmount(decimal amount)
        {
            lock (_locker)
            {
                Amount = amount;
            }
        }
        public Security EnsureCurrencyDataFeed(SecurityManager securities, SubscriptionManager subscriptions, MarketHoursDatabase marketHoursDatabase, SymbolPropertiesDatabase symbolPropertiesDatabase, IReadOnlyDictionary<SecurityType, string> marketMap, CashBook cashBook)
        {
            if (Symbol == CashBook.AccountCurrency)
            {
                SecuritySymbol = VigiothCapital.QuantTrader.Symbol.Empty;
                _isBaseCurrency = true;
                ConversionRate = 1.0m;
                return null;
            }
            if (subscriptions.Count == 0)
            {
                throw new InvalidOperationException("Unable to add cash when no subscriptions are present. Please add subscriptions in the Initialize() method.");
            }
            string normal = Symbol + CashBook.AccountCurrency;
            string invert = CashBook.AccountCurrency + Symbol;
            foreach (var config in subscriptions.Subscriptions.Where(config => config.SecurityType == SecurityType.Forex || config.SecurityType == SecurityType.Cfd))
            {
                if (config.Symbol.Value == normal)
                {
                    SecuritySymbol = config.Symbol;
                    return null;
                }
                if (config.Symbol.Value == invert)
                {
                    SecuritySymbol = config.Symbol;
                    _invertRealTimePrice = true;
                    return null;
                }
            }
            var currencyPairs = Currencies.CurrencyPairs.Select(x =>
            {
                var securityType = Symbol.StartsWith("X") ? SecurityType.Cfd : SecurityType.Forex;
                var market = marketMap[securityType];
                return VigiothCapital.QuantTrader.Symbol.Create(x, securityType, market);
            });
            var minimumResolution = subscriptions.Subscriptions.Select(x => x.Resolution).DefaultIfEmpty(Resolution.Minute).Min();
            var objectType = minimumResolution == Resolution.Tick ? typeof (Tick) : typeof (TradeBar);
            foreach (var symbol in currencyPairs)
            {
                if (symbol.Value == normal || symbol.Value == invert)
                {
                    _invertRealTimePrice = symbol.Value == invert;
                    var securityType = symbol.ID.SecurityType;
                    var symbolProperties = symbolPropertiesDatabase.GetSymbolProperties(symbol.ID.Market, symbol.Value, securityType, Symbol);
                    Cash quoteCash;
                    if (!cashBook.TryGetValue(symbolProperties.QuoteCurrency, out quoteCash))
                    {
                        throw new Exception("Unable to resolve quote cash: " + symbolProperties.QuoteCurrency + ". This is required to add conversion feed: " + symbol.ToString());
                    }
                    var marketHoursDbEntry = marketHoursDatabase.GetEntry(symbol.ID.Market, symbol.Value, symbol.ID.SecurityType);
                    var exchangeHours = marketHoursDbEntry.ExchangeHours;
                    var config = subscriptions.Add(objectType, symbol, minimumResolution, marketHoursDbEntry.DataTimeZone, exchangeHours.TimeZone, false, true, false, true);
                    SecuritySymbol = config.Symbol;
                    Security security;
                    if (securityType == SecurityType.Cfd)
                    {
                        security = new Cfd.Cfd(exchangeHours, quoteCash, config, symbolProperties);
                    }
                    else
                    {
                        security = new Forex.Forex(exchangeHours, this, config, symbolProperties);
                    }
                    securities.Add(config.Symbol, security);
                    Log.Trace("Cash.EnsureCurrencyDataFeed(): Adding " + symbol.Value + " for cash " + Symbol + " currency feed");
                    return security;
                }
            }
            throw new ArgumentException(string.Format("In order to maintain cash in {0} you are required to add a subscription for Forex pair {0}{1} or {1}{0}", Symbol, CashBook.AccountCurrency));
        }
        public override string ToString()
        {
            decimal rate = ConversionRate;
            rate = rate < 1000 ? rate.RoundToSignificantDigits(5) : Math.Round(rate, 2);
            return string.Format("{0}: {1,15} @ ${2,10} = {3}{4}", 
                Symbol, 
                Amount.ToString("0.00"), 
                rate.ToString("0.00####"), 
                Currencies.CurrencySymbols[Symbol], 
                Math.Round(ValueInAccountCurrency, 2)
                );
        }
    }
}