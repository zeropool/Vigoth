

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MovingAverageTypeExtensionsTests
    {
        [Test]
        public void CreatesCorrectAveragingIndicator()
        {
            var indicator = MovingAverageType.Simple.AsIndicator(1);
            Assert.IsInstanceOf(typeof(SimpleMovingAverage), indicator);

            indicator = MovingAverageType.Exponential.AsIndicator(1);
            Assert.IsInstanceOf(typeof(ExponentialMovingAverage), indicator);

            indicator = MovingAverageType.Wilders.AsIndicator(1);
            Assert.IsInstanceOf(typeof(ExponentialMovingAverage), indicator);

            indicator = MovingAverageType.LinearWeightedMovingAverage.AsIndicator(1);
            Assert.IsInstanceOf(typeof(LinearWeightedMovingAverage), indicator);

            indicator = MovingAverageType.DoubleExponential.AsIndicator(1);
            Assert.IsInstanceOf(typeof(DoubleExponentialMovingAverage), indicator);

            indicator = MovingAverageType.TripleExponential.AsIndicator(1);
            Assert.IsInstanceOf(typeof(TripleExponentialMovingAverage), indicator);

            indicator = MovingAverageType.Triangular.AsIndicator(1);
            Assert.IsInstanceOf(typeof(TriangularMovingAverage), indicator);

            indicator = MovingAverageType.T3.AsIndicator(1);
            Assert.IsInstanceOf(typeof(T3MovingAverage), indicator);

            indicator = MovingAverageType.Kama.AsIndicator(1);
            Assert.IsInstanceOf(typeof(KaufmanAdaptiveMovingAverage), indicator);

            string name = string.Empty;
            indicator = MovingAverageType.Simple.AsIndicator(name, 1);
            Assert.IsInstanceOf(typeof(SimpleMovingAverage), indicator);

            indicator = MovingAverageType.Exponential.AsIndicator(name, 1);
            Assert.IsInstanceOf(typeof(ExponentialMovingAverage), indicator);

            indicator = MovingAverageType.Wilders.AsIndicator(name, 1);
            Assert.IsInstanceOf(typeof(ExponentialMovingAverage), indicator);

            indicator = MovingAverageType.LinearWeightedMovingAverage.AsIndicator(name, 1);
            Assert.IsInstanceOf(typeof(LinearWeightedMovingAverage), indicator);

            indicator = MovingAverageType.DoubleExponential.AsIndicator(name, 1);
            Assert.IsInstanceOf(typeof(DoubleExponentialMovingAverage), indicator);

            indicator = MovingAverageType.TripleExponential.AsIndicator(name, 1);
            Assert.IsInstanceOf(typeof(TripleExponentialMovingAverage), indicator);

            indicator = MovingAverageType.Triangular.AsIndicator(name, 1);
            Assert.IsInstanceOf(typeof(TriangularMovingAverage), indicator);

            indicator = MovingAverageType.T3.AsIndicator(name, 1);
            Assert.IsInstanceOf(typeof(T3MovingAverage), indicator);

            indicator = MovingAverageType.Kama.AsIndicator(name, 1);
            Assert.IsInstanceOf(typeof(KaufmanAdaptiveMovingAverage), indicator);
        }
    }
}