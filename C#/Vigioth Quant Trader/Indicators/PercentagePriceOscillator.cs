

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the Percentage Price Oscillator (PPO)
    /// The Percentage Price Oscillator is calculated using the following formula:
    /// PPO[i] = 100 * (FastMA[i] - SlowMA[i]) / SlowMA[i]
    /// </summary>
    public class PercentagePriceOscillator : AbsolutePriceOscillator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PercentagePriceOscillator"/> class using the specified name and parameters.
        /// </summary> 
        /// <param name="name">The name of this indicator</param>
        /// <param name="fastPeriod">The fast moving average period</param>
        /// <param name="slowPeriod">The slow moving average period</param>
        /// <param name="movingAverageType">The type of moving average to use</param>
        public PercentagePriceOscillator(string name, int fastPeriod, int slowPeriod, MovingAverageType movingAverageType = MovingAverageType.Simple)
            : base(name, fastPeriod, slowPeriod, movingAverageType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PercentagePriceOscillator"/> class using the specified parameters.
        /// </summary> 
        /// <param name="fastPeriod">The fast moving average period</param>
        /// <param name="slowPeriod">The slow moving average period</param>
        /// <param name="movingAverageType">The type of moving average to use</param>
        public PercentagePriceOscillator(int fastPeriod, int slowPeriod, MovingAverageType movingAverageType = MovingAverageType.Simple)
            : this(string.Format("PPO({0},{1})", fastPeriod, slowPeriod), fastPeriod, slowPeriod, movingAverageType)
        {
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IndicatorDataPoint input)
        {
            var value = base.ComputeNextValue(input);

            return Slow != 0 ? 100 * value / Slow : 0m;
        }
    }
}
