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
	/// Summary description for CrossOrderCancelRequest.
	/// </summary>
	public class CrossOrderCancelRequest : Message
	{
		public const int TAG_OrderID = 37;
		public const int TAG_CrossID = 548;
		public const int TAG_OrigCrossID = 551;
		public const int TAG_CrossType = 549;
		public const int TAG_CrossPrioritization = 550;
		public const int TAG_NoSides = 552;
		public const int TAG_Side = 54;
		public const int TAG_OrigClOrdID = 41;
		public const int TAG_ClOrdID = 11;
		public const int TAG_SecondaryClOrdID = 526;
		public const int TAG_ClOrdLinkID = 583;
		public const int TAG_OrigOrdModTime = 586;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_TradeOriginationDate = 229;
		public const int TAG_TradeDate = 75;
		public const int TAG_OrderQty = 38;
		public const int TAG_CashOrderQty = 152;
		public const int TAG_OrderPercent = 516;
		public const int TAG_RoundingDirection = 468;
		public const int TAG_RoundingModulus = 469;
		public const int TAG_ComplianceID = 376;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
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
		public const int TAG_TransactTime = 60;

		private string _sOrderID;
		private string _sCrossID;
		private string _sOrigCrossID;
		private int _iCrossType;
		private int _iCrossPrioritization;
		private int _iNoSides;
		private CrossOrderCancelRequestSideList _listSide = new CrossOrderCancelRequestSideList();
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private CrossOrderCancelRequestSecurityAltIDList _listSecurityAltID = new CrossOrderCancelRequestSecurityAltIDList();
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
		private CrossOrderCancelRequestEventList _listEvent = new CrossOrderCancelRequestEventList();
		private DateTime _dtDatedDate;
		private DateTime _dtInterestAccrualDate;
		private int _iNoUnderlyings;
		private CrossOrderCancelRequestUnderlyingList _listUnderlying = new CrossOrderCancelRequestUnderlyingList();
		private int _iNoLegs;
		private CrossOrderCancelRequestLegList _listLeg = new CrossOrderCancelRequestLegList();
		private DateTime _dtTransactTime;

		public CrossOrderCancelRequest() : base()
		{
			_sMsgType = Values.MsgType.CrossOrderCancelRequest;
		}

		public string OrderID
		{
			get { return _sOrderID; }
			set { _sOrderID = value; }
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
		public int CrossPrioritization
		{
			get { return _iCrossPrioritization; }
			set { _iCrossPrioritization = value; }
		}
		public int NoSides
		{
			get { return _iNoSides; }
			set { _iNoSides = value; }
		}
		public CrossOrderCancelRequestSideList Side 
		{
			get { return _listSide; }
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
		public CrossOrderCancelRequestSecurityAltIDList SecurityAltID 
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
		public CrossOrderCancelRequestEventList Event 
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
		public CrossOrderCancelRequestUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
		}
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public CrossOrderCancelRequestLegList Leg 
		{
			get { return _listLeg; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_OrderID:
						return _sOrderID;
					case TAG_CrossID:
						return _sCrossID;
					case TAG_OrigCrossID:
						return _sOrigCrossID;
					case TAG_CrossType:
						return _iCrossType;
					case TAG_CrossPrioritization:
						return _iCrossPrioritization;
					case TAG_NoSides:
						return _iNoSides;
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
					case TAG_NoUnderlyings:
						return _iNoUnderlyings;
					case TAG_NoLegs:
						return _iNoLegs;
					case TAG_TransactTime:
						return _dtTransactTime;
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
					case TAG_CrossID:
						_sCrossID = (string)value;
						break;
					case TAG_OrigCrossID:
						_sOrigCrossID = (string)value;
						break;
					case TAG_CrossType:
						_iCrossType = (int)value;
						break;
					case TAG_CrossPrioritization:
						_iCrossPrioritization = (int)value;
						break;
					case TAG_NoSides:
						_iNoSides = (int)value;
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
					case TAG_NoUnderlyings:
						_iNoUnderlyings = (int)value;
						break;
					case TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class CrossOrderCancelRequestSide
	{
		private char _cSide;
		private string _sOrigClOrdID;
		private string _sClOrdID;
		private string _sSecondaryClOrdID;
		private string _sClOrdLinkID;
		private DateTime _dtOrigOrdModTime;
		private int _iNoPartyIDs;
		private CrossOrderCancelRequestPartyIDList _listPartyID = new CrossOrderCancelRequestPartyIDList();
		private DateTime _dtTradeOriginationDate;
		private DateTime _dtTradeDate;
		private int _iOrderQty;
		private int _iCashOrderQty;
		private double _dOrderPercent;
		private char _cRoundingDirection;
		private double _dRoundingModulus;
		private string _sComplianceID;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
		}
		public string OrigClOrdID
		{
			get { return _sOrigClOrdID; }
			set { _sOrigClOrdID = value; }
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
		public string ClOrdLinkID
		{
			get { return _sClOrdLinkID; }
			set { _sClOrdLinkID = value; }
		}
		public DateTime OrigOrdModTime
		{
			get { return _dtOrigOrdModTime; }
			set { _dtOrigOrdModTime = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public CrossOrderCancelRequestPartyIDList PartyID 
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
		public string ComplianceID
		{
			get { return _sComplianceID; }
			set { _sComplianceID = value; }
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
					case CrossOrderCancelRequest.TAG_Side:
						return _cSide;
					case CrossOrderCancelRequest.TAG_OrigClOrdID:
						return _sOrigClOrdID;
					case CrossOrderCancelRequest.TAG_ClOrdID:
						return _sClOrdID;
					case CrossOrderCancelRequest.TAG_SecondaryClOrdID:
						return _sSecondaryClOrdID;
					case CrossOrderCancelRequest.TAG_ClOrdLinkID:
						return _sClOrdLinkID;
					case CrossOrderCancelRequest.TAG_OrigOrdModTime:
						return _dtOrigOrdModTime;
					case CrossOrderCancelRequest.TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case CrossOrderCancelRequest.TAG_TradeOriginationDate:
						return _dtTradeOriginationDate;
					case CrossOrderCancelRequest.TAG_TradeDate:
						return _dtTradeDate;
					case CrossOrderCancelRequest.TAG_OrderQty:
						return _iOrderQty;
					case CrossOrderCancelRequest.TAG_CashOrderQty:
						return _iCashOrderQty;
					case CrossOrderCancelRequest.TAG_OrderPercent:
						return _dOrderPercent;
					case CrossOrderCancelRequest.TAG_RoundingDirection:
						return _cRoundingDirection;
					case CrossOrderCancelRequest.TAG_RoundingModulus:
						return _dRoundingModulus;
					case CrossOrderCancelRequest.TAG_ComplianceID:
						return _sComplianceID;
					case CrossOrderCancelRequest.TAG_Text:
						return _sText;
					case CrossOrderCancelRequest.TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case CrossOrderCancelRequest.TAG_EncodedText:
						return _sEncodedText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_Side:
						_cSide = (char)value;
						break;
					case CrossOrderCancelRequest.TAG_OrigClOrdID:
						_sOrigClOrdID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_SecondaryClOrdID:
						_sSecondaryClOrdID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_ClOrdLinkID:
						_sClOrdLinkID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_OrigOrdModTime:
						_dtOrigOrdModTime = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_TradeOriginationDate:
						_dtTradeOriginationDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_OrderQty:
						_iOrderQty = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_CashOrderQty:
						_iCashOrderQty = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_OrderPercent:
						_dOrderPercent = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_RoundingDirection:
						_cRoundingDirection = (char)value;
						break;
					case CrossOrderCancelRequest.TAG_RoundingModulus:
						_dRoundingModulus = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_ComplianceID:
						_sComplianceID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_Text:
						_sText = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedTextLen:
						_iEncodedTextLen = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedText:
						_sEncodedText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class CrossOrderCancelRequestSideList
	{
		private ArrayList _al;
		private CrossOrderCancelRequestSide _last;

		public CrossOrderCancelRequestSide this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (CrossOrderCancelRequestSide)_al[i];
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

		public void Add(CrossOrderCancelRequestSide item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(CrossOrderCancelRequestSide item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public CrossOrderCancelRequestSide Last
		{
			get { return _last; }
		}
	}

	public class CrossOrderCancelRequestPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private CrossOrderCancelRequestPartySubIDList _listPartySubID = new CrossOrderCancelRequestPartySubIDList();

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
		public CrossOrderCancelRequestPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_PartyID:
						return _sPartyID;
					case CrossOrderCancelRequest.TAG_PartyIDSource:
						return _cPartyIDSource;
					case CrossOrderCancelRequest.TAG_PartyRole:
						return _iPartyRole;
					case CrossOrderCancelRequest.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case CrossOrderCancelRequest.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class CrossOrderCancelRequestPartyIDList
	{
		private ArrayList _al;
		private CrossOrderCancelRequestPartyID _last;

		public CrossOrderCancelRequestPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (CrossOrderCancelRequestPartyID)_al[i];
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

		public void Add(CrossOrderCancelRequestPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(CrossOrderCancelRequestPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public CrossOrderCancelRequestPartyID Last
		{
			get { return _last; }
		}
	}

	public class CrossOrderCancelRequestPartySubID
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
					case CrossOrderCancelRequest.TAG_PartySubID:
						return _sPartySubID;
					case CrossOrderCancelRequest.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class CrossOrderCancelRequestPartySubIDList
	{
		private ArrayList _al;
		private CrossOrderCancelRequestPartySubID _last;

		public CrossOrderCancelRequestPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (CrossOrderCancelRequestPartySubID)_al[i];
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

		public void Add(CrossOrderCancelRequestPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(CrossOrderCancelRequestPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public CrossOrderCancelRequestPartySubID Last
		{
			get { return _last; }
		}
	}

	public class CrossOrderCancelRequestSecurityAltID
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
					case CrossOrderCancelRequest.TAG_SecurityAltID:
						return _sSecurityAltID;
					case CrossOrderCancelRequest.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class CrossOrderCancelRequestSecurityAltIDList
	{
		private ArrayList _al;
		private CrossOrderCancelRequestSecurityAltID _last;

		public CrossOrderCancelRequestSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (CrossOrderCancelRequestSecurityAltID)_al[i];
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

		public void Add(CrossOrderCancelRequestSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(CrossOrderCancelRequestSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public CrossOrderCancelRequestSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class CrossOrderCancelRequestEvent
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
					case CrossOrderCancelRequest.TAG_EventType:
						return _iEventType;
					case CrossOrderCancelRequest.TAG_EventDate:
						return _dtEventDate;
					case CrossOrderCancelRequest.TAG_EventPx:
						return _dEventPx;
					case CrossOrderCancelRequest.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_EventType:
						_iEventType = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class CrossOrderCancelRequestEventList
	{
		private ArrayList _al;
		private CrossOrderCancelRequestEvent _last;

		public CrossOrderCancelRequestEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (CrossOrderCancelRequestEvent)_al[i];
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

		public void Add(CrossOrderCancelRequestEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(CrossOrderCancelRequestEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public CrossOrderCancelRequestEvent Last
		{
			get { return _last; }
		}
	}

	public class CrossOrderCancelRequestUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private CrossOrderCancelRequestUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new CrossOrderCancelRequestUnderlyingSecurityAltIDList();
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
		public CrossOrderCancelRequestUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
					case CrossOrderCancelRequest.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case CrossOrderCancelRequest.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case CrossOrderCancelRequest.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case CrossOrderCancelRequest.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case CrossOrderCancelRequest.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case CrossOrderCancelRequest.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case CrossOrderCancelRequest.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case CrossOrderCancelRequest.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case CrossOrderCancelRequest.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case CrossOrderCancelRequest.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case CrossOrderCancelRequest.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case CrossOrderCancelRequest.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case CrossOrderCancelRequest.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case CrossOrderCancelRequest.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case CrossOrderCancelRequest.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case CrossOrderCancelRequest.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case CrossOrderCancelRequest.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case CrossOrderCancelRequest.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case CrossOrderCancelRequest.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case CrossOrderCancelRequest.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case CrossOrderCancelRequest.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case CrossOrderCancelRequest.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case CrossOrderCancelRequest.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case CrossOrderCancelRequest.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case CrossOrderCancelRequest.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case CrossOrderCancelRequest.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case CrossOrderCancelRequest.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case CrossOrderCancelRequest.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case CrossOrderCancelRequest.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case CrossOrderCancelRequest.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case CrossOrderCancelRequest.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case CrossOrderCancelRequest.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case CrossOrderCancelRequest.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case CrossOrderCancelRequest.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case CrossOrderCancelRequest.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case CrossOrderCancelRequest.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case CrossOrderCancelRequest.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case CrossOrderCancelRequest.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case CrossOrderCancelRequest.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case CrossOrderCancelRequest.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class CrossOrderCancelRequestUnderlyingList
	{
		private ArrayList _al;
		private CrossOrderCancelRequestUnderlying _last;

		public CrossOrderCancelRequestUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (CrossOrderCancelRequestUnderlying)_al[i];
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

		public void Add(CrossOrderCancelRequestUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(CrossOrderCancelRequestUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public CrossOrderCancelRequestUnderlying Last
		{
			get { return _last; }
		}
	}

	public class CrossOrderCancelRequestUnderlyingSecurityAltID
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
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class CrossOrderCancelRequestUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private CrossOrderCancelRequestUnderlyingSecurityAltID _last;

		public CrossOrderCancelRequestUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (CrossOrderCancelRequestUnderlyingSecurityAltID)_al[i];
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

		public void Add(CrossOrderCancelRequestUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(CrossOrderCancelRequestUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public CrossOrderCancelRequestUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class CrossOrderCancelRequestLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private CrossOrderCancelRequestLegSecurityAltIDList _listLegSecurityAltID = new CrossOrderCancelRequestLegSecurityAltIDList();
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
		public CrossOrderCancelRequestLegSecurityAltIDList LegSecurityAltID 
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
					case CrossOrderCancelRequest.TAG_LegSymbol:
						return _sLegSymbol;
					case CrossOrderCancelRequest.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case CrossOrderCancelRequest.TAG_LegSecurityID:
						return _sLegSecurityID;
					case CrossOrderCancelRequest.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case CrossOrderCancelRequest.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case CrossOrderCancelRequest.TAG_LegProduct:
						return _iLegProduct;
					case CrossOrderCancelRequest.TAG_LegCFICode:
						return _sLegCFICode;
					case CrossOrderCancelRequest.TAG_LegSecurityType:
						return _sLegSecurityType;
					case CrossOrderCancelRequest.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case CrossOrderCancelRequest.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case CrossOrderCancelRequest.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case CrossOrderCancelRequest.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case CrossOrderCancelRequest.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case CrossOrderCancelRequest.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case CrossOrderCancelRequest.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case CrossOrderCancelRequest.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case CrossOrderCancelRequest.TAG_LegFactor:
						return _dLegFactor;
					case CrossOrderCancelRequest.TAG_LegCreditRating:
						return _sLegCreditRating;
					case CrossOrderCancelRequest.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case CrossOrderCancelRequest.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case CrossOrderCancelRequest.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case CrossOrderCancelRequest.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case CrossOrderCancelRequest.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case CrossOrderCancelRequest.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case CrossOrderCancelRequest.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case CrossOrderCancelRequest.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case CrossOrderCancelRequest.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case CrossOrderCancelRequest.TAG_LegCouponRate:
						return _dLegCouponRate;
					case CrossOrderCancelRequest.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case CrossOrderCancelRequest.TAG_LegIssuer:
						return _sLegIssuer;
					case CrossOrderCancelRequest.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case CrossOrderCancelRequest.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case CrossOrderCancelRequest.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case CrossOrderCancelRequest.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case CrossOrderCancelRequest.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case CrossOrderCancelRequest.TAG_LegRatioQty:
						return _dLegRatioQty;
					case CrossOrderCancelRequest.TAG_LegSide:
						return _cLegSide;
					case CrossOrderCancelRequest.TAG_LegCurrency:
						return _sLegCurrency;
					case CrossOrderCancelRequest.TAG_LegPool:
						return _sLegPool;
					case CrossOrderCancelRequest.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case CrossOrderCancelRequest.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case CrossOrderCancelRequest.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case CrossOrderCancelRequest.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case CrossOrderCancelRequest.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case CrossOrderCancelRequest.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case CrossOrderCancelRequest.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case CrossOrderCancelRequest.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class CrossOrderCancelRequestLegList
	{
		private ArrayList _al;
		private CrossOrderCancelRequestLeg _last;

		public CrossOrderCancelRequestLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (CrossOrderCancelRequestLeg)_al[i];
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

		public void Add(CrossOrderCancelRequestLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(CrossOrderCancelRequestLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public CrossOrderCancelRequestLeg Last
		{
			get { return _last; }
		}
	}

	public class CrossOrderCancelRequestLegSecurityAltID
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
					case CrossOrderCancelRequest.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case CrossOrderCancelRequest.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case CrossOrderCancelRequest.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case CrossOrderCancelRequest.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class CrossOrderCancelRequestLegSecurityAltIDList
	{
		private ArrayList _al;
		private CrossOrderCancelRequestLegSecurityAltID _last;

		public CrossOrderCancelRequestLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (CrossOrderCancelRequestLegSecurityAltID)_al[i];
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

		public void Add(CrossOrderCancelRequestLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(CrossOrderCancelRequestLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public CrossOrderCancelRequestLegSecurityAltID Last
		{
			get { return _last; }
		}
	}
}
