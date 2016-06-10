using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders
{
    public class LimitOrder : Order
    {
        public decimal LimitPrice { get; internal set; }
        public override OrderType Type
        {
            get { return OrderType.Limit; }
        }
        public LimitOrder()
        {
        }
        public LimitOrder(Symbol symbol, int quantity, decimal limitPrice, DateTime time, string tag = "")
            : base(symbol, quantity, time, tag)
        {
            LimitPrice = limitPrice;
            if (tag == "")
            {
                Tag = "Limit Price: " + limitPrice.ToString("C");
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
            if (request.LimitPrice.HasValue)
            {
                LimitPrice = request.LimitPrice.Value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} at limit {1}", base.ToString(), LimitPrice.SmartRounding());
        }
        public override Order Clone()
        {
            var order = new LimitOrder {LimitPrice = LimitPrice};
            CopyTo(order);
            return order;
        }
    }
}
