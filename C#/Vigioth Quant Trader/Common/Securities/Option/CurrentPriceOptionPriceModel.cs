using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Securities.Option
{
    public class CurrentPriceOptionPriceModel : IOptionPriceModel
    {
        public OptionPriceModelResult Evaluate(Security security, Slice slice, OptionContract contract)
        {
            return new OptionPriceModelResult(security.Price, new FirstOrderGreeks());
        }
    }
}