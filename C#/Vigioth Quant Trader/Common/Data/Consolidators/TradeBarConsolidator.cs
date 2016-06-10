using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public class TradeBarConsolidator : TradeBarConsolidatorBase<TradeBar>
    {
        public static TradeBarConsolidator FromResolution(Resolution resolution)
        {
            return new TradeBarConsolidator(resolution.ToTimeSpan());
        }
        public TradeBarConsolidator(TimeSpan period)
            : base(period)
        {
        }
        public TradeBarConsolidator(int maxCount)
            : base(maxCount)
        {
        }
        public TradeBarConsolidator(int maxCount, TimeSpan period)
            : base(maxCount, period)
        {
        }
        protected override void AggregateBar(ref TradeBar workingBar, TradeBar data)
        {
            if (workingBar == null)
            {
                workingBar = new TradeBar
                {
                    Time = GetRoundedBarTime(data.Time),
                    Symbol = data.Symbol,
                    Open = data.Open,
                    High = data.High,
                    Low = data.Low,
                    Close = data.Close,
                    Volume = data.Volume,
                    DataType = MarketDataType.TradeBar,
                    Period = data.Period
                };
            }
            else
            {
                workingBar.Close = data.Close;
                workingBar.Volume += data.Volume;
                workingBar.Period += data.Period;
                if (data.Low < workingBar.Low) workingBar.Low = data.Low;
                if (data.High > workingBar.High) workingBar.High = data.High;
            }
        }
    }
}