

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class RateOfChangeTests
    {
        [Test]
        public void ComputesCorrectly()
        {
            var roc = new RateOfChange(50); 
            double epsilon = 1e-3;
            TestHelper.TestIndicator(roc, "spy_with_rocp50.txt", "Rate of Change % 50", (ind, expected) => Assert.AreEqual(expected, (double)ind.Current.Value * 100, epsilon));
        }

        [Test]
        public void ResetsProperly()
        {
            var roc = new RateOfChange(50);
            foreach (var data in TestHelper.GetDataStream(51))
            {
                roc.Update(data);
            }
            Assert.IsTrue(roc.IsReady);

            roc.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(roc);
        }
    }
}
