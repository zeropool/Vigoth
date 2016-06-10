

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Brokerages
{
    /// <summary>
    /// Provides a test implementation of order mapping
    /// </summary>
    public class OrderProvider : IOrderProvider
    {
        private static int _orderID;
        private readonly IList<Order> _orders;

        public OrderProvider(IList<Order> orders)
        {
            _orders = orders;
        }

        public OrderProvider()
        {
            _orders = new List<Order>();
        }

        public void Add(Order order)
        {
            order.Id = Interlocked.Increment(ref _orderID);
            _orders.Add(order);
        }

        public int OrdersCount
        {
            get { return _orders.Count; }
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.FirstOrDefault(x => x.Id == orderId);
        }

        public Order GetOrderByBrokerageId(string brokerageId)
        {
            return _orders.FirstOrDefault(x => x.BrokerId.Contains(brokerageId));
        }

        public IEnumerable<OrderTicket> GetOrderTickets(Func<OrderTicket, bool> filter = null)
        {
            throw new NotImplementedException("This method has not been implemented");
        }

        public OrderTicket GetOrderTicket(int orderId)
        {
            throw new NotImplementedException("This method has not been implemented");
        }

        public IEnumerable<Order> GetOrders(Func<Order, bool> filter)
        {
            return _orders.Where(filter);
        }
    }
}