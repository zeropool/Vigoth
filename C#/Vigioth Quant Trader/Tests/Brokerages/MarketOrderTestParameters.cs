

using System;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Orders;

namespace VigiothCapital.QuantTrader.Tests.Brokerages
{
    public class MarketOrderTestParameters : OrderTestParameters
    {
        public MarketOrderTestParameters(Symbol symbol)
            : base(symbol)
        {
        }

        public override Order CreateShortOrder(int quantity)
        {
            return new MarketOrder(Symbol, -Math.Abs(quantity), DateTime.Now);
        }

        public override Order CreateLongOrder(int quantity)
        {
            return new MarketOrder(Symbol, Math.Abs(quantity), DateTime.Now);
        }

        public override bool ModifyOrderToFill(IBrokerage brokerage, Order order, decimal lastMarketPrice)
        {
            // NOP
            // market orders should fill without modification
            return false;
        }

        public override OrderStatus ExpectedStatus
        {
            // all market orders should fill
            get { return OrderStatus.Filled; }
        }
    }
}