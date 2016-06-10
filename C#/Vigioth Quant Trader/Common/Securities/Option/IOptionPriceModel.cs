using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Securities.Option
{
    public interface IOptionPriceModel
    {
        OptionPriceModelResult Evaluate(Security security, Slice slice, OptionContract contract);
    }
}
