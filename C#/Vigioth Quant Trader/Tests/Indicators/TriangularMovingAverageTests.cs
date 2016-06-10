

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class TriangularMovingAverageTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        [Test]
        public override void ComparesAgainstExternalData()
        {
            foreach (var period in new[] {5, 6})
            {
                RunTestIndicator(new TriangularMovingAverage(period), period);
            }
        }

        [Test]
        public override void ComparesAgainstExternalDataAfterReset()
        {
            foreach (var period in new[] { 5, 6 })
            {
                var indicator = new TriangularMovingAverage(period);
                RunTestIndicator(indicator, period);
                indicator.Reset();
                RunTestIndicator(indicator, period);
            }
        }

        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new TriangularMovingAverage(5);
        }

        protected override string TestFileName
        {
            get { return "spy_trima.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "TRIMA"; }
        }

        private void RunTestIndicator(TriangularMovingAverage trima, int period)
        {
            TestHelper.TestIndicator(trima, TestFileName, TestColumnName + "_" + period, Assertion);
        }
    }
}
