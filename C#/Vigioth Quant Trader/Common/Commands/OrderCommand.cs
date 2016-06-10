using System;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Commands
{
    public sealed class OrderCommand : ICommand
    {
        public SecurityType SecurityType { get; set; }
        public Symbol Symbol { get; set; }
        public OrderType OrderType { get; set; }
        public int Quantity { get; set; }
        public decimal LimitPrice { get; set; }
        public decimal StopPrice { get; set; }
        public string Tag { get; set; }
        public CommandResultPacket Run(IAlgorithm algorithm)
        {
            var request = new SubmitOrderRequest(OrderType, SecurityType, Symbol, Quantity, StopPrice, LimitPrice, DateTime.UtcNow, Tag);
            var ticket = algorithm.Transactions.ProcessRequest(request);
            var response = ticket.GetMostRecentOrderResponse();
            var message = string.Format("{0} for {1} units of {2}: {3}", OrderType, Quantity, Symbol, response);
            if (response.IsSuccess)
            {
                algorithm.Debug(message);
            }
            else
            {
                algorithm.Error(message);
            }
            return new CommandResultPacket(this, response.IsSuccess);
        }
        public override string ToString()
        {
            return new SubmitOrderRequest(OrderType, SecurityType, Symbol, Quantity, StopPrice, LimitPrice, DateTime.UtcNow, Tag).ToString();
        }
    }
}