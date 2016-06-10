

using System;
using System.ComponentModel.Composition;

namespace VigiothCapital.QuantTrader.Logging
{
    /// <summary>
    /// ILogHandler implementation that writes log output to result handler
    /// </summary>
    [PartNotDiscoverable]
    public class FunctionalLogHandler : ILogHandler
    {
        private const string DateFormat = "yyyyMMdd HH:mm:ss";
        private readonly Action<string> _debug;
        private readonly Action<string> _trace;
        private readonly Action<string> _error;

        /// <summary>
        /// Default constructor to handle MEF.
        /// </summary>
        public FunctionalLogHandler()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VigiothCapital.QuantTrader.Logging.FunctionalLogHandler"/> class.
        /// </summary>
        public FunctionalLogHandler(Action<string> debug, Action<string> trace, Action<string> error)
        {
            // saves references to the real console text writer since in a deployed state we may overwrite this in order
            // to redirect messages from algorithm to result handler
            _debug = debug;
            _trace = trace;
            _error = error;
        }

        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="text">The error text to log</param>
        public void Error(string text)
        {
            if (_error != null)
            {
                _error(DateTime.Now.ToString(DateFormat) + " ERROR " + text);
            }
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The debug text to log</param>
        public void Debug(string text)
        {
            if (_debug != null)
            {
                _debug(DateTime.Now.ToString(DateFormat) + " DEBUG " + text);
            }
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The trace text to log</param>
        public void Trace(string text)
        {
            if (_trace != null)
            {
                _trace(DateTime.Now.ToString(DateFormat) + " TRACE " + text);
            }
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