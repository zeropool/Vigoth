

using System;
using NUnit.Framework;

namespace VigiothCapital.QuantTrader.Tests.Common
{
    [TestFixture]
    public class TimeZoneOffsetProviderTests
    {
        [Test]
        public void ReturnsCurrentOffset()
        {
            var utcDate = new DateTime(2015, 07, 07);
            var offsetProvider = new TimeZoneOffsetProvider(TimeZones.NewYork, utcDate, utcDate.AddDays(1));
            var currentOffset = offsetProvider.GetOffsetTicks(utcDate);
            Assert.AreEqual(-TimeSpan.FromHours(4).TotalHours, TimeSpan.FromTicks(currentOffset).TotalHours);
        }

        [Test]
        public void ReturnsCorrectOffsetBeforeDST()
        {
            // one tick before DST goes into affect
            var utcDate = new DateTime(2015, 03, 08, 2, 0, 0).AddHours(5).AddTicks(-1);
            var offsetProvider = new TimeZoneOffsetProvider(TimeZones.NewYork, utcDate, utcDate.AddDays(1));
            var currentOffset = offsetProvider.GetOffsetTicks(utcDate);
            Assert.AreEqual(-TimeSpan.FromHours(5).TotalHours, TimeSpan.FromTicks(currentOffset).TotalHours);
        }

        [Test]
        public void ReturnsCorrectOffsetAfterDST()
        {
            // the exact instant DST goes into affect
            var utcDate = new DateTime(2015, 03, 08, 2, 0, 0).AddHours(5);
            var offsetProvider = new TimeZoneOffsetProvider(TimeZones.NewYork, utcDate, utcDate.AddDays(1));
            var currentOffset = offsetProvider.GetOffsetTicks(utcDate);
            Assert.AreEqual(-TimeSpan.FromHours(4).TotalHours, TimeSpan.FromTicks(currentOffset).TotalHours);
        }
    }
}
