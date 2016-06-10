
using System;
using NodaTime;
namespace VigiothCapital.QuantTrader
{
    /// <summary>
    /// Represents the current local time. This object is created via the <see cref="TimeKeeper"/> to
    /// manage conversions to local time.
    /// </summary>
    public class LocalTimeKeeper
    {
        private Lazy<DateTime> _localTime;
        private readonly DateTimeZone _timeZone;
        /// <summary>
        /// Event fired each time <see cref="UpdateTime"/> is called
        /// </summary>
        public event EventHandler<TimeUpdatedEventArgs> TimeUpdated;
        /// <summary>
        /// Gets the time zone of this <see cref="LocalTimeKeeper"/>
        /// </summary>
        public DateTimeZone TimeZone
        {
            get { return _timeZone; }
        }
        /// <summary>
        /// Gets the current time in terms of the <see cref="TimeZone"/>
        /// </summary>
        public DateTime LocalTime
        {
            get { return _localTime.Value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalTimeKeeper"/> class
        /// </summary>
        /// <param name="utcDateTime">The current time in UTC</param>
        /// <param name="timeZone">The time zone</param>
        internal LocalTimeKeeper(DateTime utcDateTime, DateTimeZone timeZone)
        {
            _timeZone = timeZone;
            _localTime = new Lazy<DateTime>(() => utcDateTime.ConvertTo(DateTimeZone.Utc, _timeZone));
        }
        /// <summary>
        /// Updates the current time of this time keeper
        /// </summary>
        /// <param name="utcDateTime">The current time in UTC</param>
        internal void UpdateTime(DateTime utcDateTime)
        {
            // redefine the lazy conversion each time this is set
            _localTime = new Lazy<DateTime>(() => utcDateTime.ConvertTo(DateTimeZone.Utc, _timeZone));
            if (TimeUpdated != null)
            {
                TimeUpdated(this, new TimeUpdatedEventArgs(_localTime.Value, TimeZone));
            }
        }
    }
}