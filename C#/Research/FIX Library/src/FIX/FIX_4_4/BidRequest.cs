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
	/// Summary description for BidRequest.
	/// </summary>
	public class BidRequest : Message
	{
		public const int TAG_BidID = 390;
		public const int TAG_ClientBidID = 391;
		public const int TAG_BidRequestTransType = 374;
		public const int TAG_ListName = 392;
		public const int TAG_TotNoRelatedSym = 393;
		public const int TAG_BidType = 394;
		public const int TAG_NumTickets = 395;
		public const int TAG_Currency = 15;
		public const int TAG_SideValue1 = 396;
		public const int TAG_SideValue2 = 397;
		public const int TAG_NoBidDescriptors = 398;
		public const int TAG_BidDescriptorType = 399;
		public const int TAG_BidDescriptor = 400;
		public const int TAG_SideValueInd = 401;
		public const int TAG_LiquidityValue = 404;
		public const int TAG_LiquidityNumSecurities = 441;
		public const int TAG_LiquidityPctLow = 402;
		public const int TAG_LiquidityPctHigh = 403;
		public const int TAG_EFPTrackingError = 405;
		public const int TAG_FairValue = 406;
		public const int TAG_OutsideIndexPct = 407;
		public const int TAG_ValueOfFutures = 408;
		public const int TAG_NoBidComponents = 420;
		public const int TAG_ListID = 66;
		public const int TAG_Side = 54;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_NetGrossInd = 430;
		public const int TAG_SettlType = 63;
		public const int TAG_SettlDate = 64;
		public const int TAG_Account = 1;
		public const int TAG_AcctIDSource = 660;
		public const int TAG_LiquidityIndType = 409;
		public const int TAG_WtAverageLiquidity = 410;
		public const int TAG_ExchangeForPhysical = 411;
		public const int TAG_OutMainCntryUIndex = 412;
		public const int TAG_CrossPercent = 413;
		public const int TAG_ProgRptReqs = 414;
		public const int TAG_ProgPeriodInterval = 415;
		public const int TAG_IncTaxInd = 416;
		public const int TAG_ForexReq = 121;
		public const int TAG_NumBidders = 417;
		public const int TAG_TradeDate = 75;
		public const int TAG_BidTradeType = 418;
		public const int TAG_BasisPxType = 419;
		public const int TAG_StrikeTime = 443;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sBidID;
		private string _sClientBidID;
		private char _cBidRequestTransType;
		private string _sListName;
		private int _iTotNoRelatedSym;
		private int _iBidType;
		private int _iNumTickets;
		private string _sCurrency;
		private double _dSideValue1;
		private double _dSideValue2;
		private int _iNoBidDescriptors;
		private BidRequestBidDescriptorList _listBidDescriptor = new BidRequestBidDescriptorList();
		private int _iNoBidComponents;
		private BidRequestBidComponentList _listBidComponent = new BidRequestBidComponentList();
		private int _iLiquidityIndType;
		private double _dWtAverageLiquidity;
		private bool _bExchangeForPhysical;
		private double _dOutMainCntryUIndex;
		private double _dCrossPercent;
		private int _iProgRptReqs;
		private int _iProgPeriodInterval;
		private int _iIncTaxInd;
		private bool _bForexReq;
		private int _iNumBidders;
		private DateTime _dtTradeDate;
		private char _cBidTradeType;
		private char _cBasisPxType;
		private DateTime _dtStrikeTime;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public BidRequest() : base()
		{
			_sMsgType = Values.MsgType.BidRequest;
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
		public char BidRequestTransType
		{
			get { return _cBidRequestTransType; }
			set { _cBidRequestTransType = value; }
		}
		public string ListName
		{
			get { return _sListName; }
			set { _sListName = value; }
		}
		public int TotNoRelatedSym
		{
			get { return _iTotNoRelatedSym; }
			set { _iTotNoRelatedSym = value; }
		}
		public int BidType
		{
			get { return _iBidType; }
			set { _iBidType = value; }
		}
		public int NumTickets
		{
			get { return _iNumTickets; }
			set { _iNumTickets = value; }
		}
		public string Currency
		{
			get { return _sCurrency; }
			set { _sCurrency = value; }
		}
		public double SideValue1
		{
			get { return _dSideValue1; }
			set { _dSideValue1 = value; }
		}
		public double SideValue2
		{
			get { return _dSideValue2; }
			set { _dSideValue2 = value; }
		}
		public int NoBidDescriptors
		{
			get { return _iNoBidDescriptors; }
			set { _iNoBidDescriptors = value; }
		}
		public BidRequestBidDescriptorList BidDescriptor 
		{
			get { return _listBidDescriptor; }
		}
		public int NoBidComponents
		{
			get { return _iNoBidComponents; }
			set { _iNoBidComponents = value; }
		}
		public BidRequestBidComponentList BidComponent 
		{
			get { return _listBidComponent; }
		}
		public int LiquidityIndType
		{
			get { return _iLiquidityIndType; }
			set { _iLiquidityIndType = value; }
		}
		public double WtAverageLiquidity
		{
			get { return _dWtAverageLiquidity; }
			set { _dWtAverageLiquidity = value; }
		}
		public bool ExchangeForPhysical
		{
			get { return _bExchangeForPhysical; }
			set { _bExchangeForPhysical = value; }
		}
		public double OutMainCntryUIndex
		{
			get { return _dOutMainCntryUIndex; }
			set { _dOutMainCntryUIndex = value; }
		}
		public double CrossPercent
		{
			get { return _dCrossPercent; }
			set { _dCrossPercent = value; }
		}
		public int ProgRptReqs
		{
			get { return _iProgRptReqs; }
			set { _iProgRptReqs = value; }
		}
		public int ProgPeriodInterval
		{
			get { return _iProgPeriodInterval; }
			set { _iProgPeriodInterval = value; }
		}
		public int IncTaxInd
		{
			get { return _iIncTaxInd; }
			set { _iIncTaxInd = value; }
		}
		public bool ForexReq
		{
			get { return _bForexReq; }
			set { _bForexReq = value; }
		}
		public int NumBidders
		{
			get { return _iNumBidders; }
			set { _iNumBidders = value; }
		}
		public DateTime TradeDate
		{
			get { return _dtTradeDate; }
			set { _dtTradeDate = value; }
		}
		public char BidTradeType
		{
			get { return _cBidTradeType; }
			set { _cBidTradeType = value; }
		}
		public char BasisPxType
		{
			get { return _cBasisPxType; }
			set { _cBasisPxType = value; }
		}
		public DateTime StrikeTime
		{
			get { return _dtStrikeTime; }
			set { _dtStrikeTime = value; }
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
					case TAG_BidID:
						return _sBidID;
					case TAG_ClientBidID:
						return _sClientBidID;
					case TAG_BidRequestTransType:
						return _cBidRequestTransType;
					case TAG_ListName:
						return _sListName;
					case TAG_TotNoRelatedSym:
						return _iTotNoRelatedSym;
					case TAG_BidType:
						return _iBidType;
					case TAG_NumTickets:
						return _iNumTickets;
					case TAG_Currency:
						return _sCurrency;
					case TAG_SideValue1:
						return _dSideValue1;
					case TAG_SideValue2:
						return _dSideValue2;
					case TAG_NoBidDescriptors:
						return _iNoBidDescriptors;
					case TAG_NoBidComponents:
						return _iNoBidComponents;
					case TAG_LiquidityIndType:
						return _iLiquidityIndType;
					case TAG_WtAverageLiquidity:
						return _dWtAverageLiquidity;
					case TAG_ExchangeForPhysical:
						return _bExchangeForPhysical;
					case TAG_OutMainCntryUIndex:
						return _dOutMainCntryUIndex;
					case TAG_CrossPercent:
						return _dCrossPercent;
					case TAG_ProgRptReqs:
						return _iProgRptReqs;
					case TAG_ProgPeriodInterval:
						return _iProgPeriodInterval;
					case TAG_IncTaxInd:
						return _iIncTaxInd;
					case TAG_ForexReq:
						return _bForexReq;
					case TAG_NumBidders:
						return _iNumBidders;
					case TAG_TradeDate:
						return _dtTradeDate;
					case TAG_BidTradeType:
						return _cBidTradeType;
					case TAG_BasisPxType:
						return _cBasisPxType;
					case TAG_StrikeTime:
						return _dtStrikeTime;
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
					case TAG_BidID:
						_sBidID = (string)value;
						break;
					case TAG_ClientBidID:
						_sClientBidID = (string)value;
						break;
					case TAG_BidRequestTransType:
						_cBidRequestTransType = (char)value;
						break;
					case TAG_ListName:
						_sListName = (string)value;
						break;
					case TAG_TotNoRelatedSym:
						_iTotNoRelatedSym = (int)value;
						break;
					case TAG_BidType:
						_iBidType = (int)value;
						break;
					case TAG_NumTickets:
						_iNumTickets = (int)value;
						break;
					case TAG_Currency:
						_sCurrency = (string)value;
						break;
					case TAG_SideValue1:
						_dSideValue1 = (double)value;
						break;
					case TAG_SideValue2:
						_dSideValue2 = (double)value;
						break;
					case TAG_NoBidDescriptors:
						_iNoBidDescriptors = (int)value;
						break;
					case TAG_NoBidComponents:
						_iNoBidComponents = (int)value;
						break;
					case TAG_LiquidityIndType:
						_iLiquidityIndType = (int)value;
						break;
					case TAG_WtAverageLiquidity:
						_dWtAverageLiquidity = (double)value;
						break;
					case TAG_ExchangeForPhysical:
						_bExchangeForPhysical = (bool)value;
						break;
					case TAG_OutMainCntryUIndex:
						_dOutMainCntryUIndex = (double)value;
						break;
					case TAG_CrossPercent:
						_dCrossPercent = (double)value;
						break;
					case TAG_ProgRptReqs:
						_iProgRptReqs = (int)value;
						break;
					case TAG_ProgPeriodInterval:
						_iProgPeriodInterval = (int)value;
						break;
					case TAG_IncTaxInd:
						_iIncTaxInd = (int)value;
						break;
					case TAG_ForexReq:
						_bForexReq = (bool)value;
						break;
					case TAG_NumBidders:
						_iNumBidders = (int)value;
						break;
					case TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case TAG_BidTradeType:
						_cBidTradeType = (char)value;
						break;
					case TAG_BasisPxType:
						_cBasisPxType = (char)value;
						break;
					case TAG_StrikeTime:
						_dtStrikeTime = (DateTime)value;
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

	public class BidRequestBidDescriptor
	{
		private int _iBidDescriptorType;
		private string _sBidDescriptor;
		private int _iSideValueInd;
		private double _dLiquidityValue;
		private int _iLiquidityNumSecurities;
		private double _dLiquidityPctLow;
		private double _dLiquidityPctHigh;
		private double _dEFPTrackingError;
		private double _dFairValue;
		private double _dOutsideIndexPct;
		private double _dValueOfFutures;

		public int BidDescriptorType
		{
			get { return _iBidDescriptorType; }
			set { _iBidDescriptorType = value; }
		}
		public string BidDescriptor
		{
			get { return _sBidDescriptor; }
			set { _sBidDescriptor = value; }
		}
		public int SideValueInd
		{
			get { return _iSideValueInd; }
			set { _iSideValueInd = value; }
		}
		public double LiquidityValue
		{
			get { return _dLiquidityValue; }
			set { _dLiquidityValue = value; }
		}
		public int LiquidityNumSecurities
		{
			get { return _iLiquidityNumSecurities; }
			set { _iLiquidityNumSecurities = value; }
		}
		public double LiquidityPctLow
		{
			get { return _dLiquidityPctLow; }
			set { _dLiquidityPctLow = value; }
		}
		public double LiquidityPctHigh
		{
			get { return _dLiquidityPctHigh; }
			set { _dLiquidityPctHigh = value; }
		}
		public double EFPTrackingError
		{
			get { return _dEFPTrackingError; }
			set { _dEFPTrackingError = value; }
		}
		public double FairValue
		{
			get { return _dFairValue; }
			set { _dFairValue = value; }
		}
		public double OutsideIndexPct
		{
			get { return _dOutsideIndexPct; }
			set { _dOutsideIndexPct = value; }
		}
		public double ValueOfFutures
		{
			get { return _dValueOfFutures; }
			set { _dValueOfFutures = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case BidRequest.TAG_BidDescriptorType:
						return _iBidDescriptorType;
					case BidRequest.TAG_BidDescriptor:
						return _sBidDescriptor;
					case BidRequest.TAG_SideValueInd:
						return _iSideValueInd;
					case BidRequest.TAG_LiquidityValue:
						return _dLiquidityValue;
					case BidRequest.TAG_LiquidityNumSecurities:
						return _iLiquidityNumSecurities;
					case BidRequest.TAG_LiquidityPctLow:
						return _dLiquidityPctLow;
					case BidRequest.TAG_LiquidityPctHigh:
						return _dLiquidityPctHigh;
					case BidRequest.TAG_EFPTrackingError:
						return _dEFPTrackingError;
					case BidRequest.TAG_FairValue:
						return _dFairValue;
					case BidRequest.TAG_OutsideIndexPct:
						return _dOutsideIndexPct;
					case BidRequest.TAG_ValueOfFutures:
						return _dValueOfFutures;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case BidRequest.TAG_BidDescriptorType:
						_iBidDescriptorType = (int)value;
						break;
					case BidRequest.TAG_BidDescriptor:
						_sBidDescriptor = (string)value;
						break;
					case BidRequest.TAG_SideValueInd:
						_iSideValueInd = (int)value;
						break;
					case BidRequest.TAG_LiquidityValue:
						_dLiquidityValue = (double)value;
						break;
					case BidRequest.TAG_LiquidityNumSecurities:
						_iLiquidityNumSecurities = (int)value;
						break;
					case BidRequest.TAG_LiquidityPctLow:
						_dLiquidityPctLow = (double)value;
						break;
					case BidRequest.TAG_LiquidityPctHigh:
						_dLiquidityPctHigh = (double)value;
						break;
					case BidRequest.TAG_EFPTrackingError:
						_dEFPTrackingError = (double)value;
						break;
					case BidRequest.TAG_FairValue:
						_dFairValue = (double)value;
						break;
					case BidRequest.TAG_OutsideIndexPct:
						_dOutsideIndexPct = (double)value;
						break;
					case BidRequest.TAG_ValueOfFutures:
						_dValueOfFutures = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class BidRequestBidDescriptorList
	{
		private ArrayList _al;
		private BidRequestBidDescriptor _last;

		public BidRequestBidDescriptor this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (BidRequestBidDescriptor)_al[i];
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

		public void Add(BidRequestBidDescriptor item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(BidRequestBidDescriptor item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public BidRequestBidDescriptor Last
		{
			get { return _last; }
		}
	}

	public class BidRequestBidComponent
	{
		private string _sListID;
		private char _cSide;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private int _iNetGrossInd;
		private char _cSettlType;
		private DateTime _dtSettlDate;
		private string _sAccount;
		private int _iAcctIDSource;

		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
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

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case BidRequest.TAG_ListID:
						return _sListID;
					case BidRequest.TAG_Side:
						return _cSide;
					case BidRequest.TAG_TradingSessionID:
						return _sTradingSessionID;
					case BidRequest.TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case BidRequest.TAG_NetGrossInd:
						return _iNetGrossInd;
					case BidRequest.TAG_SettlType:
						return _cSettlType;
					case BidRequest.TAG_SettlDate:
						return _dtSettlDate;
					case BidRequest.TAG_Account:
						return _sAccount;
					case BidRequest.TAG_AcctIDSource:
						return _iAcctIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case BidRequest.TAG_ListID:
						_sListID = (string)value;
						break;
					case BidRequest.TAG_Side:
						_cSide = (char)value;
						break;
					case BidRequest.TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case BidRequest.TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case BidRequest.TAG_NetGrossInd:
						_iNetGrossInd = (int)value;
						break;
					case BidRequest.TAG_SettlType:
						_cSettlType = (char)value;
						break;
					case BidRequest.TAG_SettlDate:
						_dtSettlDate = (DateTime)value;
						break;
					case BidRequest.TAG_Account:
						_sAccount = (string)value;
						break;
					case BidRequest.TAG_AcctIDSource:
						_iAcctIDSource = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class BidRequestBidComponentList
	{
		private ArrayList _al;
		private BidRequestBidComponent _last;

		public BidRequestBidComponent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (BidRequestBidComponent)_al[i];
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

		public void Add(BidRequestBidComponent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(BidRequestBidComponent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public BidRequestBidComponent Last
		{
			get { return _last; }
		}
	}
}
