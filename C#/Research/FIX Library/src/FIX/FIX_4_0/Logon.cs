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

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_0
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

		private int _iEncryptMethod = 0;
		private int _iHeartBtInt = 0;
		private int _iRawDataLength = 0;
		private string _sRawData = null;

		internal Logon() : base()
		{
			_sMsgType = Values.MsgType.Logon;
		}

		#region Message Properties

		public int EncryptMethod 
		{
			get 
			{
				return _iEncryptMethod;
			}
			set 
			{
				_iEncryptMethod = value;
			}
		}

		public int HeartBtInt {
			get 
			{
				return _iHeartBtInt;
			}
			set 
			{
				_iHeartBtInt = value;
			}
		}

		public int RawDataLength {
			get 
			{
				return _iRawDataLength;
			}
			set 
			{
				_iRawDataLength = value;
			}
		}

		public string RawData {
			get 
			{
				return _sRawData;
			}
			set 
			{
				_sRawData = value;
			}
		}

		#endregion

		#region Generic Get/Set Tag #

		public override object this[int iTag] 
		{
			get 
			{
				switch(iTag) 
				{
					case TAG_EncryptMethod:
						return _iEncryptMethod;
					case TAG_HeartBtInt:
						return _iHeartBtInt;
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
				switch(iTag) 
				{
					case TAG_EncryptMethod:
						_iEncryptMethod = (int) value;
						break;
					case TAG_HeartBtInt:
						_iHeartBtInt = (int) value;
						break;
					case TAG_RawDataLength:
						_iRawDataLength = (int) value;
						break;
					case TAG_RawData:
						_sRawData = (string) value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

		#endregion
	}
}
