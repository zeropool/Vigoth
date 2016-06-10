

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// The possible states returned by <see cref="IndicatorBase{T}.ComputeNextValue"/>
    /// </summary>
    public enum IndicatorStatus
    {
        /// <summary>
        /// The indicator successfully calculated a value for the input data
        /// </summary>
        Success,

        /// <summary>
        /// The indicator detected an invalid input data point or tradebar
        /// </summary>
        InvalidInput,

        /// <summary>
        /// The indicator encountered a math error during calculations
        /// </summary>
        MathError,
    }
}
