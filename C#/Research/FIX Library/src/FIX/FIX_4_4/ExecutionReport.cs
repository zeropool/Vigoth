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
	/// Summary description for ExecutionReport.
	/// </summary>
	public class ExecutionReport : Message
	{
		public const int TAG_OrderID = 37;
		public const int TAG_SecondaryOrderID = 198;
		public const int TAG_SecondaryClOrdID = 526;
		public const int TAG_SecondaryExecID = 527;
		public const int TAG_ClOrdID = 11;
		public const int TAG_OrigClOrdID = 41;
		public const int TAG_ClOrdLinkID = 583;
		public const int TAG_QuoteRespID = 693;
		public const int TAG_OrdStatusReqID = 790;
		public const int TAG_MassStatusReqID = 584;
		public const int TAG_TotNumReports = 911;
		public const int TAG_LastRptRequested = 912;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_TradeOriginationDate = 229;
		public const int TAG_NoContraBrokers = 382;
		public const int TAG_ContraBroker = 375;
		public const int TAG_ContraTrader = 337;
		public const int TAG_ContraTradeQty = 437;
		public const int TAG_ContraTradeTime = 438;
		public const int TAG_ContraLegRefID = 655;
		public const int TAG_ListID = 66;
		public const int TAG_CrossID = 548;
		public const int TAG_OrigCrossID = 551;
		public const int TAG_CrossType = 549;
		public const int TAG_ExecID = 17;
		public const int TAG_ExecRefID = 19;
		public const int TAG_ExecType = 150;
		public const int TAG_OrdStatus = 39;
		public const int TAG_WorkingIndicator = 636;
		public const int TAG_OrdRejReason = 103;
		public const int TAG_ExecRestatementReason = 378;
		public const int TAG_Account = 1;
		public const int TAG_AcctIDSource = 660;
		public const int TAG_AccountType = 581;
		public const int TAG_DayBookingInst = 589;
		public const int TAG_BookingUnit = 590;
		public const int TAG_PreallocMethod = 591;
		public const int TAG_SettlType = 63;
		public const int TAG_SettlDate = 64;
		public const int TAG_CashMargin = 544;
		public const int TAG_ClearingFeeIndicator = 635;
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
		public const int TAG_PeggedPrice = 839;
		public const int TAG_DiscretionPrice = 845;
		public const int TAG_TargetStrategy = 847;
		public const int TAG_TargetStrategyParameters = 848;
		public const int TAG_ParticipationRate = 849;
		public const int TAG_TargetStrategyPerformance = 850;
		public const int TAG_Currency = 15;
		public const int TAG_ComplianceID = 376;
		public const int TAG_SolicitedFlag = 377;
		public const int TAG_TimeInForce = 59;
		public const int TAG_EffectiveTime = 168;
		public const int TAG_ExpireDate = 432;
		public const int TAG_ExpireTime = 126;
		public const int TAG_ExecInst = 18;
		public const int TAG_OrderCapacity = 528;
		public const int TAG_OrderRestrictions = 529;
		public const int TAG_CustOrderCapacity = 582;
		public const int TAG_LastQty = 32;
		public const int TAG_UnderlyingLastQty = 652;
		public const int TAG_LastPx = 31;
		public const int TAG_UnderlyingLastPx = 651;
		public const int TAG_LastParPx = 669;
		public const int TAG_LastSpotRate = 194;
		public const int TAG_LastForwardPoints = 195;
		public const int TAG_LastMkt = 30;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_TimeBracket = 943;
		public const int TAG_LastCapacity = 29;
		public const int TAG_LeavesQty = 151;
		public const int TAG_CumQty = 14;
		public const int TAG_AvgPx = 6;
		public const int TAG_DayOrderQty = 424;
		public const int TAG_DayCumQty = 425;
		public const int TAG_DayAvgPx = 426;
		public const int TAG_GTBookingInst = 427;
		public const int TAG_TradeDate = 75;
		public const int TAG_TransactTime = 60;
		public const int TAG_ReportToExch = 113;
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_CommCurrency = 479;
		public const int TAG_FundRenewWaiv = 497;
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
		public const int TAG_GrossTradeAmt = 381;
		public const int TAG_NumDaysInterest = 157;
		public const int TAG_ExDate = 230;
		public const int TAG_AccruedInterestRate = 158;
		public const int TAG_AccruedInterestAmt = 159;
		public const int TAG_InterestAtMaturity = 738;
		public const int TAG_EndAccruedInterestAmt = 920;
		public const int TAG_StartCash = 921;
		public const int TAG_EndCash = 922;
		public const int TAG_TradedFlatSwitch = 258;
		public const int TAG_BasisFeatureDate = 259;
		public const int TAG_BasisFeaturePrice = 260;
		public const int TAG_Concession = 238;
		public const int TAG_TotalTakedown = 237;
		public const int TAG_NetMoney = 118;
		public const int TAG_SettlCurrAmt = 119;
		public const int TAG_SettlCurrency = 120;
		public const int TAG_SettlCurrFxRate = 155;
		public const int TAG_SettlCurrFxRateCalc = 156;
		public const int TAG_HandlInst = 21;
		public const int TAG_MinQty = 110;
		public const int TAG_MaxFloor = 111;
		public const int TAG_PositionEffect = 77;
		public const int TAG_MaxShow = 210;
		public const int TAG_BookingType = 775;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_SettlDate2 = 193;
		public const int TAG_OrderQty2 = 192;
		public const int TAG_LastForwardPoints2 = 641;
		public const int TAG_MultiLegReportingType = 442;
		public const int TAG_CancellationRights = 480;
		public const int TAG_MoneyLaunderingStatus = 481;
		public const int TAG_RegistID = 513;
		public const int TAG_Designation = 494;
		public const int TAG_TransBkdTime = 483;
		public const int TAG_ExecValuationPoint = 515;
		public const int TAG_ExecPriceType = 484;
		public const int TAG_ExecPriceAdjustment = 485;
		public const int TAG_PriorityIndicator = 638;
		public const int TAG_PriceImprovement = 639;
		public const int TAG_LastLiquidityInd = 851;
		public const int TAG_NoContAmts = 518;
		public const int TAG_ContAmtType = 519;
		public const int TAG_ContAmtValue = 520;
		public const int TAG_ContAmtCurr = 521;
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
		public const int TAG_CopyMsgIndicator = 797;
		public const int TAG_NoMiscFees = 136;
		public const int TAG_MiscFeeAmt = 137;
		public const int TAG_MiscFeeCurr = 138;
		public const int TAG_MiscFeeType = 139;
		public const int TAG_MiscFeeBasis = 891;

		private string _sOrderID;
		private string _sSecondaryOrderID;
		private string _sSecondaryClOrdID;
		private string _sSecondaryExecID;
		private string _sClOrdID;
		private string _sOrigClOrdID;
		private string _sClOrdLinkID;
		private string _sQuoteRespID;
		private string _sOrdStatusReqID;
		private string _sMassStatusReqID;
		private int _iTotNumReports;
		private bool _bLastRptRequested;
		private int _iNoPartyIDs;
		private ExecutionReportPartyIDList _listPartyID = new ExecutionReportPartyIDList();
		private DateTime _dtTradeOriginationDate;
		private int _iNoContraBrokers;
		private ExecutionReportContraBrokerList _listContraBroker = new ExecutionReportContraBrokerList();
		private string _sListID;
		private string _sCrossID;
		private string _sOrigCrossID;
		private int _iCrossType;
		private string _sExecID;
		private string _sExecRefID;
		private char _cExecType;
		private char _cOrdStatus;
		private bool _bWorkingIndicator;
		private int _iOrdRejReason;
		private int _iExecRestatementReason;
		private string _sAccount;
		private int _iAcctIDSource;
		private int _iAccountType;
		private char _cDayBookingInst;
		private char _cBookingUnit;
		private char _cPreallocMethod;
		private char _cSettlType;
		private DateTime _dtSettlDate;
		private char _cCashMargin;
		private string _sClearingFeeIndicator;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private ExecutionReportSecurityAltIDList _listSecurityAltID = new ExecutionReportSecurityAltIDList();
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
		private ExecutionReportEventList _listEvent = new ExecutionReportEventList();
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
		private ExecutionReportUnderlyingList _listUnderlying = new ExecutionReportUnderlyingList();
		private char _cSide;
		private int _iNoStipulations;
		private ExecutionReportStipulationList _listStipulation = new ExecutionReportStipulationList();
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
		private double _dPeggedPrice;
		private double _dDiscretionPrice;
		private int _iTargetStrategy;
		private string _sTargetStrategyParameters;
		private double _dParticipationRate;
		private double _dTargetStrategyPerformance;
		private string _sCurrency;
		private string _sComplianceID;
		private bool _bSolicitedFlag;
		private char _cTimeInForce;
		private DateTime _dtEffectiveTime;
		private DateTime _dtExpireDate;
		private DateTime _dtExpireTime;
		private string _sExecInst;
		private char _cOrderCapacity;
		private string _sOrderRestrictions;
		private int _iCustOrderCapacity;
		private int _iLastQty;
		private int _iUnderlyingLastQty;
		private double _dLastPx;
		private double _dUnderlyingLastPx;
		private double _dLastParPx;
		private double _dLastSpotRate;
		private double _dLastForwardPoints;
		private string _sLastMkt;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private string _sTimeBracket;
		private char _cLastCapacity;
		private int _iLeavesQty;
		private int _iCumQty;
		private double _dAvgPx;
		private int _iDayOrderQty;
		private int _iDayCumQty;
		private double _dDayAvgPx;
		private int _iGTBookingInst;
		private DateTime _dtTradeDate;
		private DateTime _dtTransactTime;
		private bool _bReportToExch;
		private double _dCommission;
		private char _cCommType;
		private string _sCommCurrency;
		private char _cFundRenewWaiv;
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
		private double _dGrossTradeAmt;
		private int _iNumDaysInterest;
		private DateTime _dtExDate;
		private double _dAccruedInterestRate;
		private double _dAccruedInterestAmt;
		private double _dInterestAtMaturity;
		private double _dEndAccruedInterestAmt;
		private double _dStartCash;
		private double _dEndCash;
		private bool _bTradedFlatSwitch;
		private DateTime _dtBasisFeatureDate;
		private double _dBasisFeaturePrice;
		private double _dConcession;
		private double _dTotalTakedown;
		private double _dNetMoney;
		private double _dSettlCurrAmt;
		private string _sSettlCurrency;
		private double _dSettlCurrFxRate;
		private char _cSettlCurrFxRateCalc;
		private char _cHandlInst;
		private int _iMinQty;
		private int _iMaxFloor;
		private char _cPositionEffect;
		private int _iMaxShow;
		private int _iBookingType;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private DateTime _dtSettlDate2;
		private int _iOrderQty2;
		private double _dLastForwardPoints2;
		private char _cMultiLegReportingType;
		private char _cCancellationRights;
		private char _cMoneyLaunderingStatus;
		private string _sRegistID;
		private string _sDesignation;
		private DateTime _dtTransBkdTime;
		private DateTime _dtExecValuationPoint;
		private char _cExecPriceType;
		private double _dExecPriceAdjustment;
		private int _iPriorityIndicator;
		private double _dPriceImprovement;
		private int _iLastLiquidityInd;
		private int _iNoContAmts;
		private ExecutionReportContAmtList _listContAmt = new ExecutionReportContAmtList();
		private int _iNoLegs;
		private ExecutionReportLegList _listLeg = new ExecutionReportLegList();
		private bool _bCopyMsgIndicator;
		private int _iNoMiscFees;
		private ExecutionReportMiscFeeList _listMiscFee = new ExecutionReportMiscFeeList();

		public ExecutionReport() : base()
		{
			_sMsgType = Values.MsgType.ExecutionReport;
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
		public string SecondaryExecID
		{
			get { return _sSecondaryExecID; }
			set { _sSecondaryExecID = value; }
		}
		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public string OrigClOrdID
		{
			get { return _sOrigClOrdID; }
			set { _sOrigClOrdID = value; }
		}
		public string ClOrdLinkID
		{
			get { return _sClOrdLinkID; }
			set { _sClOrdLinkID = value; }
		}
		public string QuoteRespID
		{
			get { return _sQuoteRespID; }
			set { _sQuoteRespID = value; }
		}
		public string OrdStatusReqID
		{
			get { return _sOrdStatusReqID; }
			set { _sOrdStatusReqID = value; }
		}
		public string MassStatusReqID
		{
			get { return _sMassStatusReqID; }
			set { _sMassStatusReqID = value; }
		}
		public int TotNumReports
		{
			get { return _iTotNumReports; }
			set { _iTotNumReports = value; }
		}
		public bool LastRptRequested
		{
			get { return _bLastRptRequested; }
			set { _bLastRptRequested = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public ExecutionReportPartyIDList PartyID 
		{
			get { return _listPartyID; }
		}
		public DateTime TradeOriginationDate
		{
			get { return _dtTradeOriginationDate; }
			set { _dtTradeOriginationDate = value; }
		}
		public int NoContraBrokers
		{
			get { return _iNoContraBrokers; }
			set { _iNoContraBrokers = value; }
		}
		public ExecutionReportContraBrokerList ContraBroker 
		{
			get { return _listContraBroker; }
		}
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public string CrossID
		{
			get { return _sCrossID; }
			set { _sCrossID = value; }
		}
		public string OrigCrossID
		{
			get { return _sOrigCrossID; }
			set { _sOrigCrossID = value; }
		}
		public int CrossType
		{
			get { return _iCrossType; }
			set { _iCrossType = value; }
		}
		public string ExecID
		{
			get { return _sExecID; }
			set { _sExecID = value; }
		}
		public string ExecRefID
		{
			get { return _sExecRefID; }
			set { _sExecRefID = value; }
		}
		public char ExecType
		{
			get { return _cExecType; }
			set { _cExecType = value; }
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
		public int OrdRejReason
		{
			get { return _iOrdRejReason; }
			set { _iOrdRejReason = value; }
		}
		public int ExecRestatementReason
		{
			get { return _iExecRestatementReason; }
			set { _iExecRestatementReason = value; }
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
		public char PreallocMethod
		{
			get { return _cPreallocMethod; }
			set { _cPreallocMethod = value; }
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
		public ExecutionReportSecurityAltIDList SecurityAltID 
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
		public ExecutionReportEventList Event 
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
		public ExecutionReportUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
		}
		public int NoStipulations
		{
			get { return _iNoStipulations; }
			set { _iNoStipulations = value; }
		}
		public ExecutionReportStipulationList Stipulation 
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
		public double PeggedPrice
		{
			get { return _dPeggedPrice; }
			set { _dPeggedPrice = value; }
		}
		public double DiscretionPrice
		{
			get { return _dDiscretionPrice; }
			set { _dDiscretionPrice = value; }
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
		public double TargetStrategyPerformance
		{
			get { return _dTargetStrategyPerformance; }
			set { _dTargetStrategyPerformance = value; }
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
		public string ExecInst
		{
			get { return _sExecInst; }
			set { _sExecInst = value; }
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
		public int LastQty
		{
			get { return _iLastQty; }
			set { _iLastQty = value; }
		}
		public int UnderlyingLastQty
		{
			get { return _iUnderlyingLastQty; }
			set { _iUnderlyingLastQty = value; }
		}
		public double LastPx
		{
			get { return _dLastPx; }
			set { _dLastPx = value; }
		}
		public double UnderlyingLastPx
		{
			get { return _dUnderlyingLastPx; }
			set { _dUnderlyingLastPx = value; }
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
		public char LastCapacity
		{
			get { return _cLastCapacity; }
			set { _cLastCapacity = value; }
		}
		public int LeavesQty
		{
			get { return _iLeavesQty; }
			set { _iLeavesQty = value; }
		}
		public int CumQty
		{
			get { return _iCumQty; }
			set { _iCumQty = value; }
		}
		public double AvgPx
		{
			get { return _dAvgPx; }
			set { _dAvgPx = value; }
		}
		public int DayOrderQty
		{
			get { return _iDayOrderQty; }
			set { _iDayOrderQty = value; }
		}
		public int DayCumQty
		{
			get { return _iDayCumQty; }
			set { _iDayCumQty = value; }
		}
		public double DayAvgPx
		{
			get { return _dDayAvgPx; }
			set { _dDayAvgPx = value; }
		}
		public int GTBookingInst
		{
			get { return _iGTBookingInst; }
			set { _iGTBookingInst = value; }
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
		public bool ReportToExch
		{
			get { return _bReportToExch; }
			set { _bReportToExch = value; }
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
		public bool TradedFlatSwitch
		{
			get { return _bTradedFlatSwitch; }
			set { _bTradedFlatSwitch = value; }
		}
		public DateTime BasisFeatureDate
		{
			get { return _dtBasisFeatureDate; }
			set { _dtBasisFeatureDate = value; }
		}
		public double BasisFeaturePrice
		{
			get { return _dBasisFeaturePrice; }
			set { _dBasisFeaturePrice = value; }
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
		public char HandlInst
		{
			get { return _cHandlInst; }
			set { _cHandlInst = value; }
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
		public char PositionEffect
		{
			get { return _cPositionEffect; }
			set { _cPositionEffect = value; }
		}
		public int MaxShow
		{
			get { return _iMaxShow; }
			set { _iMaxShow = value; }
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
		public double LastForwardPoints2
		{
			get { return _dLastForwardPoints2; }
			set { _dLastForwardPoints2 = value; }
		}
		public char MultiLegReportingType
		{
			get { return _cMultiLegReportingType; }
			set { _cMultiLegReportingType = value; }
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
		public string Designation
		{
			get { return _sDesignation; }
			set { _sDesignation = value; }
		}
		public DateTime TransBkdTime
		{
			get { return _dtTransBkdTime; }
			set { _dtTransBkdTime = value; }
		}
		public DateTime ExecValuationPoint
		{
			get { return _dtExecValuationPoint; }
			set { _dtExecValuationPoint = value; }
		}
		public char ExecPriceType
		{
			get { return _cExecPriceType; }
			set { _cExecPriceType = value; }
		}
		public double ExecPriceAdjustment
		{
			get { return _dExecPriceAdjustment; }
			set { _dExecPriceAdjustment = value; }
		}
		public int PriorityIndicator
		{
			get { return _iPriorityIndicator; }
			set { _iPriorityIndicator = value; }
		}
		public double PriceImprovement
		{
			get { return _dPriceImprovement; }
			set { _dPriceImprovement = value; }
		}
		public int LastLiquidityInd
		{
			get { return _iLastLiquidityInd; }
			set { _iLastLiquidityInd = value; }
		}
		public int NoContAmts
		{
			get { return _iNoContAmts; }
			set { _iNoContAmts = value; }
		}
		public ExecutionReportContAmtList ContAmt 
		{
			get { return _listContAmt; }
		}
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public ExecutionReportLegList Leg 
		{
			get { return _listLeg; }
		}
		public bool CopyMsgIndicator
		{
			get { return _bCopyMsgIndicator; }
			set { _bCopyMsgIndicator = value; }
		}
		public int NoMiscFees
		{
			get { return _iNoMiscFees; }
			set { _iNoMiscFees = value; }
		}
		public ExecutionReportMiscFeeList MiscFee 
		{
			get { return _listMiscFee; }
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
					case TAG_SecondaryExecID:
						return _sSecondaryExecID;
					case TAG_ClOrdID:
						return _sClOrdID;
					case TAG_OrigClOrdID:
						return _sOrigClOrdID;
					case TAG_ClOrdLinkID:
						return _sClOrdLinkID;
					case TAG_QuoteRespID:
						return _sQuoteRespID;
					case TAG_OrdStatusReqID:
						return _sOrdStatusReqID;
					case TAG_MassStatusReqID:
						return _sMassStatusReqID;
					case TAG_TotNumReports:
						return _iTotNumReports;
					case TAG_LastRptRequested:
						return _bLastRptRequested;
					case TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case TAG_TradeOriginationDate:
						return _dtTradeOriginationDate;
					case TAG_NoContraBrokers:
						return _iNoContraBrokers;
					case TAG_ListID:
						return _sListID;
					case TAG_CrossID:
						return _sCrossID;
					case TAG_OrigCrossID:
						return _sOrigCrossID;
					case TAG_CrossType:
						return _iCrossType;
					case TAG_ExecID:
						return _sExecID;
					case TAG_ExecRefID:
						return _sExecRefID;
					case TAG_ExecType:
						return _cExecType;
					case TAG_OrdStatus:
						return _cOrdStatus;
					case TAG_WorkingIndicator:
						return _bWorkingIndicator;
					case TAG_OrdRejReason:
						return _iOrdRejReason;
					case TAG_ExecRestatementReason:
						return _iExecRestatementReason;
					case TAG_Account:
						return _sAccount;
					case TAG_AcctIDSource:
						return _iAcctIDSource;
					case TAG_AccountType:
						return _iAccountType;
					case TAG_DayBookingInst:
						return _cDayBookingInst;
					case TAG_BookingUnit:
						return _cBookingUnit;
					case TAG_PreallocMethod:
						return _cPreallocMethod;
					case TAG_SettlType:
						return _cSettlType;
					case TAG_SettlDate:
						return _dtSettlDate;
					case TAG_CashMargin:
						return _cCashMargin;
					case TAG_ClearingFeeIndicator:
						return _sClearingFeeIndicator;
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
					case TAG_NoStipulations:
						return _iNoStipulations;
					case TAG_QtyType:
						return _iQtyType;
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
					case TAG_OrdType:
						return _cOrdType;
					case TAG_PriceType:
						return _iPriceType;
					case TAG_Price:
						return _dPrice;
					case TAG_StopPx:
						return _dStopPx;
					case TAG_PegOffsetValue:
						return _dPegOffsetValue;
					case TAG_PegMoveType:
						return _iPegMoveType;
					case TAG_PegOffsetType:
						return _iPegOffsetType;
					case TAG_PegLimitType:
						return _iPegLimitType;
					case TAG_PegRoundDirection:
						return _iPegRoundDirection;
					case TAG_PegScope:
						return _iPegScope;
					case TAG_DiscretionInst:
						return _cDiscretionInst;
					case TAG_DiscretionOffsetValue:
						return _dDiscretionOffsetValue;
					case TAG_DiscretionMoveType:
						return _iDiscretionMoveType;
					case TAG_DiscretionOffsetType:
						return _iDiscretionOffsetType;
					case TAG_DiscretionLimitType:
						return _iDiscretionLimitType;
					case TAG_DiscretionRoundDirection:
						return _iDiscretionRoundDirection;
					case TAG_DiscretionScope:
						return _iDiscretionScope;
					case TAG_PeggedPrice:
						return _dPeggedPrice;
					case TAG_DiscretionPrice:
						return _dDiscretionPrice;
					case TAG_TargetStrategy:
						return _iTargetStrategy;
					case TAG_TargetStrategyParameters:
						return _sTargetStrategyParameters;
					case TAG_ParticipationRate:
						return _dParticipationRate;
					case TAG_TargetStrategyPerformance:
						return _dTargetStrategyPerformance;
					case TAG_Currency:
						return _sCurrency;
					case TAG_ComplianceID:
						return _sComplianceID;
					case TAG_SolicitedFlag:
						return _bSolicitedFlag;
					case TAG_TimeInForce:
						return _cTimeInForce;
					case TAG_EffectiveTime:
						return _dtEffectiveTime;
					case TAG_ExpireDate:
						return _dtExpireDate;
					case TAG_ExpireTime:
						return _dtExpireTime;
					case TAG_ExecInst:
						return _sExecInst;
					case TAG_OrderCapacity:
						return _cOrderCapacity;
					case TAG_OrderRestrictions:
						return _sOrderRestrictions;
					case TAG_CustOrderCapacity:
						return _iCustOrderCapacity;
					case TAG_LastQty:
						return _iLastQty;
					case TAG_UnderlyingLastQty:
						return _iUnderlyingLastQty;
					case TAG_LastPx:
						return _dLastPx;
					case TAG_UnderlyingLastPx:
						return _dUnderlyingLastPx;
					case TAG_LastParPx:
						return _dLastParPx;
					case TAG_LastSpotRate:
						return _dLastSpotRate;
					case TAG_LastForwardPoints:
						return _dLastForwardPoints;
					case TAG_LastMkt:
						return _sLastMkt;
					case TAG_TradingSessionID:
						return _sTradingSessionID;
					case TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case TAG_TimeBracket:
						return _sTimeBracket;
					case TAG_LastCapacity:
						return _cLastCapacity;
					case TAG_LeavesQty:
						return _iLeavesQty;
					case TAG_CumQty:
						return _iCumQty;
					case TAG_AvgPx:
						return _dAvgPx;
					case TAG_DayOrderQty:
						return _iDayOrderQty;
					case TAG_DayCumQty:
						return _iDayCumQty;
					case TAG_DayAvgPx:
						return _dDayAvgPx;
					case TAG_GTBookingInst:
						return _iGTBookingInst;
					case TAG_TradeDate:
						return _dtTradeDate;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_ReportToExch:
						return _bReportToExch;
					case TAG_Commission:
						return _dCommission;
					case TAG_CommType:
						return _cCommType;
					case TAG_CommCurrency:
						return _sCommCurrency;
					case TAG_FundRenewWaiv:
						return _cFundRenewWaiv;
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
					case TAG_TradedFlatSwitch:
						return _bTradedFlatSwitch;
					case TAG_BasisFeatureDate:
						return _dtBasisFeatureDate;
					case TAG_BasisFeaturePrice:
						return _dBasisFeaturePrice;
					case TAG_Concession:
						return _dConcession;
					case TAG_TotalTakedown:
						return _dTotalTakedown;
					case TAG_NetMoney:
						return _dNetMoney;
					case TAG_SettlCurrAmt:
						return _dSettlCurrAmt;
					case TAG_SettlCurrency:
						return _sSettlCurrency;
					case TAG_SettlCurrFxRate:
						return _dSettlCurrFxRate;
					case TAG_SettlCurrFxRateCalc:
						return _cSettlCurrFxRateCalc;
					case TAG_HandlInst:
						return _cHandlInst;
					case TAG_MinQty:
						return _iMinQty;
					case TAG_MaxFloor:
						return _iMaxFloor;
					case TAG_PositionEffect:
						return _cPositionEffect;
					case TAG_MaxShow:
						return _iMaxShow;
					case TAG_BookingType:
						return _iBookingType;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
					case TAG_SettlDate2:
						return _dtSettlDate2;
					case TAG_OrderQty2:
						return _iOrderQty2;
					case TAG_LastForwardPoints2:
						return _dLastForwardPoints2;
					case TAG_MultiLegReportingType:
						return _cMultiLegReportingType;
					case TAG_CancellationRights:
						return _cCancellationRights;
					case TAG_MoneyLaunderingStatus:
						return _cMoneyLaunderingStatus;
					case TAG_RegistID:
						return _sRegistID;
					case TAG_Designation:
						return _sDesignation;
					case TAG_TransBkdTime:
						return _dtTransBkdTime;
					case TAG_ExecValuationPoint:
						return _dtExecValuationPoint;
					case TAG_ExecPriceType:
						return _cExecPriceType;
					case TAG_ExecPriceAdjustment:
						return _dExecPriceAdjustment;
					case TAG_PriorityIndicator:
						return _iPriorityIndicator;
					case TAG_PriceImprovement:
						return _dPriceImprovement;
					case TAG_LastLiquidityInd:
						return _iLastLiquidityInd;
					case TAG_NoContAmts:
						return _iNoContAmts;
					case TAG_NoLegs:
						return _iNoLegs;
					case TAG_CopyMsgIndicator:
						return _bCopyMsgIndicator;
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
					case TAG_OrderID:
						_sOrderID = (string)value;
						break;
					case TAG_SecondaryOrderID:
						_sSecondaryOrderID = (string)value;
						break;
					case TAG_SecondaryClOrdID:
						_sSecondaryClOrdID = (string)value;
						break;
					case TAG_SecondaryExecID:
						_sSecondaryExecID = (string)value;
						break;
					case TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case TAG_OrigClOrdID:
						_sOrigClOrdID = (string)value;
						break;
					case TAG_ClOrdLinkID:
						_sClOrdLinkID = (string)value;
						break;
					case TAG_QuoteRespID:
						_sQuoteRespID = (string)value;
						break;
					case TAG_OrdStatusReqID:
						_sOrdStatusReqID = (string)value;
						break;
					case TAG_MassStatusReqID:
						_sMassStatusReqID = (string)value;
						break;
					case TAG_TotNumReports:
						_iTotNumReports = (int)value;
						break;
					case TAG_LastRptRequested:
						_bLastRptRequested = (bool)value;
						break;
					case TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case TAG_TradeOriginationDate:
						_dtTradeOriginationDate = (DateTime)value;
						break;
					case TAG_NoContraBrokers:
						_iNoContraBrokers = (int)value;
						break;
					case TAG_ListID:
						_sListID = (string)value;
						break;
					case TAG_CrossID:
						_sCrossID = (string)value;
						break;
					case TAG_OrigCrossID:
						_sOrigCrossID = (string)value;
						break;
					case TAG_CrossType:
						_iCrossType = (int)value;
						break;
					case TAG_ExecID:
						_sExecID = (string)value;
						break;
					case TAG_ExecRefID:
						_sExecRefID = (string)value;
						break;
					case TAG_ExecType:
						_cExecType = (char)value;
						break;
					case TAG_OrdStatus:
						_cOrdStatus = (char)value;
						break;
					case TAG_WorkingIndicator:
						_bWorkingIndicator = (bool)value;
						break;
					case TAG_OrdRejReason:
						_iOrdRejReason = (int)value;
						break;
					case TAG_ExecRestatementReason:
						_iExecRestatementReason = (int)value;
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
					case TAG_DayBookingInst:
						_cDayBookingInst = (char)value;
						break;
					case TAG_BookingUnit:
						_cBookingUnit = (char)value;
						break;
					case TAG_PreallocMethod:
						_cPreallocMethod = (char)value;
						break;
					case TAG_SettlType:
						_cSettlType = (char)value;
						break;
					case TAG_SettlDate:
						_dtSettlDate = (DateTime)value;
						break;
					case TAG_CashMargin:
						_cCashMargin = (char)value;
						break;
					case TAG_ClearingFeeIndicator:
						_sClearingFeeIndicator = (string)value;
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
					case TAG_NoStipulations:
						_iNoStipulations = (int)value;
						break;
					case TAG_QtyType:
						_iQtyType = (int)value;
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
					case TAG_OrdType:
						_cOrdType = (char)value;
						break;
					case TAG_PriceType:
						_iPriceType = (int)value;
						break;
					case TAG_Price:
						_dPrice = (double)value;
						break;
					case TAG_StopPx:
						_dStopPx = (double)value;
						break;
					case TAG_PegOffsetValue:
						_dPegOffsetValue = (double)value;
						break;
					case TAG_PegMoveType:
						_iPegMoveType = (int)value;
						break;
					case TAG_PegOffsetType:
						_iPegOffsetType = (int)value;
						break;
					case TAG_PegLimitType:
						_iPegLimitType = (int)value;
						break;
					case TAG_PegRoundDirection:
						_iPegRoundDirection = (int)value;
						break;
					case TAG_PegScope:
						_iPegScope = (int)value;
						break;
					case TAG_DiscretionInst:
						_cDiscretionInst = (char)value;
						break;
					case TAG_DiscretionOffsetValue:
						_dDiscretionOffsetValue = (double)value;
						break;
					case TAG_DiscretionMoveType:
						_iDiscretionMoveType = (int)value;
						break;
					case TAG_DiscretionOffsetType:
						_iDiscretionOffsetType = (int)value;
						break;
					case TAG_DiscretionLimitType:
						_iDiscretionLimitType = (int)value;
						break;
					case TAG_DiscretionRoundDirection:
						_iDiscretionRoundDirection = (int)value;
						break;
					case TAG_DiscretionScope:
						_iDiscretionScope = (int)value;
						break;
					case TAG_PeggedPrice:
						_dPeggedPrice = (double)value;
						break;
					case TAG_DiscretionPrice:
						_dDiscretionPrice = (double)value;
						break;
					case TAG_TargetStrategy:
						_iTargetStrategy = (int)value;
						break;
					case TAG_TargetStrategyParameters:
						_sTargetStrategyParameters = (string)value;
						break;
					case TAG_ParticipationRate:
						_dParticipationRate = (double)value;
						break;
					case TAG_TargetStrategyPerformance:
						_dTargetStrategyPerformance = (double)value;
						break;
					case TAG_Currency:
						_sCurrency = (string)value;
						break;
					case TAG_ComplianceID:
						_sComplianceID = (string)value;
						break;
					case TAG_SolicitedFlag:
						_bSolicitedFlag = (bool)value;
						break;
					case TAG_TimeInForce:
						_cTimeInForce = (char)value;
						break;
					case TAG_EffectiveTime:
						_dtEffectiveTime = (DateTime)value;
						break;
					case TAG_ExpireDate:
						_dtExpireDate = (DateTime)value;
						break;
					case TAG_ExpireTime:
						_dtExpireTime = (DateTime)value;
						break;
					case TAG_ExecInst:
						_sExecInst = (string)value;
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
					case TAG_LastQty:
						_iLastQty = (int)value;
						break;
					case TAG_UnderlyingLastQty:
						_iUnderlyingLastQty = (int)value;
						break;
					case TAG_LastPx:
						_dLastPx = (double)value;
						break;
					case TAG_UnderlyingLastPx:
						_dUnderlyingLastPx = (double)value;
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
					case TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case TAG_TimeBracket:
						_sTimeBracket = (string)value;
						break;
					case TAG_LastCapacity:
						_cLastCapacity = (char)value;
						break;
					case TAG_LeavesQty:
						_iLeavesQty = (int)value;
						break;
					case TAG_CumQty:
						_iCumQty = (int)value;
						break;
					case TAG_AvgPx:
						_dAvgPx = (double)value;
						break;
					case TAG_DayOrderQty:
						_iDayOrderQty = (int)value;
						break;
					case TAG_DayCumQty:
						_iDayCumQty = (int)value;
						break;
					case TAG_DayAvgPx:
						_dDayAvgPx = (double)value;
						break;
					case TAG_GTBookingInst:
						_iGTBookingInst = (int)value;
						break;
					case TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_ReportToExch:
						_bReportToExch = (bool)value;
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
					case TAG_TradedFlatSwitch:
						_bTradedFlatSwitch = (bool)value;
						break;
					case TAG_BasisFeatureDate:
						_dtBasisFeatureDate = (DateTime)value;
						break;
					case TAG_BasisFeaturePrice:
						_dBasisFeaturePrice = (double)value;
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
					case TAG_HandlInst:
						_cHandlInst = (char)value;
						break;
					case TAG_MinQty:
						_iMinQty = (int)value;
						break;
					case TAG_MaxFloor:
						_iMaxFloor = (int)value;
						break;
					case TAG_PositionEffect:
						_cPositionEffect = (char)value;
						break;
					case TAG_MaxShow:
						_iMaxShow = (int)value;
						break;
					case TAG_BookingType:
						_iBookingType = (int)value;
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
					case TAG_SettlDate2:
						_dtSettlDate2 = (DateTime)value;
						break;
					case TAG_OrderQty2:
						_iOrderQty2 = (int)value;
						break;
					case TAG_LastForwardPoints2:
						_dLastForwardPoints2 = (double)value;
						break;
					case TAG_MultiLegReportingType:
						_cMultiLegReportingType = (char)value;
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
					case TAG_Designation:
						_sDesignation = (string)value;
						break;
					case TAG_TransBkdTime:
						_dtTransBkdTime = (DateTime)value;
						break;
					case TAG_ExecValuationPoint:
						_dtExecValuationPoint = (DateTime)value;
						break;
					case TAG_ExecPriceType:
						_cExecPriceType = (char)value;
						break;
					case TAG_ExecPriceAdjustment:
						_dExecPriceAdjustment = (double)value;
						break;
					case TAG_PriorityIndicator:
						_iPriorityIndicator = (int)value;
						break;
					case TAG_PriceImprovement:
						_dPriceImprovement = (double)value;
						break;
					case TAG_LastLiquidityInd:
						_iLastLiquidityInd = (int)value;
						break;
					case TAG_NoContAmts:
						_iNoContAmts = (int)value;
						break;
					case TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					case TAG_CopyMsgIndicator:
						_bCopyMsgIndicator = (bool)value;
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

	public class ExecutionReportPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private ExecutionReportPartySubIDList _listPartySubID = new ExecutionReportPartySubIDList();

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
		public ExecutionReportPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_PartyID:
						return _sPartyID;
					case ExecutionReport.TAG_PartyIDSource:
						return _cPartyIDSource;
					case ExecutionReport.TAG_PartyRole:
						return _iPartyRole;
					case ExecutionReport.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case ExecutionReport.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case ExecutionReport.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case ExecutionReport.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportPartyIDList
	{
		private ArrayList _al;
		private ExecutionReportPartyID _last;

		public ExecutionReportPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportPartyID)_al[i];
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

		public void Add(ExecutionReportPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportPartyID Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportPartySubID
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
					case ExecutionReport.TAG_PartySubID:
						return _sPartySubID;
					case ExecutionReport.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case ExecutionReport.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportPartySubIDList
	{
		private ArrayList _al;
		private ExecutionReportPartySubID _last;

		public ExecutionReportPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportPartySubID)_al[i];
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

		public void Add(ExecutionReportPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportPartySubID Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportContraBroker
	{
		private string _sContraBroker;
		private string _sContraTrader;
		private int _iContraTradeQty;
		private DateTime _dtContraTradeTime;
		private string _sContraLegRefID;

		public string ContraBroker
		{
			get { return _sContraBroker; }
			set { _sContraBroker = value; }
		}
		public string ContraTrader
		{
			get { return _sContraTrader; }
			set { _sContraTrader = value; }
		}
		public int ContraTradeQty
		{
			get { return _iContraTradeQty; }
			set { _iContraTradeQty = value; }
		}
		public DateTime ContraTradeTime
		{
			get { return _dtContraTradeTime; }
			set { _dtContraTradeTime = value; }
		}
		public string ContraLegRefID
		{
			get { return _sContraLegRefID; }
			set { _sContraLegRefID = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_ContraBroker:
						return _sContraBroker;
					case ExecutionReport.TAG_ContraTrader:
						return _sContraTrader;
					case ExecutionReport.TAG_ContraTradeQty:
						return _iContraTradeQty;
					case ExecutionReport.TAG_ContraTradeTime:
						return _dtContraTradeTime;
					case ExecutionReport.TAG_ContraLegRefID:
						return _sContraLegRefID;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_ContraBroker:
						_sContraBroker = (string)value;
						break;
					case ExecutionReport.TAG_ContraTrader:
						_sContraTrader = (string)value;
						break;
					case ExecutionReport.TAG_ContraTradeQty:
						_iContraTradeQty = (int)value;
						break;
					case ExecutionReport.TAG_ContraTradeTime:
						_dtContraTradeTime = (DateTime)value;
						break;
					case ExecutionReport.TAG_ContraLegRefID:
						_sContraLegRefID = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportContraBrokerList
	{
		private ArrayList _al;
		private ExecutionReportContraBroker _last;

		public ExecutionReportContraBroker this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportContraBroker)_al[i];
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

		public void Add(ExecutionReportContraBroker item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportContraBroker item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportContraBroker Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportSecurityAltID
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
					case ExecutionReport.TAG_SecurityAltID:
						return _sSecurityAltID;
					case ExecutionReport.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case ExecutionReport.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportSecurityAltIDList
	{
		private ArrayList _al;
		private ExecutionReportSecurityAltID _last;

		public ExecutionReportSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportSecurityAltID)_al[i];
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

		public void Add(ExecutionReportSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportEvent
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
					case ExecutionReport.TAG_EventType:
						return _iEventType;
					case ExecutionReport.TAG_EventDate:
						return _dtEventDate;
					case ExecutionReport.TAG_EventPx:
						return _dEventPx;
					case ExecutionReport.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_EventType:
						_iEventType = (int)value;
						break;
					case ExecutionReport.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case ExecutionReport.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportEventList
	{
		private ArrayList _al;
		private ExecutionReportEvent _last;

		public ExecutionReportEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportEvent)_al[i];
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

		public void Add(ExecutionReportEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportEvent Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private ExecutionReportUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new ExecutionReportUnderlyingSecurityAltIDList();
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
		public ExecutionReportUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
					case ExecutionReport.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case ExecutionReport.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case ExecutionReport.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case ExecutionReport.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case ExecutionReport.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case ExecutionReport.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case ExecutionReport.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case ExecutionReport.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case ExecutionReport.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case ExecutionReport.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case ExecutionReport.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case ExecutionReport.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case ExecutionReport.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case ExecutionReport.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case ExecutionReport.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case ExecutionReport.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case ExecutionReport.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case ExecutionReport.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case ExecutionReport.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case ExecutionReport.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case ExecutionReport.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case ExecutionReport.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case ExecutionReport.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case ExecutionReport.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case ExecutionReport.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case ExecutionReport.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case ExecutionReport.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case ExecutionReport.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case ExecutionReport.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case ExecutionReport.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case ExecutionReport.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case ExecutionReport.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case ExecutionReport.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case ExecutionReport.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case ExecutionReport.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case ExecutionReport.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case ExecutionReport.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case ExecutionReport.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case ExecutionReport.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case ExecutionReport.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case ExecutionReport.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case ExecutionReport.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case ExecutionReport.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case ExecutionReport.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case ExecutionReport.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case ExecutionReport.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case ExecutionReport.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case ExecutionReport.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case ExecutionReport.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case ExecutionReport.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case ExecutionReport.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case ExecutionReport.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case ExecutionReport.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case ExecutionReport.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case ExecutionReport.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case ExecutionReport.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case ExecutionReport.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case ExecutionReport.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportUnderlyingList
	{
		private ArrayList _al;
		private ExecutionReportUnderlying _last;

		public ExecutionReportUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportUnderlying)_al[i];
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

		public void Add(ExecutionReportUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportUnderlying Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportUnderlyingSecurityAltID
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
					case ExecutionReport.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case ExecutionReport.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case ExecutionReport.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private ExecutionReportUnderlyingSecurityAltID _last;

		public ExecutionReportUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportUnderlyingSecurityAltID)_al[i];
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

		public void Add(ExecutionReportUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportStipulation
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
					case ExecutionReport.TAG_StipulationType:
						return _sStipulationType;
					case ExecutionReport.TAG_StipulationValue:
						return _sStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_StipulationType:
						_sStipulationType = (string)value;
						break;
					case ExecutionReport.TAG_StipulationValue:
						_sStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportStipulationList
	{
		private ArrayList _al;
		private ExecutionReportStipulation _last;

		public ExecutionReportStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportStipulation)_al[i];
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

		public void Add(ExecutionReportStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportStipulation Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportContAmt
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
					case ExecutionReport.TAG_ContAmtType:
						return _iContAmtType;
					case ExecutionReport.TAG_ContAmtValue:
						return _dContAmtValue;
					case ExecutionReport.TAG_ContAmtCurr:
						return _sContAmtCurr;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_ContAmtType:
						_iContAmtType = (int)value;
						break;
					case ExecutionReport.TAG_ContAmtValue:
						_dContAmtValue = (double)value;
						break;
					case ExecutionReport.TAG_ContAmtCurr:
						_sContAmtCurr = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportContAmtList
	{
		private ArrayList _al;
		private ExecutionReportContAmt _last;

		public ExecutionReportContAmt this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportContAmt)_al[i];
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

		public void Add(ExecutionReportContAmt item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportContAmt item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportContAmt Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private ExecutionReportLegSecurityAltIDList _listLegSecurityAltID = new ExecutionReportLegSecurityAltIDList();
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
		private ExecutionReportLegStipulationList _listLegStipulation = new ExecutionReportLegStipulationList();
		private char _cLegPositionEffect;
		private int _iLegCoveredOrUncovered;
		private int _iNoNestedPartyIDs;
		private ExecutionReportNestedPartyIDList _listNestedPartyID = new ExecutionReportNestedPartyIDList();
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
		public ExecutionReportLegSecurityAltIDList LegSecurityAltID 
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
		public ExecutionReportLegStipulationList LegStipulation 
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
		public ExecutionReportNestedPartyIDList NestedPartyID 
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
					case ExecutionReport.TAG_LegSymbol:
						return _sLegSymbol;
					case ExecutionReport.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case ExecutionReport.TAG_LegSecurityID:
						return _sLegSecurityID;
					case ExecutionReport.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case ExecutionReport.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case ExecutionReport.TAG_LegProduct:
						return _iLegProduct;
					case ExecutionReport.TAG_LegCFICode:
						return _sLegCFICode;
					case ExecutionReport.TAG_LegSecurityType:
						return _sLegSecurityType;
					case ExecutionReport.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case ExecutionReport.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case ExecutionReport.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case ExecutionReport.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case ExecutionReport.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case ExecutionReport.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case ExecutionReport.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case ExecutionReport.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case ExecutionReport.TAG_LegFactor:
						return _dLegFactor;
					case ExecutionReport.TAG_LegCreditRating:
						return _sLegCreditRating;
					case ExecutionReport.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case ExecutionReport.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case ExecutionReport.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case ExecutionReport.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case ExecutionReport.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case ExecutionReport.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case ExecutionReport.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case ExecutionReport.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case ExecutionReport.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case ExecutionReport.TAG_LegCouponRate:
						return _dLegCouponRate;
					case ExecutionReport.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case ExecutionReport.TAG_LegIssuer:
						return _sLegIssuer;
					case ExecutionReport.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case ExecutionReport.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case ExecutionReport.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case ExecutionReport.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case ExecutionReport.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case ExecutionReport.TAG_LegRatioQty:
						return _dLegRatioQty;
					case ExecutionReport.TAG_LegSide:
						return _cLegSide;
					case ExecutionReport.TAG_LegCurrency:
						return _sLegCurrency;
					case ExecutionReport.TAG_LegPool:
						return _sLegPool;
					case ExecutionReport.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case ExecutionReport.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case ExecutionReport.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					case ExecutionReport.TAG_LegQty:
						return _iLegQty;
					case ExecutionReport.TAG_LegSwapType:
						return _iLegSwapType;
					case ExecutionReport.TAG_NoLegStipulations:
						return _iNoLegStipulations;
					case ExecutionReport.TAG_LegPositionEffect:
						return _cLegPositionEffect;
					case ExecutionReport.TAG_LegCoveredOrUncovered:
						return _iLegCoveredOrUncovered;
					case ExecutionReport.TAG_NoNestedPartyIDs:
						return _iNoNestedPartyIDs;
					case ExecutionReport.TAG_LegRefID:
						return _sLegRefID;
					case ExecutionReport.TAG_LegPrice:
						return _dLegPrice;
					case ExecutionReport.TAG_LegSettlType:
						return _cLegSettlType;
					case ExecutionReport.TAG_LegSettlDate:
						return _dtLegSettlDate;
					case ExecutionReport.TAG_LegLastPx:
						return _dLegLastPx;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case ExecutionReport.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case ExecutionReport.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case ExecutionReport.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case ExecutionReport.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case ExecutionReport.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case ExecutionReport.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case ExecutionReport.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case ExecutionReport.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case ExecutionReport.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case ExecutionReport.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case ExecutionReport.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case ExecutionReport.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case ExecutionReport.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case ExecutionReport.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case ExecutionReport.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case ExecutionReport.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case ExecutionReport.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case ExecutionReport.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case ExecutionReport.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case ExecutionReport.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case ExecutionReport.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case ExecutionReport.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case ExecutionReport.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case ExecutionReport.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case ExecutionReport.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case ExecutionReport.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case ExecutionReport.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case ExecutionReport.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case ExecutionReport.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case ExecutionReport.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case ExecutionReport.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case ExecutionReport.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case ExecutionReport.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case ExecutionReport.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case ExecutionReport.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case ExecutionReport.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_LegQty:
						_iLegQty = (int)value;
						break;
					case ExecutionReport.TAG_LegSwapType:
						_iLegSwapType = (int)value;
						break;
					case ExecutionReport.TAG_NoLegStipulations:
						_iNoLegStipulations = (int)value;
						break;
					case ExecutionReport.TAG_LegPositionEffect:
						_cLegPositionEffect = (char)value;
						break;
					case ExecutionReport.TAG_LegCoveredOrUncovered:
						_iLegCoveredOrUncovered = (int)value;
						break;
					case ExecutionReport.TAG_NoNestedPartyIDs:
						_iNoNestedPartyIDs = (int)value;
						break;
					case ExecutionReport.TAG_LegRefID:
						_sLegRefID = (string)value;
						break;
					case ExecutionReport.TAG_LegPrice:
						_dLegPrice = (double)value;
						break;
					case ExecutionReport.TAG_LegSettlType:
						_cLegSettlType = (char)value;
						break;
					case ExecutionReport.TAG_LegSettlDate:
						_dtLegSettlDate = (DateTime)value;
						break;
					case ExecutionReport.TAG_LegLastPx:
						_dLegLastPx = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportLegList
	{
		private ArrayList _al;
		private ExecutionReportLeg _last;

		public ExecutionReportLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportLeg)_al[i];
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

		public void Add(ExecutionReportLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportLeg Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportLegSecurityAltID
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
					case ExecutionReport.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case ExecutionReport.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case ExecutionReport.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportLegSecurityAltIDList
	{
		private ArrayList _al;
		private ExecutionReportLegSecurityAltID _last;

		public ExecutionReportLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportLegSecurityAltID)_al[i];
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

		public void Add(ExecutionReportLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportLegSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportLegStipulation
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
					case ExecutionReport.TAG_LegStipulationType:
						return _sLegStipulationType;
					case ExecutionReport.TAG_LegStipulationValue:
						return _sLegStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_LegStipulationType:
						_sLegStipulationType = (string)value;
						break;
					case ExecutionReport.TAG_LegStipulationValue:
						_sLegStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportLegStipulationList
	{
		private ArrayList _al;
		private ExecutionReportLegStipulation _last;

		public ExecutionReportLegStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportLegStipulation)_al[i];
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

		public void Add(ExecutionReportLegStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportLegStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportLegStipulation Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportNestedPartyID
	{
		private string _sNestedPartyID;
		private char _cNestedPartyIDSource;
		private int _iNestedPartyRole;
		private int _iNoNestedPartySubIDs;
		private ExecutionReportNestedPartySubIDList _listNestedPartySubID = new ExecutionReportNestedPartySubIDList();

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
		public ExecutionReportNestedPartySubIDList NestedPartySubID 
		{
			get { return _listNestedPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_NestedPartyID:
						return _sNestedPartyID;
					case ExecutionReport.TAG_NestedPartyIDSource:
						return _cNestedPartyIDSource;
					case ExecutionReport.TAG_NestedPartyRole:
						return _iNestedPartyRole;
					case ExecutionReport.TAG_NoNestedPartySubIDs:
						return _iNoNestedPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_NestedPartyID:
						_sNestedPartyID = (string)value;
						break;
					case ExecutionReport.TAG_NestedPartyIDSource:
						_cNestedPartyIDSource = (char)value;
						break;
					case ExecutionReport.TAG_NestedPartyRole:
						_iNestedPartyRole = (int)value;
						break;
					case ExecutionReport.TAG_NoNestedPartySubIDs:
						_iNoNestedPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportNestedPartyIDList
	{
		private ArrayList _al;
		private ExecutionReportNestedPartyID _last;

		public ExecutionReportNestedPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportNestedPartyID)_al[i];
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

		public void Add(ExecutionReportNestedPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportNestedPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportNestedPartyID Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportNestedPartySubID
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
					case ExecutionReport.TAG_NestedPartySubID:
						return _sNestedPartySubID;
					case ExecutionReport.TAG_NestedPartySubIDType:
						return _iNestedPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_NestedPartySubID:
						_sNestedPartySubID = (string)value;
						break;
					case ExecutionReport.TAG_NestedPartySubIDType:
						_iNestedPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportNestedPartySubIDList
	{
		private ArrayList _al;
		private ExecutionReportNestedPartySubID _last;

		public ExecutionReportNestedPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportNestedPartySubID)_al[i];
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

		public void Add(ExecutionReportNestedPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportNestedPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportNestedPartySubID Last
		{
			get { return _last; }
		}
	}

	public class ExecutionReportMiscFee
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
					case ExecutionReport.TAG_MiscFeeAmt:
						return _dMiscFeeAmt;
					case ExecutionReport.TAG_MiscFeeCurr:
						return _sMiscFeeCurr;
					case ExecutionReport.TAG_MiscFeeType:
						return _cMiscFeeType;
					case ExecutionReport.TAG_MiscFeeBasis:
						return _iMiscFeeBasis;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ExecutionReport.TAG_MiscFeeAmt:
						_dMiscFeeAmt = (double)value;
						break;
					case ExecutionReport.TAG_MiscFeeCurr:
						_sMiscFeeCurr = (string)value;
						break;
					case ExecutionReport.TAG_MiscFeeType:
						_cMiscFeeType = (char)value;
						break;
					case ExecutionReport.TAG_MiscFeeBasis:
						_iMiscFeeBasis = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ExecutionReportMiscFeeList
	{
		private ArrayList _al;
		private ExecutionReportMiscFee _last;

		public ExecutionReportMiscFee this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ExecutionReportMiscFee)_al[i];
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

		public void Add(ExecutionReportMiscFee item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ExecutionReportMiscFee item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ExecutionReportMiscFee Last
		{
			get { return _last; }
		}
	}
}
