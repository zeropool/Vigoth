using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities.Equity;
using VigiothCapital.QuantTrader.Securities.Forex;
namespace VigiothCapital.QuantTrader.Securities.Interfaces
{
    public interface ISecurityTransactionModel : IFillModel, IFeeModel, ISlippageModel
    {
    }
}
