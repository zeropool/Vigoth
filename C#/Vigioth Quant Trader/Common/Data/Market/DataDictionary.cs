using System;
using System.Collections;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class DataDictionary<T> : IDictionary<Symbol, T>
    {
        private readonly IDictionary<Symbol, T> _data = new Dictionary<Symbol, T>();
        public DataDictionary()
        {
        }
        public DataDictionary(IEnumerable<T> data, Func<T, Symbol> keySelector)
        {
            foreach (var datum in data)
            {
                this[keySelector(datum)] = datum;
            }
        }
        public DataDictionary(DateTime time)
        {
#pragma warning disable 618            
            Time = time;
#pragma warning restore 618
        }
        [Obsolete("The DataDictionary<T> Time property is now obsolete. All algorithms should use algorithm.Time instead.")]
        public DateTime Time { get; set; }
        public IEnumerator<KeyValuePair<Symbol, T>> GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _data).GetEnumerator();
        }
        public void Add(KeyValuePair<Symbol, T> item)
        {
            _data.Add(item);
        }
        public void Clear()
        {
            _data.Clear();
        }
        public bool Contains(KeyValuePair<Symbol, T> item)
        {
            return _data.Contains(item);
        }
        public void CopyTo(KeyValuePair<Symbol, T>[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }
        public bool Remove(KeyValuePair<Symbol, T> item)
        {
            return _data.Remove(item);
        }
        public int Count
        {
            get { return _data.Count; }
        }
        public bool IsReadOnly
        {
            get { return _data.IsReadOnly; }
        }
        public bool ContainsKey(Symbol key)
        {
            return _data.ContainsKey(key);
        }
        public void Add(Symbol key, T value)
        {
            _data.Add(key, value);
        }
        public bool Remove(Symbol key)
        {
            return _data.Remove(key);
        }
        public bool TryGetValue(Symbol key, out T value)
        {
            return _data.TryGetValue(key, out value);
        }
        public T this[Symbol symbol]
        {
            get
            {
                T data;
                if (TryGetValue(symbol, out data))
                {
                    return data;
                }
                throw new KeyNotFoundException(string.Format("'{0}' wasn't found in the {1} object, likely because there was no-data at this moment in time and it wasn't possible to fillforward historical data. Please check the data exists before accessing it with data.ContainsKey(\"{0}\")", symbol, GetType().GetBetterTypeName()));
            }
            set
            {
                _data[symbol] = value;
            }
        }
        public T this[string ticker]
        {
            get
            {
                Symbol symbol;
                if (!SymbolCache.TryGetSymbol(ticker, out symbol))
                {
                    throw new KeyNotFoundException(string.Format("'{0}' wasn't found in the {1} object, likely because there was no-data at this moment in time and it wasn't possible to fillforward historical data. Please check the data exists before accessing it with data.ContainsKey(\"{0}\")", ticker, GetType().GetBetterTypeName()));
                }
                return this[symbol];
            }
            set
            {
                Symbol symbol;
                if (!SymbolCache.TryGetSymbol(ticker, out symbol))
                {
                    throw new KeyNotFoundException(string.Format("'{0}' wasn't found in the {1} object, likely because there was no-data at this moment in time and it wasn't possible to fillforward historical data. Please check the data exists before accessing it with data.ContainsKey(\"{0}\")", ticker, GetType().GetBetterTypeName()));
                }
                this[symbol] = value;
            }
        }
        public ICollection<Symbol> Keys
        {
            get { return _data.Keys; }
        }
        public ICollection<T> Values
        {
            get { return _data.Values; }
        }
    }
    public static class DataDictionaryExtensions
    {
        public static void Add<T>(this DataDictionary<T> dictionary, T data)
            where T : BaseData
        {
            dictionary.Add(data.Symbol, data);
        }
    }
}