

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Brokerages.Oanda;

namespace VigiothCapital.QuantTrader.Tests.Brokerages.Oanda
{
    [TestFixture]
    public class OandaSymbolMapperTests
    {
        [Test]
        public void ReturnsCorrectLeanSymbol()
        {
            var mapper = new OandaSymbolMapper();

            var symbol = mapper.GetLeanSymbol("EUR_USD", SecurityType.Forex, Market.Oanda);
            Assert.AreEqual("EURUSD", symbol.Value);
            Assert.AreEqual(SecurityType.Forex, symbol.ID.SecurityType);
            Assert.AreEqual(Market.Oanda, symbol.ID.Market);

            symbol = mapper.GetLeanSymbol("DE30_EUR", SecurityType.Cfd, Market.Oanda);
            Assert.AreEqual("DE30EUR", symbol.Value);
            Assert.AreEqual(SecurityType.Cfd, symbol.ID.SecurityType);
            Assert.AreEqual(Market.Oanda, symbol.ID.Market);
        }

        [Test]
        public void ReturnsCorrectBrokerageSymbol()
        {
            var mapper = new OandaSymbolMapper();

            var symbol = Symbol.Create("EURUSD", SecurityType.Forex, Market.Oanda);
            var brokerageSymbol = mapper.GetBrokerageSymbol(symbol);
            Assert.AreEqual("EUR_USD", brokerageSymbol);

            symbol = Symbol.Create("DE30EUR", SecurityType.Cfd, Market.Oanda);
            brokerageSymbol = mapper.GetBrokerageSymbol(symbol);
            Assert.AreEqual("DE30_EUR", brokerageSymbol);
        }

        [Test]
        public void ThrowsOnNullOrEmptySymbol()
        {
            var mapper = new OandaSymbolMapper();

            Assert.Throws<ArgumentException>(() => mapper.GetLeanSymbol(null, SecurityType.Forex, Market.Oanda));

            Assert.Throws<ArgumentException>(() => mapper.GetLeanSymbol("", SecurityType.Forex, Market.Oanda));

            var symbol = Symbol.Empty;
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));

            symbol = null;
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));

            symbol = Symbol.Create("", SecurityType.Forex, Market.Oanda);
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));
        }

        [Test]
        public void ThrowsOnUnknownSymbol()
        {
            var mapper = new OandaSymbolMapper();

            Assert.Throws<ArgumentException>(() => mapper.GetLeanSymbol("ABC_USD", SecurityType.Forex, Market.Oanda));

            var symbol = Symbol.Create("ABCUSD", SecurityType.Forex, Market.Oanda);
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));
        }

        [Test]
        public void ThrowsOnInvalidSecurityType()
        {
            var mapper = new OandaSymbolMapper();

            Assert.Throws<ArgumentException>(() => mapper.GetLeanSymbol("AAPL", SecurityType.Equity, Market.Oanda));

            var symbol = Symbol.Create("AAPL", SecurityType.Equity, Market.Oanda);
            Assert.Throws<ArgumentException>(() => mapper.GetBrokerageSymbol(symbol));
        }

        [Test]
        public void ChecksForKnownSymbols()
        {
#pragma warning disable 0618 // This test requires implicit operators
            var mapper = new OandaSymbolMapper();

            Assert.IsFalse(mapper.IsKnownBrokerageSymbol(null));
            Assert.IsFalse(mapper.IsKnownBrokerageSymbol(""));
            Assert.IsTrue(mapper.IsKnownBrokerageSymbol("EUR_USD"));
            Assert.IsTrue(mapper.IsKnownBrokerageSymbol("DE30_EUR"));
            Assert.IsFalse(mapper.IsKnownBrokerageSymbol("ABC_USD"));

            Assert.IsFalse(mapper.IsKnownLeanSymbol(null));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(""));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(Symbol.Empty));
            Assert.IsTrue(mapper.IsKnownLeanSymbol(Symbol.Create("EURUSD", SecurityType.Forex, Market.Oanda)));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(Symbol.Create("ABCUSD", SecurityType.Forex, Market.Oanda)));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(Symbol.Create("EURUSD", SecurityType.Cfd, Market.Oanda)));
            Assert.IsFalse(mapper.IsKnownLeanSymbol(Symbol.Create("DE30EUR", SecurityType.Forex, Market.Oanda)));
#pragma warning restore 0618
        }

    }
}
