using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class OptionChains : DataDictionary<OptionChain>
    {
        public OptionChains()
        {
        }
        public OptionChains(DateTime time)
            : base(time)
        {
        }
    }
}