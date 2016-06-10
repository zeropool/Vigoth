

using System;
using System.Collections.Generic;
using NodaTime;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Engine.DataFeeds;
using VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Enumerators
{
    [TestFixture]
    public class FrontierAwareEnumeratorTests
    {
        [Test]
        public void ReturnsTrueWhenNextDataIsAheadOfFrontier()
        {
            var currentTime = new DateTime(2015, 10, 13);
            var timeProvider = new ManualTimeProvider(currentTime);
            var underlying = new List<Tick>
            {
                new Tick {Time = currentTime.AddSeconds(1)}
            };

            var offsetProvider = new TimeZoneOffsetProvider(DateTimeZone.Utc, new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));
            var frontierAware = new FrontierAwareEnumerator(underlying.GetEnumerator(), timeProvider, offsetProvider);

            Assert.IsTrue(frontierAware.MoveNext());
            Assert.IsNull(frontierAware.Current);
        }

        [Test]
        public void YieldsDataWhenFrontierPasses()
        {
            var currentTime = new DateTime(2015, 10, 13);
            var timeProvider = new ManualTimeProvider(currentTime);
            var underlying = new List<Tick>
            {
                new Tick {Time = currentTime.AddSeconds(1)}
            };

            var offsetProvider = new TimeZoneOffsetProvider(DateTimeZone.Utc, new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));
            var frontierAware = new FrontierAwareEnumerator(underlying.GetEnumerator(), timeProvider, offsetProvider);

            timeProvider.AdvanceSeconds(1);

            Assert.IsTrue(frontierAware.MoveNext());
            Assert.IsNotNull(frontierAware.Current);
            Assert.AreEqual(underlying[0], frontierAware.Current);
        }

        [Test]
        public void YieldsFutureDataAtCorrectTime()
        {
            var currentTime = new DateTime(2015, 10, 13);
            var timeProvider = new ManualTimeProvider(currentTime);
            var underlying = new List<Tick>
            {
                new Tick {Time = currentTime.AddSeconds(10)}
            };

            var offsetProvider = new TimeZoneOffsetProvider(DateTimeZone.Utc, new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));
            var frontierAware = new FrontierAwareEnumerator(underlying.GetEnumerator(), timeProvider, offsetProvider);

            for (int i = 0; i < 10; i++)
            {
                timeProvider.AdvanceSeconds(1);
                Assert.IsTrue(frontierAware.MoveNext());
                if (i < 9)
                {
                    Assert.IsNull(frontierAware.Current);
                }
                else
                {
                    Assert.IsNotNull(frontierAware.Current);
                    Assert.AreEqual(underlying[0], frontierAware.Current);
                }
            }
        }
    }
}
