using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public class BaseDataConsolidator : TradeBarConsolidatorBase<BaseData>
    {
        public static BaseDataConsolidator FromResolution(Resolution resolution)
        {
            return new BaseDataConsolidator(resolution.ToTimeSpan());
        }
        public BaseDataConsolidator(TimeSpan period)
            : base(period)
        {
        }
        public BaseDataConsolidator(int maxCount)
            : base(maxCount)
        {
        }
        public BaseDataConsolidator(int maxCount, TimeSpan period)
            : base(maxCount, period)
        {
        }
        protected override void AggregateBar(ref TradeBar workingBar, BaseData data)
        {
            if (workingBar == null)
            {
                workingBar = new TradeBar
                {
                    Symbol = data.Symbol,
                    Time = GetRoundedBarTime(data.Time),
                    Close = data.Value,
                    High = data.Value,
                    Low = data.Value,
                    Open = data.Value,
                    DataType = data.DataType,
                    Value = data.Value
                };
            }
            else
            {
                workingBar.Close = data.Value;
                if (data.Value < workingBar.Low) workingBar.Low = data.Value;
                if (data.Value > workingBar.High) workingBar.High = data.Value;
            }
        }
    }
}