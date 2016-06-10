

using System;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Engine.DataFeeds;
using VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Enumerators
{
    [TestFixture]
    public class RateLimitEnumeratorTests
    {
        [Test]
        public void LimitsBasedOnTimeBetweenCalls()
        {
            var currentTime = new DateTime(2015, 10, 10, 13, 6, 0);
            var timeProvider = new ManualTimeProvider(currentTime, TimeZones.Utc);
            var data = Enumerable.Range(0, 100).Select(x => new Tick {Symbol = CreateSymbol(x)}).GetEnumerator();
            var rateLimit = new RateLimitEnumerator(data, timeProvider, Time.OneSecond);

            Assert.IsTrue(rateLimit.MoveNext());

            while (rateLimit.MoveNext() && rateLimit.Current == null)
            {
                timeProvider.AdvanceSeconds(0.1);
            }

            var delta = (timeProvider.GetUtcNow() - currentTime).TotalSeconds;

            Assert.AreEqual(1, delta);

            Assert.AreEqual("1", data.Current.Symbol.Value);
        }

        private static Symbol CreateSymbol(int x)
        {
            return new Symbol(SecurityIdentifier.GenerateBase(x.ToString(), Market.USA), x.ToString());
        }
    }
}
