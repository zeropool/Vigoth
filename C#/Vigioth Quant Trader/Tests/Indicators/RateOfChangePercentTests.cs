

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class RateOfChangePercentTests
    {
        [Test]
        public void ComputesCorrectly()
        {
            var rocp = new RateOfChangePercent(50); 
            double epsilon = 1e-3;
            TestHelper.TestIndicator(rocp, "spy_with_rocp50.txt", "Rate of Change % 50", (ind, expected) => Assert.AreEqual(expected, (double)ind.Current.Value, epsilon));
        }

        [Test]
        public void ResetsProperly()
        {
            var rocp = new RateOfChangePercent(50);
            foreach (var data in TestHelper.GetDataStream(51))
            {
                rocp.Update(data);
            }
            Assert.IsTrue(rocp.IsReady);

            rocp.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(rocp);
        }
    }
}
