

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Brokerages.Fxcm;

namespace VigiothCapital.QuantTrader.Tests.Brokerages.Fxcm
{
    [TestFixture]
    public class FxcmSymbolMapperTests
    {
        [Test]
        public void ReturnsCorrectLeanSymbol()
        {
            var mapper = new FxcmSymbolMapper();

            var symbol = mapper.GetLeanSymbol("EUR/USD", SecurityType.Forex, Market.FXCM);
            Assert.AreEqual("EURUSD", symbol.Value);
            Assert.AreEqual(SecurityType.Forex, symbol.ID.SecurityType);
            Assert.AreEqual(Market.FXCM, symbol.ID.Market);

            symbol = mapper.GetLeanSymbol("GER30", SecurityType.Cfd, Market.FXCM);
            Assert.AreEqual("DE30EUR", symbol.Value);
            Assert.AreEqual(SecurityType.Cfd, symbol.ID.SecurityType);
            Assert.AreEqual(Market.FXCM, symbol.ID.Market);
        }

        [Test]
        public void ReturnsCorrectBrokerageSymbol()
        {
            var mapper = new FxcmSymbolMapper();

            var symbol = Symbol.Create("EURUSD", SecurityType.Forex, Market.FXCM);
            var brokerageSymbol = mapper.GetBrokerageSymbol(symbol);
            Assert.AreEqual("EUR/USD", brokerageSymbol);

            symbol = Symbol.Create("DE30EUR", SecurityType.Cfd, Market.FXCM);
            brokerageSymbol = mapper.GetBrokerageSymbol(symbol);
            Assert.AreEqual("GER30", brokerageSymbol);
        }

        [Test]
        public void ThrowsOnNullOrEmptySymbol()
        {
            var mapper = new FxcmSymbolMapper();

            Assert.Throws<ArgumentException>(() => mapper.GetLeanSymbol(null, SecurityType.Forex, Market.FXCM));

            Assert.Throws<ArgumentException>(() => mapper.GetLeanSymbol("", SecurityType.Forex, Market.FXCM));

            var symbol = Symbol.Empty;
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));

            symbol = null;
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));

            symbol = Symbol.Create("", SecurityType.Forex, Market.FXCM);
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));
        }

        [Test]
        public void ThrowsOnUnknownSymbol()
        {
            var mapper = new FxcmSymbolMapper();

            Assert.Throws<ArgumentException>(() => mapper.GetLeanSymbol("ABC/USD", SecurityType.Forex, Market.FXCM));

            var symbol = Symbol.Create("ABCUSD", SecurityType.Forex, Market.FXCM);
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));
        }

        [Test]
        public void ThrowsOnInvalidSecurityType()
        {
            var mapper = new FxcmSymbolMapper();

            Assert.Throws<ArgumentException>(() => mapper.GetLeanSymbol("AAPL", SecurityType.Equity, Market.FXCM));

            var symbol = Symbol.Create("AAPL", SecurityType.Equity, Market.FXCM);
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));
        }

        [Test]
        public void ChecksForKnownSymbols()
        {
#pragma warning disable 0618 // This test requires implicit operators
            var mapper = new FxcmSymbolMapper();

            Assert.IsFalse(mapper.IsKnownBrokerageSymbol(null));
            Assert.IsFalse(mapper.IsKnownBrokerageSymbol(""));
            Assert.IsTrue(mapper.IsKnownBrokerageSymbol("EUR/USD"));
            Assert.IsTrue(mapper.IsKnownBrokerageSymbol("GER30"));
            Assert.IsFalse(mapper.IsKnownBrokerageSymbol("ABC/USD"));

            Assert.IsFalse(mapper.IsKnownLeanSymbol(null));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(""));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(Symbol.Empty));
            Assert.IsTrue(mapper.IsKnownLeanSymbol(Symbol.Create("EURUSD", SecurityType.Forex, Market.FXCM)));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(Symbol.Create("ABCUSD", SecurityType.Forex, Market.FXCM)));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(Symbol.Create("EURUSD", SecurityType.Cfd, Market.FXCM)));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(Symbol.Create("DE30EUR", SecurityType.Forex, Market.FXCM)));
#pragma warning restore 0618
        }

    }
}
