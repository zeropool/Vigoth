

using System;
using NUnit.Framework;

namespace VigiothCapital.QuantTrader.Tests.Common
{
    [TestFixture]
    public class TimeKeeperTests
    {
        [Test]
        public void ConstructsLocalTimeKeepers()
        {
            var reference = new DateTime(2000, 01, 01);
            var timeKeeper = new TimeKeeper(reference, new[] { TimeZones.NewYork });
            Assert.IsNotNull(timeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
        }

        [Test]
        public void TimeKeeperReportsUpdatedLocalTimes()
        {
            var reference = new DateTime(2000, 01, 01);
            var timeKeeper = new TimeKeeper(reference, new[] { TimeZones.NewYork });
            var localTime = timeKeeper.GetTimeIn(TimeZones.NewYork);

            timeKeeper.SetUtcDateTime(reference.AddDays(1));

            Assert.AreEqual(localTime.AddDays(1), timeKeeper.GetTimeIn(TimeZones.NewYork));

            timeKeeper.SetUtcDateTime(reference.AddDays(2));

            Assert.AreEqual(localTime.AddDays(2), timeKeeper.GetTimeIn(TimeZones.NewYork));
        }

        [Test]
        public void LocalTimeKeepersGetTimeUpdates()
        {
            var reference = new DateTime(2000, 01, 01);
            var timeKeeper = new TimeKeeper(reference, new[] { TimeZones.NewYork });
            var localTimeKeeper = timeKeeper.GetLocalTimeKeeper(TimeZones.NewYork);
            var localTime = localTimeKeeper.LocalTime;

            timeKeeper.SetUtcDateTime(reference.AddDays(1));

            Assert.AreEqual(localTime.AddDays(1), localTimeKeeper.LocalTime);

            timeKeeper.SetUtcDateTime(reference.AddDays(2));

            Assert.AreEqual(localTime.AddDays(2), localTimeKeeper.LocalTime);
        }

        [Test]
        public void AddingDuplicateTimeZoneDoesntAdd()
        {
            var reference = new DateTime(2000, 01, 01);
            var timeKeeper = new TimeKeeper(reference, new[] { TimeZones.NewYork });
            var localTimeKeeper = timeKeeper.GetLocalTimeKeeper(TimeZones.NewYork);

            timeKeeper.AddTimeZone(TimeZones.NewYork);

            Assert.AreEqual(localTimeKeeper, timeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));
        }
    }
}
