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

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_0
{
	/// <summary>
	/// The order cancel reject message is issued by the broker upon receipt 
	/// of a cancel request or cancel/replace request message which cannot 
	/// be honored.  Requests to change price or decrease quantity are executed 
	/// only when an outstanding quantity exists; orders which are filled 
	/// cannot be changed.
	/// 
	/// When rejecting a Cancel/Replace Request, the ClOrdID of the replacement 
	/// order in the request message is inserted in the ClOrdID field of the 
	/// Cancel Reject message for identification.
	/// 
	/// The execution message will be used to respond to accepted cancel request 
	/// and cancel/replace request messages.
	/// </summary>
	public class OrderCancelReject : Message
	{
		public const int TAG_OrderID = 37;
		public const int TAG_ClOrdID = 11;
		public const int TAG_ClientID = 109;
		public const int TAG_ExecBroker = 76;
		public const int TAG_ListID = 66;
		public const int TAG_CxlRejReason = 102;
		public const int TAG_Text = 58;

		private string _sOrderID;
		private string _sClOrdID;
		private string _sClientID;
		private string _sExecBroker;
		private string _sListID;
		private int _iCxlRejReason;
		private string _sText;

		internal OrderCancelReject()
			: base()
		{
			_sMsgType = Values.MsgType.OrderCancelReject;
		}

		public string OrderID
		{
			get { return _sOrderID; }
			set { _sOrderID = value; }
		}
		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public string ClientID
		{
			get { return _sClientID; }
			set { _sClientID = value; }
		}
		public string ExecBroker
		{
			get { return _sExecBroker; }
			set { _sExecBroker = value; }
		}
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public int CxlRejReason
		{
			get { return _iCxlRejReason; }
			set { _iCxlRejReason = value; }
		}
		public string Text
		{
			get { return _sText; }
			set { _sText = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				if (iTag == TAG_OrderID)
					return _sOrderID;
				else if (iTag == TAG_ClOrdID)
					return _sClOrdID;
				else if (iTag == TAG_ClientID)
					return _sClientID;
				else if (iTag == TAG_ExecBroker)
					return _sExecBroker;
				else if (iTag == TAG_ListID)
					return _sListID;
				else if (iTag == TAG_CxlRejReason)
					return _iCxlRejReason;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_OrderID)
					_sOrderID = (string)value;
				else if (iTag == TAG_ClOrdID)
					_sClOrdID = (string)value;
				else if (iTag == TAG_ClientID)
					_sClientID = (string)value;
				else if (iTag == TAG_ExecBroker)
					_sExecBroker = (string)value;
				else if (iTag == TAG_ListID)
					_sListID = (string)value;
				else if (iTag == TAG_CxlRejReason)
					_iCxlRejReason = (int)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}
	}
}
