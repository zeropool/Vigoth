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
	/// Summary description for ResendRequest.
	/// </summary>
	public class ResendRequest : Message, IMessageResendRequest
	{

		public const int TAG_BeginSeqNo = 7;
		public const int TAG_EndSeqNo = 16;

		private int _iBeginSeqNo = 0;
		private int _iEndSeqNo = 0;

		internal ResendRequest() : base()
		{
			_sMsgType = Values.MsgType.ResendRequest;
		}

		public int BeginSeqNo 
		{
			get 
			{
				return _iBeginSeqNo;
			}
			set 
			{
				_iBeginSeqNo = value;
			}
		}

		public int EndSeqNo 
		{
			get 
			{
				return _iEndSeqNo;
			}
			set 
			{
				_iEndSeqNo = value;
			}
		}

		public override object this[int iTag]
		{
			get
			{
				switch(iTag) 
				{
					case TAG_BeginSeqNo:
						return _iBeginSeqNo;
					case TAG_EndSeqNo:
						return _iEndSeqNo;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch(iTag) 
				{
					case TAG_BeginSeqNo:
						_iBeginSeqNo = (int)value;
						break;
					case TAG_EndSeqNo:
						_iEndSeqNo = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}
	}
}
