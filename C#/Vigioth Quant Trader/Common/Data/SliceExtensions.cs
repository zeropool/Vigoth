using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data
{
    public static class SliceExtensions
    {
        public static IEnumerable<TradeBars> TradeBars(this IEnumerable<Slice> slices)
        {
            return slices.Where(x => x.Bars.Count > 0).Select(x => x.Bars);
        }
        public static IEnumerable<Ticks> Ticks(this IEnumerable<Slice> slices)
        {
            return slices.Where(x => x.Ticks.Count > 0).Select(x => x.Ticks);
        }
        public static IEnumerable<TradeBar> Get(this IEnumerable<Slice> slices, Symbol symbol)
        {
            return slices.TradeBars().Where(x => x.ContainsKey(symbol)).Select(x => x[symbol]);
        }
        public static IEnumerable<T> Get<T>(this IEnumerable<DataDictionary<T>> dataDictionaries, Symbol symbol)
            where T : BaseData
        {
            return dataDictionaries.Where(x => x.ContainsKey(symbol)).Select(x => x[symbol]);
        }
        public static IEnumerable<decimal> Get<T>(this IEnumerable<DataDictionary<T>> dataDictionaries, Symbol symbol, string field)
        {
            Func<T, decimal> selector;
            if (typeof (DynamicData).IsAssignableFrom(typeof (T)))
            {
                selector = data =>
                {
                    var dyn = (DynamicData) (object) data;
                    return (decimal) dyn.GetProperty(field);
                };
            }
            else if (typeof (T) == typeof (List<Tick>))
            {
                var dataSelector = (Func<Tick, decimal>) ExpressionBuilder.MakePropertyOrFieldSelector(typeof (Tick), field).Compile();
                selector = ticks => dataSelector(((List<Tick>) (object) ticks).Last());
            }
            else
            {
                selector = (Func<T, decimal>) ExpressionBuilder.MakePropertyOrFieldSelector(typeof (T), field).Compile();
            }
            foreach (var dataDictionary in dataDictionaries)
            {
                T item;
                if (dataDictionary.TryGetValue(symbol, out item))
                {
                    yield return selector(item);
                }
            }
        }
        public static IEnumerable<DataDictionary<T>> Get<T>(this IEnumerable<Slice> slices)
            where T : BaseData
        {
            return slices.Select(x => x.Get<T>()).Where(x => x.Count > 0);
        }
        public static IEnumerable<T> Get<T>(this IEnumerable<Slice> slices, Symbol symbol)
            where T : BaseData
        {
            return slices.Select(x => x.Get<T>()).Where(x => x.ContainsKey(symbol)).Select(x => x[symbol]);
        }
        public static IEnumerable<decimal> Get(this IEnumerable<Slice> slices, Symbol symbol, Func<BaseData, decimal> field)
        {
            foreach (var slice in slices)
            {
                dynamic item;
                if (slice.TryGetValue(symbol, out item))
                {
                    if (item is List<Tick>) yield return field(item.Last());
                    else yield return field(item);
                }
            }
        }
        public static double[] ToDoubleArray(this IEnumerable<decimal> decimals)
        {
            return decimals.Select(x => (double) x).ToArray();
        }
    }
}