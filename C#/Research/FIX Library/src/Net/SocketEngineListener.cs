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

namespace FIX4NET.Net
{
	public class SocketEngineListener : IEngineConnector
	{
        private TimeSpan _connectTime;
        private TimeSpan _disconnectTime;
        private int _port;

        public TimeSpan ConnectTime { get { return _connectTime; } set { _connectTime = value; } }
        public TimeSpan DisconnectTime { get { return _disconnectTime; } set { _disconnectTime = value; } }
        public int Port { get { return _port; } set { _port = value; } }

		public void SetConfig(string name, object value)
		{
		}

		public void SetEngine(IEngine engine)
		{
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}

		public void Dispose()
		{
		}
	}
}
