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

namespace FIX4NET.FIX
{
	/// <summary>
	/// Summary description for Message.
	/// </summary>
	public class Message : IMessage
	{
		protected Message()
		{
		}

		internal Message(string msgType)
		{
			_sMsgType = msgType;
		}

		#region Tags #'s

		public const int TAG_BeginString = 8;
		public const int TAG_BodyLength = 9;
		public const int TAG_MsgType = 35;
		public const int TAG_SenderCompID = 49;
		public const int TAG_TargetCompID = 56;
		public const int TAG_OnBehalfOfCompID = 115;
		public const int TAG_DeliverToCompID = 128;
		public const int TAG_SecureDataLen = 90; //not implemented
		public const int TAG_SecureData = 91; //not implemented
		public const int TAG_MsgSeqNum = 34;
		public const int TAG_SenderSubID = 50;
		public const int TAG_TargetSubID = 57;
		public const int TAG_OnBehalfOfSubID = 116;
		public const int TAG_DeliverToSubID = 129;
		public const int TAG_PossDupFlag = 43;
		public const int TAG_PossResend = 97;
		public const int TAG_SendingTime = 52;
		public const int TAG_OrigSendingTime = 122;
		public const int TAG_CheckSum = 10;

		#endregion

		#region Message Varialbes

		private string _sMessageRaw;
		private MessageDirection _direction = MessageDirection.None;

		private int _iBodyLength;
		protected string _sBeginString;
		protected string _sMsgType;
		private string _sSenderCompID;
		private string _sTargetCompID;
		private string _sOnBehalfOfCompID;
		private string _sDeliverToCompID;
		private int _iMsgSeqNum;
		private string _sSenderSubID;
		private string _sTargetSubID;
		private string _sOnBehalfOfSubID;
		private string _sDeliverToSubID;
		private bool _bPossDupFlag;
		private bool _bPossResend;
		private DateTime _dtSendingTime;
		private DateTime _dtOrigSendingTime;
		private byte _iCheckSum;

		FieldCollection _fields = new FieldCollection();

		#endregion

		#region Message Properties

		public string MessageRaw 
		{
			get { return _sMessageRaw; }
			set { _sMessageRaw = value; }
		}

		public MessageDirection Direction 
		{
			get { return _direction; }
			set { _direction = value; }
		}

		public string BeginString
		{
			get { return _sBeginString; }
			set { _sBeginString = value; }
		}

		public int BodyLength
		{
			get { return _iBodyLength; }
			set { _iBodyLength = value; }
		}

		public string MsgType
		{
			get { return _sMsgType; }
			set { _sMsgType = value; }
		}

		public string SenderCompID
		{
			get { return _sSenderCompID; }
			set { _sSenderCompID = value ;}
		}

		public string TargetCompID
		{
			get { return _sTargetCompID; }
			set { _sTargetCompID = value; }
		}

		public string OnBehalfOfCompID
		{
			get { return _sOnBehalfOfCompID; }
			set { _sOnBehalfOfCompID = value; }
		}

		public string DeliverToCompID
		{
			get { return _sDeliverToCompID; }
			set { _sDeliverToCompID = value; }
		}

		public int MsgSeqNum
		{
			get { return _iMsgSeqNum; }
			set { _iMsgSeqNum = value; }
		}

		public string SenderSubID
		{
			get { return _sSenderSubID; }
			set { _sSenderSubID = value; }
		}

		public string TargetSubID
		{
			get { return _sTargetSubID; }
			set { _sTargetSubID = value; }
		}

		public string OnBehalfOfSubID
		{
			get { return _sOnBehalfOfSubID; }
			set { _sOnBehalfOfSubID = value; }
		}

		public string DeliverToSubID
		{
			get { return _sDeliverToSubID; }
			set { _sDeliverToSubID = value; }
		}

		public bool PossDupFlag
		{
			get { return _bPossDupFlag; }
			set { _bPossDupFlag = value; }
		}

		public bool PossResend
		{
			get { return _bPossResend; }
			set { _bPossResend = value; }
		}

		public DateTime SendingTime
		{
			get { return _dtSendingTime; }
			set { _dtSendingTime = value; }
		}

		public DateTime OrigSendingTime
		{
			get { return _dtOrigSendingTime; }
			set { _dtOrigSendingTime = value; }
		}

		public byte CheckSum
		{
			get { return _iCheckSum; }
			set { _iCheckSum = value; }
		}

        public FieldCollection Fields
        {
            get { return _fields; }
        }

		#endregion

		#region Generic Get/Set Tag #

		/// <summary>
		/// Get/Set value using the tag #.
		/// </summary>
		public virtual object this[int iTag] 
		{ 
			get 
			{
				switch(iTag)
				{
					case TAG_BeginString:
						return _sBeginString;
					case TAG_BodyLength:
						return _iBodyLength;
					case TAG_MsgType:
						return _sMsgType;
					case TAG_SenderCompID:
						return _sSenderCompID;
					case TAG_TargetCompID:
						return _sTargetCompID;
					case TAG_OnBehalfOfCompID:
						return _sOnBehalfOfCompID;
					case TAG_DeliverToCompID:
						return _sDeliverToCompID;
					case TAG_MsgSeqNum:
						return _iMsgSeqNum;
					case TAG_SenderSubID:
						return _sSenderSubID;
					case TAG_TargetSubID:
						return _sTargetSubID;
					case TAG_OnBehalfOfSubID:
						return _sOnBehalfOfSubID;
					case TAG_DeliverToSubID:
						return _sDeliverToSubID;
					case TAG_PossDupFlag:
						return _bPossDupFlag;
					case TAG_PossResend:
						return _bPossResend;
					case TAG_SendingTime:
						return _dtSendingTime;
					case TAG_OrigSendingTime:
						return _dtOrigSendingTime;
					default:
						return null;
				}
			}
			set 
			{
				switch(iTag)
				{
					case TAG_BeginString:
						throw new Exception("Field not editable");
					case TAG_BodyLength:
						throw new Exception("Field not editable");
					case TAG_MsgType:
						throw new Exception("Field not editable");
					case TAG_SenderCompID:
						throw new Exception("Field not editable");
					case TAG_TargetCompID:
						throw new Exception("Field not editable");
					case TAG_OnBehalfOfCompID:
						_sOnBehalfOfCompID = (string)value;
						break;
					case TAG_DeliverToCompID:
						_sDeliverToCompID = (string)value;
						break;
					case TAG_MsgSeqNum:
						throw new Exception("Field not editable");
					case TAG_SenderSubID:
						_sSenderSubID = (string)value;
						break;
					case TAG_TargetSubID:
						_sTargetSubID = (string)value;
						break;
					case TAG_OnBehalfOfSubID:
						_sOnBehalfOfSubID = (string)value;
						break;
					case TAG_DeliverToSubID:
						_sDeliverToSubID = (string)value;
						break;
					case TAG_PossDupFlag:
						throw new Exception("Field not editable");
					case TAG_PossResend:
						_bPossResend = (bool)value;
						break;
					case TAG_SendingTime:
						throw new Exception("Field not editable");
					case TAG_OrigSendingTime:
						throw new Exception("Field not editable");
					default:
						throw new Exception("Field not found");
				}
			}
		}

		#endregion

		public virtual void CopyTo(IMessage to)
		{
			Message message = (Message)to;
			
			message._sMessageRaw = _sMessageRaw;
			message._direction = _direction;
			message._iBodyLength = _iBodyLength;
			message._sBeginString = _sBeginString;
			message._sMsgType = _sMsgType;
			message._sSenderCompID = _sSenderCompID;
			message._sTargetCompID = _sTargetCompID;
			message._sOnBehalfOfCompID = _sOnBehalfOfCompID;
			message._sDeliverToCompID = _sDeliverToCompID;
			message._iMsgSeqNum = _iMsgSeqNum;
			message._sSenderSubID = _sSenderSubID;
			message._sTargetSubID = _sTargetSubID;
			message._sOnBehalfOfSubID = _sOnBehalfOfSubID;
			message._sDeliverToSubID = _sDeliverToSubID;
			message._bPossDupFlag = _bPossDupFlag;
			message._bPossResend = _bPossResend;
			message._dtSendingTime = _dtSendingTime;
			message._dtOrigSendingTime = _dtOrigSendingTime;
			message._iCheckSum = _iCheckSum;

			IField fieldNew;
			foreach (IField field in _fields)
			{
				fieldNew = field.Clone();
				message.Fields.Add(fieldNew);
			}
		}

		public virtual IMessage Clone()
		{
			Message message = new Message();
			CopyTo(message);
			return message;
		}
	}
}
