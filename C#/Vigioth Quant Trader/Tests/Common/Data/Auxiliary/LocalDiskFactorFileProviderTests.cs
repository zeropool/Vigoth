

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Auxiliary;

namespace VigiothCapital.QuantTrader.Tests.Common.Data.Auxiliary
{
    [TestFixture]
    public class LocalDiskFactorFileProviderTests
    {
        [Test]
        public void RetrievesFromDisk()
        {
            var provider = new LocalDiskFactorFileProvider();
            var factorFile = provider.Get(Symbols.SPY);
            Assert.IsNotNull(factorFile);
        }

        [Test]
        public void CachesValueAndReturnsSameReference()
        {
            var provider = new LocalDiskFactorFileProvider();
            var factorFile1 = provider.Get(Symbols.SPY);
            var factorFile2 = provider.Get(Symbols.SPY);
            Assert.IsTrue(ReferenceEquals(factorFile1, factorFile2));
        }

        [Test]
        public void ReturnsNullForNotFound()
        {
            var provider = new LocalDiskFactorFileProvider();
            var factorFile = provider.Get(Symbol.Create("not - a - ticker", SecurityType.Equity, VigiothCapital.QuantTrader.Market.USA));
            Assert.IsNull(factorFile);
        }
    }
}