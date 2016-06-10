using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities.Interfaces;
namespace VigiothCapital.QuantTrader.Securities.Equity 
{
    public class EquityTransactionModel : SecurityTransactionModel 
    {
        public EquityTransactionModel()
            : base(new ImmediateFillModel(), new InteractiveBrokersFeeModel(), new ConstantSlippageModel(0))
        {
        }
    }
}
