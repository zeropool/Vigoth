

using System;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds
{
    /// <summary>
    /// Provides an implementation of <see cref="ITimeProvider"/> that
    /// uses <see cref="DateTime.UtcNow"/> to provide the current time
    /// </summary>
    public sealed class RealTimeProvider : ITimeProvider
    {
        /// <summary>
        /// Gets the current time in UTC
        /// </summary>
        /// <returns>The current time in UTC</returns>
        public DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}