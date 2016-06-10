

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class LocalMarketHoursTests
    {
        private static readonly TimeSpan USEquityOpen = new TimeSpan(9, 30, 0);
        private static readonly TimeSpan USEquityClose = new TimeSpan(16, 0, 0);

        [Test]
        public void StartIsOpen()
        {
            var marketHours = GetUsEquityWeekDayMarketHours();

            // EDT is +4 or +5 depending on time of year, in june it's +4, so this is 530 edt
            Assert.IsTrue(marketHours.IsOpen(USEquityOpen, false));
        }

        [Test]
        public void EndIsClosed()
        {
            var marketHours = GetUsEquityWeekDayMarketHours();

            // EDT is +4 or +5 depending on time of year, in june it's +4, so this is 530 edt
            Assert.IsFalse(marketHours.IsOpen(USEquityClose, false));
        }

        [Test]
        public void IsOpenRangeAnyOverlap()
        {
            var marketHours = GetUsEquityWeekDayMarketHours();

            // EDT is +4 or +5 depending on time of year, in june it's +4, so this is 530 edt
            var startTime = new TimeSpan(9, 00, 0);
            var endTime = new TimeSpan(10, 00, 0);
            Assert.IsTrue(marketHours.IsOpen(startTime, endTime, false));
        }

        private static LocalMarketHours GetUsEquityWeekDayMarketHours()
        {
            return new LocalMarketHours(DayOfWeek.Friday, USEquityOpen, USEquityClose);
        }
    }
}
