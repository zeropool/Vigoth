//    Copyright 2006, 2007, 2008 East Tech Incorporated
//
//    This file is part of FIX4NET.
//
//    FIX4NET is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Lesser General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    FIX4NET is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with FIX4NET.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Threading;

#if NET_2_0
using System.Collections.Generic;
#else
using System.Collections;
#endif

namespace FIX4NET
{
	public class MessageQueueSignal : IMessageQueue
	{

#if NET_2_0
		private Queue<IMessage> _queue = new Queue<IMessage>();
#else
		private Queue _queue = new Queue();
#endif

		private object _lock = new object();
		private bool _disposed;

		public int Count { get { return _queue.Count; } }

		public void Clear()
		{
			lock (_lock)
			{
				_queue.Clear();
			}
		}

		public void Enqueue(IMessage message)
		{
			lock (_lock)
			{
				_queue.Enqueue(message);
				Monitor.Pulse(_lock);
			}
		}

		public IMessage DequeueBlocked()
		{
			IMessage message = null;

			lock (_lock)
			{
				while (_queue.Count == 0 && !_disposed)
					Monitor.Wait(_lock);

				if (_queue.Count != 0 && !_disposed)
#if NET_2_0
					message = _queue.Dequeue();
#else
					message = (IMessage)_queue.Dequeue();
#endif
			}

			return message;
		}

		public IMessage DequeueBlocked(int milliseconds)
		{
			IMessage message = null;

			lock (_lock)
			{
				if (_queue.Count == 0 && !_disposed)
					Monitor.Wait(_lock, milliseconds);

				if (_queue.Count != 0 && !_disposed)
#if NET_2_0
					message = _queue.Dequeue();
#else
					message = (IMessage)_queue.Dequeue();
#endif
			}

			return message;
		}

		public void Dispose()
		{
			_disposed = true;
			lock (_lock)
			{
				Monitor.Pulse(_lock);
			}
		}
	}
}
