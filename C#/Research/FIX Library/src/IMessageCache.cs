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
	/// <summary>
	/// Interface to read/write messages from local storage.
	/// </summary>
	public interface IMessageCache : IDisposable
	{

		/// <summary>
		/// Gets a message by the index position.
		/// </summary>
		IMessage this[int iMsgIndex] { get; }
		/// <summary>
		/// Gets a message by the MessageDirection and MsgSeqNum.
		/// </summary>
		IMessage this[MessageDirection msgDirection, int iMsgSeqNum] { get; }

		/// <summary>
		/// Add a message.
		/// </summary>
		void AddMessage(IMessage message);

		/// <summary>
		/// Current MsgIndex for messages.  This updates in real-time as messages are added.
		/// </summary>
		int MsgIndex { get; }
		/// <summary>
		/// Current MsgSeqNum for incoming messages.  This updates in real-time as messages are added.
		/// </summary>
		int MsgSeqNumOut { get; }
		/// <summary>
		/// Current MsgSeqNum for outgoing messages.  This updates in real-time as messages are added.
		/// </summary>
		int MsgSeqNumIn { get; }
		/// <summary>
		/// Get current MsgSeqNum by MessageDirection.  This updates in real-time as messages are added.
		/// </summary>
		int GetMsgSeqNum(MessageDirection direction);

		void ResetMsgSeqNumIn(int iMsgSeqNumIn);
		void ResetMsgSeqNumOut(int iMsgSeqNumOut);

		/// <summary>
		/// Initialize the cache.
		/// </summary>
		void Initialize(IMessageFactory messageFactory);

		/// <summary>
		/// Opens the cache for read/write access.
		/// </summary>
		void Open(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID);
		/// <summary>
		/// Opens the cache for read/write access of a specific date.
		/// </summary>
		void Open(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID, DateTime dtOpen);
		/// <summary>
		/// Opens the cache for read or read/write access.
		/// </summary>
		void Open(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID, bool bWrite);
		/// <summary>
		/// Opens the cache for read or read/write access of a specific date.
		/// </summary>
		void Open(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID, DateTime dtOpen, bool bWrite);
		/// <summary>
		/// Close the cache.
		/// </summary>
		void Close();

	}
}
