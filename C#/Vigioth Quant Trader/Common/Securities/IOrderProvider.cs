using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Orders;
namespace VigiothCapital.QuantTrader.Securities
{
    public interface IOrderProvider
    {
        int OrdersCount { get; }
        Order GetOrderById(int orderId);
        Order GetOrderByBrokerageId(string brokerageId);
        IEnumerable<OrderTicket> GetOrderTickets(Func<OrderTicket, bool> filter = null);
        OrderTicket GetOrderTicket(int orderId);
        IEnumerable<Order> GetOrders(Func<Order, bool> filter = null);
    }
    public static class OrderProviderExtensions
    {
        public static Order GetOrderByBrokerageId(this IOrderProvider orderProvider, long brokerageId)
        {
            return orderProvider.GetOrderByBrokerageId(brokerageId.ToString());
        }
        public static Order GetOrderByBrokerageId(this IOrderProvider orderProvider, int brokerageId)
        {
            return orderProvider.GetOrderByBrokerageId(brokerageId.ToString());
        }
    }
}