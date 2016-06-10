

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class FisherTransformTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var fisher = new FisherTransform("fisher", 10);
            TestHelper.TestIndicator(fisher, "spy_with_fisher.txt", "Fisher Transform 10",
                (ind, expected) => Assert.AreEqual(expected, (double)((FisherTransform)ind).Current.Value, 1e-3));
        }

        [Test]
        public void ResetsProperly()
        {
            var fisher = new FisherTransform(10);
            //fisher.Update(DateTime.Today, 1m);
            //fisher.Update(DateTime.Today.AddSeconds(1), 2m);
            Assert.IsFalse(fisher.IsReady);

            fisher.Reset();
            TestHelper.AssertIndicatorIsInDefaultState(fisher);
            //TestHelper.AssertIndicatorIsInDefaultState(fisher.AverageGain);
            //TestHelper.AssertIndicatorIsInDefaultState(fisher.AverageLoss);
        }
    }
}
