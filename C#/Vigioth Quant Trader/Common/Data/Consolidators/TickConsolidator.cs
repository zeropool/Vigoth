using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{    
    public class TickConsolidator : TradeBarConsolidatorBase<Tick>
    {
        public TickConsolidator(TimeSpan period)
            : base(period)
        {
        }
        public TickConsolidator(int maxCount)
            : base(maxCount)
        {
        }
        public TickConsolidator(int maxCount, TimeSpan period)
            : base(maxCount, period)
        {
        }
        protected override void AggregateBar(ref TradeBar workingBar, Tick data)
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
                    Value = data.Value,
                    Volume = data.Quantity
                };
            }
            else
            {
                workingBar.Close = data.Value;
                workingBar.Volume += data.Quantity;
                if (data.Value < workingBar.Low) workingBar.Low = data.Value;
                if (data.Value > workingBar.High) workingBar.High = data.Value;
            }
        }
    }
}