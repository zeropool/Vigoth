using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders
{
    public class MarketOnCloseOrder : Order
    {
        public override OrderType Type
        {
            get { return OrderType.MarketOnClose; }
        }
        public MarketOnCloseOrder()
        {
        }
        public MarketOnCloseOrder(Symbol symbol, int quantity, DateTime time, string tag = "")
            : base(symbol, quantity, time, tag)
        {
        }
        protected override decimal GetValueImpl(Security security)
        {
            return Quantity*security.Price;
        }
        public override Order Clone()
        {
            var order = new MarketOnCloseOrder();
            CopyTo(order);
            return order;
        }
    }
}
