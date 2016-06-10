

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Auxiliary;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Enumerators
{
    [TestFixture]
    public class OptionChainUniverseDataCollectionAggregatorEnumeratorTests
    {
        [Test]
        public void StoresZipEntryNamesInDataCollection()
        {
            Console.WriteLine(new DateTime().Ticks);
            Console.WriteLine(DateTime.MinValue.Ticks);
            var list = new List<BaseData>
            {
                new Tick(),
                new Tick(),
                new ZipEntryName(),
                new ZipEntryName(),
                new Tick()
            };

            var aggregator = new OptionChainUniverseDataCollectionAggregatorEnumerator(list.GetEnumerator(), Symbols.SPY);

            Assert.IsTrue(aggregator.MoveNext());
            Assert.IsNotNull(aggregator.Current);
            Assert.AreEqual(2, aggregator.Current.Data.Count);
            Assert.IsTrue(aggregator.Current.Data.All(x => x is ZipEntryName));
            Assert.AreEqual(list.Last(), aggregator.Current.Underlying);
        }
    }
}