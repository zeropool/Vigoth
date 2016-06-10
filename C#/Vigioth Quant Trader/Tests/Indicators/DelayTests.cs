

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class DelayTests
    {
        [Test, ExpectedException(typeof(ArgumentException), MatchType = MessageMatch.Contains, ExpectedMessage = "size of at least 1")]
        public void DelayZeroThrowsArgumentException()
        {
            new Delay(0);
        }

        [Test]
        public void DelayOneRepeatsFirstInputValue()
        {
            var delay = new Delay(1);

            var data = new IndicatorDataPoint(DateTime.UtcNow, 1m);
            delay.Update(data);
            Assert.AreEqual(1m, delay.Current.Value);

            data = new IndicatorDataPoint(DateTime.UtcNow.AddSeconds(1), 2m);
            delay.Update(data);
            Assert.AreEqual(1m, delay.Current.Value);

            data = new IndicatorDataPoint(DateTime.UtcNow.AddSeconds(1), 2m);
            delay.Update(data);
            Assert.AreEqual(2m, delay.Current.Value);
        }

        [Test]
        public void DelayTakesPeriodPlus2UpdaesToEmitNonInitialPoint()
        {
            int start = 1;
            int count = 10;
            for (int i = start; i < count+start; i++)
            {
                TestDelayTakesPeriodPlus2UpdatesToEmitNonInitialPoint(i);
            }
        }

        private void TestDelayTakesPeriodPlus2UpdatesToEmitNonInitialPoint(int period)
        {
            var delay = new Delay(period);
            for (int i = 0; i < period + 2; i++)
            {
                Assert.AreEqual(0m, delay.Current.Value);
                delay.Update(new IndicatorDataPoint(DateTime.Today.AddSeconds(i), i));
            }
            Assert.AreEqual(1m, delay.Current.Value);
        }

        [Test]
        public void ResetsProperly()
        {
            var delay = new Delay(2);

            foreach (var data in TestHelper.GetDataStream(3))
            {
                delay.Update(data);
            }
            Assert.IsTrue(delay.IsReady);
            Assert.AreEqual(3, delay.Samples);

            delay.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(delay);
        }
    }
}
