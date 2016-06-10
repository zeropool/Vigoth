

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class RateOfChangeRatioTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new RateOfChangeRatio(5);
        }

        protected override string TestFileName
        {
            get { return "spy_rocr.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "ROCR_5"; }
        }
    }
}
