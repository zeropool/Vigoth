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
using System.Text;

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_4
{
	/// <summary>
	/// Summary description for Logon.
	/// </summary>
	public class Logon : Message, IMessageLogon
	{
		public const int TAG_EncryptMethod = 98;
		public const int TAG_HeartBtInt = 108;
		public const int TAG_RawDataLength = 95;
		public const int TAG_RawData = 96;
		public const int TAG_ResetSeqNumFlag = 141;
		public const int TAG_NextExpectedMsgSeqNum = 789;
		public const int TAG_MaxMessageSize = 383;
		public const int TAG_NoMsgTypes = 384;
		public const int TAG_RefMsgType = 372;
		public const int TAG_MsgDirection = 385;
		public const int TAG_TestMessageIndicator = 464;
		public const int TAG_Username = 553;
		public const int TAG_Password = 554;

		private int _iEncryptMethod;
		private int _iHeartBtInt;
		private int _iRawDataLength;
		private string _sRawData;
		private bool _bResetSeqNumFlag;
		private int _iNextExpectedMsgSeqNum;
		private int _iMaxMessageSize;
		private int _iNoMsgTypes;
		private LogonRefMsgTypeList _listRefMsgType = new LogonRefMsgTypeList();
		private bool _bTestMessageIndicator;
		private string _sUsername;
		private string _sPassword;

		public Logon() : base()
		{
			_sMsgType = Values.MsgType.Logon;
		}

		public int EncryptMethod
		{
			get { return _iEncryptMethod; }
			set { _iEncryptMethod = value; }
		}
		public int HeartBtInt
		{
			get { return _iHeartBtInt; }
			set { _iHeartBtInt = value; }
		}
		public int RawDataLength
		{
			get { return _iRawDataLength; }
			set { _iRawDataLength = value; }
		}
		public string RawData
		{
			get { return _sRawData; }
			set { _sRawData = value; }
		}
		public bool ResetSeqNumFlag
		{
			get { return _bResetSeqNumFlag; }
			set { _bResetSeqNumFlag = value; }
		}
		public int NextExpectedMsgSeqNum
		{
			get { return _iNextExpectedMsgSeqNum; }
			set { _iNextExpectedMsgSeqNum = value; }
		}
		public int MaxMessageSize
		{
			get { return _iMaxMessageSize; }
			set { _iMaxMessageSize = value; }
		}
		public int NoMsgTypes
		{
			get { return _iNoMsgTypes; }
			set { _iNoMsgTypes = value; }
		}
		public LogonRefMsgTypeList RefMsgType 
		{
			get { return _listRefMsgType; }
		}
		public bool TestMessageIndicator
		{
			get { return _bTestMessageIndicator; }
			set { _bTestMessageIndicator = value; }
		}
		public string Username
		{
			get { return _sUsername; }
			set { _sUsername = value; }
		}
		public string Password
		{
			get { return _sPassword; }
			set { _sPassword = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_EncryptMethod:
						return _iEncryptMethod;
					case TAG_HeartBtInt:
						return _iHeartBtInt;
					case TAG_RawDataLength:
						return _iRawDataLength;
					case TAG_RawData:
						return _sRawData;
					case TAG_ResetSeqNumFlag:
						return _bResetSeqNumFlag;
					case TAG_NextExpectedMsgSeqNum:
						return _iNextExpectedMsgSeqNum;
					case TAG_MaxMessageSize:
						return _iMaxMessageSize;
					case TAG_NoMsgTypes:
						return _iNoMsgTypes;
					case TAG_TestMessageIndicator:
						return _bTestMessageIndicator;
					case TAG_Username:
						return _sUsername;
					case TAG_Password:
						return _sPassword;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_EncryptMethod:
						_iEncryptMethod = (int)value;
						break;
					case TAG_HeartBtInt:
						_iHeartBtInt = (int)value;
						break;
					case TAG_RawDataLength:
						_iRawDataLength = (int)value;
						break;
					case TAG_RawData:
						_sRawData = (string)value;
						break;
					case TAG_ResetSeqNumFlag:
						_bResetSeqNumFlag = (bool)value;
						break;
					case TAG_NextExpectedMsgSeqNum:
						_iNextExpectedMsgSeqNum = (int)value;
						break;
					case TAG_MaxMessageSize:
						_iMaxMessageSize = (int)value;
						break;
					case TAG_NoMsgTypes:
						_iNoMsgTypes = (int)value;
						break;
					case TAG_TestMessageIndicator:
						_bTestMessageIndicator = (bool)value;
						break;
					case TAG_Username:
						_sUsername = (string)value;
						break;
					case TAG_Password:
						_sPassword = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class LogonRefMsgType
	{
		private string _sRefMsgType;
		private char _cMsgDirection;

		public string RefMsgType
		{
			get { return _sRefMsgType; }
			set { _sRefMsgType = value; }
		}
		public char MsgDirection
		{
			get { return _cMsgDirection; }
			set { _cMsgDirection = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case Logon.TAG_RefMsgType:
						return _sRefMsgType;
					case Logon.TAG_MsgDirection:
						return _cMsgDirection;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Logon.TAG_RefMsgType:
						_sRefMsgType = (string)value;
						break;
					case Logon.TAG_MsgDirection:
						_cMsgDirection = (char)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class LogonRefMsgTypeList
	{
		private ArrayList _al;
		private LogonRefMsgType _last;

		public LogonRefMsgType this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (LogonRefMsgType)_al[i];
				else
					return null;
			}
		}

		public int Count
		{
			get
			{
				if (_al != null)
					return _al.Count;
				else
					return 0;
			}
		}

		public void Clear()
		{
			_al = null;
		}

		public void Add(LogonRefMsgType item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(LogonRefMsgType item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public LogonRefMsgType Last
		{
			get { return _last; }
		}
	}
}
