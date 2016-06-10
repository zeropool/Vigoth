

using NUnit.Framework;

namespace VigiothCapital.QuantTrader.Tests.Common
{
    [TestFixture]
    public class MarketTests
    {
        [Test]
        public void MapsAllMarketsInMarketClass()
        {
            var markets = typeof(Market).GetFields();
            foreach (var field in markets)
            {
                var market = (string)field.GetValue(null);
                var code = Market.Encode(market);
                Assert.IsTrue(code.HasValue);

                var decoded = Market.Decode(code.Value);
                Assert.AreEqual(market, decoded);
            }
        }
    }
}
