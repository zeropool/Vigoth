
using System;
using NodaTime;
namespace VigiothCapital.QuantTrader
{
    /// <summary>
    /// Event arguments class for the <see cref="LocalTimeKeeper.TimeUpdated"/> event
    /// </summary>
    public sealed class TimeUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the new time
        /// </summary>
        public readonly DateTime Time;
        /// <summary>
        /// Gets the time zone
        /// </summary>
        public readonly DateTimeZone TimeZone;
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeUpdatedEventArgs"/> class
        /// </summary>
        /// <param name="time">The newly updated time</param>
        /// <param name="timeZone">The time zone of the new time</param>
        public TimeUpdatedEventArgs(DateTime time, DateTimeZone timeZone)
        {
            Time = time;
            TimeZone = timeZone;
        }
    }
}