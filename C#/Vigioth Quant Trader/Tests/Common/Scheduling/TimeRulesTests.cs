

using System;
using System.Collections.Generic;
using NodaTime;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Scheduling;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Scheduling
{
    [TestFixture]
    public class TimeRulesTests
    {
        [Test]
        public void AtSpecificTimeFromUtc()
        {
            var rules = GetTimeRules(TimeZones.Utc);
            var rule = rules.At(TimeSpan.FromHours(12));
            var times = rule.CreateUtcEventTimes(new[] {new DateTime(2000, 01, 01)});

            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours(12), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void AtSpecificTimeFromNonUtc()
        {
            var rules = GetTimeRules(TimeZones.NewYork);
            var rule = rules.At(TimeSpan.FromHours(12));
            var times = rule.CreateUtcEventTimes(new[] {new DateTime(2000, 01, 01)});

            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours(12+5), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void RegularMarketOpenNoDelta()
        {
            var rules = GetTimeRules(TimeZones.Utc);
            var rule = rules.AfterMarketOpen(Symbols.SPY);
            var times = rule.CreateUtcEventTimes(new[] { new DateTime(2000, 01, 03) });

            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours(9.5 + 5), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void RegularMarketOpenWithDelta()
        {
            var rules = GetTimeRules(TimeZones.Utc);
            var rule = rules.AfterMarketOpen(Symbols.SPY, 30);
            var times = rule.CreateUtcEventTimes(new[] { new DateTime(2000, 01, 03) });

            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours(9.5 + 5 + .5), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void ExtendedMarketOpenNoDelta()
        {
            var rules = GetTimeRules(TimeZones.Utc);
            var rule = rules.AfterMarketOpen(Symbols.SPY, 0, true);
            var times = rule.CreateUtcEventTimes(new[] { new DateTime(2000, 01, 03) });

            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours(4 + 5), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void ExtendedMarketOpenWithDelta()
        {
            var rules = GetTimeRules(TimeZones.Utc);
            var rule = rules.AfterMarketOpen(Symbols.SPY, 30, true);
            var times = rule.CreateUtcEventTimes(new[] { new DateTime(2000, 01, 03) });

            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours(4 + 5 + .5), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void RegularMarketCloseNoDelta()
        {
            var rules = GetTimeRules(TimeZones.Utc);
            var rule = rules.BeforeMarketClose(Symbols.SPY);
            var times = rule.CreateUtcEventTimes(new[] { new DateTime(2000, 01, 03) });

            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours(16 + 5), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void RegularMarketCloseWithDelta()
        {
            var rules = GetTimeRules(TimeZones.Utc);
            var rule = rules.BeforeMarketClose(Symbols.SPY, 30);
            var times = rule.CreateUtcEventTimes(new[] { new DateTime(2000, 01, 03) });

            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours(16 + 5 - .5), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void ExtendedMarketCloseNoDelta()
        {
            var rules = GetTimeRules(TimeZones.Utc);
            var rule = rules.BeforeMarketClose(Symbols.SPY, 0, true);
            var times = rule.CreateUtcEventTimes(new[] { new DateTime(2000, 01, 03) });

            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours((20 + 5)%24), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void ExtendedMarketCloseWithDelta()
        {
            var rules = GetTimeRules(TimeZones.Utc);
            var rule = rules.BeforeMarketClose(Symbols.SPY, 30, true);
            var times = rule.CreateUtcEventTimes(new[] { new DateTime(2000, 01, 03) });
            
            int count = 0;
            foreach (var time in times)
            {
                count++;
                Assert.AreEqual(TimeSpan.FromHours((20 + 5 - .5)%24), time.TimeOfDay);
            }
            Assert.AreEqual(1, count);
        }

        private static TimeRules GetTimeRules(DateTimeZone dateTimeZone)
        {
            var timeKeeper = new TimeKeeper(DateTime.Today, new List<DateTimeZone>());
            var manager = new SecurityManager(timeKeeper);
            var marketHourDbEntry = MarketHoursDatabase.FromDataFolder().GetEntry(Market.USA, null, SecurityType.Equity);
            var securityExchangeHours = marketHourDbEntry.ExchangeHours;
            var config = new SubscriptionDataConfig(typeof(TradeBar), Symbols.SPY, Resolution.Daily, marketHourDbEntry.DataTimeZone, securityExchangeHours.TimeZone, true, false, false);
            manager.Add(Symbols.SPY, new Security(securityExchangeHours, config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency)));
            var rules = new TimeRules(manager, dateTimeZone);
            return rules;
        }
    }
}
