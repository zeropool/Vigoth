using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.UniverseSelection
{
    public class UserDefinedUniverse : Universe, INotifyCollectionChanged
    {
        private readonly TimeSpan _interval;
        private readonly HashSet<Symbol> _symbols;
        private readonly UniverseSettings _universeSettings;
        private readonly Func<DateTime, IEnumerable<Symbol>> _selector;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public TimeSpan Interval
        {
            get { return _interval; }
        }
        public override UniverseSettings UniverseSettings
        {
            get { return _universeSettings; }
        }
        public UserDefinedUniverse(SubscriptionDataConfig configuration, UniverseSettings universeSettings, ISecurityInitializer securityInitializer, TimeSpan interval, IEnumerable<Symbol> symbols)
            : base(configuration, securityInitializer)
        {
            _interval = interval;
            _symbols = symbols.ToHashSet();
            _universeSettings = universeSettings;
            _selector = time => _symbols;
        }
        public UserDefinedUniverse(SubscriptionDataConfig configuration, UniverseSettings universeSettings, ISecurityInitializer securityInitializer, TimeSpan interval, Func<DateTime,IEnumerable<string>> selector)
            : base(configuration, securityInitializer)
        {
            _interval = interval;
            _universeSettings = universeSettings;
            _selector = time =>
            {
                var selectSymbolsResult = selector(time.ConvertFromUtc(Configuration.ExchangeTimeZone));
                if (ReferenceEquals(selectSymbolsResult, Unchanged)) return Unchanged;
                return selectSymbolsResult.Select(sym => Symbol.Create(sym, Configuration.SecurityType, Configuration.Market));
            };
        }
        public static Symbol CreateSymbol(SecurityType securityType, string market)
        {
            var ticker = string.Format("qc-universe-userdefined-{0}-{1}", market.ToLower(), securityType);
            SecurityIdentifier sid;
            switch (securityType)
            {
                case SecurityType.Base:
                    sid = SecurityIdentifier.GenerateBase(ticker, market);
                    break;
                case SecurityType.Equity:
                    sid = SecurityIdentifier.GenerateEquity(SecurityIdentifier.DefaultDate, ticker, market);
                    break;
                case SecurityType.Option:
                    sid = SecurityIdentifier.GenerateOption(SecurityIdentifier.DefaultDate, ticker, market, 0, 0, 0);
                    break;
                case SecurityType.Forex:
                    sid = SecurityIdentifier.GenerateForex(ticker, market);
                    break;
                case SecurityType.Cfd:
                    sid = SecurityIdentifier.GenerateCfd(ticker, market);
                    break;
                case SecurityType.Commodity:
                case SecurityType.Future:
                default:
                    throw new NotImplementedException("The specified security type is not implemented yet: " + securityType);
            }
            return new Symbol(sid, ticker);
        }
        public bool Add(Symbol symbol)
        {
            if (_symbols.Add(symbol))
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, symbol));
                return true;
            }
            return false;
        }
        public bool Remove(Symbol symbol)
        {
            if (_symbols.Remove(symbol))
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, symbol));
                return true;
            }
            return false;
        }
        public override IEnumerable<Symbol> SelectSymbols(DateTime utcTime, BaseDataCollection data)
        {
            return _selector(utcTime);
        }
        public virtual IEnumerable<DateTime> GetTriggerTimes(DateTime startTimeUtc, DateTime endTimeUtc, MarketHoursDatabase marketHoursDatabase)
        {
            var exchangeHours = marketHoursDatabase.GetExchangeHours(Configuration);
            var localStartTime = startTimeUtc.ConvertFromUtc(exchangeHours.TimeZone);
            var localEndTime = endTimeUtc.ConvertFromUtc(exchangeHours.TimeZone);
            var first = true;
            foreach (var dateTime in LinqExtensions.Range(localStartTime, localEndTime, dt => dt + Interval))
            {
                if (first)
                {
                    yield return dateTime;
                    first = false;
                }
                else if (exchangeHours.IsOpen(dateTime, dateTime + Interval, Configuration.ExtendedMarketHours))
                {
                    yield return dateTime;
                }
            }
        }
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var handler = CollectionChanged;
            if (handler != null) handler(this, e);
        }
    }
}
