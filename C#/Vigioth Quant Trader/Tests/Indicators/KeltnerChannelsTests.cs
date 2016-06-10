

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class KeltnerChannelsTests
    {
        [Test]
        public void ComparesWithExtenralDataMiddleBand()
        {
            var kch = new KeltnerChannels(20, 1.5m, MovingAverageType.Simple);
            TestHelper.TestIndicator(kch, "spy_with_keltner.csv", "Middle Band",
                (ind, expected) => Assert.AreEqual(expected, (double)((KeltnerChannels)ind).MiddleBand.Current.Value, 1e-3));
        }

        [Test]
        public void ComparesWithExternalDataUpperBand()
        {
            var kch = new KeltnerChannels(20, 1.5m, MovingAverageType.Simple);
            TestHelper.TestIndicator(kch, "spy_with_keltner.csv", "Keltner Channels 20 Top",
                (ind, expected) => Assert.AreEqual(expected, (double)((KeltnerChannels)ind).UpperBand.Current.Value, 1e-3));
        }

        [Test]
        public void ComparesWithExternalDataLowerBand()
        {
            var kch = new KeltnerChannels(20, 1.5m, MovingAverageType.Simple);
            TestHelper.TestIndicator(kch, "spy_with_keltner.csv", "Keltner Channels 20 Bottom",
                (ind, expected) => Assert.AreEqual(expected, (double)((KeltnerChannels)ind).LowerBand.Current.Value, 1e-3));
        }

        [Test]
        public void ResetsProperly()
        {
            var kch = new KeltnerChannels(20, 1.5m, MovingAverageType.Simple);
            foreach (var data in TestHelper.GetTradeBarStream("spy_with_keltner.csv", false))
            {
               kch.Update(data);
            }

            Assert.IsTrue(kch.IsReady);
            Assert.IsTrue(kch.UpperBand.IsReady);
            Assert.IsTrue(kch.LowerBand.IsReady);
            Assert.IsTrue(kch.MiddleBand.IsReady);
            Assert.IsTrue(kch.AverageTrueRange.IsReady);

            kch.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(kch);
            TestHelper.AssertIndicatorIsInDefaultState(kch.UpperBand);
            TestHelper.AssertIndicatorIsInDefaultState(kch.LowerBand);
            TestHelper.AssertIndicatorIsInDefaultState(kch.AverageTrueRange);
        }
    }
}
