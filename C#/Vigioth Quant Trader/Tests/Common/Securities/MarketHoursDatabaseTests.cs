

using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class MarketHoursDatabaseTests
    {
        [Test]
        public void InitializesFromFile()
        {
            string file = Path.Combine("TestData", "SampleMarketHoursDatabase.json");
            var exchangeHours = GetMarketHoursDatabase(file);

            Assert.AreEqual(2, exchangeHours.ExchangeHoursListing.Count);
        }

        [Test]
        public void RetrievesExchangeHoursWithAndWithoutSymbol()
        {
            string file = Path.Combine("TestData", "SampleMarketHoursDatabase.json");
            var exchangeHours = GetMarketHoursDatabase(file);

            var hours = exchangeHours.GetExchangeHours(Market.USA, Symbols.SPY, SecurityType.Equity);
            Assert.IsNotNull(hours);

            Assert.AreEqual(hours, exchangeHours.GetExchangeHours(Market.USA, null, SecurityType.Equity));
        }

        [Test]
        public void CorrectlyReadsClosedAllDayHours()
        {
            string file = Path.Combine("TestData", "SampleMarketHoursDatabase.json");
            var exchangeHours = GetMarketHoursDatabase(file);

            var hours = exchangeHours.GetExchangeHours(Market.USA, null, SecurityType.Equity);
            Assert.IsNotNull(hours);

            Assert.IsTrue(hours.MarketHours[DayOfWeek.Saturday].IsClosedAllDay);
        }

        [Test]
        public void CorrectlyReadsOpenAllDayHours()
        {
            string file = Path.Combine("TestData", "SampleMarketHoursDatabase.json");
            var exchangeHours = GetMarketHoursDatabase(file);

            var hours = exchangeHours.GetExchangeHours(Market.FXCM, null, SecurityType.Forex);
            Assert.IsNotNull(hours);

            Assert.IsTrue(hours.MarketHours[DayOfWeek.Monday].IsOpenAllDay);
        }

        [Test]
        public void InitializesFromDataFolder()
        {
            var provider = MarketHoursDatabase.FromDataFolder();
            Assert.AreNotEqual(0, provider.ExchangeHoursListing.Count);
        }

        [Test]
        public void CorrectlyReadsUsEquityMarketHours()
        {
            string file = Path.Combine("TestData", "SampleMarketHoursDatabase.json");
            var exchangeHours = GetMarketHoursDatabase(file);

            var equityHours = exchangeHours.GetExchangeHours(Market.USA, null, SecurityType.Equity);
            foreach (var day in equityHours.MarketHours.Keys)
            {
                var marketHours = equityHours.MarketHours[day];
                if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
                {
                    Assert.IsTrue(marketHours.IsClosedAllDay);
                    continue;
                }
                Assert.AreEqual(new TimeSpan(4, 0, 0), marketHours.GetMarketOpen(TimeSpan.Zero, true));
                Assert.AreEqual(new TimeSpan(9, 30, 0), marketHours.GetMarketOpen(TimeSpan.Zero, false));
                Assert.AreEqual(new TimeSpan(16, 0, 0), marketHours.GetMarketClose(TimeSpan.Zero, false));
                Assert.AreEqual(new TimeSpan(20, 0, 0), marketHours.GetMarketClose(TimeSpan.Zero, true));
            }
        }

        [Test]
        public void CorrectlyReadFxcmForexMarketHours()
        {
            string file = Path.Combine("TestData", "SampleMarketHoursDatabase.json");
            var exchangeHours = GetMarketHoursDatabase(file);

            var equityHours = exchangeHours.GetExchangeHours(Market.FXCM, null, SecurityType.Forex);
            foreach (var day in equityHours.MarketHours.Keys)
            {
                var marketHours = equityHours.MarketHours[day];
                if (day == DayOfWeek.Saturday)
                {
                    Assert.IsTrue(marketHours.IsClosedAllDay);
                }
                else if (day != DayOfWeek.Sunday && day != DayOfWeek.Friday)
                {
                    Assert.IsTrue(marketHours.IsOpenAllDay);
                }
                else if (day == DayOfWeek.Sunday)
                {
                    Assert.AreEqual(new TimeSpan(17, 0, 0), marketHours.GetMarketOpen(TimeSpan.Zero, true));
                    Assert.AreEqual(new TimeSpan(17, 0, 0), marketHours.GetMarketOpen(TimeSpan.Zero, false));
                    Assert.AreEqual(new TimeSpan(24, 0, 0), marketHours.GetMarketClose(TimeSpan.Zero, false));
                    Assert.AreEqual(new TimeSpan(24, 0, 0), marketHours.GetMarketClose(TimeSpan.Zero, true));
                }
                else
                {
                    Assert.AreEqual(new TimeSpan(0, 0, 0), marketHours.GetMarketOpen(TimeSpan.Zero, true));
                    Assert.AreEqual(new TimeSpan(0, 0, 0), marketHours.GetMarketOpen(TimeSpan.Zero, false));
                    Assert.AreEqual(new TimeSpan(17, 0, 0), marketHours.GetMarketClose(TimeSpan.Zero, false));
                    Assert.AreEqual(new TimeSpan(17, 0, 0), marketHours.GetMarketClose(TimeSpan.Zero, true));
                }
            }
        }

        [Test]
        public void ReadsUsEquityDataTimeZone()
        {
            string file = Path.Combine("TestData", "SampleMarketHoursDatabase.json");
            var marketHoursDatabase = GetMarketHoursDatabase(file);

            Assert.AreEqual(TimeZones.NewYork, marketHoursDatabase.GetDataTimeZone(Market.USA, null, SecurityType.Equity));
        }

        [Test]
        public void ReadsFxcmForexDataTimeZone()
        {
            string file = Path.Combine("TestData", "SampleMarketHoursDatabase.json");
            var marketHoursDatabase = GetMarketHoursDatabase(file);

            Assert.AreEqual(TimeZones.EasternStandard, marketHoursDatabase.GetDataTimeZone(Market.FXCM, null, SecurityType.Forex));
        }

        private static MarketHoursDatabase GetMarketHoursDatabase(string file)
        {
            return MarketHoursDatabase.FromFile(file);
        }
    }
}
