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
	/// Summary description for ConfirmationAck.
	/// </summary>
	public class ConfirmationAck : Message
	{
		public const int TAG_ConfirmID = 664;
		public const int TAG_TradeDate = 75;
		public const int TAG_TransactTime = 60;
		public const int TAG_AffirmStatus = 940;
		public const int TAG_ConfirmRejReason = 774;
		public const int TAG_MatchStatus = 573;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sConfirmID;
		private DateTime _dtTradeDate;
		private DateTime _dtTransactTime;
		private int _iAffirmStatus;
		private int _iConfirmRejReason;
		private char _cMatchStatus;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public ConfirmationAck() : base()
		{
			_sMsgType = Values.MsgType.ConfirmationAck;
		}

		public string ConfirmID
		{
			get { return _sConfirmID; }
			set { _sConfirmID = value; }
		}
		public DateTime TradeDate
		{
			get { return _dtTradeDate; }
			set { _dtTradeDate = value; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public int AffirmStatus
		{
			get { return _iAffirmStatus; }
			set { _iAffirmStatus = value; }
		}
		public int ConfirmRejReason
		{
			get { return _iConfirmRejReason; }
			set { _iConfirmRejReason = value; }
		}
		public char MatchStatus
		{
			get { return _cMatchStatus; }
			set { _cMatchStatus = value; }
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
					case TAG_ConfirmID:
						return _sConfirmID;
					case TAG_TradeDate:
						return _dtTradeDate;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_AffirmStatus:
						return _iAffirmStatus;
					case TAG_ConfirmRejReason:
						return _iConfirmRejReason;
					case TAG_MatchStatus:
						return _cMatchStatus;
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
					case TAG_ConfirmID:
						_sConfirmID = (string)value;
						break;
					case TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_AffirmStatus:
						_iAffirmStatus = (int)value;
						break;
					case TAG_ConfirmRejReason:
						_iConfirmRejReason = (int)value;
						break;
					case TAG_MatchStatus:
						_cMatchStatus = (char)value;
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
