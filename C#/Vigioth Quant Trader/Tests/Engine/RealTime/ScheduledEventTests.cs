

using System;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Scheduling;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Engine.RealTime
{
    [TestFixture]
    public class ScheduledEventTests
    {
        [Test]
        public void FiresEventWhenTimeEquals()
        {
            var triggered = false;
            var se = new ScheduledEvent("test", new DateTime(2015, 08, 07), (name, triggerTime) =>
            {
                triggered = true;
            });
            se.IsLoggingEnabled = true;

            se.Scan(new DateTime(2015, 08, 06));
            Assert.IsFalse(triggered);

            se.Scan(new DateTime(2015, 08, 07));
            Assert.IsTrue(triggered);
        }

        [Test]
        public void FiresEventWhenTimePasses()
        {
            var triggered = false;
            var se = new ScheduledEvent("test", new DateTime(2015, 08, 07), (name, triggerTime) =>
            {
                triggered = true;
            });
            se.IsLoggingEnabled = true;

            se.Scan(new DateTime(2015, 08, 06));
            Assert.IsFalse(triggered);

            se.Scan(new DateTime(2015, 08, 08));
            Assert.IsTrue(triggered);
        }

        [Test]
        public void SchedulesNextEvent()
        {
            var first = new DateTime(2015, 08, 07);
            var second = new DateTime(2015, 08, 08);
            var dates = new[] { first, second }.ToHashSet();
            var se = new ScheduledEvent("test", dates.ToList(), (name, triggerTime) =>
            {
                dates.Remove(triggerTime);
            });

            se.Scan(first);
            Assert.IsFalse(dates.Contains(first));

            se.Scan(second);
            Assert.IsFalse(dates.Contains(second));
        }

        [Test]
        public void DoesNothingAfterEventsEnd()
        {
            var triggered = false;
            var first = new DateTime(2015, 08, 07);
            var se = new ScheduledEvent("test", first, (name, triggerTime) =>
            {
                triggered = true;
            });

            se.Scan(first);
            Assert.IsTrue(triggered);

            triggered = false;
            se.Scan(first.AddYears(100));
            Assert.IsFalse(triggered);
        }
    }
}
