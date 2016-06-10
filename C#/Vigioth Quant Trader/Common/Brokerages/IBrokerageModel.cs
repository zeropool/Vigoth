using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Brokerages
{
    public interface IBrokerageModel
    {
        AccountType AccountType
        {
            get;
        }
        IReadOnlyDictionary<SecurityType, string> DefaultMarkets { get; }
        bool CanSubmitOrder(Security security, Order order, out BrokerageMessageEvent message);
        bool CanUpdateOrder(Security security, Order order, UpdateOrderRequest request, out BrokerageMessageEvent message);
        bool CanExecuteOrder(Security security, Order order);
        void ApplySplit(List<OrderTicket> tickets, Split split);
        decimal GetLeverage(Security security);
        IFillModel GetFillModel(Security security);
        IFeeModel GetFeeModel(Security security);
        ISlippageModel GetSlippageModel(Security security);
        ISettlementModel GetSettlementModel(Security security, AccountType accountType);
    }
    public static class BrokerageModel
    {
        public static IBrokerageModel Create(BrokerageName brokerage, AccountType accountType)
        {
            switch (brokerage)
            {
                case BrokerageName.Default:
                    return new DefaultBrokerageModel(accountType);
                case BrokerageName.InteractiveBrokersBrokerage:
                    return new InteractiveBrokersBrokerageModel(accountType);
                case BrokerageName.TradierBrokerage:
                    return new TradierBrokerageModel(accountType);
                case BrokerageName.OandaBrokerage:
                    return new OandaBrokerageModel(accountType);
                case BrokerageName.FxcmBrokerage:
                    return new FxcmBrokerageModel(accountType);
                default:
                    throw new ArgumentOutOfRangeException("brokerage", brokerage, null);
            }
        }
    }
}
