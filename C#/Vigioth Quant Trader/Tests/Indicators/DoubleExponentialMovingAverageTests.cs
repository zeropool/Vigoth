

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class DoubleExponentialMovingAverageTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var dema = new DoubleExponentialMovingAverage("DEMA", 5);

            RunTestIndicator(dema);
        }

        [Test]
        public void ComparesAgainstExternalDataAfterReset()
        {
            var dema = new DoubleExponentialMovingAverage("DEMA", 5);

            RunTestIndicator(dema);
            dema.Reset();
            RunTestIndicator(dema);
        }

        [Test]
        public void ResetsProperly()
        {
            var dema = new DoubleExponentialMovingAverage("DEMA", 5);

            TestHelper.TestIndicatorReset(dema, "spy_dema.txt");
        }

        private static void RunTestIndicator(DoubleExponentialMovingAverage dema)
        {
            TestHelper.TestIndicator(dema, "spy_dema.txt", "DEMA_5", (ind, expected) => Assert.AreEqual(expected, (double)ind.Current.Value, 1e-2));
        }
    }
}
