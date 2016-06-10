using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Commands
{
    public class UpdateOrderCommand : ICommand
    {
        public int OrderId { get; set; }
        public int? Quantity { get; set; }
        public decimal? LimitPrice { get; set; }
        public decimal? StopPrice { get; set; }
        public string Tag { get; set; }
        public CommandResultPacket Run(IAlgorithm algorithm)
        {
            var ticket = algorithm.Transactions.UpdateOrder(new UpdateOrderRequest(algorithm.UtcTime, OrderId, new UpdateOrderFields
            {
                Quantity = Quantity,
                LimitPrice = LimitPrice,
                StopPrice = StopPrice,
                Tag = Tag
            }));
            var response = ticket.GetMostRecentOrderResponse();
            return new CommandResultPacket(this, response.IsSuccess);
        }
    }
}
