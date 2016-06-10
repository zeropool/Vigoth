

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Common.Data.Market
{
    [TestFixture]
    public class TradeBarTests
    {
        [Test]
        public void UpdatesProperly()
        {
            var bar = new TradeBar();
            bar.UpdateTrade(10, 10);
            Assert.AreEqual(10, bar.Open);
            Assert.AreEqual(10, bar.High);
            Assert.AreEqual(10, bar.Low);
            Assert.AreEqual(10, bar.Close);
            Assert.AreEqual(10, bar.Volume);

            bar.UpdateTrade(20, 5);
            Assert.AreEqual(10, bar.Open);
            Assert.AreEqual(20, bar.High);
            Assert.AreEqual(10, bar.Low);
            Assert.AreEqual(20, bar.Close);
            Assert.AreEqual(15, bar.Volume);

            bar.UpdateTrade(5, 50);
            Assert.AreEqual(10, bar.Open);
            Assert.AreEqual(20, bar.High);
            Assert.AreEqual(5, bar.Low);
            Assert.AreEqual(5, bar.Close);
            Assert.AreEqual(65, bar.Volume);

            bar.UpdateTrade(11, 100);
            Assert.AreEqual(10, bar.Open);
            Assert.AreEqual(20, bar.High);
            Assert.AreEqual(5, bar.Low);
            Assert.AreEqual(11, bar.Close);
            Assert.AreEqual(165, bar.Volume);
        }

        [Test]
        public void HandlesAssetWithValidZeroPrice()
        {
            var bar = new TradeBar();
            bar.UpdateTrade(10, 10);
            Assert.AreEqual(10, bar.Open);
            Assert.AreEqual(10, bar.High);
            Assert.AreEqual(10, bar.Low);
            Assert.AreEqual(10, bar.Close);
            Assert.AreEqual(10, bar.Volume);

            bar.UpdateTrade(0, 100);
            Assert.AreEqual(10, bar.Open);
            Assert.AreEqual(10, bar.High);
            Assert.AreEqual(0, bar.Low);
            Assert.AreEqual(0, bar.Close);
            Assert.AreEqual(110, bar.Volume);

            bar.UpdateTrade(-5, 100);
            Assert.AreEqual(10, bar.Open);
            Assert.AreEqual(10, bar.High);
            Assert.AreEqual(-5, bar.Low);
            Assert.AreEqual(-5, bar.Close);
            Assert.AreEqual(210, bar.Volume);

            bar.UpdateTrade(5, 100);
            Assert.AreEqual(10, bar.Open);
            Assert.AreEqual(10, bar.High);
            Assert.AreEqual(-5, bar.Low);
            Assert.AreEqual(5, bar.Close);
            Assert.AreEqual(310, bar.Volume);

            bar.UpdateTrade(50, 100);
            Assert.AreEqual(10, bar.Open);
            Assert.AreEqual(50, bar.High);
            Assert.AreEqual(-5, bar.Low);
            Assert.AreEqual(50, bar.Close);
            Assert.AreEqual(410, bar.Volume);
        }
    }
}
