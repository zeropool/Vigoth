

using System;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Orders;

namespace VigiothCapital.QuantTrader.Tests.Brokerages
{
    public class StopMarketOrderTestParameters : OrderTestParameters
    {
        private readonly decimal _highLimit;
        private readonly decimal _lowLimit;

        public StopMarketOrderTestParameters(Symbol symbol, decimal highLimit, decimal lowLimit)
            : base(symbol)
        {
            _highLimit = highLimit;
            _lowLimit = lowLimit;
        }

        public override Order CreateShortOrder(int quantity)
        {
            return new StopMarketOrder(Symbol, -Math.Abs(quantity), _lowLimit, DateTime.Now);
        }

        public override Order CreateLongOrder(int quantity)
        {
            return new StopMarketOrder(Symbol, Math.Abs(quantity), _highLimit, DateTime.Now);
        }

        public override bool ModifyOrderToFill(IBrokerage brokerage, Order order, decimal lastMarketPrice)
        {
            var stop = (StopMarketOrder)order;
            var previousStop = stop.StopPrice;
            if (order.Quantity > 0)
            {
                // for stop buys we need to decrease the stop price
                stop.StopPrice = Math.Min(stop.StopPrice, Math.Max(stop.StopPrice / 2, lastMarketPrice));
            }
            else
            {
                // for stop sells we need to increase the stop price
                stop.StopPrice = Math.Max(stop.StopPrice, Math.Min(stop.StopPrice * 2, lastMarketPrice));
            }
            return stop.StopPrice != previousStop;
        }

        public override OrderStatus ExpectedStatus
        {
            // default limit orders will only be submitted, not filled
            get { return OrderStatus.Submitted; }
        }
    }
}