using VigiothCapital.QuantTrader.Orders;
namespace VigiothCapital.QuantTrader.Securities
{
    public interface IOrderProcessor : IOrderProvider
    {
        OrderTicket Process(OrderRequest request);
    }
}