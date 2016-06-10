using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class TradeBars : DataDictionary<TradeBar>
    {
        public TradeBars()
        {
        }
        public TradeBars(DateTime frontier)
            : base(frontier)
        {
        }
    }
}