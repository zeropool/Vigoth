

using System;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Enumerators
{
    [TestFixture]
    public class BaseDataCollectionAggregatorEnumeratorTests
    {
        [Test]
        public void AggregatesUntilNull()
        {
            var time = new DateTime(2015, 10, 20);
            var underlying = Enumerable.Range(0, 5).Select(x => new Tick { Time = time }).ToList();
            underlying.AddRange(new Tick[] { null, null, null });

            var aggregator = new BaseDataCollectionAggregatorEnumerator(underlying.GetEnumerator(), Symbols.SPY);

            Assert.IsTrue(aggregator.MoveNext());
            Assert.IsNotNull(aggregator.Current);
            Assert.AreEqual(5, aggregator.Current.Data.Count);
        }
        [Test]
        public void AggregatesUntilTimeChange()
        {
            var time = new DateTime(2015, 10, 20);
            var underlying = Enumerable.Range(0, 5).Select(x => new Tick { Time = time }).ToList();
            underlying.AddRange(Enumerable.Range(0, 5).Select(x => new Tick {Time = time.AddSeconds(1)}));

            var aggregator = new BaseDataCollectionAggregatorEnumerator(underlying.GetEnumerator(), Symbols.SPY);

            Assert.IsTrue(aggregator.MoveNext());
            Assert.IsNotNull(aggregator.Current);
            Assert.AreEqual(5, aggregator.Current.Data.Count);
        }
    }
}
