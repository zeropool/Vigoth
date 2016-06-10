

using System;
using System.IO;

namespace VigiothCapital.QuantTrader.Logging
{
    /// <summary>
    /// ILogHandler implementation that writes log output to console.
    /// </summary>
    public class ConsoleLogHandler : ILogHandler
    {
        private const string DateFormat = "yyyyMMdd HH:mm:ss";
        private readonly TextWriter _trace;
        private readonly TextWriter _error;

        /// <summary>
        /// Initializes a new instance of the <see cref="VigiothCapital.QuantTrader.Logging.ConsoleLogHandler"/> class.
        /// </summary>
        public ConsoleLogHandler()
        {
            // saves references to the real console text writer since in a deployed state we may overwrite this in order
            // to redirect messages from algorithm to result handler
            _trace = Console.Out;
            _error = Console.Error;
        }

        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="text">The error text to log</param>
        public void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _error.WriteLine(DateTime.Now.ToString(DateFormat) + " ERROR:: " + text);
            Console.ResetColor();
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The debug text to log</param>
        public void Debug(string text)
        {
            _trace.WriteLine(DateTime.Now.ToString(DateFormat) + " DEBUG:: " + text);
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The trace text to log</param>
        public void Trace(string text)
        {
            _trace.WriteLine(DateTime.Now.ToString(DateFormat) + " Trace:: " + text);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
        }
    }
}