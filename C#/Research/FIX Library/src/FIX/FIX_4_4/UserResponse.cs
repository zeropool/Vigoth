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
	/// Summary description for UserResponse.
	/// </summary>
	public class UserResponse : Message
	{
		public const int TAG_UserRequestID = 923;
		public const int TAG_Username = 553;
		public const int TAG_UserStatus = 926;
		public const int TAG_UserStatusText = 927;

		private string _sUserRequestID;
		private string _sUsername;
		private int _iUserStatus;
		private string _sUserStatusText;

		public UserResponse() : base()
		{
			_sMsgType = Values.MsgType.UserResponse;
		}

		public string UserRequestID
		{
			get { return _sUserRequestID; }
			set { _sUserRequestID = value; }
		}
		public string Username
		{
			get { return _sUsername; }
			set { _sUsername = value; }
		}
		public int UserStatus
		{
			get { return _iUserStatus; }
			set { _iUserStatus = value; }
		}
		public string UserStatusText
		{
			get { return _sUserStatusText; }
			set { _sUserStatusText = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_UserRequestID:
						return _sUserRequestID;
					case TAG_Username:
						return _sUsername;
					case TAG_UserStatus:
						return _iUserStatus;
					case TAG_UserStatusText:
						return _sUserStatusText;
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
					case TAG_Username:
						_sUsername = (string)value;
						break;
					case TAG_UserStatus:
						_iUserStatus = (int)value;
						break;
					case TAG_UserStatusText:
						_sUserStatusText = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}
}
