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
	/// Summary description for QuoteCancel.
	/// </summary>
	public class QuoteCancel : Message
	{
		public const int TAG_QuoteReqID = 131;
		public const int TAG_QuoteID = 117;
		public const int TAG_QuoteCancelType = 298;
		public const int TAG_QuoteResponseLevel = 301;
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
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_NoQuoteEntries = 295;
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

		private string _sQuoteReqID;
		private string _sQuoteID;
		private int _iQuoteCancelType;
		private int _iQuoteResponseLevel;
		private int _iNoPartyIDs;
		private QuoteCancelPartyIDList _listPartyID = new QuoteCancelPartyIDList();
		private string _sAccount;
		private int _iAcctIDSource;
		private int _iAccountType;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private int _iNoQuoteEntries;
		private QuoteCancelQuoteEntrieList _listQuoteEntrie = new QuoteCancelQuoteEntrieList();

		public QuoteCancel() : base()
		{
			_sMsgType = Values.MsgType.QuoteCancel;
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
		public int QuoteCancelType
		{
			get { return _iQuoteCancelType; }
			set { _iQuoteCancelType = value; }
		}
		public int QuoteResponseLevel
		{
			get { return _iQuoteResponseLevel; }
			set { _iQuoteResponseLevel = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public QuoteCancelPartyIDList PartyID 
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
		public int NoQuoteEntries
		{
			get { return _iNoQuoteEntries; }
			set { _iNoQuoteEntries = value; }
		}
		public QuoteCancelQuoteEntrieList QuoteEntrie 
		{
			get { return _listQuoteEntrie; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_QuoteReqID:
						return _sQuoteReqID;
					case TAG_QuoteID:
						return _sQuoteID;
					case TAG_QuoteCancelType:
						return _iQuoteCancelType;
					case TAG_QuoteResponseLevel:
						return _iQuoteResponseLevel;
					case TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case TAG_Account:
						return _sAccount;
					case TAG_AcctIDSource:
						return _iAcctIDSource;
					case TAG_AccountType:
						return _iAccountType;
					case TAG_TradingSessionID:
						return _sTradingSessionID;
					case TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case TAG_NoQuoteEntries:
						return _iNoQuoteEntries;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_QuoteReqID:
						_sQuoteReqID = (string)value;
						break;
					case TAG_QuoteID:
						_sQuoteID = (string)value;
						break;
					case TAG_QuoteCancelType:
						_iQuoteCancelType = (int)value;
						break;
					case TAG_QuoteResponseLevel:
						_iQuoteResponseLevel = (int)value;
						break;
					case TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
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
					case TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case TAG_NoQuoteEntries:
						_iNoQuoteEntries = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class QuoteCancelPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private QuoteCancelPartySubIDList _listPartySubID = new QuoteCancelPartySubIDList();

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
		public QuoteCancelPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_PartyID:
						return _sPartyID;
					case QuoteCancel.TAG_PartyIDSource:
						return _cPartyIDSource;
					case QuoteCancel.TAG_PartyRole:
						return _iPartyRole;
					case QuoteCancel.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case QuoteCancel.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case QuoteCancel.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case QuoteCancel.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteCancelPartyIDList
	{
		private ArrayList _al;
		private QuoteCancelPartyID _last;

		public QuoteCancelPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteCancelPartyID)_al[i];
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

		public void Add(QuoteCancelPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteCancelPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteCancelPartyID Last
		{
			get { return _last; }
		}
	}

	public class QuoteCancelPartySubID
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
					case QuoteCancel.TAG_PartySubID:
						return _sPartySubID;
					case QuoteCancel.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case QuoteCancel.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteCancelPartySubIDList
	{
		private ArrayList _al;
		private QuoteCancelPartySubID _last;

		public QuoteCancelPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteCancelPartySubID)_al[i];
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

		public void Add(QuoteCancelPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteCancelPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteCancelPartySubID Last
		{
			get { return _last; }
		}
	}

	public class QuoteCancelQuoteEntrie
	{
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private QuoteCancelSecurityAltIDList _listSecurityAltID = new QuoteCancelSecurityAltIDList();
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
		private QuoteCancelEventList _listEvent = new QuoteCancelEventList();
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
		private QuoteCancelUnderlyingList _listUnderlying = new QuoteCancelUnderlyingList();
		private int _iNoLegs;
		private QuoteCancelLegList _listLeg = new QuoteCancelLegList();

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
		public QuoteCancelSecurityAltIDList SecurityAltID 
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
		public QuoteCancelEventList Event 
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
		public QuoteCancelUnderlyingList Underlying 
		{
			get { return _listUnderlying; }
		}
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public QuoteCancelLegList Leg 
		{
			get { return _listLeg; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_Symbol:
						return _sSymbol;
					case QuoteCancel.TAG_SymbolSfx:
						return _sSymbolSfx;
					case QuoteCancel.TAG_SecurityID:
						return _sSecurityID;
					case QuoteCancel.TAG_SecurityIDSource:
						return _sSecurityIDSource;
					case QuoteCancel.TAG_NoSecurityAltID:
						return _iNoSecurityAltID;
					case QuoteCancel.TAG_Product:
						return _iProduct;
					case QuoteCancel.TAG_CFICode:
						return _sCFICode;
					case QuoteCancel.TAG_SecurityType:
						return _sSecurityType;
					case QuoteCancel.TAG_SecuritySubType:
						return _sSecuritySubType;
					case QuoteCancel.TAG_MaturityMonthYear:
						return _dtMaturityMonthYear;
					case QuoteCancel.TAG_MaturityDate:
						return _dtMaturityDate;
					case QuoteCancel.TAG_CouponPaymentDate:
						return _dtCouponPaymentDate;
					case QuoteCancel.TAG_IssueDate:
						return _dtIssueDate;
					case QuoteCancel.TAG_RepoCollateralSecurityType:
						return _iRepoCollateralSecurityType;
					case QuoteCancel.TAG_RepurchaseTerm:
						return _iRepurchaseTerm;
					case QuoteCancel.TAG_RepurchaseRate:
						return _dRepurchaseRate;
					case QuoteCancel.TAG_Factor:
						return _dFactor;
					case QuoteCancel.TAG_CreditRating:
						return _sCreditRating;
					case QuoteCancel.TAG_InstrRegistry:
						return _sInstrRegistry;
					case QuoteCancel.TAG_CountryOfIssue:
						return _sCountryOfIssue;
					case QuoteCancel.TAG_StateOrProvinceOfIssue:
						return _sStateOrProvinceOfIssue;
					case QuoteCancel.TAG_LocaleOfIssue:
						return _sLocaleOfIssue;
					case QuoteCancel.TAG_RedemptionDate:
						return _dtRedemptionDate;
					case QuoteCancel.TAG_StrikePrice:
						return _dStrikePrice;
					case QuoteCancel.TAG_StrikeCurrency:
						return _sStrikeCurrency;
					case QuoteCancel.TAG_OptAttribute:
						return _cOptAttribute;
					case QuoteCancel.TAG_ContractMultiplier:
						return _dContractMultiplier;
					case QuoteCancel.TAG_CouponRate:
						return _dCouponRate;
					case QuoteCancel.TAG_SecurityExchange:
						return _sSecurityExchange;
					case QuoteCancel.TAG_Issuer:
						return _sIssuer;
					case QuoteCancel.TAG_EncodedIssuerLen:
						return _iEncodedIssuerLen;
					case QuoteCancel.TAG_EncodedIssuer:
						return _sEncodedIssuer;
					case QuoteCancel.TAG_SecurityDesc:
						return _sSecurityDesc;
					case QuoteCancel.TAG_EncodedSecurityDescLen:
						return _iEncodedSecurityDescLen;
					case QuoteCancel.TAG_EncodedSecurityDesc:
						return _sEncodedSecurityDesc;
					case QuoteCancel.TAG_Pool:
						return _sPool;
					case QuoteCancel.TAG_ContractSettlMonth:
						return _dtContractSettlMonth;
					case QuoteCancel.TAG_CPProgram:
						return _iCPProgram;
					case QuoteCancel.TAG_CPRegType:
						return _sCPRegType;
					case QuoteCancel.TAG_NoEvents:
						return _iNoEvents;
					case QuoteCancel.TAG_DatedDate:
						return _dtDatedDate;
					case QuoteCancel.TAG_InterestAccrualDate:
						return _dtInterestAccrualDate;
					case QuoteCancel.TAG_AgreementDesc:
						return _sAgreementDesc;
					case QuoteCancel.TAG_AgreementID:
						return _sAgreementID;
					case QuoteCancel.TAG_AgreementDate:
						return _dtAgreementDate;
					case QuoteCancel.TAG_AgreementCurrency:
						return _sAgreementCurrency;
					case QuoteCancel.TAG_TerminationType:
						return _iTerminationType;
					case QuoteCancel.TAG_StartDate:
						return _dtStartDate;
					case QuoteCancel.TAG_EndDate:
						return _dtEndDate;
					case QuoteCancel.TAG_DeliveryType:
						return _iDeliveryType;
					case QuoteCancel.TAG_MarginRatio:
						return _dMarginRatio;
					case QuoteCancel.TAG_NoUnderlyings:
						return _iNoUnderlyings;
					case QuoteCancel.TAG_NoLegs:
						return _iNoLegs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_Symbol:
						_sSymbol = (string)value;
						break;
					case QuoteCancel.TAG_SymbolSfx:
						_sSymbolSfx = (string)value;
						break;
					case QuoteCancel.TAG_SecurityID:
						_sSecurityID = (string)value;
						break;
					case QuoteCancel.TAG_SecurityIDSource:
						_sSecurityIDSource = (string)value;
						break;
					case QuoteCancel.TAG_NoSecurityAltID:
						_iNoSecurityAltID = (int)value;
						break;
					case QuoteCancel.TAG_Product:
						_iProduct = (int)value;
						break;
					case QuoteCancel.TAG_CFICode:
						_sCFICode = (string)value;
						break;
					case QuoteCancel.TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case QuoteCancel.TAG_SecuritySubType:
						_sSecuritySubType = (string)value;
						break;
					case QuoteCancel.TAG_MaturityMonthYear:
						_dtMaturityMonthYear = (DateTime)value;
						break;
					case QuoteCancel.TAG_MaturityDate:
						_dtMaturityDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_CouponPaymentDate:
						_dtCouponPaymentDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_IssueDate:
						_dtIssueDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_RepoCollateralSecurityType:
						_iRepoCollateralSecurityType = (int)value;
						break;
					case QuoteCancel.TAG_RepurchaseTerm:
						_iRepurchaseTerm = (int)value;
						break;
					case QuoteCancel.TAG_RepurchaseRate:
						_dRepurchaseRate = (double)value;
						break;
					case QuoteCancel.TAG_Factor:
						_dFactor = (double)value;
						break;
					case QuoteCancel.TAG_CreditRating:
						_sCreditRating = (string)value;
						break;
					case QuoteCancel.TAG_InstrRegistry:
						_sInstrRegistry = (string)value;
						break;
					case QuoteCancel.TAG_CountryOfIssue:
						_sCountryOfIssue = (string)value;
						break;
					case QuoteCancel.TAG_StateOrProvinceOfIssue:
						_sStateOrProvinceOfIssue = (string)value;
						break;
					case QuoteCancel.TAG_LocaleOfIssue:
						_sLocaleOfIssue = (string)value;
						break;
					case QuoteCancel.TAG_RedemptionDate:
						_dtRedemptionDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_StrikePrice:
						_dStrikePrice = (double)value;
						break;
					case QuoteCancel.TAG_StrikeCurrency:
						_sStrikeCurrency = (string)value;
						break;
					case QuoteCancel.TAG_OptAttribute:
						_cOptAttribute = (char)value;
						break;
					case QuoteCancel.TAG_ContractMultiplier:
						_dContractMultiplier = (double)value;
						break;
					case QuoteCancel.TAG_CouponRate:
						_dCouponRate = (double)value;
						break;
					case QuoteCancel.TAG_SecurityExchange:
						_sSecurityExchange = (string)value;
						break;
					case QuoteCancel.TAG_Issuer:
						_sIssuer = (string)value;
						break;
					case QuoteCancel.TAG_EncodedIssuerLen:
						_iEncodedIssuerLen = (int)value;
						break;
					case QuoteCancel.TAG_EncodedIssuer:
						_sEncodedIssuer = (string)value;
						break;
					case QuoteCancel.TAG_SecurityDesc:
						_sSecurityDesc = (string)value;
						break;
					case QuoteCancel.TAG_EncodedSecurityDescLen:
						_iEncodedSecurityDescLen = (int)value;
						break;
					case QuoteCancel.TAG_EncodedSecurityDesc:
						_sEncodedSecurityDesc = (string)value;
						break;
					case QuoteCancel.TAG_Pool:
						_sPool = (string)value;
						break;
					case QuoteCancel.TAG_ContractSettlMonth:
						_dtContractSettlMonth = (DateTime)value;
						break;
					case QuoteCancel.TAG_CPProgram:
						_iCPProgram = (int)value;
						break;
					case QuoteCancel.TAG_CPRegType:
						_sCPRegType = (string)value;
						break;
					case QuoteCancel.TAG_NoEvents:
						_iNoEvents = (int)value;
						break;
					case QuoteCancel.TAG_DatedDate:
						_dtDatedDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_InterestAccrualDate:
						_dtInterestAccrualDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_AgreementDesc:
						_sAgreementDesc = (string)value;
						break;
					case QuoteCancel.TAG_AgreementID:
						_sAgreementID = (string)value;
						break;
					case QuoteCancel.TAG_AgreementDate:
						_dtAgreementDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_AgreementCurrency:
						_sAgreementCurrency = (string)value;
						break;
					case QuoteCancel.TAG_TerminationType:
						_iTerminationType = (int)value;
						break;
					case QuoteCancel.TAG_StartDate:
						_dtStartDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_EndDate:
						_dtEndDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_DeliveryType:
						_iDeliveryType = (int)value;
						break;
					case QuoteCancel.TAG_MarginRatio:
						_dMarginRatio = (double)value;
						break;
					case QuoteCancel.TAG_NoUnderlyings:
						_iNoUnderlyings = (int)value;
						break;
					case QuoteCancel.TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteCancelQuoteEntrieList
	{
		private ArrayList _al;
		private QuoteCancelQuoteEntrie _last;

		public QuoteCancelQuoteEntrie this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteCancelQuoteEntrie)_al[i];
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

		public void Add(QuoteCancelQuoteEntrie item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteCancelQuoteEntrie item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteCancelQuoteEntrie Last
		{
			get { return _last; }
		}
	}

	public class QuoteCancelSecurityAltID
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
					case QuoteCancel.TAG_SecurityAltID:
						return _sSecurityAltID;
					case QuoteCancel.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case QuoteCancel.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteCancelSecurityAltIDList
	{
		private ArrayList _al;
		private QuoteCancelSecurityAltID _last;

		public QuoteCancelSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteCancelSecurityAltID)_al[i];
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

		public void Add(QuoteCancelSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteCancelSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteCancelSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class QuoteCancelEvent
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
					case QuoteCancel.TAG_EventType:
						return _iEventType;
					case QuoteCancel.TAG_EventDate:
						return _dtEventDate;
					case QuoteCancel.TAG_EventPx:
						return _dEventPx;
					case QuoteCancel.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_EventType:
						_iEventType = (int)value;
						break;
					case QuoteCancel.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case QuoteCancel.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteCancelEventList
	{
		private ArrayList _al;
		private QuoteCancelEvent _last;

		public QuoteCancelEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteCancelEvent)_al[i];
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

		public void Add(QuoteCancelEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteCancelEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteCancelEvent Last
		{
			get { return _last; }
		}
	}

	public class QuoteCancelUnderlying
	{
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private QuoteCancelUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new QuoteCancelUnderlyingSecurityAltIDList();
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
		public QuoteCancelUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
					case QuoteCancel.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case QuoteCancel.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case QuoteCancel.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case QuoteCancel.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case QuoteCancel.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case QuoteCancel.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case QuoteCancel.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case QuoteCancel.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case QuoteCancel.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case QuoteCancel.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case QuoteCancel.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case QuoteCancel.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case QuoteCancel.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case QuoteCancel.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case QuoteCancel.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case QuoteCancel.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case QuoteCancel.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case QuoteCancel.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case QuoteCancel.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case QuoteCancel.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case QuoteCancel.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case QuoteCancel.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case QuoteCancel.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case QuoteCancel.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case QuoteCancel.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case QuoteCancel.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case QuoteCancel.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case QuoteCancel.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case QuoteCancel.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case QuoteCancel.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case QuoteCancel.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case QuoteCancel.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case QuoteCancel.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case QuoteCancel.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case QuoteCancel.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case QuoteCancel.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case QuoteCancel.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case QuoteCancel.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case QuoteCancel.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case QuoteCancel.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case QuoteCancel.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case QuoteCancel.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case QuoteCancel.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case QuoteCancel.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case QuoteCancel.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case QuoteCancel.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case QuoteCancel.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case QuoteCancel.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case QuoteCancel.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case QuoteCancel.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case QuoteCancel.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case QuoteCancel.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case QuoteCancel.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case QuoteCancel.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case QuoteCancel.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case QuoteCancel.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case QuoteCancel.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case QuoteCancel.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteCancelUnderlyingList
	{
		private ArrayList _al;
		private QuoteCancelUnderlying _last;

		public QuoteCancelUnderlying this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteCancelUnderlying)_al[i];
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

		public void Add(QuoteCancelUnderlying item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteCancelUnderlying item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteCancelUnderlying Last
		{
			get { return _last; }
		}
	}

	public class QuoteCancelUnderlyingSecurityAltID
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
					case QuoteCancel.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case QuoteCancel.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case QuoteCancel.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteCancelUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private QuoteCancelUnderlyingSecurityAltID _last;

		public QuoteCancelUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteCancelUnderlyingSecurityAltID)_al[i];
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

		public void Add(QuoteCancelUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteCancelUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteCancelUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class QuoteCancelLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private QuoteCancelLegSecurityAltIDList _listLegSecurityAltID = new QuoteCancelLegSecurityAltIDList();
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
		public QuoteCancelLegSecurityAltIDList LegSecurityAltID 
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
					case QuoteCancel.TAG_LegSymbol:
						return _sLegSymbol;
					case QuoteCancel.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case QuoteCancel.TAG_LegSecurityID:
						return _sLegSecurityID;
					case QuoteCancel.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case QuoteCancel.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case QuoteCancel.TAG_LegProduct:
						return _iLegProduct;
					case QuoteCancel.TAG_LegCFICode:
						return _sLegCFICode;
					case QuoteCancel.TAG_LegSecurityType:
						return _sLegSecurityType;
					case QuoteCancel.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case QuoteCancel.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case QuoteCancel.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case QuoteCancel.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case QuoteCancel.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case QuoteCancel.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case QuoteCancel.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case QuoteCancel.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case QuoteCancel.TAG_LegFactor:
						return _dLegFactor;
					case QuoteCancel.TAG_LegCreditRating:
						return _sLegCreditRating;
					case QuoteCancel.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case QuoteCancel.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case QuoteCancel.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case QuoteCancel.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case QuoteCancel.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case QuoteCancel.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case QuoteCancel.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case QuoteCancel.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case QuoteCancel.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case QuoteCancel.TAG_LegCouponRate:
						return _dLegCouponRate;
					case QuoteCancel.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case QuoteCancel.TAG_LegIssuer:
						return _sLegIssuer;
					case QuoteCancel.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case QuoteCancel.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case QuoteCancel.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case QuoteCancel.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case QuoteCancel.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case QuoteCancel.TAG_LegRatioQty:
						return _dLegRatioQty;
					case QuoteCancel.TAG_LegSide:
						return _cLegSide;
					case QuoteCancel.TAG_LegCurrency:
						return _sLegCurrency;
					case QuoteCancel.TAG_LegPool:
						return _sLegPool;
					case QuoteCancel.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case QuoteCancel.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case QuoteCancel.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case QuoteCancel.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case QuoteCancel.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case QuoteCancel.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case QuoteCancel.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case QuoteCancel.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case QuoteCancel.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case QuoteCancel.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case QuoteCancel.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case QuoteCancel.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case QuoteCancel.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case QuoteCancel.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case QuoteCancel.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case QuoteCancel.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case QuoteCancel.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case QuoteCancel.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case QuoteCancel.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case QuoteCancel.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case QuoteCancel.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case QuoteCancel.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case QuoteCancel.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case QuoteCancel.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case QuoteCancel.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case QuoteCancel.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case QuoteCancel.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case QuoteCancel.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case QuoteCancel.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case QuoteCancel.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case QuoteCancel.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case QuoteCancel.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case QuoteCancel.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case QuoteCancel.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case QuoteCancel.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case QuoteCancel.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case QuoteCancel.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case QuoteCancel.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case QuoteCancel.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case QuoteCancel.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteCancelLegList
	{
		private ArrayList _al;
		private QuoteCancelLeg _last;

		public QuoteCancelLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteCancelLeg)_al[i];
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

		public void Add(QuoteCancelLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteCancelLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteCancelLeg Last
		{
			get { return _last; }
		}
	}

	public class QuoteCancelLegSecurityAltID
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
					case QuoteCancel.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case QuoteCancel.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case QuoteCancel.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case QuoteCancel.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class QuoteCancelLegSecurityAltIDList
	{
		private ArrayList _al;
		private QuoteCancelLegSecurityAltID _last;

		public QuoteCancelLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (QuoteCancelLegSecurityAltID)_al[i];
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

		public void Add(QuoteCancelLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(QuoteCancelLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public QuoteCancelLegSecurityAltID Last
		{
			get { return _last; }
		}
	}
}
