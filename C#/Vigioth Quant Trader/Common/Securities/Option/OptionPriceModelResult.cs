using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Securities.Option
{
    public class OptionPriceModelResult
    {
        public decimal TheoreticalPrice
        {
            get; private set;
        }
        public FirstOrderGreeks Greeks
        {
            get; private set;
        }
        public OptionPriceModelResult(decimal theoreticalPrice, FirstOrderGreeks greeks)
        {
            TheoreticalPrice = theoreticalPrice;
            Greeks = greeks;
        }
    }
}