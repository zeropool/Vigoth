using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class OptionContracts : DataDictionary<OptionContract>
    {
        public OptionContracts()
        {
        }
        public OptionContracts(DateTime time)
            : base(time)
        {
        }
    }
}