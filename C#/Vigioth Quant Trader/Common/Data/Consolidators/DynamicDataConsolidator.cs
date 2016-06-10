using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public class DynamicDataConsolidator : TradeBarConsolidatorBase<DynamicData>
    {
        public DynamicDataConsolidator(TimeSpan period)
            : base(period)
        {
        }
        public DynamicDataConsolidator(int maxCount)
            : base(maxCount)
        {
        }
        public DynamicDataConsolidator(int maxCount, TimeSpan period)
            : base(maxCount, period)
        {
        }
        protected override void AggregateBar(ref TradeBar workingBar, DynamicData data)
        {
            var open = GetNamedPropertyOrValueProperty(data, "Open");
            var high = GetNamedPropertyOrValueProperty(data, "High");
            var low = GetNamedPropertyOrValueProperty(data, "Low");
            var close = GetNamedPropertyOrValueProperty(data, "Close");
            var volume = data.HasProperty("Volume")
                ? (long) Convert.ChangeType(data.GetProperty("Volume"), typeof (long))
                : 0L;
            if (workingBar == null)
            {
                workingBar = new TradeBar
                {
                    Symbol = data.Symbol,
                    Time = GetRoundedBarTime(data.Time),
                    Open = open,
                    High = high,
                    Low = low,
                    Close = close,
                    Volume = volume
                };
            }
            else
            {
                workingBar.Close = close;
                workingBar.Volume += volume;
                if (low < workingBar.Low) workingBar.Low = low;
                if (high > workingBar.High) workingBar.High = high;
            }
        }
        private static decimal GetNamedPropertyOrValueProperty(DynamicData data, string propertyName)
        {
            if (!data.HasProperty(propertyName))
            {
                return data.Value;
            }
            return (decimal) Convert.ChangeType(data.GetProperty(propertyName), typeof (decimal));
        }
    }
}