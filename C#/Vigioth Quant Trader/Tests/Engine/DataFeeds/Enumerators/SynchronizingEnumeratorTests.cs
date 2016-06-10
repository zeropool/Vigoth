

using System;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Enumerators
{
    [TestFixture]
    public class SynchronizingEnumeratorTests
    {
        [Test]
        public void SynchronizesData()
        {
            var time = new DateTime(2016, 03, 03, 12, 05, 00);
            var stream1 = Enumerable.Range(0, 10).Select(x => new Tick {Time = time.AddSeconds(1)}).GetEnumerator();
            var stream2 = Enumerable.Range(0, 5).Select(x => new Tick {Time = time.AddSeconds(2)}).GetEnumerator();
            var stream3 = Enumerable.Range(0, 20).Select(x => new Tick {Time = time.AddSeconds(0.5)}).GetEnumerator();

            var previous = DateTime.MinValue;
            var synchronizer = new SynchronizingEnumerator(stream1, stream2, stream3);
            while (synchronizer.MoveNext())
            {
                Assert.That(synchronizer.Current.EndTime, Is.GreaterThanOrEqualTo(previous));
                previous = synchronizer.Current.EndTime;
            }
        }
    }
}
