using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Brokerages;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Interfaces
{
    public interface IBrokerage
    {
        event EventHandler<OrderEvent> OrderStatusChanged;
        event EventHandler<AccountEvent> AccountChanged;
        event EventHandler<BrokerageMessageEvent> Message;
        string Name { get; }
        bool IsConnected { get; }
        List<Order> GetOpenOrders();
        List<Holding> GetAccountHoldings();
        List<Cash> GetCashBalance();
        bool PlaceOrder(Order order);
        bool UpdateOrder(Order order);
        bool CancelOrder(Order order);
        void Connect();
        void Disconnect();
    }
}