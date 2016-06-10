

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    ///     Represents an indicator that is a ready after ingesting a single sample and
    ///     always returns the same value as it is given.
    /// </summary>
    public class Identity : Indicator
    {
        /// <summary>
        ///     Initializes a new instance of the Identity indicator with the specified name
        /// </summary>
        /// <param name="name">The name of the indicator</param>
        public Identity(string name)
            : base(name)
        {
        }

        /// <summary>
        ///     Gets a flag indicating when this indicator is ready and fully initialized
        /// </summary>
        public override bool IsReady
        {
            get { return Samples > 0; }
        }

        /// <summary>
        ///     Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IndicatorDataPoint input)
        {
            return input.Value;
        }
    }
}