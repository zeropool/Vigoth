

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class VarianceTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new Variance(10);
        }

        protected override string TestFileName
        {
            get { return "spy_var.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "Var"; }
        }
    }
}
