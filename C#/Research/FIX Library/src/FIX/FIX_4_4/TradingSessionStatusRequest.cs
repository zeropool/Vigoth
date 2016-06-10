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
	/// Summary description for TradingSessionStatusRequest.
	/// </summary>
	public class TradingSessionStatusRequest : Message
	{
		public const int TAG_TradSesReqID = 335;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_TradSesMethod = 338;
		public const int TAG_TradSesMode = 339;
		public const int TAG_SubscriptionRequestType = 263;

		private string _sTradSesReqID;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private int _iTradSesMethod;
		private int _iTradSesMode;
		private char _cSubscriptionRequestType;

		public TradingSessionStatusRequest() : base()
		{
			_sMsgType = Values.MsgType.TradingSessionStatusRequest;
		}

		public string TradSesReqID
		{
			get { return _sTradSesReqID; }
			set { _sTradSesReqID = value; }
		}
		public string TradingSessionID
		{
			get { return _sTradingSessionID; }
			set { _sTradingSessionID = value; }
		}
		public string TradingSessionSubID
		{
			get { return _sTradingSessionSubID; }
			set { _sTradingSessionSubID = value; }
		}
		public int TradSesMethod
		{
			get { return _iTradSesMethod; }
			set { _iTradSesMethod = value; }
		}
		public int TradSesMode
		{
			get { return _iTradSesMode; }
			set { _iTradSesMode = value; }
		}
		public char SubscriptionRequestType
		{
			get { return _cSubscriptionRequestType; }
			set { _cSubscriptionRequestType = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_TradSesReqID:
						return _sTradSesReqID;
					case TAG_TradingSessionID:
						return _sTradingSessionID;
					case TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case TAG_TradSesMethod:
						return _iTradSesMethod;
					case TAG_TradSesMode:
						return _iTradSesMode;
					case TAG_SubscriptionRequestType:
						return _cSubscriptionRequestType;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_TradSesReqID:
						_sTradSesReqID = (string)value;
						break;
					case TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case TAG_TradSesMethod:
						_iTradSesMethod = (int)value;
						break;
					case TAG_TradSesMode:
						_iTradSesMode = (int)value;
						break;
					case TAG_SubscriptionRequestType:
						_cSubscriptionRequestType = (char)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}
}
