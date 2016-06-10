

using System;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds
{
    /// <summary>
    /// Provides access to the current time in UTC. This doesn't necessarily
    /// need to be wall-clock time, but rather the current time in some system
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>
        /// Gets the current time in UTC
        /// </summary>
        /// <returns>The current time in UTC</returns>
        DateTime GetUtcNow();
    }
}