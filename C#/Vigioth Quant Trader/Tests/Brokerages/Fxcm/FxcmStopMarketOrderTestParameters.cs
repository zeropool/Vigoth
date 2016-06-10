

using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Brokerages.Fxcm;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Orders;

namespace VigiothCapital.QuantTrader.Tests.Brokerages.Fxcm
{
    public class FxcmStopMarketOrderTestParameters : StopMarketOrderTestParameters
    {
        public FxcmStopMarketOrderTestParameters(Symbol symbol, decimal highLimit, decimal lowLimit)
            : base(symbol, highLimit, lowLimit)
        {
        }

        public override bool ModifyOrderToFill(IBrokerage brokerage, Order order, decimal lastMarketPrice)
        {
            // FXCM Buy StopMarket orders will be rejected if the stop price is below the market price
            // FXCM Sell StopMarket orders will be rejected if the stop price is above the market price

            var stop = (StopMarketOrder)order;
            var previousStop = stop.StopPrice;

            var fxcmBrokerage = (FxcmBrokerage)brokerage;
            var quotes = fxcmBrokerage.GetBidAndAsk(new List<string> { new FxcmSymbolMapper().GetBrokerageSymbol(order.Symbol) });
            
            if (order.Quantity > 0)
            {
                // for stop buys we need to decrease the stop price
                // buy stop price must be strictly above ask price
                var askPrice = Convert.ToDecimal(quotes.Single().AskPrice);
                Log.Trace("FxcmStopMarketOrderTestParameters.ModifyOrderToFill(): Ask: " + askPrice);
                stop.StopPrice = Math.Min(previousStop, Math.Max(askPrice, stop.StopPrice / 2) + 0.00001m);
            }
            else
            {
                // for stop sells we need to increase the stop price
                // sell stop price must be strictly below bid price
                var bidPrice = Convert.ToDecimal(quotes.Single().BidPrice);
                Log.Trace("FxcmStopMarketOrderTestParameters.ModifyOrderToFill(): Bid: " + bidPrice);
                stop.StopPrice = Math.Max(previousStop, Math.Min(bidPrice, stop.StopPrice * 2) - 0.00001m);
            }

            return stop.StopPrice != previousStop;
        }
    }
}
