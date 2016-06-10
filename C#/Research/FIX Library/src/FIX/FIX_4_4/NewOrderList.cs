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
	/// Summary description for NewOrderList.
	/// </summary>
	public class NewOrderList : Message
	{
		public const int TAG_ListID = 66;
		public const int TAG_BidID = 390;
		public const int TAG_ClientBidID = 391;
		public const int TAG_ProgRptReqs = 414;
		public const int TAG_BidType = 394;
		public const int TAG_ProgPeriodInterval = 415;
		public const int TAG_CancellationRights = 480;
		public const int TAG_MoneyLaunderingStatus = 481;
		public const int TAG_RegistID = 513;
		public const int TAG_ListExecInstType = 433;
		public const int TAG_ListExecInst = 69;
		public const int TAG_EncodedListExecInstLen = 352;
		public const int TAG_EncodedListExecInst = 353;
		public const int TAG_AllowableOneSidednessPct = 765;
		public const int TAG_AllowableOneSidednessValue = 766;
		public const int TAG_AllowableOneSidednessCurr = 767;
		public const int TAG_TotNoOrders = 68;
		public const int TAG_LastFragment = 893;
		public const int TAG_NoOrders = 73;
		public const int TAG_ClOrdID = 11;
		public const int TAG_SecondaryClOrdID = 526;
		public const int TAG_ListSeqNo = 67;
		public const int TAG_ClOrdLinkID = 583;
		public const int TAG_SettlInstMode = 160;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_TradeOriginationDate = 229;
		public const int TAG_TradeDate = 75;
		public const int TAG_Account = 1;
		public const int TAG_AcctIDSource = 660;
		public const int TAG_AccountType = 581;
		public const int TAG_DayBookingInst = 589;
		public const int TAG_BookingUnit = 590;
		public const int TAG_AllocID = 70;
		public const int TAG_PreallocMethod = 591;
		public const int TAG_NoAllocs = 78;
		public const int TAG_AllocAccount = 79;
		public const int TAG_AllocAcctIDSource = 661;
		public const int TAG_AllocSettlCurrency = 736;
		public const int TAG_IndividualAllocID = 467;
		public const int TAG_NoNestedPartyIDs = 539;
		public const int TAG_NestedPartyID = 524;
		public const int TAG_NestedPartyIDSource = 525;
		public const int TAG_NestedPartyRole = 538;
		public const int TAG_NoNestedPartySubIDs = 804;
		public const int TAG_NestedPartySubID = 545;
		public const int TAG_NestedPartySubIDType = 805;
		public const int TAG_AllocQty = 80;
		public const int TAG_SettlType = 63;
		public const int TAG_SettlDate = 64;
		public const int TAG_CashMargin = 544;
		public const int TAG_ClearingFeeIndicator = 635;
		public const int TAG_HandlInst = 21;
		public const int TAG_ExecInst = 18;
		public const int TAG_MinQty = 110;
		public const int TAG_MaxFloor = 111;
		public const int TAG_ExDestination = 100;
		public const int TAG_NoTradingSessions = 386;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_ProcessCode = 81;
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
		public const int TAG_PrevClosePx = 140;
		public const int TAG_Side = 54;
		public const int TAG_SideValueInd = 401;
		public const int TAG_LocateReqd = 114;
		public const int TAG_TransactTime = 60;
		public const int TAG_NoStipulations = 232;
		public const int TAG_StipulationType = 233;
		public const int TAG_StipulationValue = 234;
		public const int TAG_QtyType = 854;
		public const int TAG_OrderQty = 38;
		public const int TAG_CashOrderQty = 152;
		public const int TAG_OrderPercent = 516;
		public const int TAG_RoundingDirection = 468;
		public const int TAG_RoundingModulus = 469;
		public const int TAG_OrdType = 40;
		public const int TAG_PriceType = 423;
		public const int TAG_Price = 44;
		public const int TAG_StopPx = 99;
		public const int TAG_Spread = 218;
		public const int TAG_BenchmarkCurveCurrency = 220;
		public const int TAG_BenchmarkCurveName = 221;
		public const int TAG_BenchmarkCurvePoint = 222;
		public const int TAG_BenchmarkPrice = 662;
		public const int TAG_BenchmarkPriceType = 663;
		public const int TAG_BenchmarkSecurityID = 699;
		public const int TAG_BenchmarkSecurityIDSource = 761;
		public const int TAG_YieldType = 235;
		public const int TAG_Yield = 236;
		public const int TAG_YieldCalcDate = 701;
		public const int TAG_YieldRedemptionDate = 696;
		public const int TAG_YieldRedemptionPrice = 697;
		public const int TAG_YieldRedemptionPriceType = 698;
		public const int TAG_Currency = 15;
		public const int TAG_ComplianceID = 376;
		public const int TAG_SolicitedFlag = 377;
		public const int TAG_IOIid = 23;
		public const int TAG_QuoteID = 117;
		public const int TAG_TimeInForce = 59;
		public const int TAG_EffectiveTime = 168;
		public const int TAG_ExpireDate = 432;
		public const int TAG_ExpireTime = 126;
		public const int TAG_GTBookingInst = 427;
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_CommCurrency = 479;
		public const int TAG_FundRenewWaiv = 497;
		public const int TAG_OrderCapacity = 528;
		public const int TAG_OrderRestrictions = 529;
		public const int TAG_CustOrderCapacity = 582;
		public const int TAG_ForexReq = 121;
		public const int TAG_SettlCurrency = 120;
		public const int TAG_BookingType = 775;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_SettlDate2 = 193;
		public const int TAG_OrderQty2 = 192;
		public const int TAG_Price2 = 640;
		public const int TAG_PositionEffect = 77;
		public const int TAG_CoveredOrUncovered = 203;
		public const int TAG_MaxShow = 210;
		public const int TAG_PegOffsetValue = 211;
		public const int TAG_PegMoveType = 835;
		public const int TAG_PegOffsetType = 836;
		public const int TAG_PegLimitType = 837;
		public const int TAG_PegRoundDirection = 838;
		public const int TAG_PegScope = 840;
		public const int TAG_DiscretionInst = 388;
		public const int TAG_DiscretionOffsetValue = 389;
		public const int TAG_DiscretionMoveType = 841;
		public const int TAG_DiscretionOffsetType = 842;
		public const int TAG_DiscretionLimitType = 843;
		public const int TAG_DiscretionRoundDirection = 844;
		public const int TAG_DiscretionScope = 846;
		public const int TAG_TargetStrategy = 847;
		public const int TAG_TargetStrategyParameters = 848;
		public const int TAG_ParticipationRate = 849;
		public const int TAG_Designation = 494;

		private string _sListID;
		private string _sBidID;
		private string _sClientBidID;
		private int _iProgRptReqs;
		private int _iBidType;
		private int _iProgPeriodInterval;
		private char _cCancellationRights;
		private char _cMoneyLaunderingStatus;
		private string _sRegistID;
		private char _cListExecInstType;
		private string _sListExecInst;
		private int _iEncodedListExecInstLen;
		private string _sEncodedListExecInst;
		private double _dAllowableOneSidednessPct;
		private double _dAllowableOneSidednessValue;
		private string _sAllowableOneSidednessCurr;
		private int _iTotNoOrders;
		private bool _bLastFragment;
		private int _iNoOrders;
		private NewOrderListOrderList _listOrder = new NewOrderListOrderList();

		public NewOrderList() : base()
		{
			_sMsgType = Values.MsgType.NewOrderList;
		}

		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
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
		public int ProgRptReqs
		{
			get { return _iProgRptReqs; }
			set { _iProgRptReqs = value; }
		}
		public int BidType
		{
			get { return _iBidType; }
			set { _iBidType = value; }
		}
		public int ProgPeriodInterval
		{
			get { return _iProgPeriodInterval; }
			set { _iProgPeriodInterval = value; }
		}
		public char CancellationRights
		{
			get { return _cCancellationRights; }
			set { _cCancellationRights = value; }
		}
		public char MoneyLaunderingStatus
		{
			get { return _cMoneyLaunderingStatus; }
			set { _cMoneyLaunderingStatus = value; }
		}
		public string RegistID
		{
			get { return _sRegistID; }
			set { _sRegistID = value; }
		}
		public char ListExecInstType
		{
			get { return _cListExecInstType; }
			set { _cListExecInstType = value; }
		}
		public string ListExecInst
		{
			get { return _sListExecInst; }
			set { _sListExecInst = value; }
		}
		public int EncodedListExecInstLen
		{
			get { return _iEncodedListExecInstLen; }
			set { _iEncodedListExecInstLen = value; }
		}
		public string EncodedListExecInst
		{
			get { return _sEncodedListExecInst; }
			set { _sEncodedListExecInst = value; }
		}
		public double AllowableOneSidednessPct
		{
			get { return _dAllowableOneSidednessPct; }
			set { _dAllowableOneSidednessPct = value; }
		}
		public double AllowableOneSidednessValue
		{
			get { return _dAllowableOneSidednessValue; }
			set { _dAllowableOneSidednessValue = value; }
		}
		public string AllowableOneSidednessCurr
		{
			get { return _sAllowableOneSidednessCurr; }
			set { _sAllowableOneSidednessCurr = value; }
		}
		public int TotNoOrders
		{
			get { return _iTotNoOrders; }
			set { _iTotNoOrders = value; }
		}
		public bool LastFragment
		{
			get { return _bLastFragment; }
			set { _bLastFragment = value; }
		}
		public int NoOrders
		{
			get { return _iNoOrders; }
			set { _iNoOrders = value; }
		}
		public NewOrderListOrderList Order 
		{
			get { return _listOrder; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_ListID:
						return _sListID;
					case TAG_BidID:
						return _sBidID;
					case TAG_ClientBidID:
						return _sClientBidID;
					case TAG_ProgRptReqs:
						return _iProgRptReqs;
					case TAG_BidType:
						return _iBidType;
					case TAG_ProgPeriodInterval:
						return _iProgPeriodInterval;
					case TAG_CancellationRights:
						return _cCancellationRights;
					case TAG_MoneyLaunderingStatus:
						return _cMoneyLaunderingStatus;
					case TAG_RegistID:
						return _sRegistID;
					case TAG_ListExecInstType:
						return _cListExecInstType;
					case TAG_ListExecInst:
						return _sListExecInst;
					case TAG_EncodedListExecInstLen:
						return _iEncodedListExecInstLen;
					case TAG_EncodedListExecInst:
						return _sEncodedListExecInst;
					case TAG_AllowableOneSidednessPct:
						return _dAllowableOneSidednessPct;
					case TAG_AllowableOneSidednessValue:
						return _dAllowableOneSidednessValue;
					case TAG_AllowableOneSidednessCurr:
						return _sAllowableOneSidednessCurr;
					case TAG_TotNoOrders:
						return _iTotNoOrders;
					case TAG_LastFragment:
						return _bLastFragment;
					case TAG_NoOrders:
						return _iNoOrders;
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
					case TAG_BidID:
						_sBidID = (string)value;
						break;
					case TAG_ClientBidID:
						_sClientBidID = (string)value;
						break;
					case TAG_ProgRptReqs:
						_iProgRptReqs = (int)value;
						break;
					case TAG_BidType:
						_iBidType = (int)value;
						break;
					case TAG_ProgPeriodInterval:
						_iProgPeriodInterval = (int)value;
						break;
					case TAG_CancellationRights:
						_cCancellationRights = (char)value;
						break;
					case TAG_MoneyLaunderingStatus:
						_cMoneyLaunderingStatus = (char)value;
						break;
					case TAG_RegistID:
						_sRegistID = (string)value;
						break;
					case TAG_ListExecInstType:
						_cListExecInstType = (char)value;
						break;
					case TAG_ListExecInst:
						_sListExecInst = (string)value;
						break;
					case TAG_EncodedListExecInstLen:
						_iEncodedListExecInstLen = (int)value;
						break;
					case TAG_EncodedListExecInst:
						_sEncodedListExecInst = (string)value;
						break;
					case TAG_AllowableOneSidednessPct:
						_dAllowableOneSidednessPct = (double)value;
						break;
					case TAG_AllowableOneSidednessValue:
						_dAllowableOneSidednessValue = (double)value;
						break;
					case TAG_AllowableOneSidednessCurr:
						_sAllowableOneSidednessCurr = (string)value;
						break;
					case TAG_TotNoOrders:
						_iTotNoOrders = (int)value;
						break;
					case TAG_LastFragment:
						_bLastFragment = (bool)value;
						break;
					case TAG_NoOrders:
						_iNoOrders = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class NewOrderListOrder
	{
		private string _sClOrdID;
		private string _sSecondaryClOrdID;
		private int _iListSeqNo;
		private string _sClOrdLinkID;
		private char _cSettlInstMode;
		private int _iNoPartyIDs;
		private NewOrderListPartyIDList _listPartyID = new NewOrderListPartyIDList();
		private DateTime _dtTradeOriginationDate;
		private DateTime _dtTradeDate;
		private string _sAccount;
		private int _iAcctIDSource;
		private int _iAccountType;
		private char _cDayBookingInst;
		private char _cBookingUnit;
		private string _sAllocID;
		private char _cPreallocMethod;
		private int _iNoAllocs;
		private NewOrderListAllocList _listAlloc = new NewOrderListAllocList();
		private char _cSettlType;
		private DateTime _dtSettlDate;
		private char _cCashMargin;
		private string _sClearingFeeIndicator;
		private char _cHandlInst;
		private string _sExecInst;
		private int _iMinQty;
		private int _iMaxFloor;
		private string _sExDestination;
		private int _iNoTradingSessions;
		private NewOrderListTradingSessionList _listTradingSession = new NewOrderListTradingSessionList();
		private char _cProcessCode;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private NewOrderListSecurityAltIDList _listSecurityAltID = new NewOrderListSecurityAltIDList();
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
		private NewOrderListEventList _listEvent = new NewOrderListEventList();
		private DateTime _dtDatedDate;
		private DateTime _dtInterestAccrualDate;
		private int _iNoUnderlyings;
		private NewOrderListUnderlyingList _listUnderlying = new NewOrderListUnderlyingList();
		private double _dPrevClosePx;
		private char _cSide;
		private int _iSideValueInd;
		private bool _bLocateReqd;
		private DateTime _dtTransactTime;
		private int _iNoStipulations;
		private NewOrderListStipulationList _listStipulation = new NewOrderListStipulationList();
		private int _iQtyType;
		private int _iOrderQty;
		private int _iCashOrderQty;
		private double _dOrderPercent;
		private char _cRoundingDirection;
		private double _dRoundingModulus;
		private char _cOrdType;
		private int _iPriceType;
		private double _dPrice;
		private double _dStopPx;
		private double _dSpread;
		private string _sBenchmarkCurveCurrency;
		private string _sBenchmarkCurveName;
		private string _sBenchmarkCurvePoint;
		private double _dBenchmarkPrice;
		private int _iBenchmarkPriceType;
		private string _sBenchmarkSecurityID;
		private string _sBenchmarkSecurityIDSource;
		private string _sYieldType;
		private double _dYield;
		private DateTime _dtYieldCalcDate;
		private DateTime _dtYieldRedemptionDate;
		private double _dYieldRedemptionPrice;
		private int _iYieldRedemptionPriceType;
		private string _sCurrency;
		private string _sComplianceID;
		private bool _bSolicitedFlag;
		private string _sIOIid;
		private string _sQuoteID;
		private char _cTimeInForce;
		private DateTime _dtEffectiveTime;
		private DateTime _dtExpireDate;
		private DateTime _dtExpireTime;
		private int _iGTBookingInst;
		private double _dCommission;
		private char _cCommType;
		private string _sCommCurrency;
		private char _cFundRenewWaiv;
		private char _cOrderCapacity;
		private string _sOrderRestrictions;
		private int _iCustOrderCapacity;
		private bool _bForexReq;
		private string _sSettlCurrency;
		private int _iBookingType;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private DateTime _dtSettlDate2;
		private int _iOrderQty2;
		private double _dPrice2;
		private char _cPositionEffect;
		private int _iCoveredOrUncovered;
		private int _iMaxShow;
		private double _dPegOffsetValue;
		private int _iPegMoveType;
		private int _iPegOffsetType;
		private int _iPegLimitType;
		private int _iPegRoundDirection;
		private int _iPegScope;
		private char _cDiscretionInst;
		private double _dDiscretionOffsetValue;
		private int _iDiscretionMoveType;
		private int _iDiscretionOffsetType;
		private int _iDiscretionLimitType;
		private int _iDiscretionRoundDirection;
		private int _iDiscretionScope;
		private int _iTargetStrategy;
		private string _sTargetStrategyParameters;
		private double _dParticipationRate;
		private string _sDesignation;

		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public string SecondaryClOrdID
		{
			get { return _sSecondaryClOrdID; }
			set { _sSecondaryClOrdID = value; }
		}
		public int ListSeqNo
		{
			get { return _iListSeqNo; }
			set { _iListSeqNo = value; }
		}
		public string ClOrdLinkID
		{
			get { return _sClOrdLinkID; }
			set { _sClOrdLinkID = value; }
		}
		public char SettlInstMode
		{
			get { return _cSettlInstMode; }
			set { _cSettlInstMode = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public NewOrderListPartyIDList PartyID 
		{
			get { return _listPartyID; }
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
		public char DayBookingInst
		{
			get { return _cDayBookingInst; }
			set { _cDayBookingInst = value; }
		}
		public char BookingUnit
		{
			get { return _cBookingUnit; }
			set { _cBookingUnit = value; }
		}
		public string AllocID
		{
			get { return _sAllocID; }
			set { _sAllocID = value; }
		}
		public char PreallocMethod
		{
			get { return _cPreallocMethod; }
			set { _cPreallocMethod = value; }
		}
		public int NoAllocs
		{
			get { return _iNoAllocs; }
			set { _iNoAllocs = value; }
		}
		public NewOrderListAllocList Alloc 
		{
			get { return _listAlloc; }
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
		public char CashMargin
		{
			get { return _cCashMargin; }
			set { _cCashMargin = value; }
		}
		public string ClearingFeeIndicator
		{
			get { return _sClearingFeeIndicator; }
			set { _sClearingFeeIndicator = value; }
		}
		public char HandlInst
		{
			get { return _cHandlInst; }
			set { _cHandlInst = value; }
		}
		public string ExecInst
		{
			get { return _sExecInst; }
			set { _sExecInst = value; }
		}
		public int MinQty
		{
			get { return _iMinQty; }
			set { _iMinQty = value; }
		}
		public int MaxFloor
		{
			get { return _iMaxFloor; }
			set { _iMaxFloor = value; }
		}
		public string ExDestination
		{
			get { return _sExDestination; }
			set { _sExDestination = value; }
		}
		public int NoTradingSessions
		{
			get { return _iNoTradingSessions; }
			set { _iNoTradingSessions = value; }
		}
		public NewOrderListTradingSessionList TradingSession 
		{
			get { return _listTradingSession; }
		}
		public char ProcessCode
		{
			get { return _cProcessCode; }
			set { _cProcessCode = value; }
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
		public NewOrderListSecurityAltIDList SecurityAltID 
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
		public NewOrderListEventList Event 
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
		public NewOrderListUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
		}
		public double PrevClosePx
		{
			get { return _dPrevClosePx; }
			set { _dPrevClosePx = value; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
		}
		public int SideValueInd
		{
			get { return _iSideValueInd; }
			set { _iSideValueInd = value; }
		}
		public bool LocateReqd
		{
			get { return _bLocateReqd; }
			set { _bLocateReqd = value; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public int NoStipulations
		{
			get { return _iNoStipulations; }
			set { _iNoStipulations = value; }
		}
		public NewOrderListStipulationList Stipulation 
		{
			get { return _listStipulation; }
		}
		public int QtyType
		{
			get { return _iQtyType; }
			set { _iQtyType = value; }
		}
		public int OrderQty
		{
			get { return _iOrderQty; }
			set { _iOrderQty = value; }
		}
		public int CashOrderQty
		{
			get { return _iCashOrderQty; }
			set { _iCashOrderQty = value; }
		}
		public double OrderPercent
		{
			get { return _dOrderPercent; }
			set { _dOrderPercent = value; }
		}
		public char RoundingDirection
		{
			get { return _cRoundingDirection; }
			set { _cRoundingDirection = value; }
		}
		public double RoundingModulus
		{
			get { return _dRoundingModulus; }
			set { _dRoundingModulus = value; }
		}
		public char OrdType
		{
			get { return _cOrdType; }
			set { _cOrdType = value; }
		}
		public int PriceType
		{
			get { return _iPriceType; }
			set { _iPriceType = value; }
		}
		public double Price
		{
			get { return _dPrice; }
			set { _dPrice = value; }
		}
		public double StopPx
		{
			get { return _dStopPx; }
			set { _dStopPx = value; }
		}
		public double Spread
		{
			get { return _dSpread; }
			set { _dSpread = value; }
		}
		public string BenchmarkCurveCurrency
		{
			get { return _sBenchmarkCurveCurrency; }
			set { _sBenchmarkCurveCurrency = value; }
		}
		public string BenchmarkCurveName
		{
			get { return _sBenchmarkCurveName; }
			set { _sBenchmarkCurveName = value; }
		}
		public string BenchmarkCurvePoint
		{
			get { return _sBenchmarkCurvePoint; }
			set { _sBenchmarkCurvePoint = value; }
		}
		public double BenchmarkPrice
		{
			get { return _dBenchmarkPrice; }
			set { _dBenchmarkPrice = value; }
		}
		public int BenchmarkPriceType
		{
			get { return _iBenchmarkPriceType; }
			set { _iBenchmarkPriceType = value; }
		}
		public string BenchmarkSecurityID
		{
			get { return _sBenchmarkSecurityID; }
			set { _sBenchmarkSecurityID = value; }
		}
		public string BenchmarkSecurityIDSource
		{
			get { return _sBenchmarkSecurityIDSource; }
			set { _sBenchmarkSecurityIDSource = value; }
		}
		public string YieldType
		{
			get { return _sYieldType; }
			set { _sYieldType = value; }
		}
		public double Yield
		{
			get { return _dYield; }
			set { _dYield = value; }
		}
		public DateTime YieldCalcDate
		{
			get { return _dtYieldCalcDate; }
			set { _dtYieldCalcDate = value; }
		}
		public DateTime YieldRedemptionDate
		{
			get { return _dtYieldRedemptionDate; }
			set { _dtYieldRedemptionDate = value; }
		}
		public double YieldRedemptionPrice
		{
			get { return _dYieldRedemptionPrice; }
			set { _dYieldRedemptionPrice = value; }
		}
		public int YieldRedemptionPriceType
		{
			get { return _iYieldRedemptionPriceType; }
			set { _iYieldRedemptionPriceType = value; }
		}
		public string Currency
		{
			get { return _sCurrency; }
			set { _sCurrency = value; }
		}
		public string ComplianceID
		{
			get { return _sComplianceID; }
			set { _sComplianceID = value; }
		}
		public bool SolicitedFlag
		{
			get { return _bSolicitedFlag; }
			set { _bSolicitedFlag = value; }
		}
		public string IOIid
		{
			get { return _sIOIid; }
			set { _sIOIid = value; }
		}
		public string QuoteID
		{
			get { return _sQuoteID; }
			set { _sQuoteID = value; }
		}
		public char TimeInForce
		{
			get { return _cTimeInForce; }
			set { _cTimeInForce = value; }
		}
		public DateTime EffectiveTime
		{
			get { return _dtEffectiveTime; }
			set { _dtEffectiveTime = value; }
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
		public int GTBookingInst
		{
			get { return _iGTBookingInst; }
			set { _iGTBookingInst = value; }
		}
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
		public char OrderCapacity
		{
			get { return _cOrderCapacity; }
			set { _cOrderCapacity = value; }
		}
		public string OrderRestrictions
		{
			get { return _sOrderRestrictions; }
			set { _sOrderRestrictions = value; }
		}
		public int CustOrderCapacity
		{
			get { return _iCustOrderCapacity; }
			set { _iCustOrderCapacity = value; }
		}
		public bool ForexReq
		{
			get { return _bForexReq; }
			set { _bForexReq = value; }
		}
		public string SettlCurrency
		{
			get { return _sSettlCurrency; }
			set { _sSettlCurrency = value; }
		}
		public int BookingType
		{
			get { return _iBookingType; }
			set { _iBookingType = value; }
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
		public DateTime SettlDate2
		{
			get { return _dtSettlDate2; }
			set { _dtSettlDate2 = value; }
		}
		public int OrderQty2
		{
			get { return _iOrderQty2; }
			set { _iOrderQty2 = value; }
		}
		public double Price2
		{
			get { return _dPrice2; }
			set { _dPrice2 = value; }
		}
		public char PositionEffect
		{
			get { return _cPositionEffect; }
			set { _cPositionEffect = value; }
		}
		public int CoveredOrUncovered
		{
			get { return _iCoveredOrUncovered; }
			set { _iCoveredOrUncovered = value; }
		}
		public int MaxShow
		{
			get { return _iMaxShow; }
			set { _iMaxShow = value; }
		}
		public double PegOffsetValue
		{
			get { return _dPegOffsetValue; }
			set { _dPegOffsetValue = value; }
		}
		public int PegMoveType
		{
			get { return _iPegMoveType; }
			set { _iPegMoveType = value; }
		}
		public int PegOffsetType
		{
			get { return _iPegOffsetType; }
			set { _iPegOffsetType = value; }
		}
		public int PegLimitType
		{
			get { return _iPegLimitType; }
			set { _iPegLimitType = value; }
		}
		public int PegRoundDirection
		{
			get { return _iPegRoundDirection; }
			set { _iPegRoundDirection = value; }
		}
		public int PegScope
		{
			get { return _iPegScope; }
			set { _iPegScope = value; }
		}
		public char DiscretionInst
		{
			get { return _cDiscretionInst; }
			set { _cDiscretionInst = value; }
		}
		public double DiscretionOffsetValue
		{
			get { return _dDiscretionOffsetValue; }
			set { _dDiscretionOffsetValue = value; }
		}
		public int DiscretionMoveType
		{
			get { return _iDiscretionMoveType; }
			set { _iDiscretionMoveType = value; }
		}
		public int DiscretionOffsetType
		{
			get { return _iDiscretionOffsetType; }
			set { _iDiscretionOffsetType = value; }
		}
		public int DiscretionLimitType
		{
			get { return _iDiscretionLimitType; }
			set { _iDiscretionLimitType = value; }
		}
		public int DiscretionRoundDirection
		{
			get { return _iDiscretionRoundDirection; }
			set { _iDiscretionRoundDirection = value; }
		}
		public int DiscretionScope
		{
			get { return _iDiscretionScope; }
			set { _iDiscretionScope = value; }
		}
		public int TargetStrategy
		{
			get { return _iTargetStrategy; }
			set { _iTargetStrategy = value; }
		}
		public string TargetStrategyParameters
		{
			get { return _sTargetStrategyParameters; }
			set { _sTargetStrategyParameters = value; }
		}
		public double ParticipationRate
		{
			get { return _dParticipationRate; }
			set { _dParticipationRate = value; }
		}
		public string Designation
		{
			get { return _sDesignation; }
			set { _sDesignation = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NewOrderList.TAG_ClOrdID:
						return _sClOrdID;
					case NewOrderList.TAG_SecondaryClOrdID:
						return _sSecondaryClOrdID;
					case NewOrderList.TAG_ListSeqNo:
						return _iListSeqNo;
					case NewOrderList.TAG_ClOrdLinkID:
						return _sClOrdLinkID;
					case NewOrderList.TAG_SettlInstMode:
						return _cSettlInstMode;
					case NewOrderList.TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case NewOrderList.TAG_TradeOriginationDate:
						return _dtTradeOriginationDate;
					case NewOrderList.TAG_TradeDate:
						return _dtTradeDate;
					case NewOrderList.TAG_Account:
						return _sAccount;
					case NewOrderList.TAG_AcctIDSource:
						return _iAcctIDSource;
					case NewOrderList.TAG_AccountType:
						return _iAccountType;
					case NewOrderList.TAG_DayBookingInst:
						return _cDayBookingInst;
					case NewOrderList.TAG_BookingUnit:
						return _cBookingUnit;
					case NewOrderList.TAG_AllocID:
						return _sAllocID;
					case NewOrderList.TAG_PreallocMethod:
						return _cPreallocMethod;
					case NewOrderList.TAG_NoAllocs:
						return _iNoAllocs;
					case NewOrderList.TAG_SettlType:
						return _cSettlType;
					case NewOrderList.TAG_SettlDate:
						return _dtSettlDate;
					case NewOrderList.TAG_CashMargin:
						return _cCashMargin;
					case NewOrderList.TAG_ClearingFeeIndicator:
						return _sClearingFeeIndicator;
					case NewOrderList.TAG_HandlInst:
						return _cHandlInst;
					case NewOrderList.TAG_ExecInst:
						return _sExecInst;
					case NewOrderList.TAG_MinQty:
						return _iMinQty;
					case NewOrderList.TAG_MaxFloor:
						return _iMaxFloor;
					case NewOrderList.TAG_ExDestination:
						return _sExDestination;
					case NewOrderList.TAG_NoTradingSessions:
						return _iNoTradingSessions;
					case NewOrderList.TAG_ProcessCode:
						return _cProcessCode;
					case NewOrderList.TAG_Symbol:
						return _sSymbol;
					case NewOrderList.TAG_SymbolSfx:
						return _sSymbolSfx;
					case NewOrderList.TAG_SecurityID:
						return _sSecurityID;
					case NewOrderList.TAG_SecurityIDSource:
						return _sSecurityIDSource;
					case NewOrderList.TAG_NoSecurityAltID:
						return _iNoSecurityAltID;
					case NewOrderList.TAG_Product:
						return _iProduct;
					case NewOrderList.TAG_CFICode:
						return _sCFICode;
					case NewOrderList.TAG_SecurityType:
						return _sSecurityType;
					case NewOrderList.TAG_SecuritySubType:
						return _sSecuritySubType;
					case NewOrderList.TAG_MaturityMonthYear:
						return _dtMaturityMonthYear;
					case NewOrderList.TAG_MaturityDate:
						return _dtMaturityDate;
					case NewOrderList.TAG_CouponPaymentDate:
						return _dtCouponPaymentDate;
					case NewOrderList.TAG_IssueDate:
						return _dtIssueDate;
					case NewOrderList.TAG_RepoCollateralSecurityType:
						return _iRepoCollateralSecurityType;
					case NewOrderList.TAG_RepurchaseTerm:
						return _iRepurchaseTerm;
					case NewOrderList.TAG_RepurchaseRate:
						return _dRepurchaseRate;
					case NewOrderList.TAG_Factor:
						return _dFactor;
					case NewOrderList.TAG_CreditRating:
						return _sCreditRating;
					case NewOrderList.TAG_InstrRegistry:
						return _sInstrRegistry;
					case NewOrderList.TAG_CountryOfIssue:
						return _sCountryOfIssue;
					case NewOrderList.TAG_StateOrProvinceOfIssue:
						return _sStateOrProvinceOfIssue;
					case NewOrderList.TAG_LocaleOfIssue:
						return _sLocaleOfIssue;
					case NewOrderList.TAG_RedemptionDate:
						return _dtRedemptionDate;
					case NewOrderList.TAG_StrikePrice:
						return _dStrikePrice;
					case NewOrderList.TAG_StrikeCurrency:
						return _sStrikeCurrency;
					case NewOrderList.TAG_OptAttribute:
						return _cOptAttribute;
					case NewOrderList.TAG_ContractMultiplier:
						return _dContractMultiplier;
					case NewOrderList.TAG_CouponRate:
						return _dCouponRate;
					case NewOrderList.TAG_SecurityExchange:
						return _sSecurityExchange;
					case NewOrderList.TAG_Issuer:
						return _sIssuer;
					case NewOrderList.TAG_EncodedIssuerLen:
						return _iEncodedIssuerLen;
					case NewOrderList.TAG_EncodedIssuer:
						return _sEncodedIssuer;
					case NewOrderList.TAG_SecurityDesc:
						return _sSecurityDesc;
					case NewOrderList.TAG_EncodedSecurityDescLen:
						return _iEncodedSecurityDescLen;
					case NewOrderList.TAG_EncodedSecurityDesc:
						return _sEncodedSecurityDesc;
					case NewOrderList.TAG_Pool:
						return _sPool;
					case NewOrderList.TAG_ContractSettlMonth:
						return _dtContractSettlMonth;
					case NewOrderList.TAG_CPProgram:
						return _iCPProgram;
					case NewOrderList.TAG_CPRegType:
						return _sCPRegType;
					case NewOrderList.TAG_NoEvents:
						return _iNoEvents;
					case NewOrderList.TAG_DatedDate:
						return _dtDatedDate;
					case NewOrderList.TAG_InterestAccrualDate:
						return _dtInterestAccrualDate;
					case NewOrderList.TAG_NoUnderlyings:
						return _iNoUnderlyings;
					case NewOrderList.TAG_PrevClosePx:
						return _dPrevClosePx;
					case NewOrderList.TAG_Side:
						return _cSide;
					case NewOrderList.TAG_SideValueInd:
						return _iSideValueInd;
					case NewOrderList.TAG_LocateReqd:
						return _bLocateReqd;
					case NewOrderList.TAG_TransactTime:
						return _dtTransactTime;
					case NewOrderList.TAG_NoStipulations:
						return _iNoStipulations;
					case NewOrderList.TAG_QtyType:
						return _iQtyType;
					case NewOrderList.TAG_OrderQty:
						return _iOrderQty;
					case NewOrderList.TAG_CashOrderQty:
						return _iCashOrderQty;
					case NewOrderList.TAG_OrderPercent:
						return _dOrderPercent;
					case NewOrderList.TAG_RoundingDirection:
						return _cRoundingDirection;
					case NewOrderList.TAG_RoundingModulus:
						return _dRoundingModulus;
					case NewOrderList.TAG_OrdType:
						return _cOrdType;
					case NewOrderList.TAG_PriceType:
						return _iPriceType;
					case NewOrderList.TAG_Price:
						return _dPrice;
					case NewOrderList.TAG_StopPx:
						return _dStopPx;
					case NewOrderList.TAG_Spread:
						return _dSpread;
					case NewOrderList.TAG_BenchmarkCurveCurrency:
						return _sBenchmarkCurveCurrency;
					case NewOrderList.TAG_BenchmarkCurveName:
						return _sBenchmarkCurveName;
					case NewOrderList.TAG_BenchmarkCurvePoint:
						return _sBenchmarkCurvePoint;
					case NewOrderList.TAG_BenchmarkPrice:
						return _dBenchmarkPrice;
					case NewOrderList.TAG_BenchmarkPriceType:
						return _iBenchmarkPriceType;
					case NewOrderList.TAG_BenchmarkSecurityID:
						return _sBenchmarkSecurityID;
					case NewOrderList.TAG_BenchmarkSecurityIDSource:
						return _sBenchmarkSecurityIDSource;
					case NewOrderList.TAG_YieldType:
						return _sYieldType;
					case NewOrderList.TAG_Yield:
						return _dYield;
					case NewOrderList.TAG_YieldCalcDate:
						return _dtYieldCalcDate;
					case NewOrderList.TAG_YieldRedemptionDate:
						return _dtYieldRedemptionDate;
					case NewOrderList.TAG_YieldRedemptionPrice:
						return _dYieldRedemptionPrice;
					case NewOrderList.TAG_YieldRedemptionPriceType:
						return _iYieldRedemptionPriceType;
					case NewOrderList.TAG_Currency:
						return _sCurrency;
					case NewOrderList.TAG_ComplianceID:
						return _sComplianceID;
					case NewOrderList.TAG_SolicitedFlag:
						return _bSolicitedFlag;
					case NewOrderList.TAG_IOIid:
						return _sIOIid;
					case NewOrderList.TAG_QuoteID:
						return _sQuoteID;
					case NewOrderList.TAG_TimeInForce:
						return _cTimeInForce;
					case NewOrderList.TAG_EffectiveTime:
						return _dtEffectiveTime;
					case NewOrderList.TAG_ExpireDate:
						return _dtExpireDate;
					case NewOrderList.TAG_ExpireTime:
						return _dtExpireTime;
					case NewOrderList.TAG_GTBookingInst:
						return _iGTBookingInst;
					case NewOrderList.TAG_Commission:
						return _dCommission;
					case NewOrderList.TAG_CommType:
						return _cCommType;
					case NewOrderList.TAG_CommCurrency:
						return _sCommCurrency;
					case NewOrderList.TAG_FundRenewWaiv:
						return _cFundRenewWaiv;
					case NewOrderList.TAG_OrderCapacity:
						return _cOrderCapacity;
					case NewOrderList.TAG_OrderRestrictions:
						return _sOrderRestrictions;
					case NewOrderList.TAG_CustOrderCapacity:
						return _iCustOrderCapacity;
					case NewOrderList.TAG_ForexReq:
						return _bForexReq;
					case NewOrderList.TAG_SettlCurrency:
						return _sSettlCurrency;
					case NewOrderList.TAG_BookingType:
						return _iBookingType;
					case NewOrderList.TAG_Text:
						return _sText;
					case NewOrderList.TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case NewOrderList.TAG_EncodedText:
						return _sEncodedText;
					case NewOrderList.TAG_SettlDate2:
						return _dtSettlDate2;
					case NewOrderList.TAG_OrderQty2:
						return _iOrderQty2;
					case NewOrderList.TAG_Price2:
						return _dPrice2;
					case NewOrderList.TAG_PositionEffect:
						return _cPositionEffect;
					case NewOrderList.TAG_CoveredOrUncovered:
						return _iCoveredOrUncovered;
					case NewOrderList.TAG_MaxShow:
						return _iMaxShow;
					case NewOrderList.TAG_PegOffsetValue:
						return _dPegOffsetValue;
					case NewOrderList.TAG_PegMoveType:
						return _iPegMoveType;
					case NewOrderList.TAG_PegOffsetType:
						return _iPegOffsetType;
					case NewOrderList.TAG_PegLimitType:
						return _iPegLimitType;
					case NewOrderList.TAG_PegRoundDirection:
						return _iPegRoundDirection;
					case NewOrderList.TAG_PegScope:
						return _iPegScope;
					case NewOrderList.TAG_DiscretionInst:
						return _cDiscretionInst;
					case NewOrderList.TAG_DiscretionOffsetValue:
						return _dDiscretionOffsetValue;
					case NewOrderList.TAG_DiscretionMoveType:
						return _iDiscretionMoveType;
					case NewOrderList.TAG_DiscretionOffsetType:
						return _iDiscretionOffsetType;
					case NewOrderList.TAG_DiscretionLimitType:
						return _iDiscretionLimitType;
					case NewOrderList.TAG_DiscretionRoundDirection:
						return _iDiscretionRoundDirection;
					case NewOrderList.TAG_DiscretionScope:
						return _iDiscretionScope;
					case NewOrderList.TAG_TargetStrategy:
						return _iTargetStrategy;
					case NewOrderList.TAG_TargetStrategyParameters:
						return _sTargetStrategyParameters;
					case NewOrderList.TAG_ParticipationRate:
						return _dParticipationRate;
					case NewOrderList.TAG_Designation:
						return _sDesignation;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case NewOrderList.TAG_SecondaryClOrdID:
						_sSecondaryClOrdID = (string)value;
						break;
					case NewOrderList.TAG_ListSeqNo:
						_iListSeqNo = (int)value;
						break;
					case NewOrderList.TAG_ClOrdLinkID:
						_sClOrdLinkID = (string)value;
						break;
					case NewOrderList.TAG_SettlInstMode:
						_cSettlInstMode = (char)value;
						break;
					case NewOrderList.TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case NewOrderList.TAG_TradeOriginationDate:
						_dtTradeOriginationDate = (DateTime)value;
						break;
					case NewOrderList.TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case NewOrderList.TAG_Account:
						_sAccount = (string)value;
						break;
					case NewOrderList.TAG_AcctIDSource:
						_iAcctIDSource = (int)value;
						break;
					case NewOrderList.TAG_AccountType:
						_iAccountType = (int)value;
						break;
					case NewOrderList.TAG_DayBookingInst:
						_cDayBookingInst = (char)value;
						break;
					case NewOrderList.TAG_BookingUnit:
						_cBookingUnit = (char)value;
						break;
					case NewOrderList.TAG_AllocID:
						_sAllocID = (string)value;
						break;
					case NewOrderList.TAG_PreallocMethod:
						_cPreallocMethod = (char)value;
						break;
					case NewOrderList.TAG_NoAllocs:
						_iNoAllocs = (int)value;
						break;
					case NewOrderList.TAG_SettlType:
						_cSettlType = (char)value;
						break;
					case NewOrderList.TAG_SettlDate:
						_dtSettlDate = (DateTime)value;
						break;
					case NewOrderList.TAG_CashMargin:
						_cCashMargin = (char)value;
						break;
					case NewOrderList.TAG_ClearingFeeIndicator:
						_sClearingFeeIndicator = (string)value;
						break;
					case NewOrderList.TAG_HandlInst:
						_cHandlInst = (char)value;
						break;
					case NewOrderList.TAG_ExecInst:
						_sExecInst = (string)value;
						break;
					case NewOrderList.TAG_MinQty:
						_iMinQty = (int)value;
						break;
					case NewOrderList.TAG_MaxFloor:
						_iMaxFloor = (int)value;
						break;
					case NewOrderList.TAG_ExDestination:
						_sExDestination = (string)value;
						break;
					case NewOrderList.TAG_NoTradingSessions:
						_iNoTradingSessions = (int)value;
						break;
					case NewOrderList.TAG_ProcessCode:
						_cProcessCode = (char)value;
						break;
					case NewOrderList.TAG_Symbol:
						_sSymbol = (string)value;
						break;
					case NewOrderList.TAG_SymbolSfx:
						_sSymbolSfx = (string)value;
						break;
					case NewOrderList.TAG_SecurityID:
						_sSecurityID = (string)value;
						break;
					case NewOrderList.TAG_SecurityIDSource:
						_sSecurityIDSource = (string)value;
						break;
					case NewOrderList.TAG_NoSecurityAltID:
						_iNoSecurityAltID = (int)value;
						break;
					case NewOrderList.TAG_Product:
						_iProduct = (int)value;
						break;
					case NewOrderList.TAG_CFICode:
						_sCFICode = (string)value;
						break;
					case NewOrderList.TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case NewOrderList.TAG_SecuritySubType:
						_sSecuritySubType = (string)value;
						break;
					case NewOrderList.TAG_MaturityMonthYear:
						_dtMaturityMonthYear = (DateTime)value;
						break;
					case NewOrderList.TAG_MaturityDate:
						_dtMaturityDate = (DateTime)value;
						break;
					case NewOrderList.TAG_CouponPaymentDate:
						_dtCouponPaymentDate = (DateTime)value;
						break;
					case NewOrderList.TAG_IssueDate:
						_dtIssueDate = (DateTime)value;
						break;
					case NewOrderList.TAG_RepoCollateralSecurityType:
						_iRepoCollateralSecurityType = (int)value;
						break;
					case NewOrderList.TAG_RepurchaseTerm:
						_iRepurchaseTerm = (int)value;
						break;
					case NewOrderList.TAG_RepurchaseRate:
						_dRepurchaseRate = (double)value;
						break;
					case NewOrderList.TAG_Factor:
						_dFactor = (double)value;
						break;
					case NewOrderList.TAG_CreditRating:
						_sCreditRating = (string)value;
						break;
					case NewOrderList.TAG_InstrRegistry:
						_sInstrRegistry = (string)value;
						break;
					case NewOrderList.TAG_CountryOfIssue:
						_sCountryOfIssue = (string)value;
						break;
					case NewOrderList.TAG_StateOrProvinceOfIssue:
						_sStateOrProvinceOfIssue = (string)value;
						break;
					case NewOrderList.TAG_LocaleOfIssue:
						_sLocaleOfIssue = (string)value;
						break;
					case NewOrderList.TAG_RedemptionDate:
						_dtRedemptionDate = (DateTime)value;
						break;
					case NewOrderList.TAG_StrikePrice:
						_dStrikePrice = (double)value;
						break;
					case NewOrderList.TAG_StrikeCurrency:
						_sStrikeCurrency = (string)value;
						break;
					case NewOrderList.TAG_OptAttribute:
						_cOptAttribute = (char)value;
						break;
					case NewOrderList.TAG_ContractMultiplier:
						_dContractMultiplier = (double)value;
						break;
					case NewOrderList.TAG_CouponRate:
						_dCouponRate = (double)value;
						break;
					case NewOrderList.TAG_SecurityExchange:
						_sSecurityExchange = (string)value;
						break;
					case NewOrderList.TAG_Issuer:
						_sIssuer = (string)value;
						break;
					case NewOrderList.TAG_EncodedIssuerLen:
						_iEncodedIssuerLen = (int)value;
						break;
					case NewOrderList.TAG_EncodedIssuer:
						_sEncodedIssuer = (string)value;
						break;
					case NewOrderList.TAG_SecurityDesc:
						_sSecurityDesc = (string)value;
						break;
					case NewOrderList.TAG_EncodedSecurityDescLen:
						_iEncodedSecurityDescLen = (int)value;
						break;
					case NewOrderList.TAG_EncodedSecurityDesc:
						_sEncodedSecurityDesc = (string)value;
						break;
					case NewOrderList.TAG_Pool:
						_sPool = (string)value;
						break;
					case NewOrderList.TAG_ContractSettlMonth:
						_dtContractSettlMonth = (DateTime)value;
						break;
					case NewOrderList.TAG_CPProgram:
						_iCPProgram = (int)value;
						break;
					case NewOrderList.TAG_CPRegType:
						_sCPRegType = (string)value;
						break;
					case NewOrderList.TAG_NoEvents:
						_iNoEvents = (int)value;
						break;
					case NewOrderList.TAG_DatedDate:
						_dtDatedDate = (DateTime)value;
						break;
					case NewOrderList.TAG_InterestAccrualDate:
						_dtInterestAccrualDate = (DateTime)value;
						break;
					case NewOrderList.TAG_NoUnderlyings:
						_iNoUnderlyings = (int)value;
						break;
					case NewOrderList.TAG_PrevClosePx:
						_dPrevClosePx = (double)value;
						break;
					case NewOrderList.TAG_Side:
						_cSide = (char)value;
						break;
					case NewOrderList.TAG_SideValueInd:
						_iSideValueInd = (int)value;
						break;
					case NewOrderList.TAG_LocateReqd:
						_bLocateReqd = (bool)value;
						break;
					case NewOrderList.TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case NewOrderList.TAG_NoStipulations:
						_iNoStipulations = (int)value;
						break;
					case NewOrderList.TAG_QtyType:
						_iQtyType = (int)value;
						break;
					case NewOrderList.TAG_OrderQty:
						_iOrderQty = (int)value;
						break;
					case NewOrderList.TAG_CashOrderQty:
						_iCashOrderQty = (int)value;
						break;
					case NewOrderList.TAG_OrderPercent:
						_dOrderPercent = (double)value;
						break;
					case NewOrderList.TAG_RoundingDirection:
						_cRoundingDirection = (char)value;
						break;
					case NewOrderList.TAG_RoundingModulus:
						_dRoundingModulus = (double)value;
						break;
					case NewOrderList.TAG_OrdType:
						_cOrdType = (char)value;
						break;
					case NewOrderList.TAG_PriceType:
						_iPriceType = (int)value;
						break;
					case NewOrderList.TAG_Price:
						_dPrice = (double)value;
						break;
					case NewOrderList.TAG_StopPx:
						_dStopPx = (double)value;
						break;
					case NewOrderList.TAG_Spread:
						_dSpread = (double)value;
						break;
					case NewOrderList.TAG_BenchmarkCurveCurrency:
						_sBenchmarkCurveCurrency = (string)value;
						break;
					case NewOrderList.TAG_BenchmarkCurveName:
						_sBenchmarkCurveName = (string)value;
						break;
					case NewOrderList.TAG_BenchmarkCurvePoint:
						_sBenchmarkCurvePoint = (string)value;
						break;
					case NewOrderList.TAG_BenchmarkPrice:
						_dBenchmarkPrice = (double)value;
						break;
					case NewOrderList.TAG_BenchmarkPriceType:
						_iBenchmarkPriceType = (int)value;
						break;
					case NewOrderList.TAG_BenchmarkSecurityID:
						_sBenchmarkSecurityID = (string)value;
						break;
					case NewOrderList.TAG_BenchmarkSecurityIDSource:
						_sBenchmarkSecurityIDSource = (string)value;
						break;
					case NewOrderList.TAG_YieldType:
						_sYieldType = (string)value;
						break;
					case NewOrderList.TAG_Yield:
						_dYield = (double)value;
						break;
					case NewOrderList.TAG_YieldCalcDate:
						_dtYieldCalcDate = (DateTime)value;
						break;
					case NewOrderList.TAG_YieldRedemptionDate:
						_dtYieldRedemptionDate = (DateTime)value;
						break;
					case NewOrderList.TAG_YieldRedemptionPrice:
						_dYieldRedemptionPrice = (double)value;
						break;
					case NewOrderList.TAG_YieldRedemptionPriceType:
						_iYieldRedemptionPriceType = (int)value;
						break;
					case NewOrderList.TAG_Currency:
						_sCurrency = (string)value;
						break;
					case NewOrderList.TAG_ComplianceID:
						_sComplianceID = (string)value;
						break;
					case NewOrderList.TAG_SolicitedFlag:
						_bSolicitedFlag = (bool)value;
						break;
					case NewOrderList.TAG_IOIid:
						_sIOIid = (string)value;
						break;
					case NewOrderList.TAG_QuoteID:
						_sQuoteID = (string)value;
						break;
					case NewOrderList.TAG_TimeInForce:
						_cTimeInForce = (char)value;
						break;
					case NewOrderList.TAG_EffectiveTime:
						_dtEffectiveTime = (DateTime)value;
						break;
					case NewOrderList.TAG_ExpireDate:
						_dtExpireDate = (DateTime)value;
						break;
					case NewOrderList.TAG_ExpireTime:
						_dtExpireTime = (DateTime)value;
						break;
					case NewOrderList.TAG_GTBookingInst:
						_iGTBookingInst = (int)value;
						break;
					case NewOrderList.TAG_Commission:
						_dCommission = (double)value;
						break;
					case NewOrderList.TAG_CommType:
						_cCommType = (char)value;
						break;
					case NewOrderList.TAG_CommCurrency:
						_sCommCurrency = (string)value;
						break;
					case NewOrderList.TAG_FundRenewWaiv:
						_cFundRenewWaiv = (char)value;
						break;
					case NewOrderList.TAG_OrderCapacity:
						_cOrderCapacity = (char)value;
						break;
					case NewOrderList.TAG_OrderRestrictions:
						_sOrderRestrictions = (string)value;
						break;
					case NewOrderList.TAG_CustOrderCapacity:
						_iCustOrderCapacity = (int)value;
						break;
					case NewOrderList.TAG_ForexReq:
						_bForexReq = (bool)value;
						break;
					case NewOrderList.TAG_SettlCurrency:
						_sSettlCurrency = (string)value;
						break;
					case NewOrderList.TAG_BookingType:
						_iBookingType = (int)value;
						break;
					case NewOrderList.TAG_Text:
						_sText = (string)value;
						break;
					case NewOrderList.TAG_EncodedTextLen:
						_iEncodedTextLen = (int)value;
						break;
					case NewOrderList.TAG_EncodedText:
						_sEncodedText = (string)value;
						break;
					case NewOrderList.TAG_SettlDate2:
						_dtSettlDate2 = (DateTime)value;
						break;
					case NewOrderList.TAG_OrderQty2:
						_iOrderQty2 = (int)value;
						break;
					case NewOrderList.TAG_Price2:
						_dPrice2 = (double)value;
						break;
					case NewOrderList.TAG_PositionEffect:
						_cPositionEffect = (char)value;
						break;
					case NewOrderList.TAG_CoveredOrUncovered:
						_iCoveredOrUncovered = (int)value;
						break;
					case NewOrderList.TAG_MaxShow:
						_iMaxShow = (int)value;
						break;
					case NewOrderList.TAG_PegOffsetValue:
						_dPegOffsetValue = (double)value;
						break;
					case NewOrderList.TAG_PegMoveType:
						_iPegMoveType = (int)value;
						break;
					case NewOrderList.TAG_PegOffsetType:
						_iPegOffsetType = (int)value;
						break;
					case NewOrderList.TAG_PegLimitType:
						_iPegLimitType = (int)value;
						break;
					case NewOrderList.TAG_PegRoundDirection:
						_iPegRoundDirection = (int)value;
						break;
					case NewOrderList.TAG_PegScope:
						_iPegScope = (int)value;
						break;
					case NewOrderList.TAG_DiscretionInst:
						_cDiscretionInst = (char)value;
						break;
					case NewOrderList.TAG_DiscretionOffsetValue:
						_dDiscretionOffsetValue = (double)value;
						break;
					case NewOrderList.TAG_DiscretionMoveType:
						_iDiscretionMoveType = (int)value;
						break;
					case NewOrderList.TAG_DiscretionOffsetType:
						_iDiscretionOffsetType = (int)value;
						break;
					case NewOrderList.TAG_DiscretionLimitType:
						_iDiscretionLimitType = (int)value;
						break;
					case NewOrderList.TAG_DiscretionRoundDirection:
						_iDiscretionRoundDirection = (int)value;
						break;
					case NewOrderList.TAG_DiscretionScope:
						_iDiscretionScope = (int)value;
						break;
					case NewOrderList.TAG_TargetStrategy:
						_iTargetStrategy = (int)value;
						break;
					case NewOrderList.TAG_TargetStrategyParameters:
						_sTargetStrategyParameters = (string)value;
						break;
					case NewOrderList.TAG_ParticipationRate:
						_dParticipationRate = (double)value;
						break;
					case NewOrderList.TAG_Designation:
						_sDesignation = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListOrderList
	{
		private ArrayList _al;
		private NewOrderListOrder _last;

		public NewOrderListOrder this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListOrder)_al[i];
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

		public void Add(NewOrderListOrder item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListOrder item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListOrder Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private NewOrderListPartySubIDList _listPartySubID = new NewOrderListPartySubIDList();

		public string PartyID
		{
			get { return _sPartyID; }
			set { _sPartyID = value; }
		}
		public char PartyIDSource
		{
			get { return _cPartyIDSource; }
			set { _cPartyIDSource = value; }
		}
		public int PartyRole
		{
			get { return _iPartyRole; }
			set { _iPartyRole = value; }
		}
		public int NoPartySubIDs
		{
			get { return _iNoPartySubIDs; }
			set { _iNoPartySubIDs = value; }
		}
		public NewOrderListPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NewOrderList.TAG_PartyID:
						return _sPartyID;
					case NewOrderList.TAG_PartyIDSource:
						return _cPartyIDSource;
					case NewOrderList.TAG_PartyRole:
						return _iPartyRole;
					case NewOrderList.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case NewOrderList.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case NewOrderList.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case NewOrderList.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListPartyIDList
	{
		private ArrayList _al;
		private NewOrderListPartyID _last;

		public NewOrderListPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListPartyID)_al[i];
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

		public void Add(NewOrderListPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListPartyID Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListPartySubID
	{
		private string _sPartySubID;
		private int _iPartySubIDType;

		public string PartySubID
		{
			get { return _sPartySubID; }
			set { _sPartySubID = value; }
		}
		public int PartySubIDType
		{
			get { return _iPartySubIDType; }
			set { _iPartySubIDType = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NewOrderList.TAG_PartySubID:
						return _sPartySubID;
					case NewOrderList.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case NewOrderList.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListPartySubIDList
	{
		private ArrayList _al;
		private NewOrderListPartySubID _last;

		public NewOrderListPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListPartySubID)_al[i];
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

		public void Add(NewOrderListPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListPartySubID Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListAlloc
	{
		private string _sAllocAccount;
		private int _iAllocAcctIDSource;
		private string _sAllocSettlCurrency;
		private string _sIndividualAllocID;
		private int _iNoNestedPartyIDs;
		private NewOrderListNestedPartyIDList _listNestedPartyID = new NewOrderListNestedPartyIDList();
		private int _iAllocQty;

		public string AllocAccount
		{
			get { return _sAllocAccount; }
			set { _sAllocAccount = value; }
		}
		public int AllocAcctIDSource
		{
			get { return _iAllocAcctIDSource; }
			set { _iAllocAcctIDSource = value; }
		}
		public string AllocSettlCurrency
		{
			get { return _sAllocSettlCurrency; }
			set { _sAllocSettlCurrency = value; }
		}
		public string IndividualAllocID
		{
			get { return _sIndividualAllocID; }
			set { _sIndividualAllocID = value; }
		}
		public int NoNestedPartyIDs
		{
			get { return _iNoNestedPartyIDs; }
			set { _iNoNestedPartyIDs = value; }
		}
		public NewOrderListNestedPartyIDList NestedPartyID 
		{
			get { return _listNestedPartyID; }
		}
		public int AllocQty
		{
			get { return _iAllocQty; }
			set { _iAllocQty = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NewOrderList.TAG_AllocAccount:
						return _sAllocAccount;
					case NewOrderList.TAG_AllocAcctIDSource:
						return _iAllocAcctIDSource;
					case NewOrderList.TAG_AllocSettlCurrency:
						return _sAllocSettlCurrency;
					case NewOrderList.TAG_IndividualAllocID:
						return _sIndividualAllocID;
					case NewOrderList.TAG_NoNestedPartyIDs:
						return _iNoNestedPartyIDs;
					case NewOrderList.TAG_AllocQty:
						return _iAllocQty;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_AllocAccount:
						_sAllocAccount = (string)value;
						break;
					case NewOrderList.TAG_AllocAcctIDSource:
						_iAllocAcctIDSource = (int)value;
						break;
					case NewOrderList.TAG_AllocSettlCurrency:
						_sAllocSettlCurrency = (string)value;
						break;
					case NewOrderList.TAG_IndividualAllocID:
						_sIndividualAllocID = (string)value;
						break;
					case NewOrderList.TAG_NoNestedPartyIDs:
						_iNoNestedPartyIDs = (int)value;
						break;
					case NewOrderList.TAG_AllocQty:
						_iAllocQty = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListAllocList
	{
		private ArrayList _al;
		private NewOrderListAlloc _last;

		public NewOrderListAlloc this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListAlloc)_al[i];
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

		public void Add(NewOrderListAlloc item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListAlloc item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListAlloc Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListNestedPartyID
	{
		private string _sNestedPartyID;
		private char _cNestedPartyIDSource;
		private int _iNestedPartyRole;
		private int _iNoNestedPartySubIDs;
		private NewOrderListNestedPartySubIDList _listNestedPartySubID = new NewOrderListNestedPartySubIDList();

		public string NestedPartyID
		{
			get { return _sNestedPartyID; }
			set { _sNestedPartyID = value; }
		}
		public char NestedPartyIDSource
		{
			get { return _cNestedPartyIDSource; }
			set { _cNestedPartyIDSource = value; }
		}
		public int NestedPartyRole
		{
			get { return _iNestedPartyRole; }
			set { _iNestedPartyRole = value; }
		}
		public int NoNestedPartySubIDs
		{
			get { return _iNoNestedPartySubIDs; }
			set { _iNoNestedPartySubIDs = value; }
		}
		public NewOrderListNestedPartySubIDList NestedPartySubID 
		{
			get { return _listNestedPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NewOrderList.TAG_NestedPartyID:
						return _sNestedPartyID;
					case NewOrderList.TAG_NestedPartyIDSource:
						return _cNestedPartyIDSource;
					case NewOrderList.TAG_NestedPartyRole:
						return _iNestedPartyRole;
					case NewOrderList.TAG_NoNestedPartySubIDs:
						return _iNoNestedPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_NestedPartyID:
						_sNestedPartyID = (string)value;
						break;
					case NewOrderList.TAG_NestedPartyIDSource:
						_cNestedPartyIDSource = (char)value;
						break;
					case NewOrderList.TAG_NestedPartyRole:
						_iNestedPartyRole = (int)value;
						break;
					case NewOrderList.TAG_NoNestedPartySubIDs:
						_iNoNestedPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListNestedPartyIDList
	{
		private ArrayList _al;
		private NewOrderListNestedPartyID _last;

		public NewOrderListNestedPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListNestedPartyID)_al[i];
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

		public void Add(NewOrderListNestedPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListNestedPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListNestedPartyID Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListNestedPartySubID
	{
		private string _sNestedPartySubID;
		private int _iNestedPartySubIDType;

		public string NestedPartySubID
		{
			get { return _sNestedPartySubID; }
			set { _sNestedPartySubID = value; }
		}
		public int NestedPartySubIDType
		{
			get { return _iNestedPartySubIDType; }
			set { _iNestedPartySubIDType = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NewOrderList.TAG_NestedPartySubID:
						return _sNestedPartySubID;
					case NewOrderList.TAG_NestedPartySubIDType:
						return _iNestedPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_NestedPartySubID:
						_sNestedPartySubID = (string)value;
						break;
					case NewOrderList.TAG_NestedPartySubIDType:
						_iNestedPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListNestedPartySubIDList
	{
		private ArrayList _al;
		private NewOrderListNestedPartySubID _last;

		public NewOrderListNestedPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListNestedPartySubID)_al[i];
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

		public void Add(NewOrderListNestedPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListNestedPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListNestedPartySubID Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListTradingSession
	{
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;

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

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NewOrderList.TAG_TradingSessionID:
						return _sTradingSessionID;
					case NewOrderList.TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case NewOrderList.TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListTradingSessionList
	{
		private ArrayList _al;
		private NewOrderListTradingSession _last;

		public NewOrderListTradingSession this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListTradingSession)_al[i];
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

		public void Add(NewOrderListTradingSession item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListTradingSession item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListTradingSession Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListSecurityAltID
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
					case NewOrderList.TAG_SecurityAltID:
						return _sSecurityAltID;
					case NewOrderList.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case NewOrderList.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListSecurityAltIDList
	{
		private ArrayList _al;
		private NewOrderListSecurityAltID _last;

		public NewOrderListSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListSecurityAltID)_al[i];
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

		public void Add(NewOrderListSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListEvent
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
					case NewOrderList.TAG_EventType:
						return _iEventType;
					case NewOrderList.TAG_EventDate:
						return _dtEventDate;
					case NewOrderList.TAG_EventPx:
						return _dEventPx;
					case NewOrderList.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_EventType:
						_iEventType = (int)value;
						break;
					case NewOrderList.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case NewOrderList.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case NewOrderList.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListEventList
	{
		private ArrayList _al;
		private NewOrderListEvent _last;

		public NewOrderListEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListEvent)_al[i];
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

		public void Add(NewOrderListEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListEvent Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private NewOrderListUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new NewOrderListUnderlyingSecurityAltIDList();
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
		public NewOrderListUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
					case NewOrderList.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case NewOrderList.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case NewOrderList.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case NewOrderList.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case NewOrderList.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case NewOrderList.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case NewOrderList.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case NewOrderList.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case NewOrderList.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case NewOrderList.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case NewOrderList.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case NewOrderList.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case NewOrderList.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case NewOrderList.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case NewOrderList.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case NewOrderList.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case NewOrderList.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case NewOrderList.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case NewOrderList.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case NewOrderList.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case NewOrderList.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case NewOrderList.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case NewOrderList.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case NewOrderList.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case NewOrderList.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case NewOrderList.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case NewOrderList.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case NewOrderList.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case NewOrderList.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case NewOrderList.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case NewOrderList.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case NewOrderList.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case NewOrderList.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case NewOrderList.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case NewOrderList.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case NewOrderList.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case NewOrderList.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case NewOrderList.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case NewOrderList.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case NewOrderList.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case NewOrderList.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case NewOrderList.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case NewOrderList.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case NewOrderList.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case NewOrderList.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case NewOrderList.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case NewOrderList.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case NewOrderList.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case NewOrderList.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case NewOrderList.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case NewOrderList.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case NewOrderList.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case NewOrderList.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case NewOrderList.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case NewOrderList.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case NewOrderList.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case NewOrderList.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case NewOrderList.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case NewOrderList.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case NewOrderList.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case NewOrderList.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case NewOrderList.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListUnderlyingList
	{
		private ArrayList _al;
		private NewOrderListUnderlying _last;

		public NewOrderListUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListUnderlying)_al[i];
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

		public void Add(NewOrderListUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListUnderlying Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListUnderlyingSecurityAltID
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
					case NewOrderList.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case NewOrderList.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case NewOrderList.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private NewOrderListUnderlyingSecurityAltID _last;

		public NewOrderListUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListUnderlyingSecurityAltID)_al[i];
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

		public void Add(NewOrderListUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class NewOrderListStipulation
	{
		private string _sStipulationType;
		private string _sStipulationValue;

		public string StipulationType
		{
			get { return _sStipulationType; }
			set { _sStipulationType = value; }
		}
		public string StipulationValue
		{
			get { return _sStipulationValue; }
			set { _sStipulationValue = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NewOrderList.TAG_StipulationType:
						return _sStipulationType;
					case NewOrderList.TAG_StipulationValue:
						return _sStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NewOrderList.TAG_StipulationType:
						_sStipulationType = (string)value;
						break;
					case NewOrderList.TAG_StipulationValue:
						_sStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewOrderListStipulationList
	{
		private ArrayList _al;
		private NewOrderListStipulation _last;

		public NewOrderListStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewOrderListStipulation)_al[i];
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

		public void Add(NewOrderListStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewOrderListStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewOrderListStipulation Last
		{
			get { return _last; }
		}
	}
}
