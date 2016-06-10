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

namespace FIX4NET
{

	public delegate void MessageEventHandler(IEngine engine, IMessage message);
	public delegate void EngineEventHandler(IEngine engine);
	
	/// <summary>
	/// Inteface to send/recive messages over a transport.
	/// </summary>
	public interface IEngine : IDisposable
	{
		event EngineEventHandler LogonAfter;
		event EngineEventHandler LogoutAfter;
		event MessageEventHandler Received;
		event MessageEventHandler Sent;
		event EngineEventHandler EndOfDayBefore;
		event EngineEventHandler EndOfDayAfter;

		void Initialize(string sSenderCompID, string sTargetCompID);
		void Initialize(string sSenderCompID, string sTargetCompID, byte iTimeZoneOffset);
		void Initialize(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID);
		void Initialize(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID, byte iTimeZoneOffset);

		bool IsRelatedLogon(string sMessage);

		void Logon(ILogonArgs logonArgs);
		void Logout(string sText);
		void Send(IMessage message);

		int MsgSeqNumIn { get; }
		int MsgSeqNumOut { get; }
		/// <summary>
		/// MsgSeqNum for incoming messages after recovery is complete.  This only get update when opening the cache.
		/// </summary>
		int MsgSeqNumInRecover { get; }
		/// <summary>
		/// MsgSeqNum for outgoing messages after recovery is complete.  This only get update when opening the cache.
		/// </summary>
		int MsgSeqNumOutRecover { get; }
		void ResetMsgSeqNumIn(int iMsgSeqNumIn);
		void ResetMsgSeqNumOut(int iMsgSeqNumOut);

        IMessageCacheFactory MessageCacheFactory { get; set; }
		IMessageCache Messages { get; }
        IMessageFactory MessageFactory { get; set; }

		string SenderCompID { get; }
		string SenderSubID { get; }
		string TargetCompID { get; }
		string TargetSubID { get; }
		byte TimeZoneOffset { get; }
		bool IsConnected { get; }
		int HeartBtInt { get;set; }
		bool AllowOfflineSend { get;set; }
	}
}
