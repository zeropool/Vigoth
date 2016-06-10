

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class NormalizedAverageTrueRangeTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var indicator = new NormalizedAverageTrueRange(5);

            RunTestIndicator(indicator);
        }

        [Test]
        public void ComparesAgainstExternalDataAfterReset()
        {
            var indicator = new NormalizedAverageTrueRange(5);

            RunTestIndicator(indicator);
            indicator.Reset();
            RunTestIndicator(indicator);
        }

        [Test]
        public void ResetsProperly()
        {
            var indicator = new NormalizedAverageTrueRange(5);

            TestHelper.TestIndicatorReset(indicator, "spy_natr.txt");
        }

        private static void RunTestIndicator(TradeBarIndicator indicator)
        {
            TestHelper.TestIndicator(indicator, "spy_natr.txt", "NATR_5", (ind, expected) => Assert.AreEqual(expected, (double)ind.Current.Value, 1e-3));
        }
    }
}
