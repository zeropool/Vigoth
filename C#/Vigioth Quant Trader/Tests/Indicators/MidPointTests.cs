

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MidPointTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new MidPoint(5);
        }

        protected override string TestFileName
        {
            get { return "spy_midpoint.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "MIDPOINT_5"; }
        }
    }
}
