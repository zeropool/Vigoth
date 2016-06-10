using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders
{
    public class StopLimitOrder : Order
    {
        public decimal StopPrice { get; internal set; }
        public bool StopTriggered { get; internal set; }
        public decimal LimitPrice { get; internal set; }
        public override OrderType Type
        {
            get { return OrderType.StopLimit; }
        }
        public StopLimitOrder()
        {
        }
        public StopLimitOrder(Symbol symbol, int quantity, decimal stopPrice, decimal limitPrice, DateTime time, string tag = "")
            : base(symbol, quantity, time, tag)
        {
            StopPrice = stopPrice;
            LimitPrice = limitPrice;
            if (tag == "")
            {
                Tag = "Stop Price: " + stopPrice.ToString("C") + " Limit Price: " + limitPrice.ToString("C");
            }
        }
        protected override decimal GetValueImpl(Security security)
        {
            if (Quantity < 0)
            {
                return Quantity*Math.Max(LimitPrice, security.Price);
            }
            if (Quantity > 0)
            {
                return Quantity*Math.Min(LimitPrice, security.Price);
            }
            return 0m;
        }
        public override void ApplyUpdateOrderRequest(UpdateOrderRequest request)
        {
            base.ApplyUpdateOrderRequest(request);
            if (request.StopPrice.HasValue)
            {
                StopPrice = request.StopPrice.Value;
            }
            if (request.LimitPrice.HasValue)
            {
                LimitPrice = request.LimitPrice.Value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} at stop {1} limit {2}", base.ToString(), StopPrice.SmartRounding(), LimitPrice.SmartRounding());
        }
        public override Order Clone()
        {
            var order = new StopLimitOrder {StopPrice = StopPrice, LimitPrice = LimitPrice};
            CopyTo(order);
            return order;
        }
    }
}