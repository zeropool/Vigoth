

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class TripleExponentialMovingAverageTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new TripleExponentialMovingAverage(5);
        }

        protected override string TestFileName
        {
            get { return "spy_tema.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "TEMA_5"; }
        }
    }
}
