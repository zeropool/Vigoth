
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Util 
{
    /// <summary>
    /// Helper method for a limited length queue which self-removes the extra elements.
    /// http://stackoverflow.com/questions/5852863/fixed-size-queue-which-automatically-dequeues-old-values-upon-new-enques
    /// </summary>
    /// <typeparam name="T">The type of item the queue holds</typeparam>
    public class FixedSizeQueue<T> : Queue<T>
    {
        private int _limit = -1;
        /// <summary>
        /// Max Length 
        /// </summary>
        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }
        /// <summary>
        /// Create a new fixed length queue:
        /// </summary>
        public FixedSizeQueue(int limit)
            : base(limit)
        {
            Limit = limit;
        }
        /// <summary>
        /// Enqueue a new item int the generic fixed length queue:
        /// </summary>
        public new void Enqueue(T item)
        {
            while (Count >= Limit)
            {
                Dequeue();
            }
            base.Enqueue(item);
        }
    }
}