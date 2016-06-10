using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities.Interfaces;
namespace VigiothCapital.QuantTrader.Securities.Forex
{
    public class ForexTransactionModel : SecurityTransactionModel
    {
        public ForexTransactionModel(decimal monthlyTradeAmountInUSDollars = 0)
            : base(new ImmediateFillModel(), new InteractiveBrokersFeeModel(monthlyTradeAmountInUSDollars), new SpreadSlippageModel())
        {   
        }
    }
}