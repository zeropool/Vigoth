using System.Collections.Generic;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Brokerages
{
    public class FxcmBrokerageModel : DefaultBrokerageModel
    {
        public new static readonly IReadOnlyDictionary<SecurityType, string> DefaultMarketMap = new Dictionary<SecurityType, string>
        {
            {SecurityType.Base, Market.USA},
            {SecurityType.Equity, Market.USA},
            {SecurityType.Option, Market.USA},
            {SecurityType.Forex, Market.FXCM},
            {SecurityType.Cfd, Market.FXCM}
        }.ToReadOnlyDictionary();
        public override IReadOnlyDictionary<SecurityType, string> DefaultMarkets
        {
            get { return DefaultMarketMap; }
        }
        public FxcmBrokerageModel(AccountType accountType = AccountType.Margin)
            : base(accountType)
        {
        }
        public override bool CanSubmitOrder(Security security, Order order, out BrokerageMessageEvent message)
        {
            message = null;
            if (security.Type != SecurityType.Forex && security.Type != SecurityType.Cfd)
            {
                message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "NotSupported",
                    "This model does not support " + security.Type + " security type."
                    );
                return false;
            }
            if (order.Type != OrderType.Limit && order.Type != OrderType.Market && order.Type != OrderType.StopMarket)
            {
                message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "NotSupported",
                    "This model does not support " + order.Type + " order type."
                    );
                return false;
            }
            if (order.Quantity % 1000 != 0)
            {
                message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "NotSupported",
                    "The order quantity must be a multiple of 1000."
                    );
                return false;
            }
            var limit = order as LimitOrder;
            if (limit != null)
            {
                return IsValidOrderPrices(security, OrderType.Limit, limit.Direction, security.Price, limit.LimitPrice, ref message);
            }
            var stopMarket = order as StopMarketOrder;
            if (stopMarket != null)
            {
                return IsValidOrderPrices(security, OrderType.StopMarket, stopMarket.Direction, stopMarket.StopPrice, security.Price, ref message);
            }
            var stopLimit = order as StopLimitOrder;
            if (stopLimit != null)
            {
                return IsValidOrderPrices(security, OrderType.StopLimit, stopLimit.Direction, stopLimit.StopPrice, stopLimit.LimitPrice, ref message);
            }
            return true;
        }
        public override bool CanUpdateOrder(Security security, Order order, UpdateOrderRequest request, out BrokerageMessageEvent message)
        {
            message = null;
            if (request.Quantity != null && request.Quantity % 1000 != 0)
            {
                message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "NotSupported",
                    "The order quantity must be a multiple of 1000."
                    );
                return false;
            }
            var newQuantity = request.Quantity ?? order.Quantity;
            var direction = newQuantity > 0 ? OrderDirection.Buy : OrderDirection.Sell;
            var stopPrice = request.StopPrice ?? security.Price;
            var limitPrice = request.LimitPrice ?? security.Price;
            return IsValidOrderPrices(security, order.Type, direction, stopPrice, limitPrice, ref message);
        }
        public override IFillModel GetFillModel(Security security)
        {
            return new ImmediateFillModel();
        }
        public override IFeeModel GetFeeModel(Security security)
        {
            return new FxcmFeeModel();
        }
        public override ISlippageModel GetSlippageModel(Security security)
        {
            return new SpreadSlippageModel();
        }
        private static bool IsValidOrderPrices(Security security, OrderType orderType, OrderDirection orderDirection, decimal stopPrice, decimal limitPrice, ref BrokerageMessageEvent message)
        {
            var invalidPrice = orderType == OrderType.Limit && orderDirection == OrderDirection.Buy && limitPrice > security.Price ||
                orderType == OrderType.Limit && orderDirection == OrderDirection.Sell && limitPrice < security.Price ||
                orderType == OrderType.StopMarket && orderDirection == OrderDirection.Buy && stopPrice < security.Price ||
                orderType == OrderType.StopMarket && orderDirection == OrderDirection.Sell && stopPrice > security.Price;
            if (invalidPrice)
            {
                message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "NotSupported",
                    "Limit Buy orders and Stop Sell orders must be below market, Limit Sell orders and Stop Buy orders must be above market."
                    );
                return false;
            }
            return true;
        }
    }
}
