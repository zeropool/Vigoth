

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class ParabolicStopAndReverseTests
    {
        [Test]
        public void ComparesWithExternalData()
        {
            var psar = new ParabolicStopAndReverse();
            TestHelper.TestIndicator(psar, "spy_parabolic_SAR.txt", "Parabolic SAR 0.02 0.20");
        }

        [Test]
        public void ResetsProperly()
        {
            var psar = new ParabolicStopAndReverse();

            TestHelper.TestIndicatorReset(psar, "spy_parabolic_SAR.txt");
        }
    }
}