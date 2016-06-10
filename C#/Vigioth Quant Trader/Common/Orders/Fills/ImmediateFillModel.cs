using System;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders.Fills
{
    public class ImmediateFillModel : IFillModel
    {
        public virtual OrderEvent MarketFill(Security asset, MarketOrder order)
        {
            var utcTime = asset.LocalTime.ConvertToUtc(asset.Exchange.TimeZone);
            var fill = new OrderEvent(order, utcTime, 0);
            if (order.Status == OrderStatus.Canceled) return fill;
            if (!IsExchangeOpen(asset)) return fill;
            fill.FillPrice = GetPrices(asset, order.Direction).Current;
            fill.Status = OrderStatus.Filled;
            var slip = asset.SlippageModel.GetSlippageApproximation(asset, order);
            switch (order.Direction)
            {
                case OrderDirection.Buy:
                    fill.FillPrice += slip;
                    break;
                case OrderDirection.Sell:
                    fill.FillPrice -= slip;
                    break;
            }
            if (fill.Status == OrderStatus.Filled)
            {
                fill.FillQuantity = order.Quantity;
                fill.OrderFee = asset.FeeModel.GetOrderFee(asset, order);
            }
            return fill;
        }
        public virtual OrderEvent StopMarketFill(Security asset, StopMarketOrder order)
        {
            var utcTime = asset.LocalTime.ConvertToUtc(asset.Exchange.TimeZone);
            var fill = new OrderEvent(order, utcTime, 0);
            if (!IsExchangeOpen(asset)) return fill;
            if (order.Status == OrderStatus.Canceled) return fill;
            var prices = GetPrices(asset, order.Direction);
            var slip = asset.SlippageModel.GetSlippageApproximation(asset, order);
            switch (order.Direction)
            {
                case OrderDirection.Sell:
                    if (prices.Low < order.StopPrice)
                    {
                        fill.Status = OrderStatus.Filled;
                        fill.FillPrice = Math.Min(order.StopPrice, prices.Current - slip); 
                    }
                    break;
                case OrderDirection.Buy:
                    if (prices.High > order.StopPrice)
                    {
                        fill.Status = OrderStatus.Filled;
                        fill.FillPrice = Math.Max(order.StopPrice, prices.Current + slip);
                    }
                    break;
            }
            if (fill.Status == OrderStatus.Filled)
            {
                fill.FillQuantity = order.Quantity;
                fill.OrderFee = asset.FeeModel.GetOrderFee(asset, order);
            }
            return fill;
        }
        public virtual OrderEvent StopLimitFill(Security asset, StopLimitOrder order)
        {
            var utcTime = asset.LocalTime.ConvertToUtc(asset.Exchange.TimeZone);
            var fill = new OrderEvent(order, utcTime, 0);
            if (order.Status == OrderStatus.Canceled) return fill;
            var prices = GetPrices(asset, order.Direction);
            switch (order.Direction)
            {
                case OrderDirection.Buy:
                    if (prices.High > order.StopPrice || order.StopTriggered)
                    {
                        order.StopTriggered = true;
                        if (asset.Price < order.LimitPrice)
                        {
                            fill.Status = OrderStatus.Filled;
                            fill.FillPrice = order.LimitPrice;
                        }
                    }
                    break;
                case OrderDirection.Sell:
                    if (prices.Low < order.StopPrice || order.StopTriggered)
                    {
                        order.StopTriggered = true;
                        if (asset.Price > order.LimitPrice)
                        {
                            fill.Status = OrderStatus.Filled;
                            fill.FillPrice = order.LimitPrice;        
                        }
                    }
                    break;
            }
            if (fill.Status == OrderStatus.Filled)
            {
                fill.FillQuantity = order.Quantity;
                fill.OrderFee = asset.FeeModel.GetOrderFee(asset, order);
            }
            return fill;
        }
        public virtual OrderEvent LimitFill(Security asset, LimitOrder order)
        {
            var utcTime = asset.LocalTime.ConvertToUtc(asset.Exchange.TimeZone);
            var fill = new OrderEvent(order, utcTime, 0);
            if (order.Status == OrderStatus.Canceled) return fill;
            var prices = GetPrices(asset, order.Direction);
            switch (order.Direction)
            {
                case OrderDirection.Buy:
                    if (prices.Low < order.LimitPrice)
                    {
                        fill.Status = OrderStatus.Filled;
                        fill.FillPrice = Math.Min(prices.High, order.LimitPrice);
                    }
                    break;
                case OrderDirection.Sell:
                    if (prices.High > order.LimitPrice)
                    {
                        fill.Status = OrderStatus.Filled;
                        fill.FillPrice = Math.Max(prices.Low, order.LimitPrice);
                    }
                    break;
            }
            if (fill.Status == OrderStatus.Filled)
            {
                fill.FillQuantity = order.Quantity;
                fill.OrderFee = asset.FeeModel.GetOrderFee(asset, order);
            }
            return fill;
        }
        public OrderEvent MarketOnOpenFill(Security asset, MarketOnOpenOrder order)
        {
            var utcTime = asset.LocalTime.ConvertToUtc(asset.Exchange.TimeZone);
            var fill = new OrderEvent(order, utcTime, 0);
            if (order.Status == OrderStatus.Canceled) return fill;
            var currentBar = asset.GetLastData();
            var localOrderTime = order.Time.ConvertFromUtc(asset.Exchange.TimeZone);
            if (currentBar == null || localOrderTime >= currentBar.EndTime) return fill;
            if (asset.Exchange.DateTimeIsOpen(localOrderTime) && localOrderTime.Date == asset.LocalTime.Date)
            {
                return fill;
            }
            if (!IsExchangeOpen(asset)) return fill;
            fill.FillPrice = GetPrices(asset, order.Direction).Open;
            fill.Status = OrderStatus.Filled;
            var slip = asset.SlippageModel.GetSlippageApproximation(asset, order);
            switch (order.Direction)
            {
                case OrderDirection.Buy:
                    fill.FillPrice += slip;
                    break;
                case OrderDirection.Sell:
                    fill.FillPrice -= slip;
                    break;
            }
            if (fill.Status == OrderStatus.Filled)
            {
                fill.FillQuantity = order.Quantity;
                fill.OrderFee = asset.FeeModel.GetOrderFee(asset, order);
            }
            return fill;
        }
        public OrderEvent MarketOnCloseFill(Security asset, MarketOnCloseOrder order)
        {
            var utcTime = asset.LocalTime.ConvertToUtc(asset.Exchange.TimeZone);
            var fill = new OrderEvent(order, utcTime, 0);
            if (order.Status == OrderStatus.Canceled) return fill;
            var localOrderTime = order.Time.ConvertFromUtc(asset.Exchange.TimeZone);
            var nextMarketClose = asset.Exchange.Hours.GetNextMarketClose(localOrderTime, false);
            if (asset.LocalTime < nextMarketClose)
            {
                return fill;
            }
            fill.FillPrice = GetPrices(asset, order.Direction).Close;
            fill.Status = OrderStatus.Filled;
            var slip = asset.SlippageModel.GetSlippageApproximation(asset, order);
            switch (order.Direction)
            {
                case OrderDirection.Buy:
                    fill.FillPrice += slip;
                    break;
                case OrderDirection.Sell:
                    fill.FillPrice -= slip;
                    break;
            }
            if (fill.Status == OrderStatus.Filled)
            {
                fill.FillQuantity = order.Quantity;
                fill.OrderFee = asset.FeeModel.GetOrderFee(asset, order);
            }
            return fill;
        }
        private Prices GetPrices(Security asset, OrderDirection direction)
        {
            var low = asset.Low;
            var high = asset.High;
            var open = asset.Open;
            var close = asset.Close;
            var current = asset.Price;
            if (direction == OrderDirection.Hold)
            {
                return new Prices(current, open, high, low, close);
            }
            var tick = asset.Cache.GetData<Tick>();
            if (tick != null)
            {
                if (direction == OrderDirection.Sell && tick.BidPrice != 0)
                {
                    current = tick.BidPrice;
                }
                else if (direction == OrderDirection.Buy && tick.AskPrice != 0)
                {
                    current = tick.AskPrice;
                }
            }
            var quoteBar = asset.Cache.GetData<QuoteBar>();
            if (quoteBar != null)
            {
                var bar = direction == OrderDirection.Sell ? quoteBar.Bid : quoteBar.Ask;
                if (bar != null)
                {
                    return new Prices(bar);
                }
            }
            var tradeBar = asset.Cache.GetData<TradeBar>();
            if (tradeBar != null)
            {
                return new Prices(tradeBar);
            }
            var lastData = asset.GetLastData();
            var lastBar = lastData as IBar;
            if (lastBar != null)
            {
                return new Prices(lastBar);
            }
            return new Prices(current, open, high, low, close);
        }
        private static bool IsExchangeOpen(Security asset)
        {
            if (!asset.Exchange.DateTimeIsOpen(asset.LocalTime))
            {
                var currentBar = asset.GetLastData();
                if (asset.LocalTime.Date != currentBar.EndTime.Date || !asset.Exchange.IsOpenDuringBar(currentBar.Time, currentBar.EndTime, false))
                {
                    return false;
                }
            }
            return true;
        }
        private class Prices
        {
            public readonly decimal Current;
            public readonly decimal Open;
            public readonly decimal High;
            public readonly decimal Low;
            public readonly decimal Close;
            public Prices(IBar bar)
                : this(bar.Close, bar.Open, bar.High, bar.Low, bar.Close)
            {
            }
            public Prices(decimal current, decimal open, decimal high, decimal low, decimal close)
            {
                Current = current;
                Open = open == 0 ? current : open;
                High = high == 0 ? current : high;
                Low = low == 0 ? current : low;
                Close = close == 0 ? current : close;
            }
        }
    }
}