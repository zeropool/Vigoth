

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the n-period change in a value using the following:
    /// value_0 - value_n
    /// </summary>
    public class Momentum : WindowIndicator<IndicatorDataPoint>
    {
        /// <summary>
        /// Creates a new Momentum indicator with the specified period
        /// </summary>
        /// <param name="period">The period over which to perform to computation</param>
        public Momentum(int period)
            : base("MOM" + period, period)
        {
        }

        /// <summary>
        /// Creates a new Momentum indicator with the specified period
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The period over which to perform to computation</param>
        public Momentum(string name, int period)
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
            if (!window.IsReady)
            {
                // keep returning the delta from the first item put in there to init
                return input - window[window.Count - 1];
            }

            return input - window.MostRecentlyRemoved;
        }
    }
}