
using System.Collections;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Provides an implementation of an add-only fixed length, unique queue system
    /// </summary>
    public class FixedSizeHashQueue<T> : IEnumerable<T>
    {
        private readonly int _size;
        private readonly Queue<T> _queue; 
        private readonly HashSet<T> _hash; 
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedSizeHashQueue{T}"/> class
        /// </summary>
        /// <param name="size">The maximum number of items to hold</param>
        public FixedSizeHashQueue(int size)
        {
            _size = size;
            _queue = new Queue<T>(size);
            _hash = new HashSet<T>();
        }
        /// <summary>
        /// Returns true if the item was added and didn't already exists
        /// </summary>
        public bool Add(T item)
        {
            if (_hash.Add(item))
            {
                _queue.Enqueue(item);
                if (_queue.Count > _size)
                {
                    // remove the item from both
                    _hash.Remove(_queue.Dequeue());
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Tries to inspect the first item in the queue
        /// </summary>
        public bool TryPeek(out T item)
        {
            if (_queue.Count > 0)
            {
                item = _queue.Peek();
                return true;
            }
            item = default(T);
            return false;
        }
        /// <summary>
        /// Dequeues and returns the next item in the queue
        /// </summary>
        public T Dequeue()
        {
            var item = _queue.Dequeue();
            _hash.Remove(item);
            return item;
        }
        /// <summary>
        /// Returns true if the specified item exists in the collection
        /// </summary>
        public bool Contains(T item)
        {
            return _hash.Contains(item);
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
            return _queue.GetEnumerator();
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