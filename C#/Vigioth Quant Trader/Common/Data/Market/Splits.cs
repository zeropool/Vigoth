using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class Splits : DataDictionary<Split>
    {
        public Splits()
        {
        }
        public Splits(DateTime frontier)
            : base(frontier)
        {
        }
    }
}