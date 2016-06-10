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
	/// Summary description for ListCancelRequest.
	/// </summary>
	public class ListCancelRequest : Message
	{
		public const int TAG_ListID = 66;
		public const int TAG_TransactTime = 60;
		public const int TAG_TradeOriginationDate = 229;
		public const int TAG_TradeDate = 75;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sListID;
		private DateTime _dtTransactTime;
		private DateTime _dtTradeOriginationDate;
		private DateTime _dtTradeDate;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public ListCancelRequest() : base()
		{
			_sMsgType = Values.MsgType.ListCancelRequest;
		}

		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public DateTime TradeOriginationDate
		{
			get { return _dtTradeOriginationDate; }
			set { _dtTradeOriginationDate = value; }
		}
		public DateTime TradeDate
		{
			get { return _dtTradeDate; }
			set { _dtTradeDate = value; }
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
					case TAG_ListID:
						return _sListID;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_TradeOriginationDate:
						return _dtTradeOriginationDate;
					case TAG_TradeDate:
						return _dtTradeDate;
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
					case TAG_ListID:
						_sListID = (string)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_TradeOriginationDate:
						_dtTradeOriginationDate = (DateTime)value;
						break;
					case TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
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
