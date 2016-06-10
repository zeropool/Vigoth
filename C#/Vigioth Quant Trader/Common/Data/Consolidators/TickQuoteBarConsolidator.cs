using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public class TickQuoteBarConsolidator : PeriodCountConsolidatorBase<Tick, QuoteBar>
    {
        public TickQuoteBarConsolidator(TimeSpan period)
            : base(period)
        {
        }
        public TickQuoteBarConsolidator(int maxCount)
            : base(maxCount)
        {
        }
        public TickQuoteBarConsolidator(int maxCount, TimeSpan period)
            : base(maxCount, period)
        {
        }
        protected override bool ShouldProcess(Tick data)
        {
            return data.TickType == TickType.Quote;
        }
        protected override void AggregateBar(ref QuoteBar workingBar, Tick data)
        {
            if (workingBar == null)
            {
                workingBar = new QuoteBar
                {
                    Symbol = data.Symbol,
                    Time = GetRoundedBarTime(data.Time),
                    Bid = null,
                    Ask = null
                };
            }
            workingBar.Update(0, data.BidPrice, data.AskPrice, 0, data.BidSize, data.AskSize);
        }
    }
}