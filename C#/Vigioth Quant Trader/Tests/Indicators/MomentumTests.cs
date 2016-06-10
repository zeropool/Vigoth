

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MomentumTests
    {
        [Test]
        public void ComputesCorrectly()
        {
            var mom =  new Momentum(5);
            foreach (var data in TestHelper.GetDataStream(5))
            {
                mom.Update(data);
                Assert.AreEqual(data.Value, mom.Current.Value);
            }
        }

        [Test]
        public void ResetsProperly()
        {
            var mom = new Momentum(5);
            foreach (var data in TestHelper.GetDataStream(6))
            {
                mom.Update(data);
            }
            Assert.IsTrue(mom.IsReady);

            mom.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(mom);
        }
    }
}
