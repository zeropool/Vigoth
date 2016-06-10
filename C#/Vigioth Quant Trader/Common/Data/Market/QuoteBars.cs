using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class QuoteBars : DataDictionary<QuoteBar>
    {
        public QuoteBars()
        {
        }
        public QuoteBars(DateTime time)
            : base(time)
        {
        }
    }
}