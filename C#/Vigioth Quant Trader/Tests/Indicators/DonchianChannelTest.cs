

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class DonchianChannelTest
    {
        [Test]
        public void CompareAgainstExternalDataForUpperBand()
        {
            var donchianChannel = new DonchianChannel("dch", 50);

            TestHelper.TestIndicator(donchianChannel, "spy_with_don50.txt", "Donchian Channels 50 Top",
                    (ind, expected) => Assert.AreEqual(expected, (double)((DonchianChannel)ind).UpperBand.Current.Value));
        }

        [Test]
        public void CompareAgainstExternalDataForLowerBand()
        {
            var donchianChannel = new DonchianChannel("dch", 50);

            TestHelper.TestIndicator(donchianChannel, "spy_with_don50.txt", "Donchian Channels 50 Bottom",
                    (ind, expected) => Assert.AreEqual(expected, (double)((DonchianChannel)ind).LowerBand.Current.Value));
        }
        
        [Test]
        public void ComputesPrimaryOutputCorrectly()
        {
            var donchianChannel = new DonchianChannel("dch", 50);

            TestHelper.TestIndicator(donchianChannel, "spy_with_don50.txt", "Donchian Channels 50 Mean",
                    (ind, expected) => Assert.AreEqual(expected, (double)((DonchianChannel)ind).Current.Value));

        }

        [Test]
        public void ResetsProperly()
        {
            var donchianChannelIndicator = new DonchianChannel("DCH", 50);
            foreach (var data in TestHelper.GetTradeBarStream("spy_with_don50.txt", false))
            {
                donchianChannelIndicator.Update(data);
            }

            Assert.IsTrue(donchianChannelIndicator.IsReady);
            Assert.IsTrue(donchianChannelIndicator.UpperBand.IsReady);
            Assert.IsTrue(donchianChannelIndicator.LowerBand.IsReady);

            donchianChannelIndicator.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(donchianChannelIndicator);
            TestHelper.AssertIndicatorIsInDefaultState(donchianChannelIndicator.UpperBand);
            TestHelper.AssertIndicatorIsInDefaultState(donchianChannelIndicator.LowerBand);

        }
    }
}
