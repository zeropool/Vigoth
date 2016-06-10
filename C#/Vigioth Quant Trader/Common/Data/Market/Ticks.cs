using System;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class Ticks : DataDictionary<List<Tick>>
    {
        public Ticks()
        {
        }
        public Ticks(DateTime frontier)
            : base(frontier)
        {
        }
    }
}
