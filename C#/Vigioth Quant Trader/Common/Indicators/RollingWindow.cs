using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
namespace VigiothCapital.QuantTrader.Indicators
{
    public class RollingWindow<T> : IReadOnlyWindow<T>
    {
        private readonly List<T> _list;
        private readonly ReaderWriterLockSlim _listLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        private T _mostRecentlyRemoved;
        private decimal _samples;
        private int _tail;
        public RollingWindow(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException("RollingWindow must have size of at least 1.", "size");
            }
            _list = new List<T>(size);
        }
        public int Size
        {
            get
            { 
                try
                {
                    _listLock.EnterReadLock();
                    return _list.Capacity;
                }
                finally
                {
                    _listLock.ExitReadLock();
                }
            }
        }
        public int Count
        {
            get
            { 
                try
                {
                    _listLock.EnterReadLock();
                    return _list.Count;
                }
                finally
                {
                    _listLock.ExitReadLock();
                }
            }
        }
        public decimal Samples
        {
            get
            { 
                try
                {
                    _listLock.EnterReadLock();
                    return _samples;
                }
                finally
                {
                    _listLock.ExitReadLock();
                }
            }
        }
        public T MostRecentlyRemoved
        {
            get
            {
                try
                {
                    _listLock.EnterReadLock();
                    if (!IsReady)
                    {
                        throw new InvalidOperationException("No items have been removed yet!");
                    }
                    return _mostRecentlyRemoved;
                }
                finally
                {
                    _listLock.ExitReadLock();
                }
            }
        }
        public T this [int i]
        {
            get
            {
                try
                {
                    _listLock.EnterReadLock();
                    if (i >= Count)
                    {
                        throw new ArgumentOutOfRangeException("i", i, string.Format("Must be between 0 and Count {0}", Count));
                    }
                    return _list[(Count + _tail - i - 1) % Count];
                }
                finally
                {
                    _listLock.ExitReadLock();
                }
            }
            set
            {
                try
                {
                    _listLock.EnterWriteLock();
                    if (i >= Count)
                    {
                        throw new ArgumentOutOfRangeException("i", i, string.Format("Must be between 0 and Count {0}", Count));
                    }
                    _list[(Count + _tail - i - 1) % Count] = value;
                }
                finally
                {
                    _listLock.ExitWriteLock();
                }
            }
        }
        public bool IsReady
        {
            get
            { 
                try
                {
                    _listLock.EnterReadLock();
                    return Samples > Size;
                }
                finally
                {
                    _listLock.ExitReadLock();
                } 
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            var temp = new List<T>(Count);
            try
            {
                _listLock.EnterReadLock();
                for (int i = 0; i < Count; i++)
                {
                    temp.Add(this[i]);
                }
                return temp.GetEnumerator();
            }
            finally
            {
                _listLock.ExitReadLock();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            try
            {
                _listLock.EnterWriteLock();
                _samples++;
                if (Size == Count)
                {
                    _mostRecentlyRemoved = _list[_tail];
                    _list[_tail] = item;
                    _tail = (_tail + 1) % Size;
                }
                else
                {
                    _list.Add(item);
                }
            }
            finally
            {
                _listLock.ExitWriteLock();
            }
        }
        public void Reset()
        {
            try
            {
                _listLock.EnterWriteLock();
                _samples = 0;
                _list.Clear();
                _tail = 0;
            }
            finally
            {
                _listLock.ExitWriteLock();
            }
        }
    }
}