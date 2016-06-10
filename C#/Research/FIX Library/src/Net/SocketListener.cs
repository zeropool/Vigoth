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
using System.Threading;
using System.Text;
using System.Collections;

using FIX4NET;

namespace FIX4NET.Net
{
	/// <summary>
	/// Summary description for SocketListener.
	/// </summary>
	public class SocketListener : IDisposable
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private bool _bIsDisposed;
		private Socket _socketListen;
		private Thread _threadListen;
		private int _iConnectTimeout = 5;

		private ArrayList _alEngines = ArrayList.Synchronized(new ArrayList());

		public int ConnectTimeout 
		{
			get { return _iConnectTimeout; }
			set { _iConnectTimeout = value; }
		}

		public void Add(IEngine engine) 
		{
			if (log.IsDebugEnabled)
				log.Debug("Add - Adding an engine");

			_alEngines.Add(engine);
		}

		public void Remove(IEngine engine) 
		{
			if (log.IsDebugEnabled)
				log.Debug("Remove - Removing an engine");

			_alEngines.Remove(engine);
		}

		public void Init(int iPort)
		{
			if (log.IsInfoEnabled)
				log.InfoFormat("Init - Setting up listener / Port={0}", iPort);

			//Bind listener to port
			IPEndPoint ep = new IPEndPoint(IPAddress.Any, iPort);
			_socketListen = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			_socketListen.Bind(ep);
			_socketListen.Listen(10);

			//Start listener thread
			if (log.IsDebugEnabled)
				log.Info("Init - Starting listener thread");
			_threadListen = new Thread(new ThreadStart(Accept));
			_threadListen.Name = "SocketListener.Accept";
			_threadListen.IsBackground = true;
			_threadListen.Start();
		}

		public void Dispose() 
		{
			try 
			{
				_bIsDisposed = true;

				if(_socketListen != null)
					_socketListen.Close();
				_socketListen = null;

				if(_threadListen  != null && _threadListen.IsAlive)
					_threadListen.Join();
				_threadListen = null;

			} 
			catch {}
		}

		private void Accept() 
		{
			try 
			{
				Socket socket;
				while(!_bIsDisposed) 
				{
					if (log.IsDebugEnabled)
						log.Debug("Accept - Waiting for new connection");

					socket = _socketListen.Accept();
					if(socket != null) 
					{
						if (log.IsDebugEnabled)
                            log.Debug("Accept - New socket connection received");

						ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessesNewConnection), socket);
					}
				}
			} 
			catch(Exception ex) 
			{
                if (!_bIsDisposed)
                    log.Error("Accept - Exception caught", ex);
			}
		}

		private void ProcessesNewConnection(object state) 
		{
			ProcessesNewConnection((Socket)state);
		}

		private void ProcessesNewConnection(Socket socket) 
		{
			if (log.IsDebugEnabled)
				log.Debug("--> ProcessesNewConnection");

			bool bSuccess = false;
			IEngine engine;

			if (log.IsDebugEnabled)
                log.DebugFormat("ProcessesNewConnection - Connection information / LocalEndPoint={0} RemoteEndPoint={1}", 
                    socket.LocalEndPoint, socket.RemoteEndPoint);

			try 
			{
				DateTime dtTimeout = DateTime.Now.AddSeconds(_iConnectTimeout);
				byte[] buffer = new byte[4096];
				int iLenReceive;
				StringBuilder sbReceive = new StringBuilder();

				while (!_bIsDisposed && DateTime.Now < dtTimeout && 
					socket.Connected && (sbReceive.Length == 0 || socket.Available > 0))
				{
					if(socket.Available > 0) 
					{
						iLenReceive = socket.Receive(buffer);
						if (iLenReceive > 0) 
						{
							for(int i=0; i < iLenReceive; i++)
								sbReceive.Append((char) buffer[i]);
						}
					}
					else
						Thread.Sleep(100);
				}

				if (sbReceive.Length > 0) 
				{
					string sMessage = sbReceive.ToString();
					if (log.IsDebugEnabled)
						log.DebugFormat("ProcessesNewConnection - Received message / Message={0}", sMessage);

					IMessage message = null;

					//Find corresponding engine for message
					engine = FindRelatedEngine(sMessage);
					if (engine != null)
					{
						IMessageFactory messageFactory = engine.MessageFactory;

						//Validate CheckSum and BodyLen in message
						if (!messageFactory.ValidateFixChecksum(sMessage))
							log.Warn("ProcessesNewConnection - Message failed check sum validation");
						else if (!messageFactory.ValidateBodyLength(sMessage))
							log.Warn("ProcessesNewConnection - Message failed body lenght validation");
						else
						{
							//Parse string to a message object
							if (log.IsDebugEnabled)
								log.DebugFormat("ProcessesNewConnection - Parsing string to message object");
							message = messageFactory.Parse(sMessage);
							message.Direction = MessageDirection.In;

							//Check message recieved is a Logon
							if (!messageFactory.IsLogonMessage(message))
							{
								if (log.IsWarnEnabled)
									log.Warn("ProcessesNewConnection - Message parsed is not a logon type");

								message = null;
							}
						}
					}
					else
					{
						log.Warn("ProcessesNewConnection - Could not find a related engine to process logon message");
					}

					if (message != null)
					{
						SocketLogonArgs args = new SocketLogonArgs();
						args.Socket = socket;
						args.MessageLogon = (IMessageLogon)message;
						engine.Logon(args);
						bSuccess = engine.IsConnected;
					}
				}
				else
				{
					if (log.IsWarnEnabled)
						log.Warn("ProcessesNewConnection - Nothing was received from new connection");
				}
			} 
			catch (Exception ex) 
			{
				log.Error("ProcessesNewConnection - Exception caught", ex);
			}

			if (!bSuccess) 
			{
				log.Info("ProcessesNewConnection - Failed to establish new connection");
				try 
				{
					socket.Close();
				} 
				catch (Exception ex) 
				{
					log.Error("ProcessesNewConnection - Error closing a failed connection", ex);
				}
			}

			if (log.IsDebugEnabled)
				log.Debug("<-- ProcessesNewConnection");
		}

		private IEngine FindRelatedEngine(string sMessage)
		{
			IEngine engine;

			for (int i = _alEngines.Count - 1; i >= 0; i--)
			{
				engine = (IEngine)_alEngines[i];
				if (engine.IsRelatedLogon(sMessage))
				{
					if (log.IsDebugEnabled)
						log.Debug("FindRelatedEngine - Engine has been found");

					return engine;
				}
			}

			if (log.IsDebugEnabled)
				log.Debug("FindRelatedEngine - Engine has NOT been found");

			return null;
		}
	}
}
