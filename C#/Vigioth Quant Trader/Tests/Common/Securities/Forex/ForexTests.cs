﻿

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities.Forex
{
    [TestFixture]
    public class ForexTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException), MatchType = MessageMatch.Contains, ExpectedMessage = "Currency pairs must be exactly 6 characters")]
        public void DecomposeThrowsOnSymbolTooShort()
        {
            string symbol = "12345";
            Assert.AreEqual(5, symbol.Length);
            string basec, quotec;
            VigiothCapital.QuantTrader.Securities.Forex.Forex.DecomposeCurrencyPair(symbol, out basec, out quotec);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), MatchType = MessageMatch.Contains, ExpectedMessage = "Currency pairs must be exactly 6 characters")]
        public void DecomposeThrowsOnSymbolTooLong()
        {
            string symbol = "1234567";
            Assert.AreEqual(7, symbol.Length);
            string basec, quotec;
            VigiothCapital.QuantTrader.Securities.Forex.Forex.DecomposeCurrencyPair(symbol, out basec, out quotec);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), MatchType = MessageMatch.Contains, ExpectedMessage = "Currency pairs must be exactly 6 characters")]
        public void DecomposeThrowsOnNullSymbol()
        {
            string symbol = null;
            string basec, quotec;
            VigiothCapital.QuantTrader.Securities.Forex.Forex.DecomposeCurrencyPair(symbol, out basec, out quotec);
        }

        [Test]
        public void ConstructorDecomposesBaseAndQuoteCurrencies()
        {
            var config = new SubscriptionDataConfig(typeof(TradeBar), Symbols.EURUSD, Resolution.Minute, TimeZones.NewYork, TimeZones.NewYork, true, true, true);
            var forex = new VigiothCapital.QuantTrader.Securities.Forex.Forex(SecurityExchangeHours.AlwaysOpen(config.DataTimeZone), new Cash("usd", 0, 0), config, SymbolProperties.GetDefault("usd"));
            Assert.AreEqual("EUR", forex.BaseCurrencySymbol);
            Assert.AreEqual("USD", forex.QuoteCurrency.Symbol);
        }
    }
}
