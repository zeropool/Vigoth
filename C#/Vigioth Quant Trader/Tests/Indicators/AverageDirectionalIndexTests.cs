

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class AverageDirectionalIndexTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var adx = new AverageDirectionalIndex("adx", 14);

            const double epsilon = 1;

            TestHelper.TestIndicator(adx, "spy_with_adx.txt", "ADX 14",
                (ind, expected) => Assert.AreEqual(expected, (double)((AverageDirectionalIndex)ind).Current.Value, epsilon)
            );
        }

        [Test]
        public void ComparesAgainstExternalDataAfterReset()
        {
            var adx = new AverageDirectionalIndex("adx", 14);

            const double epsilon = 1;

            TestHelper.TestIndicator(adx, "spy_with_adx.txt", "ADX 14",
                (ind, expected) => Assert.AreEqual(expected, (double)((AverageDirectionalIndex)ind).Current.Value, epsilon));
            adx.Reset();
            TestHelper.TestIndicator(adx, "spy_with_adx.txt", "ADX 14",
                (ind, expected) => Assert.AreEqual(expected, (double)((AverageDirectionalIndex)ind).Current.Value, epsilon));
        }

        [Test]
        public void ResetsProperly()
        {
            var adxIndicator = new AverageDirectionalIndex("ADX", 14);
            foreach (var data in TestHelper.GetTradeBarStream("spy_with_adx.txt", false))
            {
                adxIndicator.Update(data);
            }

            Assert.IsTrue(adxIndicator.IsReady);

            adxIndicator.Reset();
        }
    }
}
