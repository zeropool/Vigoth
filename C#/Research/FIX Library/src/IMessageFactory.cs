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
	/// Summary description for IMessageFactory.
	/// </summary>
	public interface IMessageFactory
	{
		void SetConfig(string name, object value);

		bool IsRelatedMessage(string sMessage);

		IMessage CreateInstance(string sMsgType);
		IMessageLogon CreateInstanceLogon();
		IMessageLogout CreateInstanceLogout();
		IMessageHeartbeat CreateInstanceHeartbeat();
		IMessageTestRequest CreateInstanceTestRequest();
		IMessageResendRequest CreateInstanceResendRequest();
		IMessageSequenceReset CreateInstanceSequenceReset();
		IMessageReject CreateInstanceReject();
		IMessageReject CreateInstanceReject(ParseFieldException exParse);

		bool IsAdminitrativeMessage(IMessage message);
		bool IsLogonMessage(IMessage message);
		bool IsLogoutMessage(IMessage message);
		bool IsTestRequestMessage(IMessage message);
		bool IsResendRequestMessage(IMessage message);
		bool IsSequenceResetMessage(IMessage message);

		bool ValidateFixChecksum(string sMessage);
		bool ValidateBodyLength(string sMessage);

		string GetSearchStringMessageEndPrefix();
		string GetSearchStringMessageEndSuffix();

		string Build(IMessage message);
		IMessage Parse(string sMessage);
		string ParseMsgType(string sMessage);
		int ParseMsgSeqNum(string sMessage);

        void AddField(IField field);
        FieldCollection GetFields();
	}
}
