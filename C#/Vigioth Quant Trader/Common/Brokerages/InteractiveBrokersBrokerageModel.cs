using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Forex;
namespace VigiothCapital.QuantTrader.Brokerages
{
    public class InteractiveBrokersBrokerageModel : DefaultBrokerageModel
    {
        public InteractiveBrokersBrokerageModel(AccountType accountType = AccountType.Margin)
            : base(accountType)
        {
        }
        public override bool CanSubmitOrder(Security security, Order order, out BrokerageMessageEvent message)
        {
            message = null;
            switch (order.SecurityType)
            {
                case SecurityType.Base:
                    return false;
                case SecurityType.Equity:
                    return true;        
                case SecurityType.Option:
                    return true;
                case SecurityType.Commodity:
                    return true;
                case SecurityType.Forex:
                    return IsForexWithinOrderSizeLimits(order.Symbol.Value, order.Quantity, out message);
                case SecurityType.Future:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public override bool CanUpdateOrder(Security security, Order order, UpdateOrderRequest request, out BrokerageMessageEvent message)
        {
            message = null;
            if (order.SecurityType == SecurityType.Forex && request.Quantity != null)
            {
                return IsForexWithinOrderSizeLimits(order.Symbol.Value, request.Quantity.Value, out message);
            }
            return true;
        }
        public override bool CanExecuteOrder(Security security, Order order)
        {
            return order.SecurityType != SecurityType.Base;
        }
        private bool IsForexWithinOrderSizeLimits(string currencyPair, int quantity, out BrokerageMessageEvent message)
        {
            message = null;
            string baseCurrency, quoteCurrency;
            Forex.DecomposeCurrencyPair(currencyPair, out baseCurrency, out quoteCurrency);
            decimal max;
            ForexCurrencyLimits.TryGetValue(baseCurrency, out max);
            var orderIsWithinForexSizeLimits = quantity < max;
            if (!orderIsWithinForexSizeLimits)
            {
                message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "OrderSizeLimit",
                    string.Format("The maximum allowable order size is {0}{1}.", max, baseCurrency)
                    );
            }
            return orderIsWithinForexSizeLimits;
        }
        private static readonly IReadOnlyDictionary<string, decimal> ForexCurrencyLimits = new Dictionary<string, decimal>()
        {
            {"USD", 7000000m},
            {"AUD", 6000000m},
            {"CAD", 6000000m},
            {"CHF", 6000000m},
            {"CNH", 40000000m},
            {"CZK", 0m},              
            {"DKK", 35000000m},
            {"EUR", 5000000m},
            {"GBP", 4000000m},
            {"HKD", 50000000m},
            {"HUF", 0m},              
            {"ILS", 0m},              
            {"KRW", 750000000m},
            {"JPY", 550000000m},
            {"MXN", 70000000m},
            {"NOK", 35000000m},
            {"NZD", 8000000m},
            {"RUB", 30000000m},
            {"SEK", 40000000m},
            {"SGD", 8000000m}
        };
    }
}
