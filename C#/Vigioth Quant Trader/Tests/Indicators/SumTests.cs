

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators {

    [TestFixture]
    public class SumTests {

        [Test]
        public void ComputesCorrectly() {
            var sum = new Sum(2);
            var time = DateTime.UtcNow;

            sum.Update(time.AddDays(1), 1m);
            sum.Update(time.AddDays(1), 2m);
            sum.Update(time.AddDays(1), 3m);

            Assert.AreEqual(sum.Current.Value, 2m + 3m);
        }

        [Test]
        public void ResetsCorrectly() {
            var sum = new Sum(2);
            var time = DateTime.UtcNow;

            sum.Update(time.AddDays(1), 1m);
            sum.Update(time.AddDays(1), 2m);
            sum.Update(time.AddDays(1), 3m);

            Assert.IsTrue(sum.IsReady);

            sum.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(sum);
            Assert.AreEqual(sum.Current.Value, 0m);
            sum.Update(time.AddDays(1), 1);
            Assert.AreEqual(sum.Current.Value, 1m);
        }
    }
}
