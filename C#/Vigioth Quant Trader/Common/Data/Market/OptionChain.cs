using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class OptionChain : BaseData, IEnumerable<OptionContract>
    {
        private readonly Dictionary<Type, Dictionary<Symbol, List<BaseData>>> _auxiliaryData = new Dictionary<Type, Dictionary<Symbol, List<BaseData>>>();
        public BaseData Underlying
        {
            get; internal set;
        }
        public Ticks Ticks
        {
            get; private set;
        }
        public TradeBars TradeBars
        {
            get; private set;
        }
        public QuoteBars QuoteBars
        {
            get; private set;
        }
        public OptionContracts Contracts
        {
            get; private set;
        }
        public HashSet<Symbol> FilteredContracts
        {
            get; private set;
        }
        private OptionChain()
        {
            DataType = MarketDataType.OptionChain;
        }
        public OptionChain(Symbol canonicalOptionSymbol, DateTime time)
        {
            Time = time;
            Symbol = canonicalOptionSymbol;
            DataType = MarketDataType.OptionChain;
            Ticks = new Ticks(time);
            TradeBars = new TradeBars(time);
            QuoteBars = new QuoteBars(time);
            Contracts = new OptionContracts(time);
            FilteredContracts = new HashSet<Symbol>();
        }
        public OptionChain(Symbol canonicalOptionSymbol, DateTime time, BaseData underlying, IEnumerable<BaseData> trades, IEnumerable<BaseData> quotes, IEnumerable<OptionContract> contracts, IEnumerable<Symbol> filteredContracts)
        {
            Time = time;
            Underlying = underlying;
            Symbol = canonicalOptionSymbol;
            DataType = MarketDataType.OptionChain;
            FilteredContracts = filteredContracts.ToHashSet();
            Ticks = new Ticks(time);
            TradeBars = new TradeBars(time);
            QuoteBars = new QuoteBars(time);
            Contracts = new OptionContracts(time);
            foreach (var trade in trades)
            {
                var tick = trade as Tick;
                if (tick != null)
                {
                    List<Tick> ticks;
                    if (!Ticks.TryGetValue(tick.Symbol, out ticks))
                    {
                        ticks = new List<Tick>();
                        Ticks[tick.Symbol] = ticks;
                    }
                    ticks.Add(tick);
                    continue;
                }
                var bar = trade as TradeBar;
                if (bar != null)
                {
                    TradeBars[trade.Symbol] = bar;
                }
            }
            foreach (var quote in quotes)
            {
                var tick = quote as Tick;
                if (tick != null)
                {
                    List<Tick> ticks;
                    if (!Ticks.TryGetValue(tick.Symbol, out ticks))
                    {
                        ticks = new List<Tick>();
                        Ticks[tick.Symbol] = ticks;
                    }
                    ticks.Add(tick);
                    continue;
                }
                var bar = quote as QuoteBar;
                if (bar != null)
                {
                    QuoteBars[quote.Symbol] = bar;
                }
            }
            foreach (var contract in contracts)
            {
                Contracts[contract.Symbol] = contract;
            }
        }
        public T GetAux<T>(Symbol symbol)
        {
            List<BaseData> list;
            Dictionary<Symbol, List<BaseData>> dictionary;
            if (!_auxiliaryData.TryGetValue(typeof(T), out dictionary) || !dictionary.TryGetValue(symbol, out list))
            {
                return default(T);
            }
            return list.OfType<T>().LastOrDefault();
        }
        public DataDictionary<T> GetAux<T>()
        {
            Dictionary<Symbol, List<BaseData>> d;
            if (!_auxiliaryData.TryGetValue(typeof(T), out d))
            {
                return new DataDictionary<T>();
            }
            var dictionary = new DataDictionary<T>();
            foreach (var kvp in d)
            {
                var item = kvp.Value.OfType<T>().LastOrDefault();
                if (item != null)
                {
                    dictionary.Add(kvp.Key, item);
                }
            }
            return dictionary;
        }
        public Dictionary<Symbol, List<BaseData>> GetAuxList<T>()
        {
            Dictionary<Symbol, List<BaseData>> dictionary;
            if (!_auxiliaryData.TryGetValue(typeof(T), out dictionary))
            {
                return new Dictionary<Symbol, List<BaseData>>();
            }
            return dictionary;
        }
        public List<T> GetAuxList<T>(Symbol symbol)
        {
            List<BaseData> list;
            Dictionary<Symbol, List<BaseData>> dictionary;
            if (!_auxiliaryData.TryGetValue(typeof(T), out dictionary) || !dictionary.TryGetValue(symbol, out list))
            {
                return new List<T>();
            }
            return list.OfType<T>().ToList();
        }
        public IEnumerator<OptionContract> GetEnumerator()
        {
            return Contracts.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override BaseData Clone()
        {
            return new OptionChain
            {
                Underlying = Underlying,
                Ticks = Ticks,
                Contracts = Contracts,
                QuoteBars = QuoteBars,
                TradeBars = TradeBars,
                FilteredContracts = FilteredContracts,
                Symbol = Symbol,
                Time = Time,
                DataType = DataType,
                Value = Value
            };
        }
        internal void AddAuxData(BaseData baseData)
        {
            var type = baseData.GetType();
            Dictionary<Symbol, List<BaseData>> dictionary;
            if (!_auxiliaryData.TryGetValue(type, out dictionary))
            {
                dictionary = new Dictionary<Symbol, List<BaseData>>();
                _auxiliaryData[type] = dictionary;
            }
            List<BaseData> list;
            if (!dictionary.TryGetValue(baseData.Symbol, out list))
            {
                list = new List<BaseData>();
                dictionary[baseData.Symbol] = list;
            }
            list.Add(baseData);
        }
    }
}