

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Equity;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities.Equity
{
    [TestFixture]
    public class EquityTransactionModelTests
    {
        private static readonly DateTime Noon = new DateTime(2014, 6, 24, 12, 0, 0);
        private static readonly TimeKeeper TimeKeeper = new TimeKeeper(Noon.ConvertToUtc(TimeZones.NewYork), new[] {TimeZones.NewYork});

        [Test]
        public void PerformsMarketFillBuy()
        {
            var model = new EquityTransactionModel();
            var order = new MarketOrder(Symbols.SPY, 100, Noon);
            var config = CreateTradeBarConfig();
            var security = new Security(SecurityExchangeHoursTests.CreateUsEquitySecurityExchangeHours(), config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            security.SetLocalTimeKeeper(TimeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 101.123m));

            var fill = model.MarketFill(security, order);
            Assert.AreEqual(order.Quantity, fill.FillQuantity);
            Assert.AreEqual(security.Price, fill.FillPrice);
            Assert.AreEqual(OrderStatus.Filled, fill.Status);
        }
        [Test]
        public void PerformsMarketFillSell()
        {
            var model = new EquityTransactionModel();
            var order = new MarketOrder(Symbols.SPY, -100, Noon);
            var config = CreateTradeBarConfig();
            var security = new Security(SecurityExchangeHoursTests.CreateUsEquitySecurityExchangeHours(), config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            security.SetLocalTimeKeeper(TimeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 101.123m));

            var fill = model.MarketFill(security, order);
            Assert.AreEqual(order.Quantity, fill.FillQuantity);
            Assert.AreEqual(security.Price, fill.FillPrice);
            Assert.AreEqual(OrderStatus.Filled, fill.Status);
        }

        [Test]
        public void PerformsLimitFillBuy()
        {
            var model = new EquityTransactionModel();
            var order = new LimitOrder(Symbols.SPY, 100, 101.5m, Noon);
            var config = CreateTradeBarConfig();
            var security = new Security(SecurityExchangeHoursTests.CreateUsEquitySecurityExchangeHours(), config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            security.SetLocalTimeKeeper(TimeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 102m));

            var fill = model.LimitFill(security, order);

            Assert.AreEqual(0, fill.FillQuantity);
            Assert.AreEqual(0, fill.FillPrice);
            Assert.AreEqual(OrderStatus.None, fill.Status);

            security.SetMarketPrice(new TradeBar(Noon, Symbols.SPY, 102m, 103m, 101m, 102.3m, 100));

            fill = model.LimitFill(security, order);

            // this fills worst case scenario, so it's at the limit price
            Assert.AreEqual(order.Quantity, fill.FillQuantity);
            Assert.AreEqual(Math.Min(order.LimitPrice, security.High), fill.FillPrice);
            Assert.AreEqual(OrderStatus.Filled, fill.Status);
        }

        [Test]
        public void PerformsLimitFillSell()
        {
            var model = new EquityTransactionModel();
            var order = new LimitOrder(Symbols.SPY, -100, 101.5m, Noon);
            var config = CreateTradeBarConfig();
            var security = new Security(SecurityExchangeHoursTests.CreateUsEquitySecurityExchangeHours(), config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            security.SetLocalTimeKeeper(TimeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 101m));

            var fill = model.LimitFill(security, order);

            Assert.AreEqual(0, fill.FillQuantity);
            Assert.AreEqual(0, fill.FillPrice);
            Assert.AreEqual(OrderStatus.None, fill.Status);

            security.SetMarketPrice(new TradeBar(Noon, Symbols.SPY, 102m, 103m, 101m, 102.3m, 100));

            fill = model.LimitFill(security, order);

            // this fills worst case scenario, so it's at the limit price
            Assert.AreEqual(order.Quantity, fill.FillQuantity);
            Assert.AreEqual(Math.Max(order.LimitPrice, security.Low), fill.FillPrice);
            Assert.AreEqual(OrderStatus.Filled, fill.Status);
        }

        [Test]
        public void PerformsStopLimitFillBuy()
        {
            var model = new EquityTransactionModel();
            var order = new StopLimitOrder(Symbols.SPY, 100, 101.5m, 101.75m, Noon);
            var config = CreateTradeBarConfig();
            var security = new Security(SecurityExchangeHoursTests.CreateUsEquitySecurityExchangeHours(), config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            security.SetLocalTimeKeeper(TimeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 100m));

            var fill = model.StopLimitFill(security, order);

            Assert.AreEqual(0, fill.FillQuantity);
            Assert.AreEqual(0, fill.FillPrice);
            Assert.AreEqual(OrderStatus.None, fill.Status);

            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 102m));

            fill = model.StopLimitFill(security, order);

            Assert.AreEqual(0, fill.FillQuantity);
            Assert.AreEqual(0, fill.FillPrice);
            Assert.AreEqual(OrderStatus.None, fill.Status);

            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 101.66m));

            fill = model.StopLimitFill(security, order);

            // this fills worst case scenario, so it's at the limit price
            Assert.AreEqual(order.Quantity, fill.FillQuantity);
            Assert.AreEqual(order.LimitPrice, fill.FillPrice);
            Assert.AreEqual(OrderStatus.Filled, fill.Status);
        }

        [Test]
        public void PerformsStopLimitFillSell()
        {
            var model = new EquityTransactionModel();
            var order = new StopLimitOrder(Symbols.SPY, -100, 101.75m, 101.50m, Noon);
            var config = CreateTradeBarConfig();
            var security = new Security(SecurityExchangeHoursTests.CreateUsEquitySecurityExchangeHours(), config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            security.SetLocalTimeKeeper(TimeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 102m));

            var fill = model.StopLimitFill(security, order);

            Assert.AreEqual(0, fill.FillQuantity);
            Assert.AreEqual(0, fill.FillPrice);
            Assert.AreEqual(OrderStatus.None, fill.Status);

            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 101m));

            fill = model.StopLimitFill(security, order);

            Assert.AreEqual(0, fill.FillQuantity);
            Assert.AreEqual(0, fill.FillPrice);
            Assert.AreEqual(OrderStatus.None, fill.Status);

            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 101.66m));

            fill = model.StopLimitFill(security, order);

            // this fills worst case scenario, so it's at the limit price
            Assert.AreEqual(order.Quantity, fill.FillQuantity);
            Assert.AreEqual(order.LimitPrice, fill.FillPrice);
            Assert.AreEqual(OrderStatus.Filled, fill.Status);
        }

        [Test]
        public void PerformsStopMarketFillBuy()
        {
            var model = new EquityTransactionModel();
            var order = new StopMarketOrder(Symbols.SPY, 100, 101.5m, Noon);
            var config = CreateTradeBarConfig();
            var security = new Security(SecurityExchangeHoursTests.CreateUsEquitySecurityExchangeHours(), config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            security.SetLocalTimeKeeper(TimeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 101m));

            var fill = model.StopMarketFill(security, order);

            Assert.AreEqual(0, fill.FillQuantity);
            Assert.AreEqual(0, fill.FillPrice);
            Assert.AreEqual(OrderStatus.None, fill.Status);

            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 102.5m));

            fill = model.StopMarketFill(security, order);

            // this fills worst case scenario, so it's min of asset/stop price
            Assert.AreEqual(order.Quantity, fill.FillQuantity);
            Assert.AreEqual(Math.Max(security.Price, order.StopPrice), fill.FillPrice);
            Assert.AreEqual(OrderStatus.Filled, fill.Status);
        }

        [Test]
        public void PerformsStopMarketFillSell()
        {
            var model = new EquityTransactionModel();
            var order = new StopMarketOrder(Symbols.SPY, -100, 101.5m, Noon);
            var config = CreateTradeBarConfig();
            var security = new Security(SecurityExchangeHoursTests.CreateUsEquitySecurityExchangeHours(), config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            security.SetLocalTimeKeeper(TimeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 102m));

            var fill = model.StopMarketFill(security, order);

            Assert.AreEqual(0, fill.FillQuantity);
            Assert.AreEqual(0, fill.FillPrice);
            Assert.AreEqual(OrderStatus.None, fill.Status);

            security.SetMarketPrice(new IndicatorDataPoint(Symbols.SPY, Noon, 101m));

            fill = model.StopMarketFill(security, order);

            // this fills worst case scenario, so it's min of asset/stop price
            Assert.AreEqual(order.Quantity, fill.FillQuantity);
            Assert.AreEqual(Math.Min(security.Price, order.StopPrice), fill.FillPrice);
            Assert.AreEqual(OrderStatus.Filled, fill.Status);
        }

        private SubscriptionDataConfig CreateTradeBarConfig()
        {
            return new SubscriptionDataConfig(typeof(TradeBar), Symbols.SPY, Resolution.Minute, TimeZones.NewYork, TimeZones.NewYork, true, true, false);
        }
    }
}
