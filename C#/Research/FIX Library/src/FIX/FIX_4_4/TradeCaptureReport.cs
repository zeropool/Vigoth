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
	/// Summary description for TradeCaptureReport.
	/// </summary>
	public class TradeCaptureReport : Message
	{
		public const int TAG_TradeReportID = 571;
		public const int TAG_TradeReportTransType = 487;
		public const int TAG_TradeReportType = 856;
		public const int TAG_TradeRequestID = 568;
		public const int TAG_TrdType = 828;
		public const int TAG_TrdSubType = 829;
		public const int TAG_SecondaryTrdType = 855;
		public const int TAG_TransferReason = 830;
		public const int TAG_ExecType = 150;
		public const int TAG_TotNumTradeReports = 748;
		public const int TAG_LastRptRequested = 912;
		public const int TAG_UnsolicitedIndicator = 325;
		public const int TAG_SubscriptionRequestType = 263;
		public const int TAG_TradeReportRefID = 572;
		public const int TAG_SecondaryTradeReportRefID = 881;
		public const int TAG_SecondaryTradeReportID = 818;
		public const int TAG_TradeLinkID = 820;
		public const int TAG_TrdMatchID = 880;
		public const int TAG_ExecID = 17;
		public const int TAG_OrdStatus = 39;
		public const int TAG_SecondaryExecID = 527;
		public const int TAG_ExecRestatementReason = 378;
		public const int TAG_PreviouslyReported = 570;
		public const int TAG_PriceType = 423;
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
		public const int TAG_AgreementDesc = 913;
		public const int TAG_AgreementID = 914;
		public const int TAG_AgreementDate = 915;
		public const int TAG_AgreementCurrency = 918;
		public const int TAG_TerminationType = 788;
		public const int TAG_StartDate = 916;
		public const int TAG_EndDate = 917;
		public const int TAG_DeliveryType = 919;
		public const int TAG_MarginRatio = 898;
		public const int TAG_OrderQty = 38;
		public const int TAG_CashOrderQty = 152;
		public const int TAG_OrderPercent = 516;
		public const int TAG_RoundingDirection = 468;
		public const int TAG_RoundingModulus = 469;
		public const int TAG_QtyType = 854;
		public const int TAG_YieldType = 235;
		public const int TAG_Yield = 236;
		public const int TAG_YieldCalcDate = 701;
		public const int TAG_YieldRedemptionDate = 696;
		public const int TAG_YieldRedemptionPrice = 697;
		public const int TAG_YieldRedemptionPriceType = 698;
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
		public const int TAG_UnderlyingTradingSessionID = 822;
		public const int TAG_UnderlyingTradingSessionSubID = 823;
		public const int TAG_LastQty = 32;
		public const int TAG_LastPx = 31;
		public const int TAG_LastParPx = 669;
		public const int TAG_LastSpotRate = 194;
		public const int TAG_LastForwardPoints = 195;
		public const int TAG_LastMkt = 30;
		public const int TAG_TradeDate = 75;
		public const int TAG_ClearingBusinessDate = 715;
		public const int TAG_AvgPx = 6;
		public const int TAG_Spread = 218;
		public const int TAG_BenchmarkCurveCurrency = 220;
		public const int TAG_BenchmarkCurveName = 221;
		public const int TAG_BenchmarkCurvePoint = 222;
		public const int TAG_BenchmarkPrice = 662;
		public const int TAG_BenchmarkPriceType = 663;
		public const int TAG_BenchmarkSecurityID = 699;
		public const int TAG_BenchmarkSecurityIDSource = 761;
		public const int TAG_AvgPxIndicator = 819;
		public const int TAG_NoPosAmt = 753;
		public const int TAG_PosAmtType = 707;
		public const int TAG_PosAmt = 708;
		public const int TAG_MultiLegReportingType = 442;
		public const int TAG_TradeLegRefID = 824;
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
		public const int TAG_LegQty = 687;
		public const int TAG_LegSwapType = 690;
		public const int TAG_NoLegStipulations = 683;
		public const int TAG_LegStipulationType = 688;
		public const int TAG_LegStipulationValue = 689;
		public const int TAG_LegPositionEffect = 564;
		public const int TAG_LegCoveredOrUncovered = 565;
		public const int TAG_NoNestedPartyIDs = 539;
		public const int TAG_NestedPartyID = 524;
		public const int TAG_NestedPartyIDSource = 525;
		public const int TAG_NestedPartyRole = 538;
		public const int TAG_NoNestedPartySubIDs = 804;
		public const int TAG_NestedPartySubID = 545;
		public const int TAG_NestedPartySubIDType = 805;
		public const int TAG_LegRefID = 654;
		public const int TAG_LegPrice = 566;
		public const int TAG_LegSettlType = 587;
		public const int TAG_LegSettlDate = 588;
		public const int TAG_LegLastPx = 637;
		public const int TAG_TransactTime = 60;
		public const int TAG_NoTrdRegTimestamps = 768;
		public const int TAG_TrdRegTimestamp = 769;
		public const int TAG_TrdRegTimestampType = 770;
		public const int TAG_TrdRegTimestampOrigin = 771;
		public const int TAG_SettlType = 63;
		public const int TAG_SettlDate = 64;
		public const int TAG_MatchStatus = 573;
		public const int TAG_MatchType = 574;
		public const int TAG_NoSides = 552;
		public const int TAG_Side = 54;
		public const int TAG_OrderID = 37;
		public const int TAG_SecondaryOrderID = 198;
		public const int TAG_ClOrdID = 11;
		public const int TAG_SecondaryClOrdID = 526;
		public const int TAG_ListID = 66;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_Account = 1;
		public const int TAG_AcctIDSource = 660;
		public const int TAG_AccountType = 581;
		public const int TAG_ProcessCode = 81;
		public const int TAG_OddLot = 575;
		public const int TAG_NoClearingInstructions = 576;
		public const int TAG_ClearingInstruction = 577;
		public const int TAG_ClearingFeeIndicator = 635;
		public const int TAG_TradeInputSource = 578;
		public const int TAG_TradeInputDevice = 579;
		public const int TAG_OrderInputDevice = 821;
		public const int TAG_Currency = 15;
		public const int TAG_ComplianceID = 376;
		public const int TAG_SolicitedFlag = 377;
		public const int TAG_OrderCapacity = 528;
		public const int TAG_OrderRestrictions = 529;
		public const int TAG_CustOrderCapacity = 582;
		public const int TAG_OrdType = 40;
		public const int TAG_ExecInst = 18;
		public const int TAG_TransBkdTime = 483;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_TimeBracket = 943;
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_CommCurrency = 479;
		public const int TAG_FundRenewWaiv = 497;
		public const int TAG_GrossTradeAmt = 381;
		public const int TAG_NumDaysInterest = 157;
		public const int TAG_ExDate = 230;
		public const int TAG_AccruedInterestRate = 158;
		public const int TAG_AccruedInterestAmt = 159;
		public const int TAG_InterestAtMaturity = 738;
		public const int TAG_EndAccruedInterestAmt = 920;
		public const int TAG_StartCash = 921;
		public const int TAG_EndCash = 922;
		public const int TAG_Concession = 238;
		public const int TAG_TotalTakedown = 237;
		public const int TAG_NetMoney = 118;
		public const int TAG_SettlCurrAmt = 119;
		public const int TAG_SettlCurrency = 120;
		public const int TAG_SettlCurrFxRate = 155;
		public const int TAG_SettlCurrFxRateCalc = 156;
		public const int TAG_PositionEffect = 77;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_SideMultiLegReportingType = 752;
		public const int TAG_NoContAmts = 518;
		public const int TAG_ContAmtType = 519;
		public const int TAG_ContAmtValue = 520;
		public const int TAG_ContAmtCurr = 521;
		public const int TAG_NoStipulations = 232;
		public const int TAG_StipulationType = 233;
		public const int TAG_StipulationValue = 234;
		public const int TAG_NoMiscFees = 136;
		public const int TAG_MiscFeeAmt = 137;
		public const int TAG_MiscFeeCurr = 138;
		public const int TAG_MiscFeeType = 139;
		public const int TAG_MiscFeeBasis = 891;
		public const int TAG_ExchangeRule = 825;
		public const int TAG_TradeAllocIndicator = 826;
		public const int TAG_PreallocMethod = 591;
		public const int TAG_AllocID = 70;
		public const int TAG_NoAllocs = 78;
		public const int TAG_AllocAccount = 79;
		public const int TAG_AllocAcctIDSource = 661;
		public const int TAG_AllocSettlCurrency = 736;
		public const int TAG_IndividualAllocID = 467;
		public const int TAG_NoNested2PartyIDs = 756;
		public const int TAG_Nested2PartyID = 757;
		public const int TAG_Nested2PartyIDSource = 758;
		public const int TAG_Nested2PartyRole = 759;
		public const int TAG_NoNested2PartySubIDs = 806;
		public const int TAG_Nested2PartySubID = 760;
		public const int TAG_Nested2PartySubIDType = 807;
		public const int TAG_AllocQty = 80;
		public const int TAG_CopyMsgIndicator = 797;
		public const int TAG_PublishTrdIndicator = 852;
		public const int TAG_ShortSaleReason = 853;

		private string _sTradeReportID;
		private int _iTradeReportTransType;
		private int _iTradeReportType;
		private string _sTradeRequestID;
		private int _iTrdType;
		private int _iTrdSubType;
		private int _iSecondaryTrdType;
		private string _sTransferReason;
		private char _cExecType;
		private int _iTotNumTradeReports;
		private bool _bLastRptRequested;
		private bool _bUnsolicitedIndicator;
		private char _cSubscriptionRequestType;
		private string _sTradeReportRefID;
		private string _sSecondaryTradeReportRefID;
		private string _sSecondaryTradeReportID;
		private string _sTradeLinkID;
		private string _sTrdMatchID;
		private string _sExecID;
		private char _cOrdStatus;
		private string _sSecondaryExecID;
		private int _iExecRestatementReason;
		private bool _bPreviouslyReported;
		private int _iPriceType;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private TradeCaptureReportSecurityAltIDList _listSecurityAltID = new TradeCaptureReportSecurityAltIDList();
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
		private TradeCaptureReportEventList _listEvent = new TradeCaptureReportEventList();
		private DateTime _dtDatedDate;
		private DateTime _dtInterestAccrualDate;
		private string _sAgreementDesc;
		private string _sAgreementID;
		private DateTime _dtAgreementDate;
		private string _sAgreementCurrency;
		private int _iTerminationType;
		private DateTime _dtStartDate;
		private DateTime _dtEndDate;
		private int _iDeliveryType;
		private double _dMarginRatio;
		private int _iOrderQty;
		private int _iCashOrderQty;
		private double _dOrderPercent;
		private char _cRoundingDirection;
		private double _dRoundingModulus;
		private int _iQtyType;
		private string _sYieldType;
		private double _dYield;
		private DateTime _dtYieldCalcDate;
		private DateTime _dtYieldRedemptionDate;
		private double _dYieldRedemptionPrice;
		private int _iYieldRedemptionPriceType;
		private int _iNoUnderlyings;
		private TradeCaptureReportUnderlyingList _listUnderlying = new TradeCaptureReportUnderlyingList();
		private string _sUnderlyingTradingSessionID;
		private string _sUnderlyingTradingSessionSubID;
		private int _iLastQty;
		private double _dLastPx;
		private double _dLastParPx;
		private double _dLastSpotRate;
		private double _dLastForwardPoints;
		private string _sLastMkt;
		private DateTime _dtTradeDate;
		private DateTime _dtClearingBusinessDate;
		private double _dAvgPx;
		private double _dSpread;
		private string _sBenchmarkCurveCurrency;
		private string _sBenchmarkCurveName;
		private string _sBenchmarkCurvePoint;
		private double _dBenchmarkPrice;
		private int _iBenchmarkPriceType;
		private string _sBenchmarkSecurityID;
		private string _sBenchmarkSecurityIDSource;
		private int _iAvgPxIndicator;
		private int _iNoPosAmt;
		private TradeCaptureReportPosAmtList _listPosAmt = new TradeCaptureReportPosAmtList();
		private char _cMultiLegReportingType;
		private string _sTradeLegRefID;
		private int _iNoLegs;
		private TradeCaptureReportLegList _listLeg = new TradeCaptureReportLegList();
		private DateTime _dtTransactTime;
		private int _iNoTrdRegTimestamps;
		private TradeCaptureReportTrdRegTimestampList _listTrdRegTimestamp = new TradeCaptureReportTrdRegTimestampList();
		private char _cSettlType;
		private DateTime _dtSettlDate;
		private char _cMatchStatus;
		private string _sMatchType;
		private int _iNoSides;
		private TradeCaptureReportSideList _listSide = new TradeCaptureReportSideList();
		private bool _bCopyMsgIndicator;
		private bool _bPublishTrdIndicator;
		private int _iShortSaleReason;

		public TradeCaptureReport() : base()
		{
			_sMsgType = Values.MsgType.TradeCaptureReport;
		}

		public string TradeReportID
		{
			get { return _sTradeReportID; }
			set { _sTradeReportID = value; }
		}
		public int TradeReportTransType
		{
			get { return _iTradeReportTransType; }
			set { _iTradeReportTransType = value; }
		}
		public int TradeReportType
		{
			get { return _iTradeReportType; }
			set { _iTradeReportType = value; }
		}
		public string TradeRequestID
		{
			get { return _sTradeRequestID; }
			set { _sTradeRequestID = value; }
		}
		public int TrdType
		{
			get { return _iTrdType; }
			set { _iTrdType = value; }
		}
		public int TrdSubType
		{
			get { return _iTrdSubType; }
			set { _iTrdSubType = value; }
		}
		public int SecondaryTrdType
		{
			get { return _iSecondaryTrdType; }
			set { _iSecondaryTrdType = value; }
		}
		public string TransferReason
		{
			get { return _sTransferReason; }
			set { _sTransferReason = value; }
		}
		public char ExecType
		{
			get { return _cExecType; }
			set { _cExecType = value; }
		}
		public int TotNumTradeReports
		{
			get { return _iTotNumTradeReports; }
			set { _iTotNumTradeReports = value; }
		}
		public bool LastRptRequested
		{
			get { return _bLastRptRequested; }
			set { _bLastRptRequested = value; }
		}
		public bool UnsolicitedIndicator
		{
			get { return _bUnsolicitedIndicator; }
			set { _bUnsolicitedIndicator = value; }
		}
		public char SubscriptionRequestType
		{
			get { return _cSubscriptionRequestType; }
			set { _cSubscriptionRequestType = value; }
		}
		public string TradeReportRefID
		{
			get { return _sTradeReportRefID; }
			set { _sTradeReportRefID = value; }
		}
		public string SecondaryTradeReportRefID
		{
			get { return _sSecondaryTradeReportRefID; }
			set { _sSecondaryTradeReportRefID = value; }
		}
		public string SecondaryTradeReportID
		{
			get { return _sSecondaryTradeReportID; }
			set { _sSecondaryTradeReportID = value; }
		}
		public string TradeLinkID
		{
			get { return _sTradeLinkID; }
			set { _sTradeLinkID = value; }
		}
		public string TrdMatchID
		{
			get { return _sTrdMatchID; }
			set { _sTrdMatchID = value; }
		}
		public string ExecID
		{
			get { return _sExecID; }
			set { _sExecID = value; }
		}
		public char OrdStatus
		{
			get { return _cOrdStatus; }
			set { _cOrdStatus = value; }
		}
		public string SecondaryExecID
		{
			get { return _sSecondaryExecID; }
			set { _sSecondaryExecID = value; }
		}
		public int ExecRestatementReason
		{
			get { return _iExecRestatementReason; }
			set { _iExecRestatementReason = value; }
		}
		public bool PreviouslyReported
		{
			get { return _bPreviouslyReported; }
			set { _bPreviouslyReported = value; }
		}
		public int PriceType
		{
			get { return _iPriceType; }
			set { _iPriceType = value; }
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
		public TradeCaptureReportSecurityAltIDList SecurityAltID 
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
		public TradeCaptureReportEventList Event 
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
		public string AgreementDesc
		{
			get { return _sAgreementDesc; }
			set { _sAgreementDesc = value; }
		}
		public string AgreementID
		{
			get { return _sAgreementID; }
			set { _sAgreementID = value; }
		}
		public DateTime AgreementDate
		{
			get { return _dtAgreementDate; }
			set { _dtAgreementDate = value; }
		}
		public string AgreementCurrency
		{
			get { return _sAgreementCurrency; }
			set { _sAgreementCurrency = value; }
		}
		public int TerminationType
		{
			get { return _iTerminationType; }
			set { _iTerminationType = value; }
		}
		public DateTime StartDate
		{
			get { return _dtStartDate; }
			set { _dtStartDate = value; }
		}
		public DateTime EndDate
		{
			get { return _dtEndDate; }
			set { _dtEndDate = value; }
		}
		public int DeliveryType
		{
			get { return _iDeliveryType; }
			set { _iDeliveryType = value; }
		}
		public double MarginRatio
		{
			get { return _dMarginRatio; }
			set { _dMarginRatio = value; }
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
		public int QtyType
		{
			get { return _iQtyType; }
			set { _iQtyType = value; }
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
		public int NoUnderlyings
		{
			get { return _iNoUnderlyings; }
			set { _iNoUnderlyings = value; }
		}
		public TradeCaptureReportUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
		}
		public string UnderlyingTradingSessionID
		{
			get { return _sUnderlyingTradingSessionID; }
			set { _sUnderlyingTradingSessionID = value; }
		}
		public string UnderlyingTradingSessionSubID
		{
			get { return _sUnderlyingTradingSessionSubID; }
			set { _sUnderlyingTradingSessionSubID = value; }
		}
		public int LastQty
		{
			get { return _iLastQty; }
			set { _iLastQty = value; }
		}
		public double LastPx
		{
			get { return _dLastPx; }
			set { _dLastPx = value; }
		}
		public double LastParPx
		{
			get { return _dLastParPx; }
			set { _dLastParPx = value; }
		}
		public double LastSpotRate
		{
			get { return _dLastSpotRate; }
			set { _dLastSpotRate = value; }
		}
		public double LastForwardPoints
		{
			get { return _dLastForwardPoints; }
			set { _dLastForwardPoints = value; }
		}
		public string LastMkt
		{
			get { return _sLastMkt; }
			set { _sLastMkt = value; }
		}
		public DateTime TradeDate
		{
			get { return _dtTradeDate; }
			set { _dtTradeDate = value; }
		}
		public DateTime ClearingBusinessDate
		{
			get { return _dtClearingBusinessDate; }
			set { _dtClearingBusinessDate = value; }
		}
		public double AvgPx
		{
			get { return _dAvgPx; }
			set { _dAvgPx = value; }
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
		public int AvgPxIndicator
		{
			get { return _iAvgPxIndicator; }
			set { _iAvgPxIndicator = value; }
		}
		public int NoPosAmt
		{
			get { return _iNoPosAmt; }
			set { _iNoPosAmt = value; }
		}
		public TradeCaptureReportPosAmtList PosAmt 
		{
			get { return _listPosAmt; }
		}
		public char MultiLegReportingType
		{
			get { return _cMultiLegReportingType; }
			set { _cMultiLegReportingType = value; }
		}
		public string TradeLegRefID
		{
			get { return _sTradeLegRefID; }
			set { _sTradeLegRefID = value; }
		}
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public TradeCaptureReportLegList Leg 
		{
			get { return _listLeg; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public int NoTrdRegTimestamps
		{
			get { return _iNoTrdRegTimestamps; }
			set { _iNoTrdRegTimestamps = value; }
		}
		public TradeCaptureReportTrdRegTimestampList TrdRegTimestamp 
		{
			get { return _listTrdRegTimestamp; }
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
		public char MatchStatus
		{
			get { return _cMatchStatus; }
			set { _cMatchStatus = value; }
		}
		public string MatchType
		{
			get { return _sMatchType; }
			set { _sMatchType = value; }
		}
		public int NoSides
		{
			get { return _iNoSides; }
			set { _iNoSides = value; }
		}
		public TradeCaptureReportSideList Side 
		{
			get { return _listSide; }
		}
		public bool CopyMsgIndicator
		{
			get { return _bCopyMsgIndicator; }
			set { _bCopyMsgIndicator = value; }
		}
		public bool PublishTrdIndicator
		{
			get { return _bPublishTrdIndicator; }
			set { _bPublishTrdIndicator = value; }
		}
		public int ShortSaleReason
		{
			get { return _iShortSaleReason; }
			set { _iShortSaleReason = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_TradeReportID:
						return _sTradeReportID;
					case TAG_TradeReportTransType:
						return _iTradeReportTransType;
					case TAG_TradeReportType:
						return _iTradeReportType;
					case TAG_TradeRequestID:
						return _sTradeRequestID;
					case TAG_TrdType:
						return _iTrdType;
					case TAG_TrdSubType:
						return _iTrdSubType;
					case TAG_SecondaryTrdType:
						return _iSecondaryTrdType;
					case TAG_TransferReason:
						return _sTransferReason;
					case TAG_ExecType:
						return _cExecType;
					case TAG_TotNumTradeReports:
						return _iTotNumTradeReports;
					case TAG_LastRptRequested:
						return _bLastRptRequested;
					case TAG_UnsolicitedIndicator:
						return _bUnsolicitedIndicator;
					case TAG_SubscriptionRequestType:
						return _cSubscriptionRequestType;
					case TAG_TradeReportRefID:
						return _sTradeReportRefID;
					case TAG_SecondaryTradeReportRefID:
						return _sSecondaryTradeReportRefID;
					case TAG_SecondaryTradeReportID:
						return _sSecondaryTradeReportID;
					case TAG_TradeLinkID:
						return _sTradeLinkID;
					case TAG_TrdMatchID:
						return _sTrdMatchID;
					case TAG_ExecID:
						return _sExecID;
					case TAG_OrdStatus:
						return _cOrdStatus;
					case TAG_SecondaryExecID:
						return _sSecondaryExecID;
					case TAG_ExecRestatementReason:
						return _iExecRestatementReason;
					case TAG_PreviouslyReported:
						return _bPreviouslyReported;
					case TAG_PriceType:
						return _iPriceType;
					case TAG_Symbol:
						return _sSymbol;
					case TAG_SymbolSfx:
						return _sSymbolSfx;
					case TAG_SecurityID:
						return _sSecurityID;
					case TAG_SecurityIDSource:
						return _sSecurityIDSource;
					case TAG_NoSecurityAltID:
						return _iNoSecurityAltID;
					case TAG_Product:
						return _iProduct;
					case TAG_CFICode:
						return _sCFICode;
					case TAG_SecurityType:
						return _sSecurityType;
					case TAG_SecuritySubType:
						return _sSecuritySubType;
					case TAG_MaturityMonthYear:
						return _dtMaturityMonthYear;
					case TAG_MaturityDate:
						return _dtMaturityDate;
					case TAG_CouponPaymentDate:
						return _dtCouponPaymentDate;
					case TAG_IssueDate:
						return _dtIssueDate;
					case TAG_RepoCollateralSecurityType:
						return _iRepoCollateralSecurityType;
					case TAG_RepurchaseTerm:
						return _iRepurchaseTerm;
					case TAG_RepurchaseRate:
						return _dRepurchaseRate;
					case TAG_Factor:
						return _dFactor;
					case TAG_CreditRating:
						return _sCreditRating;
					case TAG_InstrRegistry:
						return _sInstrRegistry;
					case TAG_CountryOfIssue:
						return _sCountryOfIssue;
					case TAG_StateOrProvinceOfIssue:
						return _sStateOrProvinceOfIssue;
					case TAG_LocaleOfIssue:
						return _sLocaleOfIssue;
					case TAG_RedemptionDate:
						return _dtRedemptionDate;
					case TAG_StrikePrice:
						return _dStrikePrice;
					case TAG_StrikeCurrency:
						return _sStrikeCurrency;
					case TAG_OptAttribute:
						return _cOptAttribute;
					case TAG_ContractMultiplier:
						return _dContractMultiplier;
					case TAG_CouponRate:
						return _dCouponRate;
					case TAG_SecurityExchange:
						return _sSecurityExchange;
					case TAG_Issuer:
						return _sIssuer;
					case TAG_EncodedIssuerLen:
						return _iEncodedIssuerLen;
					case TAG_EncodedIssuer:
						return _sEncodedIssuer;
					case TAG_SecurityDesc:
						return _sSecurityDesc;
					case TAG_EncodedSecurityDescLen:
						return _iEncodedSecurityDescLen;
					case TAG_EncodedSecurityDesc:
						return _sEncodedSecurityDesc;
					case TAG_Pool:
						return _sPool;
					case TAG_ContractSettlMonth:
						return _dtContractSettlMonth;
					case TAG_CPProgram:
						return _iCPProgram;
					case TAG_CPRegType:
						return _sCPRegType;
					case TAG_NoEvents:
						return _iNoEvents;
					case TAG_DatedDate:
						return _dtDatedDate;
					case TAG_InterestAccrualDate:
						return _dtInterestAccrualDate;
					case TAG_AgreementDesc:
						return _sAgreementDesc;
					case TAG_AgreementID:
						return _sAgreementID;
					case TAG_AgreementDate:
						return _dtAgreementDate;
					case TAG_AgreementCurrency:
						return _sAgreementCurrency;
					case TAG_TerminationType:
						return _iTerminationType;
					case TAG_StartDate:
						return _dtStartDate;
					case TAG_EndDate:
						return _dtEndDate;
					case TAG_DeliveryType:
						return _iDeliveryType;
					case TAG_MarginRatio:
						return _dMarginRatio;
					case TAG_OrderQty:
						return _iOrderQty;
					case TAG_CashOrderQty:
						return _iCashOrderQty;
					case TAG_OrderPercent:
						return _dOrderPercent;
					case TAG_RoundingDirection:
						return _cRoundingDirection;
					case TAG_RoundingModulus:
						return _dRoundingModulus;
					case TAG_QtyType:
						return _iQtyType;
					case TAG_YieldType:
						return _sYieldType;
					case TAG_Yield:
						return _dYield;
					case TAG_YieldCalcDate:
						return _dtYieldCalcDate;
					case TAG_YieldRedemptionDate:
						return _dtYieldRedemptionDate;
					case TAG_YieldRedemptionPrice:
						return _dYieldRedemptionPrice;
					case TAG_YieldRedemptionPriceType:
						return _iYieldRedemptionPriceType;
					case TAG_NoUnderlyings:
						return _iNoUnderlyings;
					case TAG_UnderlyingTradingSessionID:
						return _sUnderlyingTradingSessionID;
					case TAG_UnderlyingTradingSessionSubID:
						return _sUnderlyingTradingSessionSubID;
					case TAG_LastQty:
						return _iLastQty;
					case TAG_LastPx:
						return _dLastPx;
					case TAG_LastParPx:
						return _dLastParPx;
					case TAG_LastSpotRate:
						return _dLastSpotRate;
					case TAG_LastForwardPoints:
						return _dLastForwardPoints;
					case TAG_LastMkt:
						return _sLastMkt;
					case TAG_TradeDate:
						return _dtTradeDate;
					case TAG_ClearingBusinessDate:
						return _dtClearingBusinessDate;
					case TAG_AvgPx:
						return _dAvgPx;
					case TAG_Spread:
						return _dSpread;
					case TAG_BenchmarkCurveCurrency:
						return _sBenchmarkCurveCurrency;
					case TAG_BenchmarkCurveName:
						return _sBenchmarkCurveName;
					case TAG_BenchmarkCurvePoint:
						return _sBenchmarkCurvePoint;
					case TAG_BenchmarkPrice:
						return _dBenchmarkPrice;
					case TAG_BenchmarkPriceType:
						return _iBenchmarkPriceType;
					case TAG_BenchmarkSecurityID:
						return _sBenchmarkSecurityID;
					case TAG_BenchmarkSecurityIDSource:
						return _sBenchmarkSecurityIDSource;
					case TAG_AvgPxIndicator:
						return _iAvgPxIndicator;
					case TAG_NoPosAmt:
						return _iNoPosAmt;
					case TAG_MultiLegReportingType:
						return _cMultiLegReportingType;
					case TAG_TradeLegRefID:
						return _sTradeLegRefID;
					case TAG_NoLegs:
						return _iNoLegs;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_NoTrdRegTimestamps:
						return _iNoTrdRegTimestamps;
					case TAG_SettlType:
						return _cSettlType;
					case TAG_SettlDate:
						return _dtSettlDate;
					case TAG_MatchStatus:
						return _cMatchStatus;
					case TAG_MatchType:
						return _sMatchType;
					case TAG_NoSides:
						return _iNoSides;
					case TAG_CopyMsgIndicator:
						return _bCopyMsgIndicator;
					case TAG_PublishTrdIndicator:
						return _bPublishTrdIndicator;
					case TAG_ShortSaleReason:
						return _iShortSaleReason;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_TradeReportID:
						_sTradeReportID = (string)value;
						break;
					case TAG_TradeReportTransType:
						_iTradeReportTransType = (int)value;
						break;
					case TAG_TradeReportType:
						_iTradeReportType = (int)value;
						break;
					case TAG_TradeRequestID:
						_sTradeRequestID = (string)value;
						break;
					case TAG_TrdType:
						_iTrdType = (int)value;
						break;
					case TAG_TrdSubType:
						_iTrdSubType = (int)value;
						break;
					case TAG_SecondaryTrdType:
						_iSecondaryTrdType = (int)value;
						break;
					case TAG_TransferReason:
						_sTransferReason = (string)value;
						break;
					case TAG_ExecType:
						_cExecType = (char)value;
						break;
					case TAG_TotNumTradeReports:
						_iTotNumTradeReports = (int)value;
						break;
					case TAG_LastRptRequested:
						_bLastRptRequested = (bool)value;
						break;
					case TAG_UnsolicitedIndicator:
						_bUnsolicitedIndicator = (bool)value;
						break;
					case TAG_SubscriptionRequestType:
						_cSubscriptionRequestType = (char)value;
						break;
					case TAG_TradeReportRefID:
						_sTradeReportRefID = (string)value;
						break;
					case TAG_SecondaryTradeReportRefID:
						_sSecondaryTradeReportRefID = (string)value;
						break;
					case TAG_SecondaryTradeReportID:
						_sSecondaryTradeReportID = (string)value;
						break;
					case TAG_TradeLinkID:
						_sTradeLinkID = (string)value;
						break;
					case TAG_TrdMatchID:
						_sTrdMatchID = (string)value;
						break;
					case TAG_ExecID:
						_sExecID = (string)value;
						break;
					case TAG_OrdStatus:
						_cOrdStatus = (char)value;
						break;
					case TAG_SecondaryExecID:
						_sSecondaryExecID = (string)value;
						break;
					case TAG_ExecRestatementReason:
						_iExecRestatementReason = (int)value;
						break;
					case TAG_PreviouslyReported:
						_bPreviouslyReported = (bool)value;
						break;
					case TAG_PriceType:
						_iPriceType = (int)value;
						break;
					case TAG_Symbol:
						_sSymbol = (string)value;
						break;
					case TAG_SymbolSfx:
						_sSymbolSfx = (string)value;
						break;
					case TAG_SecurityID:
						_sSecurityID = (string)value;
						break;
					case TAG_SecurityIDSource:
						_sSecurityIDSource = (string)value;
						break;
					case TAG_NoSecurityAltID:
						_iNoSecurityAltID = (int)value;
						break;
					case TAG_Product:
						_iProduct = (int)value;
						break;
					case TAG_CFICode:
						_sCFICode = (string)value;
						break;
					case TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case TAG_SecuritySubType:
						_sSecuritySubType = (string)value;
						break;
					case TAG_MaturityMonthYear:
						_dtMaturityMonthYear = (DateTime)value;
						break;
					case TAG_MaturityDate:
						_dtMaturityDate = (DateTime)value;
						break;
					case TAG_CouponPaymentDate:
						_dtCouponPaymentDate = (DateTime)value;
						break;
					case TAG_IssueDate:
						_dtIssueDate = (DateTime)value;
						break;
					case TAG_RepoCollateralSecurityType:
						_iRepoCollateralSecurityType = (int)value;
						break;
					case TAG_RepurchaseTerm:
						_iRepurchaseTerm = (int)value;
						break;
					case TAG_RepurchaseRate:
						_dRepurchaseRate = (double)value;
						break;
					case TAG_Factor:
						_dFactor = (double)value;
						break;
					case TAG_CreditRating:
						_sCreditRating = (string)value;
						break;
					case TAG_InstrRegistry:
						_sInstrRegistry = (string)value;
						break;
					case TAG_CountryOfIssue:
						_sCountryOfIssue = (string)value;
						break;
					case TAG_StateOrProvinceOfIssue:
						_sStateOrProvinceOfIssue = (string)value;
						break;
					case TAG_LocaleOfIssue:
						_sLocaleOfIssue = (string)value;
						break;
					case TAG_RedemptionDate:
						_dtRedemptionDate = (DateTime)value;
						break;
					case TAG_StrikePrice:
						_dStrikePrice = (double)value;
						break;
					case TAG_StrikeCurrency:
						_sStrikeCurrency = (string)value;
						break;
					case TAG_OptAttribute:
						_cOptAttribute = (char)value;
						break;
					case TAG_ContractMultiplier:
						_dContractMultiplier = (double)value;
						break;
					case TAG_CouponRate:
						_dCouponRate = (double)value;
						break;
					case TAG_SecurityExchange:
						_sSecurityExchange = (string)value;
						break;
					case TAG_Issuer:
						_sIssuer = (string)value;
						break;
					case TAG_EncodedIssuerLen:
						_iEncodedIssuerLen = (int)value;
						break;
					case TAG_EncodedIssuer:
						_sEncodedIssuer = (string)value;
						break;
					case TAG_SecurityDesc:
						_sSecurityDesc = (string)value;
						break;
					case TAG_EncodedSecurityDescLen:
						_iEncodedSecurityDescLen = (int)value;
						break;
					case TAG_EncodedSecurityDesc:
						_sEncodedSecurityDesc = (string)value;
						break;
					case TAG_Pool:
						_sPool = (string)value;
						break;
					case TAG_ContractSettlMonth:
						_dtContractSettlMonth = (DateTime)value;
						break;
					case TAG_CPProgram:
						_iCPProgram = (int)value;
						break;
					case TAG_CPRegType:
						_sCPRegType = (string)value;
						break;
					case TAG_NoEvents:
						_iNoEvents = (int)value;
						break;
					case TAG_DatedDate:
						_dtDatedDate = (DateTime)value;
						break;
					case TAG_InterestAccrualDate:
						_dtInterestAccrualDate = (DateTime)value;
						break;
					case TAG_AgreementDesc:
						_sAgreementDesc = (string)value;
						break;
					case TAG_AgreementID:
						_sAgreementID = (string)value;
						break;
					case TAG_AgreementDate:
						_dtAgreementDate = (DateTime)value;
						break;
					case TAG_AgreementCurrency:
						_sAgreementCurrency = (string)value;
						break;
					case TAG_TerminationType:
						_iTerminationType = (int)value;
						break;
					case TAG_StartDate:
						_dtStartDate = (DateTime)value;
						break;
					case TAG_EndDate:
						_dtEndDate = (DateTime)value;
						break;
					case TAG_DeliveryType:
						_iDeliveryType = (int)value;
						break;
					case TAG_MarginRatio:
						_dMarginRatio = (double)value;
						break;
					case TAG_OrderQty:
						_iOrderQty = (int)value;
						break;
					case TAG_CashOrderQty:
						_iCashOrderQty = (int)value;
						break;
					case TAG_OrderPercent:
						_dOrderPercent = (double)value;
						break;
					case TAG_RoundingDirection:
						_cRoundingDirection = (char)value;
						break;
					case TAG_RoundingModulus:
						_dRoundingModulus = (double)value;
						break;
					case TAG_QtyType:
						_iQtyType = (int)value;
						break;
					case TAG_YieldType:
						_sYieldType = (string)value;
						break;
					case TAG_Yield:
						_dYield = (double)value;
						break;
					case TAG_YieldCalcDate:
						_dtYieldCalcDate = (DateTime)value;
						break;
					case TAG_YieldRedemptionDate:
						_dtYieldRedemptionDate = (DateTime)value;
						break;
					case TAG_YieldRedemptionPrice:
						_dYieldRedemptionPrice = (double)value;
						break;
					case TAG_YieldRedemptionPriceType:
						_iYieldRedemptionPriceType = (int)value;
						break;
					case TAG_NoUnderlyings:
						_iNoUnderlyings = (int)value;
						break;
					case TAG_UnderlyingTradingSessionID:
						_sUnderlyingTradingSessionID = (string)value;
						break;
					case TAG_UnderlyingTradingSessionSubID:
						_sUnderlyingTradingSessionSubID = (string)value;
						break;
					case TAG_LastQty:
						_iLastQty = (int)value;
						break;
					case TAG_LastPx:
						_dLastPx = (double)value;
						break;
					case TAG_LastParPx:
						_dLastParPx = (double)value;
						break;
					case TAG_LastSpotRate:
						_dLastSpotRate = (double)value;
						break;
					case TAG_LastForwardPoints:
						_dLastForwardPoints = (double)value;
						break;
					case TAG_LastMkt:
						_sLastMkt = (string)value;
						break;
					case TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case TAG_ClearingBusinessDate:
						_dtClearingBusinessDate = (DateTime)value;
						break;
					case TAG_AvgPx:
						_dAvgPx = (double)value;
						break;
					case TAG_Spread:
						_dSpread = (double)value;
						break;
					case TAG_BenchmarkCurveCurrency:
						_sBenchmarkCurveCurrency = (string)value;
						break;
					case TAG_BenchmarkCurveName:
						_sBenchmarkCurveName = (string)value;
						break;
					case TAG_BenchmarkCurvePoint:
						_sBenchmarkCurvePoint = (string)value;
						break;
					case TAG_BenchmarkPrice:
						_dBenchmarkPrice = (double)value;
						break;
					case TAG_BenchmarkPriceType:
						_iBenchmarkPriceType = (int)value;
						break;
					case TAG_BenchmarkSecurityID:
						_sBenchmarkSecurityID = (string)value;
						break;
					case TAG_BenchmarkSecurityIDSource:
						_sBenchmarkSecurityIDSource = (string)value;
						break;
					case TAG_AvgPxIndicator:
						_iAvgPxIndicator = (int)value;
						break;
					case TAG_NoPosAmt:
						_iNoPosAmt = (int)value;
						break;
					case TAG_MultiLegReportingType:
						_cMultiLegReportingType = (char)value;
						break;
					case TAG_TradeLegRefID:
						_sTradeLegRefID = (string)value;
						break;
					case TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_NoTrdRegTimestamps:
						_iNoTrdRegTimestamps = (int)value;
						break;
					case TAG_SettlType:
						_cSettlType = (char)value;
						break;
					case TAG_SettlDate:
						_dtSettlDate = (DateTime)value;
						break;
					case TAG_MatchStatus:
						_cMatchStatus = (char)value;
						break;
					case TAG_MatchType:
						_sMatchType = (string)value;
						break;
					case TAG_NoSides:
						_iNoSides = (int)value;
						break;
					case TAG_CopyMsgIndicator:
						_bCopyMsgIndicator = (bool)value;
						break;
					case TAG_PublishTrdIndicator:
						_bPublishTrdIndicator = (bool)value;
						break;
					case TAG_ShortSaleReason:
						_iShortSaleReason = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class TradeCaptureReportSecurityAltID
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
					case TradeCaptureReport.TAG_SecurityAltID:
						return _sSecurityAltID;
					case TradeCaptureReport.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case TradeCaptureReport.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportSecurityAltIDList
	{
		private ArrayList _al;
		private TradeCaptureReportSecurityAltID _last;

		public TradeCaptureReportSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportSecurityAltID)_al[i];
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

		public void Add(TradeCaptureReportSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportEvent
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
					case TradeCaptureReport.TAG_EventType:
						return _iEventType;
					case TradeCaptureReport.TAG_EventDate:
						return _dtEventDate;
					case TradeCaptureReport.TAG_EventPx:
						return _dEventPx;
					case TradeCaptureReport.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_EventType:
						_iEventType = (int)value;
						break;
					case TradeCaptureReport.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case TradeCaptureReport.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportEventList
	{
		private ArrayList _al;
		private TradeCaptureReportEvent _last;

		public TradeCaptureReportEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportEvent)_al[i];
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

		public void Add(TradeCaptureReportEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportEvent Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private TradeCaptureReportUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new TradeCaptureReportUnderlyingSecurityAltIDList();
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
		public TradeCaptureReportUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
					case TradeCaptureReport.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case TradeCaptureReport.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case TradeCaptureReport.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case TradeCaptureReport.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case TradeCaptureReport.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case TradeCaptureReport.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case TradeCaptureReport.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case TradeCaptureReport.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case TradeCaptureReport.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case TradeCaptureReport.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case TradeCaptureReport.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case TradeCaptureReport.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case TradeCaptureReport.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case TradeCaptureReport.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case TradeCaptureReport.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case TradeCaptureReport.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case TradeCaptureReport.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case TradeCaptureReport.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case TradeCaptureReport.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case TradeCaptureReport.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case TradeCaptureReport.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case TradeCaptureReport.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case TradeCaptureReport.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case TradeCaptureReport.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case TradeCaptureReport.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case TradeCaptureReport.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case TradeCaptureReport.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case TradeCaptureReport.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case TradeCaptureReport.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case TradeCaptureReport.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case TradeCaptureReport.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case TradeCaptureReport.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case TradeCaptureReport.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case TradeCaptureReport.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case TradeCaptureReport.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case TradeCaptureReport.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case TradeCaptureReport.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case TradeCaptureReport.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case TradeCaptureReport.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case TradeCaptureReport.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case TradeCaptureReport.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case TradeCaptureReport.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case TradeCaptureReport.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case TradeCaptureReport.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case TradeCaptureReport.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case TradeCaptureReport.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case TradeCaptureReport.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case TradeCaptureReport.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case TradeCaptureReport.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case TradeCaptureReport.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportUnderlyingList
	{
		private ArrayList _al;
		private TradeCaptureReportUnderlying _last;

		public TradeCaptureReportUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportUnderlying)_al[i];
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

		public void Add(TradeCaptureReportUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportUnderlying Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportUnderlyingSecurityAltID
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
					case TradeCaptureReport.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case TradeCaptureReport.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case TradeCaptureReport.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private TradeCaptureReportUnderlyingSecurityAltID _last;

		public TradeCaptureReportUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportUnderlyingSecurityAltID)_al[i];
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

		public void Add(TradeCaptureReportUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportPosAmt
	{
		private string _sPosAmtType;
		private double _dPosAmt;

		public string PosAmtType
		{
			get { return _sPosAmtType; }
			set { _sPosAmtType = value; }
		}
		public double PosAmt
		{
			get { return _dPosAmt; }
			set { _dPosAmt = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_PosAmtType:
						return _sPosAmtType;
					case TradeCaptureReport.TAG_PosAmt:
						return _dPosAmt;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_PosAmtType:
						_sPosAmtType = (string)value;
						break;
					case TradeCaptureReport.TAG_PosAmt:
						_dPosAmt = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportPosAmtList
	{
		private ArrayList _al;
		private TradeCaptureReportPosAmt _last;

		public TradeCaptureReportPosAmt this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportPosAmt)_al[i];
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

		public void Add(TradeCaptureReportPosAmt item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportPosAmt item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportPosAmt Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private TradeCaptureReportLegSecurityAltIDList _listLegSecurityAltID = new TradeCaptureReportLegSecurityAltIDList();
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
		private int _iLegQty;
		private int _iLegSwapType;
		private int _iNoLegStipulations;
		private TradeCaptureReportLegStipulationList _listLegStipulation = new TradeCaptureReportLegStipulationList();
		private char _cLegPositionEffect;
		private int _iLegCoveredOrUncovered;
		private int _iNoNestedPartyIDs;
		private TradeCaptureReportNestedPartyIDList _listNestedPartyID = new TradeCaptureReportNestedPartyIDList();
		private string _sLegRefID;
		private double _dLegPrice;
		private char _cLegSettlType;
		private DateTime _dtLegSettlDate;
		private double _dLegLastPx;

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
		public TradeCaptureReportLegSecurityAltIDList LegSecurityAltID 
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
		public int LegQty
		{
			get { return _iLegQty; }
			set { _iLegQty = value; }
		}
		public int LegSwapType
		{
			get { return _iLegSwapType; }
			set { _iLegSwapType = value; }
		}
		public int NoLegStipulations
		{
			get { return _iNoLegStipulations; }
			set { _iNoLegStipulations = value; }
		}
		public TradeCaptureReportLegStipulationList LegStipulation 
		{
			get { return _listLegStipulation; }
		}
		public char LegPositionEffect
		{
			get { return _cLegPositionEffect; }
			set { _cLegPositionEffect = value; }
		}
		public int LegCoveredOrUncovered
		{
			get { return _iLegCoveredOrUncovered; }
			set { _iLegCoveredOrUncovered = value; }
		}
		public int NoNestedPartyIDs
		{
			get { return _iNoNestedPartyIDs; }
			set { _iNoNestedPartyIDs = value; }
		}
		public TradeCaptureReportNestedPartyIDList NestedPartyID 
		{
			get { return _listNestedPartyID; }
		}
		public string LegRefID
		{
			get { return _sLegRefID; }
			set { _sLegRefID = value; }
		}
		public double LegPrice
		{
			get { return _dLegPrice; }
			set { _dLegPrice = value; }
		}
		public char LegSettlType
		{
			get { return _cLegSettlType; }
			set { _cLegSettlType = value; }
		}
		public DateTime LegSettlDate
		{
			get { return _dtLegSettlDate; }
			set { _dtLegSettlDate = value; }
		}
		public double LegLastPx
		{
			get { return _dLegLastPx; }
			set { _dLegLastPx = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_LegSymbol:
						return _sLegSymbol;
					case TradeCaptureReport.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case TradeCaptureReport.TAG_LegSecurityID:
						return _sLegSecurityID;
					case TradeCaptureReport.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case TradeCaptureReport.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case TradeCaptureReport.TAG_LegProduct:
						return _iLegProduct;
					case TradeCaptureReport.TAG_LegCFICode:
						return _sLegCFICode;
					case TradeCaptureReport.TAG_LegSecurityType:
						return _sLegSecurityType;
					case TradeCaptureReport.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case TradeCaptureReport.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case TradeCaptureReport.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case TradeCaptureReport.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case TradeCaptureReport.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case TradeCaptureReport.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case TradeCaptureReport.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case TradeCaptureReport.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case TradeCaptureReport.TAG_LegFactor:
						return _dLegFactor;
					case TradeCaptureReport.TAG_LegCreditRating:
						return _sLegCreditRating;
					case TradeCaptureReport.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case TradeCaptureReport.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case TradeCaptureReport.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case TradeCaptureReport.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case TradeCaptureReport.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case TradeCaptureReport.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case TradeCaptureReport.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case TradeCaptureReport.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case TradeCaptureReport.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case TradeCaptureReport.TAG_LegCouponRate:
						return _dLegCouponRate;
					case TradeCaptureReport.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case TradeCaptureReport.TAG_LegIssuer:
						return _sLegIssuer;
					case TradeCaptureReport.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case TradeCaptureReport.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case TradeCaptureReport.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case TradeCaptureReport.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case TradeCaptureReport.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case TradeCaptureReport.TAG_LegRatioQty:
						return _dLegRatioQty;
					case TradeCaptureReport.TAG_LegSide:
						return _cLegSide;
					case TradeCaptureReport.TAG_LegCurrency:
						return _sLegCurrency;
					case TradeCaptureReport.TAG_LegPool:
						return _sLegPool;
					case TradeCaptureReport.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case TradeCaptureReport.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case TradeCaptureReport.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					case TradeCaptureReport.TAG_LegQty:
						return _iLegQty;
					case TradeCaptureReport.TAG_LegSwapType:
						return _iLegSwapType;
					case TradeCaptureReport.TAG_NoLegStipulations:
						return _iNoLegStipulations;
					case TradeCaptureReport.TAG_LegPositionEffect:
						return _cLegPositionEffect;
					case TradeCaptureReport.TAG_LegCoveredOrUncovered:
						return _iLegCoveredOrUncovered;
					case TradeCaptureReport.TAG_NoNestedPartyIDs:
						return _iNoNestedPartyIDs;
					case TradeCaptureReport.TAG_LegRefID:
						return _sLegRefID;
					case TradeCaptureReport.TAG_LegPrice:
						return _dLegPrice;
					case TradeCaptureReport.TAG_LegSettlType:
						return _cLegSettlType;
					case TradeCaptureReport.TAG_LegSettlDate:
						return _dtLegSettlDate;
					case TradeCaptureReport.TAG_LegLastPx:
						return _dLegLastPx;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case TradeCaptureReport.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case TradeCaptureReport.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case TradeCaptureReport.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case TradeCaptureReport.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case TradeCaptureReport.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case TradeCaptureReport.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case TradeCaptureReport.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case TradeCaptureReport.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case TradeCaptureReport.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case TradeCaptureReport.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case TradeCaptureReport.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case TradeCaptureReport.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case TradeCaptureReport.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case TradeCaptureReport.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case TradeCaptureReport.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case TradeCaptureReport.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case TradeCaptureReport.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case TradeCaptureReport.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case TradeCaptureReport.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case TradeCaptureReport.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case TradeCaptureReport.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case TradeCaptureReport.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case TradeCaptureReport.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case TradeCaptureReport.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case TradeCaptureReport.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case TradeCaptureReport.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case TradeCaptureReport.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case TradeCaptureReport.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case TradeCaptureReport.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case TradeCaptureReport.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case TradeCaptureReport.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case TradeCaptureReport.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case TradeCaptureReport.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case TradeCaptureReport.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_LegQty:
						_iLegQty = (int)value;
						break;
					case TradeCaptureReport.TAG_LegSwapType:
						_iLegSwapType = (int)value;
						break;
					case TradeCaptureReport.TAG_NoLegStipulations:
						_iNoLegStipulations = (int)value;
						break;
					case TradeCaptureReport.TAG_LegPositionEffect:
						_cLegPositionEffect = (char)value;
						break;
					case TradeCaptureReport.TAG_LegCoveredOrUncovered:
						_iLegCoveredOrUncovered = (int)value;
						break;
					case TradeCaptureReport.TAG_NoNestedPartyIDs:
						_iNoNestedPartyIDs = (int)value;
						break;
					case TradeCaptureReport.TAG_LegRefID:
						_sLegRefID = (string)value;
						break;
					case TradeCaptureReport.TAG_LegPrice:
						_dLegPrice = (double)value;
						break;
					case TradeCaptureReport.TAG_LegSettlType:
						_cLegSettlType = (char)value;
						break;
					case TradeCaptureReport.TAG_LegSettlDate:
						_dtLegSettlDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_LegLastPx:
						_dLegLastPx = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportLegList
	{
		private ArrayList _al;
		private TradeCaptureReportLeg _last;

		public TradeCaptureReportLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportLeg)_al[i];
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

		public void Add(TradeCaptureReportLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportLeg Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportLegSecurityAltID
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
					case TradeCaptureReport.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case TradeCaptureReport.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case TradeCaptureReport.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportLegSecurityAltIDList
	{
		private ArrayList _al;
		private TradeCaptureReportLegSecurityAltID _last;

		public TradeCaptureReportLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportLegSecurityAltID)_al[i];
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

		public void Add(TradeCaptureReportLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportLegSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportLegStipulation
	{
		private string _sLegStipulationType;
		private string _sLegStipulationValue;

		public string LegStipulationType
		{
			get { return _sLegStipulationType; }
			set { _sLegStipulationType = value; }
		}
		public string LegStipulationValue
		{
			get { return _sLegStipulationValue; }
			set { _sLegStipulationValue = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_LegStipulationType:
						return _sLegStipulationType;
					case TradeCaptureReport.TAG_LegStipulationValue:
						return _sLegStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_LegStipulationType:
						_sLegStipulationType = (string)value;
						break;
					case TradeCaptureReport.TAG_LegStipulationValue:
						_sLegStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportLegStipulationList
	{
		private ArrayList _al;
		private TradeCaptureReportLegStipulation _last;

		public TradeCaptureReportLegStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportLegStipulation)_al[i];
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

		public void Add(TradeCaptureReportLegStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportLegStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportLegStipulation Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportNestedPartyID
	{
		private string _sNestedPartyID;
		private char _cNestedPartyIDSource;
		private int _iNestedPartyRole;
		private int _iNoNestedPartySubIDs;
		private TradeCaptureReportNestedPartySubIDList _listNestedPartySubID = new TradeCaptureReportNestedPartySubIDList();

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
		public TradeCaptureReportNestedPartySubIDList NestedPartySubID 
		{
			get { return _listNestedPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_NestedPartyID:
						return _sNestedPartyID;
					case TradeCaptureReport.TAG_NestedPartyIDSource:
						return _cNestedPartyIDSource;
					case TradeCaptureReport.TAG_NestedPartyRole:
						return _iNestedPartyRole;
					case TradeCaptureReport.TAG_NoNestedPartySubIDs:
						return _iNoNestedPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_NestedPartyID:
						_sNestedPartyID = (string)value;
						break;
					case TradeCaptureReport.TAG_NestedPartyIDSource:
						_cNestedPartyIDSource = (char)value;
						break;
					case TradeCaptureReport.TAG_NestedPartyRole:
						_iNestedPartyRole = (int)value;
						break;
					case TradeCaptureReport.TAG_NoNestedPartySubIDs:
						_iNoNestedPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportNestedPartyIDList
	{
		private ArrayList _al;
		private TradeCaptureReportNestedPartyID _last;

		public TradeCaptureReportNestedPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportNestedPartyID)_al[i];
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

		public void Add(TradeCaptureReportNestedPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportNestedPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportNestedPartyID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportNestedPartySubID
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
					case TradeCaptureReport.TAG_NestedPartySubID:
						return _sNestedPartySubID;
					case TradeCaptureReport.TAG_NestedPartySubIDType:
						return _iNestedPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_NestedPartySubID:
						_sNestedPartySubID = (string)value;
						break;
					case TradeCaptureReport.TAG_NestedPartySubIDType:
						_iNestedPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportNestedPartySubIDList
	{
		private ArrayList _al;
		private TradeCaptureReportNestedPartySubID _last;

		public TradeCaptureReportNestedPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportNestedPartySubID)_al[i];
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

		public void Add(TradeCaptureReportNestedPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportNestedPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportNestedPartySubID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportTrdRegTimestamp
	{
		private DateTime _dtTrdRegTimestamp;
		private int _iTrdRegTimestampType;
		private string _sTrdRegTimestampOrigin;

		public DateTime TrdRegTimestamp
		{
			get { return _dtTrdRegTimestamp; }
			set { _dtTrdRegTimestamp = value; }
		}
		public int TrdRegTimestampType
		{
			get { return _iTrdRegTimestampType; }
			set { _iTrdRegTimestampType = value; }
		}
		public string TrdRegTimestampOrigin
		{
			get { return _sTrdRegTimestampOrigin; }
			set { _sTrdRegTimestampOrigin = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_TrdRegTimestamp:
						return _dtTrdRegTimestamp;
					case TradeCaptureReport.TAG_TrdRegTimestampType:
						return _iTrdRegTimestampType;
					case TradeCaptureReport.TAG_TrdRegTimestampOrigin:
						return _sTrdRegTimestampOrigin;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_TrdRegTimestamp:
						_dtTrdRegTimestamp = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_TrdRegTimestampType:
						_iTrdRegTimestampType = (int)value;
						break;
					case TradeCaptureReport.TAG_TrdRegTimestampOrigin:
						_sTrdRegTimestampOrigin = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportTrdRegTimestampList
	{
		private ArrayList _al;
		private TradeCaptureReportTrdRegTimestamp _last;

		public TradeCaptureReportTrdRegTimestamp this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportTrdRegTimestamp)_al[i];
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

		public void Add(TradeCaptureReportTrdRegTimestamp item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportTrdRegTimestamp item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportTrdRegTimestamp Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportSide
	{
		private char _cSide;
		private string _sOrderID;
		private string _sSecondaryOrderID;
		private string _sClOrdID;
		private string _sSecondaryClOrdID;
		private string _sListID;
		private int _iNoPartyIDs;
		private TradeCaptureReportPartyIDList _listPartyID = new TradeCaptureReportPartyIDList();
		private string _sAccount;
		private int _iAcctIDSource;
		private int _iAccountType;
		private char _cProcessCode;
		private bool _bOddLot;
		private int _iNoClearingInstructions;
		private TradeCaptureReportClearingInstructionList _listClearingInstruction = new TradeCaptureReportClearingInstructionList();
		private string _sClearingFeeIndicator;
		private string _sTradeInputSource;
		private string _sTradeInputDevice;
		private string _sOrderInputDevice;
		private string _sCurrency;
		private string _sComplianceID;
		private bool _bSolicitedFlag;
		private char _cOrderCapacity;
		private string _sOrderRestrictions;
		private int _iCustOrderCapacity;
		private char _cOrdType;
		private string _sExecInst;
		private DateTime _dtTransBkdTime;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private string _sTimeBracket;
		private double _dCommission;
		private char _cCommType;
		private string _sCommCurrency;
		private char _cFundRenewWaiv;
		private double _dGrossTradeAmt;
		private int _iNumDaysInterest;
		private DateTime _dtExDate;
		private double _dAccruedInterestRate;
		private double _dAccruedInterestAmt;
		private double _dInterestAtMaturity;
		private double _dEndAccruedInterestAmt;
		private double _dStartCash;
		private double _dEndCash;
		private double _dConcession;
		private double _dTotalTakedown;
		private double _dNetMoney;
		private double _dSettlCurrAmt;
		private string _sSettlCurrency;
		private double _dSettlCurrFxRate;
		private char _cSettlCurrFxRateCalc;
		private char _cPositionEffect;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private int _iSideMultiLegReportingType;
		private int _iNoContAmts;
		private TradeCaptureReportContAmtList _listContAmt = new TradeCaptureReportContAmtList();
		private int _iNoStipulations;
		private TradeCaptureReportStipulationList _listStipulation = new TradeCaptureReportStipulationList();
		private int _iNoMiscFees;
		private TradeCaptureReportMiscFeeList _listMiscFee = new TradeCaptureReportMiscFeeList();
		private string _sExchangeRule;
		private int _iTradeAllocIndicator;
		private char _cPreallocMethod;
		private string _sAllocID;
		private int _iNoAllocs;
		private TradeCaptureReportAllocList _listAlloc = new TradeCaptureReportAllocList();

		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
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
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public TradeCaptureReportPartyIDList PartyID 
		{
			get { return _listPartyID; }
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
		public char ProcessCode
		{
			get { return _cProcessCode; }
			set { _cProcessCode = value; }
		}
		public bool OddLot
		{
			get { return _bOddLot; }
			set { _bOddLot = value; }
		}
		public int NoClearingInstructions
		{
			get { return _iNoClearingInstructions; }
			set { _iNoClearingInstructions = value; }
		}
		public TradeCaptureReportClearingInstructionList ClearingInstruction 
		{
			get { return _listClearingInstruction; }
		}
		public string ClearingFeeIndicator
		{
			get { return _sClearingFeeIndicator; }
			set { _sClearingFeeIndicator = value; }
		}
		public string TradeInputSource
		{
			get { return _sTradeInputSource; }
			set { _sTradeInputSource = value; }
		}
		public string TradeInputDevice
		{
			get { return _sTradeInputDevice; }
			set { _sTradeInputDevice = value; }
		}
		public string OrderInputDevice
		{
			get { return _sOrderInputDevice; }
			set { _sOrderInputDevice = value; }
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
		public char OrdType
		{
			get { return _cOrdType; }
			set { _cOrdType = value; }
		}
		public string ExecInst
		{
			get { return _sExecInst; }
			set { _sExecInst = value; }
		}
		public DateTime TransBkdTime
		{
			get { return _dtTransBkdTime; }
			set { _dtTransBkdTime = value; }
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
		public string TimeBracket
		{
			get { return _sTimeBracket; }
			set { _sTimeBracket = value; }
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
		public double GrossTradeAmt
		{
			get { return _dGrossTradeAmt; }
			set { _dGrossTradeAmt = value; }
		}
		public int NumDaysInterest
		{
			get { return _iNumDaysInterest; }
			set { _iNumDaysInterest = value; }
		}
		public DateTime ExDate
		{
			get { return _dtExDate; }
			set { _dtExDate = value; }
		}
		public double AccruedInterestRate
		{
			get { return _dAccruedInterestRate; }
			set { _dAccruedInterestRate = value; }
		}
		public double AccruedInterestAmt
		{
			get { return _dAccruedInterestAmt; }
			set { _dAccruedInterestAmt = value; }
		}
		public double InterestAtMaturity
		{
			get { return _dInterestAtMaturity; }
			set { _dInterestAtMaturity = value; }
		}
		public double EndAccruedInterestAmt
		{
			get { return _dEndAccruedInterestAmt; }
			set { _dEndAccruedInterestAmt = value; }
		}
		public double StartCash
		{
			get { return _dStartCash; }
			set { _dStartCash = value; }
		}
		public double EndCash
		{
			get { return _dEndCash; }
			set { _dEndCash = value; }
		}
		public double Concession
		{
			get { return _dConcession; }
			set { _dConcession = value; }
		}
		public double TotalTakedown
		{
			get { return _dTotalTakedown; }
			set { _dTotalTakedown = value; }
		}
		public double NetMoney
		{
			get { return _dNetMoney; }
			set { _dNetMoney = value; }
		}
		public double SettlCurrAmt
		{
			get { return _dSettlCurrAmt; }
			set { _dSettlCurrAmt = value; }
		}
		public string SettlCurrency
		{
			get { return _sSettlCurrency; }
			set { _sSettlCurrency = value; }
		}
		public double SettlCurrFxRate
		{
			get { return _dSettlCurrFxRate; }
			set { _dSettlCurrFxRate = value; }
		}
		public char SettlCurrFxRateCalc
		{
			get { return _cSettlCurrFxRateCalc; }
			set { _cSettlCurrFxRateCalc = value; }
		}
		public char PositionEffect
		{
			get { return _cPositionEffect; }
			set { _cPositionEffect = value; }
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
		public int SideMultiLegReportingType
		{
			get { return _iSideMultiLegReportingType; }
			set { _iSideMultiLegReportingType = value; }
		}
		public int NoContAmts
		{
			get { return _iNoContAmts; }
			set { _iNoContAmts = value; }
		}
		public TradeCaptureReportContAmtList ContAmt 
		{
			get { return _listContAmt; }
		}
		public int NoStipulations
		{
			get { return _iNoStipulations; }
			set { _iNoStipulations = value; }
		}
		public TradeCaptureReportStipulationList Stipulation 
		{
			get { return _listStipulation; }
		}
		public int NoMiscFees
		{
			get { return _iNoMiscFees; }
			set { _iNoMiscFees = value; }
		}
		public TradeCaptureReportMiscFeeList MiscFee 
		{
			get { return _listMiscFee; }
		}
		public string ExchangeRule
		{
			get { return _sExchangeRule; }
			set { _sExchangeRule = value; }
		}
		public int TradeAllocIndicator
		{
			get { return _iTradeAllocIndicator; }
			set { _iTradeAllocIndicator = value; }
		}
		public char PreallocMethod
		{
			get { return _cPreallocMethod; }
			set { _cPreallocMethod = value; }
		}
		public string AllocID
		{
			get { return _sAllocID; }
			set { _sAllocID = value; }
		}
		public int NoAllocs
		{
			get { return _iNoAllocs; }
			set { _iNoAllocs = value; }
		}
		public TradeCaptureReportAllocList Alloc 
		{
			get { return _listAlloc; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_Side:
						return _cSide;
					case TradeCaptureReport.TAG_OrderID:
						return _sOrderID;
					case TradeCaptureReport.TAG_SecondaryOrderID:
						return _sSecondaryOrderID;
					case TradeCaptureReport.TAG_ClOrdID:
						return _sClOrdID;
					case TradeCaptureReport.TAG_SecondaryClOrdID:
						return _sSecondaryClOrdID;
					case TradeCaptureReport.TAG_ListID:
						return _sListID;
					case TradeCaptureReport.TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case TradeCaptureReport.TAG_Account:
						return _sAccount;
					case TradeCaptureReport.TAG_AcctIDSource:
						return _iAcctIDSource;
					case TradeCaptureReport.TAG_AccountType:
						return _iAccountType;
					case TradeCaptureReport.TAG_ProcessCode:
						return _cProcessCode;
					case TradeCaptureReport.TAG_OddLot:
						return _bOddLot;
					case TradeCaptureReport.TAG_NoClearingInstructions:
						return _iNoClearingInstructions;
					case TradeCaptureReport.TAG_ClearingFeeIndicator:
						return _sClearingFeeIndicator;
					case TradeCaptureReport.TAG_TradeInputSource:
						return _sTradeInputSource;
					case TradeCaptureReport.TAG_TradeInputDevice:
						return _sTradeInputDevice;
					case TradeCaptureReport.TAG_OrderInputDevice:
						return _sOrderInputDevice;
					case TradeCaptureReport.TAG_Currency:
						return _sCurrency;
					case TradeCaptureReport.TAG_ComplianceID:
						return _sComplianceID;
					case TradeCaptureReport.TAG_SolicitedFlag:
						return _bSolicitedFlag;
					case TradeCaptureReport.TAG_OrderCapacity:
						return _cOrderCapacity;
					case TradeCaptureReport.TAG_OrderRestrictions:
						return _sOrderRestrictions;
					case TradeCaptureReport.TAG_CustOrderCapacity:
						return _iCustOrderCapacity;
					case TradeCaptureReport.TAG_OrdType:
						return _cOrdType;
					case TradeCaptureReport.TAG_ExecInst:
						return _sExecInst;
					case TradeCaptureReport.TAG_TransBkdTime:
						return _dtTransBkdTime;
					case TradeCaptureReport.TAG_TradingSessionID:
						return _sTradingSessionID;
					case TradeCaptureReport.TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case TradeCaptureReport.TAG_TimeBracket:
						return _sTimeBracket;
					case TradeCaptureReport.TAG_Commission:
						return _dCommission;
					case TradeCaptureReport.TAG_CommType:
						return _cCommType;
					case TradeCaptureReport.TAG_CommCurrency:
						return _sCommCurrency;
					case TradeCaptureReport.TAG_FundRenewWaiv:
						return _cFundRenewWaiv;
					case TradeCaptureReport.TAG_GrossTradeAmt:
						return _dGrossTradeAmt;
					case TradeCaptureReport.TAG_NumDaysInterest:
						return _iNumDaysInterest;
					case TradeCaptureReport.TAG_ExDate:
						return _dtExDate;
					case TradeCaptureReport.TAG_AccruedInterestRate:
						return _dAccruedInterestRate;
					case TradeCaptureReport.TAG_AccruedInterestAmt:
						return _dAccruedInterestAmt;
					case TradeCaptureReport.TAG_InterestAtMaturity:
						return _dInterestAtMaturity;
					case TradeCaptureReport.TAG_EndAccruedInterestAmt:
						return _dEndAccruedInterestAmt;
					case TradeCaptureReport.TAG_StartCash:
						return _dStartCash;
					case TradeCaptureReport.TAG_EndCash:
						return _dEndCash;
					case TradeCaptureReport.TAG_Concession:
						return _dConcession;
					case TradeCaptureReport.TAG_TotalTakedown:
						return _dTotalTakedown;
					case TradeCaptureReport.TAG_NetMoney:
						return _dNetMoney;
					case TradeCaptureReport.TAG_SettlCurrAmt:
						return _dSettlCurrAmt;
					case TradeCaptureReport.TAG_SettlCurrency:
						return _sSettlCurrency;
					case TradeCaptureReport.TAG_SettlCurrFxRate:
						return _dSettlCurrFxRate;
					case TradeCaptureReport.TAG_SettlCurrFxRateCalc:
						return _cSettlCurrFxRateCalc;
					case TradeCaptureReport.TAG_PositionEffect:
						return _cPositionEffect;
					case TradeCaptureReport.TAG_Text:
						return _sText;
					case TradeCaptureReport.TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TradeCaptureReport.TAG_EncodedText:
						return _sEncodedText;
					case TradeCaptureReport.TAG_SideMultiLegReportingType:
						return _iSideMultiLegReportingType;
					case TradeCaptureReport.TAG_NoContAmts:
						return _iNoContAmts;
					case TradeCaptureReport.TAG_NoStipulations:
						return _iNoStipulations;
					case TradeCaptureReport.TAG_NoMiscFees:
						return _iNoMiscFees;
					case TradeCaptureReport.TAG_ExchangeRule:
						return _sExchangeRule;
					case TradeCaptureReport.TAG_TradeAllocIndicator:
						return _iTradeAllocIndicator;
					case TradeCaptureReport.TAG_PreallocMethod:
						return _cPreallocMethod;
					case TradeCaptureReport.TAG_AllocID:
						return _sAllocID;
					case TradeCaptureReport.TAG_NoAllocs:
						return _iNoAllocs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_Side:
						_cSide = (char)value;
						break;
					case TradeCaptureReport.TAG_OrderID:
						_sOrderID = (string)value;
						break;
					case TradeCaptureReport.TAG_SecondaryOrderID:
						_sSecondaryOrderID = (string)value;
						break;
					case TradeCaptureReport.TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case TradeCaptureReport.TAG_SecondaryClOrdID:
						_sSecondaryClOrdID = (string)value;
						break;
					case TradeCaptureReport.TAG_ListID:
						_sListID = (string)value;
						break;
					case TradeCaptureReport.TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case TradeCaptureReport.TAG_Account:
						_sAccount = (string)value;
						break;
					case TradeCaptureReport.TAG_AcctIDSource:
						_iAcctIDSource = (int)value;
						break;
					case TradeCaptureReport.TAG_AccountType:
						_iAccountType = (int)value;
						break;
					case TradeCaptureReport.TAG_ProcessCode:
						_cProcessCode = (char)value;
						break;
					case TradeCaptureReport.TAG_OddLot:
						_bOddLot = (bool)value;
						break;
					case TradeCaptureReport.TAG_NoClearingInstructions:
						_iNoClearingInstructions = (int)value;
						break;
					case TradeCaptureReport.TAG_ClearingFeeIndicator:
						_sClearingFeeIndicator = (string)value;
						break;
					case TradeCaptureReport.TAG_TradeInputSource:
						_sTradeInputSource = (string)value;
						break;
					case TradeCaptureReport.TAG_TradeInputDevice:
						_sTradeInputDevice = (string)value;
						break;
					case TradeCaptureReport.TAG_OrderInputDevice:
						_sOrderInputDevice = (string)value;
						break;
					case TradeCaptureReport.TAG_Currency:
						_sCurrency = (string)value;
						break;
					case TradeCaptureReport.TAG_ComplianceID:
						_sComplianceID = (string)value;
						break;
					case TradeCaptureReport.TAG_SolicitedFlag:
						_bSolicitedFlag = (bool)value;
						break;
					case TradeCaptureReport.TAG_OrderCapacity:
						_cOrderCapacity = (char)value;
						break;
					case TradeCaptureReport.TAG_OrderRestrictions:
						_sOrderRestrictions = (string)value;
						break;
					case TradeCaptureReport.TAG_CustOrderCapacity:
						_iCustOrderCapacity = (int)value;
						break;
					case TradeCaptureReport.TAG_OrdType:
						_cOrdType = (char)value;
						break;
					case TradeCaptureReport.TAG_ExecInst:
						_sExecInst = (string)value;
						break;
					case TradeCaptureReport.TAG_TransBkdTime:
						_dtTransBkdTime = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case TradeCaptureReport.TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case TradeCaptureReport.TAG_TimeBracket:
						_sTimeBracket = (string)value;
						break;
					case TradeCaptureReport.TAG_Commission:
						_dCommission = (double)value;
						break;
					case TradeCaptureReport.TAG_CommType:
						_cCommType = (char)value;
						break;
					case TradeCaptureReport.TAG_CommCurrency:
						_sCommCurrency = (string)value;
						break;
					case TradeCaptureReport.TAG_FundRenewWaiv:
						_cFundRenewWaiv = (char)value;
						break;
					case TradeCaptureReport.TAG_GrossTradeAmt:
						_dGrossTradeAmt = (double)value;
						break;
					case TradeCaptureReport.TAG_NumDaysInterest:
						_iNumDaysInterest = (int)value;
						break;
					case TradeCaptureReport.TAG_ExDate:
						_dtExDate = (DateTime)value;
						break;
					case TradeCaptureReport.TAG_AccruedInterestRate:
						_dAccruedInterestRate = (double)value;
						break;
					case TradeCaptureReport.TAG_AccruedInterestAmt:
						_dAccruedInterestAmt = (double)value;
						break;
					case TradeCaptureReport.TAG_InterestAtMaturity:
						_dInterestAtMaturity = (double)value;
						break;
					case TradeCaptureReport.TAG_EndAccruedInterestAmt:
						_dEndAccruedInterestAmt = (double)value;
						break;
					case TradeCaptureReport.TAG_StartCash:
						_dStartCash = (double)value;
						break;
					case TradeCaptureReport.TAG_EndCash:
						_dEndCash = (double)value;
						break;
					case TradeCaptureReport.TAG_Concession:
						_dConcession = (double)value;
						break;
					case TradeCaptureReport.TAG_TotalTakedown:
						_dTotalTakedown = (double)value;
						break;
					case TradeCaptureReport.TAG_NetMoney:
						_dNetMoney = (double)value;
						break;
					case TradeCaptureReport.TAG_SettlCurrAmt:
						_dSettlCurrAmt = (double)value;
						break;
					case TradeCaptureReport.TAG_SettlCurrency:
						_sSettlCurrency = (string)value;
						break;
					case TradeCaptureReport.TAG_SettlCurrFxRate:
						_dSettlCurrFxRate = (double)value;
						break;
					case TradeCaptureReport.TAG_SettlCurrFxRateCalc:
						_cSettlCurrFxRateCalc = (char)value;
						break;
					case TradeCaptureReport.TAG_PositionEffect:
						_cPositionEffect = (char)value;
						break;
					case TradeCaptureReport.TAG_Text:
						_sText = (string)value;
						break;
					case TradeCaptureReport.TAG_EncodedTextLen:
						_iEncodedTextLen = (int)value;
						break;
					case TradeCaptureReport.TAG_EncodedText:
						_sEncodedText = (string)value;
						break;
					case TradeCaptureReport.TAG_SideMultiLegReportingType:
						_iSideMultiLegReportingType = (int)value;
						break;
					case TradeCaptureReport.TAG_NoContAmts:
						_iNoContAmts = (int)value;
						break;
					case TradeCaptureReport.TAG_NoStipulations:
						_iNoStipulations = (int)value;
						break;
					case TradeCaptureReport.TAG_NoMiscFees:
						_iNoMiscFees = (int)value;
						break;
					case TradeCaptureReport.TAG_ExchangeRule:
						_sExchangeRule = (string)value;
						break;
					case TradeCaptureReport.TAG_TradeAllocIndicator:
						_iTradeAllocIndicator = (int)value;
						break;
					case TradeCaptureReport.TAG_PreallocMethod:
						_cPreallocMethod = (char)value;
						break;
					case TradeCaptureReport.TAG_AllocID:
						_sAllocID = (string)value;
						break;
					case TradeCaptureReport.TAG_NoAllocs:
						_iNoAllocs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportSideList
	{
		private ArrayList _al;
		private TradeCaptureReportSide _last;

		public TradeCaptureReportSide this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportSide)_al[i];
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

		public void Add(TradeCaptureReportSide item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportSide item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportSide Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private TradeCaptureReportPartySubIDList _listPartySubID = new TradeCaptureReportPartySubIDList();

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
		public TradeCaptureReportPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_PartyID:
						return _sPartyID;
					case TradeCaptureReport.TAG_PartyIDSource:
						return _cPartyIDSource;
					case TradeCaptureReport.TAG_PartyRole:
						return _iPartyRole;
					case TradeCaptureReport.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case TradeCaptureReport.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case TradeCaptureReport.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case TradeCaptureReport.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportPartyIDList
	{
		private ArrayList _al;
		private TradeCaptureReportPartyID _last;

		public TradeCaptureReportPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportPartyID)_al[i];
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

		public void Add(TradeCaptureReportPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportPartyID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportPartySubID
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
					case TradeCaptureReport.TAG_PartySubID:
						return _sPartySubID;
					case TradeCaptureReport.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case TradeCaptureReport.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportPartySubIDList
	{
		private ArrayList _al;
		private TradeCaptureReportPartySubID _last;

		public TradeCaptureReportPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportPartySubID)_al[i];
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

		public void Add(TradeCaptureReportPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportPartySubID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportClearingInstruction
	{
		private int _iClearingInstruction;

		public int ClearingInstruction
		{
			get { return _iClearingInstruction; }
			set { _iClearingInstruction = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_ClearingInstruction:
						return _iClearingInstruction;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_ClearingInstruction:
						_iClearingInstruction = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportClearingInstructionList
	{
		private ArrayList _al;
		private TradeCaptureReportClearingInstruction _last;

		public TradeCaptureReportClearingInstruction this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportClearingInstruction)_al[i];
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

		public void Add(TradeCaptureReportClearingInstruction item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportClearingInstruction item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportClearingInstruction Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportContAmt
	{
		private int _iContAmtType;
		private double _dContAmtValue;
		private string _sContAmtCurr;

		public int ContAmtType
		{
			get { return _iContAmtType; }
			set { _iContAmtType = value; }
		}
		public double ContAmtValue
		{
			get { return _dContAmtValue; }
			set { _dContAmtValue = value; }
		}
		public string ContAmtCurr
		{
			get { return _sContAmtCurr; }
			set { _sContAmtCurr = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_ContAmtType:
						return _iContAmtType;
					case TradeCaptureReport.TAG_ContAmtValue:
						return _dContAmtValue;
					case TradeCaptureReport.TAG_ContAmtCurr:
						return _sContAmtCurr;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_ContAmtType:
						_iContAmtType = (int)value;
						break;
					case TradeCaptureReport.TAG_ContAmtValue:
						_dContAmtValue = (double)value;
						break;
					case TradeCaptureReport.TAG_ContAmtCurr:
						_sContAmtCurr = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportContAmtList
	{
		private ArrayList _al;
		private TradeCaptureReportContAmt _last;

		public TradeCaptureReportContAmt this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportContAmt)_al[i];
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

		public void Add(TradeCaptureReportContAmt item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportContAmt item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportContAmt Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportStipulation
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
					case TradeCaptureReport.TAG_StipulationType:
						return _sStipulationType;
					case TradeCaptureReport.TAG_StipulationValue:
						return _sStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_StipulationType:
						_sStipulationType = (string)value;
						break;
					case TradeCaptureReport.TAG_StipulationValue:
						_sStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportStipulationList
	{
		private ArrayList _al;
		private TradeCaptureReportStipulation _last;

		public TradeCaptureReportStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportStipulation)_al[i];
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

		public void Add(TradeCaptureReportStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportStipulation Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportMiscFee
	{
		private double _dMiscFeeAmt;
		private string _sMiscFeeCurr;
		private char _cMiscFeeType;
		private int _iMiscFeeBasis;

		public double MiscFeeAmt
		{
			get { return _dMiscFeeAmt; }
			set { _dMiscFeeAmt = value; }
		}
		public string MiscFeeCurr
		{
			get { return _sMiscFeeCurr; }
			set { _sMiscFeeCurr = value; }
		}
		public char MiscFeeType
		{
			get { return _cMiscFeeType; }
			set { _cMiscFeeType = value; }
		}
		public int MiscFeeBasis
		{
			get { return _iMiscFeeBasis; }
			set { _iMiscFeeBasis = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_MiscFeeAmt:
						return _dMiscFeeAmt;
					case TradeCaptureReport.TAG_MiscFeeCurr:
						return _sMiscFeeCurr;
					case TradeCaptureReport.TAG_MiscFeeType:
						return _cMiscFeeType;
					case TradeCaptureReport.TAG_MiscFeeBasis:
						return _iMiscFeeBasis;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_MiscFeeAmt:
						_dMiscFeeAmt = (double)value;
						break;
					case TradeCaptureReport.TAG_MiscFeeCurr:
						_sMiscFeeCurr = (string)value;
						break;
					case TradeCaptureReport.TAG_MiscFeeType:
						_cMiscFeeType = (char)value;
						break;
					case TradeCaptureReport.TAG_MiscFeeBasis:
						_iMiscFeeBasis = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportMiscFeeList
	{
		private ArrayList _al;
		private TradeCaptureReportMiscFee _last;

		public TradeCaptureReportMiscFee this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportMiscFee)_al[i];
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

		public void Add(TradeCaptureReportMiscFee item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportMiscFee item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportMiscFee Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAlloc
	{
		private string _sAllocAccount;
		private int _iAllocAcctIDSource;
		private string _sAllocSettlCurrency;
		private string _sIndividualAllocID;
		private int _iNoNested2PartyIDs;
		private TradeCaptureReportNested2PartyIDList _listNested2PartyID = new TradeCaptureReportNested2PartyIDList();
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
		public int NoNested2PartyIDs
		{
			get { return _iNoNested2PartyIDs; }
			set { _iNoNested2PartyIDs = value; }
		}
		public TradeCaptureReportNested2PartyIDList Nested2PartyID 
		{
			get { return _listNested2PartyID; }
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
					case TradeCaptureReport.TAG_AllocAccount:
						return _sAllocAccount;
					case TradeCaptureReport.TAG_AllocAcctIDSource:
						return _iAllocAcctIDSource;
					case TradeCaptureReport.TAG_AllocSettlCurrency:
						return _sAllocSettlCurrency;
					case TradeCaptureReport.TAG_IndividualAllocID:
						return _sIndividualAllocID;
					case TradeCaptureReport.TAG_NoNested2PartyIDs:
						return _iNoNested2PartyIDs;
					case TradeCaptureReport.TAG_AllocQty:
						return _iAllocQty;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_AllocAccount:
						_sAllocAccount = (string)value;
						break;
					case TradeCaptureReport.TAG_AllocAcctIDSource:
						_iAllocAcctIDSource = (int)value;
						break;
					case TradeCaptureReport.TAG_AllocSettlCurrency:
						_sAllocSettlCurrency = (string)value;
						break;
					case TradeCaptureReport.TAG_IndividualAllocID:
						_sIndividualAllocID = (string)value;
						break;
					case TradeCaptureReport.TAG_NoNested2PartyIDs:
						_iNoNested2PartyIDs = (int)value;
						break;
					case TradeCaptureReport.TAG_AllocQty:
						_iAllocQty = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAllocList
	{
		private ArrayList _al;
		private TradeCaptureReportAlloc _last;

		public TradeCaptureReportAlloc this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAlloc)_al[i];
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

		public void Add(TradeCaptureReportAlloc item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAlloc item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAlloc Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportNested2PartyID
	{
		private string _sNested2PartyID;
		private char _cNested2PartyIDSource;
		private int _iNested2PartyRole;
		private int _iNoNested2PartySubIDs;
		private TradeCaptureReportNested2PartySubIDList _listNested2PartySubID = new TradeCaptureReportNested2PartySubIDList();

		public string Nested2PartyID
		{
			get { return _sNested2PartyID; }
			set { _sNested2PartyID = value; }
		}
		public char Nested2PartyIDSource
		{
			get { return _cNested2PartyIDSource; }
			set { _cNested2PartyIDSource = value; }
		}
		public int Nested2PartyRole
		{
			get { return _iNested2PartyRole; }
			set { _iNested2PartyRole = value; }
		}
		public int NoNested2PartySubIDs
		{
			get { return _iNoNested2PartySubIDs; }
			set { _iNoNested2PartySubIDs = value; }
		}
		public TradeCaptureReportNested2PartySubIDList Nested2PartySubID 
		{
			get { return _listNested2PartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_Nested2PartyID:
						return _sNested2PartyID;
					case TradeCaptureReport.TAG_Nested2PartyIDSource:
						return _cNested2PartyIDSource;
					case TradeCaptureReport.TAG_Nested2PartyRole:
						return _iNested2PartyRole;
					case TradeCaptureReport.TAG_NoNested2PartySubIDs:
						return _iNoNested2PartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_Nested2PartyID:
						_sNested2PartyID = (string)value;
						break;
					case TradeCaptureReport.TAG_Nested2PartyIDSource:
						_cNested2PartyIDSource = (char)value;
						break;
					case TradeCaptureReport.TAG_Nested2PartyRole:
						_iNested2PartyRole = (int)value;
						break;
					case TradeCaptureReport.TAG_NoNested2PartySubIDs:
						_iNoNested2PartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportNested2PartyIDList
	{
		private ArrayList _al;
		private TradeCaptureReportNested2PartyID _last;

		public TradeCaptureReportNested2PartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportNested2PartyID)_al[i];
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

		public void Add(TradeCaptureReportNested2PartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportNested2PartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportNested2PartyID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportNested2PartySubID
	{
		private string _sNested2PartySubID;
		private int _iNested2PartySubIDType;

		public string Nested2PartySubID
		{
			get { return _sNested2PartySubID; }
			set { _sNested2PartySubID = value; }
		}
		public int Nested2PartySubIDType
		{
			get { return _iNested2PartySubIDType; }
			set { _iNested2PartySubIDType = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_Nested2PartySubID:
						return _sNested2PartySubID;
					case TradeCaptureReport.TAG_Nested2PartySubIDType:
						return _iNested2PartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReport.TAG_Nested2PartySubID:
						_sNested2PartySubID = (string)value;
						break;
					case TradeCaptureReport.TAG_Nested2PartySubIDType:
						_iNested2PartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportNested2PartySubIDList
	{
		private ArrayList _al;
		private TradeCaptureReportNested2PartySubID _last;

		public TradeCaptureReportNested2PartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportNested2PartySubID)_al[i];
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

		public void Add(TradeCaptureReportNested2PartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportNested2PartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportNested2PartySubID Last
		{
			get { return _last; }
		}
	}
}
