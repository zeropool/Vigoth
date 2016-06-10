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
using System.Text;

using FIX4NET;
using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_2
{
	/// <summary>
	/// Summary description for Reject.
	/// </summary>
	public class Reject : Message, IMessageReject
	{
		public const int TAG_RefSeqNum = 45;
		public const int TAG_RefTagID = 371;
		public const int TAG_RefMsgType = 372;
		public const int TAG_SessionRejectReason = 373;
		public const int TAG_Text = 58;

		private int _iRefSeqNum;
		private int _iRefTagID;
		private string _sRefMsgType;
		private int _iSessionRejectReason = -1;
		private string _sText;

		internal Reject()
			: base()
		{
			_sMsgType = Values.MsgType.Reject;
		}

		public int RefSeqNum 
		{
			get { return _iRefSeqNum; }
			set { _iRefSeqNum = value; }
		}

		public int RefTagID 
		{
			get { return _iRefTagID; }
			set { _iRefTagID = value; }
		}

		public string RefMsgType 
		{
			get { return _sRefMsgType; }
			set { _sRefMsgType = value; }
		}

		public int SessionRejectReason 
		{
			get { return _iSessionRejectReason; }
			set { _iSessionRejectReason = value; }
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
				if (iTag == TAG_RefSeqNum)
					return _iRefSeqNum;
				else if (iTag == TAG_RefTagID)
					return _iRefTagID;
				else if (iTag == TAG_RefMsgType)
					return _sRefMsgType;
				else if (iTag == TAG_SessionRejectReason)
					return _iSessionRejectReason;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];	
			}
			set
			{
				if (iTag == TAG_RefSeqNum)
					_iRefSeqNum = (int)value;
				else if (iTag == TAG_RefTagID)
					_iRefTagID = (int)value;
				else if (iTag == TAG_RefMsgType)
					_sRefMsgType = (string)value;
				else if (iTag == TAG_SessionRejectReason)
					_iSessionRejectReason = (int)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}
	}
}
