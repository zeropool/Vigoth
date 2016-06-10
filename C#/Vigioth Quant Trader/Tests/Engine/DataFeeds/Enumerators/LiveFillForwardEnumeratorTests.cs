

using System;
using System.Collections.Generic;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Engine.DataFeeds;
using VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Enumerators
{
    [TestFixture]
    public class LiveFillForwardEnumeratorTests
    {
        [Test]
        public void FillsForwardOnNulls()
        {
            var reference = new DateTime(2015, 10, 08);
            var period = Time.OneSecond;
            var underlying = new List<BaseData>
            {
                // 0 seconds
                new TradeBar(reference, Symbols.SPY, 10, 20, 5, 15, 123456, period),
                // 1 seconds
                null,
                // 3 seconds
                new TradeBar(reference.AddSeconds(2), Symbols.SPY, 100, 200, 50, 150, 1234560, period),
                null,
                null,
                null,
                null
            };

            var timeProvider = new ManualTimeProvider(TimeZones.NewYork);
            timeProvider.SetCurrentTime(reference);
            var exchange = new SecurityExchange(SecurityExchangeHours.AlwaysOpen(TimeZones.NewYork));
            var fillForward = new LiveFillForwardEnumerator(timeProvider, underlying.GetEnumerator(), exchange, Ref.Create(Time.OneSecond), false, Time.EndOfTime, Time.OneSecond);

            // first point is always emitted
            Assert.IsTrue(fillForward.MoveNext());
            Assert.AreEqual(underlying[0], fillForward.Current);

            // stepping again without advancing time does nothing, but we'll still
            // return true as per IEnumerator contract
            Assert.IsTrue(fillForward.MoveNext());
            Assert.IsNull(fillForward.Current);

            timeProvider.SetCurrentTime(reference.AddSeconds(1));

            // non-null next will fill forward in between
            Assert.IsTrue(fillForward.MoveNext());
            Assert.AreEqual(underlying[0].EndTime, fillForward.Current.Time);
            Assert.AreEqual(underlying[0].Value, fillForward.Current.Value);
            Assert.IsTrue(fillForward.Current.IsFillForward);

            // even without stepping the time this will advance since non-null data is ready
            Assert.IsTrue(fillForward.MoveNext());
            Assert.AreEqual(underlying[2], fillForward.Current);

            // step ahead into null data territory
            timeProvider.SetCurrentTime(reference.AddSeconds(4));

            Assert.IsTrue(fillForward.MoveNext());
            Assert.AreEqual(underlying[2].Value, fillForward.Current.Value);
            Assert.AreEqual(timeProvider.GetUtcNow().ConvertFromUtc(TimeZones.NewYork), fillForward.Current.EndTime);
            Assert.IsTrue(fillForward.Current.IsFillForward);

            Assert.IsTrue(fillForward.MoveNext());
            Assert.IsNull(fillForward.Current);

            timeProvider.SetCurrentTime(reference.AddSeconds(5));

            Assert.IsTrue(fillForward.MoveNext());
            Assert.AreEqual(underlying[2].Value, fillForward.Current.Value);
            Assert.AreEqual(timeProvider.GetUtcNow().ConvertFromUtc(TimeZones.NewYork), fillForward.Current.EndTime);
            Assert.IsTrue(fillForward.Current.IsFillForward);

            timeProvider.SetCurrentTime(reference.AddSeconds(6));

            Assert.IsTrue(fillForward.MoveNext());
            Assert.AreEqual(underlying[2].Value, fillForward.Current.Value);
            Assert.AreEqual(timeProvider.GetUtcNow().ConvertFromUtc(TimeZones.NewYork), fillForward.Current.EndTime);
            Assert.IsTrue(fillForward.Current.IsFillForward);
        }
    }
}