

using System;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds
{
    /// <summary>
    /// Event arguments for the <see cref="TextSubscriptionFactory.CreateStreamReader"/> event
    /// </summary>
    public sealed class CreateStreamReaderErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the date of the source
        /// </summary>
        public DateTime Date
        {
            get; private set;
        }

        /// <summary>
        /// Gets the source that caused the error
        /// </summary>
        public SubscriptionDataSource Source
        {
            get; private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStreamReaderErrorEventArgs"/> class
        /// </summary>
        /// <param name="date">The date of the source</param>
        /// <param name="source">The source that cause the error</param>
        public CreateStreamReaderErrorEventArgs(DateTime date, SubscriptionDataSource source)
        {
            Date = date;
            Source = source;
        }
    }
}