using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public class QuoteBarConsolidator : PeriodCountConsolidatorBase<QuoteBar, QuoteBar>
    {
        public QuoteBarConsolidator(TimeSpan period)
            : base(period)
        {
        }
        public QuoteBarConsolidator(int maxCount)
            : base(maxCount)
        {
        }
        public QuoteBarConsolidator(int maxCount, TimeSpan period)
            : base(maxCount, period)
        {
        }
        protected override void AggregateBar(ref QuoteBar workingBar, QuoteBar data)
        {
            var bid = data.Bid;
            var ask = data.Ask;
            if (workingBar == null)
            {
                workingBar = new QuoteBar
                {
                    Symbol = data.Symbol,
                    Time = GetRoundedBarTime(data.Time),
                    Bid = bid == null ? null : bid.Clone(),
                    Ask = ask == null ? null : ask.Clone()
                };
            }
            if (bid != null)
            {
                workingBar.LastBidSize = data.LastBidSize;
                if (workingBar.Bid == null)
                {
                    workingBar.Bid = new Bar(bid.Open, bid.High, bid.Low, bid.Close);
                }
                else
                {
                    workingBar.Bid.Close = bid.Close;
                    if (workingBar.Bid.High < bid.High) workingBar.Bid.High = bid.High;
                    if (workingBar.Bid.Low > bid.Low) workingBar.Bid.Low = bid.Low;
                }
            }
            if (ask != null)
            {
                workingBar.LastAskSize = data.LastAskSize;
                if (workingBar.Ask == null)
                {
                    workingBar.Ask = new Bar(ask.Open, ask.High, ask.Low, ask.Close);
                }
                else
                {
                    workingBar.Ask.Close = ask.Close;
                    if (workingBar.Ask.High < ask.High) workingBar.Ask.High = ask.High;
                    if (workingBar.Ask.Low > ask.Low) workingBar.Ask.Low = ask.Low;
                }
            }
        }
    }
}