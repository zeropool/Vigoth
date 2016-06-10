

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class RelativeStandardDeviationVolatilityModelTests
    {
        [Test]
        public void UpdatesAfterCorrectPeriodElapses()
        {
            const int periods = 3;
            var periodSpan = Time.OneMinute;
            var reference = new DateTime(2016, 04, 06, 12, 0, 0);
            var referenceUtc = reference.ConvertToUtc(TimeZones.NewYork);
            var timeKeeper = new TimeKeeper(referenceUtc);
            var config = new SubscriptionDataConfig(typeof (TradeBar), Symbols.SPY, Resolution.Minute, TimeZones.NewYork, TimeZones.NewYork, true, false, false);
            var security = new Security(SecurityExchangeHours.AlwaysOpen(TimeZones.NewYork), config, new Cash("USD", 0, 0), SymbolProperties.GetDefault("USD"));
            security.SetLocalTimeKeeper(timeKeeper.GetLocalTimeKeeper(TimeZones.NewYork));

            var model = new RelativeStandardDeviationVolatilityModel(periodSpan, periods);
            security.VolatilityModel = model;

            var first = new IndicatorDataPoint(reference, 1);
            security.SetMarketPrice(first);

            Assert.AreEqual(0m, model.Volatility);

            const decimal value = 0.471404520791032M; // std of 1,2 is ~0.707 over a mean of 1.5
            var second = new IndicatorDataPoint(reference.AddMinutes(1), 2);
            security.SetMarketPrice(second);
            Assert.AreEqual(value, model.Volatility);

            // update should not be applied since not enough time has passed
            var third = new IndicatorDataPoint(reference.AddMinutes(1.01), 1000);
            security.SetMarketPrice(third);
            Assert.AreEqual(value, model.Volatility);

            var fourth = new IndicatorDataPoint(reference.AddMinutes(2), 3m);
            security.SetMarketPrice(fourth);
            Assert.AreEqual(0.5m, model.Volatility);
        }
    }
}
