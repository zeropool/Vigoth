

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Consolidators;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Common.Data
{
    [TestFixture]
    public class IdentityDataConsolidatorTests
    {
        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ThrowsOnDataOfWrongType()
        {
            var identity = new IdentityDataConsolidator<Tick>();
            identity.Update(new TradeBar());
        }

        [Test]
        public void ReturnsTheSameObjectReference()
        {
            var identity = new IdentityDataConsolidator<Tick>();

            var tick = new Tick();

            int count = 0;
            identity.DataConsolidated += (sender, data) =>
            {
                Assert.IsTrue(ReferenceEquals(tick, data));
                count++;
            };

            identity.Update(tick);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void IgnoresNonTickDataWithSameTimestamps()
        {
            var reference = new DateTime(2015, 09, 23);
            var identity = new IdentityDataConsolidator<TradeBar>();

            int count = 0;
            identity.DataConsolidated += (sender, data) =>
            {
                count++;
            };
            
            var tradeBar = new TradeBar{EndTime = reference};
            identity.Update(tradeBar);

            tradeBar = (TradeBar) tradeBar.Clone();
            identity.Update(tradeBar);

            Assert.AreEqual(1, count);
        }

        [Test]
        public void AcceptsTickDataWithSameTimestamps()
        {
            var reference = new DateTime(2015, 09, 23);
            var identity = new IdentityDataConsolidator<Tick>();

            int count = 0;
            identity.DataConsolidated += (sender, data) =>
            {
                count++;
            };

            var tradeBar = new Tick { EndTime = reference };
            identity.Update(tradeBar);

            tradeBar = (Tick)tradeBar.Clone();
            identity.Update(tradeBar);

            Assert.AreEqual(2, count);
        }
    }
}
