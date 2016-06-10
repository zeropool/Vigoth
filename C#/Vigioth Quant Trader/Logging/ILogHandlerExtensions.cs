

using System;

namespace VigiothCapital.QuantTrader.Logging
{
    /// <summary>
    /// Logging extensions.
    /// </summary>
    public static class LogHandlerExtensions
    {
        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="logHandler"></param>
        /// <param name="text">Message</param>
        /// <param name="args">Arguments to format.</param>
        public static void Error(this ILogHandler logHandler, string text, params object[] args)
        {
            if (logHandler == null)
            {
                throw new ArgumentNullException("logHandler", "Log Handler cannot be null");
            }

            logHandler.Error(string.Format(text, args));
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="logHandler"></param>
        /// <param name="text">Message</param>
        /// <param name="args">Arguments to format.</param>
        public static void Debug(this ILogHandler logHandler, string text, params object[] args)
        {
            if (logHandler == null)
            {
                throw new ArgumentNullException("logHandler", "Log Handler cannot be null");
            }

            logHandler.Debug(string.Format(text, args));
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="logHandler"></param>
        /// <param name="text">Message</param>
        /// <param name="args">Arguments to format.</param>
        public static void Trace(this ILogHandler logHandler, string text, params object[] args)
        {
            if (logHandler == null)
            {
                throw new ArgumentNullException("logHandler", "Log Handler cannot be null");
            }

            logHandler.Trace(string.Format(text, args));
        }
    }
}
