using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders
{
    public class MarketOrder : Order
    {
        public MarketOrder()
        {
        }
        public override OrderType Type
        {
            get { return OrderType.Market; }
        }
        public MarketOrder(Symbol symbol, int quantity, DateTime time, string tag = "")
            : base(symbol, quantity, time, tag)
        {
        }
        protected override decimal GetValueImpl(Security security)
        {
            return Quantity*security.Price;
        }
        public override Order Clone()
        {
            var order = new MarketOrder();
            CopyTo(order);
            return order;
        }
    }
}