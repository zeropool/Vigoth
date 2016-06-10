

using System;

namespace VigiothCapital.QuantTrader.Logging
{
    /// <summary>
    /// Provides an <see cref="ILogHandler"/> implementation that composes multiple handlers
    /// </summary>
    public class CompositeLogHandler : ILogHandler
    {
        private readonly ILogHandler[] _handlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeLogHandler"/> that pipes log messages to the console and log.txt
        /// </summary>
        public CompositeLogHandler()
            : this(new ILogHandler[] {new ConsoleLogHandler(), new FileLogHandler()})
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeLogHandler"/> class from the specified handlers
        /// </summary>
        /// <param name="handlers">The implementations to compose</param>
        public CompositeLogHandler(ILogHandler[] handlers)
        {
            if (handlers == null || handlers.Length == 0)
            {
                throw new ArgumentNullException("handlers");
            }

            _handlers = handlers;
        }

        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="text"></param>
        public void Error(string text)
        {
            foreach (var handler in _handlers)
            {
                handler.Error(text);
            }
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text"></param>
        public void Debug(string text)
        {
            foreach (var handler in _handlers)
            {
                handler.Debug(text);
            }
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text"></param>
        public void Trace(string text)
        {
            foreach (var handler in _handlers)
            {
                handler.Trace(text);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            foreach (var handler in _handlers)
            {
                handler.Dispose();
            }
        }
    }
}