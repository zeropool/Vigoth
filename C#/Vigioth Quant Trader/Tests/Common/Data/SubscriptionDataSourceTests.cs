

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Tests.Common.Data
{
    [TestFixture]
    public class SubscriptionDataSourceTests
    {
        [Test]
        public void ComparesEqualWithIdenticalSourceAndTransportMedium()
        {
            var one = new SubscriptionDataSource("source", SubscriptionTransportMedium.LocalFile);
            var two = new SubscriptionDataSource("source", SubscriptionTransportMedium.LocalFile);
            Assert.IsTrue(one == two);
            Assert.IsTrue(one.Equals(two));
        }

        [Test]
        public void ComparesNotEqualWithDifferentSource()
        {
            var one = new SubscriptionDataSource("source1", SubscriptionTransportMedium.LocalFile);
            var two = new SubscriptionDataSource("source2", SubscriptionTransportMedium.LocalFile);
            Assert.IsTrue(one != two);
            Assert.IsTrue(!one.Equals(two));
        }

        [Test]
        public void ComparesNotEqualWithDifferentTransportMedium()
        {
            var one = new SubscriptionDataSource("source", SubscriptionTransportMedium.LocalFile);
            var two = new SubscriptionDataSource("source", SubscriptionTransportMedium.RemoteFile);
            Assert.IsTrue(one != two);
            Assert.IsTrue(!one.Equals(two));
        }
    }
}
