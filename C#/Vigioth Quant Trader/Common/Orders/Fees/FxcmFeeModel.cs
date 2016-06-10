using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders.Fees
{
    public class FxcmFeeModel : IFeeModel
    {
        private readonly HashSet<Symbol> _groupCommissionSchedule1 = new HashSet<Symbol>
        {
            Symbol.Create("EURUSD", SecurityType.Forex, Market.FXCM),
            Symbol.Create("GBPUSD", SecurityType.Forex, Market.FXCM),
            Symbol.Create("USDJPY", SecurityType.Forex, Market.FXCM),
            Symbol.Create("USDCHF", SecurityType.Forex, Market.FXCM),
            Symbol.Create("AUDUSD", SecurityType.Forex, Market.FXCM),
            Symbol.Create("EURJPY", SecurityType.Forex, Market.FXCM),
            Symbol.Create("GBPJPY", SecurityType.Forex, Market.FXCM),
        };
        public decimal GetOrderFee(Security security, Order order)
        {
            if (security.Type != SecurityType.Forex)
                return 0m;
            var commissionRate = _groupCommissionSchedule1.Contains(security.Symbol) ? 0.04m : 0.06m;
            return Math.Abs(commissionRate*order.AbsoluteQuantity/1000);
        }
    }
}