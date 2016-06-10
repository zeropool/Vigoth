

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class BollingerBandsTests
    {
        [Test]
        public void ComparesWithExternalDataMiddleBand()
        {
            var bb = new BollingerBands(20, 2.0m, MovingAverageType.Simple);
            TestHelper.TestIndicator(bb, "spy_bollinger_bands.txt", "Moving Average 20", (BollingerBands ind) => (double)ind.MiddleBand.Current.Value);
        }   

        [Test]
        public void ComparesWithExternalDataUpperBand()
        {
            var bb = new BollingerBands(20, 2.0m, MovingAverageType.Simple);
            TestHelper.TestIndicator(bb, "spy_bollinger_bands.txt", "Bollinger Bands® 20 2 Top", (BollingerBands ind) => (double)ind.UpperBand.Current.Value);
        }           

        [Test]
        public void ComparesWithExternalDataLowerBand()
        {
            var bb = new BollingerBands(20, 2.0m, MovingAverageType.Simple);
            TestHelper.TestIndicator(bb, "spy_bollinger_bands.txt", "Bollinger Bands® 20 2 Bottom", (BollingerBands ind) => (double)ind.LowerBand.Current.Value);
        }

        [Test]
        public void ResetsProperly()
        {
            var bb = new BollingerBands(2, 2m);
            bb.Update(DateTime.Today, 1m);

            Assert.IsFalse(bb.IsReady);
            bb.Update(DateTime.Today.AddSeconds(1), 2m);
            Assert.IsTrue(bb.IsReady);
            Assert.IsTrue(bb.StandardDeviation.IsReady);
            Assert.IsTrue(bb.LowerBand.IsReady);
            Assert.IsTrue(bb.MiddleBand.IsReady);
            Assert.IsTrue(bb.UpperBand.IsReady);

            bb.Reset();
            TestHelper.AssertIndicatorIsInDefaultState(bb);
            TestHelper.AssertIndicatorIsInDefaultState(bb.StandardDeviation);
            TestHelper.AssertIndicatorIsInDefaultState(bb.LowerBand);
            TestHelper.AssertIndicatorIsInDefaultState(bb.MiddleBand);
            TestHelper.AssertIndicatorIsInDefaultState(bb.UpperBand);
        }
    }
}
