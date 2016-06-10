using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Interfaces;
namespace VigiothCapital.QuantTrader.Brokerages
{
    public class FxcmTransactionModel : SecurityTransactionModel
    {
        public FxcmTransactionModel()
            : base(new ImmediateFillModel(), new FxcmFeeModel(), new SpreadSlippageModel())
        {
        }
    }
}
