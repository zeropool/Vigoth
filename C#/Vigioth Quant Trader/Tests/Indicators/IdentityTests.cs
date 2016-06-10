

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    /// <summary>
    /// Test class for VigiothCapital.QuantTrader.Indicators.Identity
    /// </summary>
    [TestFixture]
    public class IdentityTests
    {
        [Test]
        public void TestIdentityInvariants()
        {
            // the invariants of the identity indicator is to be ready after
            // a single sample has been added, and always produce the same value
            // as the last ingested value

            var identity = new Identity("test");
            Assert.IsFalse(identity.IsReady);

            const decimal value = 1m;
            identity.Update(new IndicatorDataPoint(DateTime.UtcNow, value));
            Assert.IsTrue(identity.IsReady);
            Assert.AreEqual(value, identity.Current.Value);
        }

        [Test]
        public void ResetsProperly()
        {
            var identity = new Identity("test");
            Assert.IsFalse(identity.IsReady);
            Assert.AreEqual(0m, identity.Current.Value);

            foreach (var data in TestHelper.GetDataStream(2))
            {
                identity.Update(data);
            }
            Assert.IsTrue(identity.IsReady);
            Assert.AreEqual(2, identity.Samples);

            identity.Reset();

            Assert.IsFalse(identity.IsReady);
            Assert.AreEqual(0, identity.Samples);
        }
    }
}
