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
	/// Summary description for TradeCaptureReportAck.
	/// </summary>
	public class TradeCaptureReportAck : Message
	{
		public const int TAG_TradeReportID = 571;
		public const int TAG_TradeReportTransType = 487;
		public const int TAG_TradeReportType = 856;
		public const int TAG_TrdType = 828;
		public const int TAG_TrdSubType = 829;
		public const int TAG_SecondaryTrdType = 855;
		public const int TAG_TransferReason = 830;
		public const int TAG_ExecType = 150;
		public const int TAG_TradeReportRefID = 572;
		public const int TAG_SecondaryTradeReportRefID = 881;
		public const int TAG_TrdRptStatus = 939;
		public const int TAG_TradeReportRejectReason = 751;
		public const int TAG_SecondaryTradeReportID = 818;
		public const int TAG_SubscriptionRequestType = 263;
		public const int TAG_TradeLinkID = 820;
		public const int TAG_TrdMatchID = 880;
		public const int TAG_ExecID = 17;
		public const int TAG_SecondaryExecID = 527;
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
		public const int TAG_TransactTime = 60;
		public const int TAG_NoTrdRegTimestamps = 768;
		public const int TAG_TrdRegTimestamp = 769;
		public const int TAG_TrdRegTimestampType = 770;
		public const int TAG_TrdRegTimestampOrigin = 771;
		public const int TAG_ResponseTransportType = 725;
		public const int TAG_ResponseDestination = 726;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
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
		public const int TAG_ClearingFeeIndicator = 635;
		public const int TAG_OrderCapacity = 528;
		public const int TAG_OrderRestrictions = 529;
		public const int TAG_CustOrderCapacity = 582;
		public const int TAG_Account = 1;
		public const int TAG_AcctIDSource = 660;
		public const int TAG_AccountType = 581;
		public const int TAG_PositionEffect = 77;
		public const int TAG_PreallocMethod = 591;
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

		private string _sTradeReportID;
		private int _iTradeReportTransType;
		private int _iTradeReportType;
		private int _iTrdType;
		private int _iTrdSubType;
		private int _iSecondaryTrdType;
		private string _sTransferReason;
		private char _cExecType;
		private string _sTradeReportRefID;
		private string _sSecondaryTradeReportRefID;
		private int _iTrdRptStatus;
		private int _iTradeReportRejectReason;
		private string _sSecondaryTradeReportID;
		private char _cSubscriptionRequestType;
		private string _sTradeLinkID;
		private string _sTrdMatchID;
		private string _sExecID;
		private string _sSecondaryExecID;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private TradeCaptureReportAckSecurityAltIDList _listSecurityAltID = new TradeCaptureReportAckSecurityAltIDList();
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
		private TradeCaptureReportAckEventList _listEvent = new TradeCaptureReportAckEventList();
		private DateTime _dtDatedDate;
		private DateTime _dtInterestAccrualDate;
		private DateTime _dtTransactTime;
		private int _iNoTrdRegTimestamps;
		private TradeCaptureReportAckTrdRegTimestampList _listTrdRegTimestamp = new TradeCaptureReportAckTrdRegTimestampList();
		private int _iResponseTransportType;
		private string _sResponseDestination;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private int _iNoLegs;
		private TradeCaptureReportAckLegList _listLeg = new TradeCaptureReportAckLegList();
		private string _sClearingFeeIndicator;
		private char _cOrderCapacity;
		private string _sOrderRestrictions;
		private int _iCustOrderCapacity;
		private string _sAccount;
		private int _iAcctIDSource;
		private int _iAccountType;
		private char _cPositionEffect;
		private char _cPreallocMethod;
		private int _iNoAllocs;
		private TradeCaptureReportAckAllocList _listAlloc = new TradeCaptureReportAckAllocList();

		public TradeCaptureReportAck() : base()
		{
			_sMsgType = Values.MsgType.TradeCaptureReportAck;
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
		public int TrdRptStatus
		{
			get { return _iTrdRptStatus; }
			set { _iTrdRptStatus = value; }
		}
		public int TradeReportRejectReason
		{
			get { return _iTradeReportRejectReason; }
			set { _iTradeReportRejectReason = value; }
		}
		public string SecondaryTradeReportID
		{
			get { return _sSecondaryTradeReportID; }
			set { _sSecondaryTradeReportID = value; }
		}
		public char SubscriptionRequestType
		{
			get { return _cSubscriptionRequestType; }
			set { _cSubscriptionRequestType = value; }
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
		public string SecondaryExecID
		{
			get { return _sSecondaryExecID; }
			set { _sSecondaryExecID = value; }
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
		public TradeCaptureReportAckSecurityAltIDList SecurityAltID 
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
		public TradeCaptureReportAckEventList Event 
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
		public TradeCaptureReportAckTrdRegTimestampList TrdRegTimestamp 
		{
			get { return _listTrdRegTimestamp; }
		}
		public int ResponseTransportType
		{
			get { return _iResponseTransportType; }
			set { _iResponseTransportType = value; }
		}
		public string ResponseDestination
		{
			get { return _sResponseDestination; }
			set { _sResponseDestination = value; }
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
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public TradeCaptureReportAckLegList Leg 
		{
			get { return _listLeg; }
		}
		public string ClearingFeeIndicator
		{
			get { return _sClearingFeeIndicator; }
			set { _sClearingFeeIndicator = value; }
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
		public char PositionEffect
		{
			get { return _cPositionEffect; }
			set { _cPositionEffect = value; }
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
		public TradeCaptureReportAckAllocList Alloc 
		{
			get { return _listAlloc; }
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
					case TAG_TradeReportRefID:
						return _sTradeReportRefID;
					case TAG_SecondaryTradeReportRefID:
						return _sSecondaryTradeReportRefID;
					case TAG_TrdRptStatus:
						return _iTrdRptStatus;
					case TAG_TradeReportRejectReason:
						return _iTradeReportRejectReason;
					case TAG_SecondaryTradeReportID:
						return _sSecondaryTradeReportID;
					case TAG_SubscriptionRequestType:
						return _cSubscriptionRequestType;
					case TAG_TradeLinkID:
						return _sTradeLinkID;
					case TAG_TrdMatchID:
						return _sTrdMatchID;
					case TAG_ExecID:
						return _sExecID;
					case TAG_SecondaryExecID:
						return _sSecondaryExecID;
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
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_NoTrdRegTimestamps:
						return _iNoTrdRegTimestamps;
					case TAG_ResponseTransportType:
						return _iResponseTransportType;
					case TAG_ResponseDestination:
						return _sResponseDestination;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
					case TAG_NoLegs:
						return _iNoLegs;
					case TAG_ClearingFeeIndicator:
						return _sClearingFeeIndicator;
					case TAG_OrderCapacity:
						return _cOrderCapacity;
					case TAG_OrderRestrictions:
						return _sOrderRestrictions;
					case TAG_CustOrderCapacity:
						return _iCustOrderCapacity;
					case TAG_Account:
						return _sAccount;
					case TAG_AcctIDSource:
						return _iAcctIDSource;
					case TAG_AccountType:
						return _iAccountType;
					case TAG_PositionEffect:
						return _cPositionEffect;
					case TAG_PreallocMethod:
						return _cPreallocMethod;
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
					case TAG_TradeReportID:
						_sTradeReportID = (string)value;
						break;
					case TAG_TradeReportTransType:
						_iTradeReportTransType = (int)value;
						break;
					case TAG_TradeReportType:
						_iTradeReportType = (int)value;
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
					case TAG_TradeReportRefID:
						_sTradeReportRefID = (string)value;
						break;
					case TAG_SecondaryTradeReportRefID:
						_sSecondaryTradeReportRefID = (string)value;
						break;
					case TAG_TrdRptStatus:
						_iTrdRptStatus = (int)value;
						break;
					case TAG_TradeReportRejectReason:
						_iTradeReportRejectReason = (int)value;
						break;
					case TAG_SecondaryTradeReportID:
						_sSecondaryTradeReportID = (string)value;
						break;
					case TAG_SubscriptionRequestType:
						_cSubscriptionRequestType = (char)value;
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
					case TAG_SecondaryExecID:
						_sSecondaryExecID = (string)value;
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
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_NoTrdRegTimestamps:
						_iNoTrdRegTimestamps = (int)value;
						break;
					case TAG_ResponseTransportType:
						_iResponseTransportType = (int)value;
						break;
					case TAG_ResponseDestination:
						_sResponseDestination = (string)value;
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
					case TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					case TAG_ClearingFeeIndicator:
						_sClearingFeeIndicator = (string)value;
						break;
					case TAG_OrderCapacity:
						_cOrderCapacity = (char)value;
						break;
					case TAG_OrderRestrictions:
						_sOrderRestrictions = (string)value;
						break;
					case TAG_CustOrderCapacity:
						_iCustOrderCapacity = (int)value;
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
					case TAG_PositionEffect:
						_cPositionEffect = (char)value;
						break;
					case TAG_PreallocMethod:
						_cPreallocMethod = (char)value;
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

	public class TradeCaptureReportAckSecurityAltID
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
					case TradeCaptureReportAck.TAG_SecurityAltID:
						return _sSecurityAltID;
					case TradeCaptureReportAck.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case TradeCaptureReportAck.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckSecurityAltIDList
	{
		private ArrayList _al;
		private TradeCaptureReportAckSecurityAltID _last;

		public TradeCaptureReportAckSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckSecurityAltID)_al[i];
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

		public void Add(TradeCaptureReportAckSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckEvent
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
					case TradeCaptureReportAck.TAG_EventType:
						return _iEventType;
					case TradeCaptureReportAck.TAG_EventDate:
						return _dtEventDate;
					case TradeCaptureReportAck.TAG_EventPx:
						return _dEventPx;
					case TradeCaptureReportAck.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_EventType:
						_iEventType = (int)value;
						break;
					case TradeCaptureReportAck.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case TradeCaptureReportAck.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckEventList
	{
		private ArrayList _al;
		private TradeCaptureReportAckEvent _last;

		public TradeCaptureReportAckEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckEvent)_al[i];
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

		public void Add(TradeCaptureReportAckEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckEvent Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckTrdRegTimestamp
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
					case TradeCaptureReportAck.TAG_TrdRegTimestamp:
						return _dtTrdRegTimestamp;
					case TradeCaptureReportAck.TAG_TrdRegTimestampType:
						return _iTrdRegTimestampType;
					case TradeCaptureReportAck.TAG_TrdRegTimestampOrigin:
						return _sTrdRegTimestampOrigin;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_TrdRegTimestamp:
						_dtTrdRegTimestamp = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_TrdRegTimestampType:
						_iTrdRegTimestampType = (int)value;
						break;
					case TradeCaptureReportAck.TAG_TrdRegTimestampOrigin:
						_sTrdRegTimestampOrigin = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckTrdRegTimestampList
	{
		private ArrayList _al;
		private TradeCaptureReportAckTrdRegTimestamp _last;

		public TradeCaptureReportAckTrdRegTimestamp this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckTrdRegTimestamp)_al[i];
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

		public void Add(TradeCaptureReportAckTrdRegTimestamp item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckTrdRegTimestamp item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckTrdRegTimestamp Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private TradeCaptureReportAckLegSecurityAltIDList _listLegSecurityAltID = new TradeCaptureReportAckLegSecurityAltIDList();
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
		private TradeCaptureReportAckLegStipulationList _listLegStipulation = new TradeCaptureReportAckLegStipulationList();
		private char _cLegPositionEffect;
		private int _iLegCoveredOrUncovered;
		private int _iNoNestedPartyIDs;
		private TradeCaptureReportAckNestedPartyIDList _listNestedPartyID = new TradeCaptureReportAckNestedPartyIDList();
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
		public TradeCaptureReportAckLegSecurityAltIDList LegSecurityAltID 
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
		public TradeCaptureReportAckLegStipulationList LegStipulation 
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
		public TradeCaptureReportAckNestedPartyIDList NestedPartyID 
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
					case TradeCaptureReportAck.TAG_LegSymbol:
						return _sLegSymbol;
					case TradeCaptureReportAck.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case TradeCaptureReportAck.TAG_LegSecurityID:
						return _sLegSecurityID;
					case TradeCaptureReportAck.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case TradeCaptureReportAck.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case TradeCaptureReportAck.TAG_LegProduct:
						return _iLegProduct;
					case TradeCaptureReportAck.TAG_LegCFICode:
						return _sLegCFICode;
					case TradeCaptureReportAck.TAG_LegSecurityType:
						return _sLegSecurityType;
					case TradeCaptureReportAck.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case TradeCaptureReportAck.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case TradeCaptureReportAck.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case TradeCaptureReportAck.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case TradeCaptureReportAck.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case TradeCaptureReportAck.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case TradeCaptureReportAck.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case TradeCaptureReportAck.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case TradeCaptureReportAck.TAG_LegFactor:
						return _dLegFactor;
					case TradeCaptureReportAck.TAG_LegCreditRating:
						return _sLegCreditRating;
					case TradeCaptureReportAck.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case TradeCaptureReportAck.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case TradeCaptureReportAck.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case TradeCaptureReportAck.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case TradeCaptureReportAck.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case TradeCaptureReportAck.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case TradeCaptureReportAck.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case TradeCaptureReportAck.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case TradeCaptureReportAck.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case TradeCaptureReportAck.TAG_LegCouponRate:
						return _dLegCouponRate;
					case TradeCaptureReportAck.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case TradeCaptureReportAck.TAG_LegIssuer:
						return _sLegIssuer;
					case TradeCaptureReportAck.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case TradeCaptureReportAck.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case TradeCaptureReportAck.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case TradeCaptureReportAck.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case TradeCaptureReportAck.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case TradeCaptureReportAck.TAG_LegRatioQty:
						return _dLegRatioQty;
					case TradeCaptureReportAck.TAG_LegSide:
						return _cLegSide;
					case TradeCaptureReportAck.TAG_LegCurrency:
						return _sLegCurrency;
					case TradeCaptureReportAck.TAG_LegPool:
						return _sLegPool;
					case TradeCaptureReportAck.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case TradeCaptureReportAck.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case TradeCaptureReportAck.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					case TradeCaptureReportAck.TAG_LegQty:
						return _iLegQty;
					case TradeCaptureReportAck.TAG_LegSwapType:
						return _iLegSwapType;
					case TradeCaptureReportAck.TAG_NoLegStipulations:
						return _iNoLegStipulations;
					case TradeCaptureReportAck.TAG_LegPositionEffect:
						return _cLegPositionEffect;
					case TradeCaptureReportAck.TAG_LegCoveredOrUncovered:
						return _iLegCoveredOrUncovered;
					case TradeCaptureReportAck.TAG_NoNestedPartyIDs:
						return _iNoNestedPartyIDs;
					case TradeCaptureReportAck.TAG_LegRefID:
						return _sLegRefID;
					case TradeCaptureReportAck.TAG_LegPrice:
						return _dLegPrice;
					case TradeCaptureReportAck.TAG_LegSettlType:
						return _cLegSettlType;
					case TradeCaptureReportAck.TAG_LegSettlDate:
						return _dtLegSettlDate;
					case TradeCaptureReportAck.TAG_LegLastPx:
						return _dLegLastPx;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case TradeCaptureReportAck.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case TradeCaptureReportAck.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case TradeCaptureReportAck.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case TradeCaptureReportAck.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case TradeCaptureReportAck.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case TradeCaptureReportAck.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case TradeCaptureReportAck.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case TradeCaptureReportAck.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case TradeCaptureReportAck.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case TradeCaptureReportAck.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case TradeCaptureReportAck.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case TradeCaptureReportAck.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case TradeCaptureReportAck.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case TradeCaptureReportAck.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case TradeCaptureReportAck.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case TradeCaptureReportAck.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case TradeCaptureReportAck.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_LegQty:
						_iLegQty = (int)value;
						break;
					case TradeCaptureReportAck.TAG_LegSwapType:
						_iLegSwapType = (int)value;
						break;
					case TradeCaptureReportAck.TAG_NoLegStipulations:
						_iNoLegStipulations = (int)value;
						break;
					case TradeCaptureReportAck.TAG_LegPositionEffect:
						_cLegPositionEffect = (char)value;
						break;
					case TradeCaptureReportAck.TAG_LegCoveredOrUncovered:
						_iLegCoveredOrUncovered = (int)value;
						break;
					case TradeCaptureReportAck.TAG_NoNestedPartyIDs:
						_iNoNestedPartyIDs = (int)value;
						break;
					case TradeCaptureReportAck.TAG_LegRefID:
						_sLegRefID = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegPrice:
						_dLegPrice = (double)value;
						break;
					case TradeCaptureReportAck.TAG_LegSettlType:
						_cLegSettlType = (char)value;
						break;
					case TradeCaptureReportAck.TAG_LegSettlDate:
						_dtLegSettlDate = (DateTime)value;
						break;
					case TradeCaptureReportAck.TAG_LegLastPx:
						_dLegLastPx = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckLegList
	{
		private ArrayList _al;
		private TradeCaptureReportAckLeg _last;

		public TradeCaptureReportAckLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckLeg)_al[i];
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

		public void Add(TradeCaptureReportAckLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckLeg Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckLegSecurityAltID
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
					case TradeCaptureReportAck.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case TradeCaptureReportAck.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckLegSecurityAltIDList
	{
		private ArrayList _al;
		private TradeCaptureReportAckLegSecurityAltID _last;

		public TradeCaptureReportAckLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckLegSecurityAltID)_al[i];
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

		public void Add(TradeCaptureReportAckLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckLegSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckLegStipulation
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
					case TradeCaptureReportAck.TAG_LegStipulationType:
						return _sLegStipulationType;
					case TradeCaptureReportAck.TAG_LegStipulationValue:
						return _sLegStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_LegStipulationType:
						_sLegStipulationType = (string)value;
						break;
					case TradeCaptureReportAck.TAG_LegStipulationValue:
						_sLegStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckLegStipulationList
	{
		private ArrayList _al;
		private TradeCaptureReportAckLegStipulation _last;

		public TradeCaptureReportAckLegStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckLegStipulation)_al[i];
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

		public void Add(TradeCaptureReportAckLegStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckLegStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckLegStipulation Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckNestedPartyID
	{
		private string _sNestedPartyID;
		private char _cNestedPartyIDSource;
		private int _iNestedPartyRole;
		private int _iNoNestedPartySubIDs;
		private TradeCaptureReportAckNestedPartySubIDList _listNestedPartySubID = new TradeCaptureReportAckNestedPartySubIDList();

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
		public TradeCaptureReportAckNestedPartySubIDList NestedPartySubID 
		{
			get { return _listNestedPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_NestedPartyID:
						return _sNestedPartyID;
					case TradeCaptureReportAck.TAG_NestedPartyIDSource:
						return _cNestedPartyIDSource;
					case TradeCaptureReportAck.TAG_NestedPartyRole:
						return _iNestedPartyRole;
					case TradeCaptureReportAck.TAG_NoNestedPartySubIDs:
						return _iNoNestedPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_NestedPartyID:
						_sNestedPartyID = (string)value;
						break;
					case TradeCaptureReportAck.TAG_NestedPartyIDSource:
						_cNestedPartyIDSource = (char)value;
						break;
					case TradeCaptureReportAck.TAG_NestedPartyRole:
						_iNestedPartyRole = (int)value;
						break;
					case TradeCaptureReportAck.TAG_NoNestedPartySubIDs:
						_iNoNestedPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckNestedPartyIDList
	{
		private ArrayList _al;
		private TradeCaptureReportAckNestedPartyID _last;

		public TradeCaptureReportAckNestedPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckNestedPartyID)_al[i];
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

		public void Add(TradeCaptureReportAckNestedPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckNestedPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckNestedPartyID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckNestedPartySubID
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
					case TradeCaptureReportAck.TAG_NestedPartySubID:
						return _sNestedPartySubID;
					case TradeCaptureReportAck.TAG_NestedPartySubIDType:
						return _iNestedPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_NestedPartySubID:
						_sNestedPartySubID = (string)value;
						break;
					case TradeCaptureReportAck.TAG_NestedPartySubIDType:
						_iNestedPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckNestedPartySubIDList
	{
		private ArrayList _al;
		private TradeCaptureReportAckNestedPartySubID _last;

		public TradeCaptureReportAckNestedPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckNestedPartySubID)_al[i];
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

		public void Add(TradeCaptureReportAckNestedPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckNestedPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckNestedPartySubID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckAlloc
	{
		private string _sAllocAccount;
		private int _iAllocAcctIDSource;
		private string _sAllocSettlCurrency;
		private string _sIndividualAllocID;
		private int _iNoNested2PartyIDs;
		private TradeCaptureReportAckNested2PartyIDList _listNested2PartyID = new TradeCaptureReportAckNested2PartyIDList();
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
		public TradeCaptureReportAckNested2PartyIDList Nested2PartyID 
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
					case TradeCaptureReportAck.TAG_AllocAccount:
						return _sAllocAccount;
					case TradeCaptureReportAck.TAG_AllocAcctIDSource:
						return _iAllocAcctIDSource;
					case TradeCaptureReportAck.TAG_AllocSettlCurrency:
						return _sAllocSettlCurrency;
					case TradeCaptureReportAck.TAG_IndividualAllocID:
						return _sIndividualAllocID;
					case TradeCaptureReportAck.TAG_NoNested2PartyIDs:
						return _iNoNested2PartyIDs;
					case TradeCaptureReportAck.TAG_AllocQty:
						return _iAllocQty;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_AllocAccount:
						_sAllocAccount = (string)value;
						break;
					case TradeCaptureReportAck.TAG_AllocAcctIDSource:
						_iAllocAcctIDSource = (int)value;
						break;
					case TradeCaptureReportAck.TAG_AllocSettlCurrency:
						_sAllocSettlCurrency = (string)value;
						break;
					case TradeCaptureReportAck.TAG_IndividualAllocID:
						_sIndividualAllocID = (string)value;
						break;
					case TradeCaptureReportAck.TAG_NoNested2PartyIDs:
						_iNoNested2PartyIDs = (int)value;
						break;
					case TradeCaptureReportAck.TAG_AllocQty:
						_iAllocQty = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckAllocList
	{
		private ArrayList _al;
		private TradeCaptureReportAckAlloc _last;

		public TradeCaptureReportAckAlloc this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckAlloc)_al[i];
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

		public void Add(TradeCaptureReportAckAlloc item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckAlloc item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckAlloc Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckNested2PartyID
	{
		private string _sNested2PartyID;
		private char _cNested2PartyIDSource;
		private int _iNested2PartyRole;
		private int _iNoNested2PartySubIDs;
		private TradeCaptureReportAckNested2PartySubIDList _listNested2PartySubID = new TradeCaptureReportAckNested2PartySubIDList();

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
		public TradeCaptureReportAckNested2PartySubIDList Nested2PartySubID 
		{
			get { return _listNested2PartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_Nested2PartyID:
						return _sNested2PartyID;
					case TradeCaptureReportAck.TAG_Nested2PartyIDSource:
						return _cNested2PartyIDSource;
					case TradeCaptureReportAck.TAG_Nested2PartyRole:
						return _iNested2PartyRole;
					case TradeCaptureReportAck.TAG_NoNested2PartySubIDs:
						return _iNoNested2PartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_Nested2PartyID:
						_sNested2PartyID = (string)value;
						break;
					case TradeCaptureReportAck.TAG_Nested2PartyIDSource:
						_cNested2PartyIDSource = (char)value;
						break;
					case TradeCaptureReportAck.TAG_Nested2PartyRole:
						_iNested2PartyRole = (int)value;
						break;
					case TradeCaptureReportAck.TAG_NoNested2PartySubIDs:
						_iNoNested2PartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckNested2PartyIDList
	{
		private ArrayList _al;
		private TradeCaptureReportAckNested2PartyID _last;

		public TradeCaptureReportAckNested2PartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckNested2PartyID)_al[i];
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

		public void Add(TradeCaptureReportAckNested2PartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckNested2PartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckNested2PartyID Last
		{
			get { return _last; }
		}
	}

	public class TradeCaptureReportAckNested2PartySubID
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
					case TradeCaptureReportAck.TAG_Nested2PartySubID:
						return _sNested2PartySubID;
					case TradeCaptureReportAck.TAG_Nested2PartySubIDType:
						return _iNested2PartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case TradeCaptureReportAck.TAG_Nested2PartySubID:
						_sNested2PartySubID = (string)value;
						break;
					case TradeCaptureReportAck.TAG_Nested2PartySubIDType:
						_iNested2PartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class TradeCaptureReportAckNested2PartySubIDList
	{
		private ArrayList _al;
		private TradeCaptureReportAckNested2PartySubID _last;

		public TradeCaptureReportAckNested2PartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (TradeCaptureReportAckNested2PartySubID)_al[i];
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

		public void Add(TradeCaptureReportAckNested2PartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(TradeCaptureReportAckNested2PartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public TradeCaptureReportAckNested2PartySubID Last
		{
			get { return _last; }
		}
	}
}
