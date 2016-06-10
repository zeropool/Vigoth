

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// Defines the different types of moving averages
    /// </summary>  
    public enum MovingAverageType
    {
        /// <summary>
        /// An unweighted, arithmetic mean
        /// </summary>
        Simple,
        /// <summary>
        /// The standard exponential moving average, using a smoothing factor of 2/(n+1)
        /// </summary>
        Exponential,
        /// <summary>
        /// The standard exponential moving average, using a smoothing factor of 1/n
        /// </summary>
        Wilders,
        /// <summary>
        /// A weighted moving average type
        /// </summary>
        LinearWeightedMovingAverage,
        /// <summary>
        /// The double exponential moving average
        /// </summary>
        DoubleExponential,
        /// <summary>
        /// The triple exponential moving average
        /// </summary>
        TripleExponential,
        /// <summary>
        /// The triangular moving average
        /// </summary>
        Triangular,
        /// <summary>
        /// The T3 moving average
        /// </summary>
        T3,
        /// <summary>
        /// The Kaufman Adaptive Moving Average
        /// </summary>
        Kama
    }
}
