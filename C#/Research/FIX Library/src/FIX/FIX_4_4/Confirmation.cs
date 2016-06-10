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
	/// Summary description for Confirmation.
	/// </summary>
	public class Confirmation : Message
	{
		public const int TAG_ConfirmID = 664;
		public const int TAG_ConfirmRefID = 772;
		public const int TAG_ConfirmReqID = 859;
		public const int TAG_ConfirmTransType = 666;
		public const int TAG_ConfirmType = 773;
		public const int TAG_CopyMsgIndicator = 797;
		public const int TAG_LegalConfirm = 650;
		public const int TAG_ConfirmStatus = 665;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
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
		public const int TAG_AllocID = 70;
		public const int TAG_SecondaryAllocID = 793;
		public const int TAG_IndividualAllocID = 467;
		public const int TAG_TransactTime = 60;
		public const int TAG_TradeDate = 75;
		public const int TAG_NoTrdRegTimestamps = 768;
		public const int TAG_TrdRegTimestamp = 769;
		public const int TAG_TrdRegTimestampType = 770;
		public const int TAG_TrdRegTimestampOrigin = 771;
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
		public const int TAG_YieldType = 235;
		public const int TAG_Yield = 236;
		public const int TAG_YieldCalcDate = 701;
		public const int TAG_YieldRedemptionDate = 696;
		public const int TAG_YieldRedemptionPrice = 697;
		public const int TAG_YieldRedemptionPriceType = 698;
		public const int TAG_AllocQty = 80;
		public const int TAG_QtyType = 854;
		public const int TAG_Side = 54;
		public const int TAG_Currency = 15;
		public const int TAG_LastMkt = 30;
		public const int TAG_NoCapacities = 862;
		public const int TAG_OrderCapacity = 528;
		public const int TAG_OrderRestrictions = 529;
		public const int TAG_OrderCapacityQty = 863;
		public const int TAG_AllocAccount = 79;
		public const int TAG_AllocAcctIDSource = 661;
		public const int TAG_AllocAccountType = 798;
		public const int TAG_AvgPx = 6;
		public const int TAG_AvgPxPrecision = 74;
		public const int TAG_PriceType = 423;
		public const int TAG_AvgParPx = 860;
		public const int TAG_Spread = 218;
		public const int TAG_BenchmarkCurveCurrency = 220;
		public const int TAG_BenchmarkCurveName = 221;
		public const int TAG_BenchmarkCurvePoint = 222;
		public const int TAG_BenchmarkPrice = 662;
		public const int TAG_BenchmarkPriceType = 663;
		public const int TAG_BenchmarkSecurityID = 699;
		public const int TAG_BenchmarkSecurityIDSource = 761;
		public const int TAG_ReportedPx = 861;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_ProcessCode = 81;
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
		public const int TAG_MaturityNetMoney = 890;
		public const int TAG_SettlCurrAmt = 119;
		public const int TAG_SettlCurrency = 120;
		public const int TAG_SettlCurrFxRate = 155;
		public const int TAG_SettlCurrFxRateCalc = 156;
		public const int TAG_SettlType = 63;
		public const int TAG_SettlDate = 64;
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
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_CommCurrency = 479;
		public const int TAG_FundRenewWaiv = 497;
		public const int TAG_SharedCommission = 858;
		public const int TAG_NoStipulations = 232;
		public const int TAG_StipulationType = 233;
		public const int TAG_StipulationValue = 234;
		public const int TAG_NoMiscFees = 136;
		public const int TAG_MiscFeeAmt = 137;
		public const int TAG_MiscFeeCurr = 138;
		public const int TAG_MiscFeeType = 139;
		public const int TAG_MiscFeeBasis = 891;

		private string _sConfirmID;
		private string _sConfirmRefID;
		private string _sConfirmReqID;
		private int _iConfirmTransType;
		private int _iConfirmType;
		private bool _bCopyMsgIndicator;
		private bool _bLegalConfirm;
		private int _iConfirmStatus;
		private int _iNoPartyIDs;
		private ConfirmationPartyIDList _listPartyID = new ConfirmationPartyIDList();
		private int _iNoOrders;
		private ConfirmationOrderList _listOrder = new ConfirmationOrderList();
		private string _sAllocID;
		private string _sSecondaryAllocID;
		private string _sIndividualAllocID;
		private DateTime _dtTransactTime;
		private DateTime _dtTradeDate;
		private int _iNoTrdRegTimestamps;
		private ConfirmationTrdRegTimestampList _listTrdRegTimestamp = new ConfirmationTrdRegTimestampList();
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private ConfirmationSecurityAltIDList _listSecurityAltID = new ConfirmationSecurityAltIDList();
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
		private ConfirmationEventList _listEvent = new ConfirmationEventList();
		private DateTime _dtDatedDate;
		private DateTime _dtInterestAccrualDate;
		private int _iDeliveryForm;
		private double _dPctAtRisk;
		private int _iNoInstrAttrib;
		private ConfirmationInstrAttribList _listInstrAttrib = new ConfirmationInstrAttribList();
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
		private ConfirmationUnderlyingList _listUnderlying = new ConfirmationUnderlyingList();
		private int _iNoLegs;
		private ConfirmationLegList _listLeg = new ConfirmationLegList();
		private string _sYieldType;
		private double _dYield;
		private DateTime _dtYieldCalcDate;
		private DateTime _dtYieldRedemptionDate;
		private double _dYieldRedemptionPrice;
		private int _iYieldRedemptionPriceType;
		private int _iAllocQty;
		private int _iQtyType;
		private char _cSide;
		private string _sCurrency;
		private string _sLastMkt;
		private int _iNoCapacities;
		private ConfirmationCapacitieList _listCapacitie = new ConfirmationCapacitieList();
		private string _sAllocAccount;
		private int _iAllocAcctIDSource;
		private int _iAllocAccountType;
		private double _dAvgPx;
		private int _iAvgPxPrecision;
		private int _iPriceType;
		private double _dAvgParPx;
		private double _dSpread;
		private string _sBenchmarkCurveCurrency;
		private string _sBenchmarkCurveName;
		private string _sBenchmarkCurvePoint;
		private double _dBenchmarkPrice;
		private int _iBenchmarkPriceType;
		private string _sBenchmarkSecurityID;
		private string _sBenchmarkSecurityIDSource;
		private double _dReportedPx;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private char _cProcessCode;
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
		private double _dMaturityNetMoney;
		private double _dSettlCurrAmt;
		private string _sSettlCurrency;
		private double _dSettlCurrFxRate;
		private char _cSettlCurrFxRateCalc;
		private char _cSettlType;
		private DateTime _dtSettlDate;
		private int _iSettlDeliveryType;
		private int _iStandInstDbType;
		private string _sStandInstDbName;
		private string _sStandInstDbID;
		private int _iNoDlvyInst;
		private ConfirmationDlvyInstList _listDlvyInst = new ConfirmationDlvyInstList();
		private double _dCommission;
		private char _cCommType;
		private string _sCommCurrency;
		private char _cFundRenewWaiv;
		private double _dSharedCommission;
		private int _iNoStipulations;
		private ConfirmationStipulationList _listStipulation = new ConfirmationStipulationList();
		private int _iNoMiscFees;
		private ConfirmationMiscFeeList _listMiscFee = new ConfirmationMiscFeeList();

		public Confirmation() : base()
		{
			_sMsgType = Values.MsgType.Confirmation;
		}

		public string ConfirmID
		{
			get { return _sConfirmID; }
			set { _sConfirmID = value; }
		}
		public string ConfirmRefID
		{
			get { return _sConfirmRefID; }
			set { _sConfirmRefID = value; }
		}
		public string ConfirmReqID
		{
			get { return _sConfirmReqID; }
			set { _sConfirmReqID = value; }
		}
		public int ConfirmTransType
		{
			get { return _iConfirmTransType; }
			set { _iConfirmTransType = value; }
		}
		public int ConfirmType
		{
			get { return _iConfirmType; }
			set { _iConfirmType = value; }
		}
		public bool CopyMsgIndicator
		{
			get { return _bCopyMsgIndicator; }
			set { _bCopyMsgIndicator = value; }
		}
		public bool LegalConfirm
		{
			get { return _bLegalConfirm; }
			set { _bLegalConfirm = value; }
		}
		public int ConfirmStatus
		{
			get { return _iConfirmStatus; }
			set { _iConfirmStatus = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public ConfirmationPartyIDList PartyID 
		{
			get { return _listPartyID; }
		}
		public int NoOrders
		{
			get { return _iNoOrders; }
			set { _iNoOrders = value; }
		}
		public ConfirmationOrderList Order 
		{
			get { return _listOrder; }
		}
		public string AllocID
		{
			get { return _sAllocID; }
			set { _sAllocID = value; }
		}
		public string SecondaryAllocID
		{
			get { return _sSecondaryAllocID; }
			set { _sSecondaryAllocID = value; }
		}
		public string IndividualAllocID
		{
			get { return _sIndividualAllocID; }
			set { _sIndividualAllocID = value; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public DateTime TradeDate
		{
			get { return _dtTradeDate; }
			set { _dtTradeDate = value; }
		}
		public int NoTrdRegTimestamps
		{
			get { return _iNoTrdRegTimestamps; }
			set { _iNoTrdRegTimestamps = value; }
		}
		public ConfirmationTrdRegTimestampList TrdRegTimestamp 
		{
			get { return _listTrdRegTimestamp; }
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
		public ConfirmationSecurityAltIDList SecurityAltID 
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
		public ConfirmationEventList Event 
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
		public ConfirmationInstrAttribList InstrAttrib 
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
		public ConfirmationUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
		}
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public ConfirmationLegList Leg 
		{
			get { return _listLeg; }
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
		public int AllocQty
		{
			get { return _iAllocQty; }
			set { _iAllocQty = value; }
		}
		public int QtyType
		{
			get { return _iQtyType; }
			set { _iQtyType = value; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
		}
		public string Currency
		{
			get { return _sCurrency; }
			set { _sCurrency = value; }
		}
		public string LastMkt
		{
			get { return _sLastMkt; }
			set { _sLastMkt = value; }
		}
		public int NoCapacities
		{
			get { return _iNoCapacities; }
			set { _iNoCapacities = value; }
		}
		public ConfirmationCapacitieList Capacitie 
		{
			get { return _listCapacitie; }
		}
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
		public int AllocAccountType
		{
			get { return _iAllocAccountType; }
			set { _iAllocAccountType = value; }
		}
		public double AvgPx
		{
			get { return _dAvgPx; }
			set { _dAvgPx = value; }
		}
		public int AvgPxPrecision
		{
			get { return _iAvgPxPrecision; }
			set { _iAvgPxPrecision = value; }
		}
		public int PriceType
		{
			get { return _iPriceType; }
			set { _iPriceType = value; }
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
		public double ReportedPx
		{
			get { return _dReportedPx; }
			set { _dReportedPx = value; }
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
		public char ProcessCode
		{
			get { return _cProcessCode; }
			set { _cProcessCode = value; }
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
		public double MaturityNetMoney
		{
			get { return _dMaturityNetMoney; }
			set { _dMaturityNetMoney = value; }
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
		public ConfirmationDlvyInstList DlvyInst 
		{
			get { return _listDlvyInst; }
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
		public double SharedCommission
		{
			get { return _dSharedCommission; }
			set { _dSharedCommission = value; }
		}
		public int NoStipulations
		{
			get { return _iNoStipulations; }
			set { _iNoStipulations = value; }
		}
		public ConfirmationStipulationList Stipulation 
		{
			get { return _listStipulation; }
		}
		public int NoMiscFees
		{
			get { return _iNoMiscFees; }
			set { _iNoMiscFees = value; }
		}
		public ConfirmationMiscFeeList MiscFee 
		{
			get { return _listMiscFee; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_ConfirmID:
						return _sConfirmID;
					case TAG_ConfirmRefID:
						return _sConfirmRefID;
					case TAG_ConfirmReqID:
						return _sConfirmReqID;
					case TAG_ConfirmTransType:
						return _iConfirmTransType;
					case TAG_ConfirmType:
						return _iConfirmType;
					case TAG_CopyMsgIndicator:
						return _bCopyMsgIndicator;
					case TAG_LegalConfirm:
						return _bLegalConfirm;
					case TAG_ConfirmStatus:
						return _iConfirmStatus;
					case TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case TAG_NoOrders:
						return _iNoOrders;
					case TAG_AllocID:
						return _sAllocID;
					case TAG_SecondaryAllocID:
						return _sSecondaryAllocID;
					case TAG_IndividualAllocID:
						return _sIndividualAllocID;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_TradeDate:
						return _dtTradeDate;
					case TAG_NoTrdRegTimestamps:
						return _iNoTrdRegTimestamps;
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
					case TAG_AllocQty:
						return _iAllocQty;
					case TAG_QtyType:
						return _iQtyType;
					case TAG_Side:
						return _cSide;
					case TAG_Currency:
						return _sCurrency;
					case TAG_LastMkt:
						return _sLastMkt;
					case TAG_NoCapacities:
						return _iNoCapacities;
					case TAG_AllocAccount:
						return _sAllocAccount;
					case TAG_AllocAcctIDSource:
						return _iAllocAcctIDSource;
					case TAG_AllocAccountType:
						return _iAllocAccountType;
					case TAG_AvgPx:
						return _dAvgPx;
					case TAG_AvgPxPrecision:
						return _iAvgPxPrecision;
					case TAG_PriceType:
						return _iPriceType;
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
					case TAG_ReportedPx:
						return _dReportedPx;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
					case TAG_ProcessCode:
						return _cProcessCode;
					case TAG_GrossTradeAmt:
						return _dGrossTradeAmt;
					case TAG_NumDaysInterest:
						return _iNumDaysInterest;
					case TAG_ExDate:
						return _dtExDate;
					case TAG_AccruedInterestRate:
						return _dAccruedInterestRate;
					case TAG_AccruedInterestAmt:
						return _dAccruedInterestAmt;
					case TAG_InterestAtMaturity:
						return _dInterestAtMaturity;
					case TAG_EndAccruedInterestAmt:
						return _dEndAccruedInterestAmt;
					case TAG_StartCash:
						return _dStartCash;
					case TAG_EndCash:
						return _dEndCash;
					case TAG_Concession:
						return _dConcession;
					case TAG_TotalTakedown:
						return _dTotalTakedown;
					case TAG_NetMoney:
						return _dNetMoney;
					case TAG_MaturityNetMoney:
						return _dMaturityNetMoney;
					case TAG_SettlCurrAmt:
						return _dSettlCurrAmt;
					case TAG_SettlCurrency:
						return _sSettlCurrency;
					case TAG_SettlCurrFxRate:
						return _dSettlCurrFxRate;
					case TAG_SettlCurrFxRateCalc:
						return _cSettlCurrFxRateCalc;
					case TAG_SettlType:
						return _cSettlType;
					case TAG_SettlDate:
						return _dtSettlDate;
					case TAG_SettlDeliveryType:
						return _iSettlDeliveryType;
					case TAG_StandInstDbType:
						return _iStandInstDbType;
					case TAG_StandInstDbName:
						return _sStandInstDbName;
					case TAG_StandInstDbID:
						return _sStandInstDbID;
					case TAG_NoDlvyInst:
						return _iNoDlvyInst;
					case TAG_Commission:
						return _dCommission;
					case TAG_CommType:
						return _cCommType;
					case TAG_CommCurrency:
						return _sCommCurrency;
					case TAG_FundRenewWaiv:
						return _cFundRenewWaiv;
					case TAG_SharedCommission:
						return _dSharedCommission;
					case TAG_NoStipulations:
						return _iNoStipulations;
					case TAG_NoMiscFees:
						return _iNoMiscFees;
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
					case TAG_ConfirmRefID:
						_sConfirmRefID = (string)value;
						break;
					case TAG_ConfirmReqID:
						_sConfirmReqID = (string)value;
						break;
					case TAG_ConfirmTransType:
						_iConfirmTransType = (int)value;
						break;
					case TAG_ConfirmType:
						_iConfirmType = (int)value;
						break;
					case TAG_CopyMsgIndicator:
						_bCopyMsgIndicator = (bool)value;
						break;
					case TAG_LegalConfirm:
						_bLegalConfirm = (bool)value;
						break;
					case TAG_ConfirmStatus:
						_iConfirmStatus = (int)value;
						break;
					case TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case TAG_NoOrders:
						_iNoOrders = (int)value;
						break;
					case TAG_AllocID:
						_sAllocID = (string)value;
						break;
					case TAG_SecondaryAllocID:
						_sSecondaryAllocID = (string)value;
						break;
					case TAG_IndividualAllocID:
						_sIndividualAllocID = (string)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case TAG_NoTrdRegTimestamps:
						_iNoTrdRegTimestamps = (int)value;
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
					case TAG_AllocQty:
						_iAllocQty = (int)value;
						break;
					case TAG_QtyType:
						_iQtyType = (int)value;
						break;
					case TAG_Side:
						_cSide = (char)value;
						break;
					case TAG_Currency:
						_sCurrency = (string)value;
						break;
					case TAG_LastMkt:
						_sLastMkt = (string)value;
						break;
					case TAG_NoCapacities:
						_iNoCapacities = (int)value;
						break;
					case TAG_AllocAccount:
						_sAllocAccount = (string)value;
						break;
					case TAG_AllocAcctIDSource:
						_iAllocAcctIDSource = (int)value;
						break;
					case TAG_AllocAccountType:
						_iAllocAccountType = (int)value;
						break;
					case TAG_AvgPx:
						_dAvgPx = (double)value;
						break;
					case TAG_AvgPxPrecision:
						_iAvgPxPrecision = (int)value;
						break;
					case TAG_PriceType:
						_iPriceType = (int)value;
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
					case TAG_ReportedPx:
						_dReportedPx = (double)value;
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
					case TAG_ProcessCode:
						_cProcessCode = (char)value;
						break;
					case TAG_GrossTradeAmt:
						_dGrossTradeAmt = (double)value;
						break;
					case TAG_NumDaysInterest:
						_iNumDaysInterest = (int)value;
						break;
					case TAG_ExDate:
						_dtExDate = (DateTime)value;
						break;
					case TAG_AccruedInterestRate:
						_dAccruedInterestRate = (double)value;
						break;
					case TAG_AccruedInterestAmt:
						_dAccruedInterestAmt = (double)value;
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
					case TAG_Concession:
						_dConcession = (double)value;
						break;
					case TAG_TotalTakedown:
						_dTotalTakedown = (double)value;
						break;
					case TAG_NetMoney:
						_dNetMoney = (double)value;
						break;
					case TAG_MaturityNetMoney:
						_dMaturityNetMoney = (double)value;
						break;
					case TAG_SettlCurrAmt:
						_dSettlCurrAmt = (double)value;
						break;
					case TAG_SettlCurrency:
						_sSettlCurrency = (string)value;
						break;
					case TAG_SettlCurrFxRate:
						_dSettlCurrFxRate = (double)value;
						break;
					case TAG_SettlCurrFxRateCalc:
						_cSettlCurrFxRateCalc = (char)value;
						break;
					case TAG_SettlType:
						_cSettlType = (char)value;
						break;
					case TAG_SettlDate:
						_dtSettlDate = (DateTime)value;
						break;
					case TAG_SettlDeliveryType:
						_iSettlDeliveryType = (int)value;
						break;
					case TAG_StandInstDbType:
						_iStandInstDbType = (int)value;
						break;
					case TAG_StandInstDbName:
						_sStandInstDbName = (string)value;
						break;
					case TAG_StandInstDbID:
						_sStandInstDbID = (string)value;
						break;
					case TAG_NoDlvyInst:
						_iNoDlvyInst = (int)value;
						break;
					case TAG_Commission:
						_dCommission = (double)value;
						break;
					case TAG_CommType:
						_cCommType = (char)value;
						break;
					case TAG_CommCurrency:
						_sCommCurrency = (string)value;
						break;
					case TAG_FundRenewWaiv:
						_cFundRenewWaiv = (char)value;
						break;
					case TAG_SharedCommission:
						_dSharedCommission = (double)value;
						break;
					case TAG_NoStipulations:
						_iNoStipulations = (int)value;
						break;
					case TAG_NoMiscFees:
						_iNoMiscFees = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class ConfirmationPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private ConfirmationPartySubIDList _listPartySubID = new ConfirmationPartySubIDList();

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
		public ConfirmationPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case Confirmation.TAG_PartyID:
						return _sPartyID;
					case Confirmation.TAG_PartyIDSource:
						return _cPartyIDSource;
					case Confirmation.TAG_PartyRole:
						return _iPartyRole;
					case Confirmation.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case Confirmation.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case Confirmation.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case Confirmation.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationPartyIDList
	{
		private ArrayList _al;
		private ConfirmationPartyID _last;

		public ConfirmationPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationPartyID)_al[i];
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

		public void Add(ConfirmationPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationPartyID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationPartySubID
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
					case Confirmation.TAG_PartySubID:
						return _sPartySubID;
					case Confirmation.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case Confirmation.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationPartySubIDList
	{
		private ArrayList _al;
		private ConfirmationPartySubID _last;

		public ConfirmationPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationPartySubID)_al[i];
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

		public void Add(ConfirmationPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationPartySubID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationOrder
	{
		private string _sClOrdID;
		private string _sOrderID;
		private string _sSecondaryOrderID;
		private string _sSecondaryClOrdID;
		private string _sListID;
		private int _iNoNested2PartyIDs;
		private ConfirmationNested2PartyIDList _listNested2PartyID = new ConfirmationNested2PartyIDList();
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
		public ConfirmationNested2PartyIDList Nested2PartyID 
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
					case Confirmation.TAG_ClOrdID:
						return _sClOrdID;
					case Confirmation.TAG_OrderID:
						return _sOrderID;
					case Confirmation.TAG_SecondaryOrderID:
						return _sSecondaryOrderID;
					case Confirmation.TAG_SecondaryClOrdID:
						return _sSecondaryClOrdID;
					case Confirmation.TAG_ListID:
						return _sListID;
					case Confirmation.TAG_NoNested2PartyIDs:
						return _iNoNested2PartyIDs;
					case Confirmation.TAG_OrderQty:
						return _iOrderQty;
					case Confirmation.TAG_OrderAvgPx:
						return _dOrderAvgPx;
					case Confirmation.TAG_OrderBookingQty:
						return _iOrderBookingQty;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case Confirmation.TAG_OrderID:
						_sOrderID = (string)value;
						break;
					case Confirmation.TAG_SecondaryOrderID:
						_sSecondaryOrderID = (string)value;
						break;
					case Confirmation.TAG_SecondaryClOrdID:
						_sSecondaryClOrdID = (string)value;
						break;
					case Confirmation.TAG_ListID:
						_sListID = (string)value;
						break;
					case Confirmation.TAG_NoNested2PartyIDs:
						_iNoNested2PartyIDs = (int)value;
						break;
					case Confirmation.TAG_OrderQty:
						_iOrderQty = (int)value;
						break;
					case Confirmation.TAG_OrderAvgPx:
						_dOrderAvgPx = (double)value;
						break;
					case Confirmation.TAG_OrderBookingQty:
						_iOrderBookingQty = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationOrderList
	{
		private ArrayList _al;
		private ConfirmationOrder _last;

		public ConfirmationOrder this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationOrder)_al[i];
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

		public void Add(ConfirmationOrder item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationOrder item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationOrder Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationNested2PartyID
	{
		private string _sNested2PartyID;
		private char _cNested2PartyIDSource;
		private int _iNested2PartyRole;
		private int _iNoNested2PartySubIDs;
		private ConfirmationNested2PartySubIDList _listNested2PartySubID = new ConfirmationNested2PartySubIDList();

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
		public ConfirmationNested2PartySubIDList Nested2PartySubID 
		{
			get { return _listNested2PartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case Confirmation.TAG_Nested2PartyID:
						return _sNested2PartyID;
					case Confirmation.TAG_Nested2PartyIDSource:
						return _cNested2PartyIDSource;
					case Confirmation.TAG_Nested2PartyRole:
						return _iNested2PartyRole;
					case Confirmation.TAG_NoNested2PartySubIDs:
						return _iNoNested2PartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_Nested2PartyID:
						_sNested2PartyID = (string)value;
						break;
					case Confirmation.TAG_Nested2PartyIDSource:
						_cNested2PartyIDSource = (char)value;
						break;
					case Confirmation.TAG_Nested2PartyRole:
						_iNested2PartyRole = (int)value;
						break;
					case Confirmation.TAG_NoNested2PartySubIDs:
						_iNoNested2PartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationNested2PartyIDList
	{
		private ArrayList _al;
		private ConfirmationNested2PartyID _last;

		public ConfirmationNested2PartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationNested2PartyID)_al[i];
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

		public void Add(ConfirmationNested2PartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationNested2PartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationNested2PartyID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationNested2PartySubID
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
					case Confirmation.TAG_Nested2PartySubID:
						return _sNested2PartySubID;
					case Confirmation.TAG_Nested2PartySubIDType:
						return _iNested2PartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_Nested2PartySubID:
						_sNested2PartySubID = (string)value;
						break;
					case Confirmation.TAG_Nested2PartySubIDType:
						_iNested2PartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationNested2PartySubIDList
	{
		private ArrayList _al;
		private ConfirmationNested2PartySubID _last;

		public ConfirmationNested2PartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationNested2PartySubID)_al[i];
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

		public void Add(ConfirmationNested2PartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationNested2PartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationNested2PartySubID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationTrdRegTimestamp
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
					case Confirmation.TAG_TrdRegTimestamp:
						return _dtTrdRegTimestamp;
					case Confirmation.TAG_TrdRegTimestampType:
						return _iTrdRegTimestampType;
					case Confirmation.TAG_TrdRegTimestampOrigin:
						return _sTrdRegTimestampOrigin;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_TrdRegTimestamp:
						_dtTrdRegTimestamp = (DateTime)value;
						break;
					case Confirmation.TAG_TrdRegTimestampType:
						_iTrdRegTimestampType = (int)value;
						break;
					case Confirmation.TAG_TrdRegTimestampOrigin:
						_sTrdRegTimestampOrigin = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationTrdRegTimestampList
	{
		private ArrayList _al;
		private ConfirmationTrdRegTimestamp _last;

		public ConfirmationTrdRegTimestamp this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationTrdRegTimestamp)_al[i];
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

		public void Add(ConfirmationTrdRegTimestamp item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationTrdRegTimestamp item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationTrdRegTimestamp Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationSecurityAltID
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
					case Confirmation.TAG_SecurityAltID:
						return _sSecurityAltID;
					case Confirmation.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case Confirmation.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationSecurityAltIDList
	{
		private ArrayList _al;
		private ConfirmationSecurityAltID _last;

		public ConfirmationSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationSecurityAltID)_al[i];
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

		public void Add(ConfirmationSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationEvent
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
					case Confirmation.TAG_EventType:
						return _iEventType;
					case Confirmation.TAG_EventDate:
						return _dtEventDate;
					case Confirmation.TAG_EventPx:
						return _dEventPx;
					case Confirmation.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_EventType:
						_iEventType = (int)value;
						break;
					case Confirmation.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case Confirmation.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case Confirmation.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationEventList
	{
		private ArrayList _al;
		private ConfirmationEvent _last;

		public ConfirmationEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationEvent)_al[i];
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

		public void Add(ConfirmationEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationEvent Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationInstrAttrib
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
					case Confirmation.TAG_InstrAttribType:
						return _iInstrAttribType;
					case Confirmation.TAG_InstrAttribValue:
						return _sInstrAttribValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_InstrAttribType:
						_iInstrAttribType = (int)value;
						break;
					case Confirmation.TAG_InstrAttribValue:
						_sInstrAttribValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationInstrAttribList
	{
		private ArrayList _al;
		private ConfirmationInstrAttrib _last;

		public ConfirmationInstrAttrib this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationInstrAttrib)_al[i];
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

		public void Add(ConfirmationInstrAttrib item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationInstrAttrib item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationInstrAttrib Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private ConfirmationUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new ConfirmationUnderlyingSecurityAltIDList();
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
		public ConfirmationUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
					case Confirmation.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case Confirmation.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case Confirmation.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case Confirmation.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case Confirmation.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case Confirmation.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case Confirmation.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case Confirmation.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case Confirmation.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case Confirmation.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case Confirmation.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case Confirmation.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case Confirmation.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case Confirmation.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case Confirmation.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case Confirmation.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case Confirmation.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case Confirmation.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case Confirmation.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case Confirmation.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case Confirmation.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case Confirmation.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case Confirmation.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case Confirmation.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case Confirmation.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case Confirmation.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case Confirmation.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case Confirmation.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case Confirmation.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case Confirmation.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case Confirmation.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case Confirmation.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case Confirmation.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case Confirmation.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case Confirmation.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case Confirmation.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case Confirmation.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case Confirmation.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case Confirmation.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case Confirmation.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case Confirmation.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case Confirmation.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case Confirmation.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case Confirmation.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case Confirmation.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case Confirmation.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case Confirmation.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case Confirmation.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case Confirmation.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case Confirmation.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case Confirmation.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case Confirmation.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case Confirmation.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case Confirmation.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case Confirmation.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case Confirmation.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case Confirmation.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case Confirmation.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case Confirmation.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case Confirmation.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case Confirmation.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case Confirmation.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case Confirmation.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case Confirmation.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case Confirmation.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case Confirmation.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case Confirmation.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case Confirmation.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case Confirmation.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case Confirmation.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case Confirmation.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case Confirmation.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case Confirmation.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case Confirmation.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case Confirmation.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case Confirmation.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case Confirmation.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case Confirmation.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case Confirmation.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case Confirmation.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case Confirmation.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case Confirmation.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case Confirmation.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case Confirmation.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case Confirmation.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case Confirmation.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case Confirmation.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case Confirmation.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case Confirmation.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationUnderlyingList
	{
		private ArrayList _al;
		private ConfirmationUnderlying _last;

		public ConfirmationUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationUnderlying)_al[i];
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

		public void Add(ConfirmationUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationUnderlying Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationUnderlyingSecurityAltID
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
					case Confirmation.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case Confirmation.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case Confirmation.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private ConfirmationUnderlyingSecurityAltID _last;

		public ConfirmationUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationUnderlyingSecurityAltID)_al[i];
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

		public void Add(ConfirmationUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private ConfirmationLegSecurityAltIDList _listLegSecurityAltID = new ConfirmationLegSecurityAltIDList();
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
		public ConfirmationLegSecurityAltIDList LegSecurityAltID 
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
					case Confirmation.TAG_LegSymbol:
						return _sLegSymbol;
					case Confirmation.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case Confirmation.TAG_LegSecurityID:
						return _sLegSecurityID;
					case Confirmation.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case Confirmation.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case Confirmation.TAG_LegProduct:
						return _iLegProduct;
					case Confirmation.TAG_LegCFICode:
						return _sLegCFICode;
					case Confirmation.TAG_LegSecurityType:
						return _sLegSecurityType;
					case Confirmation.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case Confirmation.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case Confirmation.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case Confirmation.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case Confirmation.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case Confirmation.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case Confirmation.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case Confirmation.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case Confirmation.TAG_LegFactor:
						return _dLegFactor;
					case Confirmation.TAG_LegCreditRating:
						return _sLegCreditRating;
					case Confirmation.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case Confirmation.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case Confirmation.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case Confirmation.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case Confirmation.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case Confirmation.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case Confirmation.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case Confirmation.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case Confirmation.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case Confirmation.TAG_LegCouponRate:
						return _dLegCouponRate;
					case Confirmation.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case Confirmation.TAG_LegIssuer:
						return _sLegIssuer;
					case Confirmation.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case Confirmation.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case Confirmation.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case Confirmation.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case Confirmation.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case Confirmation.TAG_LegRatioQty:
						return _dLegRatioQty;
					case Confirmation.TAG_LegSide:
						return _cLegSide;
					case Confirmation.TAG_LegCurrency:
						return _sLegCurrency;
					case Confirmation.TAG_LegPool:
						return _sLegPool;
					case Confirmation.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case Confirmation.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case Confirmation.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case Confirmation.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case Confirmation.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case Confirmation.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case Confirmation.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case Confirmation.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case Confirmation.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case Confirmation.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case Confirmation.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case Confirmation.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case Confirmation.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case Confirmation.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case Confirmation.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case Confirmation.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case Confirmation.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case Confirmation.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case Confirmation.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case Confirmation.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case Confirmation.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case Confirmation.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case Confirmation.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case Confirmation.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case Confirmation.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case Confirmation.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case Confirmation.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case Confirmation.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case Confirmation.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case Confirmation.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case Confirmation.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case Confirmation.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case Confirmation.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case Confirmation.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case Confirmation.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case Confirmation.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case Confirmation.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case Confirmation.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case Confirmation.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case Confirmation.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case Confirmation.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case Confirmation.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case Confirmation.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case Confirmation.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationLegList
	{
		private ArrayList _al;
		private ConfirmationLeg _last;

		public ConfirmationLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationLeg)_al[i];
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

		public void Add(ConfirmationLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationLeg Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationLegSecurityAltID
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
					case Confirmation.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case Confirmation.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case Confirmation.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationLegSecurityAltIDList
	{
		private ArrayList _al;
		private ConfirmationLegSecurityAltID _last;

		public ConfirmationLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationLegSecurityAltID)_al[i];
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

		public void Add(ConfirmationLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationLegSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationCapacitie
	{
		private char _cOrderCapacity;
		private string _sOrderRestrictions;
		private int _iOrderCapacityQty;

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
		public int OrderCapacityQty
		{
			get { return _iOrderCapacityQty; }
			set { _iOrderCapacityQty = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case Confirmation.TAG_OrderCapacity:
						return _cOrderCapacity;
					case Confirmation.TAG_OrderRestrictions:
						return _sOrderRestrictions;
					case Confirmation.TAG_OrderCapacityQty:
						return _iOrderCapacityQty;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_OrderCapacity:
						_cOrderCapacity = (char)value;
						break;
					case Confirmation.TAG_OrderRestrictions:
						_sOrderRestrictions = (string)value;
						break;
					case Confirmation.TAG_OrderCapacityQty:
						_iOrderCapacityQty = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationCapacitieList
	{
		private ArrayList _al;
		private ConfirmationCapacitie _last;

		public ConfirmationCapacitie this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationCapacitie)_al[i];
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

		public void Add(ConfirmationCapacitie item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationCapacitie item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationCapacitie Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationDlvyInst
	{
		private char _cSettlInstSource;
		private char _cDlvyInstType;
		private int _iNoSettlPartyIDs;
		private ConfirmationSettlPartyIDList _listSettlPartyID = new ConfirmationSettlPartyIDList();

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
		public ConfirmationSettlPartyIDList SettlPartyID 
		{
			get { return _listSettlPartyID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case Confirmation.TAG_SettlInstSource:
						return _cSettlInstSource;
					case Confirmation.TAG_DlvyInstType:
						return _cDlvyInstType;
					case Confirmation.TAG_NoSettlPartyIDs:
						return _iNoSettlPartyIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_SettlInstSource:
						_cSettlInstSource = (char)value;
						break;
					case Confirmation.TAG_DlvyInstType:
						_cDlvyInstType = (char)value;
						break;
					case Confirmation.TAG_NoSettlPartyIDs:
						_iNoSettlPartyIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationDlvyInstList
	{
		private ArrayList _al;
		private ConfirmationDlvyInst _last;

		public ConfirmationDlvyInst this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationDlvyInst)_al[i];
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

		public void Add(ConfirmationDlvyInst item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationDlvyInst item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationDlvyInst Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationSettlPartyID
	{
		private string _sSettlPartyID;
		private char _cSettlPartyIDSource;
		private int _iSettlPartyRole;
		private int _iNoSettlPartySubIDs;
		private ConfirmationSettlPartySubIDList _listSettlPartySubID = new ConfirmationSettlPartySubIDList();

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
		public ConfirmationSettlPartySubIDList SettlPartySubID 
		{
			get { return _listSettlPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case Confirmation.TAG_SettlPartyID:
						return _sSettlPartyID;
					case Confirmation.TAG_SettlPartyIDSource:
						return _cSettlPartyIDSource;
					case Confirmation.TAG_SettlPartyRole:
						return _iSettlPartyRole;
					case Confirmation.TAG_NoSettlPartySubIDs:
						return _iNoSettlPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_SettlPartyID:
						_sSettlPartyID = (string)value;
						break;
					case Confirmation.TAG_SettlPartyIDSource:
						_cSettlPartyIDSource = (char)value;
						break;
					case Confirmation.TAG_SettlPartyRole:
						_iSettlPartyRole = (int)value;
						break;
					case Confirmation.TAG_NoSettlPartySubIDs:
						_iNoSettlPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationSettlPartyIDList
	{
		private ArrayList _al;
		private ConfirmationSettlPartyID _last;

		public ConfirmationSettlPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationSettlPartyID)_al[i];
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

		public void Add(ConfirmationSettlPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationSettlPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationSettlPartyID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationSettlPartySubID
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
					case Confirmation.TAG_SettlPartySubID:
						return _sSettlPartySubID;
					case Confirmation.TAG_SettlPartySubIDType:
						return _iSettlPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_SettlPartySubID:
						_sSettlPartySubID = (string)value;
						break;
					case Confirmation.TAG_SettlPartySubIDType:
						_iSettlPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationSettlPartySubIDList
	{
		private ArrayList _al;
		private ConfirmationSettlPartySubID _last;

		public ConfirmationSettlPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationSettlPartySubID)_al[i];
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

		public void Add(ConfirmationSettlPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationSettlPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationSettlPartySubID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationStipulation
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
					case Confirmation.TAG_StipulationType:
						return _sStipulationType;
					case Confirmation.TAG_StipulationValue:
						return _sStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_StipulationType:
						_sStipulationType = (string)value;
						break;
					case Confirmation.TAG_StipulationValue:
						_sStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationStipulationList
	{
		private ArrayList _al;
		private ConfirmationStipulation _last;

		public ConfirmationStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationStipulation)_al[i];
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

		public void Add(ConfirmationStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationStipulation Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationMiscFee
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
					case Confirmation.TAG_MiscFeeAmt:
						return _dMiscFeeAmt;
					case Confirmation.TAG_MiscFeeCurr:
						return _sMiscFeeCurr;
					case Confirmation.TAG_MiscFeeType:
						return _cMiscFeeType;
					case Confirmation.TAG_MiscFeeBasis:
						return _iMiscFeeBasis;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case Confirmation.TAG_MiscFeeAmt:
						_dMiscFeeAmt = (double)value;
						break;
					case Confirmation.TAG_MiscFeeCurr:
						_sMiscFeeCurr = (string)value;
						break;
					case Confirmation.TAG_MiscFeeType:
						_cMiscFeeType = (char)value;
						break;
					case Confirmation.TAG_MiscFeeBasis:
						_iMiscFeeBasis = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationMiscFeeList
	{
		private ArrayList _al;
		private ConfirmationMiscFee _last;

		public ConfirmationMiscFee this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationMiscFee)_al[i];
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

		public void Add(ConfirmationMiscFee item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationMiscFee item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationMiscFee Last
		{
			get { return _last; }
		}
	}
}
