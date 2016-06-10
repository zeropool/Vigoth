

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Cfd;
using VigiothCapital.QuantTrader.Securities.Equity;
using VigiothCapital.QuantTrader.Securities.Forex;

namespace VigiothCapital.QuantTrader.Tests.Common.Orders
{
    [TestFixture]
    public class OrderTests
    {
        [Test, TestCaseSource("GetValueTestParameters")]
        public void GetValueTest(ValueTestParameters parameters)
        {
            var value = parameters.Order.GetValue(parameters.Security);
            Assert.AreEqual(parameters.ExpectedValue, value);
        }

        private static TestCaseData[] GetValueTestParameters()
        {
            const decimal delta = 1m;
            const decimal price = 1.2345m;
            const int quantity = 100;
            const decimal pricePlusDelta = price + delta;
            const decimal priceMinusDelta = price - delta;
            var tz = TimeZones.NewYork;

            var time = new DateTime(2016, 2, 4, 16, 0, 0).ConvertToUtc(tz);

            var equity = new Equity(SecurityExchangeHours.AlwaysOpen(tz), new SubscriptionDataConfig(typeof(TradeBar), Symbols.SPY, Resolution.Minute, tz, tz, true, false, false), new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            equity.SetMarketPrice(new Tick {Value = price});

            var gbpCash = new Cash("GBP", 0, 1.46m);
            var properties = SymbolProperties.GetDefault(gbpCash.Symbol);
            var forex = new Forex(SecurityExchangeHours.AlwaysOpen(tz), gbpCash, new SubscriptionDataConfig(typeof(TradeBar), Symbols.EURGBP, Resolution.Minute, tz, tz, true, false, false), properties);
            forex.SetMarketPrice(new Tick {Value= price});

            var eurCash = new Cash("EUR", 0, 1.12m);
            properties = new SymbolProperties("Euro-Bund", eurCash.Symbol, 10, 0.1m);
            var cfd = new Cfd(SecurityExchangeHours.AlwaysOpen(tz), eurCash, new SubscriptionDataConfig(typeof(TradeBar), Symbols.DE10YBEUR, Resolution.Minute, tz, tz, true, false, false), properties);
            cfd.SetMarketPrice(new Tick { Value = price });
            var multiplierTimesConversionRate = properties.ContractMultiplier*eurCash.ConversionRate;

            return new List<ValueTestParameters>
            {
                // equity orders
                new ValueTestParameters("EquityLongMarketOrder", equity, new MarketOrder(Symbols.SPY, quantity, time), quantity*price),
                new ValueTestParameters("EquityShortMarketOrder", equity, new MarketOrder(Symbols.SPY, -quantity, time), -quantity*price),
                new ValueTestParameters("EquityLongLimitOrder", equity, new LimitOrder(Symbols.SPY, quantity, priceMinusDelta, time), quantity*priceMinusDelta),
                new ValueTestParameters("EquityShortLimit Order", equity, new LimitOrder(Symbols.SPY, -quantity, pricePlusDelta, time), -quantity*pricePlusDelta),
                new ValueTestParameters("EquityLongStopLimitOrder", equity, new StopLimitOrder(Symbols.SPY, quantity,.5m*priceMinusDelta, priceMinusDelta, time), quantity*priceMinusDelta),
                new ValueTestParameters("EquityShortStopLimitOrder", equity, new StopLimitOrder(Symbols.SPY, -quantity, 1.5m*pricePlusDelta, pricePlusDelta, time), -quantity*pricePlusDelta),
                new ValueTestParameters("EquityLongStopMarketOrder", equity, new StopMarketOrder(Symbols.SPY, quantity, priceMinusDelta, time), quantity*priceMinusDelta),
                new ValueTestParameters("EquityLongStopMarketOrder", equity, new StopMarketOrder(Symbols.SPY, quantity, pricePlusDelta, time), quantity*price),
                new ValueTestParameters("EquityShortStopMarketOrder", equity, new StopMarketOrder(Symbols.SPY, -quantity, pricePlusDelta, time), -quantity*pricePlusDelta),
                new ValueTestParameters("EquityShortStopMarketOrder", equity, new StopMarketOrder(Symbols.SPY, -quantity, priceMinusDelta, time), -quantity*price),

                // forex orders
                new ValueTestParameters("ForexLongMarketOrder", forex, new MarketOrder(Symbols.EURGBP, quantity, time), quantity*price*forex.QuoteCurrency.ConversionRate),
                new ValueTestParameters("ForexShortMarketOrder", forex, new MarketOrder(Symbols.EURGBP, -quantity, time), -quantity*price*forex.QuoteCurrency.ConversionRate),
                new ValueTestParameters("ForexLongLimitOrder", forex, new LimitOrder(Symbols.EURGBP, quantity, priceMinusDelta, time), quantity*priceMinusDelta*forex.QuoteCurrency.ConversionRate),
                new ValueTestParameters("ForexShortLimit Order", forex, new LimitOrder(Symbols.EURGBP, -quantity, pricePlusDelta, time), -quantity*pricePlusDelta*forex.QuoteCurrency.ConversionRate),
                new ValueTestParameters("ForexLongStopLimitOrder", forex, new StopLimitOrder(Symbols.EURGBP, quantity,.5m*priceMinusDelta, priceMinusDelta, time), quantity*priceMinusDelta*forex.QuoteCurrency.ConversionRate),
                new ValueTestParameters("ForexShortStopLimitOrder", forex, new StopLimitOrder(Symbols.EURGBP, -quantity, 1.5m*pricePlusDelta, pricePlusDelta, time), -quantity*pricePlusDelta*forex.QuoteCurrency.ConversionRate),
                new ValueTestParameters("ForexLongStopMarketOrder", forex, new StopMarketOrder(Symbols.EURGBP, quantity, priceMinusDelta, time), quantity*priceMinusDelta*forex.QuoteCurrency.ConversionRate),
                new ValueTestParameters("ForexLongStopMarketOrder", forex, new StopMarketOrder(Symbols.EURGBP, quantity, pricePlusDelta, time), quantity*price*forex.QuoteCurrency.ConversionRate),
                new ValueTestParameters("ForexShortStopMarketOrder", forex, new StopMarketOrder(Symbols.EURGBP, -quantity, pricePlusDelta, time), -quantity*pricePlusDelta*forex.QuoteCurrency.ConversionRate),
                new ValueTestParameters("ForexShortStopMarketOrder", forex, new StopMarketOrder(Symbols.EURGBP, -quantity, priceMinusDelta, time), -quantity*price*forex.QuoteCurrency.ConversionRate),
                
                // cfd orders
                new ValueTestParameters("CfdLongMarketOrder", cfd, new MarketOrder(Symbols.DE10YBEUR, quantity, time), quantity*price*multiplierTimesConversionRate),
                new ValueTestParameters("CfdShortMarketOrder", cfd, new MarketOrder(Symbols.DE10YBEUR, -quantity, time), -quantity*price*multiplierTimesConversionRate),
                new ValueTestParameters("CfdLongLimitOrder", cfd, new LimitOrder(Symbols.DE10YBEUR, quantity, priceMinusDelta, time), quantity*priceMinusDelta*multiplierTimesConversionRate),
                new ValueTestParameters("CfdShortLimit Order", cfd, new LimitOrder(Symbols.DE10YBEUR, -quantity, pricePlusDelta, time), -quantity*pricePlusDelta*multiplierTimesConversionRate),
                new ValueTestParameters("CfdLongStopLimitOrder", cfd, new StopLimitOrder(Symbols.DE10YBEUR, quantity,.5m*priceMinusDelta, priceMinusDelta, time), quantity*priceMinusDelta*multiplierTimesConversionRate),
                new ValueTestParameters("CfdShortStopLimitOrder", cfd, new StopLimitOrder(Symbols.DE10YBEUR, -quantity, 1.5m*pricePlusDelta, pricePlusDelta, time), -quantity*pricePlusDelta*multiplierTimesConversionRate),
                new ValueTestParameters("CfdLongStopMarketOrder", cfd, new StopMarketOrder(Symbols.DE10YBEUR, quantity, priceMinusDelta, time), quantity*priceMinusDelta*multiplierTimesConversionRate),
                new ValueTestParameters("CfdLongStopMarketOrder", cfd, new StopMarketOrder(Symbols.DE10YBEUR, quantity, pricePlusDelta, time), quantity*price*multiplierTimesConversionRate),
                new ValueTestParameters("CfdShortStopMarketOrder", cfd, new StopMarketOrder(Symbols.DE10YBEUR, -quantity, pricePlusDelta, time), -quantity*pricePlusDelta*multiplierTimesConversionRate),
                new ValueTestParameters("CfdShortStopMarketOrder", cfd, new StopMarketOrder(Symbols.DE10YBEUR, -quantity, priceMinusDelta, time), -quantity*price*multiplierTimesConversionRate),

            }.Select(x => new TestCaseData(x).SetName(x.Name)).ToArray();
        }

        public class ValueTestParameters
        {
            public readonly string Name;
            public readonly Security Security;
            public readonly Order Order;
            public readonly decimal ExpectedValue;

            public ValueTestParameters(string name, Security security, Order order, decimal expectedValue)
            {
                Name = name;
                Security = security;
                Order = order;
                ExpectedValue = expectedValue;
            }
        }
    }
}
