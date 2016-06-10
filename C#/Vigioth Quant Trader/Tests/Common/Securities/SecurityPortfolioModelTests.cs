

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class SecurityPortfolioModelTests
    {
        [Test]
        public void LastTradeProfit_FlatToLong()
        {
            var reference = new DateTime(2016, 02, 16, 11, 53, 30);
            SecurityPortfolioManager portfolio;
            var security = InitializeTest(reference, out portfolio);

            var fillPrice = 100m;
            var fillQuantity = 100;
            var orderFee = 1m;
            var orderDirection = fillQuantity > 0 ? OrderDirection.Buy : OrderDirection.Sell;
            var fill = new OrderEvent(1, security.Symbol, reference, OrderStatus.Filled, orderDirection, fillPrice, fillQuantity, orderFee);
            portfolio.ProcessFill(fill);

            // zero since we're from flat
            Assert.AreEqual(0, security.Holdings.LastTradeProfit);
        }

        [Test]
        public void LastTradeProfit_FlatToShort()
        {
            var reference = new DateTime(2016, 02, 16, 11, 53, 30);
            SecurityPortfolioManager portfolio;
            var security = InitializeTest(reference, out portfolio);

            var fillPrice = 100m;
            var fillQuantity = -100;
            var orderFee = 1m;
            var orderDirection = fillQuantity > 0 ? OrderDirection.Buy : OrderDirection.Sell;
            var fill = new OrderEvent(1, security.Symbol, reference, OrderStatus.Filled, orderDirection, fillPrice, fillQuantity, orderFee);
            portfolio.ProcessFill(fill);

            // zero since we're from flat
            Assert.AreEqual(0, security.Holdings.LastTradeProfit);
        }

        [Test]
        public void LastTradeProfit_LongToLonger()
        {
            var reference = new DateTime(2016, 02, 16, 11, 53, 30);
            SecurityPortfolioManager portfolio;
            var security = InitializeTest(reference, out portfolio);

            security.Holdings.SetHoldings(50m, 100);

            var fillPrice = 100m;
            var fillQuantity = 100;
            var orderFee = 1m;
            var orderDirection = fillQuantity > 0 ? OrderDirection.Buy : OrderDirection.Sell;
            var fill = new OrderEvent(1, security.Symbol, reference, OrderStatus.Filled, orderDirection, fillPrice, fillQuantity, orderFee);
            portfolio.ProcessFill(fill);

            // zero since we're from flat
            Assert.AreEqual(0, security.Holdings.LastTradeProfit);
        }

        [Test]
        public void LastTradeProfit_LongToFlat()
        {
            var reference = new DateTime(2016, 02, 16, 11, 53, 30);
            SecurityPortfolioManager portfolio;
            var security = InitializeTest(reference, out portfolio);

            security.Holdings.SetHoldings(50m, 100);

            var fillPrice = 100m;
            var fillQuantity = -security.Holdings.Quantity;
            var orderFee = 1m;
            var orderDirection = fillQuantity > 0 ? OrderDirection.Buy : OrderDirection.Sell;
            var fill = new OrderEvent(1, security.Symbol, reference, OrderStatus.Filled, orderDirection, fillPrice, fillQuantity, orderFee);
            portfolio.ProcessFill(fill);

            // bought @50 and sold @100 = (-50*100)+(100*100 - 1) = 4999
            // current implementation doesn't back out fees.
            Assert.AreEqual(5000m, security.Holdings.LastTradeProfit);
        }

        [Test]
        public void LastTradeProfit_LongToShort()
        {
            var reference = new DateTime(2016, 02, 16, 11, 53, 30);
            SecurityPortfolioManager portfolio;
            var security = InitializeTest(reference, out portfolio);

            security.Holdings.SetHoldings(50m, 100);

            var fillPrice = 100m;
            var fillQuantity = -2*security.Holdings.Quantity;
            var orderFee = 1m;
            var orderDirection = fillQuantity > 0 ? OrderDirection.Buy : OrderDirection.Sell;
            var fill = new OrderEvent(1, security.Symbol, reference, OrderStatus.Filled, orderDirection, fillPrice, fillQuantity, orderFee);
            portfolio.ProcessFill(fill);

            // we can only take 'profit' on the closing part of the position, so we closed 100
            // shares and opened a new for the second 100, so ony the frst 100 go into the calculation
            // bought @50 and sold @100 = (-50*100)+(100*100 - 1) = 4999
            // current implementation doesn't back out fees.
            Assert.AreEqual(5000m, security.Holdings.LastTradeProfit);
        }

        [Test]
        public void LastTradeProfit_ShortToShorter()
        {
            var reference = new DateTime(2016, 02, 16, 11, 53, 30);
            SecurityPortfolioManager portfolio;
            var security = InitializeTest(reference, out portfolio);

            security.Holdings.SetHoldings(50m, -100);

            var fillPrice = 100m;
            var fillQuantity = -100;
            var orderFee = 1m;
            var orderDirection = fillQuantity > 0 ? OrderDirection.Buy : OrderDirection.Sell;
            var fill = new OrderEvent(1, security.Symbol, reference, OrderStatus.Filled, orderDirection, fillPrice, fillQuantity, orderFee);
            portfolio.ProcessFill(fill);

            Assert.AreEqual(0, security.Holdings.LastTradeProfit);
        }

        [Test]
        public void LastTradeProfit_ShortToFlat()
        {
            var reference = new DateTime(2016, 02, 16, 11, 53, 30);
            SecurityPortfolioManager portfolio;
            var security = InitializeTest(reference, out portfolio);

            security.Holdings.SetHoldings(50m, -100);

            var fillPrice = 100m;
            var fillQuantity = -security.Holdings.Quantity;
            var orderFee = 1m;
            var orderDirection = fillQuantity > 0 ? OrderDirection.Buy : OrderDirection.Sell;
            var fill = new OrderEvent(1, security.Symbol, reference, OrderStatus.Filled, orderDirection, fillPrice, fillQuantity, orderFee);
            portfolio.ProcessFill(fill);


            // sold @50 and bought @100 = (50*100)+(-100*100 - 1) = -5001
            // current implementation doesn't back out fees.
            Assert.AreEqual(-5000m, security.Holdings.LastTradeProfit);
        }

        [Test]
        public void LastTradeProfit_ShortToLong()
        {
            var reference = new DateTime(2016, 02, 16, 11, 53, 30);
            SecurityPortfolioManager portfolio;
            var security = InitializeTest(reference, out portfolio);

            security.Holdings.SetHoldings(50m, -100);

            var fillPrice = 100m;
            var fillQuantity = -2*security.Holdings.Quantity; // flip from -100 to +100
            var orderFee = 1m;
            var orderDirection = fillQuantity > 0 ? OrderDirection.Buy : OrderDirection.Sell;
            var fill = new OrderEvent(1, security.Symbol, reference, OrderStatus.Filled, orderDirection, fillPrice, fillQuantity, orderFee);
            portfolio.ProcessFill(fill);

            // we can only take 'profit' on the closing part of the position, so we closed 100
            // shares and opened a new for the second 100, so ony the frst 100 go into the calculation
            // sold @50 and bought @100 = (50*100)+(-100*100 - 1) = -5001
            // current implementation doesn't back out fees.
            Assert.AreEqual(-5000m, security.Holdings.LastTradeProfit);
        }

        private Security InitializeTest(DateTime reference, out SecurityPortfolioManager portfolio)
        {
            var security = new Security(SecurityExchangeHours.AlwaysOpen(TimeZones.NewYork), CreateTradeBarConfig(), new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            security.SetMarketPrice(new Tick { Value = 100 });
            var timeKeeper = new TimeKeeper(reference);
            var securityManager = new SecurityManager(timeKeeper);
            securityManager.Add(security);
            var transactionManager = new SecurityTransactionManager(securityManager);
            portfolio = new SecurityPortfolioManager(securityManager, transactionManager);
            portfolio.SetCash("USD", 100 * 1000m, 1m);
            Assert.AreEqual(0, security.Holdings.Quantity);
            Assert.AreEqual(100*1000m, portfolio.CashBook[CashBook.AccountCurrency].Amount);
            return security;
        }

        private static SubscriptionDataConfig CreateTradeBarConfig()
        {
            return new SubscriptionDataConfig(typeof(TradeBar), Symbols.SPY, Resolution.Minute, TimeZones.NewYork, TimeZones.NewYork, true, true, false);
        }
    }
}