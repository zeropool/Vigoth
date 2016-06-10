using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Equity;
namespace VigiothCapital.QuantTrader.Brokerages
{
    public class TradierBrokerageModel : DefaultBrokerageModel
    {
        private static readonly EquityExchange EquityExchange = 
            new EquityExchange(MarketHoursDatabase.FromDataFolder().GetExchangeHours(Market.USA, null, SecurityType.Equity, TimeZones.NewYork));
        public TradierBrokerageModel(AccountType accountType = AccountType.Margin)
            : base(accountType)
        {
        }
        public override bool CanSubmitOrder(Security security, Order order, out BrokerageMessageEvent message)
        {
            message = null;
            var securityType = order.SecurityType;
            if (securityType != SecurityType.Equity)
            {
                message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "NotSupported",
                    "This model only supports equities."
                    );
                return false;
            }
            if (!CanExecuteOrder(security, order))
            {
                message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "ExtendedMarket",
                    "Tradier does not support extended market hours trading.  Your order will be processed at market open."
                    );
            }
            return true;
        }
        public override bool CanUpdateOrder(Security security, Order order, UpdateOrderRequest request, out BrokerageMessageEvent message)
        {
            message = null;
            if (request.Quantity != null && request.Quantity != order.Quantity)
            {
                message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "UpdateRejected",
                    "Traider does not support updating order quantities."
                    );
                return false;
            }
            return true;
        }
        public override bool CanExecuteOrder(Security security, Order order)
        {
            EquityExchange.SetLocalDateTimeFrontier(security.Exchange.LocalTime);
            var cache = security.GetLastData();
            if (cache == null)
            {
                return false;
            }
            if (!EquityExchange.IsOpenDuringBar(cache.Time, cache.EndTime, false))
            {
                return false;
            }
            return true;
        }
        public override void ApplySplit(List<OrderTicket> tickets, Split split)
        {
            var splitFactor = split.SplitFactor;
            if (splitFactor > 1.0m)
            {
                tickets.ForEach(ticket => ticket.Cancel("Tradier Brokerage cancels open orders on reverse split symbols"));
            }
            else
            {
                base.ApplySplit(tickets, split);
            }
        }
        public override IFillModel GetFillModel(Security security)
        {
            return new ImmediateFillModel();
        }
        public override IFeeModel GetFeeModel(Security security)
        {
            return new ConstantFeeModel(1m);
        }
        public override ISlippageModel GetSlippageModel(Security security)
        {
            return new SpreadSlippageModel();
        }
    }
}
