using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Commands
{
    public sealed class CancelOrderCommand : ICommand
    {
        public int OrderId { get; set; }
        public CommandResultPacket Run(IAlgorithm algorithm)
        {
            var ticket = algorithm.Transactions.CancelOrder(OrderId);
            return ticket.CancelRequest != null 
                ? new Result(this, true, ticket.QuantityFilled) 
                : new Result(this, false, ticket.QuantityFilled);
        }
        public class Result : CommandResultPacket
        {
            public decimal QuantityFilled { get; set; }
            public Result(ICommand command, bool success, decimal quantityFilled)
                : base(command, success)
            {
                QuantityFilled = quantityFilled;
            }
        }
    }
}
