using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Equity;
using VigiothCapital.QuantTrader.Securities.Option;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Brokerages
{
    public class DefaultBrokerageModel : IBrokerageModel
    {
        public static readonly IReadOnlyDictionary<SecurityType, string> DefaultMarketMap = new Dictionary<SecurityType, string>
        {
            {SecurityType.Base, Market.USA},
            {SecurityType.Equity, Market.USA},
            {SecurityType.Option, Market.USA},
            {SecurityType.Forex, Market.FXCM},
            {SecurityType.Cfd, Market.FXCM}
        }.ToReadOnlyDictionary();
        public virtual AccountType AccountType
        {
            get; 
            private set;
        }
        public virtual IReadOnlyDictionary<SecurityType, string> DefaultMarkets
        {
            get { return DefaultMarketMap; }
        }
        public DefaultBrokerageModel(AccountType accountType = AccountType.Margin)
        {
            AccountType = accountType;
        }
        public virtual bool CanSubmitOrder(Security security, Order order, out BrokerageMessageEvent message)
        {
            message = null;
            return true;
        }
        public virtual bool CanUpdateOrder(Security security, Order order, UpdateOrderRequest request, out BrokerageMessageEvent message)
        {
            message = null;
            return true;
        }
        public virtual bool CanExecuteOrder(Security security, Order order)
        {
            return true;
        }
        public virtual void ApplySplit(List<OrderTicket> tickets, Split split)
        {
            var splitFactor = split.SplitFactor;
            tickets.ForEach(ticket => ticket.Update(new UpdateOrderFields
            {
                Quantity = (int?) (ticket.Quantity/splitFactor),
                LimitPrice = ticket.OrderType.IsLimitOrder() ? ticket.Get(OrderField.LimitPrice)*splitFactor : (decimal?) null,
                StopPrice = ticket.OrderType.IsStopOrder() ? ticket.Get(OrderField.StopPrice)*splitFactor : (decimal?) null
            }));
        }
        public decimal GetLeverage(Security security)
        {
            switch (security.Type)
            {
                case SecurityType.Equity:
                    return 2m;
                case SecurityType.Forex:
                case SecurityType.Cfd:
                    return 50m;
                case SecurityType.Base:
                case SecurityType.Commodity:
                case SecurityType.Option:
                case SecurityType.Future:
                default:
                    return 1m;
            }
        }
        public virtual IFillModel GetFillModel(Security security)
        {
            return new ImmediateFillModel();
        }
        public virtual IFeeModel GetFeeModel(Security security)
        {
            switch (security.Type)
            {
                case SecurityType.Base:
                    return new ConstantFeeModel(0m);
                case SecurityType.Forex:
                case SecurityType.Equity:
                    return new InteractiveBrokersFeeModel();
                case SecurityType.Commodity:
                case SecurityType.Option:
                case SecurityType.Future:
                case SecurityType.Cfd:
                default:
                    return new ConstantFeeModel(0m);
            }
        }
        public virtual ISlippageModel GetSlippageModel(Security security)
        {
            switch (security.Type)
            {
                case SecurityType.Base:
                case SecurityType.Equity:
                    return new ConstantSlippageModel(0);
                case SecurityType.Forex:
                case SecurityType.Cfd:
                    return new SpreadSlippageModel();
                case SecurityType.Commodity:
                case SecurityType.Option:
                case SecurityType.Future:
                default:
                    return new ConstantSlippageModel(0);
            }
        }
        public virtual ISettlementModel GetSettlementModel(Security security, AccountType accountType)
        {
            if (accountType == AccountType.Cash)
            {
                switch (security.Type)
                {
                    case SecurityType.Equity:
                        return new DelayedSettlementModel(Equity.DefaultSettlementDays, Equity.DefaultSettlementTime);
                    case SecurityType.Option:
                        return new DelayedSettlementModel(Option.DefaultSettlementDays, Option.DefaultSettlementTime);
                }
            }
            return new ImmediateSettlementModel();
        }
    }
}