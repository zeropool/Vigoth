

using System;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// Provides extension methods for the MovingAverageType enumeration
    /// </summary>
    public static class MovingAverageTypeExtensions
    {
        /// <summary>
        /// Creates a new indicator from the specified MovingAverageType. So if MovingAverageType.Simple
        /// is specified, then a new SimpleMovingAverage will be returned.
        /// </summary>
        /// <param name="movingAverageType">The type of averaging indicator to create</param>
        /// <param name="period">The smoothing period</param>
        /// <returns>A new indicator that matches the MovingAverageType</returns>
        public static IndicatorBase<IndicatorDataPoint> AsIndicator(this MovingAverageType movingAverageType, int period)
        {
            switch (movingAverageType)
            {
                case MovingAverageType.Simple:
                    return new SimpleMovingAverage(period);

                case MovingAverageType.Exponential:
                    return new ExponentialMovingAverage(period);

                case MovingAverageType.Wilders:
                    return new ExponentialMovingAverage(period, 1m/period);

                case MovingAverageType.LinearWeightedMovingAverage:
                    return new LinearWeightedMovingAverage(period);

                case MovingAverageType.DoubleExponential:
                    return new DoubleExponentialMovingAverage(period);

                case MovingAverageType.TripleExponential:
                    return new TripleExponentialMovingAverage(period);

                case MovingAverageType.Triangular:
                    return new TriangularMovingAverage(period);

                case MovingAverageType.T3:
                    return new T3MovingAverage(period);

                case MovingAverageType.Kama:
                    return new KaufmanAdaptiveMovingAverage(period);

                default:
                    throw new ArgumentOutOfRangeException("movingAverageType");
            }
        }

        /// <summary>
        /// Creates a new indicator from the specified MovingAverageType. So if MovingAverageType.Simple
        /// is specified, then a new SimpleMovingAverage will be returned.
        /// </summary>
        /// <param name="movingAverageType">The type of averaging indicator to create</param>
        /// <param name="name">The name of the new indicator</param>
        /// <param name="period">The smoothing period</param>
        /// <returns>A new indicator that matches the MovingAverageType</returns>
        public static IndicatorBase<IndicatorDataPoint> AsIndicator(this MovingAverageType movingAverageType, string name, int period)
        {
            switch (movingAverageType)
            {
                case MovingAverageType.Simple:
                    return new SimpleMovingAverage(name, period);

                case MovingAverageType.Exponential:
                    return new ExponentialMovingAverage(name, period);

                case MovingAverageType.Wilders:
                    return new ExponentialMovingAverage(name, period, 1m / period);

                case MovingAverageType.LinearWeightedMovingAverage:
                    return new LinearWeightedMovingAverage(name, period);

                case MovingAverageType.DoubleExponential:
                    return new DoubleExponentialMovingAverage(name, period);

                case MovingAverageType.TripleExponential:
                    return new TripleExponentialMovingAverage(name, period);

                case MovingAverageType.Triangular:
                    return new TriangularMovingAverage(name, period);

                case MovingAverageType.T3:
                    return new T3MovingAverage(name, period);

                case MovingAverageType.Kama:
                    return new KaufmanAdaptiveMovingAverage(name, period);

                default:
                    throw new ArgumentOutOfRangeException("movingAverageType");
            }
        }
    }
}