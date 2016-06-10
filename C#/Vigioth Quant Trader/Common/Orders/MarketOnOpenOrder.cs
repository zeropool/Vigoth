using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders
{
    public class MarketOnOpenOrder : Order
    {
        public override OrderType Type
        {
            get { return OrderType.MarketOnOpen; }
        }
        public MarketOnOpenOrder()
        {
        }
        public MarketOnOpenOrder(Symbol symbol, int quantity, DateTime time, string tag = "")
            : base(symbol, quantity, time, tag)
        {
        }
        protected override decimal GetValueImpl(Security security)
        {
            return Quantity*security.Price;
        }
        public override Order Clone()
        {
            var order = new MarketOnOpenOrder();
            CopyTo(order);
            return order;
        }
    }
}
