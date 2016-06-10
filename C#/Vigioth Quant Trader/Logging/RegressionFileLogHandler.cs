

namespace VigiothCapital.QuantTrader.Logging
{
    /// <summary>
    /// Provides an implementation of <see cref="ILogHandler"/> that writes all log messages to a file on disk
    /// without timestamps.
    /// </summary>
    /// <remarks>
    /// This type is provided for convenience/setting from configuration
    /// </remarks>
    public class RegressionFileLogHandler : FileLogHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegressionFileLogHandler"/> class
        /// that will write to a 'regression.log' file in the executing directory
        /// </summary>
        public RegressionFileLogHandler()
            : base("regression.log", false)
        {
        }
    }
}