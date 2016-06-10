

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class TrixTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new Trix(5);
        }

        protected override string TestFileName
        {
            get { return "spy_trix.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "TRIX_5"; }
        }
    }
}
