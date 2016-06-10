

using NUnit.Framework;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common
{
    [TestFixture]
    public class SymbolCacheTests
    {
        [Test]
        public void HandlesRoundTripAccessSymbolToTicker()
        {
            var ticker = "ticker";
            SymbolCache.Set(ticker, Symbols.EURUSD);
            var actual = SymbolCache.GetSymbol(ticker);
            Assert.AreEqual(Symbols.EURUSD, actual);
        }

        [Test]
        public void HandlesRoundTripAccessTickerToSymbol()
        {
            var expected = "ticker";
            expected = Symbols.EURUSD.Value;
            SymbolCache.Set(expected, Symbols.EURUSD);
            var actual = SymbolCache.GetTicker(Symbols.EURUSD);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TryGetSymbol()
        {
            SymbolCache.Set("EURUSD", Symbols.EURUSD);

            Symbol actual;
            Assert.IsTrue(SymbolCache.TryGetSymbol("EURUSD", out actual));
            Assert.AreEqual(Symbols.EURUSD, actual);

            Assert.IsFalse(SymbolCache.TryGetSymbol("EURUSD1", out actual));
            Assert.AreEqual(default(Symbol), actual);
        }

        [Test]
        public void TryGetTicker()
        {
            SymbolCache.Set("EURUSD", Symbols.EURUSD);

            string ticker;
            Assert.IsTrue(SymbolCache.TryGetTicker(Symbols.EURUSD, out ticker));
            Assert.AreEqual(Symbols.EURUSD.Value, ticker);

            var symbol = new Symbol(SecurityIdentifier.GenerateForex("NOT A FOREX PAIR", Market.FXCM), "EURGBP");
            Assert.IsFalse(SymbolCache.TryGetTicker(symbol, out ticker));
            Assert.AreEqual(default(string), ticker);
        }

        [Test]
        public void TryGetSymbolFromSidString()
        {
            var sid = Symbols.EURUSD.ID.ToString();
            var symbol = SymbolCache.GetSymbol(sid);
            Assert.AreEqual(Symbols.EURUSD, symbol);
        }

        [Test]
        public void TryGetTickerFromUncachedSymbol()
        {
            var symbol = Symbol.Create("My Ticker", SecurityType.Equity, Market.USA);
            var ticker = SymbolCache.GetTicker(symbol);
            Assert.AreEqual(symbol.ID.ToString(), ticker);
        }

        [Test]
        public void TryRemoveSymbolRemovesSymbolMappings()
        {
            string ticker;
            Symbol symbol;
            SymbolCache.Set("SPY", Symbols.SPY);
            Assert.IsTrue(SymbolCache.TryRemove(Symbols.SPY));
            Assert.IsFalse(SymbolCache.TryGetSymbol("SPY", out symbol));
            Assert.IsFalse(SymbolCache.TryGetTicker(Symbols.SPY, out ticker));
        }

        [Test]
        public void TryRemoveTickerRemovesSymbolMappings()
        {
            string ticker;
            Symbol symbol;
            SymbolCache.Set("SPY", Symbols.SPY);
            Assert.IsTrue(SymbolCache.TryRemove("SPY"));
            Assert.IsFalse(SymbolCache.TryGetSymbol("SPY", out symbol));
            Assert.IsFalse(SymbolCache.TryGetTicker(Symbols.SPY, out ticker));
        }
    }
}
