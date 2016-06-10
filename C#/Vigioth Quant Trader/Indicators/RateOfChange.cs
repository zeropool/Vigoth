

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the n-period rate of change in a value using the following:
    /// (value_0 - value_n) / value_n
    /// </summary>
    public class RateOfChange : WindowIndicator<IndicatorDataPoint>
    {
        /// <summary>
        /// Creates a new RateOfChange indicator with the specified period
        /// </summary>
        /// <param name="period">The period over which to perform to computation</param>
        public RateOfChange(int period)
            : base("ROC" + period, period)
        {
        }

        /// <summary>
        /// Creates a new RateOfChange indicator with the specified period
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The period over which to perform to computation</param>
        public RateOfChange(string name, int period)
            : base(name, period)
        {
        }

        /// <summary>
        /// Computes the next value for this indicator from the given state.
        /// </summary>
        /// <param name="window">The window of data held in this indicator</param>
        /// <param name="input">The input value to this indicator on this time step</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IReadOnlyWindow<IndicatorDataPoint> window, IndicatorDataPoint input)
        {
            // if we're not ready just grab the first input point in the window
            decimal denominator = !window.IsReady ? window[window.Count - 1] : window.MostRecentlyRemoved;

            if (denominator == 0)
            {
                return 0;
            }

            return (input - denominator) / denominator;
        }
    }
}