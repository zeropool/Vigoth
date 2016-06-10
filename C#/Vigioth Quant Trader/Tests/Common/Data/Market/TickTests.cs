

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Common.Data.Market
{
    [TestFixture]
    public class TickTests
    {
        [Test]
        public void ConstructsFromLine()
        {
            const string line = "15093000,1456300,100,P,T,0";

            var baseDate = new DateTime(2013, 10, 08);
            var tick = new Tick(Symbols.SPY, line, baseDate);

            var ms = (tick.Time - baseDate).TotalMilliseconds;
            Assert.AreEqual(15093000, ms);
            Assert.AreEqual(1456300, tick.LastPrice * 10000m);
            Assert.AreEqual(100, tick.Quantity);
            Assert.AreEqual("P", tick.Exchange);
            Assert.AreEqual("T", tick.SaleCondition);
            Assert.AreEqual(false, tick.Suspicious);
        }
    }
}
