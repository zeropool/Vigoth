

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class WilliamsPercentRTests
    {
        [Test]
        public void ComputesCorrectly()
        {
            var wilr = new WilliamsPercentR(14);
            TestHelper.TestIndicator(wilr, "spy_with_williamsR14.txt", "Williams %R 14", (ind, expected) => Assert.AreEqual(expected, (double) ind.Current.Value, 1e-3));
        }

        [Test]
        public void ResetsProperly()
        {
            var wilr = new WilliamsPercentR(14);
            foreach (var data in TestHelper.GetTradeBarStream("spy_with_williamsR14.txt", false))
            {
                wilr.Update(data);
            }
            Assert.IsTrue(wilr.IsReady);

            wilr.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(wilr);
        }
    }
}
