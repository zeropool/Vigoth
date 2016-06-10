

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MomentumPercentTests
    {
        [Test]
        public void ComputesCorrectly()
        {
            var momp = new MomentumPercent(50);
            double epsilon = 1e-3;
            TestHelper.TestIndicator(momp, "spy_with_rocp50.txt", "Rate of Change % 50", (ind, expected) => Assert.AreEqual(expected, (double)ind.Current.Value, epsilon));
        }

        [Test]
        public void ResetsProperly()
        {
            var momp = new MomentumPercent(50);
            foreach (var data in TestHelper.GetDataStream(51))
            {
                momp.Update(data);
            }
            Assert.IsTrue(momp.IsReady);

            momp.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(momp);
        }
    }
}