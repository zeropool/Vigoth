

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Data.UniverseSelection;
using VigiothCapital.QuantTrader.Engine.DataFeeds;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds
{
    [TestFixture]
    public class TimeSliceTests
    {
        [Test]
        public void HandlesTicks_ExpectInOrderWithNoDuplicates()
        {
            var subscriptionDataConfig = new SubscriptionDataConfig(
                typeof(Tick), 
                Symbols.EURUSD, 
                Resolution.Tick, 
                TimeZones.Utc, 
                TimeZones.Utc, 
                true, 
                true, 
                false);

            var security = new Security(
                SecurityExchangeHours.AlwaysOpen(TimeZones.Utc), 
                subscriptionDataConfig, 
                new Cash(CashBook.AccountCurrency, 0, 1m), 
                SymbolProperties.GetDefault(CashBook.AccountCurrency));

            DateTime refTime = DateTime.UtcNow;

            Tick[] rawTicks = Enumerable
                .Range(0, 10)
                .Select(i => new Tick(refTime.AddSeconds(i), Symbols.EURUSD, 1.3465m, 1.34652m))
                .ToArray();

            IEnumerable<TimeSlice> timeSlices = rawTicks.Select(t => TimeSlice.Create(
                t.Time,
                TimeZones.Utc,
                new CashBook(),
                new List<DataFeedPacket> {new DataFeedPacket(security, subscriptionDataConfig, new List<BaseData>() {t})},
                new SecurityChanges(Enumerable.Empty<Security>(), Enumerable.Empty<Security>())));

            Tick[] timeSliceTicks = timeSlices.SelectMany(ts => ts.Slice.Ticks.Values.SelectMany(x => x)).ToArray();

            Assert.AreEqual(rawTicks.Length, timeSliceTicks.Length);
            for (int i = 0; i < rawTicks.Length; i++)
            {
                Assert.IsTrue(Compare(rawTicks[i], timeSliceTicks[i]));
            }
        }

        private bool Compare(Tick expected, Tick actual)
        {
            return expected.Time == actual.Time
                   && expected.BidPrice == actual.BidPrice
                   && expected.AskPrice == actual.AskPrice
                   && expected.Quantity == actual.Quantity;
        }
    }
}
