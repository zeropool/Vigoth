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
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;

using FIX4NET.Utils;

namespace FIX4NET.Net
{
	/// <summary>
	/// Summary description for SocketEngine.
	/// </summary>
	public class SocketEngine : IEngine
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private bool _bInitialized;
		private bool _bDisposed;

		private string _sSenderCompID, _sSenderSubID;
		private string _sTargetCompID, _sTargetSubID;
		private byte _iTimeZoneOffset;
		private int _iMsgSeqNumIn, _iMsgSeqNumOut;
		private int _iMsgSeqNumInRecover, _iMsgSeqNumOutRecover;
		private int _iHeartBtInt = 30;
		private int _iMessageTimeout = 5;
		private bool _bAllowOfflineSend;

		private IMessageCacheFactory _messageCacheFactory;
		private IMessageCache _messageCache;
		protected IMessageFactory _messageFactory;

		private bool _bConnect;
		private bool _bLogon;
		private LogoutType _logoutType = LogoutType.None;
		private object _lockLogout = new object();
		private DateTime _dtLogoutReceived;

		private Socket _socket;
		private Thread _threadReceive;
		private Thread _threadSend;
		private object _lockSend = new object();
		private IMessageQueue _qPendingSend = new MessageQueueSignal();

		private DateTime _dtReceiveLast;
		private DateTime _dtSendLast;
		private DateTime _dtTestRequestSentLast;
		private int _iTestRequestCount;
		private Thread _threadHeartbeat;

        protected int _lastResendRequestBeginSeqNo;
        protected DateTime _lastResendRequestTimestamp = DateTime.MinValue;

		private IMessageQueue _qProcessedMessages = new MessageQueueSignal();
		private Thread _threadMessageEvent;

		private Thread _threadEndOfDay;

		private const char TAG_DELIM = '=';
		private const char FIELD_DELIM = (char)1;
		private const string TAG_CHECKSUM = "10";
		private const int SEND_BUFFER_LENGTH = 1024;

		private enum LogoutType
		{
			None,
			Client,
			Server,
		}

        public int MessageTimeout { get { return _iMessageTimeout; } set { _iMessageTimeout = value; } }

		public SocketEngine()
		{
			MessageEventLoopStart();
			EndOfDayStart();
		}

		public void Dispose()
		{
			_bDisposed = true;
			try
			{
				Logout("DISPOSE");
			}
			catch { }
			try
			{
				MessageEventLoopStop();
			}
			catch { }
			try
			{
				EndOfDayStop();
			}
			catch { }
			try
			{
				MessageCacheDispose();
			}
			catch { }
		}

		#region IEngine Members

		public event EngineEventHandler LogonAfter;
		public event EngineEventHandler LogoutAfter;
		public event MessageEventHandler Received;
		public event MessageEventHandler Sent;
		public event EngineEventHandler EndOfDayBefore;
		public event EngineEventHandler EndOfDayAfter;

		public void Initialize(string sSenderCompID, string sTargetCompID)
		{
			Initialize(sSenderCompID, null, sTargetCompID, null, 0);
		}

		public void Initialize(string sSenderCompID, string sTargetCompID, byte iTimeZoneOffset)
		{
			Initialize(sSenderCompID, null, sTargetCompID, null, iTimeZoneOffset);
		}

		public void Initialize(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID)
		{
			Initialize(sSenderCompID, sSenderSubID, sTargetCompID, sTargetSubID, 0);
		}

		public void Initialize(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID, byte iTimeZoneOffset)
		{
            if (log.IsDebugEnabled) 
                log.DebugFormat("Initialize - SenderCompID={0} SenderSubID={1} TargetCompID={2} TargetSubID={3} TimeZoneOffset={4}", 
                    sSenderCompID, sSenderSubID, sTargetCompID, sTargetSubID, iTimeZoneOffset);

			if (_bInitialized)
				throw new Exception("Instance already initialized");

            if (_messageFactory == null)
                throw new Exception("MessageFactory has not been intialized");

            if (_messageCacheFactory == null)
                throw new Exception("MessageCacheFactory has not been intialized");

			_bInitialized = true;

			_sSenderCompID = sSenderCompID;
			_sSenderSubID = sSenderSubID;
			_sTargetCompID = sTargetCompID;
			_sTargetSubID = sTargetSubID;
			_iTimeZoneOffset = iTimeZoneOffset;

			MessageCacheInit();
		}

		public bool IsRelatedLogon(string sMessage)
		{
			bool bRelated = false;

			if (_bInitialized)
			{
				if (_messageFactory.IsRelatedMessage(sMessage))
				{
					IMessage message = _messageFactory.Parse(sMessage);
					if (_messageFactory.IsLogonMessage(message))
					{
						bRelated = CompareTargetIsMe(message);
					}
				}
			}

			return bRelated;
		}

		private bool CompareTargetIsMe(IMessage message)
		{
			return message.TargetCompID == _sSenderCompID && message.TargetSubID == _sSenderSubID &&
				message.SenderCompID == _sTargetCompID && message.SenderSubID == _sTargetSubID;
		}

		public void Logon(ILogonArgs logonArgs)
		{
			if (!_bInitialized)
				throw new Exception("Engine has not been initialized");
			if (_bDisposed)
				throw new Exception("Engine has been disposed");
			if (_bConnect || _bLogon)
				throw new Exception("Can not connect when a connection is currently open");
			if (!(logonArgs is SocketLogonArgs))
				throw new InvalidCastException("LogonArgs must be of type SocketLogonArgs");

			Logon((SocketLogonArgs)logonArgs);
		}

		private void Logon(SocketLogonArgs logonArgs)
		{
			if (log.IsDebugEnabled)
				log.Debug("--> Logon");

			if (log.IsInfoEnabled)
				log.Info("Logon - Logon has been called");

			Socket socket = logonArgs.Socket;
			if (socket == null && logonArgs.MessageLogon != null)
			{
				if (log.IsWarnEnabled)
					log.Warn("Logon - Attempt to logon supplying only logon message w/o socket was not allowed");
				throw new Exception("Logon message can not be specified without supplying the socket it was received on");
			}
			else if (socket == null)
			{
				socket = CreateSocket(logonArgs);
			}
			else if (logonArgs.MessageLogon != null)
			{
				if (log.IsDebugEnabled)
					log.Debug("Logon - Testing logon message cridentials match");
				if (!CompareTargetIsMe(logonArgs.MessageLogon))
				{
					if (log.IsWarnEnabled)
						log.Warn("Logon - Logon message did not have the same cridentials");
					throw new Exception("Logon message was not for this engine");
				}

				_iHeartBtInt = logonArgs.MessageLogon.HeartBtInt;
			}

			try
			{
				_socket = socket;
				if (_socket == null || !_socket.Connected)
					throw new Exception("Socket is not initialized");
				if (log.IsInfoEnabled)
					log.InfoFormat("Logon(Socket) - Socket information / LocalEndPoint={0} RemoteEndPoint={1}",
						_socket.LocalEndPoint.ToString(), _socket.RemoteEndPoint.ToString());

				SetSocketOptions();

				_qPendingSend.Clear();
				_bConnect = true;
				_logoutType = LogoutType.None;
				_dtReceiveLast = DateTime.Now;
				_dtSendLast = DateTime.Now;
                _lastResendRequestBeginSeqNo = 0;
                _lastResendRequestTimestamp = DateTime.MinValue;

				//Send logon message to remote machine
				if (log.IsDebugEnabled)
					log.Debug("Logon - Sending logon message to remote machine");
				IMessageLogon logon = _messageFactory.CreateInstanceLogon();
				logon.HeartBtInt = _iHeartBtInt;
                foreach (IField field in logonArgs.GetFields())
                    logon.Fields.Add(field);
				Send(logon, true);

				if (logonArgs.MessageLogon != null)
				{
					//Process logon message received
					if (log.IsDebugEnabled)
						log.Debug("Logon - Process logon message received");
					ReceiveMessage(logonArgs.MessageLogon);
				}

				//Start send/receive threads
				ReceiveLoopStart();
				SendLoopStart();

				//Wait timeout period for Logon to complete.
				DateTime dtStart = DateTime.Now;
				while (!_bLogon && DateTime.Now <= dtStart.AddSeconds(_iMessageTimeout))
					Thread.Sleep(10);

				if (_bLogon)
				{
					HeartbeatLoopStart();
					RaiseLogonAfterEvent();
				}
			}
			finally
			{
				//If the logon failed cleanup
				if (!_bLogon)
				{
					if (log.IsWarnEnabled)
						log.Warn("Logon - Failed to logon");
					Logout("CLEANUP");
				}
			}

			if (log.IsDebugEnabled)
				log.Debug("<-- Logon");
		}

		private Socket CreateSocket(SocketLogonArgs logonArgs)
		{
			if (log.IsDebugEnabled)
				log.Debug("CreateSocket - Creating socket and connecting");

			IPEndPoint ep = logonArgs.IPEndPoint;
			if (ep == null)
			{
				IPAddress ipAddress = logonArgs.IPAddress;
				if (ipAddress == null)
				{
					string sHost = logonArgs.Host;
					if (sHost != null && sHost.Length > 0)
					{
						IPHostEntry ipHostEntry;
#if NET_2_0
						ipHostEntry = System.Net.Dns.GetHostEntry(logonArgs.Host);
#else
							ipHostEntry = System.Net.Dns.GetHostByName(logonArgs.Host);
#endif
						if (ipHostEntry != null && ipHostEntry.AddressList != null && ipHostEntry.AddressList.Length > 0)
						{
							ipAddress = ipHostEntry.AddressList[0];
						}
					}
				}
				if (ipAddress != null)
					ep = new IPEndPoint(ipAddress, logonArgs.Port);
				else
					throw new Exception("Failed to determine IP Address");
			}

			Socket socket = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			if (log.IsDebugEnabled)
				log.DebugFormat("CreateSocket - Connecting Socket / RemoteEndPoint={0}", ep.ToString());
			socket.Connect(ep);

			return socket;
		}

		private void RaiseLogonAfterEvent()
		{
			if (LogonAfter != null)
			{
				try
				{
					LogonAfter(this);
				}
				catch (Exception ex)
				{
					log.Error("Logon - Error raising event LogonAfter", ex);
				}
			}
		}

		private void SetSocketOptions()
		{
			if (log.IsDebugEnabled)
				log.DebugFormat("Logon - NoDelay={0} KeepAlive={1} Send Buffer={2} Timeout={3} Receive Buffer={4} Timeout={5}",
					_socket.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout));
			_socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, 1);
			_socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, 65536); // 64KB Buffer
			_socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, 65536); // 64KB Buffer
			if (log.IsDebugEnabled)
				log.DebugFormat("Logon - NoDelay={0} KeepAlive={1} Send Buffer={2} Timeout={3} Receive Buffer={4} Timeout={5}",
					_socket.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer),
					_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout));
		}

		public void Logout(string sText)
		{
			if (log.IsDebugEnabled)
				log.Debug("--> Logout");

			bool bLogon;

			lock (_lockLogout)
			{
				//Check if Logout was already called
				if (!_bConnect)
				{
					if (log.IsDebugEnabled)
						log.Debug("Logout - Abort Logout while not connected");
					return;
				}

				if (log.IsInfoEnabled)
					log.Info("Logout - Logout has been called");

				bLogon = _bLogon;

				if (_logoutType == LogoutType.None)
					_logoutType = LogoutType.Client;

				if (bLogon)
					SendLogoutMessage(sText);

				_bLogon = false;
				_bConnect = false;
			}

			SocketClose();
			HeartbeatLoopStop();
			SendLoopStop();
			ReceiveLoopStop();

			if (bLogon)
				RaiseLogoutAfterEvent();

			if (log.IsDebugEnabled)
				log.Debug("<-- Logout");
		}

		private void RaiseLogoutAfterEvent()
		{
			if (LogoutAfter != null)
			{
				try
				{
					LogoutAfter(this);
				}
				catch (Exception ex)
				{
					log.Error("Logout - Error raising event LogoutAfter", ex);
				}
			}
		}

		private void SendLogoutMessage(string sText)
		{
			if (log.IsDebugEnabled)
				log.Debug("SendLogoutMessage - Sending logout message to server");

			IMessageLogout msgLogout = _messageFactory.CreateInstanceLogout();
			msgLogout.Text = sText;
			Send(msgLogout, true);

			DateTime dtStart = DateTime.Now;
			DateTime dtTimeout = dtStart.AddSeconds(_iMessageTimeout);
			if (_logoutType == LogoutType.Client)
			{
				while (dtStart > _dtLogoutReceived && DateTime.Now <= dtTimeout)
					Thread.Sleep(10);
				if (dtStart > _dtLogoutReceived)
				{
					if (log.IsInfoEnabled)
						log.Info("Logout - Never received logout message back from server");
				}
			}
			else if (_logoutType == LogoutType.Server)
			{
				while (_qPendingSend.Count > 0 && DateTime.Now <= dtTimeout)
					Thread.Sleep(10);
			}
		}

		public bool AllowOfflineSend
		{
			get { return _bAllowOfflineSend; }
			set { _bAllowOfflineSend = value; }
		}

		public virtual void Send(IMessage message)
		{
			Send(message, false);
		}

        private bool IsSendAvailable(bool bLogonOverride)
        {
            if (_bLogon && _logoutType == LogoutType.None)
                return true;
            else if (_bConnect && bLogonOverride)
                return true;
            else if (_bInitialized && _bAllowOfflineSend)
                return true;
            else
                return false;
        }

		private void Send(IMessage message, bool bLogonOverride)
		{
            if (!IsSendAvailable(bLogonOverride))
            {
                log.WarnFormat("Send - Send is not allowed in the current state / Logon={0} LogoutType={1}", 
                    _bLogon, _logoutType);
                throw new Exception("Sending message is not allowed in the current state");
            }

			bool bNewMessage = true;
			int iMsgSeqNo = message.MsgSeqNum;

			message.Direction = MessageDirection.Out;
			message.SenderCompID = _sSenderCompID;
			if (_sSenderSubID != null && _sSenderSubID.Length > 0)
				message.SenderSubID = _sSenderSubID;
			message.TargetCompID = _sTargetCompID;
			if (_sTargetSubID != null && _sTargetSubID.Length > 0)
				message.TargetSubID = _sTargetSubID;
			if (message.PossDupFlag)
				message.OrigSendingTime = message.SendingTime;
            message.SendingTime = DateTime.Now.ToUniversalTime();

			lock (_lockSend)
			{
				if (iMsgSeqNo == 0)
				{
					_iMsgSeqNumOut += 1;
					message.MsgSeqNum = _iMsgSeqNumOut;
				}
				else if (iMsgSeqNo > _iMsgSeqNumOut)
					_iMsgSeqNumOut = iMsgSeqNo;
				else
					bNewMessage = false;

				_messageFactory.Build(message);

				if (bNewMessage)
				{
					_messageCache.AddMessage(message);
					_qProcessedMessages.Enqueue(message);
				}

				if (_bConnect)
					_qPendingSend.Enqueue(message);
			}
		}

		public int MsgSeqNumIn
		{
			get { return _iMsgSeqNumIn; }
		}

		public int MsgSeqNumOut
		{
			get { return _iMsgSeqNumOut; }
		}

		public int MsgSeqNumInRecover
		{
			get { return _iMsgSeqNumInRecover; }
		}

		public int MsgSeqNumOutRecover
		{
			get { return _iMsgSeqNumOutRecover; }
		}

        public IMessageCacheFactory MessageCacheFactory
        {
            get { return _messageCacheFactory; }
            set { _messageCacheFactory = value; }
        }

		public IMessageCache Messages
		{
			get { return _messageCache; }
		}

		public IMessageFactory MessageFactory
		{
			get { return _messageFactory; }
            set { _messageFactory = value; }
		}

		public string SenderCompID
		{
			get { return _sSenderCompID; }
		}

		public string SenderSubID
		{
			get { return _sSenderSubID; }
		}

		public string TargetCompID
		{
			get { return _sTargetCompID; }
		}

		public string TargetSubID
		{
			get { return _sTargetSubID; }
		}

		public byte TimeZoneOffset
		{
			get { return _iTimeZoneOffset; }
		}

		public bool IsConnected
		{
			get { return _bLogon; }
		}

		public int HeartBtInt
		{
			get { return _iHeartBtInt; }
			set { _iHeartBtInt = value; }
		}

		#endregion

		private void LogoutThreadPool(object oText)
		{
			Logout((string)oText);
		}

		private void LogoutAsynchronous(string sText)
		{
			bool bConnect;
			lock (_lockLogout)
			{
				bConnect = _bConnect;
			}
			if (!bConnect)
			{
				if (log.IsDebugEnabled)
					log.Debug("LogoutAsynchronous - Abort background logout because engine is NOT connected");
				return;
			}

			if (log.IsDebugEnabled)
				log.Debug("LogoutAsynchronous - Starting background logout because engine is connected");
			ThreadPool.QueueUserWorkItem(new WaitCallback(LogoutThreadPool), sText);
		}

		private void SocketClose()
		{
			Socket socket = _socket;
			_socket = null;
			if (socket != null)
			{
                if (log.IsDebugEnabled) log.Debug("SocketClose - Clocing socket connection");

				try
				{
					socket.Shutdown(SocketShutdown.Both);
				}
				catch (Exception ex)
				{
					log.Warn("SocketClose - Error on Socket.Shutdown", ex);
				}
				try
				{
					socket.Close();
				}
				catch (Exception ex)
				{
					log.Warn("SocketClose - Error on Socket.Close", ex);
				}
			}
		}

		#region Receive

		private void ReceiveLoopStart()
		{
			if (log.IsDebugEnabled)
				log.Debug("ReceiveLoopStart - Starting recieve thread");

			_threadReceive = new Thread(new ThreadStart(ReceiveLoop));
#if NET_2_0
			_threadReceive.Name = string.Format("SocketEngine.Receive[{0}]", _threadReceive.ManagedThreadId);
#else
			_threadReceive.Name = "SocketEngine.Receive";
#endif
            _threadReceive.IsBackground = true;
			_threadReceive.Start();
		}

		private void ReceiveLoopStop()
		{
			try
			{
				Thread threadReceive = _threadReceive;
				_threadReceive = null;
				if (threadReceive != null && threadReceive.IsAlive)
				{
					if (log.IsDebugEnabled)
						log.Debug("ReceiveLoopStop - Stopping receive loop thread");
					threadReceive.Join();
				}
			}
			catch (Exception ex)
			{
				log.Error("ReceiveLoopStop - Error stopping receive thread", ex);
			}
		}

        private void ReceiveLoop()
        {
            if (log.IsDebugEnabled)
                log.Debug("--> ReceiveLoop");

            try
            {
                byte[] buffer = new byte[4096];
                int iLenReceive;
                char[] buffer_char = new char[4096];
                StringBuilder sbReceive = new StringBuilder();

                string sFindPrefix = _messageFactory.GetSearchStringMessageEndPrefix();
                string sFindSuffix = _messageFactory.GetSearchStringMessageEndSuffix();
                int iFindStart = 0;
                int iMessageEnd;
                string sMessage;
                bool bParseNext = false;

                do
                {
                    iLenReceive = _socket.Receive(buffer);
                    _dtReceiveLast = DateTime.Now;
                    if (iLenReceive > 0)
                    {
                        for (int i = 0; i < iLenReceive; i++)
                            buffer_char[i] = (char)buffer[i];
                        sbReceive.Append(buffer_char, 0, iLenReceive);

                        do
                        {
                            bParseNext = false;

                            //Find ending prefix
                            iMessageEnd = StringBuilderUtils.Find(sbReceive, sFindPrefix, iFindStart);
                            if (iMessageEnd > 0)
                            {
                                iFindStart = iMessageEnd;
                                //Find ending suffix
                                iMessageEnd = StringBuilderUtils.Find(sbReceive, sFindSuffix, iMessageEnd + sFindPrefix.Length);
                                if (iMessageEnd > 0)
                                {
                                    //Extract the message
                                    iMessageEnd += sFindSuffix.Length;
                                    iFindStart = 0;
                                    sMessage = sbReceive.ToString(0, iMessageEnd);
                                    sbReceive.Remove(0, iMessageEnd);

                                    if (log.IsDebugEnabled)
                                        log.DebugFormat("ReceiveLoop - Message parsed from stream / Message={0}", sMessage);

                                    //Process the message
                                    ReceiveMessage(sMessage);

                                    //Check if StringBuilder has more messages
                                    if (sbReceive.Length > sFindPrefix.Length)
                                        bParseNext = true;
                                }
                            }
                            else
                            {
                                //Set the search position to start at end to not waste time searching the same stuff
                                iFindStart = sbReceive.Length - sFindPrefix.Length;
                                if (iFindStart < 0) iFindStart = 0;
                            }

                        } while (bParseNext);
                    }
                } while (iLenReceive > 0);

                LogoutAsynchronous("CLEANUP");
            }
            catch (LogoutException ex)
            {
                log.Error("ReceiveLoop - LogoutException caught", ex);
                LogoutAsynchronous(ex.LogoutText);
            }
            catch (SocketException ex)
            {
                if (_logoutType == LogoutType.None)
                {
                    log.Error("ReceiveLoop - SocketException caught", ex);
                    LogoutAsynchronous("UNKOWN ERROR");
                }
                else
                    if (log.IsDebugEnabled)
                        log.DebugFormat("ReceiveLoop - Expected SocketException caught / LogoutType={0} SocketException={1}", _logoutType, ex);
            }
            catch (Exception ex)
            {
                log.Error("ReceiveLoop - Exception caught", ex);
                LogoutAsynchronous("UNKOWN ERROR");
            }

            if (log.IsDebugEnabled)
                log.Debug("<-- ReceiveLoop");
        }

		private void ReceiveMessage(string sMessage)
		{
			if (!_messageFactory.ValidateFixChecksum(sMessage))
			{
				log.Warn("ReceiveMessage - Message failed check sum validation");
				SendResendRequest();
			}
			else if (!_messageFactory.ValidateBodyLength(sMessage))
			{
				log.Warn("ReceiveMessage - Message failed body lenght validation");
				SendResendRequest();
			}
			else
			{
				IMessage message = null;
				bool bValid = false;
				IMessageReject reject = null;
				try
				{
					message = _messageFactory.Parse(sMessage);
					message.Direction = MessageDirection.In;
					bValid = true;
				}
				catch (ParseFieldException ex)
				{
					log.Error("ReceiveMessage(string) - ParseFieldException caught", ex);
					reject = _messageFactory.CreateInstanceReject(ex);
				}
				catch (Exception ex)
				{
					log.Error("ReceiveMessage(string) - Error parsing message", ex);
				}
				if (!bValid)
				{
					if (log.IsWarnEnabled)
						log.WarnFormat("ReceiveMessage(string) - Detected a bad message unable to process / Message={0}", sMessage);

					message = null;
					int iMsgSeqNum = _messageFactory.ParseMsgSeqNum(sMessage);
					if (iMsgSeqNum > 0)
					{
						if (log.IsDebugEnabled)
							log.DebugFormat("ReceiveMessage(string) - Sending Reject for a bad messsage / MsgSeqNum(Bad)={0}", iMsgSeqNum);
						//Build reject message if not already done
						if (reject == null)
						{
							reject = _messageFactory.CreateInstanceReject();
							reject.RefSeqNum = iMsgSeqNum;
							reject.Text = "FAILED PARSING MESSAGE";
						}
						//Send reject message
						Send(reject);

						//Create a dummy message as place holder for the bad message;
						message = _messageFactory.CreateInstanceHeartbeat();
						message.Direction = MessageDirection.In;
						message.MsgSeqNum = iMsgSeqNum;
						_messageFactory.Build(message);
					}
				}
				if (message != null)
					ReceiveMessage(message);
			}
		}

		//TODO:  Process SequeneReset(Reset)
		private void ReceiveMessage(IMessage message)
		{
			if (log.IsDebugEnabled)
				log.Debug("--> ReceiveMessage");

			int iMsgSeqNum = message.MsgSeqNum;

			//Check if MSN is less then expected.
			if (iMsgSeqNum <= _iMsgSeqNumIn && !message.PossDupFlag)
			{
				//Received MSN out of sequence.  Fatal error and must disconnect.
				if (log.IsWarnEnabled)
					log.WarnFormat("ReceiveMessage - Received MsgSeqNo less then expected with PossDupFlag set to fales / MesgSeqNum(Received)={0}, MsgSeqNum(Expected)={1}", iMsgSeqNum, _iMsgSeqNumIn + 1);
				string sMessage = string.Format("Received MsgSeqNo less then expected with PossDupFlag set to fales / MesgSeqNum(Received)={0}, MsgSeqNum(Expected)={1}", iMsgSeqNum, _iMsgSeqNumIn + 1);
				string sLogoutText = string.Format("MSN LESS THEN EXPECTED - RECEIVED={0} EXPTECTED={1}", iMsgSeqNum, _iMsgSeqNumIn + 1);
				throw new LogoutException(sMessage, sLogoutText);
			}
			else if (!_bLogon)
			{
				if (_messageFactory.IsLogonMessage(message))
				{
					if (log.IsInfoEnabled)
						log.Info("ReceiveMessage - Logon message received");
					_bLogon = true;
				}
				else
				{
					//Did not receive Logon message.  Fatal error and must disconnect.
					if (log.IsWarnEnabled)
						log.WarnFormat("Expected a logon message and received MsgType={0}", message.MsgType);
					string sMessage = string.Format("Expected a logon message and received MsgType={0}", message.MsgType);
					string sLogoutText = string.Format("DID NOT RECEIVE LOGON MESSAGE");
					throw new LogoutException(sMessage, sLogoutText);
				}
			}

			//Check for ResendRequest
			if (_messageFactory.IsResendRequestMessage(message))
			{
				ProcessResendRequest((IMessageResendRequest)message);
			}

			//Check for message out of sequence.
			if (iMsgSeqNum == _iMsgSeqNumIn + 1)
			{
				//Received message in sequence.  Update the incoming MsgSeqNo.
				_iMsgSeqNumIn += 1;

				//Check for SequenceReset message.
				if (_messageFactory.IsSequenceResetMessage(message))
				{
					//Receive a SequenceReset message.  Use the NewSeqNo field to set the incoming MsgSeqNo.
					int iNewSeqNo = ((IMessageSequenceReset)message).NewSeqNo;
					if (iNewSeqNo > _iMsgSeqNumIn)
					{
						//Update the incoming MsgSeqNo.
						_iMsgSeqNumIn = iNewSeqNo - 1;
						if (log.IsInfoEnabled)
							log.InfoFormat("ReceiveMessage - Processed a SequenceReset message / MsgSeqNum(In)={0}", _iMsgSeqNumIn);
					}
					else
					{
						//Received MSN out of sequence.  Fatal error and must disconnect.
						if (log.IsWarnEnabled)
							log.WarnFormat("Received NewSeqNo less then expected / NewSeqNo(Received)={0}, MsgSeqNum(Expected)={1}", iMsgSeqNum, _iMsgSeqNumIn + 1);
						string sMessage = string.Format("Received NewSeqNo less then expected / NewSeqNo(Received)={0}, MsgSeqNum(Expected)={1}", iMsgSeqNum, _iMsgSeqNumIn + 1);
						string sLogoutText = string.Format("MSN LESS THEN EXPECTED - RECEIVED={0} EXPTECTED={1}", iNewSeqNo, _iMsgSeqNumIn + 1);
						throw new LogoutException(sMessage, sLogoutText);
					}
				}

				//Save the message in cache.
				_messageCache.AddMessage(message);

				_qProcessedMessages.Enqueue(message);
			}
			else if (iMsgSeqNum > _iMsgSeqNumIn + 1)
			{
				if (log.IsInfoEnabled)
					log.InfoFormat("ReceiveMessage - Message out of sequence detected / MsgSeqNum(In)={0} MsgSeqNum(Received)={1}", _iMsgSeqNumIn, iMsgSeqNum);
				//Message is out of sequence.  Send a ResendRequest message.
				SendResendRequest();
			}
			else
			{
				if (log.IsDebugEnabled)
					log.DebugFormat("ReceiveMessage - Not processed this message because it was in the wrong sequence / MsgSeqNum={0}", message.MsgSeqNum);
			}

			//Handle TestRequest message.
			if (_messageFactory.IsTestRequestMessage(message))
			{
				if (log.IsDebugEnabled)
					log.Debug("ReceiveMessage - TestRequest message received");
				IMessageTestRequest messageTestRequest = (IMessageTestRequest)message;
				IMessageHeartbeat messageHeartbeat = _messageFactory.CreateInstanceHeartbeat();
				messageHeartbeat.TestReqID = messageTestRequest.TestReqID;
				Send(messageHeartbeat);
			}
			else if (_messageFactory.IsLogoutMessage(message))
			{
				//Receive Logout message.
				if (log.IsInfoEnabled)
					log.Info("ReceiveMessage - Logout message received");

				_dtLogoutReceived = DateTime.Now;
				if (_logoutType == LogoutType.None)
				{
					if (log.IsDebugEnabled)
						log.Debug("ReceiveMessage - Remote side has start logout process");
					_logoutType = LogoutType.Server;
					LogoutAsynchronous("LOGOUT RESPONSE");
				}
			}

			if (log.IsDebugEnabled)
				log.Debug("<-- ReceiveMessage");
		}

		#endregion

		#region Send

		private void SendLoopStart()
		{
			if (log.IsDebugEnabled)
				log.Debug("SendLoopStart - Starting send thread");

			_threadSend = new Thread(new ThreadStart(SendLoop));
			_threadSend.Name = "SocketEngine.SendLoop";
			_threadSend.IsBackground = true;
			_threadSend.Start();
		}

		private void SendLoopStop()
		{
			try
			{
				Thread threadSend = _threadSend;
				_threadSend = null;
				if (threadSend != null && threadSend.IsAlive)
				{
					if (log.IsDebugEnabled)
						log.Debug("SendLoopStop - Stopping send thread");
					threadSend.Join();
				}
			}
			catch (Exception ex)
			{
				log.Error("SendLoopStop - Error stopping send thread", ex);
			}
		}

		private void SendLoop()
		{
			if (log.IsDebugEnabled)
				log.Debug("--> SendLoop");

			try
			{
				IMessage message;
				string sMessage;
				int iMessageLen, iMessagePos;
				byte[] buffer = new byte[SEND_BUFFER_LENGTH];
				int iBufferPos = 0;

				while (_bConnect)
				{
					message = _qPendingSend.DequeueBlocked(100);
					if (_bConnect && message != null)
					{
						sMessage = message.MessageRaw;
						iMessageLen = sMessage.Length;
						iMessagePos = 0;
						if (log.IsDebugEnabled)
							log.DebugFormat("SendLoop - Sending / Message={0}", sMessage);

						while (iMessagePos < iMessageLen)
						{
							while (iMessagePos < iMessageLen && iBufferPos < SEND_BUFFER_LENGTH)
							{
								buffer[iBufferPos] = (byte)sMessage[iMessagePos];
								iMessagePos += 1;
								iBufferPos += 1;
							}

							_dtSendLast = DateTime.Now;

							if (_qPendingSend.Count == 0 || iBufferPos == SEND_BUFFER_LENGTH)
							{
								_socket.Send(buffer, iBufferPos, SocketFlags.None);
								if (log.IsDebugEnabled)
									log.DebugFormat("SendLoop - Socket send complete / Bytes={0}", iBufferPos);

								iBufferPos = 0;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				log.Error("SendLoop - Exception caught", ex);
				LogoutAsynchronous("UNKOWN ERROR");
			}

			if (log.IsDebugEnabled)
				log.Debug("<-- SendLoop");
		}

		#endregion

		#region MessageCache

		private void MessageCacheInit()
		{
            if (log.IsDebugEnabled) log.Debug("MessageCacheInit");

			MessageCacheDispose();
			DateTime dtOpen = DateTime.Now.Date.AddHours(_iTimeZoneOffset);
			_messageCache = _messageCacheFactory.CreateInstance();
			_messageCache.Initialize(_messageFactory);
			_messageCache.Open(_sSenderCompID, _sSenderSubID, _sTargetCompID, _sTargetSubID, dtOpen, true);
			_iMsgSeqNumInRecover = _messageCache.MsgSeqNumIn;
			_iMsgSeqNumOutRecover = _messageCache.MsgSeqNumOut;
			_iMsgSeqNumIn = _messageCache.MsgSeqNumIn;
			_iMsgSeqNumOut = _messageCache.MsgSeqNumOut;
		}

		private void MessageCacheDispose()
		{
            if (log.IsDebugEnabled) log.Debug("MessageCacheDispose");

			IMessageCache cache = _messageCache;
			_messageCache = null;
			if (cache != null)
				cache.Dispose();
		}

		#endregion

		#region ResendRequest

		private void ProcessResendRequest(IMessageResendRequest resendRequest)
		{
			if (log.IsDebugEnabled)
				log.DebugFormat("--> ProcessResendRequest / MsgSeqNum={0} BeginSeqNo={1} EndSeqNo={2}",
					resendRequest.MsgSeqNum, resendRequest.BeginSeqNo, resendRequest.EndSeqNo);

			lock (_lockSend)
			{
				int iResendBegin = resendRequest.BeginSeqNo;
				int iResendEnd = resendRequest.EndSeqNo;
				if (iResendEnd == 0)
					iResendEnd = _iMsgSeqNumOut;

				int iResetBegin = -1;
				IMessage message;

				for (int i = iResendBegin; _bLogon && i <= iResendEnd; i++)
				{
					if (log.IsDebugEnabled)
						log.DebugFormat("ProcessResendRequest - Getting message from cache / MsgSeqNum={0}", i);
					message = _messageCache[MessageDirection.Out, i];
					if (message != null && !_messageFactory.IsAdminitrativeMessage(message))
					{
						if (iResetBegin != -1)
						{
							ProcessResendRequestSendSequenceReset(iResetBegin, i);
							iResetBegin = -1;
						}
						if (log.IsDebugEnabled)
							log.DebugFormat("ProcessResendRequest - Re-Sending message / MsgSeqNum={0}", i);
						ProcessResendRequestSend(message);
					}
					else if (iResetBegin == -1)
						iResetBegin = i;
				}

				if (_bLogon && iResetBegin != -1)
					ProcessResendRequestSendSequenceReset(iResetBegin, iResendEnd + 1);
			}

			if (log.IsDebugEnabled)
				log.DebugFormat("<-- ProcessResendRequest / MsgSeqNum={0}", resendRequest.MsgSeqNum);
		}

		private void ProcessResendRequestSendSequenceReset(int iMsgSeqNo, int iNewSeqNo)
		{
			if (log.IsDebugEnabled)
				log.DebugFormat("ProcessResendRequestSendSequenceReset - Sending Sequence Reset / MsgSeqNum={0} NewSeqNo={1}", iMsgSeqNo, iNewSeqNo);
			IMessageSequenceReset sequenceReset = _messageFactory.CreateInstanceSequenceReset();
			sequenceReset.MsgSeqNum = iMsgSeqNo;
			sequenceReset.NewSeqNo = iNewSeqNo;
			sequenceReset.GapFillFlag = true;
            sequenceReset.SendingTime = DateTime.Now.ToUniversalTime();
			ProcessResendRequestSend(sequenceReset);
		}

		private void ProcessResendRequestSend(IMessage message)
		{
			message.PossDupFlag = true;
			Send(message);
		}

		protected virtual void SendResendRequest()
		{
            if (log.IsDebugEnabled) log.Debug("SendResendRequest");

            if (_logoutType != LogoutType.None)
            {
                if (log.IsDebugEnabled)
                    log.Debug("SendResendRequest - Skip because logout is in progress");
                return;
            }

			int iBeginSeqNo = _iMsgSeqNumIn + 1;
            TimeSpan timeDiff = DateTime.Now.Subtract(_lastResendRequestTimestamp);

            if (_lastResendRequestBeginSeqNo == iBeginSeqNo && timeDiff.TotalSeconds <= (_iHeartBtInt + _iMessageTimeout))
            {
                if (log.IsDebugEnabled) 
                    log.DebugFormat("SendResendRequest - Abort sending ResendRequest because it was already sent recently / LastResendRequestBeginSeqNo={0} LastResendRequestTimestamp={1}", 
                        _lastResendRequestBeginSeqNo, _lastResendRequestTimestamp);
                return;
            }

			if (log.IsInfoEnabled)
				log.InfoFormat("SendResendRequest - Sending resend request to remote machine / BeginSeqNo={0}", iBeginSeqNo);

			IMessageResendRequest messageResendRequest = _messageFactory.CreateInstanceResendRequest();
			messageResendRequest.BeginSeqNo = iBeginSeqNo;
			messageResendRequest.EndSeqNo = 0;
			Send(messageResendRequest);

            _lastResendRequestBeginSeqNo = iBeginSeqNo;
            _lastResendRequestTimestamp = DateTime.Now;
		}

		#endregion

		#region Heartbeat

		private void HeartbeatLoopStart()
		{
			if (log.IsDebugEnabled)
				log.DebugFormat("HeartbeatLoopStart - Starting heartbeat thread / HeartBtInt={0}", _iHeartBtInt);
			if (_iHeartBtInt > 0)
			{
				_threadHeartbeat = new Thread(new ThreadStart(HeartbeatLoop));
				_threadHeartbeat.Name = "SocketEngine.HeartbeatLoop";
				_threadHeartbeat.IsBackground = true;
				_threadHeartbeat.Start();
			}
		}

		private void HeartbeatLoopStop()
		{
			try
			{
				Thread threadHeartbeat = _threadHeartbeat;
				_threadHeartbeat = null;
				if (threadHeartbeat != null && threadHeartbeat.IsAlive)
				{
					if (log.IsDebugEnabled)
						log.Debug("HeartbeatLoopStop - Stopping heartbeat thread");
					threadHeartbeat.Join();
				}
			}
			catch (Exception ex)
			{
				log.Error("HeartbeatLoopStop - Error stopping Heartbeat thread", ex);
			}
		}

		private void HeartbeatLoop()
		{
			try
			{
				IMessageTestRequest messageTestRequest;
				IMessageHeartbeat messageHeartbeat;

				while (_logoutType == LogoutType.None)
				{
					//Check for sent a message in the Heartbeat Interval
					if (_dtSendLast.AddSeconds(_iHeartBtInt) <= DateTime.Now)
					{
						messageHeartbeat = _messageFactory.CreateInstanceHeartbeat();
						Send(messageHeartbeat);
					}

					//Check for received a message in the Heartbeat Interval
					if (_dtReceiveLast.AddSeconds(_iHeartBtInt + _iMessageTimeout) <= DateTime.Now)
					{
						//Check how long since the last message received
						if (_dtReceiveLast.AddSeconds((_iHeartBtInt + _iMessageTimeout) * 2) <= DateTime.Now)
						{
							string sMessage = "No traffic has been received in some time";
							string sLogoutText = "NO TRAFFIC RECEIVED";
							throw new LogoutException(sMessage, sLogoutText);
						}
						//Check time since the last TestRequest message was sent
						else if (_dtTestRequestSentLast.AddSeconds(10) <= DateTime.Now)
						{
							_dtTestRequestSentLast = DateTime.Now;
							_iTestRequestCount += 1;
							messageTestRequest = _messageFactory.CreateInstanceTestRequest();
							messageTestRequest.TestReqID = DateTime.Now.ToString("yyyyMMddssHHmmss");
							Send(messageTestRequest);
						}
					}

					Thread.Sleep(1000);
				}
			}
			catch (LogoutException ex)
			{
				log.Error("HeartbeatLoop - LogoutException caught", ex);
				LogoutAsynchronous(ex.LogoutText);
			}
			catch (Exception ex)
			{
				log.Error("HeartbeatLoop - Exception caught", ex);
				LogoutAsynchronous("HEARTBEAT ERROR");
			}
		}

		#endregion

		#region MessageEvent

		private void MessageEventLoopStart()
		{
			_threadMessageEvent = new Thread(new ThreadStart(MessageEventLoop));
			_threadMessageEvent.Name = "SocketEngine.MessageEventLoop";
			_threadMessageEvent.IsBackground = true;
			_threadMessageEvent.Start();
		}

		private void MessageEventLoopStop()
		{
			try
			{
				_qProcessedMessages.Dispose();

				Thread threadMessageEvent = _threadMessageEvent;
				_threadMessageEvent = null;
				if (threadMessageEvent != null && threadMessageEvent.IsAlive)
					threadMessageEvent.Join();
			}
			catch (Exception ex)
			{
				log.Error("MessageEventLoopStop - Error stopping MessageEvent thread", ex);
			}
		}

		private void MessageEventLoop()
		{
			IMessage message;
			MessageDirection direction;
			while (!_bDisposed)
			{
				message = _qProcessedMessages.DequeueBlocked();
				if (message != null)
				{
					direction = message.Direction;
					if (direction == MessageDirection.In)
					{
						if (Received != null)
						{
							try
							{
								Received(this, message);
							}
							catch (Exception ex)
							{
								log.Error("MessageEventLoop - Error raising Received event", ex);
							}
						}
					}
					else if (direction == MessageDirection.Out)
					{
						if (Sent != null)
						{
							try
							{
								Sent(this, message);
							}
							catch (Exception ex)
							{
								log.Error("MessageEventLoop - Error raising Sent event", ex);
							}
						}
					}
				}
			}
		}

		#endregion

		#region EndOfDay(EOD)

		private void EndOfDayStart()
		{
			_threadEndOfDay = new Thread(new ThreadStart(EndOfDayLoop));
			_threadEndOfDay.IsBackground = true;
			_threadEndOfDay.Name = "SocketEngine.EndOfDayLoop";
			_threadEndOfDay.Start();
		}

		private void EndOfDayStop()
		{
			try
			{
				Thread threadEndOfDay = _threadEndOfDay;
				_threadEndOfDay = null;
				if (threadEndOfDay != null && threadEndOfDay.IsAlive)
					threadEndOfDay.Join();
			}
			catch (Exception ex)
			{
				log.Error("EndOfDayStop - Error stopping EOD thread", ex);
			}
		}

		private void EndOfDayLoop()
		{
            if (log.IsDebugEnabled) log.Debug("EndOfDayLoop");

			try
			{
				TimeSpan tsEndOfDay = new TimeSpan(23, 59, 30);
				bool bEndOfDayRunning = false;
				while (!_bDisposed)
				{
					if (_bInitialized)
					{
						if (!bEndOfDayRunning && DateTime.Now.AddHours(_iTimeZoneOffset).TimeOfDay >= tsEndOfDay)
						{
                            if (log.IsDebugEnabled) log.Debug("EndOfDayLoop - EOD process phase I has started");
                            if (log.IsInfoEnabled) log.Info("EndOfDayLoop - EOD process has started");

							if (EndOfDayBefore != null)
							{
								try
								{
									EndOfDayBefore(this);
								}
								catch (Exception exInner)
								{
                                    log.Error("EndOfDayLoop - Exception caught raising event EndOfDayBefore", exInner);
								}
							}

							bEndOfDayRunning = true;
							try
							{
								Logout("END OF DAY");
							}
							catch (Exception exInner)
							{
								log.Error("EndOfDayLoop - Exception caught running Logout", exInner);
							}
							MessageCacheDispose();

                            if (log.IsDebugEnabled) log.Debug("EndOfDayLoop - EOD process phase I has finished");
						}
						else if (bEndOfDayRunning && DateTime.Now.AddHours(_iTimeZoneOffset).TimeOfDay < tsEndOfDay)
						{
                            if (log.IsDebugEnabled) log.Info("EndOfDayLoop - EOD process phase II has started");

							bEndOfDayRunning = false;
							MessageCacheInit();

							if (EndOfDayAfter != null)
							{
								try
								{
									EndOfDayAfter(this);
								}
								catch (Exception exInner)
								{
                                    log.Error("EndOfDayLoop - Exception caught raising event EndOfDayAfter", exInner);
								}
							}

                            if (log.IsInfoEnabled) log.Info("EndOfDayLoop - EOD process has finished");
                            if (log.IsDebugEnabled) log.Debug("EndOfDayLoop - EOD process phase II has finished");
						}
					}

					Thread.Sleep(1000);
				}
			}
			catch (Exception ex)
			{
				log.Error("EndOfDayLoop - Exception caught", ex);
			}

            if (log.IsDebugEnabled) log.Debug("EndOfDayLoop - Terminating");
		}

		#endregion

		#region Reset MsgSeqNum In/Out

		public void ResetMsgSeqNumIn(int iMsgSeqNumIn)
		{
			if (!_bInitialized)
				throw new Exception("Must be initialized to reset the MsgSeqNum in");

			if (_bConnect || _bLogon)
				throw new Exception("Must be disconnected to reset the MsgSeqNum int");

			_messageCache.ResetMsgSeqNumIn(iMsgSeqNumIn);
			_iMsgSeqNumIn = iMsgSeqNumIn;
		}

		public void ResetMsgSeqNumOut(int iMsgSeqNumOut)
		{
			if (!_bInitialized)
				throw new Exception("Must be initialized to reset the MsgSeqNum out");

			if (_bConnect || _bLogon)
				throw new Exception("Must be disconnected to reset the MsgSeqNum out");

			_messageCache.ResetMsgSeqNumOut(iMsgSeqNumOut);
			_iMsgSeqNumOut = iMsgSeqNumOut;
		}

		#endregion
	}
}
