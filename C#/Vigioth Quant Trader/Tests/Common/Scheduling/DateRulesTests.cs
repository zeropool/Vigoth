

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
    public class DateRulesTests
    {
        [Test]
        public void EveryDayDateRuleEmitsEveryDay()
        {
            var rules = GetDateRules();
            var rule = rules.EveryDay();
            var dates = rule.GetDates(new DateTime(2000, 01, 01), new DateTime(2000, 12, 31));

            int count = 0;
            DateTime previous = DateTime.MinValue;
            foreach (var date in dates)
            {
                count++;
                if (previous != DateTime.MinValue)
                {
                    Assert.AreEqual(Time.OneDay, date - previous);
                }
                previous = date;
            }
            // leap year
            Assert.AreEqual(366, count);
        }

        [Test]
        public void EverySymbolDayRuleEmitsOnTradeableDates()
        {
            var rules = GetDateRules();
            var rule = rules.EveryDay(Symbols.SPY);
            var dates = rule.GetDates(new DateTime(2000, 01, 01), new DateTime(2000, 12, 31));

            int count = 0;
            foreach (var date in dates)
            {
                count++;
                Assert.AreNotEqual(DayOfWeek.Saturday, date.DayOfWeek);
                Assert.AreNotEqual(DayOfWeek.Sunday, date.DayOfWeek);
            }

            Assert.AreEqual(252, count);
        }

        [Test]
        public void StartOfMonthNoSymbol()
        {
            var rules = GetDateRules();
            var rule = rules.MonthStart();
            var dates = rule.GetDates(new DateTime(2000, 01, 01), new DateTime(2000, 12, 31));

            int count = 0;
            foreach (var date in dates)
            {
                count++;
                Assert.AreEqual(1, date.Day);
            }

            Assert.AreEqual(12, count);
        }

        [Test]
        public void StartOfMonthNoSymbolMidMonthStart()
        {
            var rules = GetDateRules();
            var rule = rules.MonthStart();
            var dates = rule.GetDates(new DateTime(2000, 01, 04), new DateTime(2000, 12, 31));

            int count = 0;
            foreach (var date in dates)
            {
                count++;
                Assert.AreEqual(1, date.Day);
            }

            Assert.AreEqual(11, count);
        }

        [Test]
        public void StartOfMonthWithSymbol()
        {
            var rules = GetDateRules();
            var rule = rules.MonthStart(Symbols.SPY);
            var dates = rule.GetDates(new DateTime(2000, 01, 01), new DateTime(2000, 12, 31));

            int count = 0;
            foreach (var date in dates)
            {
                count++;
                Assert.AreNotEqual(DayOfWeek.Saturday, date.DayOfWeek);
                Assert.AreNotEqual(DayOfWeek.Sunday, date.DayOfWeek);
                Assert.IsTrue(date.Day <= 3);
                Console.WriteLine(date.Day);
            }

            Assert.AreEqual(12, count);
        }

        [Test]
        public void StartOfMonthWithSymbolMidMonthStart()
        {
            var rules = GetDateRules();
            var rule = rules.MonthStart(Symbols.SPY);
            var dates = rule.GetDates(new DateTime(2000, 01, 04), new DateTime(2000, 12, 31));

            int count = 0;
            foreach (var date in dates)
            {
                count++;
                Assert.AreNotEqual(DayOfWeek.Saturday, date.DayOfWeek);
                Assert.AreNotEqual(DayOfWeek.Sunday, date.DayOfWeek);
                Assert.IsTrue(date.Day <= 3);
                Console.WriteLine(date.Day);
            }

            Assert.AreEqual(11, count);
        }

        private static DateRules GetDateRules()
        {
            var timeKeeper = new TimeKeeper(DateTime.Today, new List<DateTimeZone>());
            var manager = new SecurityManager(timeKeeper);
            var securityExchangeHours = MarketHoursDatabase.FromDataFolder().GetExchangeHours(Market.USA, null, SecurityType.Equity);
            var config = new SubscriptionDataConfig(typeof(TradeBar), Symbols.SPY, Resolution.Daily, TimeZones.NewYork, TimeZones.NewYork, true, false, false);
            manager.Add(Symbols.SPY, new Security(securityExchangeHours, config, new Cash(CashBook.AccountCurrency, 0, 1m), SymbolProperties.GetDefault(CashBook.AccountCurrency)));
            var rules = new DateRules(manager);
            return rules;
        }
    }
}
