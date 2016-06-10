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
	/// Summary description for MarketDataIncrementalRefresh.
	/// </summary>
	public class MarketDataIncrementalRefresh : Message
	{
		public const int TAG_MDReqID = 262;
		public const int TAG_NoMDEntries = 268;
		public const int TAG_MDUpdateAction = 279;
		public const int TAG_DeleteReason = 285;
		public const int TAG_MDEntryType = 269;
		public const int TAG_MDEntryID = 278;
		public const int TAG_MDEntryRefID = 280;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_SecurityIDSource = 22;
		public const int TAG_NoSecurityAltID = 454;
		public const int TAG_SecurityAltID = 455;
		public const int TAG_SecurityAltIDSource = 456;
		public const int TAG_Product = 460;
		public const int TAG_CFICode = 461;
		public const int TAG_SecurityType = 167;
		public const int TAG_SecuritySubType = 762;
		public const int TAG_MaturityMonthYear = 200;
		public const int TAG_MaturityDate = 541;
		public const int TAG_CouponPaymentDate = 224;
		public const int TAG_IssueDate = 225;
		public const int TAG_RepoCollateralSecurityType = 239;
		public const int TAG_RepurchaseTerm = 226;
		public const int TAG_RepurchaseRate = 227;
		public const int TAG_Factor = 228;
		public const int TAG_CreditRating = 255;
		public const int TAG_InstrRegistry = 543;
		public const int TAG_CountryOfIssue = 470;
		public const int TAG_StateOrProvinceOfIssue = 471;
		public const int TAG_LocaleOfIssue = 472;
		public const int TAG_RedemptionDate = 240;
		public const int TAG_StrikePrice = 202;
		public const int TAG_StrikeCurrency = 947;
		public const int TAG_OptAttribute = 206;
		public const int TAG_ContractMultiplier = 231;
		public const int TAG_CouponRate = 223;
		public const int TAG_SecurityExchange = 207;
		public const int TAG_Issuer = 106;
		public const int TAG_EncodedIssuerLen = 348;
		public const int TAG_EncodedIssuer = 349;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_EncodedSecurityDescLen = 350;
		public const int TAG_EncodedSecurityDesc = 351;
		public const int TAG_Pool = 691;
		public const int TAG_ContractSettlMonth = 667;
		public const int TAG_CPProgram = 875;
		public const int TAG_CPRegType = 876;
		public const int TAG_NoEvents = 864;
		public const int TAG_EventType = 865;
		public const int TAG_EventDate = 866;
		public const int TAG_EventPx = 867;
		public const int TAG_EventText = 868;
		public const int TAG_DatedDate = 873;
		public const int TAG_InterestAccrualDate = 874;
		public const int TAG_NoUnderlyings = 711;
		public const int TAG_UnderlyingSymbol = 311;
		public const int TAG_UnderlyingSymbolSfx = 312;
		public const int TAG_UnderlyingSecurityID = 309;
		public const int TAG_UnderlyingSecurityIDSource = 305;
		public const int TAG_NoUnderlyingSecurityAltID = 457;
		public const int TAG_UnderlyingSecurityAltID = 458;
		public const int TAG_UnderlyingSecurityAltIDSource = 459;
		public const int TAG_UnderlyingProduct = 462;
		public const int TAG_UnderlyingCFICode = 463;
		public const int TAG_UnderlyingSecurityType = 310;
		public const int TAG_UnderlyingSecuritySubType = 763;
		public const int TAG_UnderlyingMaturityMonthYear = 313;
		public const int TAG_UnderlyingMaturityDate = 542;
		public const int TAG_UnderlyingCouponPaymentDate = 241;
		public const int TAG_UnderlyingIssueDate = 242;
		public const int TAG_UnderlyingRepoCollateralSecurityType = 243;
		public const int TAG_UnderlyingRepurchaseTerm = 244;
		public const int TAG_UnderlyingRepurchaseRate = 245;
		public const int TAG_UnderlyingFactor = 246;
		public const int TAG_UnderlyingCreditRating = 256;
		public const int TAG_UnderlyingInstrRegistry = 595;
		public const int TAG_UnderlyingCountryOfIssue = 592;
		public const int TAG_UnderlyingStateOrProvinceOfIssue = 593;
		public const int TAG_UnderlyingLocaleOfIssue = 594;
		public const int TAG_UnderlyingRedemptionDate = 247;
		public const int TAG_UnderlyingStrikePrice = 316;
		public const int TAG_UnderlyingStrikeCurrency = 941;
		public const int TAG_UnderlyingOptAttribute = 317;
		public const int TAG_UnderlyingContractMultiplier = 436;
		public const int TAG_UnderlyingCouponRate = 435;
		public const int TAG_UnderlyingSecurityExchange = 308;
		public const int TAG_UnderlyingIssuer = 306;
		public const int TAG_EncodedUnderlyingIssuerLen = 362;
		public const int TAG_EncodedUnderlyingIssuer = 363;
		public const int TAG_UnderlyingSecurityDesc = 307;
		public const int TAG_EncodedUnderlyingSecurityDescLen = 364;
		public const int TAG_EncodedUnderlyingSecurityDesc = 365;
		public const int TAG_UnderlyingCPProgram = 877;
		public const int TAG_UnderlyingCPRegType = 878;
		public const int TAG_UnderlyingCurrency = 318;
		public const int TAG_UnderlyingQty = 879;
		public const int TAG_UnderlyingPx = 810;
		public const int TAG_UnderlyingDirtyPrice = 882;
		public const int TAG_UnderlyingEndPrice = 883;
		public const int TAG_UnderlyingStartValue = 884;
		public const int TAG_UnderlyingCurrentValue = 885;
		public const int TAG_UnderlyingEndValue = 886;
		public const int TAG_NoLegs = 555;
		public const int TAG_LegSymbol = 600;
		public const int TAG_LegSymbolSfx = 601;
		public const int TAG_LegSecurityID = 602;
		public const int TAG_LegSecurityIDSource = 603;
		public const int TAG_NoLegSecurityAltID = 604;
		public const int TAG_LegSecurityAltID = 605;
		public const int TAG_LegSecurityAltIDSource = 606;
		public const int TAG_LegProduct = 607;
		public const int TAG_LegCFICode = 608;
		public const int TAG_LegSecurityType = 609;
		public const int TAG_LegSecuritySubType = 764;
		public const int TAG_LegMaturityMonthYear = 610;
		public const int TAG_LegMaturityDate = 611;
		public const int TAG_LegCouponPaymentDate = 248;
		public const int TAG_LegIssueDate = 249;
		public const int TAG_LegRepoCollateralSecurityType = 250;
		public const int TAG_LegRepurchaseTerm = 251;
		public const int TAG_LegRepurchaseRate = 252;
		public const int TAG_LegFactor = 253;
		public const int TAG_LegCreditRating = 257;
		public const int TAG_LegInstrRegistry = 599;
		public const int TAG_LegCountryOfIssue = 596;
		public const int TAG_LegStateOrProvinceOfIssue = 597;
		public const int TAG_LegLocaleOfIssue = 598;
		public const int TAG_LegRedemptionDate = 254;
		public const int TAG_LegStrikePrice = 612;
		public const int TAG_LegStrikeCurrency = 942;
		public const int TAG_LegOptAttribute = 613;
		public const int TAG_LegContractMultiplier = 614;
		public const int TAG_LegCouponRate = 615;
		public const int TAG_LegSecurityExchange = 616;
		public const int TAG_LegIssuer = 617;
		public const int TAG_EncodedLegIssuerLen = 618;
		public const int TAG_EncodedLegIssuer = 619;
		public const int TAG_LegSecurityDesc = 620;
		public const int TAG_EncodedLegSecurityDescLen = 621;
		public const int TAG_EncodedLegSecurityDesc = 622;
		public const int TAG_LegRatioQty = 623;
		public const int TAG_LegSide = 624;
		public const int TAG_LegCurrency = 556;
		public const int TAG_LegPool = 740;
		public const int TAG_LegDatedDate = 739;
		public const int TAG_LegContractSettlMonth = 955;
		public const int TAG_LegInterestAccrualDate = 956;
		public const int TAG_FinancialStatus = 291;
		public const int TAG_CorporateAction = 292;
		public const int TAG_MDEntryPx = 270;
		public const int TAG_Currency = 15;
		public const int TAG_MDEntrySize = 271;
		public const int TAG_MDEntryDate = 272;
		public const int TAG_MDEntryTime = 273;
		public const int TAG_TickDirection = 274;
		public const int TAG_MDMkt = 275;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_QuoteCondition = 276;
		public const int TAG_TradeCondition = 277;
		public const int TAG_MDEntryOriginator = 282;
		public const int TAG_LocationID = 283;
		public const int TAG_DeskID = 284;
		public const int TAG_OpenCloseSettlFlag = 286;
		public const int TAG_TimeInForce = 59;
		public const int TAG_ExpireDate = 432;
		public const int TAG_ExpireTime = 126;
		public const int TAG_MinQty = 110;
		public const int TAG_ExecInst = 18;
		public const int TAG_SellerDays = 287;
		public const int TAG_OrderID = 37;
		public const int TAG_QuoteEntryID = 299;
		public const int TAG_MDEntryBuyer = 288;
		public const int TAG_MDEntrySeller = 289;
		public const int TAG_NumberOfOrders = 346;
		public const int TAG_MDEntryPositionNo = 290;
		public const int TAG_Scope = 546;
		public const int TAG_PriceDelta = 811;
		public const int TAG_NetChgPrevDay = 451;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_ApplQueueDepth = 813;
		public const int TAG_ApplQueueResolution = 814;

		private string _sMDReqID;
		private int _iNoMDEntries;
		private MarketDataIncrementalRefreshMDEntrieList _listMDEntrie = new MarketDataIncrementalRefreshMDEntrieList();
		private int _iApplQueueDepth;
		private int _iApplQueueResolution;

		public MarketDataIncrementalRefresh() : base()
		{
			_sMsgType = Values.MsgType.MarketDataIncrementalRefresh;
		}

		public string MDReqID
		{
			get { return _sMDReqID; }
			set { _sMDReqID = value; }
		}
		public int NoMDEntries
		{
			get { return _iNoMDEntries; }
			set { _iNoMDEntries = value; }
		}
		public MarketDataIncrementalRefreshMDEntrieList MDEntrie 
		{
			get { return _listMDEntrie; }
		}
		public int ApplQueueDepth
		{
			get { return _iApplQueueDepth; }
			set { _iApplQueueDepth = value; }
		}
		public int ApplQueueResolution
		{
			get { return _iApplQueueResolution; }
			set { _iApplQueueResolution = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_MDReqID:
						return _sMDReqID;
					case TAG_NoMDEntries:
						return _iNoMDEntries;
					case TAG_ApplQueueDepth:
						return _iApplQueueDepth;
					case TAG_ApplQueueResolution:
						return _iApplQueueResolution;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_MDReqID:
						_sMDReqID = (string)value;
						break;
					case TAG_NoMDEntries:
						_iNoMDEntries = (int)value;
						break;
					case TAG_ApplQueueDepth:
						_iApplQueueDepth = (int)value;
						break;
					case TAG_ApplQueueResolution:
						_iApplQueueResolution = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class MarketDataIncrementalRefreshMDEntrie
	{
		private char _cMDUpdateAction;
		private char _cDeleteReason;
		private char _cMDEntryType;
		private string _sMDEntryID;
		private string _sMDEntryRefID;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private MarketDataIncrementalRefreshSecurityAltIDList _listSecurityAltID = new MarketDataIncrementalRefreshSecurityAltIDList();
		private int _iProduct;
		private string _sCFICode;
		private string _sSecurityType;
		private string _sSecuritySubType;
		private DateTime _dtMaturityMonthYear;
		private DateTime _dtMaturityDate;
		private DateTime _dtCouponPaymentDate;
		private DateTime _dtIssueDate;
		private int _iRepoCollateralSecurityType;
		private int _iRepurchaseTerm;
		private double _dRepurchaseRate;
		private double _dFactor;
		private string _sCreditRating;
		private string _sInstrRegistry;
		private string _sCountryOfIssue;
		private string _sStateOrProvinceOfIssue;
		private string _sLocaleOfIssue;
		private DateTime _dtRedemptionDate;
		private double _dStrikePrice;
		private string _sStrikeCurrency;
		private char _cOptAttribute;
		private double _dContractMultiplier;
		private double _dCouponRate;
		private string _sSecurityExchange;
		private string _sIssuer;
		private int _iEncodedIssuerLen;
		private string _sEncodedIssuer;
		private string _sSecurityDesc;
		private int _iEncodedSecurityDescLen;
		private string _sEncodedSecurityDesc;
		private string _sPool;
		private DateTime _dtContractSettlMonth;
		private int _iCPProgram;
		private string _sCPRegType;
		private int _iNoEvents;
		private MarketDataIncrementalRefreshEventList _listEvent = new MarketDataIncrementalRefreshEventList();
		private DateTime _dtDatedDate;
		private DateTime _dtInterestAccrualDate;
		private int _iNoUnderlyings;
		private MarketDataIncrementalRefreshUnderlyingList _listUnderlying = new MarketDataIncrementalRefreshUnderlyingList();
		private int _iNoLegs;
		private MarketDataIncrementalRefreshLegList _listLeg = new MarketDataIncrementalRefreshLegList();
		private string _sFinancialStatus;
		private string _sCorporateAction;
		private double _dMDEntryPx;
		private string _sCurrency;
		private int _iMDEntrySize;
		private DateTime _dtMDEntryDate;
		private DateTime _dtMDEntryTime;
		private char _cTickDirection;
		private string _sMDMkt;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private string _sQuoteCondition;
		private string _sTradeCondition;
		private string _sMDEntryOriginator;
		private string _sLocationID;
		private string _sDeskID;
		private string _sOpenCloseSettlFlag;
		private char _cTimeInForce;
		private DateTime _dtExpireDate;
		private DateTime _dtExpireTime;
		private int _iMinQty;
		private string _sExecInst;
		private int _iSellerDays;
		private string _sOrderID;
		private string _sQuoteEntryID;
		private string _sMDEntryBuyer;
		private string _sMDEntrySeller;
		private int _iNumberOfOrders;
		private int _iMDEntryPositionNo;
		private string _sScope;
		private double _dPriceDelta;
		private double _dNetChgPrevDay;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public char MDUpdateAction
		{
			get { return _cMDUpdateAction; }
			set { _cMDUpdateAction = value; }
		}
		public char DeleteReason
		{
			get { return _cDeleteReason; }
			set { _cDeleteReason = value; }
		}
		public char MDEntryType
		{
			get { return _cMDEntryType; }
			set { _cMDEntryType = value; }
		}
		public string MDEntryID
		{
			get { return _sMDEntryID; }
			set { _sMDEntryID = value; }
		}
		public string MDEntryRefID
		{
			get { return _sMDEntryRefID; }
			set { _sMDEntryRefID = value; }
		}
		public string Symbol
		{
			get { return _sSymbol; }
			set { _sSymbol = value; }
		}
		public string SymbolSfx
		{
			get { return _sSymbolSfx; }
			set { _sSymbolSfx = value; }
		}
		public string SecurityID
		{
			get { return _sSecurityID; }
			set { _sSecurityID = value; }
		}
		public string SecurityIDSource
		{
			get { return _sSecurityIDSource; }
			set { _sSecurityIDSource = value; }
		}
		public int NoSecurityAltID
		{
			get { return _iNoSecurityAltID; }
			set { _iNoSecurityAltID = value; }
		}
		public MarketDataIncrementalRefreshSecurityAltIDList SecurityAltID 
		{
			get { return _listSecurityAltID; }
		}
		public int Product
		{
			get { return _iProduct; }
			set { _iProduct = value; }
		}
		public string CFICode
		{
			get { return _sCFICode; }
			set { _sCFICode = value; }
		}
		public string SecurityType
		{
			get { return _sSecurityType; }
			set { _sSecurityType = value; }
		}
		public string SecuritySubType
		{
			get { return _sSecuritySubType; }
			set { _sSecuritySubType = value; }
		}
		public DateTime MaturityMonthYear
		{
			get { return _dtMaturityMonthYear; }
			set { _dtMaturityMonthYear = value; }
		}
		public DateTime MaturityDate
		{
			get { return _dtMaturityDate; }
			set { _dtMaturityDate = value; }
		}
		public DateTime CouponPaymentDate
		{
			get { return _dtCouponPaymentDate; }
			set { _dtCouponPaymentDate = value; }
		}
		public DateTime IssueDate
		{
			get { return _dtIssueDate; }
			set { _dtIssueDate = value; }
		}
		public int RepoCollateralSecurityType
		{
			get { return _iRepoCollateralSecurityType; }
			set { _iRepoCollateralSecurityType = value; }
		}
		public int RepurchaseTerm
		{
			get { return _iRepurchaseTerm; }
			set { _iRepurchaseTerm = value; }
		}
		public double RepurchaseRate
		{
			get { return _dRepurchaseRate; }
			set { _dRepurchaseRate = value; }
		}
		public double Factor
		{
			get { return _dFactor; }
			set { _dFactor = value; }
		}
		public string CreditRating
		{
			get { return _sCreditRating; }
			set { _sCreditRating = value; }
		}
		public string InstrRegistry
		{
			get { return _sInstrRegistry; }
			set { _sInstrRegistry = value; }
		}
		public string CountryOfIssue
		{
			get { return _sCountryOfIssue; }
			set { _sCountryOfIssue = value; }
		}
		public string StateOrProvinceOfIssue
		{
			get { return _sStateOrProvinceOfIssue; }
			set { _sStateOrProvinceOfIssue = value; }
		}
		public string LocaleOfIssue
		{
			get { return _sLocaleOfIssue; }
			set { _sLocaleOfIssue = value; }
		}
		public DateTime RedemptionDate
		{
			get { return _dtRedemptionDate; }
			set { _dtRedemptionDate = value; }
		}
		public double StrikePrice
		{
			get { return _dStrikePrice; }
			set { _dStrikePrice = value; }
		}
		public string StrikeCurrency
		{
			get { return _sStrikeCurrency; }
			set { _sStrikeCurrency = value; }
		}
		public char OptAttribute
		{
			get { return _cOptAttribute; }
			set { _cOptAttribute = value; }
		}
		public double ContractMultiplier
		{
			get { return _dContractMultiplier; }
			set { _dContractMultiplier = value; }
		}
		public double CouponRate
		{
			get { return _dCouponRate; }
			set { _dCouponRate = value; }
		}
		public string SecurityExchange
		{
			get { return _sSecurityExchange; }
			set { _sSecurityExchange = value; }
		}
		public string Issuer
		{
			get { return _sIssuer; }
			set { _sIssuer = value; }
		}
		public int EncodedIssuerLen
		{
			get { return _iEncodedIssuerLen; }
			set { _iEncodedIssuerLen = value; }
		}
		public string EncodedIssuer
		{
			get { return _sEncodedIssuer; }
			set { _sEncodedIssuer = value; }
		}
		public string SecurityDesc
		{
			get { return _sSecurityDesc; }
			set { _sSecurityDesc = value; }
		}
		public int EncodedSecurityDescLen
		{
			get { return _iEncodedSecurityDescLen; }
			set { _iEncodedSecurityDescLen = value; }
		}
		public string EncodedSecurityDesc
		{
			get { return _sEncodedSecurityDesc; }
			set { _sEncodedSecurityDesc = value; }
		}
		public string Pool
		{
			get { return _sPool; }
			set { _sPool = value; }
		}
		public DateTime ContractSettlMonth
		{
			get { return _dtContractSettlMonth; }
			set { _dtContractSettlMonth = value; }
		}
		public int CPProgram
		{
			get { return _iCPProgram; }
			set { _iCPProgram = value; }
		}
		public string CPRegType
		{
			get { return _sCPRegType; }
			set { _sCPRegType = value; }
		}
		public int NoEvents
		{
			get { return _iNoEvents; }
			set { _iNoEvents = value; }
		}
		public MarketDataIncrementalRefreshEventList Event 
		{
			get { return _listEvent; }
		}
		public DateTime DatedDate
		{
			get { return _dtDatedDate; }
			set { _dtDatedDate = value; }
		}
		public DateTime InterestAccrualDate
		{
			get { return _dtInterestAccrualDate; }
			set { _dtInterestAccrualDate = value; }
		}
		public int NoUnderlyings
		{
			get { return _iNoUnderlyings; }
			set { _iNoUnderlyings = value; }
		}
		public MarketDataIncrementalRefreshUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
		}
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public MarketDataIncrementalRefreshLegList Leg 
		{
			get { return _listLeg; }
		}
		public string FinancialStatus
		{
			get { return _sFinancialStatus; }
			set { _sFinancialStatus = value; }
		}
		public string CorporateAction
		{
			get { return _sCorporateAction; }
			set { _sCorporateAction = value; }
		}
		public double MDEntryPx
		{
			get { return _dMDEntryPx; }
			set { _dMDEntryPx = value; }
		}
		public string Currency
		{
			get { return _sCurrency; }
			set { _sCurrency = value; }
		}
		public int MDEntrySize
		{
			get { return _iMDEntrySize; }
			set { _iMDEntrySize = value; }
		}
		public DateTime MDEntryDate
		{
			get { return _dtMDEntryDate; }
			set { _dtMDEntryDate = value; }
		}
		public DateTime MDEntryTime
		{
			get { return _dtMDEntryTime; }
			set { _dtMDEntryTime = value; }
		}
		public char TickDirection
		{
			get { return _cTickDirection; }
			set { _cTickDirection = value; }
		}
		public string MDMkt
		{
			get { return _sMDMkt; }
			set { _sMDMkt = value; }
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
		public string QuoteCondition
		{
			get { return _sQuoteCondition; }
			set { _sQuoteCondition = value; }
		}
		public string TradeCondition
		{
			get { return _sTradeCondition; }
			set { _sTradeCondition = value; }
		}
		public string MDEntryOriginator
		{
			get { return _sMDEntryOriginator; }
			set { _sMDEntryOriginator = value; }
		}
		public string LocationID
		{
			get { return _sLocationID; }
			set { _sLocationID = value; }
		}
		public string DeskID
		{
			get { return _sDeskID; }
			set { _sDeskID = value; }
		}
		public string OpenCloseSettlFlag
		{
			get { return _sOpenCloseSettlFlag; }
			set { _sOpenCloseSettlFlag = value; }
		}
		public char TimeInForce
		{
			get { return _cTimeInForce; }
			set { _cTimeInForce = value; }
		}
		public DateTime ExpireDate
		{
			get { return _dtExpireDate; }
			set { _dtExpireDate = value; }
		}
		public DateTime ExpireTime
		{
			get { return _dtExpireTime; }
			set { _dtExpireTime = value; }
		}
		public int MinQty
		{
			get { return _iMinQty; }
			set { _iMinQty = value; }
		}
		public string ExecInst
		{
			get { return _sExecInst; }
			set { _sExecInst = value; }
		}
		public int SellerDays
		{
			get { return _iSellerDays; }
			set { _iSellerDays = value; }
		}
		public string OrderID
		{
			get { return _sOrderID; }
			set { _sOrderID = value; }
		}
		public string QuoteEntryID
		{
			get { return _sQuoteEntryID; }
			set { _sQuoteEntryID = value; }
		}
		public string MDEntryBuyer
		{
			get { return _sMDEntryBuyer; }
			set { _sMDEntryBuyer = value; }
		}
		public string MDEntrySeller
		{
			get { return _sMDEntrySeller; }
			set { _sMDEntrySeller = value; }
		}
		public int NumberOfOrders
		{
			get { return _iNumberOfOrders; }
			set { _iNumberOfOrders = value; }
		}
		public int MDEntryPositionNo
		{
			get { return _iMDEntryPositionNo; }
			set { _iMDEntryPositionNo = value; }
		}
		public string Scope
		{
			get { return _sScope; }
			set { _sScope = value; }
		}
		public double PriceDelta
		{
			get { return _dPriceDelta; }
			set { _dPriceDelta = value; }
		}
		public double NetChgPrevDay
		{
			get { return _dNetChgPrevDay; }
			set { _dNetChgPrevDay = value; }
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
					case MarketDataIncrementalRefresh.TAG_MDUpdateAction:
						return _cMDUpdateAction;
					case MarketDataIncrementalRefresh.TAG_DeleteReason:
						return _cDeleteReason;
					case MarketDataIncrementalRefresh.TAG_MDEntryType:
						return _cMDEntryType;
					case MarketDataIncrementalRefresh.TAG_MDEntryID:
						return _sMDEntryID;
					case MarketDataIncrementalRefresh.TAG_MDEntryRefID:
						return _sMDEntryRefID;
					case MarketDataIncrementalRefresh.TAG_Symbol:
						return _sSymbol;
					case MarketDataIncrementalRefresh.TAG_SymbolSfx:
						return _sSymbolSfx;
					case MarketDataIncrementalRefresh.TAG_SecurityID:
						return _sSecurityID;
					case MarketDataIncrementalRefresh.TAG_SecurityIDSource:
						return _sSecurityIDSource;
					case MarketDataIncrementalRefresh.TAG_NoSecurityAltID:
						return _iNoSecurityAltID;
					case MarketDataIncrementalRefresh.TAG_Product:
						return _iProduct;
					case MarketDataIncrementalRefresh.TAG_CFICode:
						return _sCFICode;
					case MarketDataIncrementalRefresh.TAG_SecurityType:
						return _sSecurityType;
					case MarketDataIncrementalRefresh.TAG_SecuritySubType:
						return _sSecuritySubType;
					case MarketDataIncrementalRefresh.TAG_MaturityMonthYear:
						return _dtMaturityMonthYear;
					case MarketDataIncrementalRefresh.TAG_MaturityDate:
						return _dtMaturityDate;
					case MarketDataIncrementalRefresh.TAG_CouponPaymentDate:
						return _dtCouponPaymentDate;
					case MarketDataIncrementalRefresh.TAG_IssueDate:
						return _dtIssueDate;
					case MarketDataIncrementalRefresh.TAG_RepoCollateralSecurityType:
						return _iRepoCollateralSecurityType;
					case MarketDataIncrementalRefresh.TAG_RepurchaseTerm:
						return _iRepurchaseTerm;
					case MarketDataIncrementalRefresh.TAG_RepurchaseRate:
						return _dRepurchaseRate;
					case MarketDataIncrementalRefresh.TAG_Factor:
						return _dFactor;
					case MarketDataIncrementalRefresh.TAG_CreditRating:
						return _sCreditRating;
					case MarketDataIncrementalRefresh.TAG_InstrRegistry:
						return _sInstrRegistry;
					case MarketDataIncrementalRefresh.TAG_CountryOfIssue:
						return _sCountryOfIssue;
					case MarketDataIncrementalRefresh.TAG_StateOrProvinceOfIssue:
						return _sStateOrProvinceOfIssue;
					case MarketDataIncrementalRefresh.TAG_LocaleOfIssue:
						return _sLocaleOfIssue;
					case MarketDataIncrementalRefresh.TAG_RedemptionDate:
						return _dtRedemptionDate;
					case MarketDataIncrementalRefresh.TAG_StrikePrice:
						return _dStrikePrice;
					case MarketDataIncrementalRefresh.TAG_StrikeCurrency:
						return _sStrikeCurrency;
					case MarketDataIncrementalRefresh.TAG_OptAttribute:
						return _cOptAttribute;
					case MarketDataIncrementalRefresh.TAG_ContractMultiplier:
						return _dContractMultiplier;
					case MarketDataIncrementalRefresh.TAG_CouponRate:
						return _dCouponRate;
					case MarketDataIncrementalRefresh.TAG_SecurityExchange:
						return _sSecurityExchange;
					case MarketDataIncrementalRefresh.TAG_Issuer:
						return _sIssuer;
					case MarketDataIncrementalRefresh.TAG_EncodedIssuerLen:
						return _iEncodedIssuerLen;
					case MarketDataIncrementalRefresh.TAG_EncodedIssuer:
						return _sEncodedIssuer;
					case MarketDataIncrementalRefresh.TAG_SecurityDesc:
						return _sSecurityDesc;
					case MarketDataIncrementalRefresh.TAG_EncodedSecurityDescLen:
						return _iEncodedSecurityDescLen;
					case MarketDataIncrementalRefresh.TAG_EncodedSecurityDesc:
						return _sEncodedSecurityDesc;
					case MarketDataIncrementalRefresh.TAG_Pool:
						return _sPool;
					case MarketDataIncrementalRefresh.TAG_ContractSettlMonth:
						return _dtContractSettlMonth;
					case MarketDataIncrementalRefresh.TAG_CPProgram:
						return _iCPProgram;
					case MarketDataIncrementalRefresh.TAG_CPRegType:
						return _sCPRegType;
					case MarketDataIncrementalRefresh.TAG_NoEvents:
						return _iNoEvents;
					case MarketDataIncrementalRefresh.TAG_DatedDate:
						return _dtDatedDate;
					case MarketDataIncrementalRefresh.TAG_InterestAccrualDate:
						return _dtInterestAccrualDate;
					case MarketDataIncrementalRefresh.TAG_NoUnderlyings:
						return _iNoUnderlyings;
					case MarketDataIncrementalRefresh.TAG_NoLegs:
						return _iNoLegs;
					case MarketDataIncrementalRefresh.TAG_FinancialStatus:
						return _sFinancialStatus;
					case MarketDataIncrementalRefresh.TAG_CorporateAction:
						return _sCorporateAction;
					case MarketDataIncrementalRefresh.TAG_MDEntryPx:
						return _dMDEntryPx;
					case MarketDataIncrementalRefresh.TAG_Currency:
						return _sCurrency;
					case MarketDataIncrementalRefresh.TAG_MDEntrySize:
						return _iMDEntrySize;
					case MarketDataIncrementalRefresh.TAG_MDEntryDate:
						return _dtMDEntryDate;
					case MarketDataIncrementalRefresh.TAG_MDEntryTime:
						return _dtMDEntryTime;
					case MarketDataIncrementalRefresh.TAG_TickDirection:
						return _cTickDirection;
					case MarketDataIncrementalRefresh.TAG_MDMkt:
						return _sMDMkt;
					case MarketDataIncrementalRefresh.TAG_TradingSessionID:
						return _sTradingSessionID;
					case MarketDataIncrementalRefresh.TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case MarketDataIncrementalRefresh.TAG_QuoteCondition:
						return _sQuoteCondition;
					case MarketDataIncrementalRefresh.TAG_TradeCondition:
						return _sTradeCondition;
					case MarketDataIncrementalRefresh.TAG_MDEntryOriginator:
						return _sMDEntryOriginator;
					case MarketDataIncrementalRefresh.TAG_LocationID:
						return _sLocationID;
					case MarketDataIncrementalRefresh.TAG_DeskID:
						return _sDeskID;
					case MarketDataIncrementalRefresh.TAG_OpenCloseSettlFlag:
						return _sOpenCloseSettlFlag;
					case MarketDataIncrementalRefresh.TAG_TimeInForce:
						return _cTimeInForce;
					case MarketDataIncrementalRefresh.TAG_ExpireDate:
						return _dtExpireDate;
					case MarketDataIncrementalRefresh.TAG_ExpireTime:
						return _dtExpireTime;
					case MarketDataIncrementalRefresh.TAG_MinQty:
						return _iMinQty;
					case MarketDataIncrementalRefresh.TAG_ExecInst:
						return _sExecInst;
					case MarketDataIncrementalRefresh.TAG_SellerDays:
						return _iSellerDays;
					case MarketDataIncrementalRefresh.TAG_OrderID:
						return _sOrderID;
					case MarketDataIncrementalRefresh.TAG_QuoteEntryID:
						return _sQuoteEntryID;
					case MarketDataIncrementalRefresh.TAG_MDEntryBuyer:
						return _sMDEntryBuyer;
					case MarketDataIncrementalRefresh.TAG_MDEntrySeller:
						return _sMDEntrySeller;
					case MarketDataIncrementalRefresh.TAG_NumberOfOrders:
						return _iNumberOfOrders;
					case MarketDataIncrementalRefresh.TAG_MDEntryPositionNo:
						return _iMDEntryPositionNo;
					case MarketDataIncrementalRefresh.TAG_Scope:
						return _sScope;
					case MarketDataIncrementalRefresh.TAG_PriceDelta:
						return _dPriceDelta;
					case MarketDataIncrementalRefresh.TAG_NetChgPrevDay:
						return _dNetChgPrevDay;
					case MarketDataIncrementalRefresh.TAG_Text:
						return _sText;
					case MarketDataIncrementalRefresh.TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case MarketDataIncrementalRefresh.TAG_EncodedText:
						return _sEncodedText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_MDUpdateAction:
						_cMDUpdateAction = (char)value;
						break;
					case MarketDataIncrementalRefresh.TAG_DeleteReason:
						_cDeleteReason = (char)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntryType:
						_cMDEntryType = (char)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntryID:
						_sMDEntryID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntryRefID:
						_sMDEntryRefID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_Symbol:
						_sSymbol = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_SymbolSfx:
						_sSymbolSfx = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_SecurityID:
						_sSecurityID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_SecurityIDSource:
						_sSecurityIDSource = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_NoSecurityAltID:
						_iNoSecurityAltID = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_Product:
						_iProduct = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_CFICode:
						_sCFICode = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_SecuritySubType:
						_sSecuritySubType = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MaturityMonthYear:
						_dtMaturityMonthYear = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MaturityDate:
						_dtMaturityDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_CouponPaymentDate:
						_dtCouponPaymentDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_IssueDate:
						_dtIssueDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_RepoCollateralSecurityType:
						_iRepoCollateralSecurityType = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_RepurchaseTerm:
						_iRepurchaseTerm = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_RepurchaseRate:
						_dRepurchaseRate = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_Factor:
						_dFactor = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_CreditRating:
						_sCreditRating = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_InstrRegistry:
						_sInstrRegistry = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_CountryOfIssue:
						_sCountryOfIssue = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_StateOrProvinceOfIssue:
						_sStateOrProvinceOfIssue = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LocaleOfIssue:
						_sLocaleOfIssue = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_RedemptionDate:
						_dtRedemptionDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_StrikePrice:
						_dStrikePrice = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_StrikeCurrency:
						_sStrikeCurrency = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_OptAttribute:
						_cOptAttribute = (char)value;
						break;
					case MarketDataIncrementalRefresh.TAG_ContractMultiplier:
						_dContractMultiplier = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_CouponRate:
						_dCouponRate = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_SecurityExchange:
						_sSecurityExchange = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_Issuer:
						_sIssuer = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedIssuerLen:
						_iEncodedIssuerLen = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedIssuer:
						_sEncodedIssuer = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_SecurityDesc:
						_sSecurityDesc = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedSecurityDescLen:
						_iEncodedSecurityDescLen = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedSecurityDesc:
						_sEncodedSecurityDesc = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_Pool:
						_sPool = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_ContractSettlMonth:
						_dtContractSettlMonth = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_CPProgram:
						_iCPProgram = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_CPRegType:
						_sCPRegType = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_NoEvents:
						_iNoEvents = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_DatedDate:
						_dtDatedDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_InterestAccrualDate:
						_dtInterestAccrualDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_NoUnderlyings:
						_iNoUnderlyings = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_FinancialStatus:
						_sFinancialStatus = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_CorporateAction:
						_sCorporateAction = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntryPx:
						_dMDEntryPx = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_Currency:
						_sCurrency = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntrySize:
						_iMDEntrySize = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntryDate:
						_dtMDEntryDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntryTime:
						_dtMDEntryTime = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_TickDirection:
						_cTickDirection = (char)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDMkt:
						_sMDMkt = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_QuoteCondition:
						_sQuoteCondition = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_TradeCondition:
						_sTradeCondition = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntryOriginator:
						_sMDEntryOriginator = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LocationID:
						_sLocationID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_DeskID:
						_sDeskID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_OpenCloseSettlFlag:
						_sOpenCloseSettlFlag = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_TimeInForce:
						_cTimeInForce = (char)value;
						break;
					case MarketDataIncrementalRefresh.TAG_ExpireDate:
						_dtExpireDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_ExpireTime:
						_dtExpireTime = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MinQty:
						_iMinQty = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_ExecInst:
						_sExecInst = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_SellerDays:
						_iSellerDays = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_OrderID:
						_sOrderID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_QuoteEntryID:
						_sQuoteEntryID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntryBuyer:
						_sMDEntryBuyer = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntrySeller:
						_sMDEntrySeller = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_NumberOfOrders:
						_iNumberOfOrders = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_MDEntryPositionNo:
						_iMDEntryPositionNo = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_Scope:
						_sScope = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_PriceDelta:
						_dPriceDelta = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_NetChgPrevDay:
						_dNetChgPrevDay = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_Text:
						_sText = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedTextLen:
						_iEncodedTextLen = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedText:
						_sEncodedText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MarketDataIncrementalRefreshMDEntrieList
	{
		private ArrayList _al;
		private MarketDataIncrementalRefreshMDEntrie _last;

		public MarketDataIncrementalRefreshMDEntrie this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MarketDataIncrementalRefreshMDEntrie)_al[i];
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

		public void Add(MarketDataIncrementalRefreshMDEntrie item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MarketDataIncrementalRefreshMDEntrie item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MarketDataIncrementalRefreshMDEntrie Last
		{
			get { return _last; }
		}
	}

	public class MarketDataIncrementalRefreshSecurityAltID
	{
		private string _sSecurityAltID;
		private string _sSecurityAltIDSource;

		public string SecurityAltID
		{
			get { return _sSecurityAltID; }
			set { _sSecurityAltID = value; }
		}
		public string SecurityAltIDSource
		{
			get { return _sSecurityAltIDSource; }
			set { _sSecurityAltIDSource = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_SecurityAltID:
						return _sSecurityAltID;
					case MarketDataIncrementalRefresh.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MarketDataIncrementalRefreshSecurityAltIDList
	{
		private ArrayList _al;
		private MarketDataIncrementalRefreshSecurityAltID _last;

		public MarketDataIncrementalRefreshSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MarketDataIncrementalRefreshSecurityAltID)_al[i];
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

		public void Add(MarketDataIncrementalRefreshSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MarketDataIncrementalRefreshSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MarketDataIncrementalRefreshSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class MarketDataIncrementalRefreshEvent
	{
		private int _iEventType;
		private DateTime _dtEventDate;
		private double _dEventPx;
		private string _sEventText;

		public int EventType
		{
			get { return _iEventType; }
			set { _iEventType = value; }
		}
		public DateTime EventDate
		{
			get { return _dtEventDate; }
			set { _dtEventDate = value; }
		}
		public double EventPx
		{
			get { return _dEventPx; }
			set { _dEventPx = value; }
		}
		public string EventText
		{
			get { return _sEventText; }
			set { _sEventText = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_EventType:
						return _iEventType;
					case MarketDataIncrementalRefresh.TAG_EventDate:
						return _dtEventDate;
					case MarketDataIncrementalRefresh.TAG_EventPx:
						return _dEventPx;
					case MarketDataIncrementalRefresh.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_EventType:
						_iEventType = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MarketDataIncrementalRefreshEventList
	{
		private ArrayList _al;
		private MarketDataIncrementalRefreshEvent _last;

		public MarketDataIncrementalRefreshEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MarketDataIncrementalRefreshEvent)_al[i];
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

		public void Add(MarketDataIncrementalRefreshEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MarketDataIncrementalRefreshEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MarketDataIncrementalRefreshEvent Last
		{
			get { return _last; }
		}
	}

	public class MarketDataIncrementalRefreshUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private MarketDataIncrementalRefreshUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new MarketDataIncrementalRefreshUnderlyingSecurityAltIDList();
		private int _iUnderlyingProduct;
		private string _sUnderlyingCFICode;
		private string _sUnderlyingSecurityType;
		private string _sUnderlyingSecuritySubType;
		private DateTime _dtUnderlyingMaturityMonthYear;
		private DateTime _dtUnderlyingMaturityDate;
		private DateTime _dtUnderlyingCouponPaymentDate;
		private DateTime _dtUnderlyingIssueDate;
		private int _iUnderlyingRepoCollateralSecurityType;
		private int _iUnderlyingRepurchaseTerm;
		private double _dUnderlyingRepurchaseRate;
		private double _dUnderlyingFactor;
		private string _sUnderlyingCreditRating;
		private string _sUnderlyingInstrRegistry;
		private string _sUnderlyingCountryOfIssue;
		private string _sUnderlyingStateOrProvinceOfIssue;
		private string _sUnderlyingLocaleOfIssue;
		private DateTime _dtUnderlyingRedemptionDate;
		private double _dUnderlyingStrikePrice;
		private string _sUnderlyingStrikeCurrency;
		private char _cUnderlyingOptAttribute;
		private double _dUnderlyingContractMultiplier;
		private double _dUnderlyingCouponRate;
		private string _sUnderlyingSecurityExchange;
		private string _sUnderlyingIssuer;
		private int _iEncodedUnderlyingIssuerLen;
		private string _sEncodedUnderlyingIssuer;
		private string _sUnderlyingSecurityDesc;
		private int _iEncodedUnderlyingSecurityDescLen;
		private string _sEncodedUnderlyingSecurityDesc;
		private string _sUnderlyingCPProgram;
		private string _sUnderlyingCPRegType;
		private string _sUnderlyingCurrency;
		private int _iUnderlyingQty;
		private double _dUnderlyingPx;
		private double _dUnderlyingDirtyPrice;
		private double _dUnderlyingEndPrice;
		private double _dUnderlyingStartValue;
		private double _dUnderlyingCurrentValue;
		private double _dUnderlyingEndValue;

		public string UnderlyingSymbol
		{
			get { return _sUnderlyingSymbol; }
			set { _sUnderlyingSymbol = value; }
		}
		public string UnderlyingSymbolSfx
		{
			get { return _sUnderlyingSymbolSfx; }
			set { _sUnderlyingSymbolSfx = value; }
		}
		public string UnderlyingSecurityID
		{
			get { return _sUnderlyingSecurityID; }
			set { _sUnderlyingSecurityID = value; }
		}
		public string UnderlyingSecurityIDSource
		{
			get { return _sUnderlyingSecurityIDSource; }
			set { _sUnderlyingSecurityIDSource = value; }
		}
		public int NoUnderlyingSecurityAltID
		{
			get { return _iNoUnderlyingSecurityAltID; }
			set { _iNoUnderlyingSecurityAltID = value; }
		}
		public MarketDataIncrementalRefreshUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
		{
			get { return _listUnderlyingSecurityAltID; }
		}
		public int UnderlyingProduct
		{
			get { return _iUnderlyingProduct; }
			set { _iUnderlyingProduct = value; }
		}
		public string UnderlyingCFICode
		{
			get { return _sUnderlyingCFICode; }
			set { _sUnderlyingCFICode = value; }
		}
		public string UnderlyingSecurityType
		{
			get { return _sUnderlyingSecurityType; }
			set { _sUnderlyingSecurityType = value; }
		}
		public string UnderlyingSecuritySubType
		{
			get { return _sUnderlyingSecuritySubType; }
			set { _sUnderlyingSecuritySubType = value; }
		}
		public DateTime UnderlyingMaturityMonthYear
		{
			get { return _dtUnderlyingMaturityMonthYear; }
			set { _dtUnderlyingMaturityMonthYear = value; }
		}
		public DateTime UnderlyingMaturityDate
		{
			get { return _dtUnderlyingMaturityDate; }
			set { _dtUnderlyingMaturityDate = value; }
		}
		public DateTime UnderlyingCouponPaymentDate
		{
			get { return _dtUnderlyingCouponPaymentDate; }
			set { _dtUnderlyingCouponPaymentDate = value; }
		}
		public DateTime UnderlyingIssueDate
		{
			get { return _dtUnderlyingIssueDate; }
			set { _dtUnderlyingIssueDate = value; }
		}
		public int UnderlyingRepoCollateralSecurityType
		{
			get { return _iUnderlyingRepoCollateralSecurityType; }
			set { _iUnderlyingRepoCollateralSecurityType = value; }
		}
		public int UnderlyingRepurchaseTerm
		{
			get { return _iUnderlyingRepurchaseTerm; }
			set { _iUnderlyingRepurchaseTerm = value; }
		}
		public double UnderlyingRepurchaseRate
		{
			get { return _dUnderlyingRepurchaseRate; }
			set { _dUnderlyingRepurchaseRate = value; }
		}
		public double UnderlyingFactor
		{
			get { return _dUnderlyingFactor; }
			set { _dUnderlyingFactor = value; }
		}
		public string UnderlyingCreditRating
		{
			get { return _sUnderlyingCreditRating; }
			set { _sUnderlyingCreditRating = value; }
		}
		public string UnderlyingInstrRegistry
		{
			get { return _sUnderlyingInstrRegistry; }
			set { _sUnderlyingInstrRegistry = value; }
		}
		public string UnderlyingCountryOfIssue
		{
			get { return _sUnderlyingCountryOfIssue; }
			set { _sUnderlyingCountryOfIssue = value; }
		}
		public string UnderlyingStateOrProvinceOfIssue
		{
			get { return _sUnderlyingStateOrProvinceOfIssue; }
			set { _sUnderlyingStateOrProvinceOfIssue = value; }
		}
		public string UnderlyingLocaleOfIssue
		{
			get { return _sUnderlyingLocaleOfIssue; }
			set { _sUnderlyingLocaleOfIssue = value; }
		}
		public DateTime UnderlyingRedemptionDate
		{
			get { return _dtUnderlyingRedemptionDate; }
			set { _dtUnderlyingRedemptionDate = value; }
		}
		public double UnderlyingStrikePrice
		{
			get { return _dUnderlyingStrikePrice; }
			set { _dUnderlyingStrikePrice = value; }
		}
		public string UnderlyingStrikeCurrency
		{
			get { return _sUnderlyingStrikeCurrency; }
			set { _sUnderlyingStrikeCurrency = value; }
		}
		public char UnderlyingOptAttribute
		{
			get { return _cUnderlyingOptAttribute; }
			set { _cUnderlyingOptAttribute = value; }
		}
		public double UnderlyingContractMultiplier
		{
			get { return _dUnderlyingContractMultiplier; }
			set { _dUnderlyingContractMultiplier = value; }
		}
		public double UnderlyingCouponRate
		{
			get { return _dUnderlyingCouponRate; }
			set { _dUnderlyingCouponRate = value; }
		}
		public string UnderlyingSecurityExchange
		{
			get { return _sUnderlyingSecurityExchange; }
			set { _sUnderlyingSecurityExchange = value; }
		}
		public string UnderlyingIssuer
		{
			get { return _sUnderlyingIssuer; }
			set { _sUnderlyingIssuer = value; }
		}
		public int EncodedUnderlyingIssuerLen
		{
			get { return _iEncodedUnderlyingIssuerLen; }
			set { _iEncodedUnderlyingIssuerLen = value; }
		}
		public string EncodedUnderlyingIssuer
		{
			get { return _sEncodedUnderlyingIssuer; }
			set { _sEncodedUnderlyingIssuer = value; }
		}
		public string UnderlyingSecurityDesc
		{
			get { return _sUnderlyingSecurityDesc; }
			set { _sUnderlyingSecurityDesc = value; }
		}
		public int EncodedUnderlyingSecurityDescLen
		{
			get { return _iEncodedUnderlyingSecurityDescLen; }
			set { _iEncodedUnderlyingSecurityDescLen = value; }
		}
		public string EncodedUnderlyingSecurityDesc
		{
			get { return _sEncodedUnderlyingSecurityDesc; }
			set { _sEncodedUnderlyingSecurityDesc = value; }
		}
		public string UnderlyingCPProgram
		{
			get { return _sUnderlyingCPProgram; }
			set { _sUnderlyingCPProgram = value; }
		}
		public string UnderlyingCPRegType
		{
			get { return _sUnderlyingCPRegType; }
			set { _sUnderlyingCPRegType = value; }
		}
		public string UnderlyingCurrency
		{
			get { return _sUnderlyingCurrency; }
			set { _sUnderlyingCurrency = value; }
		}
		public int UnderlyingQty
		{
			get { return _iUnderlyingQty; }
			set { _iUnderlyingQty = value; }
		}
		public double UnderlyingPx
		{
			get { return _dUnderlyingPx; }
			set { _dUnderlyingPx = value; }
		}
		public double UnderlyingDirtyPrice
		{
			get { return _dUnderlyingDirtyPrice; }
			set { _dUnderlyingDirtyPrice = value; }
		}
		public double UnderlyingEndPrice
		{
			get { return _dUnderlyingEndPrice; }
			set { _dUnderlyingEndPrice = value; }
		}
		public double UnderlyingStartValue
		{
			get { return _dUnderlyingStartValue; }
			set { _dUnderlyingStartValue = value; }
		}
		public double UnderlyingCurrentValue
		{
			get { return _dUnderlyingCurrentValue; }
			set { _dUnderlyingCurrentValue = value; }
		}
		public double UnderlyingEndValue
		{
			get { return _dUnderlyingEndValue; }
			set { _dUnderlyingEndValue = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case MarketDataIncrementalRefresh.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case MarketDataIncrementalRefresh.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case MarketDataIncrementalRefresh.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case MarketDataIncrementalRefresh.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case MarketDataIncrementalRefresh.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case MarketDataIncrementalRefresh.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case MarketDataIncrementalRefresh.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case MarketDataIncrementalRefresh.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case MarketDataIncrementalRefresh.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case MarketDataIncrementalRefresh.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case MarketDataIncrementalRefresh.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case MarketDataIncrementalRefresh.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case MarketDataIncrementalRefresh.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case MarketDataIncrementalRefresh.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case MarketDataIncrementalRefresh.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case MarketDataIncrementalRefresh.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case MarketDataIncrementalRefresh.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case MarketDataIncrementalRefresh.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case MarketDataIncrementalRefresh.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case MarketDataIncrementalRefresh.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case MarketDataIncrementalRefresh.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case MarketDataIncrementalRefresh.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case MarketDataIncrementalRefresh.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case MarketDataIncrementalRefresh.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case MarketDataIncrementalRefresh.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case MarketDataIncrementalRefresh.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case MarketDataIncrementalRefresh.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case MarketDataIncrementalRefresh.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MarketDataIncrementalRefreshUnderlyingList
	{
		private ArrayList _al;
		private MarketDataIncrementalRefreshUnderlying _last;

		public MarketDataIncrementalRefreshUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MarketDataIncrementalRefreshUnderlying)_al[i];
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

		public void Add(MarketDataIncrementalRefreshUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MarketDataIncrementalRefreshUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MarketDataIncrementalRefreshUnderlying Last
		{
			get { return _last; }
		}
	}

	public class MarketDataIncrementalRefreshUnderlyingSecurityAltID
	{
		private string _sUnderlyingSecurityAltID;
		private string _sUnderlyingSecurityAltIDSource;

		public string UnderlyingSecurityAltID
		{
			get { return _sUnderlyingSecurityAltID; }
			set { _sUnderlyingSecurityAltID = value; }
		}
		public string UnderlyingSecurityAltIDSource
		{
			get { return _sUnderlyingSecurityAltIDSource; }
			set { _sUnderlyingSecurityAltIDSource = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MarketDataIncrementalRefreshUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private MarketDataIncrementalRefreshUnderlyingSecurityAltID _last;

		public MarketDataIncrementalRefreshUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MarketDataIncrementalRefreshUnderlyingSecurityAltID)_al[i];
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

		public void Add(MarketDataIncrementalRefreshUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MarketDataIncrementalRefreshUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MarketDataIncrementalRefreshUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class MarketDataIncrementalRefreshLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private MarketDataIncrementalRefreshLegSecurityAltIDList _listLegSecurityAltID = new MarketDataIncrementalRefreshLegSecurityAltIDList();
		private int _iLegProduct;
		private string _sLegCFICode;
		private string _sLegSecurityType;
		private string _sLegSecuritySubType;
		private DateTime _dtLegMaturityMonthYear;
		private DateTime _dtLegMaturityDate;
		private DateTime _dtLegCouponPaymentDate;
		private DateTime _dtLegIssueDate;
		private int _iLegRepoCollateralSecurityType;
		private int _iLegRepurchaseTerm;
		private double _dLegRepurchaseRate;
		private double _dLegFactor;
		private string _sLegCreditRating;
		private string _sLegInstrRegistry;
		private string _sLegCountryOfIssue;
		private string _sLegStateOrProvinceOfIssue;
		private string _sLegLocaleOfIssue;
		private DateTime _dtLegRedemptionDate;
		private double _dLegStrikePrice;
		private string _sLegStrikeCurrency;
		private char _cLegOptAttribute;
		private double _dLegContractMultiplier;
		private double _dLegCouponRate;
		private string _sLegSecurityExchange;
		private string _sLegIssuer;
		private int _iEncodedLegIssuerLen;
		private string _sEncodedLegIssuer;
		private string _sLegSecurityDesc;
		private int _iEncodedLegSecurityDescLen;
		private string _sEncodedLegSecurityDesc;
		private double _dLegRatioQty;
		private char _cLegSide;
		private string _sLegCurrency;
		private string _sLegPool;
		private DateTime _dtLegDatedDate;
		private DateTime _dtLegContractSettlMonth;
		private DateTime _dtLegInterestAccrualDate;

		public string LegSymbol
		{
			get { return _sLegSymbol; }
			set { _sLegSymbol = value; }
		}
		public string LegSymbolSfx
		{
			get { return _sLegSymbolSfx; }
			set { _sLegSymbolSfx = value; }
		}
		public string LegSecurityID
		{
			get { return _sLegSecurityID; }
			set { _sLegSecurityID = value; }
		}
		public string LegSecurityIDSource
		{
			get { return _sLegSecurityIDSource; }
			set { _sLegSecurityIDSource = value; }
		}
		public int NoLegSecurityAltID
		{
			get { return _iNoLegSecurityAltID; }
			set { _iNoLegSecurityAltID = value; }
		}
		public MarketDataIncrementalRefreshLegSecurityAltIDList LegSecurityAltID 
		{
			get { return _listLegSecurityAltID; }
		}
		public int LegProduct
		{
			get { return _iLegProduct; }
			set { _iLegProduct = value; }
		}
		public string LegCFICode
		{
			get { return _sLegCFICode; }
			set { _sLegCFICode = value; }
		}
		public string LegSecurityType
		{
			get { return _sLegSecurityType; }
			set { _sLegSecurityType = value; }
		}
		public string LegSecuritySubType
		{
			get { return _sLegSecuritySubType; }
			set { _sLegSecuritySubType = value; }
		}
		public DateTime LegMaturityMonthYear
		{
			get { return _dtLegMaturityMonthYear; }
			set { _dtLegMaturityMonthYear = value; }
		}
		public DateTime LegMaturityDate
		{
			get { return _dtLegMaturityDate; }
			set { _dtLegMaturityDate = value; }
		}
		public DateTime LegCouponPaymentDate
		{
			get { return _dtLegCouponPaymentDate; }
			set { _dtLegCouponPaymentDate = value; }
		}
		public DateTime LegIssueDate
		{
			get { return _dtLegIssueDate; }
			set { _dtLegIssueDate = value; }
		}
		public int LegRepoCollateralSecurityType
		{
			get { return _iLegRepoCollateralSecurityType; }
			set { _iLegRepoCollateralSecurityType = value; }
		}
		public int LegRepurchaseTerm
		{
			get { return _iLegRepurchaseTerm; }
			set { _iLegRepurchaseTerm = value; }
		}
		public double LegRepurchaseRate
		{
			get { return _dLegRepurchaseRate; }
			set { _dLegRepurchaseRate = value; }
		}
		public double LegFactor
		{
			get { return _dLegFactor; }
			set { _dLegFactor = value; }
		}
		public string LegCreditRating
		{
			get { return _sLegCreditRating; }
			set { _sLegCreditRating = value; }
		}
		public string LegInstrRegistry
		{
			get { return _sLegInstrRegistry; }
			set { _sLegInstrRegistry = value; }
		}
		public string LegCountryOfIssue
		{
			get { return _sLegCountryOfIssue; }
			set { _sLegCountryOfIssue = value; }
		}
		public string LegStateOrProvinceOfIssue
		{
			get { return _sLegStateOrProvinceOfIssue; }
			set { _sLegStateOrProvinceOfIssue = value; }
		}
		public string LegLocaleOfIssue
		{
			get { return _sLegLocaleOfIssue; }
			set { _sLegLocaleOfIssue = value; }
		}
		public DateTime LegRedemptionDate
		{
			get { return _dtLegRedemptionDate; }
			set { _dtLegRedemptionDate = value; }
		}
		public double LegStrikePrice
		{
			get { return _dLegStrikePrice; }
			set { _dLegStrikePrice = value; }
		}
		public string LegStrikeCurrency
		{
			get { return _sLegStrikeCurrency; }
			set { _sLegStrikeCurrency = value; }
		}
		public char LegOptAttribute
		{
			get { return _cLegOptAttribute; }
			set { _cLegOptAttribute = value; }
		}
		public double LegContractMultiplier
		{
			get { return _dLegContractMultiplier; }
			set { _dLegContractMultiplier = value; }
		}
		public double LegCouponRate
		{
			get { return _dLegCouponRate; }
			set { _dLegCouponRate = value; }
		}
		public string LegSecurityExchange
		{
			get { return _sLegSecurityExchange; }
			set { _sLegSecurityExchange = value; }
		}
		public string LegIssuer
		{
			get { return _sLegIssuer; }
			set { _sLegIssuer = value; }
		}
		public int EncodedLegIssuerLen
		{
			get { return _iEncodedLegIssuerLen; }
			set { _iEncodedLegIssuerLen = value; }
		}
		public string EncodedLegIssuer
		{
			get { return _sEncodedLegIssuer; }
			set { _sEncodedLegIssuer = value; }
		}
		public string LegSecurityDesc
		{
			get { return _sLegSecurityDesc; }
			set { _sLegSecurityDesc = value; }
		}
		public int EncodedLegSecurityDescLen
		{
			get { return _iEncodedLegSecurityDescLen; }
			set { _iEncodedLegSecurityDescLen = value; }
		}
		public string EncodedLegSecurityDesc
		{
			get { return _sEncodedLegSecurityDesc; }
			set { _sEncodedLegSecurityDesc = value; }
		}
		public double LegRatioQty
		{
			get { return _dLegRatioQty; }
			set { _dLegRatioQty = value; }
		}
		public char LegSide
		{
			get { return _cLegSide; }
			set { _cLegSide = value; }
		}
		public string LegCurrency
		{
			get { return _sLegCurrency; }
			set { _sLegCurrency = value; }
		}
		public string LegPool
		{
			get { return _sLegPool; }
			set { _sLegPool = value; }
		}
		public DateTime LegDatedDate
		{
			get { return _dtLegDatedDate; }
			set { _dtLegDatedDate = value; }
		}
		public DateTime LegContractSettlMonth
		{
			get { return _dtLegContractSettlMonth; }
			set { _dtLegContractSettlMonth = value; }
		}
		public DateTime LegInterestAccrualDate
		{
			get { return _dtLegInterestAccrualDate; }
			set { _dtLegInterestAccrualDate = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_LegSymbol:
						return _sLegSymbol;
					case MarketDataIncrementalRefresh.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case MarketDataIncrementalRefresh.TAG_LegSecurityID:
						return _sLegSecurityID;
					case MarketDataIncrementalRefresh.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case MarketDataIncrementalRefresh.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case MarketDataIncrementalRefresh.TAG_LegProduct:
						return _iLegProduct;
					case MarketDataIncrementalRefresh.TAG_LegCFICode:
						return _sLegCFICode;
					case MarketDataIncrementalRefresh.TAG_LegSecurityType:
						return _sLegSecurityType;
					case MarketDataIncrementalRefresh.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case MarketDataIncrementalRefresh.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case MarketDataIncrementalRefresh.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case MarketDataIncrementalRefresh.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case MarketDataIncrementalRefresh.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case MarketDataIncrementalRefresh.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case MarketDataIncrementalRefresh.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case MarketDataIncrementalRefresh.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case MarketDataIncrementalRefresh.TAG_LegFactor:
						return _dLegFactor;
					case MarketDataIncrementalRefresh.TAG_LegCreditRating:
						return _sLegCreditRating;
					case MarketDataIncrementalRefresh.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case MarketDataIncrementalRefresh.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case MarketDataIncrementalRefresh.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case MarketDataIncrementalRefresh.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case MarketDataIncrementalRefresh.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case MarketDataIncrementalRefresh.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case MarketDataIncrementalRefresh.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case MarketDataIncrementalRefresh.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case MarketDataIncrementalRefresh.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case MarketDataIncrementalRefresh.TAG_LegCouponRate:
						return _dLegCouponRate;
					case MarketDataIncrementalRefresh.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case MarketDataIncrementalRefresh.TAG_LegIssuer:
						return _sLegIssuer;
					case MarketDataIncrementalRefresh.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case MarketDataIncrementalRefresh.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case MarketDataIncrementalRefresh.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case MarketDataIncrementalRefresh.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case MarketDataIncrementalRefresh.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case MarketDataIncrementalRefresh.TAG_LegRatioQty:
						return _dLegRatioQty;
					case MarketDataIncrementalRefresh.TAG_LegSide:
						return _cLegSide;
					case MarketDataIncrementalRefresh.TAG_LegCurrency:
						return _sLegCurrency;
					case MarketDataIncrementalRefresh.TAG_LegPool:
						return _sLegPool;
					case MarketDataIncrementalRefresh.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case MarketDataIncrementalRefresh.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case MarketDataIncrementalRefresh.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case MarketDataIncrementalRefresh.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MarketDataIncrementalRefreshLegList
	{
		private ArrayList _al;
		private MarketDataIncrementalRefreshLeg _last;

		public MarketDataIncrementalRefreshLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MarketDataIncrementalRefreshLeg)_al[i];
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

		public void Add(MarketDataIncrementalRefreshLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MarketDataIncrementalRefreshLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MarketDataIncrementalRefreshLeg Last
		{
			get { return _last; }
		}
	}

	public class MarketDataIncrementalRefreshLegSecurityAltID
	{
		private string _sLegSecurityAltID;
		private string _sLegSecurityAltIDSource;

		public string LegSecurityAltID
		{
			get { return _sLegSecurityAltID; }
			set { _sLegSecurityAltID = value; }
		}
		public string LegSecurityAltIDSource
		{
			get { return _sLegSecurityAltIDSource; }
			set { _sLegSecurityAltIDSource = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case MarketDataIncrementalRefresh.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MarketDataIncrementalRefresh.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case MarketDataIncrementalRefresh.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MarketDataIncrementalRefreshLegSecurityAltIDList
	{
		private ArrayList _al;
		private MarketDataIncrementalRefreshLegSecurityAltID _last;

		public MarketDataIncrementalRefreshLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MarketDataIncrementalRefreshLegSecurityAltID)_al[i];
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

		public void Add(MarketDataIncrementalRefreshLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MarketDataIncrementalRefreshLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MarketDataIncrementalRefreshLegSecurityAltID Last
		{
			get { return _last; }
		}
	}
}
