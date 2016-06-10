using System;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Forex;
namespace VigiothCapital.QuantTrader.Orders.Fees
{
    public class InteractiveBrokersFeeModel : IFeeModel
    {
        private readonly decimal _forexCommissionRate;
        private readonly decimal _forexMinimumOrderFee;
        public InteractiveBrokersFeeModel(decimal monthlyForexTradeAmountInUSDollars = 0)
        {
            ProcessForexRateSchedule(monthlyForexTradeAmountInUSDollars, out _forexCommissionRate, out _forexMinimumOrderFee);
        }
        public decimal GetOrderFee(Security security, Order order)
        {
            switch (security.Type)
            {
                case SecurityType.Forex:
                    var totalOrderValue = order.GetValue(security);
                    var fee = Math.Abs(_forexCommissionRate*totalOrderValue);
                    return Math.Max(_forexMinimumOrderFee, fee);
                case SecurityType.Equity:
                    var tradeValue = Math.Abs(order.GetValue(security));
                    var tradeFee = 0.005m * order.AbsoluteQuantity;
                    var maximumPerOrder = 0.005m * tradeValue;
                    if (tradeFee < 1)
                    {
                        tradeFee = 1;
                    }
                    else if (tradeFee > maximumPerOrder)
                    {
                        tradeFee = maximumPerOrder;
                    }
                    return Math.Abs(tradeFee);
            }
            return 0m;
        }
        private static void ProcessForexRateSchedule(decimal monthlyForexTradeAmountInUSDollars, out decimal commissionRate, out decimal minimumOrderFee)
        {
            const decimal bp = 0.0001m;
            if (monthlyForexTradeAmountInUSDollars <= 1000000000)        
            {
                commissionRate = 0.20m * bp;
                minimumOrderFee = 2.00m;
            }
            else if (monthlyForexTradeAmountInUSDollars <= 2000000000)   
            {
                commissionRate = 0.15m * bp;
                minimumOrderFee = 1.50m;
            }
            else if (monthlyForexTradeAmountInUSDollars <= 5000000000)   
            {
                commissionRate = 0.10m * bp;
                minimumOrderFee = 1.25m;
            }
            else
            {
                commissionRate = 0.08m * bp;
                minimumOrderFee = 1.00m;
            }
        }
    }
}
