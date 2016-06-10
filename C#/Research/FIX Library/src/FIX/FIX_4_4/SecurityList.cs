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
	/// Summary description for SecurityList.
	/// </summary>
	public class SecurityList : Message
	{
		public const int TAG_SecurityReqID = 320;
		public const int TAG_SecurityResponseID = 322;
		public const int TAG_SecurityRequestResult = 560;
		public const int TAG_TotNoRelatedSym = 393;
		public const int TAG_LastFragment = 893;
		public const int TAG_NoRelatedSym = 146;
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
		public const int TAG_Currency = 15;
		public const int TAG_NoStipulations = 232;
		public const int TAG_StipulationType = 233;
		public const int TAG_StipulationValue = 234;
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
		public const int TAG_LegSwapType = 690;
		public const int TAG_LegSettlType = 587;
		public const int TAG_NoLegStipulations = 683;
		public const int TAG_LegStipulationType = 688;
		public const int TAG_LegStipulationValue = 689;
		public const int TAG_LegBenchmarkCurveCurrency = 676;
		public const int TAG_LegBenchmarkCurveName = 677;
		public const int TAG_LegBenchmarkCurvePoint = 678;
		public const int TAG_LegBenchmarkPrice = 679;
		public const int TAG_LegBenchmarkPriceType = 680;
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
		public const int TAG_RoundLot = 561;
		public const int TAG_MinTradeVol = 562;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_ExpirationCycle = 827;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sSecurityReqID;
		private string _sSecurityResponseID;
		private int _iSecurityRequestResult;
		private int _iTotNoRelatedSym;
		private bool _bLastFragment;
		private int _iNoRelatedSym;
		private SecurityListRelatedSymList _listRelatedSym = new SecurityListRelatedSymList();

		public SecurityList() : base()
		{
			_sMsgType = Values.MsgType.SecurityList;
		}

		public string SecurityReqID
		{
			get { return _sSecurityReqID; }
			set { _sSecurityReqID = value; }
		}
		public string SecurityResponseID
		{
			get { return _sSecurityResponseID; }
			set { _sSecurityResponseID = value; }
		}
		public int SecurityRequestResult
		{
			get { return _iSecurityRequestResult; }
			set { _iSecurityRequestResult = value; }
		}
		public int TotNoRelatedSym
		{
			get { return _iTotNoRelatedSym; }
			set { _iTotNoRelatedSym = value; }
		}
		public bool LastFragment
		{
			get { return _bLastFragment; }
			set { _bLastFragment = value; }
		}
		public int NoRelatedSym
		{
			get { return _iNoRelatedSym; }
			set { _iNoRelatedSym = value; }
		}
		public SecurityListRelatedSymList RelatedSym 
		{
			get { return _listRelatedSym; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_SecurityReqID:
						return _sSecurityReqID;
					case TAG_SecurityResponseID:
						return _sSecurityResponseID;
					case TAG_SecurityRequestResult:
						return _iSecurityRequestResult;
					case TAG_TotNoRelatedSym:
						return _iTotNoRelatedSym;
					case TAG_LastFragment:
						return _bLastFragment;
					case TAG_NoRelatedSym:
						return _iNoRelatedSym;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_SecurityReqID:
						_sSecurityReqID = (string)value;
						break;
					case TAG_SecurityResponseID:
						_sSecurityResponseID = (string)value;
						break;
					case TAG_SecurityRequestResult:
						_iSecurityRequestResult = (int)value;
						break;
					case TAG_TotNoRelatedSym:
						_iTotNoRelatedSym = (int)value;
						break;
					case TAG_LastFragment:
						_bLastFragment = (bool)value;
						break;
					case TAG_NoRelatedSym:
						_iNoRelatedSym = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class SecurityListRelatedSym
	{
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private SecurityListSecurityAltIDList _listSecurityAltID = new SecurityListSecurityAltIDList();
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
		private SecurityListEventList _listEvent = new SecurityListEventList();
		private DateTime _dtDatedDate;
		private DateTime _dtInterestAccrualDate;
		private int _iDeliveryForm;
		private double _dPctAtRisk;
		private int _iNoInstrAttrib;
		private SecurityListInstrAttribList _listInstrAttrib = new SecurityListInstrAttribList();
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
		private SecurityListUnderlyingList _listUnderlying = new SecurityListUnderlyingList();
		private string _sCurrency;
		private int _iNoStipulations;
		private SecurityListStipulationList _listStipulation = new SecurityListStipulationList();
		private int _iNoLegs;
		private SecurityListLegList _listLeg = new SecurityListLegList();
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
		private int _iRoundLot;
		private int _iMinTradeVol;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private int _iExpirationCycle;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

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
		public SecurityListSecurityAltIDList SecurityAltID 
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
		public SecurityListEventList Event 
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
		public SecurityListInstrAttribList InstrAttrib 
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
		public SecurityListUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
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
		public SecurityListStipulationList Stipulation 
		{
			get { return _listStipulation; }
		}
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public SecurityListLegList Leg 
		{
			get { return _listLeg; }
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
		public int RoundLot
		{
			get { return _iRoundLot; }
			set { _iRoundLot = value; }
		}
		public int MinTradeVol
		{
			get { return _iMinTradeVol; }
			set { _iMinTradeVol = value; }
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
		public int ExpirationCycle
		{
			get { return _iExpirationCycle; }
			set { _iExpirationCycle = value; }
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
					case SecurityList.TAG_Symbol:
						return _sSymbol;
					case SecurityList.TAG_SymbolSfx:
						return _sSymbolSfx;
					case SecurityList.TAG_SecurityID:
						return _sSecurityID;
					case SecurityList.TAG_SecurityIDSource:
						return _sSecurityIDSource;
					case SecurityList.TAG_NoSecurityAltID:
						return _iNoSecurityAltID;
					case SecurityList.TAG_Product:
						return _iProduct;
					case SecurityList.TAG_CFICode:
						return _sCFICode;
					case SecurityList.TAG_SecurityType:
						return _sSecurityType;
					case SecurityList.TAG_SecuritySubType:
						return _sSecuritySubType;
					case SecurityList.TAG_MaturityMonthYear:
						return _dtMaturityMonthYear;
					case SecurityList.TAG_MaturityDate:
						return _dtMaturityDate;
					case SecurityList.TAG_CouponPaymentDate:
						return _dtCouponPaymentDate;
					case SecurityList.TAG_IssueDate:
						return _dtIssueDate;
					case SecurityList.TAG_RepoCollateralSecurityType:
						return _iRepoCollateralSecurityType;
					case SecurityList.TAG_RepurchaseTerm:
						return _iRepurchaseTerm;
					case SecurityList.TAG_RepurchaseRate:
						return _dRepurchaseRate;
					case SecurityList.TAG_Factor:
						return _dFactor;
					case SecurityList.TAG_CreditRating:
						return _sCreditRating;
					case SecurityList.TAG_InstrRegistry:
						return _sInstrRegistry;
					case SecurityList.TAG_CountryOfIssue:
						return _sCountryOfIssue;
					case SecurityList.TAG_StateOrProvinceOfIssue:
						return _sStateOrProvinceOfIssue;
					case SecurityList.TAG_LocaleOfIssue:
						return _sLocaleOfIssue;
					case SecurityList.TAG_RedemptionDate:
						return _dtRedemptionDate;
					case SecurityList.TAG_StrikePrice:
						return _dStrikePrice;
					case SecurityList.TAG_StrikeCurrency:
						return _sStrikeCurrency;
					case SecurityList.TAG_OptAttribute:
						return _cOptAttribute;
					case SecurityList.TAG_ContractMultiplier:
						return _dContractMultiplier;
					case SecurityList.TAG_CouponRate:
						return _dCouponRate;
					case SecurityList.TAG_SecurityExchange:
						return _sSecurityExchange;
					case SecurityList.TAG_Issuer:
						return _sIssuer;
					case SecurityList.TAG_EncodedIssuerLen:
						return _iEncodedIssuerLen;
					case SecurityList.TAG_EncodedIssuer:
						return _sEncodedIssuer;
					case SecurityList.TAG_SecurityDesc:
						return _sSecurityDesc;
					case SecurityList.TAG_EncodedSecurityDescLen:
						return _iEncodedSecurityDescLen;
					case SecurityList.TAG_EncodedSecurityDesc:
						return _sEncodedSecurityDesc;
					case SecurityList.TAG_Pool:
						return _sPool;
					case SecurityList.TAG_ContractSettlMonth:
						return _dtContractSettlMonth;
					case SecurityList.TAG_CPProgram:
						return _iCPProgram;
					case SecurityList.TAG_CPRegType:
						return _sCPRegType;
					case SecurityList.TAG_NoEvents:
						return _iNoEvents;
					case SecurityList.TAG_DatedDate:
						return _dtDatedDate;
					case SecurityList.TAG_InterestAccrualDate:
						return _dtInterestAccrualDate;
					case SecurityList.TAG_DeliveryForm:
						return _iDeliveryForm;
					case SecurityList.TAG_PctAtRisk:
						return _dPctAtRisk;
					case SecurityList.TAG_NoInstrAttrib:
						return _iNoInstrAttrib;
					case SecurityList.TAG_AgreementDesc:
						return _sAgreementDesc;
					case SecurityList.TAG_AgreementID:
						return _sAgreementID;
					case SecurityList.TAG_AgreementDate:
						return _dtAgreementDate;
					case SecurityList.TAG_AgreementCurrency:
						return _sAgreementCurrency;
					case SecurityList.TAG_TerminationType:
						return _iTerminationType;
					case SecurityList.TAG_StartDate:
						return _dtStartDate;
					case SecurityList.TAG_EndDate:
						return _dtEndDate;
					case SecurityList.TAG_DeliveryType:
						return _iDeliveryType;
					case SecurityList.TAG_MarginRatio:
						return _dMarginRatio;
					case SecurityList.TAG_NoUnderlyings:
						return _iNoUnderlyings;
					case SecurityList.TAG_Currency:
						return _sCurrency;
					case SecurityList.TAG_NoStipulations:
						return _iNoStipulations;
					case SecurityList.TAG_NoLegs:
						return _iNoLegs;
					case SecurityList.TAG_Spread:
						return _dSpread;
					case SecurityList.TAG_BenchmarkCurveCurrency:
						return _sBenchmarkCurveCurrency;
					case SecurityList.TAG_BenchmarkCurveName:
						return _sBenchmarkCurveName;
					case SecurityList.TAG_BenchmarkCurvePoint:
						return _sBenchmarkCurvePoint;
					case SecurityList.TAG_BenchmarkPrice:
						return _dBenchmarkPrice;
					case SecurityList.TAG_BenchmarkPriceType:
						return _iBenchmarkPriceType;
					case SecurityList.TAG_BenchmarkSecurityID:
						return _sBenchmarkSecurityID;
					case SecurityList.TAG_BenchmarkSecurityIDSource:
						return _sBenchmarkSecurityIDSource;
					case SecurityList.TAG_YieldType:
						return _sYieldType;
					case SecurityList.TAG_Yield:
						return _dYield;
					case SecurityList.TAG_YieldCalcDate:
						return _dtYieldCalcDate;
					case SecurityList.TAG_YieldRedemptionDate:
						return _dtYieldRedemptionDate;
					case SecurityList.TAG_YieldRedemptionPrice:
						return _dYieldRedemptionPrice;
					case SecurityList.TAG_YieldRedemptionPriceType:
						return _iYieldRedemptionPriceType;
					case SecurityList.TAG_RoundLot:
						return _iRoundLot;
					case SecurityList.TAG_MinTradeVol:
						return _iMinTradeVol;
					case SecurityList.TAG_TradingSessionID:
						return _sTradingSessionID;
					case SecurityList.TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case SecurityList.TAG_ExpirationCycle:
						return _iExpirationCycle;
					case SecurityList.TAG_Text:
						return _sText;
					case SecurityList.TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case SecurityList.TAG_EncodedText:
						return _sEncodedText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_Symbol:
						_sSymbol = (string)value;
						break;
					case SecurityList.TAG_SymbolSfx:
						_sSymbolSfx = (string)value;
						break;
					case SecurityList.TAG_SecurityID:
						_sSecurityID = (string)value;
						break;
					case SecurityList.TAG_SecurityIDSource:
						_sSecurityIDSource = (string)value;
						break;
					case SecurityList.TAG_NoSecurityAltID:
						_iNoSecurityAltID = (int)value;
						break;
					case SecurityList.TAG_Product:
						_iProduct = (int)value;
						break;
					case SecurityList.TAG_CFICode:
						_sCFICode = (string)value;
						break;
					case SecurityList.TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case SecurityList.TAG_SecuritySubType:
						_sSecuritySubType = (string)value;
						break;
					case SecurityList.TAG_MaturityMonthYear:
						_dtMaturityMonthYear = (DateTime)value;
						break;
					case SecurityList.TAG_MaturityDate:
						_dtMaturityDate = (DateTime)value;
						break;
					case SecurityList.TAG_CouponPaymentDate:
						_dtCouponPaymentDate = (DateTime)value;
						break;
					case SecurityList.TAG_IssueDate:
						_dtIssueDate = (DateTime)value;
						break;
					case SecurityList.TAG_RepoCollateralSecurityType:
						_iRepoCollateralSecurityType = (int)value;
						break;
					case SecurityList.TAG_RepurchaseTerm:
						_iRepurchaseTerm = (int)value;
						break;
					case SecurityList.TAG_RepurchaseRate:
						_dRepurchaseRate = (double)value;
						break;
					case SecurityList.TAG_Factor:
						_dFactor = (double)value;
						break;
					case SecurityList.TAG_CreditRating:
						_sCreditRating = (string)value;
						break;
					case SecurityList.TAG_InstrRegistry:
						_sInstrRegistry = (string)value;
						break;
					case SecurityList.TAG_CountryOfIssue:
						_sCountryOfIssue = (string)value;
						break;
					case SecurityList.TAG_StateOrProvinceOfIssue:
						_sStateOrProvinceOfIssue = (string)value;
						break;
					case SecurityList.TAG_LocaleOfIssue:
						_sLocaleOfIssue = (string)value;
						break;
					case SecurityList.TAG_RedemptionDate:
						_dtRedemptionDate = (DateTime)value;
						break;
					case SecurityList.TAG_StrikePrice:
						_dStrikePrice = (double)value;
						break;
					case SecurityList.TAG_StrikeCurrency:
						_sStrikeCurrency = (string)value;
						break;
					case SecurityList.TAG_OptAttribute:
						_cOptAttribute = (char)value;
						break;
					case SecurityList.TAG_ContractMultiplier:
						_dContractMultiplier = (double)value;
						break;
					case SecurityList.TAG_CouponRate:
						_dCouponRate = (double)value;
						break;
					case SecurityList.TAG_SecurityExchange:
						_sSecurityExchange = (string)value;
						break;
					case SecurityList.TAG_Issuer:
						_sIssuer = (string)value;
						break;
					case SecurityList.TAG_EncodedIssuerLen:
						_iEncodedIssuerLen = (int)value;
						break;
					case SecurityList.TAG_EncodedIssuer:
						_sEncodedIssuer = (string)value;
						break;
					case SecurityList.TAG_SecurityDesc:
						_sSecurityDesc = (string)value;
						break;
					case SecurityList.TAG_EncodedSecurityDescLen:
						_iEncodedSecurityDescLen = (int)value;
						break;
					case SecurityList.TAG_EncodedSecurityDesc:
						_sEncodedSecurityDesc = (string)value;
						break;
					case SecurityList.TAG_Pool:
						_sPool = (string)value;
						break;
					case SecurityList.TAG_ContractSettlMonth:
						_dtContractSettlMonth = (DateTime)value;
						break;
					case SecurityList.TAG_CPProgram:
						_iCPProgram = (int)value;
						break;
					case SecurityList.TAG_CPRegType:
						_sCPRegType = (string)value;
						break;
					case SecurityList.TAG_NoEvents:
						_iNoEvents = (int)value;
						break;
					case SecurityList.TAG_DatedDate:
						_dtDatedDate = (DateTime)value;
						break;
					case SecurityList.TAG_InterestAccrualDate:
						_dtInterestAccrualDate = (DateTime)value;
						break;
					case SecurityList.TAG_DeliveryForm:
						_iDeliveryForm = (int)value;
						break;
					case SecurityList.TAG_PctAtRisk:
						_dPctAtRisk = (double)value;
						break;
					case SecurityList.TAG_NoInstrAttrib:
						_iNoInstrAttrib = (int)value;
						break;
					case SecurityList.TAG_AgreementDesc:
						_sAgreementDesc = (string)value;
						break;
					case SecurityList.TAG_AgreementID:
						_sAgreementID = (string)value;
						break;
					case SecurityList.TAG_AgreementDate:
						_dtAgreementDate = (DateTime)value;
						break;
					case SecurityList.TAG_AgreementCurrency:
						_sAgreementCurrency = (string)value;
						break;
					case SecurityList.TAG_TerminationType:
						_iTerminationType = (int)value;
						break;
					case SecurityList.TAG_StartDate:
						_dtStartDate = (DateTime)value;
						break;
					case SecurityList.TAG_EndDate:
						_dtEndDate = (DateTime)value;
						break;
					case SecurityList.TAG_DeliveryType:
						_iDeliveryType = (int)value;
						break;
					case SecurityList.TAG_MarginRatio:
						_dMarginRatio = (double)value;
						break;
					case SecurityList.TAG_NoUnderlyings:
						_iNoUnderlyings = (int)value;
						break;
					case SecurityList.TAG_Currency:
						_sCurrency = (string)value;
						break;
					case SecurityList.TAG_NoStipulations:
						_iNoStipulations = (int)value;
						break;
					case SecurityList.TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					case SecurityList.TAG_Spread:
						_dSpread = (double)value;
						break;
					case SecurityList.TAG_BenchmarkCurveCurrency:
						_sBenchmarkCurveCurrency = (string)value;
						break;
					case SecurityList.TAG_BenchmarkCurveName:
						_sBenchmarkCurveName = (string)value;
						break;
					case SecurityList.TAG_BenchmarkCurvePoint:
						_sBenchmarkCurvePoint = (string)value;
						break;
					case SecurityList.TAG_BenchmarkPrice:
						_dBenchmarkPrice = (double)value;
						break;
					case SecurityList.TAG_BenchmarkPriceType:
						_iBenchmarkPriceType = (int)value;
						break;
					case SecurityList.TAG_BenchmarkSecurityID:
						_sBenchmarkSecurityID = (string)value;
						break;
					case SecurityList.TAG_BenchmarkSecurityIDSource:
						_sBenchmarkSecurityIDSource = (string)value;
						break;
					case SecurityList.TAG_YieldType:
						_sYieldType = (string)value;
						break;
					case SecurityList.TAG_Yield:
						_dYield = (double)value;
						break;
					case SecurityList.TAG_YieldCalcDate:
						_dtYieldCalcDate = (DateTime)value;
						break;
					case SecurityList.TAG_YieldRedemptionDate:
						_dtYieldRedemptionDate = (DateTime)value;
						break;
					case SecurityList.TAG_YieldRedemptionPrice:
						_dYieldRedemptionPrice = (double)value;
						break;
					case SecurityList.TAG_YieldRedemptionPriceType:
						_iYieldRedemptionPriceType = (int)value;
						break;
					case SecurityList.TAG_RoundLot:
						_iRoundLot = (int)value;
						break;
					case SecurityList.TAG_MinTradeVol:
						_iMinTradeVol = (int)value;
						break;
					case SecurityList.TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case SecurityList.TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case SecurityList.TAG_ExpirationCycle:
						_iExpirationCycle = (int)value;
						break;
					case SecurityList.TAG_Text:
						_sText = (string)value;
						break;
					case SecurityList.TAG_EncodedTextLen:
						_iEncodedTextLen = (int)value;
						break;
					case SecurityList.TAG_EncodedText:
						_sEncodedText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListRelatedSymList
	{
		private ArrayList _al;
		private SecurityListRelatedSym _last;

		public SecurityListRelatedSym this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListRelatedSym)_al[i];
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

		public void Add(SecurityListRelatedSym item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListRelatedSym item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListRelatedSym Last
		{
			get { return _last; }
		}
	}

	public class SecurityListSecurityAltID
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
					case SecurityList.TAG_SecurityAltID:
						return _sSecurityAltID;
					case SecurityList.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case SecurityList.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListSecurityAltIDList
	{
		private ArrayList _al;
		private SecurityListSecurityAltID _last;

		public SecurityListSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListSecurityAltID)_al[i];
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

		public void Add(SecurityListSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class SecurityListEvent
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
					case SecurityList.TAG_EventType:
						return _iEventType;
					case SecurityList.TAG_EventDate:
						return _dtEventDate;
					case SecurityList.TAG_EventPx:
						return _dEventPx;
					case SecurityList.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_EventType:
						_iEventType = (int)value;
						break;
					case SecurityList.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case SecurityList.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case SecurityList.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListEventList
	{
		private ArrayList _al;
		private SecurityListEvent _last;

		public SecurityListEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListEvent)_al[i];
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

		public void Add(SecurityListEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListEvent Last
		{
			get { return _last; }
		}
	}

	public class SecurityListInstrAttrib
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
					case SecurityList.TAG_InstrAttribType:
						return _iInstrAttribType;
					case SecurityList.TAG_InstrAttribValue:
						return _sInstrAttribValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_InstrAttribType:
						_iInstrAttribType = (int)value;
						break;
					case SecurityList.TAG_InstrAttribValue:
						_sInstrAttribValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListInstrAttribList
	{
		private ArrayList _al;
		private SecurityListInstrAttrib _last;

		public SecurityListInstrAttrib this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListInstrAttrib)_al[i];
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

		public void Add(SecurityListInstrAttrib item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListInstrAttrib item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListInstrAttrib Last
		{
			get { return _last; }
		}
	}

	public class SecurityListUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private SecurityListUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new SecurityListUnderlyingSecurityAltIDList();
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
		public SecurityListUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
					case SecurityList.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case SecurityList.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case SecurityList.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case SecurityList.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case SecurityList.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case SecurityList.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case SecurityList.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case SecurityList.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case SecurityList.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case SecurityList.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case SecurityList.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case SecurityList.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case SecurityList.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case SecurityList.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case SecurityList.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case SecurityList.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case SecurityList.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case SecurityList.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case SecurityList.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case SecurityList.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case SecurityList.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case SecurityList.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case SecurityList.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case SecurityList.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case SecurityList.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case SecurityList.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case SecurityList.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case SecurityList.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case SecurityList.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case SecurityList.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case SecurityList.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case SecurityList.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case SecurityList.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case SecurityList.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case SecurityList.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case SecurityList.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case SecurityList.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case SecurityList.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case SecurityList.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case SecurityList.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case SecurityList.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case SecurityList.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case SecurityList.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case SecurityList.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case SecurityList.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case SecurityList.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case SecurityList.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case SecurityList.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case SecurityList.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case SecurityList.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case SecurityList.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case SecurityList.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case SecurityList.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case SecurityList.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case SecurityList.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case SecurityList.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case SecurityList.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case SecurityList.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case SecurityList.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case SecurityList.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case SecurityList.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case SecurityList.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case SecurityList.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case SecurityList.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case SecurityList.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case SecurityList.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case SecurityList.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case SecurityList.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case SecurityList.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case SecurityList.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case SecurityList.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case SecurityList.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case SecurityList.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case SecurityList.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case SecurityList.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case SecurityList.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case SecurityList.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case SecurityList.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case SecurityList.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case SecurityList.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case SecurityList.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case SecurityList.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case SecurityList.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case SecurityList.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case SecurityList.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case SecurityList.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case SecurityList.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case SecurityList.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case SecurityList.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListUnderlyingList
	{
		private ArrayList _al;
		private SecurityListUnderlying _last;

		public SecurityListUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListUnderlying)_al[i];
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

		public void Add(SecurityListUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListUnderlying Last
		{
			get { return _last; }
		}
	}

	public class SecurityListUnderlyingSecurityAltID
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
					case SecurityList.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case SecurityList.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case SecurityList.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private SecurityListUnderlyingSecurityAltID _last;

		public SecurityListUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListUnderlyingSecurityAltID)_al[i];
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

		public void Add(SecurityListUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class SecurityListStipulation
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
					case SecurityList.TAG_StipulationType:
						return _sStipulationType;
					case SecurityList.TAG_StipulationValue:
						return _sStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_StipulationType:
						_sStipulationType = (string)value;
						break;
					case SecurityList.TAG_StipulationValue:
						_sStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListStipulationList
	{
		private ArrayList _al;
		private SecurityListStipulation _last;

		public SecurityListStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListStipulation)_al[i];
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

		public void Add(SecurityListStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListStipulation Last
		{
			get { return _last; }
		}
	}

	public class SecurityListLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private SecurityListLegSecurityAltIDList _listLegSecurityAltID = new SecurityListLegSecurityAltIDList();
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
		private int _iLegSwapType;
		private char _cLegSettlType;
		private int _iNoLegStipulations;
		private SecurityListLegStipulationList _listLegStipulation = new SecurityListLegStipulationList();
		private string _sLegBenchmarkCurveCurrency;
		private string _sLegBenchmarkCurveName;
		private string _sLegBenchmarkCurvePoint;
		private double _dLegBenchmarkPrice;
		private int _iLegBenchmarkPriceType;

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
		public SecurityListLegSecurityAltIDList LegSecurityAltID 
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
		public int NoLegStipulations
		{
			get { return _iNoLegStipulations; }
			set { _iNoLegStipulations = value; }
		}
		public SecurityListLegStipulationList LegStipulation 
		{
			get { return _listLegStipulation; }
		}
		public string LegBenchmarkCurveCurrency
		{
			get { return _sLegBenchmarkCurveCurrency; }
			set { _sLegBenchmarkCurveCurrency = value; }
		}
		public string LegBenchmarkCurveName
		{
			get { return _sLegBenchmarkCurveName; }
			set { _sLegBenchmarkCurveName = value; }
		}
		public string LegBenchmarkCurvePoint
		{
			get { return _sLegBenchmarkCurvePoint; }
			set { _sLegBenchmarkCurvePoint = value; }
		}
		public double LegBenchmarkPrice
		{
			get { return _dLegBenchmarkPrice; }
			set { _dLegBenchmarkPrice = value; }
		}
		public int LegBenchmarkPriceType
		{
			get { return _iLegBenchmarkPriceType; }
			set { _iLegBenchmarkPriceType = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case SecurityList.TAG_LegSymbol:
						return _sLegSymbol;
					case SecurityList.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case SecurityList.TAG_LegSecurityID:
						return _sLegSecurityID;
					case SecurityList.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case SecurityList.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case SecurityList.TAG_LegProduct:
						return _iLegProduct;
					case SecurityList.TAG_LegCFICode:
						return _sLegCFICode;
					case SecurityList.TAG_LegSecurityType:
						return _sLegSecurityType;
					case SecurityList.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case SecurityList.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case SecurityList.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case SecurityList.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case SecurityList.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case SecurityList.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case SecurityList.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case SecurityList.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case SecurityList.TAG_LegFactor:
						return _dLegFactor;
					case SecurityList.TAG_LegCreditRating:
						return _sLegCreditRating;
					case SecurityList.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case SecurityList.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case SecurityList.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case SecurityList.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case SecurityList.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case SecurityList.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case SecurityList.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case SecurityList.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case SecurityList.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case SecurityList.TAG_LegCouponRate:
						return _dLegCouponRate;
					case SecurityList.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case SecurityList.TAG_LegIssuer:
						return _sLegIssuer;
					case SecurityList.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case SecurityList.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case SecurityList.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case SecurityList.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case SecurityList.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case SecurityList.TAG_LegRatioQty:
						return _dLegRatioQty;
					case SecurityList.TAG_LegSide:
						return _cLegSide;
					case SecurityList.TAG_LegCurrency:
						return _sLegCurrency;
					case SecurityList.TAG_LegPool:
						return _sLegPool;
					case SecurityList.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case SecurityList.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case SecurityList.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					case SecurityList.TAG_LegSwapType:
						return _iLegSwapType;
					case SecurityList.TAG_LegSettlType:
						return _cLegSettlType;
					case SecurityList.TAG_NoLegStipulations:
						return _iNoLegStipulations;
					case SecurityList.TAG_LegBenchmarkCurveCurrency:
						return _sLegBenchmarkCurveCurrency;
					case SecurityList.TAG_LegBenchmarkCurveName:
						return _sLegBenchmarkCurveName;
					case SecurityList.TAG_LegBenchmarkCurvePoint:
						return _sLegBenchmarkCurvePoint;
					case SecurityList.TAG_LegBenchmarkPrice:
						return _dLegBenchmarkPrice;
					case SecurityList.TAG_LegBenchmarkPriceType:
						return _iLegBenchmarkPriceType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case SecurityList.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case SecurityList.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case SecurityList.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case SecurityList.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case SecurityList.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case SecurityList.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case SecurityList.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case SecurityList.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case SecurityList.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case SecurityList.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case SecurityList.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case SecurityList.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case SecurityList.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case SecurityList.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case SecurityList.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case SecurityList.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case SecurityList.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case SecurityList.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case SecurityList.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case SecurityList.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case SecurityList.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case SecurityList.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case SecurityList.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case SecurityList.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case SecurityList.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case SecurityList.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case SecurityList.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case SecurityList.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case SecurityList.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case SecurityList.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case SecurityList.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case SecurityList.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case SecurityList.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case SecurityList.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case SecurityList.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case SecurityList.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case SecurityList.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case SecurityList.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case SecurityList.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case SecurityList.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case SecurityList.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					case SecurityList.TAG_LegSwapType:
						_iLegSwapType = (int)value;
						break;
					case SecurityList.TAG_LegSettlType:
						_cLegSettlType = (char)value;
						break;
					case SecurityList.TAG_NoLegStipulations:
						_iNoLegStipulations = (int)value;
						break;
					case SecurityList.TAG_LegBenchmarkCurveCurrency:
						_sLegBenchmarkCurveCurrency = (string)value;
						break;
					case SecurityList.TAG_LegBenchmarkCurveName:
						_sLegBenchmarkCurveName = (string)value;
						break;
					case SecurityList.TAG_LegBenchmarkCurvePoint:
						_sLegBenchmarkCurvePoint = (string)value;
						break;
					case SecurityList.TAG_LegBenchmarkPrice:
						_dLegBenchmarkPrice = (double)value;
						break;
					case SecurityList.TAG_LegBenchmarkPriceType:
						_iLegBenchmarkPriceType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListLegList
	{
		private ArrayList _al;
		private SecurityListLeg _last;

		public SecurityListLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListLeg)_al[i];
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

		public void Add(SecurityListLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListLeg Last
		{
			get { return _last; }
		}
	}

	public class SecurityListLegSecurityAltID
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
					case SecurityList.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case SecurityList.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case SecurityList.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListLegSecurityAltIDList
	{
		private ArrayList _al;
		private SecurityListLegSecurityAltID _last;

		public SecurityListLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListLegSecurityAltID)_al[i];
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

		public void Add(SecurityListLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListLegSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class SecurityListLegStipulation
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
					case SecurityList.TAG_LegStipulationType:
						return _sLegStipulationType;
					case SecurityList.TAG_LegStipulationValue:
						return _sLegStipulationValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityList.TAG_LegStipulationType:
						_sLegStipulationType = (string)value;
						break;
					case SecurityList.TAG_LegStipulationValue:
						_sLegStipulationValue = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityListLegStipulationList
	{
		private ArrayList _al;
		private SecurityListLegStipulation _last;

		public SecurityListLegStipulation this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityListLegStipulation)_al[i];
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

		public void Add(SecurityListLegStipulation item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityListLegStipulation item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityListLegStipulation Last
		{
			get { return _last; }
		}
	}
}
