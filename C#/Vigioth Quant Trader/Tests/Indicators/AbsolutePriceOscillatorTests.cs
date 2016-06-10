

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class AbsolutePriceOscillatorTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new AbsolutePriceOscillator(5, 10);
        }

        protected override string TestFileName
        {
            get { return "spy_apo.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "APO_5_10"; }
        }
    }
}
