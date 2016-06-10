using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders.Fees
{
    public interface IFeeModel
    {
        decimal GetOrderFee(Security security, Order order);
    }
}