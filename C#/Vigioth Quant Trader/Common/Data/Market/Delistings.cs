using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class Delistings : DataDictionary<Delisting>
    {
        public Delistings()
        {
        }
        public Delistings(DateTime frontier)
            : base(frontier)
        {
        }
    }
}
