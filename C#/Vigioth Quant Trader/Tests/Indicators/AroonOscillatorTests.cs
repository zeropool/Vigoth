

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class AroonOscillatorTests
    {
        [Test]
        public void ComparesWithExternalData()
        {
            var aroon = new AroonOscillator(14, 14);
            TestHelper.TestIndicator(aroon, "spy_aroon_oscillator.txt", "Aroon Oscillator 14",
                (i, expected) => Assert.AreEqual(expected, (double)aroon.Current.Value, 1e-3));
        }

        [Test]
        public void ResetsProperly()
        {
            var aroon = new AroonOscillator(3, 3);
            aroon.Update(new TradeBar
            {
                Symbol = Symbols.SPY,
                Time = DateTime.Today,
                Open = 3m,
                High = 7m,
                Low = 2m,
                Close = 5m,
                Volume = 10
            });
            aroon.Update(new TradeBar
            {
                Symbol = Symbols.SPY,
                Time = DateTime.Today.AddSeconds(1),
                Open = 3m,
                High = 7m,
                Low = 2m,
                Close = 5m,
                Volume = 10
            });
            aroon.Update(new TradeBar
            {
                Symbol = Symbols.SPY,
                Time = DateTime.Today.AddSeconds(2),
                Open = 3m,
                High = 7m,
                Low = 2m,
                Close = 5m,
                Volume = 10
            });
            Assert.IsFalse(aroon.IsReady);
            aroon.Update(new TradeBar
            {
                Symbol = Symbols.SPY,
                Time = DateTime.Today.AddSeconds(3),
                Open = 3m,
                High = 7m,
                Low = 2m,
                Close = 5m,
                Volume = 10
            });
            Assert.IsTrue(aroon.IsReady);

            aroon.Reset();
            TestHelper.AssertIndicatorIsInDefaultState(aroon);
            TestHelper.AssertIndicatorIsInDefaultState(aroon.AroonUp);
            TestHelper.AssertIndicatorIsInDefaultState(aroon.AroonDown);
        }
    }
}
