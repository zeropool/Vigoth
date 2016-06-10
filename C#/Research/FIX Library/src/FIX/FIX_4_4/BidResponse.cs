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
	/// Summary description for BidResponse.
	/// </summary>
	public class BidResponse : Message
	{
		public const int TAG_BidID = 390;
		public const int TAG_ClientBidID = 391;
		public const int TAG_NoBidComponents = 420;
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_CommCurrency = 479;
		public const int TAG_FundRenewWaiv = 497;
		public const int TAG_ListID = 66;
		public const int TAG_Country = 421;
		public const int TAG_Side = 54;
		public const int TAG_Price = 44;
		public const int TAG_PriceType = 423;
		public const int TAG_FairValue = 406;
		public const int TAG_NetGrossInd = 430;
		public const int TAG_SettlType = 63;
		public const int TAG_SettlDate = 64;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sBidID;
		private string _sClientBidID;
		private int _iNoBidComponents;
		private BidResponseBidComponentList _listBidComponent = new BidResponseBidComponentList();

		public BidResponse() : base()
		{
			_sMsgType = Values.MsgType.BidResponse;
		}

		public string BidID
		{
			get { return _sBidID; }
			set { _sBidID = value; }
		}
		public string ClientBidID
		{
			get { return _sClientBidID; }
			set { _sClientBidID = value; }
		}
		public int NoBidComponents
		{
			get { return _iNoBidComponents; }
			set { _iNoBidComponents = value; }
		}
		public BidResponseBidComponentList BidComponent 
		{
			get { return _listBidComponent; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_BidID:
						return _sBidID;
					case TAG_ClientBidID:
						return _sClientBidID;
					case TAG_NoBidComponents:
						return _iNoBidComponents;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_BidID:
						_sBidID = (string)value;
						break;
					case TAG_ClientBidID:
						_sClientBidID = (string)value;
						break;
					case TAG_NoBidComponents:
						_iNoBidComponents = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class BidResponseBidComponent
	{
		private double _dCommission;
		private char _cCommType;
		private string _sCommCurrency;
		private char _cFundRenewWaiv;
		private string _sListID;
		private string _sCountry;
		private char _cSide;
		private double _dPrice;
		private int _iPriceType;
		private double _dFairValue;
		private int _iNetGrossInd;
		private char _cSettlType;
		private DateTime _dtSettlDate;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public double Commission
		{
			get { return _dCommission; }
			set { _dCommission = value; }
		}
		public char CommType
		{
			get { return _cCommType; }
			set { _cCommType = value; }
		}
		public string CommCurrency
		{
			get { return _sCommCurrency; }
			set { _sCommCurrency = value; }
		}
		public char FundRenewWaiv
		{
			get { return _cFundRenewWaiv; }
			set { _cFundRenewWaiv = value; }
		}
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public string Country
		{
			get { return _sCountry; }
			set { _sCountry = value; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
		}
		public double Price
		{
			get { return _dPrice; }
			set { _dPrice = value; }
		}
		public int PriceType
		{
			get { return _iPriceType; }
			set { _iPriceType = value; }
		}
		public double FairValue
		{
			get { return _dFairValue; }
			set { _dFairValue = value; }
		}
		public int NetGrossInd
		{
			get { return _iNetGrossInd; }
			set { _iNetGrossInd = value; }
		}
		public char SettlType
		{
			get { return _cSettlType; }
			set { _cSettlType = value; }
		}
		public DateTime SettlDate
		{
			get { return _dtSettlDate; }
			set { _dtSettlDate = value; }
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

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case BidResponse.TAG_Commission:
						return _dCommission;
					case BidResponse.TAG_CommType:
						return _cCommType;
					case BidResponse.TAG_CommCurrency:
						return _sCommCurrency;
					case BidResponse.TAG_FundRenewWaiv:
						return _cFundRenewWaiv;
					case BidResponse.TAG_ListID:
						return _sListID;
					case BidResponse.TAG_Country:
						return _sCountry;
					case BidResponse.TAG_Side:
						return _cSide;
					case BidResponse.TAG_Price:
						return _dPrice;
					case BidResponse.TAG_PriceType:
						return _iPriceType;
					case BidResponse.TAG_FairValue:
						return _dFairValue;
					case BidResponse.TAG_NetGrossInd:
						return _iNetGrossInd;
					case BidResponse.TAG_SettlType:
						return _cSettlType;
					case BidResponse.TAG_SettlDate:
						return _dtSettlDate;
					case BidResponse.TAG_TradingSessionID:
						return _sTradingSessionID;
					case BidResponse.TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case BidResponse.TAG_Text:
						return _sText;
					case BidResponse.TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case BidResponse.TAG_EncodedText:
						return _sEncodedText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case BidResponse.TAG_Commission:
						_dCommission = (double)value;
						break;
					case BidResponse.TAG_CommType:
						_cCommType = (char)value;
						break;
					case BidResponse.TAG_CommCurrency:
						_sCommCurrency = (string)value;
						break;
					case BidResponse.TAG_FundRenewWaiv:
						_cFundRenewWaiv = (char)value;
						break;
					case BidResponse.TAG_ListID:
						_sListID = (string)value;
						break;
					case BidResponse.TAG_Country:
						_sCountry = (string)value;
						break;
					case BidResponse.TAG_Side:
						_cSide = (char)value;
						break;
					case BidResponse.TAG_Price:
						_dPrice = (double)value;
						break;
					case BidResponse.TAG_PriceType:
						_iPriceType = (int)value;
						break;
					case BidResponse.TAG_FairValue:
						_dFairValue = (double)value;
						break;
					case BidResponse.TAG_NetGrossInd:
						_iNetGrossInd = (int)value;
						break;
					case BidResponse.TAG_SettlType:
						_cSettlType = (char)value;
						break;
					case BidResponse.TAG_SettlDate:
						_dtSettlDate = (DateTime)value;
						break;
					case BidResponse.TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case BidResponse.TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case BidResponse.TAG_Text:
						_sText = (string)value;
						break;
					case BidResponse.TAG_EncodedTextLen:
						_iEncodedTextLen = (int)value;
						break;
					case BidResponse.TAG_EncodedText:
						_sEncodedText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class BidResponseBidComponentList
	{
		private ArrayList _al;
		private BidResponseBidComponent _last;

		public BidResponseBidComponent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (BidResponseBidComponent)_al[i];
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

		public void Add(BidResponseBidComponent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(BidResponseBidComponent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public BidResponseBidComponent Last
		{
			get { return _last; }
		}
	}
}
