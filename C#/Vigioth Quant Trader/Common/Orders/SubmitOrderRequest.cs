using System;
namespace VigiothCapital.QuantTrader.Orders
{
    public class SubmitOrderRequest : OrderRequest
    {
        public override OrderRequestType OrderRequestType
        {
            get { return OrderRequestType.Submit; }
        }
        public SecurityType SecurityType
        {
            get; private set;
        }
        public Symbol Symbol
        {
            get; private set;
        }
        public OrderType OrderType
        {
            get; private set;
        }
        public int Quantity
        {
            get; private set;
        }
        public decimal LimitPrice
        {
            get; private set;
        }
        public decimal StopPrice
        {
            get; private set;
        }
        public SubmitOrderRequest(OrderType orderType, SecurityType securityType, Symbol symbol, int quantity, decimal stopPrice, decimal limitPrice, DateTime time, string tag)
            : base(time, (int) OrderResponseErrorCode.UnableToFindOrder, tag)
        {
            SecurityType = securityType;
            Symbol = symbol;
            OrderType = orderType;
            Quantity = quantity;
            LimitPrice = limitPrice;
            StopPrice = stopPrice;
        }
        internal void SetOrderId(int orderId)
        {
            OrderId = orderId;
        }
        public override string ToString()
        {
            var proxy = Order.CreateOrder(this);
            return string.Format("{0} UTC: Submit Order: ({1}) - {2} {3}", Time, OrderId, proxy, Tag) + " Status: " + Status;
        }
    }
}