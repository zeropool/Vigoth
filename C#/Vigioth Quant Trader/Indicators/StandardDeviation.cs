

using System;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the n-period population standard deviation.
    /// </summary>
    public class StandardDeviation : Variance
    {
        /// <summary>
        /// Initializes a new instance of the StandardDeviation class with the specified period.
        /// 
        /// Evaluates the standard deviation of samples in the lookback period. 
        /// On a dataset of size N will use an N normalizer and would thus be biased if applied to a subset.
        /// </summary>
        /// <param name="period">The sample size of the standard deviation</param>
        public StandardDeviation(int period)
            : this("STD" + period, period)
        {
        }

        /// <summary>
        /// Initializes a new instance of the StandardDeviation class with the specified name and period.
        /// 
        /// Evaluates the standard deviation of samples in the lookback period. 
        /// On a dataset of size N will use an N normalizer and would thus be biased if applied to a subset.
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The sample size of the standard deviation</param>
        public StandardDeviation(string name, int period)
            : base(name, period)
        {
        }

        /// <summary>
        /// Gets a flag indicating when this indicator is ready and fully initialized
        /// </summary>
        public override bool IsReady
        {
            get { return Samples >= Period; }
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <param name="window">The window for the input history</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IReadOnlyWindow<IndicatorDataPoint> window, IndicatorDataPoint input)
        {
            return (decimal)Math.Sqrt((double)base.ComputeNextValue(window, input));
        }
    }
}
