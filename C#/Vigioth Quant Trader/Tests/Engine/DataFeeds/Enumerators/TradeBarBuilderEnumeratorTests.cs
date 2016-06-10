

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Engine.DataFeeds;
using VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Enumerators
{
    [TestFixture]
    public class TradeBarBuilderEnumeratorTests
    {
        [Test]
        public void AggregatesTicksIntoSecondBars()
        {
            var timeProvider = new ManualTimeProvider(TimeZones.NewYork);
            var enumerator = new TradeBarBuilderEnumerator(Time.OneSecond, TimeZones.NewYork, timeProvider);

            // noon new york time
            var currentTime = new DateTime(2015, 10, 08, 12, 0, 0);
            timeProvider.SetCurrentTime(currentTime);

            // add some ticks
            var ticks = new List<Tick>
            {
                new Tick(currentTime, Symbols.SPY, 199.55m, 199, 200) {Quantity = 10},
                new Tick(currentTime, Symbols.SPY, 199.56m, 199.21m, 200.02m) {Quantity = 5},
                new Tick(currentTime, Symbols.SPY, 199.53m, 198.77m, 199.75m) {Quantity = 20},
                new Tick(currentTime, Symbols.SPY, 198.77m, 199.75m) {Quantity = 0},
                new Tick(currentTime, Symbols.SPY, 199.73m, 198.77m, 199.75m) {Quantity = 20},
                new Tick(currentTime, Symbols.SPY, 198.77m, 199.75m) {Quantity = 0},
            };

            foreach (var tick in ticks)
            {
                enumerator.ProcessData(tick);
            }

            // even though no data is here, it will still return true
            Assert.IsTrue(enumerator.MoveNext());
            Assert.IsNull(enumerator.Current);

            // advance a second
            currentTime = currentTime.AddSeconds(1);
            timeProvider.SetCurrentTime(currentTime);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.IsNotNull(enumerator.Current);
            
            // in the spirit of not duplicating the above code 5 times (OHLCV, we'll assert these ere as well)
            var bar = (TradeBar)enumerator.Current;
            Assert.AreEqual(currentTime.AddSeconds(-1), bar.Time);
            Assert.AreEqual(currentTime, bar.EndTime);
            Assert.AreEqual(Symbols.SPY, bar.Symbol);
            Assert.AreEqual(ticks.First().LastPrice, bar.Open);
            Assert.AreEqual(ticks.Max(x => x.LastPrice), bar.High);
            Assert.AreEqual(ticks.Min(x => x.LastPrice), bar.Low);
            Assert.AreEqual(ticks.Last().LastPrice, bar.Close);
            Assert.AreEqual(ticks.Sum(x => x.Quantity), bar.Volume);
        }
    }
}
