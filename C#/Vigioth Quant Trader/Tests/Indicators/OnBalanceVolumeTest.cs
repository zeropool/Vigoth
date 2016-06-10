

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class OnBalanceVolumeTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var onBalanceVolumeIndicator = new OnBalanceVolume("OBV");

            TestHelper.TestIndicator(onBalanceVolumeIndicator, "spy_with_obv.txt", "OBV",
                (ind, expected) => Assert.AreEqual(
                    expected.ToString("0.##E-00"),
                    (onBalanceVolumeIndicator.Current.Value).ToString("0.##E-00")
                    )
                );
        }

        [Test]
        public void ResetsProperly()
        {
            var onBalanceVolumeIndicator = new OnBalanceVolume("OBV");
            foreach (var data in TestHelper.GetTradeBarStream("spy_with_obv.txt", false))
            {
                onBalanceVolumeIndicator.Update(data);
            }

            Assert.IsTrue(onBalanceVolumeIndicator.IsReady);

            onBalanceVolumeIndicator.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(onBalanceVolumeIndicator);
        }
    }
}
