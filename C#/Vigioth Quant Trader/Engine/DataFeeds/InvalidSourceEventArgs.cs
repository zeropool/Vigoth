

using System;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds
{
    /// <summary>
    /// Event arguments for the <see cref="ISubscriptionFactory.InvalidSource"/> event
    /// </summary>
    public sealed class InvalidSourceEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the source that was considered invalid
        /// </summary>
        public SubscriptionDataSource Source
        {
            get; private set;
        }

        /// <summary>
        /// Gets the exception that was encountered
        /// </summary>
        public Exception Exception
        {
            get; private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSourceEventArgs"/> class
        /// </summary>
        /// <param name="source">The source that was considered invalid</param>
        /// <param name="exception">The exception that was encountered</param>
        public InvalidSourceEventArgs(SubscriptionDataSource source, Exception exception)
        {
            Source = source;
            Exception = exception;
        }
    }
}