

using System;
using System.Collections.Generic;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Engine.DataFeeds;
using VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Enumerators
{
    [TestFixture]
    public class FastForwardEnumeratorTests
    {
        [Test]
        public void FastForwardsOldData()
        {
            var start = new DateTime(2015, 10, 10, 13, 0, 0);
            var data = new List<Tick>
            {
                new Tick {Time = start.AddMinutes(-1)},
                new Tick {Time = start.AddSeconds(-1)},
                new Tick {Time = start.AddSeconds(0)},
                new Tick {Time = start.AddSeconds(1)},
            };

            var timeProvider = new ManualTimeProvider(start, TimeZones.Utc);
            var fastForward = new FastForwardEnumerator(data.GetEnumerator(), timeProvider, TimeZones.Utc, TimeSpan.FromSeconds(0.5));

            Assert.IsTrue(fastForward.MoveNext());
            Assert.AreEqual(start, fastForward.Current.Time);
        }
        [Test]
        public void FastForwardsOldDataAllowsEquals()
        {
            var start = new DateTime(2015, 10, 10, 13, 0, 0);
            var data = new List<Tick>
            {
                new Tick {Time = start.AddMinutes(-1)},
                new Tick {Time = start.AddSeconds(-1)},
                new Tick {Time = start.AddSeconds(0)},
                new Tick {Time = start.AddSeconds(1)},
            };

            var timeProvider = new ManualTimeProvider(start, TimeZones.Utc);
            var fastForward = new FastForwardEnumerator(data.GetEnumerator(), timeProvider, TimeZones.Utc, TimeSpan.FromSeconds(1));

            Assert.IsTrue(fastForward.MoveNext());
            Assert.AreEqual(start.AddSeconds(-1), fastForward.Current.Time);
        }
        [Test]
        public void FiltersOutPastData()
        {
            var start = new DateTime(2015, 10, 10, 13, 0, 0);
            var data = new List<Tick>
            {
                new Tick {Time = start.AddMinutes(-1)},
                new Tick {Time = start.AddSeconds(-1)},
                new Tick {Time = start.AddSeconds(1)},
                new Tick {Time = start.AddSeconds(0)},
                new Tick {Time = start.AddSeconds(2)}
            };

            var timeProvider = new ManualTimeProvider(start, TimeZones.Utc);
            var fastForward = new FastForwardEnumerator(data.GetEnumerator(), timeProvider, TimeZones.Utc, TimeSpan.FromSeconds(0.5));

            Assert.IsTrue(fastForward.MoveNext());
            Assert.AreEqual(start.AddSeconds(1), fastForward.Current.Time);

            Assert.IsTrue(fastForward.MoveNext());
            Assert.AreEqual(start.AddSeconds(2), fastForward.Current.Time);
        }
    }
}
