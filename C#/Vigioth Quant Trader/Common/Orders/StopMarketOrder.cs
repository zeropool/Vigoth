using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders
{
    public class StopMarketOrder : Order
    {
        public decimal StopPrice;
        public override OrderType Type
        {
            get { return OrderType.StopMarket; }
        }
        public StopMarketOrder()
        {
        }
        public StopMarketOrder(Symbol symbol, int quantity, decimal stopPrice, DateTime time, string tag = "")
            : base(symbol, quantity, time, tag)
        {
            StopPrice = stopPrice;
            if (tag == "")
            {
                Tag = "Stop Price: " + stopPrice.ToString("C");
            }
        }
        protected override decimal GetValueImpl(Security security)
        {
            if (Quantity < 0)
            {
                return Quantity*Math.Max(StopPrice, security.Price);
            }
            if (Quantity > 0)
            {
                return Quantity*Math.Min(StopPrice, security.Price);
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
        }
        public override string ToString()
        {
            return string.Format("{0} at stop {1}", base.ToString(), StopPrice.SmartRounding());
        }
        public override Order Clone()
        {
            var order = new StopMarketOrder {StopPrice = StopPrice};
            CopyTo(order);
            return order;
        }
    }
}
