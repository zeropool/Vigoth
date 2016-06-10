﻿

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities.Cfd
{
    [TestFixture]
    public class CfdTests
    {
        [Test]
        public void ConstructorExtractsQuoteCurrency()
        {
            var symbol = Symbol.Create("DE30EUR", SecurityType.Cfd, Market.Oanda);
            var config = new SubscriptionDataConfig(typeof(TradeBar), symbol, Resolution.Minute, TimeZones.Utc, TimeZones.NewYork, true, true, true);
            var symbolProperties = new SymbolProperties("Dax German index", "EUR", 1, 1);
            var cfd = new VigiothCapital.QuantTrader.Securities.Cfd.Cfd(SecurityExchangeHours.AlwaysOpen(config.DataTimeZone), new Cash("EUR", 0, 0), config, symbolProperties);
            Assert.AreEqual("EUR", cfd.QuoteCurrency.Symbol);
        }

    }
}
