using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Brokerages
{
    public class OandaBrokerageModel : DefaultBrokerageModel
    {
        public new static readonly IReadOnlyDictionary<SecurityType, string> DefaultMarketMap = new Dictionary<SecurityType, string>
        {
            {SecurityType.Base, Market.USA},
            {SecurityType.Equity, Market.USA},
            {SecurityType.Option, Market.USA},
            {SecurityType.Forex, Market.Oanda},
            {SecurityType.Cfd, Market.Oanda}
        }.ToReadOnlyDictionary();
        public override IReadOnlyDictionary<SecurityType, string> DefaultMarkets
        {
            get { return DefaultMarketMap; }
        }
        public OandaBrokerageModel(AccountType accountType = AccountType.Margin)
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
            return true;
        }
        public override bool CanExecuteOrder(Security security, Order order)
        {
            return order.DurationValue == DateTime.MaxValue || order.DurationValue <= order.Time.AddMonths(3);
        }
        public override IFillModel GetFillModel(Security security)
        {
            return new ImmediateFillModel();
        }
        public override IFeeModel GetFeeModel(Security security)
        {
            return new ConstantFeeModel(0m);
        }
        public override ISlippageModel GetSlippageModel(Security security)
        {
            return new SpreadSlippageModel();
        }
    }
}