

using System.Collections.Generic;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class SubscriptionDataConfigTests
    {
        [Test]
        public void UsesValueEqualsSemantics()
        {
            var config1 = new SubscriptionDataConfig(typeof(TradeBar), Symbols.SPY, Resolution.Minute, TimeZones.NewYork, TimeZones.NewYork, false, false, false, false, TickType.Trade, false);
            var config2 = new SubscriptionDataConfig(config1);
            Assert.AreEqual(config1, config2);
        }

        [Test]
        public void UsedAsDictionaryKey()
        {
            var set = new HashSet<SubscriptionDataConfig>();
            var config1 = new SubscriptionDataConfig(typeof(TradeBar), Symbols.SPY, Resolution.Minute, TimeZones.NewYork, TimeZones.NewYork, false, false, false, false, TickType.Trade, false);
            Assert.IsTrue(set.Add(config1));
            var config2 = new SubscriptionDataConfig(config1);
            Assert.IsFalse(set.Add(config2));
        }
    }
}