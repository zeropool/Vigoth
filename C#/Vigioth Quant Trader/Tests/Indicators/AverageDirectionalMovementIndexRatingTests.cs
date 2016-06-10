

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class AverageDirectionalMovementIndexRatingTests : CommonIndicatorTests<TradeBar>
    {
        protected override IndicatorBase<TradeBar> CreateIndicator()
        {
            return new AverageDirectionalMovementIndexRating(14);
        }

        protected override string TestFileName
        {
            get { return "spy_adxr.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "ADXR_14"; }
        }

        protected override Action<IndicatorBase<TradeBar>, double> Assertion
        {
            get { return (indicator, expected) => Assert.AreEqual(expected, (double)indicator.Current.Value, 1.0); }
        }
    }
}
