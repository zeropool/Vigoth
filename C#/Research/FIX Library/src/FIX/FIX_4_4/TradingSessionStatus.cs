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
	/// Summary description for TradingSessionStatus.
	/// </summary>
	public class TradingSessionStatus : Message
	{
		public const int TAG_TradSesReqID = 335;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_TradSesMethod = 338;
		public const int TAG_TradSesMode = 339;
		public const int TAG_UnsolicitedIndicator = 325;
		public const int TAG_TradSesStatus = 340;
		public const int TAG_TradSesStatusRejReason = 567;
		public const int TAG_TradSesStartTime = 341;
		public const int TAG_TradSesOpenTime = 342;
		public const int TAG_TradSesPreCloseTime = 343;
		public const int TAG_TradSesCloseTime = 344;
		public const int TAG_TradSesEndTime = 345;
		public const int TAG_TotalVolumeTraded = 387;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sTradSesReqID;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private int _iTradSesMethod;
		private int _iTradSesMode;
		private bool _bUnsolicitedIndicator;
		private int _iTradSesStatus;
		private int _iTradSesStatusRejReason;
		private DateTime _dtTradSesStartTime;
		private DateTime _dtTradSesOpenTime;
		private DateTime _dtTradSesPreCloseTime;
		private DateTime _dtTradSesCloseTime;
		private DateTime _dtTradSesEndTime;
		private int _iTotalVolumeTraded;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public TradingSessionStatus() : base()
		{
			_sMsgType = Values.MsgType.TradingSessionStatus;
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
		public bool UnsolicitedIndicator
		{
			get { return _bUnsolicitedIndicator; }
			set { _bUnsolicitedIndicator = value; }
		}
		public int TradSesStatus
		{
			get { return _iTradSesStatus; }
			set { _iTradSesStatus = value; }
		}
		public int TradSesStatusRejReason
		{
			get { return _iTradSesStatusRejReason; }
			set { _iTradSesStatusRejReason = value; }
		}
		public DateTime TradSesStartTime
		{
			get { return _dtTradSesStartTime; }
			set { _dtTradSesStartTime = value; }
		}
		public DateTime TradSesOpenTime
		{
			get { return _dtTradSesOpenTime; }
			set { _dtTradSesOpenTime = value; }
		}
		public DateTime TradSesPreCloseTime
		{
			get { return _dtTradSesPreCloseTime; }
			set { _dtTradSesPreCloseTime = value; }
		}
		public DateTime TradSesCloseTime
		{
			get { return _dtTradSesCloseTime; }
			set { _dtTradSesCloseTime = value; }
		}
		public DateTime TradSesEndTime
		{
			get { return _dtTradSesEndTime; }
			set { _dtTradSesEndTime = value; }
		}
		public int TotalVolumeTraded
		{
			get { return _iTotalVolumeTraded; }
			set { _iTotalVolumeTraded = value; }
		}
		public string Text
		{
			get { return _sText; }
			set { _sText = value; }
		}
		public int EncodedTextLen
		{
			get { return _iEncodedTextLen; }
			set { _iEncodedTextLen = value; }
		}
		public string EncodedText
		{
			get { return _sEncodedText; }
			set { _sEncodedText = value; }
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
					case TAG_UnsolicitedIndicator:
						return _bUnsolicitedIndicator;
					case TAG_TradSesStatus:
						return _iTradSesStatus;
					case TAG_TradSesStatusRejReason:
						return _iTradSesStatusRejReason;
					case TAG_TradSesStartTime:
						return _dtTradSesStartTime;
					case TAG_TradSesOpenTime:
						return _dtTradSesOpenTime;
					case TAG_TradSesPreCloseTime:
						return _dtTradSesPreCloseTime;
					case TAG_TradSesCloseTime:
						return _dtTradSesCloseTime;
					case TAG_TradSesEndTime:
						return _dtTradSesEndTime;
					case TAG_TotalVolumeTraded:
						return _iTotalVolumeTraded;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
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
					case TAG_UnsolicitedIndicator:
						_bUnsolicitedIndicator = (bool)value;
						break;
					case TAG_TradSesStatus:
						_iTradSesStatus = (int)value;
						break;
					case TAG_TradSesStatusRejReason:
						_iTradSesStatusRejReason = (int)value;
						break;
					case TAG_TradSesStartTime:
						_dtTradSesStartTime = (DateTime)value;
						break;
					case TAG_TradSesOpenTime:
						_dtTradSesOpenTime = (DateTime)value;
						break;
					case TAG_TradSesPreCloseTime:
						_dtTradSesPreCloseTime = (DateTime)value;
						break;
					case TAG_TradSesCloseTime:
						_dtTradSesCloseTime = (DateTime)value;
						break;
					case TAG_TradSesEndTime:
						_dtTradSesEndTime = (DateTime)value;
						break;
					case TAG_TotalVolumeTraded:
						_iTotalVolumeTraded = (int)value;
						break;
					case TAG_Text:
						_sText = (string)value;
						break;
					case TAG_EncodedTextLen:
						_iEncodedTextLen = (int)value;
						break;
					case TAG_EncodedText:
						_sEncodedText = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}
}
