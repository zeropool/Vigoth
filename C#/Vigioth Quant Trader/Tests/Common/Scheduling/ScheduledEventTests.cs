

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Scheduling;

namespace VigiothCapital.QuantTrader.Tests.Common.Scheduling
{
    [TestFixture]
    public class ScheduledEventTests
    {
        [Test]
        public void FiresEventOnTime()
        {
            var fired = false;
            var time = new DateTime(2015, 08, 11, 10, 30, 0);
            var sevent = new ScheduledEvent("test", time, (n, t) => fired = true);
            sevent.Scan(time);
            Assert.IsTrue(fired);
        }

        [Test]
        public void NextEventTimeIsMaxValueWhenNoEvents()
        {
            var sevent = new ScheduledEvent("test", new DateTime[0], (n, t) => { });
            Assert.AreEqual(DateTime.MaxValue, sevent.NextEventUtcTime);
        }

        [Test]
        public void NextEventTimeIsMaxValueWhenNoMoreEvents()
        {
            var time = new DateTime(2015, 08, 11, 10, 30, 0);
            var sevent = new ScheduledEvent("test", time, (n, t) => { });
            sevent.Scan(time);
            Assert.AreEqual(DateTime.MaxValue, sevent.NextEventUtcTime);
        }

        [Test]
        public void FiresSkippedEventsInSameCallToScan()
        {
            int count = 0;
            var time = new DateTime(2015, 08, 11, 10, 30, 0);
            var sevent = new ScheduledEvent("test", new[] { time.AddSeconds(-2), time.AddSeconds(-1), time}, (n, t) => count++);
            sevent.Scan(time);
            Assert.AreEqual(3, count);
        }

        [Test]
        public void SkipsEventsUntilTime()
        {
            int count = 0;
            var time = new DateTime(2015, 08, 11, 10, 30, 0);
            var sevent = new ScheduledEvent("test", new[] { time.AddSeconds(-2), time.AddSeconds(-1), time }, (n, t) => count++);
            // skips all preceding events, not including the specified time
            sevent.SkipEventsUntil(time);
            Assert.AreEqual(time, sevent.NextEventUtcTime);
        }
    }
}
