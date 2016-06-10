using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class Dividends : DataDictionary<Dividend>
    {
        public Dividends()
        {
        }
        public Dividends(DateTime frontier)
            : base(frontier)
        {
        }
    }
}
