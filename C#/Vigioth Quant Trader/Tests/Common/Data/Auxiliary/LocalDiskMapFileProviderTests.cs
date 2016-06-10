

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Auxiliary;

namespace VigiothCapital.QuantTrader.Tests.Common.Data.Auxiliary
{
    [TestFixture]
    public class LocalDiskMapFileProviderTests
    {
        [Test]
        public void RetrievesFromDisk()
        {
            var provider = new LocalDiskMapFileProvider();
            var mapFiles = provider.Get(VigiothCapital.QuantTrader.Market.USA);
            Assert.IsNotEmpty(mapFiles);
        }

        [Test]
        public void CachesValueAndReturnsSameReference()
        {
            var provider = new LocalDiskMapFileProvider();
            var mapFiles1 = provider.Get(VigiothCapital.QuantTrader.Market.USA);
            var mapFiles2 = provider.Get(VigiothCapital.QuantTrader.Market.USA);
            Assert.IsTrue(ReferenceEquals(mapFiles1, mapFiles2));
        }
    }
}
