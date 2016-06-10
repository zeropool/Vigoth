

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class KaufmanAdaptiveMovingAverageTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new KaufmanAdaptiveMovingAverage(5);
        }

        protected override string TestFileName
        {
            get { return "spy_kama.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "KAMA_5"; }
        }
    }
}
