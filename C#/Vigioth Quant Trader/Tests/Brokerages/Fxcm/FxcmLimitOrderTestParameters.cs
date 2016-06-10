

using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Brokerages.Fxcm;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Orders;

namespace VigiothCapital.QuantTrader.Tests.Brokerages.Fxcm
{
    public class FxcmLimitOrderTestParameters : LimitOrderTestParameters
    {
        public FxcmLimitOrderTestParameters(Symbol symbol, decimal highLimit, decimal lowLimit)
            : base(symbol, highLimit, lowLimit)
        {
        }

        public override bool ModifyOrderToFill(IBrokerage brokerage, Order order, decimal lastMarketPrice)
        {
            // FXCM Buy Limit orders will be rejected if the limit price is above the market price
            // FXCM Sell Limit orders will be rejected if the limit price is below the market price

            var limit = (LimitOrder)order;
            var previousLimit = limit.LimitPrice;

            var fxcmBrokerage = (FxcmBrokerage)brokerage;
            var quotes = fxcmBrokerage.GetBidAndAsk(new List<string> { new FxcmSymbolMapper().GetBrokerageSymbol(order.Symbol) });

            if (order.Quantity > 0)
            {
                // for limit buys we need to increase the limit price
                // buy limit price must be at bid price or below
                var bidPrice = Convert.ToDecimal(quotes.Single().BidPrice);
                Log.Trace("FxcmLimitOrderTestParameters.ModifyOrderToFill(): Bid: " + bidPrice);
                limit.LimitPrice = Math.Max(previousLimit, Math.Min(bidPrice, limit.LimitPrice * 2));
            }
            else
            {
                // for limit sells we need to decrease the limit price
                // sell limit price must be at ask price or above
                var askPrice = Convert.ToDecimal(quotes.Single().AskPrice);
                Log.Trace("FxcmLimitOrderTestParameters.ModifyOrderToFill(): Ask: " + askPrice);
                limit.LimitPrice = Math.Min(previousLimit, Math.Max(askPrice, limit.LimitPrice / 2));
            }

            return limit.LimitPrice != previousLimit;
        }
    }
}
