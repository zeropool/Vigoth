using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Interfaces;
namespace VigiothCapital.QuantTrader.Brokerages
{
    public class OandaTransactionModel : SecurityTransactionModel
    {
        public OandaTransactionModel()
            : base(new ImmediateFillModel(), new ConstantFeeModel(0), new SpreadSlippageModel())
        {
        }
    }
}
