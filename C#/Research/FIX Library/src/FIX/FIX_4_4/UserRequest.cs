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
	/// Summary description for UserRequest.
	/// </summary>
	public class UserRequest : Message
	{
		public const int TAG_UserRequestID = 923;
		public const int TAG_UserRequestType = 924;
		public const int TAG_Username = 553;
		public const int TAG_Password = 554;
		public const int TAG_NewPassword = 925;
		public const int TAG_RawDataLength = 95;
		public const int TAG_RawData = 96;

		private string _sUserRequestID;
		private int _iUserRequestType;
		private string _sUsername;
		private string _sPassword;
		private string _sNewPassword;
		private int _iRawDataLength;
		private string _sRawData;

		public UserRequest() : base()
		{
			_sMsgType = Values.MsgType.UserRequest;
		}

		public string UserRequestID
		{
			get { return _sUserRequestID; }
			set { _sUserRequestID = value; }
		}
		public int UserRequestType
		{
			get { return _iUserRequestType; }
			set { _iUserRequestType = value; }
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
		public string NewPassword
		{
			get { return _sNewPassword; }
			set { _sNewPassword = value; }
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

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_UserRequestID:
						return _sUserRequestID;
					case TAG_UserRequestType:
						return _iUserRequestType;
					case TAG_Username:
						return _sUsername;
					case TAG_Password:
						return _sPassword;
					case TAG_NewPassword:
						return _sNewPassword;
					case TAG_RawDataLength:
						return _iRawDataLength;
					case TAG_RawData:
						return _sRawData;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_UserRequestID:
						_sUserRequestID = (string)value;
						break;
					case TAG_UserRequestType:
						_iUserRequestType = (int)value;
						break;
					case TAG_Username:
						_sUsername = (string)value;
						break;
					case TAG_Password:
						_sPassword = (string)value;
						break;
					case TAG_NewPassword:
						_sNewPassword = (string)value;
						break;
					case TAG_RawDataLength:
						_iRawDataLength = (int)value;
						break;
					case TAG_RawData:
						_sRawData = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}
}
