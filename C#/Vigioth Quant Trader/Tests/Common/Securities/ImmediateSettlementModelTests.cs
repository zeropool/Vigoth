

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class ImmediateSettlementModelTests
    {
        private static readonly DateTime Noon = new DateTime(2014, 6, 24, 12, 0, 0);
        private static readonly TimeKeeper TimeKeeper = new TimeKeeper(Noon.ConvertToUtc(TimeZones.NewYork), new[] { TimeZones.NewYork });

        [Test]
        public void FundsAreSettledImmediately()
        {
            var securities = new SecurityManager(TimeKeeper);
            var transactions = new SecurityTransactionManager(securities);
            var portfolio = new SecurityPortfolioManager(securities, transactions);
            var model = new ImmediateSettlementModel();
            var config = CreateTradeBarConfig();
            var security = new Security(SecurityExchangeHoursTests.CreateUsEquitySecurityExchangeHours(), config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));

            portfolio.SetCash(1000);
            Assert.AreEqual(1000, portfolio.Cash);
            Assert.AreEqual(0, portfolio.UnsettledCash);

            var timeUtc = Noon.ConvertToUtc(TimeZones.NewYork);
            model.ApplyFunds(portfolio, security, timeUtc, "USD", 1000);

            Assert.AreEqual(2000, portfolio.Cash);
            Assert.AreEqual(0, portfolio.UnsettledCash);

            model.ApplyFunds(portfolio, security, timeUtc, "USD", -500);

            Assert.AreEqual(1500, portfolio.Cash);
            Assert.AreEqual(0, portfolio.UnsettledCash);

            model.ApplyFunds(portfolio, security, timeUtc, "USD", 1000);

            Assert.AreEqual(2500, portfolio.Cash);
            Assert.AreEqual(0, portfolio.UnsettledCash);
        }

        private SubscriptionDataConfig CreateTradeBarConfig()
        {
            return new SubscriptionDataConfig(typeof(TradeBar), Symbols.SPY, Resolution.Minute, TimeZones.NewYork, TimeZones.NewYork, true, true, false);
        }
    }
}
