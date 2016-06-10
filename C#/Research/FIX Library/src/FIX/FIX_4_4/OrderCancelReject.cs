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
	/// Summary description for OrderCancelReject.
	/// </summary>
	public class OrderCancelReject : Message
	{
		public const int TAG_OrderID = 37;
		public const int TAG_SecondaryOrderID = 198;
		public const int TAG_SecondaryClOrdID = 526;
		public const int TAG_ClOrdID = 11;
		public const int TAG_ClOrdLinkID = 583;
		public const int TAG_OrigClOrdID = 41;
		public const int TAG_OrdStatus = 39;
		public const int TAG_WorkingIndicator = 636;
		public const int TAG_OrigOrdModTime = 586;
		public const int TAG_ListID = 66;
		public const int TAG_Account = 1;
		public const int TAG_AcctIDSource = 660;
		public const int TAG_AccountType = 581;
		public const int TAG_TradeOriginationDate = 229;
		public const int TAG_TradeDate = 75;
		public const int TAG_TransactTime = 60;
		public const int TAG_CxlRejResponseTo = 434;
		public const int TAG_CxlRejReason = 102;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sOrderID;
		private string _sSecondaryOrderID;
		private string _sSecondaryClOrdID;
		private string _sClOrdID;
		private string _sClOrdLinkID;
		private string _sOrigClOrdID;
		private char _cOrdStatus;
		private bool _bWorkingIndicator;
		private DateTime _dtOrigOrdModTime;
		private string _sListID;
		private string _sAccount;
		private int _iAcctIDSource;
		private int _iAccountType;
		private DateTime _dtTradeOriginationDate;
		private DateTime _dtTradeDate;
		private DateTime _dtTransactTime;
		private char _cCxlRejResponseTo;
		private int _iCxlRejReason;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public OrderCancelReject() : base()
		{
			_sMsgType = Values.MsgType.OrderCancelReject;
		}

		public string OrderID
		{
			get { return _sOrderID; }
			set { _sOrderID = value; }
		}
		public string SecondaryOrderID
		{
			get { return _sSecondaryOrderID; }
			set { _sSecondaryOrderID = value; }
		}
		public string SecondaryClOrdID
		{
			get { return _sSecondaryClOrdID; }
			set { _sSecondaryClOrdID = value; }
		}
		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public string ClOrdLinkID
		{
			get { return _sClOrdLinkID; }
			set { _sClOrdLinkID = value; }
		}
		public string OrigClOrdID
		{
			get { return _sOrigClOrdID; }
			set { _sOrigClOrdID = value; }
		}
		public char OrdStatus
		{
			get { return _cOrdStatus; }
			set { _cOrdStatus = value; }
		}
		public bool WorkingIndicator
		{
			get { return _bWorkingIndicator; }
			set { _bWorkingIndicator = value; }
		}
		public DateTime OrigOrdModTime
		{
			get { return _dtOrigOrdModTime; }
			set { _dtOrigOrdModTime = value; }
		}
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public string Account
		{
			get { return _sAccount; }
			set { _sAccount = value; }
		}
		public int AcctIDSource
		{
			get { return _iAcctIDSource; }
			set { _iAcctIDSource = value; }
		}
		public int AccountType
		{
			get { return _iAccountType; }
			set { _iAccountType = value; }
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
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public char CxlRejResponseTo
		{
			get { return _cCxlRejResponseTo; }
			set { _cCxlRejResponseTo = value; }
		}
		public int CxlRejReason
		{
			get { return _iCxlRejReason; }
			set { _iCxlRejReason = value; }
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
					case TAG_OrderID:
						return _sOrderID;
					case TAG_SecondaryOrderID:
						return _sSecondaryOrderID;
					case TAG_SecondaryClOrdID:
						return _sSecondaryClOrdID;
					case TAG_ClOrdID:
						return _sClOrdID;
					case TAG_ClOrdLinkID:
						return _sClOrdLinkID;
					case TAG_OrigClOrdID:
						return _sOrigClOrdID;
					case TAG_OrdStatus:
						return _cOrdStatus;
					case TAG_WorkingIndicator:
						return _bWorkingIndicator;
					case TAG_OrigOrdModTime:
						return _dtOrigOrdModTime;
					case TAG_ListID:
						return _sListID;
					case TAG_Account:
						return _sAccount;
					case TAG_AcctIDSource:
						return _iAcctIDSource;
					case TAG_AccountType:
						return _iAccountType;
					case TAG_TradeOriginationDate:
						return _dtTradeOriginationDate;
					case TAG_TradeDate:
						return _dtTradeDate;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_CxlRejResponseTo:
						return _cCxlRejResponseTo;
					case TAG_CxlRejReason:
						return _iCxlRejReason;
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
					case TAG_OrderID:
						_sOrderID = (string)value;
						break;
					case TAG_SecondaryOrderID:
						_sSecondaryOrderID = (string)value;
						break;
					case TAG_SecondaryClOrdID:
						_sSecondaryClOrdID = (string)value;
						break;
					case TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case TAG_ClOrdLinkID:
						_sClOrdLinkID = (string)value;
						break;
					case TAG_OrigClOrdID:
						_sOrigClOrdID = (string)value;
						break;
					case TAG_OrdStatus:
						_cOrdStatus = (char)value;
						break;
					case TAG_WorkingIndicator:
						_bWorkingIndicator = (bool)value;
						break;
					case TAG_OrigOrdModTime:
						_dtOrigOrdModTime = (DateTime)value;
						break;
					case TAG_ListID:
						_sListID = (string)value;
						break;
					case TAG_Account:
						_sAccount = (string)value;
						break;
					case TAG_AcctIDSource:
						_iAcctIDSource = (int)value;
						break;
					case TAG_AccountType:
						_iAccountType = (int)value;
						break;
					case TAG_TradeOriginationDate:
						_dtTradeOriginationDate = (DateTime)value;
						break;
					case TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_CxlRejResponseTo:
						_cCxlRejResponseTo = (char)value;
						break;
					case TAG_CxlRejReason:
						_iCxlRejReason = (int)value;
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
