using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VigiothCapital.QuantTrader.Data;
namespace VigiothCapital.QuantTrader.Securities
{
    public class CashBook : IDictionary<string, Cash>
    {
        public const string AccountCurrency = "USD";
        private readonly Dictionary<string, Cash> _currencies;
        public decimal TotalValueInAccountCurrency
        {
            get { return _currencies.Values.Sum(x => x.ValueInAccountCurrency); }
        }
        public CashBook()
        {
            _currencies = new Dictionary<string, Cash>();
            _currencies.Add(AccountCurrency, new Cash(AccountCurrency, 0, 1.0m));
        }
        public void Add(string symbol, decimal quantity, decimal conversionRate)
        {
            var cash = new Cash(symbol, quantity, conversionRate);
            _currencies.Add(symbol, cash);
        }
        public List<Security> EnsureCurrencyDataFeeds(SecurityManager securities, SubscriptionManager subscriptions, MarketHoursDatabase marketHoursDatabase, SymbolPropertiesDatabase symbolPropertiesDatabase, IReadOnlyDictionary<SecurityType, string> marketMap)
        {
            var addedSecurities = new List<Security>();
            foreach (var cash in _currencies.Values)
            {
                var security = cash.EnsureCurrencyDataFeed(securities, subscriptions, marketHoursDatabase, symbolPropertiesDatabase, marketMap, this);
                if (security != null)
                {
                    addedSecurities.Add(security);
                }
            }
            return addedSecurities;
        }
        public decimal Convert(decimal sourceQuantity, string sourceCurrency, string destinationCurrency)
        {
            var source = this[sourceCurrency];
            var destination = this[destinationCurrency];
            var conversionRate = source.ConversionRate*destination.ConversionRate;
            return sourceQuantity*conversionRate;
        }
        public decimal ConvertToAccountCurrency(decimal sourceQuantity, string sourceCurrency)
        {
            return Convert(sourceQuantity, sourceCurrency, AccountCurrency);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} {1,13}    {2,10} = {3}", "Symbol", "Quantity", "Conversion", "Value in " + AccountCurrency));
            foreach (var value in Values)
            {
                sb.AppendLine(value.ToString());
            }
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine(string.Format("CashBook Total Value:                {0}{1}", 
                Currencies.CurrencySymbols[AccountCurrency], 
                Math.Round(TotalValueInAccountCurrency, 2))
                );
            return sb.ToString();
        }
        #region IDictionary Implementation
        public int Count
        {
            get { return _currencies.Count; }
        }
        public bool IsReadOnly
        {
            get { return ((IDictionary<string, Cash>) _currencies).IsReadOnly; }
        }
        public void Add(KeyValuePair<string, Cash> item)
        {
            _currencies.Add(item.Key, item.Value);
        }
        public void Add(string symbol, Cash value)
        {
            _currencies.Add(symbol, value);
        }
        public void Clear()
        {
            _currencies.Clear();
        }
        public bool Remove(string symbol)
        {
            return _currencies.Remove (symbol);
        }
        public bool Remove(KeyValuePair<string, Cash> item)
        {
            return _currencies.Remove(item.Key);
        }
        public bool ContainsKey(string symbol)
        {
            return _currencies.ContainsKey(symbol);
        }
        public bool TryGetValue(string symbol, out Cash value)
        {
            return _currencies.TryGetValue(symbol, out value);
        }
        public bool Contains(KeyValuePair<string, Cash> item)
        {
            return _currencies.Contains(item);
        }
        public void CopyTo(KeyValuePair<string, Cash>[] array, int arrayIndex)
        {
            ((IDictionary<string, Cash>) _currencies).CopyTo(array, arrayIndex);
        }
        public Cash this[string symbol]
        {
            get
            {
                Cash cash;
                if (!_currencies.TryGetValue(symbol, out cash))
                {
                    throw new Exception("This cash symbol (" + symbol + ") was not found in your cash book.");
                }
                return cash;
            }
            set { _currencies[symbol] = value; }
        }
        public ICollection<string> Keys
        {
            get { return _currencies.Keys; }
        }
        public ICollection<Cash> Values
        {
            get { return _currencies.Values; }
        }
        public IEnumerator<KeyValuePair<string, Cash>> GetEnumerator()
        {
            return _currencies.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _currencies).GetEnumerator();
        }
        #endregion
    }
}