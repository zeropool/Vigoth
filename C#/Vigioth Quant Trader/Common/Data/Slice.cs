using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Data.Custom;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data
{
    public class Slice : IEnumerable<KeyValuePair<Symbol, BaseData>>
    {
        private readonly Ticks _ticks;
        private readonly TradeBars _bars;
        private readonly QuoteBars _quoteBars;
        private readonly OptionChains _optionChains;
        private readonly Splits _splits;
        private readonly Dividends _dividends;
        private readonly Delistings _delistings;
        private readonly SymbolChangedEvents _symbolChangedEvents;
        private readonly Lazy<DataDictionary<SymbolData>> _data;
        private readonly Dictionary<Type, Lazy<object>> _dataByType;
        public DateTime Time
        {
            get; private set;
        }
        public bool HasData
        {
            get; private set;
        }
        public TradeBars Bars
        {
            get { return _bars; }
        }
        public QuoteBars QuoteBars
        {
            get { return _quoteBars; }
        }
        public Ticks Ticks
        {
            get { return _ticks; }
        }
        public OptionChains OptionChains
        {
            get { return _optionChains; }
        }
        public Splits Splits
        {
            get { return _splits; }
        }
        public Dividends Dividends
        {
            get { return _dividends; }
        }
        public Delistings Delistings
        {
            get { return _delistings; }
        }
        public SymbolChangedEvents SymbolChangedEvents
        {
            get { return _symbolChangedEvents; }
        }
        public int Count
        {
            get { return _data.Value.Count; }
        }
        public IReadOnlyList<Symbol> Keys
        {
            get { return new List<Symbol>(_data.Value.Keys); }
        }
        public IReadOnlyList<BaseData> Values
        {
            get { return GetKeyValuePairEnumerable().Select(x => x.Value).ToList(); }
        }
        public Slice(DateTime time, IEnumerable<BaseData> data)
            : this(time, data, null, null, null, null, null, null, null, null)
        {
        }
        public Slice(DateTime time, IEnumerable<BaseData> data, TradeBars tradeBars, QuoteBars quoteBars, Ticks ticks, OptionChains optionChains, Splits splits, Dividends dividends, Delistings delistings, SymbolChangedEvents symbolChanges, bool? hasData = null)
        {
            Time = time;
            _dataByType = new Dictionary<Type, Lazy<object>>();
            _data = new Lazy<DataDictionary<SymbolData>>(() => CreateDynamicDataDictionary(data));
            HasData = hasData ?? _data.Value.Count > 0;
            _ticks = CreateTicksCollection(ticks);
            _bars = CreateCollection<TradeBars, TradeBar>(tradeBars);
            _quoteBars = CreateCollection<QuoteBars, QuoteBar>(quoteBars);
            _optionChains = CreateCollection<OptionChains, OptionChain>(optionChains);
            _splits = CreateCollection<Splits, Split>(splits);
            _dividends = CreateCollection<Dividends, Dividend>(dividends);
            _delistings = CreateCollection<Delistings, Delisting>(delistings);
            _symbolChangedEvents = CreateCollection<SymbolChangedEvents, SymbolChangedEvent>(symbolChanges);
        }
        public dynamic this[Symbol symbol]
        {
            get
            {
                SymbolData value;
                if (_data.Value.TryGetValue(symbol, out value))
                {
                    return value.GetData();
                }
                throw new KeyNotFoundException(string.Format("'{0}' wasn't found in the Slice object, likely because there was no-data at this moment in time and it wasn't possible to fillforward historical data. Please check the data exists before accessing it with data.ContainsKey(\"{0}\")", symbol));
            }
        }
        public DataDictionary<T> Get<T>()
            where T : BaseData
        {
            Lazy<object> dictionary;
            if (!_dataByType.TryGetValue(typeof(T), out dictionary))
            {
                if (typeof(T) == typeof(Tick))
                {
                    dictionary = new Lazy<object>(() => new DataDictionary<T>(_data.Value.Values.SelectMany<dynamic, dynamic>(x => x.GetData()).OfType<T>(), x => x.Symbol));
                }
                else
                {
                    dictionary = new Lazy<object>(() => new DataDictionary<T>(_data.Value.Values.Select(x => x.GetData()).OfType<T>(), x => x.Symbol));
                }
                _dataByType[typeof(T)] = dictionary;
            }
            return (DataDictionary<T>)dictionary.Value;
        }
        public T Get<T>(Symbol symbol)
            where T : BaseData
        {
            return Get<T>()[symbol];
        }
        public bool ContainsKey(Symbol symbol)
        {
            return _data.Value.ContainsKey(symbol);
        }
        public bool TryGetValue(Symbol symbol, out dynamic data)
        {
            data = null;
            SymbolData symbolData;
            if (_data.Value.TryGetValue(symbol, out symbolData))
            {
                data = symbolData.GetData();
                return data != null;
            }
            return false;
        }
        private static DataDictionary<SymbolData> CreateDynamicDataDictionary(IEnumerable<BaseData> data)
        {
            var allData = new DataDictionary<SymbolData>();
            foreach (var datum in data)
            {
                SymbolData symbolData;
                if (!allData.TryGetValue(datum.Symbol, out symbolData))
                {
                    symbolData = new SymbolData(datum.Symbol);
                    allData[datum.Symbol] = symbolData;
                }
                switch (datum.DataType)
                {
                    case MarketDataType.Base:
                        symbolData.Type = SubscriptionType.Custom;
                        symbolData.Custom = datum;
                        break;
                    case MarketDataType.TradeBar:
                        symbolData.Type = SubscriptionType.TradeBar;
                        symbolData.TradeBar = (TradeBar)datum;
                        break;
                    case MarketDataType.Tick:
                        symbolData.Type = SubscriptionType.Tick;
                        symbolData.Ticks.Add((Tick)datum);
                        break;
                    case MarketDataType.Auxiliary:
                        symbolData.AuxilliaryData.Add(datum);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return allData;
        }
        private Ticks CreateTicksCollection(Ticks ticks)
        {
            if (ticks != null) return ticks;
            ticks = new Ticks(Time);
            foreach (var listTicks in _data.Value.Values.Select(x => x.GetData()).OfType<List<Tick>>().Where(x => x.Count != 0))
            {
                ticks[listTicks[0].Symbol] = listTicks;
            }
            return ticks;
        }
        private T CreateCollection<T, TItem>(T collection)
            where T : DataDictionary<TItem>, new()
            where TItem : BaseData
        {
            if (collection != null) return collection;
            collection = new T();
#pragma warning disable 618            
            collection.Time = Time;
#pragma warning restore 618
            foreach (var item in _data.Value.Values.Select(x => x.GetData()).OfType<TItem>())
            {
                collection[item.Symbol] = item;
            }
            return collection;
        }
        public IEnumerator<KeyValuePair<Symbol, BaseData>> GetEnumerator()
        {
            return GetKeyValuePairEnumerable().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private IEnumerable<KeyValuePair<Symbol, BaseData>> GetKeyValuePairEnumerable()
        {
            return _data.Value.Select(kvp => new KeyValuePair<Symbol, BaseData>(kvp.Key, kvp.Value.GetData()));
        }
        private enum SubscriptionType { TradeBar, Tick, Custom };
        private class SymbolData
        {
            public SubscriptionType Type;
            public readonly Symbol Symbol;
            public BaseData Custom;
            public TradeBar TradeBar;
            public readonly List<Tick> Ticks;
            public readonly List<BaseData> AuxilliaryData;
            public SymbolData(Symbol symbol)
            {
                Symbol = symbol;
                Ticks = new List<Tick>();
                AuxilliaryData = new List<BaseData>();
            }
            public dynamic GetData()
            {
                switch (Type)
                {
                    case SubscriptionType.TradeBar:
                        return TradeBar;
                    case SubscriptionType.Tick:
                        return Ticks;
                    case SubscriptionType.Custom:
                        return Custom;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
