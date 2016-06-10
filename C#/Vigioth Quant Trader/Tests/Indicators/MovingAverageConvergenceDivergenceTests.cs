

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MovingAverageConvergenceDivergenceTests
    {
        [Test]
        public void ComputesCorrectly()
        {
            var fast = new SimpleMovingAverage(3);
            var slow = new SimpleMovingAverage(5);
            var signal = new SimpleMovingAverage(3);
            var macd = new MovingAverageConvergenceDivergence("macd", 3, 5, 3, MovingAverageType.Simple);

            foreach (var data in TestHelper.GetDataStream(7))
            {
                fast.Update(data);
                slow.Update(data);
                macd.Update(data);
                Assert.AreEqual(fast - slow, macd);
                if (fast.IsReady && slow.IsReady)
                {
                    signal.Update(new IndicatorDataPoint(data.Time, macd));
                    Assert.AreEqual(signal.Current.Value, macd.Current.Value);
                }
            }
        }

        [Test]
        public void ResetsProperly()
        {
            var macd = new MovingAverageConvergenceDivergence("macd", 3, 5, 3);
            foreach (var data in TestHelper.GetDataStream(30))
            {
                macd.Update(data);
            }
            Assert.IsTrue(macd.IsReady);

            macd.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(macd);
            TestHelper.AssertIndicatorIsInDefaultState(macd.Fast);
            TestHelper.AssertIndicatorIsInDefaultState(macd.Signal);
            TestHelper.AssertIndicatorIsInDefaultState(macd.Signal);
        }
    }
}
