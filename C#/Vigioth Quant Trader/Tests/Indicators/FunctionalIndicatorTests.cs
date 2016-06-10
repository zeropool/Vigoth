

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class FunctionalIndicatorTests
    {
        [Test]
        public void ComputesDelegateCorrectly()
        {
            var func = new FunctionalIndicator<IndicatorDataPoint>("f", data => data.Value, @this => @this.Samples > 1, () => {});
            func.Update(DateTime.Today, 1m);
            Assert.IsFalse(func.IsReady);
            Assert.AreEqual(1m, func.Current.Value);

            func.Update(DateTime.Today.AddSeconds(1), 2m);
            Assert.IsTrue(func.IsReady);
            Assert.AreEqual(2m, func.Current.Value);
        }

        [Test]
        public void ResetsProperly()
        {
            var inner = new SimpleMovingAverage(2);
            var func = new FunctionalIndicator<IndicatorDataPoint>("f", data =>
            {
                inner.Update(data);
                return inner.Current.Value*2;
            },
            @this => inner.IsReady,
            () => inner.Reset()
            );

            func.Update(DateTime.Today, 1m);
            func.Update(DateTime.Today.AddSeconds(1), 2m);
            Assert.IsTrue(func.IsReady);

            func.Reset();
            TestHelper.AssertIndicatorIsInDefaultState(inner);
            TestHelper.AssertIndicatorIsInDefaultState(func);
        }
    }
}
