

using System;
using System.Collections;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators
{
    /// <summary>
    /// Provides augmentation of how often an enumerator can be called. Time is measured using
    /// an <see cref="ITimeProvider"/> instance and calls to the underlying enumerator are limited
    /// to a minimum time between each call.
    /// </summary>
    public class RateLimitEnumerator : IEnumerator<BaseData>
    {
        private BaseData _current;
        private DateTime _lastCallTime;

        private readonly ITimeProvider _timeProvider;
        private readonly IEnumerator<BaseData> _enumerator;
        private readonly TimeSpan _minimumTimeBetweenCalls;

        /// <summary>
        /// Initializes a new instance of the <see cref="RateLimitEnumerator"/> class
        /// </summary>
        /// <param name="enumerator">The underlying enumerator to place rate limits on</param>
        /// <param name="timeProvider">Time provider used for determing the time between calls</param>
        /// <param name="minimumTimeBetweenCalls">The minimum time allowed between calls to the underlying enumerator</param>
        public RateLimitEnumerator(IEnumerator<BaseData> enumerator, ITimeProvider timeProvider, TimeSpan minimumTimeBetweenCalls)
        {
            _enumerator = enumerator;
            _timeProvider = timeProvider;
            _minimumTimeBetweenCalls = minimumTimeBetweenCalls;
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
        public bool MoveNext()
        {
            // determine time since last successful call, do this on units of the minimum time
            // this will give us nice round emit times
            var currentTime = _timeProvider.GetUtcNow().RoundDown(_minimumTimeBetweenCalls);
            var timeBetweenCalls = currentTime - _lastCallTime;

            // if within limits, patch it through to move next
            if (timeBetweenCalls >= _minimumTimeBetweenCalls)
            {
                if (!_enumerator.MoveNext())
                {
                    // our underlying is finished
                    _current = null;
                    return false;
                }

                // only update last call time on non rate limited requests
                _lastCallTime = currentTime;
                _current = _enumerator.Current;
            }
            else
            {
                // we've been rate limitted
                _current = null;
            }

            return true;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
        public void Reset()
        {
            _enumerator.Reset();
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <returns>
        /// The element in the collection at the current position of the enumerator.
        /// </returns>
        public BaseData Current
        {
            get { return _current; }
        }

        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        /// <returns>
        /// The current element in the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        object IEnumerator.Current
        {
            get { return _current; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            _enumerator.Dispose();
        }
    }
}