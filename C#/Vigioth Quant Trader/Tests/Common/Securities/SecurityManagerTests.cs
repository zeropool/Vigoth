

using System;
using System.Collections.Specialized;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class SecurityManagerTests
    {
        [Test]
        public void NotifiesWhenSecurityAdded()
        {
            var timeKeeper = new TimeKeeper(new DateTime(2015, 12, 07));
            var manager = new SecurityManager(timeKeeper);

            var security = new Security(SecurityExchangeHours.AlwaysOpen(TimeZones.NewYork), CreateTradeBarConfig(), new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            manager.CollectionChanged += (sender, args) =>
            {
                if (args.NewItems.OfType<object>().Single() != security)
                {
                    Assert.Fail("Expected args.NewItems to have exactly one element equal to security");
                }
                else
                {
                    Assert.IsTrue(args.Action == NotifyCollectionChangedAction.Add);
                    Assert.Pass();
                }
            };

            manager.Add(security.Symbol, security);
        }

        [Test]
        public void NotifiesWhenSecurityAddedViaIndexer()
        {
            var timeKeeper = new TimeKeeper(new DateTime(2015, 12, 07));
            var manager = new SecurityManager(timeKeeper);

            var security = new Security(SecurityExchangeHours.AlwaysOpen(TimeZones.NewYork), CreateTradeBarConfig(), new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            manager.CollectionChanged += (sender, args) =>
            {
                if (args.NewItems.OfType<object>().Single() != security)
                {
                    Assert.Fail("Expected args.NewItems to have exactly one element equal to security");
                }
                else
                {
                    Assert.IsTrue(args.Action == NotifyCollectionChangedAction.Add);
                    Assert.Pass();
                }
            };

            manager[security.Symbol] = security;
        }

        [Test]
        public void NotifiesWhenSecurityRemoved()
        {
            var timeKeeper = new TimeKeeper(new DateTime(2015, 12, 07));
            var manager = new SecurityManager(timeKeeper);

            var security = new Security(SecurityExchangeHours.AlwaysOpen(TimeZones.NewYork), CreateTradeBarConfig(), new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency));
            manager.Add(security.Symbol, security);
            manager.CollectionChanged += (sender, args) =>
            {
                if (args.OldItems.OfType<object>().Single() != security)
                {
                    Assert.Fail("Expected args.NewItems to have exactly one element equal to security");
                }
                else
                {
                    Assert.IsTrue(args.Action == NotifyCollectionChangedAction.Remove);
                    Assert.Pass();
                }
            };

            manager.Remove(security.Symbol);
        }

        private SubscriptionDataConfig CreateTradeBarConfig()
        {
            return new SubscriptionDataConfig(typeof (TradeBar), Symbols.SPY, Resolution.Minute, TimeZones.NewYork, TimeZones.NewYork, true, true, false);
        }
    }
}
