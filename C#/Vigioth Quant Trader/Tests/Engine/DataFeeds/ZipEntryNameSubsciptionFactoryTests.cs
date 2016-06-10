

using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Auxiliary;
using VigiothCapital.QuantTrader.Engine.DataFeeds;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds
{
    [TestFixture]
    public class ZipEntryNameSubsciptionFactoryTests
    {
        [Test]
        public void ReadsZipEntryNames()
        {
            var time = new DateTime(2016, 03, 03, 12, 48, 15);
            var source = Path.Combine("TestData", "20151224_quote_american.zip");
            var config = new SubscriptionDataConfig(typeof (ZipEntryName), Symbol.Create("XLRE", SecurityType.Option, Market.USA), Resolution.Tick,
                TimeZones.NewYork, TimeZones.NewYork, false, false, false);
            var factory = new ZipEntryNameSubscriptionFactory(config, time, false);
            var expected = new[]
            {
                Symbol.CreateOption("XLRE", Market.USA, OptionStyle.American, OptionRight.Call, 21m, new DateTime(2016, 08, 19)),
                Symbol.CreateOption("XLRE", Market.USA, OptionStyle.American, OptionRight.Call, 22m, new DateTime(2016, 08, 19)),
                Symbol.CreateOption("XLRE", Market.USA, OptionStyle.American, OptionRight.Put, 37m, new DateTime(2016, 08, 19)),
            };

            var actual = factory.Read(new SubscriptionDataSource(source, SubscriptionTransportMedium.LocalFile, FileFormat.ZipEntryName)).ToList();

            // we only really care about the symbols
            CollectionAssert.AreEqual(expected, actual.Select(x => x.Symbol));
            Assert.IsTrue(actual.All(x => x is ZipEntryName));
        }
    }
}
