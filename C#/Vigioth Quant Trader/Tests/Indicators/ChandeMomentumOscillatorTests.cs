

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class ChandeMomentumOscillatorTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var cmo = new ChandeMomentumOscillator("CMO", 5);

            TestIndicator(cmo);
        }

        [Test]
        public void ComparesAgainstExternalDataAfterReset()
        {
            var cmo = new ChandeMomentumOscillator("CMO", 5);

            TestIndicator(cmo);
            cmo.Reset();
            TestIndicator(cmo);
        }

        [Test]
        public void ResetsProperly()
        {
            var cmo = new ChandeMomentumOscillator("CMO", 5);

            TestHelper.TestIndicatorReset(cmo, "spy_cmo.txt");
        }

        private static void TestIndicator(ChandeMomentumOscillator cmo)
        {
            TestHelper.TestIndicator(cmo, "spy_cmo.txt", "CMO_5", (ind, expected) => Assert.AreEqual(expected, (double)ind.Current.Value, 1e-3));
        }
    }
}
