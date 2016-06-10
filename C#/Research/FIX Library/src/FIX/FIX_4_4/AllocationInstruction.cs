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
	/// Summary description for AllocationInstruction.
	/// </summary>
	public class AllocationInstruction : Message
	{
		public const int TAG_AllocID = 70;
		public const int TAG_AllocTransType = 71;
		public const int TAG_AllocType = 626;
		public const int TAG_SecondaryAllocID = 793;
		public const int TAG_RefAllocID = 72;
		public const int TAG_AllocCancReplaceReason = 796;
		public const int TAG_AllocIntermedReqType = 808;
		public const int TAG_AllocLinkID = 196;
		public const int TAG_AllocLinkType = 197;
		public const int TAG_BookingRefID = 466;
		public const int TAG_AllocNoOrdersType = 857;
		public const int TAG_NoOrders = 73;
		public const int TAG_ClOrdID = 11;
		public const int TAG_OrderID = 37;
		public const int TAG_SecondaryOrderID = 198;
		public const int TAG_SecondaryClOrdID = 526;
		public const int TAG_ListID = 66;
		public const int TAG_NoNested2PartyIDs = 756;
		public const int TAG_Nested2PartyID = 757;
		public const int TAG_Nested2PartyIDSource = 758;
		public const int TAG_Nested2PartyRole = 759;
		public const int TAG_NoNested2PartySubIDs = 806;
		public const int TAG_Nested2PartySubID = 760;
		public const int TAG_Nested2PartySubIDType = 807;
		public const int TAG_OrderQty = 38;
		public const int TAG_OrderAvgPx = 799;
		public const int TAG_OrderBookingQty = 800;
		public const int TAG_NoExecs = 124;
		public const int TAG_LastQty = 32;
		public const int TAG_ExecID = 17;
		public const int TAG_SecondaryExecID = 527;
		public const int TAG_LastPx = 31;
		public const int TAG_LastParPx = 669;
		public const int TAG_LastCapacity = 29;
		public const int TAG_PreviouslyReported = 570;
		public const int TAG_ReversalIndicator = 700;
		public const int TAG_MatchType = 574;
		public const int TAG_Side = 54;
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
		public const int TAG_DeliveryForm = 668;
		public const int TAG_PctAtRisk = 869;
		public const int TAG_NoInstrAttrib = 870;
		public const int TAG_InstrAttribType = 871;
		public const int TAG_InstrAttribValue = 872;
		public const int TAG_AgreementDesc = 913;
		public const int TAG_AgreementID = 914;
		public const int TAG_AgreementDate = 915;
		public const int TAG_AgreementCurrency = 918;
		public const int TAG_TerminationType = 788;
		public const int TAG_StartDate = 916;
		public const int TAG_EndDate = 917;
		public const int TAG_DeliveryType = 919;
		public const int TAG_MarginRatio = 898;
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
		public const int TAG_Quantity = 53;
		public const int TAG_QtyType = 854;
		public const int TAG_LastMkt = 30;
		public const int TAG_TradeOriginationDate = 229;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_PriceType = 423;
		public const int TAG_AvgPx = 6;
		public const int TAG_AvgParPx = 860;
		public const int TAG_Spread = 218;
		public const int TAG_BenchmarkCurveCurrency = 220;
		public const int TAG_BenchmarkCurveName = 221;
		public const int TAG_BenchmarkCurvePoint = 222;
		public const int TAG_BenchmarkPrice = 662;
		public const int TAG_BenchmarkPriceType = 663;
		public const int TAG_BenchmarkSecurityID = 699;
		public const int TAG_BenchmarkSecurityIDSource = 761;
		public const int TAG_Currency = 15;
		public const int TAG_AvgPxPrecision = 74;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_TradeDate = 75;
		public const int TAG_TransactTime = 60;
		public const int TAG_SettlType = 63;
		public const int TAG_SettlDate = 64;
		public const int TAG_BookingType = 775;
		public const int TAG_GrossTradeAmt = 381;
		public const int TAG_Concession = 238;
		public const int TAG_TotalTakedown = 237;
		public const int TAG_NetMoney = 118;
		public const int TAG_PositionEffect = 77;
		public const int TAG_AutoAcceptIndicator = 754;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_NumDaysInterest = 157;
		public const int TAG_AccruedInterestRate = 158;
		public const int TAG_AccruedInterestAmt = 159;
		public const int TAG_TotalAccruedInterestAmt = 540;
		public const int TAG_InterestAtMaturity = 738;
		public const int TAG_EndAccruedInterestAmt = 920;
		public const int TAG_StartCash = 921;
		public const int TAG_EndCash = 922;
		public const int TAG_LegalConfirm = 650;
		public const int TAG_NoStipulations = 232;
		public const int TAG_StipulationType = 233;
		public const int TAG_StipulationValue = 234;
		public const int TAG_YieldType = 235;
		public const int TAG_Yield = 236;
		public const int TAG_YieldCalcDate = 701;
		public const int TAG_YieldRedemptionDate = 696;
		public const int TAG_YieldRedemptionPrice = 697;
		public const int TAG_YieldRedemptionPriceType = 698;
		public const int TAG_TotNoAllocs = 892;
		public const int TAG_LastFragment = 893;
		public const int TAG_NoAllocs = 78;
		public const int TAG_AllocAccount = 79;
		public const int TAG_AllocAcctIDSource = 661;
		public const int TAG_MatchStatus = 573;
		public const int TAG_AllocPrice = 366;
		public const int TAG_AllocQty = 80;
		public const int TAG_IndividualAllocID = 467;
		public const int TAG_ProcessCode = 81;
		public const int TAG_NoNestedPartyIDs = 539;
		public const int TAG_NestedPartyID = 524;
		public const int TAG_NestedPartyIDSource = 525;
		public const int TAG_NestedPartyRole = 538;
		public const int TAG_NoNestedPartySubIDs = 804;
		public const int TAG_NestedPartySubID = 545;
		public const int TAG_NestedPartySubIDType = 805;
		public const int TAG_NotifyBrokerOfCredit = 208;
		public const int TAG_AllocHandlInst = 209;
		public const int TAG_AllocText = 161;
		public const int TAG_EncodedAllocTextLen = 360;
		public const int TAG_EncodedAllocText = 361;
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_CommCurrency = 479;
		public const int TAG_FundRenewWaiv = 497;
		public const int TAG_AllocAvgPx = 153;
		public const int TAG_AllocNetMoney = 154;
		public const int TAG_SettlCurrAmt = 119;
		public const int TAG_AllocSettlCurrAmt = 737;
		public const int TAG_SettlCurrency = 120;
		public const int TAG_AllocSettlCurrency = 736;
		public const int TAG_SettlCurrFxRate = 155;
		public const int TAG_SettlCurrFxRateCalc = 156;
		public const int TAG_AllocAccruedInterestAmt = 742;
		public const int TAG_AllocInterestAtMaturity = 741;
		public const int TAG_SettlInstMode = 160;
		public const int TAG_NoMiscFees = 136;
		public const int TAG_MiscFeeAmt = 137;
		public const int TAG_MiscFeeCurr = 138;
		public const int TAG_MiscFeeType = 139;
		public const int TAG_MiscFeeBasis = 891;
		public const int TAG_NoClearingInstructions = 576;
		public const int TAG_ClearingInstruction = 577;
		public const int TAG_ClearingFeeIndicator = 635;
		public const int TAG_AllocSettlInstType = 780;
		public const int TAG_SettlDeliveryType = 172;
		public const int TAG_StandInstDbType = 169;
		public const int TAG_StandInstDbName = 170;
		public const int TAG_StandInstDbID = 171;
		public const int TAG_NoDlvyInst = 85;
		public const int TAG_SettlInstSource = 165;
		public const int TAG_DlvyInstType = 787;
		public const int TAG_NoSettlPartyIDs = 781;
		public const int TAG_SettlPartyID = 782;
		public const int TAG_SettlPartyIDSource = 783;
		public const int TAG_SettlPartyRole = 784;
		public const int TAG_NoSettlPartySubIDs = 801;
		public const int TAG_SettlPartySubID = 785;
		public const int TAG_SettlPartySubIDType = 786;

		private string _sAllocID;
		private char _cAllocTransType;
		private int _iAllocType;
		private string _sSecondaryAllocID;
		private string _sRefAllocID;
		private int _iAllocCancReplaceReason;
		private int _iAllocIntermedReqType;
		private string _sAllocLinkID;
		private int _iAllocLinkType;
		private string _sBookingRefID;
		private int _iAllocNoOrdersType;
		private int _iNoOrders;
		private AllocationInstructionOrderList _listOrder = new AllocationInstructionOrderList();
		private int _iNoExecs;
		private AllocationInstructionExecList _listExec = new AllocationInstructionExecList();
		private bool _bPreviouslyReported;
		private bool _bReversalIndicator;
		private string _sMatchType;
		private char _cSide;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private AllocationInstructionSecurityAltIDList _listSecurityAltID = new AllocationInstructionSecurityAltIDList();
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
		private AllocationInstructionEventList _listEvent = new AllocationInstructionEventList();
		private DateTime _dtDatedDate;
		private DateTime _dtInterestAccrualDate;
		private int _iDeliveryForm;
		private double _dPctAtRisk;
		private int _iNoInstrAttrib;
		private AllocationInstructionInstrAttribList _listInstrAttrib = new AllocationInstructionInstrAttribList();
		private string _sAgreementDesc;
		private string _sAgreementID;
		private DateTime _dtAgreementDate;
		private string _sAgreementCurrency;
		private int _iTerminationType;
		private DateTime _dtStartDate;
		private DateTime _dtEndDate;
		private int _iDeliveryType;
		private double _dMarginRatio;
		private int _iNoUnderlyings;
		private AllocationInstructionUnderlyingList _listUnderlying = new AllocationInstructionUnderlyingList();
		private int _iNoLegs;
		private AllocationInstructionLegList _listLeg = new AllocationInstructionLegList();
		private int _iQuantity;
		private int _iQtyType;
		private string _sLastMkt;
		private DateTime _dtTradeOriginationDate;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private int _iPriceType;
		private double _dAvgPx;
		private double _dAvgParPx;
		private double _dSpread;
		private string _sBenchmarkCurveCurrency;
		private string _sBenchmarkCurveName;
		private string _sBenchmarkCurvePoint;
		private double _dBenchmarkPrice;
		private int _iBenchmarkPriceType;
		private string _sBenchmarkSecurityID;
		private string _sBenchmarkSecurityIDSource;
		private string _sCurrency;
		private int _iAvgPxPrecision;
		private int _iNoPartyIDs;
		private AllocationInstructionPartyIDList _listPartyID = new AllocationInstructionPartyIDList();
		private DateTime _dtTradeDate;
		private DateTime _dtTransactTime;
		private char _cSettlType;
		private DateTime _dtSettlDate;
		private int _iBookingType;
		private double _dGrossTradeAmt;
		private double _dConcession;
		private double _dTotalTakedown;
		private double _dNetMoney;
		private char _cPositionEffect;
		private bool _bAutoAcceptIndicator;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private int _iNumDaysInterest;
		private double _dAccruedInterestRate;
		private double _dAccruedInterestAmt;
		private double _dTotalAccruedInterestAmt;
		private double _dInterestAtMaturity;
		private double _dEndAccruedInterestAmt;
		private double _dStartCash;
		private double _dEndCash;
		private bool _bLegalConfirm;
		private int _iNoStipulations;
		private AllocationInstructionStipulationList _listStipulation = new AllocationInstructionStipulationList();
		private string _sYieldType;
		private double _dYield;
		private DateTime _dtYieldCalcDate;
		private DateTime _dtYieldRedemptionDate;
		private double _dYieldRedemptionPrice;
		private int _iYieldRedemptionPriceType;
		private int _iTotNoAllocs;
		private bool _bLastFragment;
		private int _iNoAllocs;
		private AllocationInstructionAllocList _listAlloc = new AllocationInstructionAllocList();

		public AllocationInstruction() : base()
		{
			_sMsgType = Values.MsgType.AllocationInstruction;
		}

		public string AllocID
		{
			get { return _sAllocID; }
			set { _sAllocID = value; }
		}
		public char AllocTransType
		{
			get { return _cAllocTransType; }
			set { _cAllocTransType = value; }
		}
		public int AllocType
		{
			get { return _iAllocType; }
			set { _iAllocType = value; }
		}
		public string SecondaryAllocID
		{
			get { return _sSecondaryAllocID; }
			set { _sSecondaryAllocID = value; }
		}
		public string RefAllocID
		{
			get { return _sRefAllocID; }
			set { _sRefAllocID = value; }
		}
		public int AllocCancReplaceReason
		{
			get { return _iAllocCancReplaceReason; }
			set { _iAllocCancReplaceReason = value; }
		}
		public int AllocIntermedReqType
		{
			get { return _iAllocIntermedReqType; }
			set { _iAllocIntermedReqType = value; }
		}
		public string AllocLinkID
		{
			get { return _sAllocLinkID; }
			set { _sAllocLinkID = value; }
		}
		public int AllocLinkType
		{
			get { return _iAllocLinkType; }
			set { _iAllocLinkType = value; }
		}
		public string BookingRefID
		{
			get { return _sBookingRefID; }
			set { _sBookingRefID = value; }
		}
		public int AllocNoOrdersType
		{
			get { return _iAllocNoOrdersType; }
			set { _iAllocNoOrdersType = value; }
		}
		public int NoOrders
		{
			get { return _iNoOrders; }
			set { _iNoOrders = value; }
		}
		public AllocationInstructionOrderList Order 
		{
			get { return _listOrder; }
		}
		public int NoExecs
		{
			get { return _iNoExecs; }
			set { _iNoExecs = value; }
		}
		public AllocationInstructionExecList Exec 
		{
			get { return _listExec; }
		}
		public bool PreviouslyReported
		{
			get { return _bPreviouslyReported; }
			set { _bPreviouslyReported = value; }
		}
		public bool ReversalIndicator
		{
			get { return _bReversalIndicator; }
			set { _bReversalIndicator = value; }
		}
		public string MatchType
		{
			get { return _sMatchType; }
			set { _sMatchType = value; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
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
		public AllocationInstructionSecurityAltIDList SecurityAltID 
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
		public AllocationInstructionEventList Event 
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
		public int DeliveryForm
		{
			get { return _iDeliveryForm; }
			set { _iDeliveryForm = value; }
		}
		public double PctAtRisk
		{
			get { return _dPctAtRisk; }
			set { _dPctAtRisk = value; }
		}
		public int NoInstrAttrib
		{
			get { return _iNoInstrAttrib; }
			set { _iNoInstrAttrib = value; }
		}
		public AllocationInstructionInstrAttribList InstrAttrib 
		{
			get { return _listInstrAttrib; }
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
		public int NoUnderlyings
		{
			get { return _iNoUnderlyings; }
			set { _iNoUnderlyings = value; }
		}
		public AllocationInstructionUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
		}
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public AllocationInstructionLegList Leg 
		{
			get { return _listLeg; }
		}
		public int Quantity
		{
			get { return _iQuantity; }
			set { _iQuantity = value; }
		}
		public int QtyType
		{
			get { return _iQtyType; }
			set { _iQtyType = value; }
		}
		public string LastMkt
		{
			get { return _sLastMkt; }
			set { _sLastMkt = value; }
		}
		public DateTime TradeOriginationDate
		{
			get { return _dtTradeOriginationDate; }
			set { _dtTradeOriginationDate = value; }
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
		public int PriceType
		{
			get { return _iPriceType; }
			set { _iPriceType = value; }
		}
		public double AvgPx
		{
			get { return _dAvgPx; }
			set { _dAvgPx = value; }
		}
		public double AvgParPx
		{
			get { return _dAvgParPx; }
			set { _dAvgParPx = value; }
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
		public string Currency
		{
			get { return _sCurrency; }
			set { _sCurrency = value; }
		}
		public int AvgPxPrecision
		{
			get { return _iAvgPxPrecision; }
			set { _iAvgPxPrecision = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public AllocationInstructionPartyIDList PartyID 
		{
			get { return _listPartyID; }
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
		public int BookingType
		{
			get { return _iBookingType; }
			set { _iBookingType = value; }
		}
		public double GrossTradeAmt
		{
			get { return _dGrossTradeAmt; }
			set { _dGrossTradeAmt = value; }
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
		public char PositionEffect
		{
			get { return _cPositionEffect; }
			set { _cPositionEffect = value; }
		}
		public bool AutoAcceptIndicator
		{
			get { return _bAutoAcceptIndicator; }
			set { _bAutoAcceptIndicator = value; }
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
		public int NumDaysInterest
		{
			get { return _iNumDaysInterest; }
			set { _iNumDaysInterest = value; }
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
		public double TotalAccruedInterestAmt
		{
			get { return _dTotalAccruedInterestAmt; }
			set { _dTotalAccruedInterestAmt = value; }
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
		public bool LegalConfirm
		{
			get { return _bLegalConfirm; }
			set { _bLegalConfirm = value; }
		}
		public int NoStipulations
		{
			get { return _iNoStipulations; }
			set { _iNoStipulations = value; }
		}
		public AllocationInstructionStipulationList Stipulation 
		{
			get { return _listStipulation; }
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
		public int TotNoAllocs
		{
			get { return _iTotNoAllocs; }
			set { _iTotNoAllocs = value; }
		}
		public bool LastFragment
		{
			get { return _bLastFragment; }
			set { _bLastFragment = value; }
		}
		public int NoAllocs
		{
			get { return _iNoAllocs; }
			set { _iNoAllocs = value; }
		}
		public AllocationInstructionAllocList Alloc 
		{
			get { return _listAlloc; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_AllocID:
						return _sAllocID;
					case TAG_AllocTransType:
						return _cAllocTransType;
					case TAG_AllocType:
						return _iAllocType;
					case TAG_SecondaryAllocID:
						return _sSecondaryAllocID;
					case TAG_RefAllocID:
						return _sRefAllocID;
					case TAG_AllocCancReplaceReason:
						return _iAllocCancReplaceReason;
					case TAG_AllocIntermedReqType:
						return _iAllocIntermedReqType;
					case TAG_AllocLinkID:
						return _sAllocLinkID;
					case TAG_AllocLinkType:
						return _iAllocLinkType;
					case TAG_BookingRefID:
						return _sBookingRefID;
					case TAG_AllocNoOrdersType:
						return _iAllocNoOrdersType;
					case TAG_NoOrders:
						return _iNoOrders;
					case TAG_NoExecs:
						return _iNoExecs;
					case TAG_PreviouslyReported:
						return _bPreviouslyReported;
					case TAG_ReversalIndicator:
						return _bReversalIndicator;
					case TAG_MatchType:
						return _sMatchType;
					case TAG_Side:
						return _cSide;
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
					case TAG_DeliveryForm:
						return _iDeliveryForm;
					case TAG_PctAtRisk:
						return _dPctAtRisk;
					case TAG_NoInstrAttrib:
						return _iNoInstrAttrib;
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
					case TAG_NoUnderlyings:
						return _iNoUnderlyings;
					case TAG_NoLegs:
						return _iNoLegs;
					case TAG_Quantity:
						return _iQuantity;
					case TAG_QtyType:
						return _iQtyType;
					case TAG_LastMkt:
						return _sLastMkt;
					case TAG_TradeOriginationDate:
						return _dtTradeOriginationDate;
					case TAG_TradingSessionID:
						return _sTradingSessionID;
					case TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case TAG_PriceType:
						return _iPriceType;
					case TAG_AvgPx:
						return _dAvgPx;
					case TAG_AvgParPx:
						return _dAvgParPx;
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
					case TAG_Currency:
						return _sCurrency;
					case TAG_AvgPxPrecision:
						return _iAvgPxPrecision;
					case TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case TAG_TradeDate:
						return _dtTradeDate;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_SettlType:
						return _cSettlType;
					case TAG_SettlDate:
						return _dtSettlDate;
					case TAG_BookingType:
						return _iBookingType;
					case TAG_GrossTradeAmt:
						return _dGrossTradeAmt;
					case TAG_Concession:
						return _dConcession;
					case TAG_TotalTakedown:
						return _dTotalTakedown;
					case TAG_NetMoney:
						return _dNetMoney;
					case TAG_PositionEffect:
						return _cPositionEffect;
					case TAG_AutoAcceptIndicator:
						return _bAutoAcceptIndicator;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
					case TAG_NumDaysInterest:
						return _iNumDaysInterest;
					case TAG_AccruedInterestRate:
						return _dAccruedInterestRate;
					case TAG_AccruedInterestAmt:
						return _dAccruedInterestAmt;
					case TAG_TotalAccruedInterestAmt:
						return _dTotalAccruedInterestAmt;
					case TAG_InterestAtMaturity:
						return _dInterestAtMaturity;
					case TAG_EndAccruedInterestAmt:
						return _dEndAccruedInterestAmt;
					case TAG_StartCash:
						return _dStartCash;
					case TAG_EndCash:
						return _dEndCash;
					case TAG_LegalConfirm:
						return _bLegalConfirm;
					case TAG_NoStipulations:
						return _iNoStipulations;
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
					case TAG_TotNoAllocs:
						return _iTotNoAllocs;
					case TAG_LastFragment:
						return _bLastFragment;
					case TAG_NoAllocs:
						return _iNoAllocs;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_AllocID:
						_sAllocID = (string)value;
						break;
					case TAG_AllocTransType:
						_cAllocTransType = (char)value;
						break;
					case TAG_AllocType:
						_iAllocType = (int)value;
						break;
					case TAG_SecondaryAllocID:
						_sSecondaryAllocID = (string)value;
						break;
					case TAG_RefAllocID:
						_sRefAllocID = (string)value;
						break;
					case TAG_AllocCancReplaceReason:
						_iAllocCancReplaceReason = (int)value;
						break;
					case TAG_AllocIntermedReqType:
						_iAllocIntermedReqType = (int)value;
						break;
					case TAG_AllocLinkID:
						_sAllocLinkID = (string)value;
						break;
					case TAG_AllocLinkType:
						_iAllocLinkType = (int)value;
						break;
					case TAG_BookingRefID:
						_sBookingRefID = (string)value;
						break;
					case TAG_AllocNoOrdersType:
						_iAllocNoOrdersType = (int)value;
						break;
					case TAG_NoOrders:
						_iNoOrders = (int)value;
						break;
					case TAG_NoExecs:
						_iNoExecs = (int)value;
						break;
					case TAG_PreviouslyReported:
						_bPreviouslyReported = (bool)value;
						break;
					case TAG_ReversalIndicator:
						_bReversalIndicator = (bool)value;
						break;
					case TAG_MatchType:
						_sMatchType = (string)value;
						break;
					case TAG_Side:
						_cSide = (char)value;
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
					case TAG_DeliveryForm:
						_iDeliveryForm = (int)value;
						break;
					case TAG_PctAtRisk:
						_dPctAtRisk = (double)value;
						break;
					case TAG_NoInstrAttrib:
						_iNoInstrAttrib = (int)value;
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
					case TAG_NoUnderlyings:
						_iNoUnderlyings = (int)value;
						break;
					case TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					case TAG_Quantity:
						_iQuantity = (int)value;
						break;
					case TAG_QtyType:
						_iQtyType = (int)value;
						break;
					case TAG_LastMkt:
						_sLastMkt = (string)value;
						break;
					case TAG_TradeOriginationDate:
						_dtTradeOriginationDate = (DateTime)value;
						break;
					case TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case TAG_PriceType:
						_iPriceType = (int)value;
						break;
					case TAG_AvgPx:
						_dAvgPx = (double)value;
						break;
					case TAG_AvgParPx:
						_dAvgParPx = (double)value;
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
					case TAG_Currency:
						_sCurrency = (string)value;
						break;
					case TAG_AvgPxPrecision:
						_iAvgPxPrecision = (int)value;
						break;
					case TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_SettlType:
						_cSettlType = (char)value;
						break;
					case TAG_SettlDate:
						_dtSettlDate = (DateTime)value;
						break;
					case TAG_BookingType:
						_iBookingType = (int)value;
						break;
					case TAG_GrossTradeAmt:
						_dGrossTradeAmt = (double)value;
						break;
					case TAG_Concession:
						_dConcession = (double)value;
						break;
					case TAG_TotalTakedown:
						_dTotalTakedown = (double)value;
						break;
					case TAG_NetMoney:
						_dNetMoney = (double)value;
						break;
					case TAG_PositionEffect:
						_cPositionEffect = (char)value;
						break;
					case TAG_AutoAcceptIndicator:
						_bAutoAcceptIndicator = (bool)value;
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
					case TAG_NumDaysInterest:
						_iNumDaysInterest = (int)value;
						break;
					case TAG_AccruedInterestRate:
						_dAccruedInterestRate = (double)value;
						break;
					case TAG_AccruedInterestAmt:
						_dAccruedInterestAmt = (double)value;
						break;
					case TAG_TotalAccruedInterestAmt:
						_dTotalAccruedInterestAmt = (double)value;
						break;
					case TAG_InterestAtMaturity:
						_dInterestAtMaturity = (double)value;
						break;
					case TAG_EndAccruedInterestAmt:
						_dEndAccruedInterestAmt = (double)value;
						break;
					case TAG_StartCash:
						_dStartCash = (double)value;
						break;
					case TAG_EndCash:
						_dEndCash = (double)value;
						break;
					case TAG_LegalConfirm:
						_bLegalConfirm = (bool)value;
						break;
					case TAG_NoStipulations:
						_iNoStipulations = (int)value;
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
					case TAG_TotNoAllocs:
						_iTotNoAllocs = (int)value;
						break;
					case TAG_LastFragment:
						_bLastFragment = (bool)value;
						break;
					case TAG_NoAllocs:
						_iNoAllocs = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class AllocationInstructionOrder
	{
		private string _sClOrdID;
		private string _sOrderID;
		private string _sSecondaryOrderID;
		private string _sSecondaryClOrdID;
		private string _sListID;
		private int _iNoNested2PartyIDs;
		private AllocationInstructionNested2PartyIDList _listNested2PartyID = new AllocationInstructionNested2PartyIDList();
		private int _iOrderQty;
		private double _dOrderAvgPx;
		private int _iOrderBookingQty;

		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
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
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public int NoNested2PartyIDs
		{
			get { return _iNoNested2PartyIDs; }
			set { _iNoNested2PartyIDs = value; }
		}
		public AllocationInstructionNested2PartyIDList Nested2PartyID 
		{
			get { return _listNested2PartyID; }
		}
		public int OrderQty
		{
			get { return _iOrderQty; }
			set { _iOrderQty = value; }
		}
		public double OrderAvgPx
		{
			get { return _dOrderAvgPx; }
			set { _dOrderAvgPx = value; }
		}
		public int OrderBookingQty
		{
			get { return _iOrderBookingQty; }
			set { _iOrderBookingQty = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_ClOrdID:
						return _sClOrdID;
					case AllocationInstruction.TAG_OrderID:
						return _sOrderID;
					case AllocationInstruction.TAG_SecondaryOrderID:
						return _sSecondaryOrderID;
					case AllocationInstruction.TAG_SecondaryClOrdID:
						return _sSecondaryClOrdID;
					case AllocationInstruction.TAG_ListID:
						return _sListID;
					case AllocationInstruction.TAG_NoNested2PartyIDs:
						return _iNoNested2PartyIDs;
					case AllocationInstruction.TAG_OrderQty:
						return _iOrderQty;
					case AllocationInstruction.TAG_OrderAvgPx:
						return _dOrderAvgPx;
					case AllocationInstruction.TAG_OrderBookingQty:
						return _iOrderBookingQty;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case AllocationInstruction.TAG_OrderID:
						_sOrderID = (string)value;
						break;
					case AllocationInstruction.TAG_SecondaryOrderID:
						_sSecondaryOrderID = (string)value;
						break;
					case AllocationInstruction.TAG_SecondaryClOrdID:
						_sSecondaryClOrdID = (string)value;
						break;
					case AllocationInstruction.TAG_ListID:
						_sListID = (string)value;
						break;
					case AllocationInstruction.TAG_NoNested2PartyIDs:
						_iNoNested2PartyIDs = (int)value;
						break;
					case AllocationInstruction.TAG_OrderQty:
						_iOrderQty = (int)value;
						break;
					case AllocationInstruction.TAG_OrderAvgPx:
						_dOrderAvgPx = (double)value;
						break;
					case AllocationInstruction.TAG_OrderBookingQty:
						_iOrderBookingQty = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionOrderList
	{
		private ArrayList _al;
		private AllocationInstructionOrder _last;

		public AllocationInstructionOrder this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionOrder)_al[i];
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

		public void Add(AllocationInstructionOrder item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionOrder item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionOrder Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionNested2PartyID
	{
		private string _sNested2PartyID;
		private char _cNested2PartyIDSource;
		private int _iNested2PartyRole;
		private int _iNoNested2PartySubIDs;
		private AllocationInstructionNested2PartySubIDList _listNested2PartySubID = new AllocationInstructionNested2PartySubIDList();

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
		public AllocationInstructionNested2PartySubIDList Nested2PartySubID 
		{
			get { return _listNested2PartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_Nested2PartyID:
						return _sNested2PartyID;
					case AllocationInstruction.TAG_Nested2PartyIDSource:
						return _cNested2PartyIDSource;
					case AllocationInstruction.TAG_Nested2PartyRole:
						return _iNested2PartyRole;
					case AllocationInstruction.TAG_NoNested2PartySubIDs:
						return _iNoNested2PartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_Nested2PartyID:
						_sNested2PartyID = (string)value;
						break;
					case AllocationInstruction.TAG_Nested2PartyIDSource:
						_cNested2PartyIDSource = (char)value;
						break;
					case AllocationInstruction.TAG_Nested2PartyRole:
						_iNested2PartyRole = (int)value;
						break;
					case AllocationInstruction.TAG_NoNested2PartySubIDs:
						_iNoNested2PartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionNested2PartyIDList
	{
		private ArrayList _al;
		private AllocationInstructionNested2PartyID _last;

		public AllocationInstructionNested2PartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionNested2PartyID)_al[i];
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

		public void Add(AllocationInstructionNested2PartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionNested2PartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionNested2PartyID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionNested2PartySubID
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
					case AllocationInstruction.TAG_Nested2PartySubID:
						return _sNested2PartySubID;
					case AllocationInstruction.TAG_Nested2PartySubIDType:
						return _iNested2PartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_Nested2PartySubID:
						_sNested2PartySubID = (string)value;
						break;
					case AllocationInstruction.TAG_Nested2PartySubIDType:
						_iNested2PartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionNested2PartySubIDList
	{
		private ArrayList _al;
		private AllocationInstructionNested2PartySubID _last;

		public AllocationInstructionNested2PartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionNested2PartySubID)_al[i];
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

		public void Add(AllocationInstructionNested2PartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionNested2PartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionNested2PartySubID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionExec
	{
		private int _iLastQty;
		private string _sExecID;
		private string _sSecondaryExecID;
		private double _dLastPx;
		private double _dLastParPx;
		private char _cLastCapacity;

		public int LastQty
		{
			get { return _iLastQty; }
			set { _iLastQty = value; }
		}
		public string ExecID
		{
			get { return _sExecID; }
			set { _sExecID = value; }
		}
		public string SecondaryExecID
		{
			get { return _sSecondaryExecID; }
			set { _sSecondaryExecID = value; }
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
		public char LastCapacity
		{
			get { return _cLastCapacity; }
			set { _cLastCapacity = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_LastQty:
						return _iLastQty;
					case AllocationInstruction.TAG_ExecID:
						return _sExecID;
					case AllocationInstruction.TAG_SecondaryExecID:
						return _sSecondaryExecID;
					case AllocationInstruction.TAG_LastPx:
						return _dLastPx;
					case AllocationInstruction.TAG_LastParPx:
						return _dLastParPx;
					case AllocationInstruction.TAG_LastCapacity:
						return _cLastCapacity;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_LastQty:
						_iLastQty = (int)value;
						break;
					case AllocationInstruction.TAG_ExecID:
						_sExecID = (string)value;
						break;
					case AllocationInstruction.TAG_SecondaryExecID:
						_sSecondaryExecID = (string)value;
						break;
					case AllocationInstruction.TAG_LastPx:
						_dLastPx = (double)value;
						break;
					case AllocationInstruction.TAG_LastParPx:
						_dLastParPx = (double)value;
						break;
					case AllocationInstruction.TAG_LastCapacity:
						_cLastCapacity = (char)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionExecList
	{
		private ArrayList _al;
		private AllocationInstructionExec _last;

		public AllocationInstructionExec this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionExec)_al[i];
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

		public void Add(AllocationInstructionExec item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionExec item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionExec Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionSecurityAltID
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
					case AllocationInstruction.TAG_SecurityAltID:
						return _sSecurityAltID;
					case AllocationInstruction.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case AllocationInstruction.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionSecurityAltIDList
	{
		private ArrayList _al;
		private AllocationInstructionSecurityAltID _last;

		public AllocationInstructionSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionSecurityAltID)_al[i];
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

		public void Add(AllocationInstructionSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionEvent
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
					case AllocationInstruction.TAG_EventType:
						return _iEventType;
					case AllocationInstruction.TAG_EventDate:
						return _dtEventDate;
					case AllocationInstruction.TAG_EventPx:
						return _dEventPx;
					case AllocationInstruction.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_EventType:
						_iEventType = (int)value;
						break;
					case AllocationInstruction.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case AllocationInstruction.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionEventList
	{
		private ArrayList _al;
		private AllocationInstructionEvent _last;

		public AllocationInstructionEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionEvent)_al[i];
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

		public void Add(AllocationInstructionEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionEvent Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionInstrAttrib
	{
		private int _iInstrAttribType;
		private string _sInstrAttribValue;

		public int InstrAttribType
		{
			get { return _iInstrAttribType; }
			set { _iInstrAttribType = value; }
		}
		public string InstrAttribValue
		{
			get { return _sInstrAttribValue; }
			set { _sInstrAttribValue = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_InstrAttribType:
						return _iInstrAttribType;
					case AllocationInstruction.TAG_InstrAttribValue:
						return _sInstrAttribValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_InstrAttribType:
						_iInstrAttribType = (int)value;
						break;
					case AllocationInstruction.TAG_InstrAttribValue:
						_sInstrAttribValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionInstrAttribList
	{
		private ArrayList _al;
		private AllocationInstructionInstrAttrib _last;

		public AllocationInstructionInstrAttrib this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionInstrAttrib)_al[i];
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

		public void Add(AllocationInstructionInstrAttrib item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionInstrAttrib item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionInstrAttrib Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private AllocationInstructionUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new AllocationInstructionUnderlyingSecurityAltIDList();
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
		public AllocationInstructionUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
					case AllocationInstruction.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case AllocationInstruction.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case AllocationInstruction.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case AllocationInstruction.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case AllocationInstruction.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case AllocationInstruction.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case AllocationInstruction.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case AllocationInstruction.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case AllocationInstruction.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case AllocationInstruction.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case AllocationInstruction.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case AllocationInstruction.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case AllocationInstruction.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case AllocationInstruction.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case AllocationInstruction.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case AllocationInstruction.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case AllocationInstruction.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case AllocationInstruction.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case AllocationInstruction.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case AllocationInstruction.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case AllocationInstruction.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case AllocationInstruction.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case AllocationInstruction.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case AllocationInstruction.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case AllocationInstruction.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case AllocationInstruction.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case AllocationInstruction.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case AllocationInstruction.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case AllocationInstruction.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case AllocationInstruction.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case AllocationInstruction.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case AllocationInstruction.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case AllocationInstruction.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case AllocationInstruction.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case AllocationInstruction.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case AllocationInstruction.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case AllocationInstruction.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case AllocationInstruction.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case AllocationInstruction.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case AllocationInstruction.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case AllocationInstruction.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case AllocationInstruction.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case AllocationInstruction.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case AllocationInstruction.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case AllocationInstruction.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case AllocationInstruction.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case AllocationInstruction.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case AllocationInstruction.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case AllocationInstruction.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case AllocationInstruction.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case AllocationInstruction.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case AllocationInstruction.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case AllocationInstruction.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case AllocationInstruction.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case AllocationInstruction.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case AllocationInstruction.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case AllocationInstruction.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case AllocationInstruction.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionUnderlyingList
	{
		private ArrayList _al;
		private AllocationInstructionUnderlying _last;

		public AllocationInstructionUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionUnderlying)_al[i];
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

		public void Add(AllocationInstructionUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionUnderlying Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionUnderlyingSecurityAltID
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
					case AllocationInstruction.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case AllocationInstruction.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case AllocationInstruction.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private AllocationInstructionUnderlyingSecurityAltID _last;

		public AllocationInstructionUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionUnderlyingSecurityAltID)_al[i];
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

		public void Add(AllocationInstructionUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private AllocationInstructionLegSecurityAltIDList _listLegSecurityAltID = new AllocationInstructionLegSecurityAltIDList();
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
		public AllocationInstructionLegSecurityAltIDList LegSecurityAltID 
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
					case AllocationInstruction.TAG_LegSymbol:
						return _sLegSymbol;
					case AllocationInstruction.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case AllocationInstruction.TAG_LegSecurityID:
						return _sLegSecurityID;
					case AllocationInstruction.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case AllocationInstruction.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case AllocationInstruction.TAG_LegProduct:
						return _iLegProduct;
					case AllocationInstruction.TAG_LegCFICode:
						return _sLegCFICode;
					case AllocationInstruction.TAG_LegSecurityType:
						return _sLegSecurityType;
					case AllocationInstruction.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case AllocationInstruction.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case AllocationInstruction.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case AllocationInstruction.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case AllocationInstruction.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case AllocationInstruction.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case AllocationInstruction.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case AllocationInstruction.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case AllocationInstruction.TAG_LegFactor:
						return _dLegFactor;
					case AllocationInstruction.TAG_LegCreditRating:
						return _sLegCreditRating;
					case AllocationInstruction.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case AllocationInstruction.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case AllocationInstruction.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case AllocationInstruction.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case AllocationInstruction.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case AllocationInstruction.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case AllocationInstruction.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case AllocationInstruction.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case AllocationInstruction.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case AllocationInstruction.TAG_LegCouponRate:
						return _dLegCouponRate;
					case AllocationInstruction.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case AllocationInstruction.TAG_LegIssuer:
						return _sLegIssuer;
					case AllocationInstruction.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case AllocationInstruction.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case AllocationInstruction.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case AllocationInstruction.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case AllocationInstruction.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case AllocationInstruction.TAG_LegRatioQty:
						return _dLegRatioQty;
					case AllocationInstruction.TAG_LegSide:
						return _cLegSide;
					case AllocationInstruction.TAG_LegCurrency:
						return _sLegCurrency;
					case AllocationInstruction.TAG_LegPool:
						return _sLegPool;
					case AllocationInstruction.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case AllocationInstruction.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case AllocationInstruction.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case AllocationInstruction.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case AllocationInstruction.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case AllocationInstruction.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case AllocationInstruction.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case AllocationInstruction.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case AllocationInstruction.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case AllocationInstruction.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case AllocationInstruction.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case AllocationInstruction.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case AllocationInstruction.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case AllocationInstruction.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case AllocationInstruction.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case AllocationInstruction.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case AllocationInstruction.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case AllocationInstruction.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case AllocationInstruction.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case AllocationInstruction.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case AllocationInstruction.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case AllocationInstruction.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case AllocationInstruction.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case AllocationInstruction.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case AllocationInstruction.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case AllocationInstruction.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case AllocationInstruction.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case AllocationInstruction.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case AllocationInstruction.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case AllocationInstruction.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case AllocationInstruction.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case AllocationInstruction.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case AllocationInstruction.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case AllocationInstruction.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case AllocationInstruction.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case AllocationInstruction.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case AllocationInstruction.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case AllocationInstruction.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case AllocationInstruction.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case AllocationInstruction.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionLegList
	{
		private ArrayList _al;
		private AllocationInstructionLeg _last;

		public AllocationInstructionLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionLeg)_al[i];
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

		public void Add(AllocationInstructionLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionLeg Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionLegSecurityAltID
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
					case AllocationInstruction.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case AllocationInstruction.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case AllocationInstruction.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionLegSecurityAltIDList
	{
		private ArrayList _al;
		private AllocationInstructionLegSecurityAltID _last;

		public AllocationInstructionLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionLegSecurityAltID)_al[i];
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

		public void Add(AllocationInstructionLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionLegSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private AllocationInstructionPartySubIDList _listPartySubID = new AllocationInstructionPartySubIDList();

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
		public AllocationInstructionPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_PartyID:
						return _sPartyID;
					case AllocationInstruction.TAG_PartyIDSource:
						return _cPartyIDSource;
					case AllocationInstruction.TAG_PartyRole:
						return _iPartyRole;
					case AllocationInstruction.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case AllocationInstruction.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case AllocationInstruction.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case AllocationInstruction.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionPartyIDList
	{
		private ArrayList _al;
		private AllocationInstructionPartyID _last;

		public AllocationInstructionPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionPartyID)_al[i];
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

		public void Add(AllocationInstructionPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionPartyID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionPartySubID
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
					case AllocationInstruction.TAG_PartySubID:
						return _sPartySubID;
					case AllocationInstruction.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case AllocationInstruction.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionPartySubIDList
	{
		private ArrayList _al;
		private AllocationInstructionPartySubID _last;

		public AllocationInstructionPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionPartySubID)_al[i];
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

		public void Add(AllocationInstructionPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionPartySubID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionStipulation
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
					case AllocationInstruction.TAG_StipulationType:
						return _sStipulationType;
					case AllocationInstruction.TAG_StipulationValue:
						return _sStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_StipulationType:
						_sStipulationType = (string)value;
						break;
					case AllocationInstruction.TAG_StipulationValue:
						_sStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionStipulationList
	{
		private ArrayList _al;
		private AllocationInstructionStipulation _last;

		public AllocationInstructionStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionStipulation)_al[i];
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

		public void Add(AllocationInstructionStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionStipulation Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionAlloc
	{
		private string _sAllocAccount;
		private int _iAllocAcctIDSource;
		private char _cMatchStatus;
		private double _dAllocPrice;
		private int _iAllocQty;
		private string _sIndividualAllocID;
		private char _cProcessCode;
		private int _iNoNestedPartyIDs;
		private AllocationInstructionNestedPartyIDList _listNestedPartyID = new AllocationInstructionNestedPartyIDList();
		private bool _bNotifyBrokerOfCredit;
		private int _iAllocHandlInst;
		private string _sAllocText;
		private int _iEncodedAllocTextLen;
		private string _sEncodedAllocText;
		private double _dCommission;
		private char _cCommType;
		private string _sCommCurrency;
		private char _cFundRenewWaiv;
		private double _dAllocAvgPx;
		private double _dAllocNetMoney;
		private double _dSettlCurrAmt;
		private double _dAllocSettlCurrAmt;
		private string _sSettlCurrency;
		private string _sAllocSettlCurrency;
		private double _dSettlCurrFxRate;
		private char _cSettlCurrFxRateCalc;
		private double _dAccruedInterestAmt;
		private double _dAllocAccruedInterestAmt;
		private double _dAllocInterestAtMaturity;
		private char _cSettlInstMode;
		private int _iNoMiscFees;
		private AllocationInstructionMiscFeeList _listMiscFee = new AllocationInstructionMiscFeeList();
		private int _iNoClearingInstructions;
		private int _iClearingInstruction;
		private string _sClearingFeeIndicator;
		private int _iAllocSettlInstType;
		private int _iSettlDeliveryType;
		private int _iStandInstDbType;
		private string _sStandInstDbName;
		private string _sStandInstDbID;
		private int _iNoDlvyInst;
		private AllocationInstructionDlvyInstList _listDlvyInst = new AllocationInstructionDlvyInstList();

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
		public char MatchStatus
		{
			get { return _cMatchStatus; }
			set { _cMatchStatus = value; }
		}
		public double AllocPrice
		{
			get { return _dAllocPrice; }
			set { _dAllocPrice = value; }
		}
		public int AllocQty
		{
			get { return _iAllocQty; }
			set { _iAllocQty = value; }
		}
		public string IndividualAllocID
		{
			get { return _sIndividualAllocID; }
			set { _sIndividualAllocID = value; }
		}
		public char ProcessCode
		{
			get { return _cProcessCode; }
			set { _cProcessCode = value; }
		}
		public int NoNestedPartyIDs
		{
			get { return _iNoNestedPartyIDs; }
			set { _iNoNestedPartyIDs = value; }
		}
		public AllocationInstructionNestedPartyIDList NestedPartyID 
		{
			get { return _listNestedPartyID; }
		}
		public bool NotifyBrokerOfCredit
		{
			get { return _bNotifyBrokerOfCredit; }
			set { _bNotifyBrokerOfCredit = value; }
		}
		public int AllocHandlInst
		{
			get { return _iAllocHandlInst; }
			set { _iAllocHandlInst = value; }
		}
		public string AllocText
		{
			get { return _sAllocText; }
			set { _sAllocText = value; }
		}
		public int EncodedAllocTextLen
		{
			get { return _iEncodedAllocTextLen; }
			set { _iEncodedAllocTextLen = value; }
		}
		public string EncodedAllocText
		{
			get { return _sEncodedAllocText; }
			set { _sEncodedAllocText = value; }
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
		public double AllocAvgPx
		{
			get { return _dAllocAvgPx; }
			set { _dAllocAvgPx = value; }
		}
		public double AllocNetMoney
		{
			get { return _dAllocNetMoney; }
			set { _dAllocNetMoney = value; }
		}
		public double SettlCurrAmt
		{
			get { return _dSettlCurrAmt; }
			set { _dSettlCurrAmt = value; }
		}
		public double AllocSettlCurrAmt
		{
			get { return _dAllocSettlCurrAmt; }
			set { _dAllocSettlCurrAmt = value; }
		}
		public string SettlCurrency
		{
			get { return _sSettlCurrency; }
			set { _sSettlCurrency = value; }
		}
		public string AllocSettlCurrency
		{
			get { return _sAllocSettlCurrency; }
			set { _sAllocSettlCurrency = value; }
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
		public double AccruedInterestAmt
		{
			get { return _dAccruedInterestAmt; }
			set { _dAccruedInterestAmt = value; }
		}
		public double AllocAccruedInterestAmt
		{
			get { return _dAllocAccruedInterestAmt; }
			set { _dAllocAccruedInterestAmt = value; }
		}
		public double AllocInterestAtMaturity
		{
			get { return _dAllocInterestAtMaturity; }
			set { _dAllocInterestAtMaturity = value; }
		}
		public char SettlInstMode
		{
			get { return _cSettlInstMode; }
			set { _cSettlInstMode = value; }
		}
		public int NoMiscFees
		{
			get { return _iNoMiscFees; }
			set { _iNoMiscFees = value; }
		}
		public AllocationInstructionMiscFeeList MiscFee 
		{
			get { return _listMiscFee; }
		}
		public int NoClearingInstructions
		{
			get { return _iNoClearingInstructions; }
			set { _iNoClearingInstructions = value; }
		}
		public int ClearingInstruction
		{
			get { return _iClearingInstruction; }
			set { _iClearingInstruction = value; }
		}
		public string ClearingFeeIndicator
		{
			get { return _sClearingFeeIndicator; }
			set { _sClearingFeeIndicator = value; }
		}
		public int AllocSettlInstType
		{
			get { return _iAllocSettlInstType; }
			set { _iAllocSettlInstType = value; }
		}
		public int SettlDeliveryType
		{
			get { return _iSettlDeliveryType; }
			set { _iSettlDeliveryType = value; }
		}
		public int StandInstDbType
		{
			get { return _iStandInstDbType; }
			set { _iStandInstDbType = value; }
		}
		public string StandInstDbName
		{
			get { return _sStandInstDbName; }
			set { _sStandInstDbName = value; }
		}
		public string StandInstDbID
		{
			get { return _sStandInstDbID; }
			set { _sStandInstDbID = value; }
		}
		public int NoDlvyInst
		{
			get { return _iNoDlvyInst; }
			set { _iNoDlvyInst = value; }
		}
		public AllocationInstructionDlvyInstList DlvyInst 
		{
			get { return _listDlvyInst; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_AllocAccount:
						return _sAllocAccount;
					case AllocationInstruction.TAG_AllocAcctIDSource:
						return _iAllocAcctIDSource;
					case AllocationInstruction.TAG_MatchStatus:
						return _cMatchStatus;
					case AllocationInstruction.TAG_AllocPrice:
						return _dAllocPrice;
					case AllocationInstruction.TAG_AllocQty:
						return _iAllocQty;
					case AllocationInstruction.TAG_IndividualAllocID:
						return _sIndividualAllocID;
					case AllocationInstruction.TAG_ProcessCode:
						return _cProcessCode;
					case AllocationInstruction.TAG_NoNestedPartyIDs:
						return _iNoNestedPartyIDs;
					case AllocationInstruction.TAG_NotifyBrokerOfCredit:
						return _bNotifyBrokerOfCredit;
					case AllocationInstruction.TAG_AllocHandlInst:
						return _iAllocHandlInst;
					case AllocationInstruction.TAG_AllocText:
						return _sAllocText;
					case AllocationInstruction.TAG_EncodedAllocTextLen:
						return _iEncodedAllocTextLen;
					case AllocationInstruction.TAG_EncodedAllocText:
						return _sEncodedAllocText;
					case AllocationInstruction.TAG_Commission:
						return _dCommission;
					case AllocationInstruction.TAG_CommType:
						return _cCommType;
					case AllocationInstruction.TAG_CommCurrency:
						return _sCommCurrency;
					case AllocationInstruction.TAG_FundRenewWaiv:
						return _cFundRenewWaiv;
					case AllocationInstruction.TAG_AllocAvgPx:
						return _dAllocAvgPx;
					case AllocationInstruction.TAG_AllocNetMoney:
						return _dAllocNetMoney;
					case AllocationInstruction.TAG_SettlCurrAmt:
						return _dSettlCurrAmt;
					case AllocationInstruction.TAG_AllocSettlCurrAmt:
						return _dAllocSettlCurrAmt;
					case AllocationInstruction.TAG_SettlCurrency:
						return _sSettlCurrency;
					case AllocationInstruction.TAG_AllocSettlCurrency:
						return _sAllocSettlCurrency;
					case AllocationInstruction.TAG_SettlCurrFxRate:
						return _dSettlCurrFxRate;
					case AllocationInstruction.TAG_SettlCurrFxRateCalc:
						return _cSettlCurrFxRateCalc;
					case AllocationInstruction.TAG_AccruedInterestAmt:
						return _dAccruedInterestAmt;
					case AllocationInstruction.TAG_AllocAccruedInterestAmt:
						return _dAllocAccruedInterestAmt;
					case AllocationInstruction.TAG_AllocInterestAtMaturity:
						return _dAllocInterestAtMaturity;
					case AllocationInstruction.TAG_SettlInstMode:
						return _cSettlInstMode;
					case AllocationInstruction.TAG_NoMiscFees:
						return _iNoMiscFees;
					case AllocationInstruction.TAG_NoClearingInstructions:
						return _iNoClearingInstructions;
					case AllocationInstruction.TAG_ClearingInstruction:
						return _iClearingInstruction;
					case AllocationInstruction.TAG_ClearingFeeIndicator:
						return _sClearingFeeIndicator;
					case AllocationInstruction.TAG_AllocSettlInstType:
						return _iAllocSettlInstType;
					case AllocationInstruction.TAG_SettlDeliveryType:
						return _iSettlDeliveryType;
					case AllocationInstruction.TAG_StandInstDbType:
						return _iStandInstDbType;
					case AllocationInstruction.TAG_StandInstDbName:
						return _sStandInstDbName;
					case AllocationInstruction.TAG_StandInstDbID:
						return _sStandInstDbID;
					case AllocationInstruction.TAG_NoDlvyInst:
						return _iNoDlvyInst;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_AllocAccount:
						_sAllocAccount = (string)value;
						break;
					case AllocationInstruction.TAG_AllocAcctIDSource:
						_iAllocAcctIDSource = (int)value;
						break;
					case AllocationInstruction.TAG_MatchStatus:
						_cMatchStatus = (char)value;
						break;
					case AllocationInstruction.TAG_AllocPrice:
						_dAllocPrice = (double)value;
						break;
					case AllocationInstruction.TAG_AllocQty:
						_iAllocQty = (int)value;
						break;
					case AllocationInstruction.TAG_IndividualAllocID:
						_sIndividualAllocID = (string)value;
						break;
					case AllocationInstruction.TAG_ProcessCode:
						_cProcessCode = (char)value;
						break;
					case AllocationInstruction.TAG_NoNestedPartyIDs:
						_iNoNestedPartyIDs = (int)value;
						break;
					case AllocationInstruction.TAG_NotifyBrokerOfCredit:
						_bNotifyBrokerOfCredit = (bool)value;
						break;
					case AllocationInstruction.TAG_AllocHandlInst:
						_iAllocHandlInst = (int)value;
						break;
					case AllocationInstruction.TAG_AllocText:
						_sAllocText = (string)value;
						break;
					case AllocationInstruction.TAG_EncodedAllocTextLen:
						_iEncodedAllocTextLen = (int)value;
						break;
					case AllocationInstruction.TAG_EncodedAllocText:
						_sEncodedAllocText = (string)value;
						break;
					case AllocationInstruction.TAG_Commission:
						_dCommission = (double)value;
						break;
					case AllocationInstruction.TAG_CommType:
						_cCommType = (char)value;
						break;
					case AllocationInstruction.TAG_CommCurrency:
						_sCommCurrency = (string)value;
						break;
					case AllocationInstruction.TAG_FundRenewWaiv:
						_cFundRenewWaiv = (char)value;
						break;
					case AllocationInstruction.TAG_AllocAvgPx:
						_dAllocAvgPx = (double)value;
						break;
					case AllocationInstruction.TAG_AllocNetMoney:
						_dAllocNetMoney = (double)value;
						break;
					case AllocationInstruction.TAG_SettlCurrAmt:
						_dSettlCurrAmt = (double)value;
						break;
					case AllocationInstruction.TAG_AllocSettlCurrAmt:
						_dAllocSettlCurrAmt = (double)value;
						break;
					case AllocationInstruction.TAG_SettlCurrency:
						_sSettlCurrency = (string)value;
						break;
					case AllocationInstruction.TAG_AllocSettlCurrency:
						_sAllocSettlCurrency = (string)value;
						break;
					case AllocationInstruction.TAG_SettlCurrFxRate:
						_dSettlCurrFxRate = (double)value;
						break;
					case AllocationInstruction.TAG_SettlCurrFxRateCalc:
						_cSettlCurrFxRateCalc = (char)value;
						break;
					case AllocationInstruction.TAG_AccruedInterestAmt:
						_dAccruedInterestAmt = (double)value;
						break;
					case AllocationInstruction.TAG_AllocAccruedInterestAmt:
						_dAllocAccruedInterestAmt = (double)value;
						break;
					case AllocationInstruction.TAG_AllocInterestAtMaturity:
						_dAllocInterestAtMaturity = (double)value;
						break;
					case AllocationInstruction.TAG_SettlInstMode:
						_cSettlInstMode = (char)value;
						break;
					case AllocationInstruction.TAG_NoMiscFees:
						_iNoMiscFees = (int)value;
						break;
					case AllocationInstruction.TAG_NoClearingInstructions:
						_iNoClearingInstructions = (int)value;
						break;
					case AllocationInstruction.TAG_ClearingInstruction:
						_iClearingInstruction = (int)value;
						break;
					case AllocationInstruction.TAG_ClearingFeeIndicator:
						_sClearingFeeIndicator = (string)value;
						break;
					case AllocationInstruction.TAG_AllocSettlInstType:
						_iAllocSettlInstType = (int)value;
						break;
					case AllocationInstruction.TAG_SettlDeliveryType:
						_iSettlDeliveryType = (int)value;
						break;
					case AllocationInstruction.TAG_StandInstDbType:
						_iStandInstDbType = (int)value;
						break;
					case AllocationInstruction.TAG_StandInstDbName:
						_sStandInstDbName = (string)value;
						break;
					case AllocationInstruction.TAG_StandInstDbID:
						_sStandInstDbID = (string)value;
						break;
					case AllocationInstruction.TAG_NoDlvyInst:
						_iNoDlvyInst = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionAllocList
	{
		private ArrayList _al;
		private AllocationInstructionAlloc _last;

		public AllocationInstructionAlloc this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionAlloc)_al[i];
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

		public void Add(AllocationInstructionAlloc item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionAlloc item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionAlloc Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionNestedPartyID
	{
		private string _sNestedPartyID;
		private char _cNestedPartyIDSource;
		private int _iNestedPartyRole;
		private int _iNoNestedPartySubIDs;
		private AllocationInstructionNestedPartySubIDList _listNestedPartySubID = new AllocationInstructionNestedPartySubIDList();

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
		public AllocationInstructionNestedPartySubIDList NestedPartySubID 
		{
			get { return _listNestedPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_NestedPartyID:
						return _sNestedPartyID;
					case AllocationInstruction.TAG_NestedPartyIDSource:
						return _cNestedPartyIDSource;
					case AllocationInstruction.TAG_NestedPartyRole:
						return _iNestedPartyRole;
					case AllocationInstruction.TAG_NoNestedPartySubIDs:
						return _iNoNestedPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_NestedPartyID:
						_sNestedPartyID = (string)value;
						break;
					case AllocationInstruction.TAG_NestedPartyIDSource:
						_cNestedPartyIDSource = (char)value;
						break;
					case AllocationInstruction.TAG_NestedPartyRole:
						_iNestedPartyRole = (int)value;
						break;
					case AllocationInstruction.TAG_NoNestedPartySubIDs:
						_iNoNestedPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionNestedPartyIDList
	{
		private ArrayList _al;
		private AllocationInstructionNestedPartyID _last;

		public AllocationInstructionNestedPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionNestedPartyID)_al[i];
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

		public void Add(AllocationInstructionNestedPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionNestedPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionNestedPartyID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionNestedPartySubID
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
					case AllocationInstruction.TAG_NestedPartySubID:
						return _sNestedPartySubID;
					case AllocationInstruction.TAG_NestedPartySubIDType:
						return _iNestedPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_NestedPartySubID:
						_sNestedPartySubID = (string)value;
						break;
					case AllocationInstruction.TAG_NestedPartySubIDType:
						_iNestedPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionNestedPartySubIDList
	{
		private ArrayList _al;
		private AllocationInstructionNestedPartySubID _last;

		public AllocationInstructionNestedPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionNestedPartySubID)_al[i];
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

		public void Add(AllocationInstructionNestedPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionNestedPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionNestedPartySubID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionMiscFee
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
					case AllocationInstruction.TAG_MiscFeeAmt:
						return _dMiscFeeAmt;
					case AllocationInstruction.TAG_MiscFeeCurr:
						return _sMiscFeeCurr;
					case AllocationInstruction.TAG_MiscFeeType:
						return _cMiscFeeType;
					case AllocationInstruction.TAG_MiscFeeBasis:
						return _iMiscFeeBasis;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_MiscFeeAmt:
						_dMiscFeeAmt = (double)value;
						break;
					case AllocationInstruction.TAG_MiscFeeCurr:
						_sMiscFeeCurr = (string)value;
						break;
					case AllocationInstruction.TAG_MiscFeeType:
						_cMiscFeeType = (char)value;
						break;
					case AllocationInstruction.TAG_MiscFeeBasis:
						_iMiscFeeBasis = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionMiscFeeList
	{
		private ArrayList _al;
		private AllocationInstructionMiscFee _last;

		public AllocationInstructionMiscFee this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionMiscFee)_al[i];
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

		public void Add(AllocationInstructionMiscFee item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionMiscFee item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionMiscFee Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionDlvyInst
	{
		private char _cSettlInstSource;
		private char _cDlvyInstType;
		private int _iNoSettlPartyIDs;
		private AllocationInstructionSettlPartyIDList _listSettlPartyID = new AllocationInstructionSettlPartyIDList();

		public char SettlInstSource
		{
			get { return _cSettlInstSource; }
			set { _cSettlInstSource = value; }
		}
		public char DlvyInstType
		{
			get { return _cDlvyInstType; }
			set { _cDlvyInstType = value; }
		}
		public int NoSettlPartyIDs
		{
			get { return _iNoSettlPartyIDs; }
			set { _iNoSettlPartyIDs = value; }
		}
		public AllocationInstructionSettlPartyIDList SettlPartyID 
		{
			get { return _listSettlPartyID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_SettlInstSource:
						return _cSettlInstSource;
					case AllocationInstruction.TAG_DlvyInstType:
						return _cDlvyInstType;
					case AllocationInstruction.TAG_NoSettlPartyIDs:
						return _iNoSettlPartyIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_SettlInstSource:
						_cSettlInstSource = (char)value;
						break;
					case AllocationInstruction.TAG_DlvyInstType:
						_cDlvyInstType = (char)value;
						break;
					case AllocationInstruction.TAG_NoSettlPartyIDs:
						_iNoSettlPartyIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionDlvyInstList
	{
		private ArrayList _al;
		private AllocationInstructionDlvyInst _last;

		public AllocationInstructionDlvyInst this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionDlvyInst)_al[i];
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

		public void Add(AllocationInstructionDlvyInst item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionDlvyInst item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionDlvyInst Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionSettlPartyID
	{
		private string _sSettlPartyID;
		private char _cSettlPartyIDSource;
		private int _iSettlPartyRole;
		private int _iNoSettlPartySubIDs;
		private AllocationInstructionSettlPartySubIDList _listSettlPartySubID = new AllocationInstructionSettlPartySubIDList();

		public string SettlPartyID
		{
			get { return _sSettlPartyID; }
			set { _sSettlPartyID = value; }
		}
		public char SettlPartyIDSource
		{
			get { return _cSettlPartyIDSource; }
			set { _cSettlPartyIDSource = value; }
		}
		public int SettlPartyRole
		{
			get { return _iSettlPartyRole; }
			set { _iSettlPartyRole = value; }
		}
		public int NoSettlPartySubIDs
		{
			get { return _iNoSettlPartySubIDs; }
			set { _iNoSettlPartySubIDs = value; }
		}
		public AllocationInstructionSettlPartySubIDList SettlPartySubID 
		{
			get { return _listSettlPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_SettlPartyID:
						return _sSettlPartyID;
					case AllocationInstruction.TAG_SettlPartyIDSource:
						return _cSettlPartyIDSource;
					case AllocationInstruction.TAG_SettlPartyRole:
						return _iSettlPartyRole;
					case AllocationInstruction.TAG_NoSettlPartySubIDs:
						return _iNoSettlPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_SettlPartyID:
						_sSettlPartyID = (string)value;
						break;
					case AllocationInstruction.TAG_SettlPartyIDSource:
						_cSettlPartyIDSource = (char)value;
						break;
					case AllocationInstruction.TAG_SettlPartyRole:
						_iSettlPartyRole = (int)value;
						break;
					case AllocationInstruction.TAG_NoSettlPartySubIDs:
						_iNoSettlPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionSettlPartyIDList
	{
		private ArrayList _al;
		private AllocationInstructionSettlPartyID _last;

		public AllocationInstructionSettlPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionSettlPartyID)_al[i];
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

		public void Add(AllocationInstructionSettlPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionSettlPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionSettlPartyID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionSettlPartySubID
	{
		private string _sSettlPartySubID;
		private int _iSettlPartySubIDType;

		public string SettlPartySubID
		{
			get { return _sSettlPartySubID; }
			set { _sSettlPartySubID = value; }
		}
		public int SettlPartySubIDType
		{
			get { return _iSettlPartySubIDType; }
			set { _iSettlPartySubIDType = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_SettlPartySubID:
						return _sSettlPartySubID;
					case AllocationInstruction.TAG_SettlPartySubIDType:
						return _iSettlPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstruction.TAG_SettlPartySubID:
						_sSettlPartySubID = (string)value;
						break;
					case AllocationInstruction.TAG_SettlPartySubIDType:
						_iSettlPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionSettlPartySubIDList
	{
		private ArrayList _al;
		private AllocationInstructionSettlPartySubID _last;

		public AllocationInstructionSettlPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionSettlPartySubID)_al[i];
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

		public void Add(AllocationInstructionSettlPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionSettlPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionSettlPartySubID Last
		{
			get { return _last; }
		}
	}
}
