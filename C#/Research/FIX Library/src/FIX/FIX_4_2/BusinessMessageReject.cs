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
	public class BusinessMessageReject : Message
	{
		public const int TAG_RefSeqNum = 45;
		public const int TAG_RefMsgType = 372;
		public const int TAG_BusinessRejectRefID = 379;
		public const int TAG_BusinessRejectReason = 380;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		public const string TAG_STRING_RefSeqNum = "45";
		public const string TAG_STRING_RefMsgType = "372";
		public const string TAG_STRING_BusinessRejectRefID = "379";
		public const string TAG_STRING_BusinessRejectReason = "380";
		public const string TAG_STRING_Text = "58";
		public const string TAG_STRING_EncodedTextLen = "354";
		public const string TAG_STRING_EncodedText = "355";

		private int _iRefSeqNum;
		private string _sRefMsgType;
		private string _sBusinessRejectRefID;
		private int _iBusinessRejectReason;
		private string _sText;

		internal BusinessMessageReject()
			: base()
		{
			_sMsgType = Values.MsgType.BusinessMessageReject;
		}

		public int RefSeqNum
		{
			get { return _iRefSeqNum; }
			set { _iRefSeqNum = value; }
		}
		public string RefMsgType
		{
			get { return _sRefMsgType; }
			set { _sRefMsgType = value; }
		}
		public string BusinessRejectRefID
		{
			get { return _sBusinessRejectRefID; }
			set { _sBusinessRejectRefID = value; }
		}
		public int BusinessRejectReason
		{
			get { return _iBusinessRejectReason; }
			set { _iBusinessRejectReason = value; }
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
				else if (iTag == TAG_RefMsgType)
					return _sRefMsgType;
				else if (iTag == TAG_BusinessRejectRefID)
					return _sBusinessRejectRefID;
				else if (iTag == TAG_BusinessRejectReason)
					return _iBusinessRejectReason;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_RefSeqNum)
					_iRefSeqNum = (int)value;
				else if (iTag == TAG_RefMsgType)
					_sRefMsgType = (string)value;
				else if (iTag == TAG_BusinessRejectRefID)
					_sBusinessRejectRefID = (string)value;
				else if (iTag == TAG_BusinessRejectReason)
					_iBusinessRejectReason = (int)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}


	}
}
