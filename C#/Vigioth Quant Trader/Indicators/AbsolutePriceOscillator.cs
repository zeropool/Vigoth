

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the Absolute Price Oscillator (APO)
    /// The Absolute Price Oscillator is calculated using the following formula:
    /// APO[i] = FastMA[i] - SlowMA[i]
    /// </summary>
    /// <remarks>
    /// The Absolute Price Oscillator is the same as a MACD with the signal period equal to the slow period.
    /// </remarks>
    public class AbsolutePriceOscillator : MovingAverageConvergenceDivergence
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbsolutePriceOscillator"/> class using the specified name and parameters.
        /// </summary> 
        /// <param name="name">The name of this indicator</param>
        /// <param name="fastPeriod">The fast moving average period</param>
        /// <param name="slowPeriod">The slow moving average period</param>
        /// <param name="movingAverageType">The type of moving average to use</param>
        public AbsolutePriceOscillator(string name, int fastPeriod, int slowPeriod, MovingAverageType movingAverageType = MovingAverageType.Simple)
            : base(name, fastPeriod, slowPeriod, slowPeriod, movingAverageType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbsolutePriceOscillator"/> class using the specified parameters.
        /// </summary> 
        /// <param name="fastPeriod">The fast moving average period</param>
        /// <param name="slowPeriod">The slow moving average period</param>
        /// <param name="movingAverageType">The type of moving average to use</param>
        public AbsolutePriceOscillator(int fastPeriod, int slowPeriod, MovingAverageType movingAverageType = MovingAverageType.Simple)
            : this(string.Format("APO({0},{1})", fastPeriod, slowPeriod), fastPeriod, slowPeriod, movingAverageType)
        {
        }
    }
}
