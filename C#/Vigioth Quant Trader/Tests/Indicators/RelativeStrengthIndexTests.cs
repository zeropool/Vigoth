

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class RelativeStrengthIndexTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var rsi = new RelativeStrengthIndex("rsi", 14, MovingAverageType.Simple);
            TestHelper.TestIndicator(rsi, "RSI 14");
        }

        [Test]
        public void ResetsProperly()
        {
            var rsi = new RelativeStrengthIndex(2);
            rsi.Update(DateTime.Today, 1m);
            rsi.Update(DateTime.Today.AddSeconds(1), 2m);
            Assert.IsFalse(rsi.IsReady);

            rsi.Reset();
            TestHelper.AssertIndicatorIsInDefaultState(rsi);
            TestHelper.AssertIndicatorIsInDefaultState(rsi.AverageGain);
            TestHelper.AssertIndicatorIsInDefaultState(rsi.AverageLoss);
        }
    }
}
