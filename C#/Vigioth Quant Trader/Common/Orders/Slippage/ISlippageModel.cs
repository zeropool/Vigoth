using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders.Slippage
{
    public interface ISlippageModel
    {
        decimal GetSlippageApproximation(Security asset, Order order);
    }
}