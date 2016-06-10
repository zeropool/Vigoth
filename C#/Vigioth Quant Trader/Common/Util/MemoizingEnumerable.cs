
using System;
using System.Collections;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Defines an enumerable that can be enumerated many times while
    /// only performing a single enumeration of the root enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MemoizingEnumerable<T> : IEnumerable<T>
    {
        private bool _finished;
        private readonly List<T> _buffer;
        private readonly IEnumerator<T> _enumerator;
        private readonly object _lock = new object();
        /// <summary>
        /// Initializes a new instance of the <see cref="MemoizingEnumerable{T}"/> class
        /// </summary>
        /// <param name="enumerable">The source enumerable to be memoized</param>
        public MemoizingEnumerable(IEnumerable<T> enumerable)
            : this(enumerable.GetEnumerator())
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MemoizingEnumerable{T}"/> class
        /// </summary>
        /// <param name="enumerator">The source enumerator to be memoized</param>
        public MemoizingEnumerable(IEnumerator<T> enumerator)
        {
            _buffer = new List<T>();
            _enumerator = enumerator;
        }
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (true)
            {
                bool hasValue;
                // sync for multiple threads access to _enumerator and _buffer
                lock (_lock)
                {
                    // check to see if we need to move next
                    if (!_finished && i >= _buffer.Count)
                    {
                        hasValue = _enumerator.MoveNext();
                        if (hasValue)
                        {
                            _buffer.Add(_enumerator.Current);
                        }
                        else
                        {
                            _finished = true;
                        }
                    }
                    else
                    {
                        // we have a value if it's in the buffer
                        hasValue = _buffer.Count > i;
                    }
                }
                // yield the i'th element if we have it, otherwise stop enumeration
                if (hasValue)
                {
                    yield return _buffer[i];
                }
                else
                {
                    yield break;
                }
                // increment for next time
                i++;
            }
        }
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
