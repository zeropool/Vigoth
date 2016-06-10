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
using System.Net;
using System.Net.Sockets;
#if NET_2_0
using System.Collections.Generic;
#else
using System.Collections;
#endif

namespace FIX4NET.Net
{
	/// <summary>
	/// Summary description for SocketLogonArgs.
	/// </summary>
	public class SocketLogonArgs : ILogonArgs
	{
        private FieldCollection _fields = new FieldCollection();

        public void AddField(IField field)
        {
            _fields.Add(field);
        }

        public FieldCollection GetFields()
        {
            return _fields;
        }

		private string _sHost;
		public string Host 
		{
			get { return _sHost; }
			set { _sHost = value; }
		}

		private IPAddress _ipAddress;
		public IPAddress IPAddress 
		{
			get { return _ipAddress; }
			set { _ipAddress = value; }
		}

		private int _iPort;
		public int Port 
		{
			get { return _iPort; }
			set { _iPort = value; }
		}

		private IPEndPoint _ipEndPoint;
		public IPEndPoint IPEndPoint 
		{
			get { return _ipEndPoint; }
			set { _ipEndPoint = value; }
		}

		private Socket _socket;
		public Socket Socket 
		{
			get { return _socket; }
			set { _socket = value; }
		}

		private IMessageLogon _messageLogon;
		public IMessageLogon MessageLogon
		{
			get { return _messageLogon; }
			set { _messageLogon = value; }
		}
	}
}
