

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class FractalAdaptiveMovingAverageTests
    {

        [Test]
        public void ResetsProperly()
        {

            FractalAdaptiveMovingAverage frama = new FractalAdaptiveMovingAverage("", 6, 198);

            foreach (var data in TestHelper.GetDataStream(7))
            {
                frama.Update(new TradeBar { High = data, Low = data });
            }
            Assert.IsTrue(frama.IsReady);
            Assert.AreNotEqual(0m, frama.Current.Value);
            Assert.AreNotEqual(0, frama.Samples);

            frama.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(frama);
        }

        [Test]
        public void ComparesAgainstExternalData()
        {
            var indicator = new FractalAdaptiveMovingAverage("", 16, 198);
            RunTestIndicator(indicator);
        }

        private static void RunTestIndicator(TradeBarIndicator indicator)
        {
            TestHelper.TestIndicator(indicator, "frama.txt", "Filt", (actual, expected) => {AssertResult(expected, actual.Current.Value);});
        }

        private static void AssertResult(double expected, decimal actual)
        {
            Assert.IsTrue(Math.Abs((decimal)expected - actual) < 0.006m);
        }

    }
}
