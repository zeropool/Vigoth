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
	/// Summary description for QuoteStatusReport.
	/// </summary>
	public class QuoteStatusReport : Message
	{
		public const int TAG_QuoteStatusReqID = 649;
		public const int TAG_QuoteReqID = 131;
		public const int TAG_QuoteID = 117;
		public const int TAG_QuoteRespID = 693;
		public const int TAG_QuoteType = 537;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
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
		public const int TAG_Side = 54;
		public const int TAG_OrderQty = 38;
		public const int TAG_CashOrderQty = 152;
		public const int TAG_OrderPercent = 516;
		public const int TAG_RoundingDirection = 468;
		public const int TAG_RoundingModulus = 469;
		public const int TAG_SettlType = 63;
		public const int TAG_SettlDate = 64;
		public const int TAG_SettlDate2 = 193;
		public const int TAG_OrderQty2 = 192;
		public const int TAG_Currency = 15;
		public const int TAG_NoStipulations = 232;
		public const int TAG_StipulationType = 233;
		public const int TAG_StipulationValue = 234;
		public const int TAG_Account = 1;
		public const int TAG_AcctIDSource = 660;
		public const int TAG_AccountType = 581;
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
		public const int TAG_LegSettlType = 587;
		public const int TAG_LegSettlDate = 588;
		public const int TAG_NoLegStipulations = 683;
		public const int TAG_LegStipulationType = 688;
		public const int TAG_LegStipulationValue = 689;
		public const int TAG_NoNestedPartyIDs = 539;
		public const int TAG_NestedPartyID = 524;
		public const int TAG_NestedPartyIDSource = 525;
		public const int TAG_NestedPartyRole = 538;
		public const int TAG_NoNestedPartySubIDs = 804;
		public const int TAG_NestedPartySubID = 545;
		public const int TAG_NestedPartySubIDType = 805;
		public const int TAG_NoQuoteQualifiers = 735;
		public const int TAG_QuoteQualifier = 695;
		public const int TAG_ExpireTime = 126;
		public const int TAG_Price = 44;
		public const int TAG_PriceType = 423;
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
		public const int TAG_BidPx = 132;
		public const int TAG_OfferPx = 133;
		public const int TAG_MktBidPx = 645;
		public const int TAG_MktOfferPx = 646;
		public const int TAG_MinBidSize = 647;
		public const int TAG_BidSize = 134;
		public const int TAG_MinOfferSize = 648;
		public const int TAG_OfferSize = 135;
		public const int TAG_ValidUntilTime = 62;
		public const int TAG_BidSpotRate = 188;
		public const int TAG_OfferSpotRate = 190;
		public const int TAG_BidForwardPoints = 189;
		public const int TAG_OfferForwardPoints = 191;
		public const int TAG_MidPx = 631;
		public const int TAG_BidYield = 632;
		public const int TAG_MidYield = 633;
		public const int TAG_OfferYield = 634;
		public const int TAG_TransactTime = 60;
		public const int TAG_OrdType = 40;
		public const int TAG_BidForwardPoints2 = 642;
		public const int TAG_OfferForwardPoints2 = 643;
		public const int TAG_SettlCurrBidFxRate = 656;
		public const int TAG_SettlCurrOfferFxRate = 657;
		public const int TAG_SettlCurrFxRateCalc = 156;
		public const int TAG_CommType = 13;
		public const int TAG_Commission = 12;
		public const int TAG_CustOrderCapacity = 582;
		public const int TAG_ExDestination = 100;
		public const int TAG_QuoteStatus = 297;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sQuoteStatusReqID;
		private string _sQuoteReqID;
		private string _sQuoteID;
		private string _sQuoteRespID;
		private int _iQuoteType;
		private int _iNoPartyIDs;
		private QuoteStatusReportPartyIDList _listPartyID = new QuoteStatusReportPartyIDList();
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private QuoteStatusReportSecurityAltIDList _listSecurityAltID = new QuoteStatusReportSecurityAltIDList();
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
		private QuoteStatusReportEventList _listEvent = new QuoteStatusReportEventList();
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
		private int _iNoUnderlyings;
		private QuoteStatusReportUnderlyingList _listUnderlying = new QuoteStatusReportUnderlyingList();
		private char _cSide;
		private int _iOrderQty;
		private int _iCashOrderQty;
		private double _dOrderPercent;
		private char _cRoundingDirection;
		private double _dRoundingModulus;
		private char _cSettlType;
		private DateTime _dtSettlDate;
		private DateTime _dtSettlDate2;
		private int _iOrderQty2;
		private string _sCurrency;
		private int _iNoStipulations;
		private QuoteStatusReportStipulationList _listStipulation = new QuoteStatusReportStipulationList();
		private string _sAccount;
		private int _iAcctIDSource;
		private int _iAccountType;
		private int _iNoLegs;
		private QuoteStatusReportLegList _listLeg = new QuoteStatusReportLegList();
		private int _iNoQuoteQualifiers;
		private QuoteStatusReportQuoteQualifierList _listQuoteQualifier = new QuoteStatusReportQuoteQualifierList();
		private DateTime _dtExpireTime;
		private double _dPrice;
		private int _iPriceType;
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
		private double _dBidPx;
		private double _dOfferPx;
		private double _dMktBidPx;
		private double _dMktOfferPx;
		private int _iMinBidSize;
		private int _iBidSize;
		private int _iMinOfferSize;
		private int _iOfferSize;
		private DateTime _dtValidUntilTime;
		private double _dBidSpotRate;
		private double _dOfferSpotRate;
		private double _dBidForwardPoints;
		private double _dOfferForwardPoints;
		private double _dMidPx;
		private double _dBidYield;
		private double _dMidYield;
		private double _dOfferYield;
		private DateTime _dtTransactTime;
		private char _cOrdType;
		private double _dBidForwardPoints2;
		private double _dOfferForwardPoints2;
		private double _dSettlCurrBidFxRate;
		private double _dSettlCurrOfferFxRate;
		private char _cSettlCurrFxRateCalc;
		private char _cCommType;
		private double _dCommission;
		private int _iCustOrderCapacity;
		private string _sExDestination;
		private int _iQuoteStatus;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public QuoteStatusReport() : base()
		{
			_sMsgType = Values.MsgType.QuoteStatusReport;
		}

		public string QuoteStatusReqID
		{
			get { return _sQuoteStatusReqID; }
			set { _sQuoteStatusReqID = value; }
		}
		public string QuoteReqID
		{
			get { return _sQuoteReqID; }
			set { _sQuoteReqID = value; }
		}
		public string QuoteID
		{
			get { return _sQuoteID; }
			set { _sQuoteID = value; }
		}
		public string QuoteRespID
		{
			get { return _sQuoteRespID; }
			set { _sQuoteRespID = value; }
		}
		public int QuoteType
		{
			get { return _iQuoteType; }
			set { _iQuoteType = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public QuoteStatusReportPartyIDList PartyID 
		{
			get { return _listPartyID; }
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
		public QuoteStatusReportSecurityAltIDList SecurityAltID 
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
		public QuoteStatusReportEventList Event 
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
		public int NoUnderlyings
		{
			get { return _iNoUnderlyings; }
			set { _iNoUnderlyings = value; }
		}
		public QuoteStatusReportUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
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
		public string Currency
		{
			get { return _sCurrency; }
			set { _sCurrency = value; }
		}
		public int NoStipulations
		{
			get { return _iNoStipulations; }
			set { _iNoStipulations = value; }
		}
		public QuoteStatusReportStipulationList Stipulation 
		{
			get { return _listStipulation; }
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
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public QuoteStatusReportLegList Leg 
		{
			get { return _listLeg; }
		}
		public int NoQuoteQualifiers
		{
			get { return _iNoQuoteQualifiers; }
			set { _iNoQuoteQualifiers = value; }
		}
		public QuoteStatusReportQuoteQualifierList QuoteQualifier 
		{
			get { return _listQuoteQualifier; }
		}
		public DateTime ExpireTime
		{
			get { return _dtExpireTime; }
			set { _dtExpireTime = value; }
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
		public double BidPx
		{
			get { return _dBidPx; }
			set { _dBidPx = value; }
		}
		public double OfferPx
		{
			get { return _dOfferPx; }
			set { _dOfferPx = value; }
		}
		public double MktBidPx
		{
			get { return _dMktBidPx; }
			set { _dMktBidPx = value; }
		}
		public double MktOfferPx
		{
			get { return _dMktOfferPx; }
			set { _dMktOfferPx = value; }
		}
		public int MinBidSize
		{
			get { return _iMinBidSize; }
			set { _iMinBidSize = value; }
		}
		public int BidSize
		{
			get { return _iBidSize; }
			set { _iBidSize = value; }
		}
		public int MinOfferSize
		{
			get { return _iMinOfferSize; }
			set { _iMinOfferSize = value; }
		}
		public int OfferSize
		{
			get { return _iOfferSize; }
			set { _iOfferSize = value; }
		}
		public DateTime ValidUntilTime
		{
			get { return _dtValidUntilTime; }
			set { _dtValidUntilTime = value; }
		}
		public double BidSpotRate
		{
			get { return _dBidSpotRate; }
			set { _dBidSpotRate = value; }
		}
		public double OfferSpotRate
		{
			get { return _dOfferSpotRate; }
			set { _dOfferSpotRate = value; }
		}
		public double BidForwardPoints
		{
			get { return _dBidForwardPoints; }
			set { _dBidForwardPoints = value; }
		}
		public double OfferForwardPoints
		{
			get { return _dOfferForwardPoints; }
			set { _dOfferForwardPoints = value; }
		}
		public double MidPx
		{
			get { return _dMidPx; }
			set { _dMidPx = value; }
		}
		public double BidYield
		{
			get { return _dBidYield; }
			set { _dBidYield = value; }
		}
		public double MidYield
		{
			get { return _dMidYield; }
			set { _dMidYield = value; }
		}
		public double OfferYield
		{
			get { return _dOfferYield; }
			set { _dOfferYield = value; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public char OrdType
		{
			get { return _cOrdType; }
			set { _cOrdType = value; }
		}
		public double BidForwardPoints2
		{
			get { return _dBidForwardPoints2; }
			set { _dBidForwardPoints2 = value; }
		}
		public double OfferForwardPoints2
		{
			get { return _dOfferForwardPoints2; }
			set { _dOfferForwardPoints2 = value; }
		}
		public double SettlCurrBidFxRate
		{
			get { return _dSettlCurrBidFxRate; }
			set { _dSettlCurrBidFxRate = value; }
		}
		public double SettlCurrOfferFxRate
		{
			get { return _dSettlCurrOfferFxRate; }
			set { _dSettlCurrOfferFxRate = value; }
		}
		public char SettlCurrFxRateCalc
		{
			get { return _cSettlCurrFxRateCalc; }
			set { _cSettlCurrFxRateCalc = value; }
		}
		public char CommType
		{
			get { return _cCommType; }
			set { _cCommType = value; }
		}
		public double Commission
		{
			get { return _dCommission; }
			set { _dCommission = value; }
		}
		public int CustOrderCapacity
		{
			get { return _iCustOrderCapacity; }
			set { _iCustOrderCapacity = value; }
		}
		public string ExDestination
		{
			get { return _sExDestination; }
			set { _sExDestination = value; }
		}
		public int QuoteStatus
		{
			get { return _iQuoteStatus; }
			set { _iQuoteStatus = value; }
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
					case TAG_QuoteStatusReqID:
						return _sQuoteStatusReqID;
					case TAG_QuoteReqID:
						return _sQuoteReqID;
					case TAG_QuoteID:
						return _sQuoteID;
					case TAG_QuoteRespID:
						return _sQuoteRespID;
					case TAG_QuoteType:
						return _iQuoteType;
					case TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case TAG_TradingSessionID:
						return _sTradingSessionID;
					case TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
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
					case TAG_NoUnderlyings:
						return _iNoUnderlyings;
					case TAG_Side:
						return _cSide;
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
					case TAG_SettlType:
						return _cSettlType;
					case TAG_SettlDate:
						return _dtSettlDate;
					case TAG_SettlDate2:
						return _dtSettlDate2;
					case TAG_OrderQty2:
						return _iOrderQty2;
					case TAG_Currency:
						return _sCurrency;
					case TAG_NoStipulations:
						return _iNoStipulations;
					case TAG_Account:
						return _sAccount;
					case TAG_AcctIDSource:
						return _iAcctIDSource;
					case TAG_AccountType:
						return _iAccountType;
					case TAG_NoLegs:
						return _iNoLegs;
					case TAG_NoQuoteQualifiers:
						return _iNoQuoteQualifiers;
					case TAG_ExpireTime:
						return _dtExpireTime;
					case TAG_Price:
						return _dPrice;
					case TAG_PriceType:
						return _iPriceType;
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
					case TAG_BidPx:
						return _dBidPx;
					case TAG_OfferPx:
						return _dOfferPx;
					case TAG_MktBidPx:
						return _dMktBidPx;
					case TAG_MktOfferPx:
						return _dMktOfferPx;
					case TAG_MinBidSize:
						return _iMinBidSize;
					case TAG_BidSize:
						return _iBidSize;
					case TAG_MinOfferSize:
						return _iMinOfferSize;
					case TAG_OfferSize:
						return _iOfferSize;
					case TAG_ValidUntilTime:
						return _dtValidUntilTime;
					case TAG_BidSpotRate:
						return _dBidSpotRate;
					case TAG_OfferSpotRate:
						return _dOfferSpotRate;
					case TAG_BidForwardPoints:
						return _dBidForwardPoints;
					case TAG_OfferForwardPoints:
						return _dOfferForwardPoints;
					case TAG_MidPx:
						return _dMidPx;
					case TAG_BidYield:
						return _dBidYield;
					case TAG_MidYield:
						return _dMidYield;
					case TAG_OfferYield:
						return _dOfferYield;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_OrdType:
						return _cOrdType;
					case TAG_BidForwardPoints2:
						return _dBidForwardPoints2;
					case TAG_OfferForwardPoints2:
						return _dOfferForwardPoints2;
					case TAG_SettlCurrBidFxRate:
						return _dSettlCurrBidFxRate;
					case TAG_SettlCurrOfferFxRate:
						return _dSettlCurrOfferFxRate;
					case TAG_SettlCurrFxRateCalc:
						return _cSettlCurrFxRateCalc;
					case TAG_CommType:
						return _cCommType;
					case TAG_Commission:
						return _dCommission;
					case TAG_CustOrderCapacity:
						return _iCustOrderCapacity;
					case TAG_ExDestination:
						return _sExDestination;
					case TAG_QuoteStatus:
						return _iQuoteStatus;
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
					case TAG_QuoteStatusReqID:
						_sQuoteStatusReqID = (string)value;
						break;
					case TAG_QuoteReqID:
						_sQuoteReqID = (string)value;
						break;
					case TAG_QuoteID:
						_sQuoteID = (string)value;
						break;
					case TAG_QuoteRespID:
						_sQuoteRespID = (string)value;
						break;
					case TAG_QuoteType:
						_iQuoteType = (int)value;
						break;
					case TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
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
					case TAG_NoUnderlyings:
						_iNoUnderlyings = (int)value;
						break;
					case TAG_Side:
						_cSide = (char)value;
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
					case TAG_SettlType:
						_cSettlType = (char)value;
						break;
					case TAG_SettlDate:
						_dtSettlDate = (DateTime)value;
						break;
					case TAG_SettlDate2:
						_dtSettlDate2 = (DateTime)value;
						break;
					case TAG_OrderQty2:
						_iOrderQty2 = (int)value;
						break;
					case TAG_Currency:
						_sCurrency = (string)value;
						break;
					case TAG_NoStipulations:
						_iNoStipulations = (int)value;
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
					case TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					case TAG_NoQuoteQualifiers:
						_iNoQuoteQualifiers = (int)value;
						break;
					case TAG_ExpireTime:
						_dtExpireTime = (DateTime)value;
						break;
					case TAG_Price:
						_dPrice = (double)value;
						break;
					case TAG_PriceType:
						_iPriceType = (int)value;
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
					case TAG_BidPx:
						_dBidPx = (double)value;
						break;
					case TAG_OfferPx:
						_dOfferPx = (double)value;
						break;
					case TAG_MktBidPx:
						_dMktBidPx = (double)value;
						break;
					case TAG_MktOfferPx:
						_dMktOfferPx = (double)value;
						break;
					case TAG_MinBidSize:
						_iMinBidSize = (int)value;
						break;
					case TAG_BidSize:
						_iBidSize = (int)value;
						break;
					case TAG_MinOfferSize:
						_iMinOfferSize = (int)value;
						break;
					case TAG_OfferSize:
						_iOfferSize = (int)value;
						break;
					case TAG_ValidUntilTime:
						_dtValidUntilTime = (DateTime)value;
						break;
					case TAG_BidSpotRate:
						_dBidSpotRate = (double)value;
						break;
					case TAG_OfferSpotRate:
						_dOfferSpotRate = (double)value;
						break;
					case TAG_BidForwardPoints:
						_dBidForwardPoints = (double)value;
						break;
					case TAG_OfferForwardPoints:
						_dOfferForwardPoints = (double)value;
						break;
					case TAG_MidPx:
						_dMidPx = (double)value;
						break;
					case TAG_BidYield:
						_dBidYield = (double)value;
						break;
					case TAG_MidYield:
						_dMidYield = (double)value;
						break;
					case TAG_OfferYield:
						_dOfferYield = (double)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_OrdType:
						_cOrdType = (char)value;
						break;
					case TAG_BidForwardPoints2:
						_dBidForwardPoints2 = (double)value;
						break;
					case TAG_OfferForwardPoints2:
						_dOfferForwardPoints2 = (double)value;
						break;
					case TAG_SettlCurrBidFxRate:
						_dSettlCurrBidFxRate = (double)value;
						break;
					case TAG_SettlCurrOfferFxRate:
						_dSettlCurrOfferFxRate = (double)value;
						break;
					case TAG_SettlCurrFxRateCalc:
						_cSettlCurrFxRateCalc = (char)value;
						break;
					case TAG_CommType:
						_cCommType = (char)value;
						break;
					case TAG_Commission:
						_dCommission = (double)value;
						break;
					case TAG_CustOrderCapacity:
						_iCustOrderCapacity = (int)value;
						break;
					case TAG_ExDestination:
						_sExDestination = (string)value;
						break;
					case TAG_QuoteStatus:
						_iQuoteStatus = (int)value;
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

	public class QuoteStatusReportPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private QuoteStatusReportPartySubIDList _listPartySubID = new QuoteStatusReportPartySubIDList();

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
		public QuoteStatusReportPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_PartyID:
						return _sPartyID;
					case QuoteStatusReport.TAG_PartyIDSource:
						return _cPartyIDSource;
					case QuoteStatusReport.TAG_PartyRole:
						return _iPartyRole;
					case QuoteStatusReport.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case QuoteStatusReport.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case QuoteStatusReport.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case QuoteStatusReport.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportPartyIDList
	{
		private ArrayList _al;
		private QuoteStatusReportPartyID _last;

		public QuoteStatusReportPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportPartyID)_al[i];
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

		public void Add(QuoteStatusReportPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportPartyID Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportPartySubID
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
					case QuoteStatusReport.TAG_PartySubID:
						return _sPartySubID;
					case QuoteStatusReport.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case QuoteStatusReport.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportPartySubIDList
	{
		private ArrayList _al;
		private QuoteStatusReportPartySubID _last;

		public QuoteStatusReportPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportPartySubID)_al[i];
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

		public void Add(QuoteStatusReportPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportPartySubID Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportSecurityAltID
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
					case QuoteStatusReport.TAG_SecurityAltID:
						return _sSecurityAltID;
					case QuoteStatusReport.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case QuoteStatusReport.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportSecurityAltIDList
	{
		private ArrayList _al;
		private QuoteStatusReportSecurityAltID _last;

		public QuoteStatusReportSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportSecurityAltID)_al[i];
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

		public void Add(QuoteStatusReportSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportEvent
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
					case QuoteStatusReport.TAG_EventType:
						return _iEventType;
					case QuoteStatusReport.TAG_EventDate:
						return _dtEventDate;
					case QuoteStatusReport.TAG_EventPx:
						return _dEventPx;
					case QuoteStatusReport.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_EventType:
						_iEventType = (int)value;
						break;
					case QuoteStatusReport.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case QuoteStatusReport.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportEventList
	{
		private ArrayList _al;
		private QuoteStatusReportEvent _last;

		public QuoteStatusReportEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportEvent)_al[i];
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

		public void Add(QuoteStatusReportEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportEvent Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private QuoteStatusReportUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new QuoteStatusReportUnderlyingSecurityAltIDList();
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
		public QuoteStatusReportUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
					case QuoteStatusReport.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case QuoteStatusReport.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case QuoteStatusReport.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case QuoteStatusReport.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case QuoteStatusReport.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case QuoteStatusReport.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case QuoteStatusReport.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case QuoteStatusReport.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case QuoteStatusReport.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case QuoteStatusReport.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case QuoteStatusReport.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case QuoteStatusReport.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case QuoteStatusReport.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case QuoteStatusReport.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case QuoteStatusReport.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case QuoteStatusReport.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case QuoteStatusReport.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case QuoteStatusReport.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case QuoteStatusReport.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case QuoteStatusReport.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case QuoteStatusReport.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case QuoteStatusReport.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case QuoteStatusReport.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case QuoteStatusReport.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case QuoteStatusReport.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case QuoteStatusReport.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case QuoteStatusReport.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case QuoteStatusReport.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case QuoteStatusReport.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case QuoteStatusReport.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case QuoteStatusReport.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case QuoteStatusReport.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case QuoteStatusReport.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case QuoteStatusReport.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case QuoteStatusReport.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case QuoteStatusReport.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case QuoteStatusReport.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case QuoteStatusReport.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case QuoteStatusReport.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case QuoteStatusReport.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case QuoteStatusReport.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case QuoteStatusReport.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case QuoteStatusReport.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case QuoteStatusReport.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case QuoteStatusReport.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case QuoteStatusReport.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case QuoteStatusReport.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case QuoteStatusReport.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case QuoteStatusReport.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case QuoteStatusReport.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportUnderlyingList
	{
		private ArrayList _al;
		private QuoteStatusReportUnderlying _last;

		public QuoteStatusReportUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportUnderlying)_al[i];
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

		public void Add(QuoteStatusReportUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportUnderlying Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportUnderlyingSecurityAltID
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
					case QuoteStatusReport.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case QuoteStatusReport.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case QuoteStatusReport.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private QuoteStatusReportUnderlyingSecurityAltID _last;

		public QuoteStatusReportUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportUnderlyingSecurityAltID)_al[i];
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

		public void Add(QuoteStatusReportUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportStipulation
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
					case QuoteStatusReport.TAG_StipulationType:
						return _sStipulationType;
					case QuoteStatusReport.TAG_StipulationValue:
						return _sStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_StipulationType:
						_sStipulationType = (string)value;
						break;
					case QuoteStatusReport.TAG_StipulationValue:
						_sStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportStipulationList
	{
		private ArrayList _al;
		private QuoteStatusReportStipulation _last;

		public QuoteStatusReportStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportStipulation)_al[i];
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

		public void Add(QuoteStatusReportStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportStipulation Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private QuoteStatusReportLegSecurityAltIDList _listLegSecurityAltID = new QuoteStatusReportLegSecurityAltIDList();
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
		private char _cLegSettlType;
		private DateTime _dtLegSettlDate;
		private int _iNoLegStipulations;
		private QuoteStatusReportLegStipulationList _listLegStipulation = new QuoteStatusReportLegStipulationList();
		private int _iNoNestedPartyIDs;
		private QuoteStatusReportNestedPartyIDList _listNestedPartyID = new QuoteStatusReportNestedPartyIDList();

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
		public QuoteStatusReportLegSecurityAltIDList LegSecurityAltID 
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
		public int NoLegStipulations
		{
			get { return _iNoLegStipulations; }
			set { _iNoLegStipulations = value; }
		}
		public QuoteStatusReportLegStipulationList LegStipulation 
		{
			get { return _listLegStipulation; }
		}
		public int NoNestedPartyIDs
		{
			get { return _iNoNestedPartyIDs; }
			set { _iNoNestedPartyIDs = value; }
		}
		public QuoteStatusReportNestedPartyIDList NestedPartyID 
		{
			get { return _listNestedPartyID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_LegSymbol:
						return _sLegSymbol;
					case QuoteStatusReport.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case QuoteStatusReport.TAG_LegSecurityID:
						return _sLegSecurityID;
					case QuoteStatusReport.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case QuoteStatusReport.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case QuoteStatusReport.TAG_LegProduct:
						return _iLegProduct;
					case QuoteStatusReport.TAG_LegCFICode:
						return _sLegCFICode;
					case QuoteStatusReport.TAG_LegSecurityType:
						return _sLegSecurityType;
					case QuoteStatusReport.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case QuoteStatusReport.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case QuoteStatusReport.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case QuoteStatusReport.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case QuoteStatusReport.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case QuoteStatusReport.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case QuoteStatusReport.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case QuoteStatusReport.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case QuoteStatusReport.TAG_LegFactor:
						return _dLegFactor;
					case QuoteStatusReport.TAG_LegCreditRating:
						return _sLegCreditRating;
					case QuoteStatusReport.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case QuoteStatusReport.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case QuoteStatusReport.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case QuoteStatusReport.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case QuoteStatusReport.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case QuoteStatusReport.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case QuoteStatusReport.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case QuoteStatusReport.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case QuoteStatusReport.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case QuoteStatusReport.TAG_LegCouponRate:
						return _dLegCouponRate;
					case QuoteStatusReport.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case QuoteStatusReport.TAG_LegIssuer:
						return _sLegIssuer;
					case QuoteStatusReport.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case QuoteStatusReport.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case QuoteStatusReport.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case QuoteStatusReport.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case QuoteStatusReport.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case QuoteStatusReport.TAG_LegRatioQty:
						return _dLegRatioQty;
					case QuoteStatusReport.TAG_LegSide:
						return _cLegSide;
					case QuoteStatusReport.TAG_LegCurrency:
						return _sLegCurrency;
					case QuoteStatusReport.TAG_LegPool:
						return _sLegPool;
					case QuoteStatusReport.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case QuoteStatusReport.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case QuoteStatusReport.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					case QuoteStatusReport.TAG_LegQty:
						return _iLegQty;
					case QuoteStatusReport.TAG_LegSwapType:
						return _iLegSwapType;
					case QuoteStatusReport.TAG_LegSettlType:
						return _cLegSettlType;
					case QuoteStatusReport.TAG_LegSettlDate:
						return _dtLegSettlDate;
					case QuoteStatusReport.TAG_NoLegStipulations:
						return _iNoLegStipulations;
					case QuoteStatusReport.TAG_NoNestedPartyIDs:
						return _iNoNestedPartyIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case QuoteStatusReport.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case QuoteStatusReport.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case QuoteStatusReport.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case QuoteStatusReport.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case QuoteStatusReport.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case QuoteStatusReport.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case QuoteStatusReport.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case QuoteStatusReport.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case QuoteStatusReport.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case QuoteStatusReport.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case QuoteStatusReport.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case QuoteStatusReport.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case QuoteStatusReport.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case QuoteStatusReport.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case QuoteStatusReport.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case QuoteStatusReport.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case QuoteStatusReport.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case QuoteStatusReport.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case QuoteStatusReport.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case QuoteStatusReport.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case QuoteStatusReport.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case QuoteStatusReport.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case QuoteStatusReport.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case QuoteStatusReport.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case QuoteStatusReport.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case QuoteStatusReport.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case QuoteStatusReport.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case QuoteStatusReport.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case QuoteStatusReport.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case QuoteStatusReport.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case QuoteStatusReport.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case QuoteStatusReport.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case QuoteStatusReport.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case QuoteStatusReport.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_LegQty:
						_iLegQty = (int)value;
						break;
					case QuoteStatusReport.TAG_LegSwapType:
						_iLegSwapType = (int)value;
						break;
					case QuoteStatusReport.TAG_LegSettlType:
						_cLegSettlType = (char)value;
						break;
					case QuoteStatusReport.TAG_LegSettlDate:
						_dtLegSettlDate = (DateTime)value;
						break;
					case QuoteStatusReport.TAG_NoLegStipulations:
						_iNoLegStipulations = (int)value;
						break;
					case QuoteStatusReport.TAG_NoNestedPartyIDs:
						_iNoNestedPartyIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportLegList
	{
		private ArrayList _al;
		private QuoteStatusReportLeg _last;

		public QuoteStatusReportLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportLeg)_al[i];
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

		public void Add(QuoteStatusReportLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportLeg Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportLegSecurityAltID
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
					case QuoteStatusReport.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case QuoteStatusReport.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case QuoteStatusReport.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportLegSecurityAltIDList
	{
		private ArrayList _al;
		private QuoteStatusReportLegSecurityAltID _last;

		public QuoteStatusReportLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportLegSecurityAltID)_al[i];
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

		public void Add(QuoteStatusReportLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportLegSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportLegStipulation
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
					case QuoteStatusReport.TAG_LegStipulationType:
						return _sLegStipulationType;
					case QuoteStatusReport.TAG_LegStipulationValue:
						return _sLegStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_LegStipulationType:
						_sLegStipulationType = (string)value;
						break;
					case QuoteStatusReport.TAG_LegStipulationValue:
						_sLegStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportLegStipulationList
	{
		private ArrayList _al;
		private QuoteStatusReportLegStipulation _last;

		public QuoteStatusReportLegStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportLegStipulation)_al[i];
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

		public void Add(QuoteStatusReportLegStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportLegStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportLegStipulation Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportNestedPartyID
	{
		private string _sNestedPartyID;
		private char _cNestedPartyIDSource;
		private int _iNestedPartyRole;
		private int _iNoNestedPartySubIDs;
		private QuoteStatusReportNestedPartySubIDList _listNestedPartySubID = new QuoteStatusReportNestedPartySubIDList();

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
		public QuoteStatusReportNestedPartySubIDList NestedPartySubID 
		{
			get { return _listNestedPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_NestedPartyID:
						return _sNestedPartyID;
					case QuoteStatusReport.TAG_NestedPartyIDSource:
						return _cNestedPartyIDSource;
					case QuoteStatusReport.TAG_NestedPartyRole:
						return _iNestedPartyRole;
					case QuoteStatusReport.TAG_NoNestedPartySubIDs:
						return _iNoNestedPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_NestedPartyID:
						_sNestedPartyID = (string)value;
						break;
					case QuoteStatusReport.TAG_NestedPartyIDSource:
						_cNestedPartyIDSource = (char)value;
						break;
					case QuoteStatusReport.TAG_NestedPartyRole:
						_iNestedPartyRole = (int)value;
						break;
					case QuoteStatusReport.TAG_NoNestedPartySubIDs:
						_iNoNestedPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportNestedPartyIDList
	{
		private ArrayList _al;
		private QuoteStatusReportNestedPartyID _last;

		public QuoteStatusReportNestedPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportNestedPartyID)_al[i];
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

		public void Add(QuoteStatusReportNestedPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportNestedPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportNestedPartyID Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportNestedPartySubID
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
					case QuoteStatusReport.TAG_NestedPartySubID:
						return _sNestedPartySubID;
					case QuoteStatusReport.TAG_NestedPartySubIDType:
						return _iNestedPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_NestedPartySubID:
						_sNestedPartySubID = (string)value;
						break;
					case QuoteStatusReport.TAG_NestedPartySubIDType:
						_iNestedPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportNestedPartySubIDList
	{
		private ArrayList _al;
		private QuoteStatusReportNestedPartySubID _last;

		public QuoteStatusReportNestedPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportNestedPartySubID)_al[i];
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

		public void Add(QuoteStatusReportNestedPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportNestedPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportNestedPartySubID Last
		{
			get { return _last; }
		}
	}

	public class QuoteStatusReportQuoteQualifier
	{
		private char _cQuoteQualifier;

		public char QuoteQualifier
		{
			get { return _cQuoteQualifier; }
			set { _cQuoteQualifier = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_QuoteQualifier:
						return _cQuoteQualifier;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteStatusReport.TAG_QuoteQualifier:
						_cQuoteQualifier = (char)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteStatusReportQuoteQualifierList
	{
		private ArrayList _al;
		private QuoteStatusReportQuoteQualifier _last;

		public QuoteStatusReportQuoteQualifier this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteStatusReportQuoteQualifier)_al[i];
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

		public void Add(QuoteStatusReportQuoteQualifier item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteStatusReportQuoteQualifier item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteStatusReportQuoteQualifier Last
		{
			get { return _last; }
		}
	}
}
