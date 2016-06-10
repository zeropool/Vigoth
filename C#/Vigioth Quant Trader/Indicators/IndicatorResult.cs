

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// Represents the result of an indicator's calculations
    /// </summary>
    public class IndicatorResult
    {
        /// <summary>
        /// The indicator output value
        /// </summary>
        public decimal Value
        {
            get;
            private set;
        }

        /// <summary>
        /// The indicator status
        /// </summary>
        public IndicatorStatus Status
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndicatorResult"/> class
        /// </summary>
        /// <param name="value">The value output by the indicator</param>
        /// <param name="status">The status returned by the indicator</param>
        public IndicatorResult(decimal value, IndicatorStatus status = IndicatorStatus.Success)
        {
            Value = value;
            Status = status;
        }

        /// <summary>
        /// Converts the specified decimal value into a successful indicator result
        /// </summary>
        /// <remarks>
        /// This method is provided for backwards compatibility
        /// </remarks>
        /// <param name="value">The decimal value to be converted into an <see cref="IndicatorResult"/></param>
        public static implicit operator IndicatorResult(decimal value)
        {
            return new IndicatorResult(value);
        }
    }
}
