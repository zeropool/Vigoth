

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class T3MovingAverageTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var indicator = new T3MovingAverage(5);

            RunTestIndicator(indicator);
        }

        [Test]
        public void ComparesAgainstExternalDataAfterReset()
        {
            var indicator = new T3MovingAverage(5);

            RunTestIndicator(indicator);
            indicator.Reset();
            RunTestIndicator(indicator);
        }

        [Test]
        public void ResetsProperly()
        {
            var indicator = new T3MovingAverage(5, 1);

            TestHelper.TestIndicatorReset(indicator, "spy_t3.txt");
        }

        private static void RunTestIndicator(IndicatorBase<IndicatorDataPoint> indicator)
        {
            TestHelper.TestIndicator(indicator, "spy_t3.txt", "T3_5", (ind, expected) => Assert.AreEqual(expected, (double)ind.Current.Value, 2e-2));
        }
    }
}
