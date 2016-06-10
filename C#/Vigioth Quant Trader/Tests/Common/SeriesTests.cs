

using System;
using System.Linq;
using NUnit.Framework;

namespace VigiothCapital.QuantTrader.Tests.Common
{
    [TestFixture]
    public class SeriesTests
    {
        [Test]
        public void RespectsMostRecentTimeOnDuplicatePoints()
        {
            var series = new Series();
            series.AddPoint(DateTime.Today, 1m);
            series.AddPoint(DateTime.Today, 2m);
            Assert.AreEqual(1, series.Values.Count);
            Assert.AreEqual(2m, series.Values.Single().y);
        }
    }
}
