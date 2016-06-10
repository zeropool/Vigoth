

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// An indicator that delays its input for a certain period
    /// </summary>
    public class Delay : WindowIndicator<IndicatorDataPoint>
    {
        /// <summary>
        /// Creates a new Delay indicator that delays its input by the specified period
        /// </summary>
        /// <param name="period">The period to delay input, must be greater than zero</param>
        public Delay(int period)
            : this("DELAY" + period, period)
        {
            
        }

        /// <summary>
        /// Creates a new Delay indicator that delays its input by the specified period
        /// </summary>
        /// <param name="name">Name of the delay window indicator</param>
        /// <param name="period">The period to delay input, must be greater than zero</param>
        public Delay(string name, int period) 
            : base(name, period)
        {
        }

        /// <summary>
        ///     Computes the next value for this indicator from the given state.
        /// </summary>
        /// <param name="window">The window of data held in this indicator</param>
        /// <param name="input">The input value to this indicator on this time step</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IReadOnlyWindow<IndicatorDataPoint> window, IndicatorDataPoint input)
        {
            if (!window.IsReady)
            {
                // grab the initial value until we're ready
                return window[window.Count - 1];
            }

            return window.MostRecentlyRemoved;
        }
    }
}
