

using System;
using NodaTime;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds
{
    /// <summary>
    /// Provides an implementation of <see cref="ITimeProvider"/> that can be
    /// manually advanced through time
    /// </summary>
    public class ManualTimeProvider : ITimeProvider
    {
        private DateTime _currentTime;
        private readonly DateTimeZone _setCurrentTimeTimeZone;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManualTimeProvider"/>
        /// </summary>
        /// <param name="setCurrentTimeTimeZone">Specify to use this time zone when calling <see cref="SetCurrentTime"/>,
        /// leave null for the deault of <see cref="TimeZones.Utc"/></param>
        public ManualTimeProvider(DateTimeZone setCurrentTimeTimeZone = null)
        {
            _setCurrentTimeTimeZone = setCurrentTimeTimeZone ?? TimeZones.Utc;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManualTimeProvider"/> class
        /// </summary>
        /// <param name="currentTime">The current time in the specified time zone, if the time zone is
        /// null then the time is interpreted as being in <see cref="TimeZones.Utc"/></param>
        /// <param name="setCurrentTimeTimeZone">Specify to use this time zone when calling <see cref="SetCurrentTime"/>,
        /// leave null for the deault of <see cref="TimeZones.Utc"/></param>
        public ManualTimeProvider(DateTime currentTime, DateTimeZone setCurrentTimeTimeZone = null)
        {
            _setCurrentTimeTimeZone = setCurrentTimeTimeZone ?? TimeZones.Utc;
            _currentTime = currentTime.ConvertToUtc(_setCurrentTimeTimeZone);
        }

        /// <summary>
        /// Gets the current time in UTC
        /// </summary>
        /// <returns>The current time in UTC</returns>
        public DateTime GetUtcNow()
        {
            return _currentTime;
        }

        /// <summary>
        /// Sets the current time interpreting the specified time as a UTC time
        /// </summary>
        /// <param name="time">The current time in UTC</param>
        public void SetCurrentTimeUtc(DateTime time)
        {
            _currentTime = time;
        }

        /// <summary>
        /// Sets the current time interpeting the specified time as a local time
        /// using the time zone used at instatiation.
        /// </summary>
        /// <param name="time">The local time to set the current time time, will be
        /// converted into UTC</param>
        public void SetCurrentTime(DateTime time)
        {
            _currentTime = time.ConvertToUtc(_setCurrentTimeTimeZone);
        }

        /// <summary>
        /// Advances the current time by the specified span
        /// </summary>
        /// <param name="span">The amount of time to advance the current time by</param>
        public void Advance(TimeSpan span)
        {
            _currentTime += span;
        }

        /// <summary>
        /// Advances the current time by the specified number of seconds
        /// </summary>
        /// <param name="seconds">The number of seconds to advance the current time by</param>
        public void AdvanceSeconds(double seconds)
        {
            Advance(TimeSpan.FromSeconds(seconds));
        }
    }
}