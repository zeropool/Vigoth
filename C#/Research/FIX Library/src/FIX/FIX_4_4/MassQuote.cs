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
	/// Summary description for MassQuote.
	/// </summary>
	public class MassQuote : Message
	{
		public const int TAG_QuoteReqID = 131;
		public const int TAG_QuoteID = 117;
		public const int TAG_QuoteType = 537;
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
		public const int TAG_DefBidSize = 293;
		public const int TAG_DefOfferSize = 294;
		public const int TAG_NoQuoteSets = 296;
		public const int TAG_QuoteSetID = 302;
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
		public const int TAG_QuoteSetValidUntilTime = 367;
		public const int TAG_TotNoQuoteEntries = 304;
		public const int TAG_LastFragment = 893;
		public const int TAG_NoQuoteEntries = 295;
		public const int TAG_QuoteEntryID = 299;
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
		public const int TAG_BidPx = 132;
		public const int TAG_OfferPx = 133;
		public const int TAG_BidSize = 134;
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
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_SettlDate = 64;
		public const int TAG_OrdType = 40;
		public const int TAG_SettlDate2 = 193;
		public const int TAG_OrderQty2 = 192;
		public const int TAG_BidForwardPoints2 = 642;
		public const int TAG_OfferForwardPoints2 = 643;
		public const int TAG_Currency = 15;

		private string _sQuoteReqID;
		private string _sQuoteID;
		private int _iQuoteType;
		private int _iQuoteResponseLevel;
		private int _iNoPartyIDs;
		private MassQuotePartyIDList _listPartyID = new MassQuotePartyIDList();
		private string _sAccount;
		private int _iAcctIDSource;
		private int _iAccountType;
		private int _iDefBidSize;
		private int _iDefOfferSize;
		private int _iNoQuoteSets;
		private MassQuoteQuoteSetList _listQuoteSet = new MassQuoteQuoteSetList();

		public MassQuote() : base()
		{
			_sMsgType = Values.MsgType.MassQuote;
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
		public int QuoteType
		{
			get { return _iQuoteType; }
			set { _iQuoteType = value; }
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
		public MassQuotePartyIDList PartyID 
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
		public int DefBidSize
		{
			get { return _iDefBidSize; }
			set { _iDefBidSize = value; }
		}
		public int DefOfferSize
		{
			get { return _iDefOfferSize; }
			set { _iDefOfferSize = value; }
		}
		public int NoQuoteSets
		{
			get { return _iNoQuoteSets; }
			set { _iNoQuoteSets = value; }
		}
		public MassQuoteQuoteSetList QuoteSet 
		{
			get { return _listQuoteSet; }
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
					case TAG_QuoteType:
						return _iQuoteType;
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
					case TAG_DefBidSize:
						return _iDefBidSize;
					case TAG_DefOfferSize:
						return _iDefOfferSize;
					case TAG_NoQuoteSets:
						return _iNoQuoteSets;
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
					case TAG_QuoteType:
						_iQuoteType = (int)value;
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
					case TAG_DefBidSize:
						_iDefBidSize = (int)value;
						break;
					case TAG_DefOfferSize:
						_iDefOfferSize = (int)value;
						break;
					case TAG_NoQuoteSets:
						_iNoQuoteSets = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class MassQuotePartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private MassQuotePartySubIDList _listPartySubID = new MassQuotePartySubIDList();

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
		public MassQuotePartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MassQuote.TAG_PartyID:
						return _sPartyID;
					case MassQuote.TAG_PartyIDSource:
						return _cPartyIDSource;
					case MassQuote.TAG_PartyRole:
						return _iPartyRole;
					case MassQuote.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MassQuote.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case MassQuote.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case MassQuote.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case MassQuote.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MassQuotePartyIDList
	{
		private ArrayList _al;
		private MassQuotePartyID _last;

		public MassQuotePartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MassQuotePartyID)_al[i];
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

		public void Add(MassQuotePartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MassQuotePartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MassQuotePartyID Last
		{
			get { return _last; }
		}
	}

	public class MassQuotePartySubID
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
					case MassQuote.TAG_PartySubID:
						return _sPartySubID;
					case MassQuote.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MassQuote.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case MassQuote.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MassQuotePartySubIDList
	{
		private ArrayList _al;
		private MassQuotePartySubID _last;

		public MassQuotePartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MassQuotePartySubID)_al[i];
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

		public void Add(MassQuotePartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MassQuotePartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MassQuotePartySubID Last
		{
			get { return _last; }
		}
	}

	public class MassQuoteQuoteSet
	{
		private string _sQuoteSetID;
		private string _sUnderlyingSymbol;
		private string _sUnderlyingSymbolSfx;
		private string _sUnderlyingSecurityID;
		private string _sUnderlyingSecurityIDSource;
		private int _iNoUnderlyingSecurityAltID;
		private MassQuoteUnderlyingSecurityAltIDList _listUnderlyingSecurityAltID = new MassQuoteUnderlyingSecurityAltIDList();
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
		private DateTime _dtQuoteSetValidUntilTime;
		private int _iTotNoQuoteEntries;
		private bool _bLastFragment;
		private int _iNoQuoteEntries;
		private MassQuoteQuoteEntrieList _listQuoteEntrie = new MassQuoteQuoteEntrieList();

		public string QuoteSetID
		{
			get { return _sQuoteSetID; }
			set { _sQuoteSetID = value; }
		}
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
		public MassQuoteUnderlyingSecurityAltIDList UnderlyingSecurityAltID 
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
		public DateTime QuoteSetValidUntilTime
		{
			get { return _dtQuoteSetValidUntilTime; }
			set { _dtQuoteSetValidUntilTime = value; }
		}
		public int TotNoQuoteEntries
		{
			get { return _iTotNoQuoteEntries; }
			set { _iTotNoQuoteEntries = value; }
		}
		public bool LastFragment
		{
			get { return _bLastFragment; }
			set { _bLastFragment = value; }
		}
		public int NoQuoteEntries
		{
			get { return _iNoQuoteEntries; }
			set { _iNoQuoteEntries = value; }
		}
		public MassQuoteQuoteEntrieList QuoteEntrie 
		{
			get { return _listQuoteEntrie; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MassQuote.TAG_QuoteSetID:
						return _sQuoteSetID;
					case MassQuote.TAG_UnderlyingSymbol:
						return _sUnderlyingSymbol;
					case MassQuote.TAG_UnderlyingSymbolSfx:
						return _sUnderlyingSymbolSfx;
					case MassQuote.TAG_UnderlyingSecurityID:
						return _sUnderlyingSecurityID;
					case MassQuote.TAG_UnderlyingSecurityIDSource:
						return _sUnderlyingSecurityIDSource;
					case MassQuote.TAG_NoUnderlyingSecurityAltID:
						return _iNoUnderlyingSecurityAltID;
					case MassQuote.TAG_UnderlyingProduct:
						return _iUnderlyingProduct;
					case MassQuote.TAG_UnderlyingCFICode:
						return _sUnderlyingCFICode;
					case MassQuote.TAG_UnderlyingSecurityType:
						return _sUnderlyingSecurityType;
					case MassQuote.TAG_UnderlyingSecuritySubType:
						return _sUnderlyingSecuritySubType;
					case MassQuote.TAG_UnderlyingMaturityMonthYear:
						return _dtUnderlyingMaturityMonthYear;
					case MassQuote.TAG_UnderlyingMaturityDate:
						return _dtUnderlyingMaturityDate;
					case MassQuote.TAG_UnderlyingCouponPaymentDate:
						return _dtUnderlyingCouponPaymentDate;
					case MassQuote.TAG_UnderlyingIssueDate:
						return _dtUnderlyingIssueDate;
					case MassQuote.TAG_UnderlyingRepoCollateralSecurityType:
						return _iUnderlyingRepoCollateralSecurityType;
					case MassQuote.TAG_UnderlyingRepurchaseTerm:
						return _iUnderlyingRepurchaseTerm;
					case MassQuote.TAG_UnderlyingRepurchaseRate:
						return _dUnderlyingRepurchaseRate;
					case MassQuote.TAG_UnderlyingFactor:
						return _dUnderlyingFactor;
					case MassQuote.TAG_UnderlyingCreditRating:
						return _sUnderlyingCreditRating;
					case MassQuote.TAG_UnderlyingInstrRegistry:
						return _sUnderlyingInstrRegistry;
					case MassQuote.TAG_UnderlyingCountryOfIssue:
						return _sUnderlyingCountryOfIssue;
					case MassQuote.TAG_UnderlyingStateOrProvinceOfIssue:
						return _sUnderlyingStateOrProvinceOfIssue;
					case MassQuote.TAG_UnderlyingLocaleOfIssue:
						return _sUnderlyingLocaleOfIssue;
					case MassQuote.TAG_UnderlyingRedemptionDate:
						return _dtUnderlyingRedemptionDate;
					case MassQuote.TAG_UnderlyingStrikePrice:
						return _dUnderlyingStrikePrice;
					case MassQuote.TAG_UnderlyingStrikeCurrency:
						return _sUnderlyingStrikeCurrency;
					case MassQuote.TAG_UnderlyingOptAttribute:
						return _cUnderlyingOptAttribute;
					case MassQuote.TAG_UnderlyingContractMultiplier:
						return _dUnderlyingContractMultiplier;
					case MassQuote.TAG_UnderlyingCouponRate:
						return _dUnderlyingCouponRate;
					case MassQuote.TAG_UnderlyingSecurityExchange:
						return _sUnderlyingSecurityExchange;
					case MassQuote.TAG_UnderlyingIssuer:
						return _sUnderlyingIssuer;
					case MassQuote.TAG_EncodedUnderlyingIssuerLen:
						return _iEncodedUnderlyingIssuerLen;
					case MassQuote.TAG_EncodedUnderlyingIssuer:
						return _sEncodedUnderlyingIssuer;
					case MassQuote.TAG_UnderlyingSecurityDesc:
						return _sUnderlyingSecurityDesc;
					case MassQuote.TAG_EncodedUnderlyingSecurityDescLen:
						return _iEncodedUnderlyingSecurityDescLen;
					case MassQuote.TAG_EncodedUnderlyingSecurityDesc:
						return _sEncodedUnderlyingSecurityDesc;
					case MassQuote.TAG_UnderlyingCPProgram:
						return _sUnderlyingCPProgram;
					case MassQuote.TAG_UnderlyingCPRegType:
						return _sUnderlyingCPRegType;
					case MassQuote.TAG_UnderlyingCurrency:
						return _sUnderlyingCurrency;
					case MassQuote.TAG_UnderlyingQty:
						return _iUnderlyingQty;
					case MassQuote.TAG_UnderlyingPx:
						return _dUnderlyingPx;
					case MassQuote.TAG_UnderlyingDirtyPrice:
						return _dUnderlyingDirtyPrice;
					case MassQuote.TAG_UnderlyingEndPrice:
						return _dUnderlyingEndPrice;
					case MassQuote.TAG_UnderlyingStartValue:
						return _dUnderlyingStartValue;
					case MassQuote.TAG_UnderlyingCurrentValue:
						return _dUnderlyingCurrentValue;
					case MassQuote.TAG_UnderlyingEndValue:
						return _dUnderlyingEndValue;
					case MassQuote.TAG_QuoteSetValidUntilTime:
						return _dtQuoteSetValidUntilTime;
					case MassQuote.TAG_TotNoQuoteEntries:
						return _iTotNoQuoteEntries;
					case MassQuote.TAG_LastFragment:
						return _bLastFragment;
					case MassQuote.TAG_NoQuoteEntries:
						return _iNoQuoteEntries;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MassQuote.TAG_QuoteSetID:
						_sQuoteSetID = (string)value;
						break;
					case MassQuote.TAG_UnderlyingSymbol:
						_sUnderlyingSymbol = (string)value;
						break;
					case MassQuote.TAG_UnderlyingSymbolSfx:
						_sUnderlyingSymbolSfx = (string)value;
						break;
					case MassQuote.TAG_UnderlyingSecurityID:
						_sUnderlyingSecurityID = (string)value;
						break;
					case MassQuote.TAG_UnderlyingSecurityIDSource:
						_sUnderlyingSecurityIDSource = (string)value;
						break;
					case MassQuote.TAG_NoUnderlyingSecurityAltID:
						_iNoUnderlyingSecurityAltID = (int)value;
						break;
					case MassQuote.TAG_UnderlyingProduct:
						_iUnderlyingProduct = (int)value;
						break;
					case MassQuote.TAG_UnderlyingCFICode:
						_sUnderlyingCFICode = (string)value;
						break;
					case MassQuote.TAG_UnderlyingSecurityType:
						_sUnderlyingSecurityType = (string)value;
						break;
					case MassQuote.TAG_UnderlyingSecuritySubType:
						_sUnderlyingSecuritySubType = (string)value;
						break;
					case MassQuote.TAG_UnderlyingMaturityMonthYear:
						_dtUnderlyingMaturityMonthYear = (DateTime)value;
						break;
					case MassQuote.TAG_UnderlyingMaturityDate:
						_dtUnderlyingMaturityDate = (DateTime)value;
						break;
					case MassQuote.TAG_UnderlyingCouponPaymentDate:
						_dtUnderlyingCouponPaymentDate = (DateTime)value;
						break;
					case MassQuote.TAG_UnderlyingIssueDate:
						_dtUnderlyingIssueDate = (DateTime)value;
						break;
					case MassQuote.TAG_UnderlyingRepoCollateralSecurityType:
						_iUnderlyingRepoCollateralSecurityType = (int)value;
						break;
					case MassQuote.TAG_UnderlyingRepurchaseTerm:
						_iUnderlyingRepurchaseTerm = (int)value;
						break;
					case MassQuote.TAG_UnderlyingRepurchaseRate:
						_dUnderlyingRepurchaseRate = (double)value;
						break;
					case MassQuote.TAG_UnderlyingFactor:
						_dUnderlyingFactor = (double)value;
						break;
					case MassQuote.TAG_UnderlyingCreditRating:
						_sUnderlyingCreditRating = (string)value;
						break;
					case MassQuote.TAG_UnderlyingInstrRegistry:
						_sUnderlyingInstrRegistry = (string)value;
						break;
					case MassQuote.TAG_UnderlyingCountryOfIssue:
						_sUnderlyingCountryOfIssue = (string)value;
						break;
					case MassQuote.TAG_UnderlyingStateOrProvinceOfIssue:
						_sUnderlyingStateOrProvinceOfIssue = (string)value;
						break;
					case MassQuote.TAG_UnderlyingLocaleOfIssue:
						_sUnderlyingLocaleOfIssue = (string)value;
						break;
					case MassQuote.TAG_UnderlyingRedemptionDate:
						_dtUnderlyingRedemptionDate = (DateTime)value;
						break;
					case MassQuote.TAG_UnderlyingStrikePrice:
						_dUnderlyingStrikePrice = (double)value;
						break;
					case MassQuote.TAG_UnderlyingStrikeCurrency:
						_sUnderlyingStrikeCurrency = (string)value;
						break;
					case MassQuote.TAG_UnderlyingOptAttribute:
						_cUnderlyingOptAttribute = (char)value;
						break;
					case MassQuote.TAG_UnderlyingContractMultiplier:
						_dUnderlyingContractMultiplier = (double)value;
						break;
					case MassQuote.TAG_UnderlyingCouponRate:
						_dUnderlyingCouponRate = (double)value;
						break;
					case MassQuote.TAG_UnderlyingSecurityExchange:
						_sUnderlyingSecurityExchange = (string)value;
						break;
					case MassQuote.TAG_UnderlyingIssuer:
						_sUnderlyingIssuer = (string)value;
						break;
					case MassQuote.TAG_EncodedUnderlyingIssuerLen:
						_iEncodedUnderlyingIssuerLen = (int)value;
						break;
					case MassQuote.TAG_EncodedUnderlyingIssuer:
						_sEncodedUnderlyingIssuer = (string)value;
						break;
					case MassQuote.TAG_UnderlyingSecurityDesc:
						_sUnderlyingSecurityDesc = (string)value;
						break;
					case MassQuote.TAG_EncodedUnderlyingSecurityDescLen:
						_iEncodedUnderlyingSecurityDescLen = (int)value;
						break;
					case MassQuote.TAG_EncodedUnderlyingSecurityDesc:
						_sEncodedUnderlyingSecurityDesc = (string)value;
						break;
					case MassQuote.TAG_UnderlyingCPProgram:
						_sUnderlyingCPProgram = (string)value;
						break;
					case MassQuote.TAG_UnderlyingCPRegType:
						_sUnderlyingCPRegType = (string)value;
						break;
					case MassQuote.TAG_UnderlyingCurrency:
						_sUnderlyingCurrency = (string)value;
						break;
					case MassQuote.TAG_UnderlyingQty:
						_iUnderlyingQty = (int)value;
						break;
					case MassQuote.TAG_UnderlyingPx:
						_dUnderlyingPx = (double)value;
						break;
					case MassQuote.TAG_UnderlyingDirtyPrice:
						_dUnderlyingDirtyPrice = (double)value;
						break;
					case MassQuote.TAG_UnderlyingEndPrice:
						_dUnderlyingEndPrice = (double)value;
						break;
					case MassQuote.TAG_UnderlyingStartValue:
						_dUnderlyingStartValue = (double)value;
						break;
					case MassQuote.TAG_UnderlyingCurrentValue:
						_dUnderlyingCurrentValue = (double)value;
						break;
					case MassQuote.TAG_UnderlyingEndValue:
						_dUnderlyingEndValue = (double)value;
						break;
					case MassQuote.TAG_QuoteSetValidUntilTime:
						_dtQuoteSetValidUntilTime = (DateTime)value;
						break;
					case MassQuote.TAG_TotNoQuoteEntries:
						_iTotNoQuoteEntries = (int)value;
						break;
					case MassQuote.TAG_LastFragment:
						_bLastFragment = (bool)value;
						break;
					case MassQuote.TAG_NoQuoteEntries:
						_iNoQuoteEntries = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MassQuoteQuoteSetList
	{
		private ArrayList _al;
		private MassQuoteQuoteSet _last;

		public MassQuoteQuoteSet this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MassQuoteQuoteSet)_al[i];
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

		public void Add(MassQuoteQuoteSet item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MassQuoteQuoteSet item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MassQuoteQuoteSet Last
		{
			get { return _last; }
		}
	}

	public class MassQuoteUnderlyingSecurityAltID
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
					case MassQuote.TAG_UnderlyingSecurityAltID:
						return _sUnderlyingSecurityAltID;
					case MassQuote.TAG_UnderlyingSecurityAltIDSource:
						return _sUnderlyingSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MassQuote.TAG_UnderlyingSecurityAltID:
						_sUnderlyingSecurityAltID = (string)value;
						break;
					case MassQuote.TAG_UnderlyingSecurityAltIDSource:
						_sUnderlyingSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MassQuoteUnderlyingSecurityAltIDList
	{
		private ArrayList _al;
		private MassQuoteUnderlyingSecurityAltID _last;

		public MassQuoteUnderlyingSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MassQuoteUnderlyingSecurityAltID)_al[i];
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

		public void Add(MassQuoteUnderlyingSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MassQuoteUnderlyingSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MassQuoteUnderlyingSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class MassQuoteQuoteEntrie
	{
		private string _sQuoteEntryID;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sSecurityIDSource;
		private int _iNoSecurityAltID;
		private MassQuoteSecurityAltIDList _listSecurityAltID = new MassQuoteSecurityAltIDList();
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
		private MassQuoteEventList _listEvent = new MassQuoteEventList();
		private DateTime _dtDatedDate;
		private DateTime _dtInterestAccrualDate;
		private int _iNoLegs;
		private MassQuoteLegList _listLeg = new MassQuoteLegList();
		private double _dBidPx;
		private double _dOfferPx;
		private int _iBidSize;
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
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private DateTime _dtSettlDate;
		private char _cOrdType;
		private DateTime _dtSettlDate2;
		private int _iOrderQty2;
		private double _dBidForwardPoints2;
		private double _dOfferForwardPoints2;
		private string _sCurrency;

		public string QuoteEntryID
		{
			get { return _sQuoteEntryID; }
			set { _sQuoteEntryID = value; }
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
		public MassQuoteSecurityAltIDList SecurityAltID 
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
		public MassQuoteEventList Event 
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
		public int NoLegs
		{
			get { return _iNoLegs; }
			set { _iNoLegs = value; }
		}
		public MassQuoteLegList Leg 
		{
			get { return _listLeg; }
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
		public int BidSize
		{
			get { return _iBidSize; }
			set { _iBidSize = value; }
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
		public DateTime SettlDate
		{
			get { return _dtSettlDate; }
			set { _dtSettlDate = value; }
		}
		public char OrdType
		{
			get { return _cOrdType; }
			set { _cOrdType = value; }
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
		public string Currency
		{
			get { return _sCurrency; }
			set { _sCurrency = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MassQuote.TAG_QuoteEntryID:
						return _sQuoteEntryID;
					case MassQuote.TAG_Symbol:
						return _sSymbol;
					case MassQuote.TAG_SymbolSfx:
						return _sSymbolSfx;
					case MassQuote.TAG_SecurityID:
						return _sSecurityID;
					case MassQuote.TAG_SecurityIDSource:
						return _sSecurityIDSource;
					case MassQuote.TAG_NoSecurityAltID:
						return _iNoSecurityAltID;
					case MassQuote.TAG_Product:
						return _iProduct;
					case MassQuote.TAG_CFICode:
						return _sCFICode;
					case MassQuote.TAG_SecurityType:
						return _sSecurityType;
					case MassQuote.TAG_SecuritySubType:
						return _sSecuritySubType;
					case MassQuote.TAG_MaturityMonthYear:
						return _dtMaturityMonthYear;
					case MassQuote.TAG_MaturityDate:
						return _dtMaturityDate;
					case MassQuote.TAG_CouponPaymentDate:
						return _dtCouponPaymentDate;
					case MassQuote.TAG_IssueDate:
						return _dtIssueDate;
					case MassQuote.TAG_RepoCollateralSecurityType:
						return _iRepoCollateralSecurityType;
					case MassQuote.TAG_RepurchaseTerm:
						return _iRepurchaseTerm;
					case MassQuote.TAG_RepurchaseRate:
						return _dRepurchaseRate;
					case MassQuote.TAG_Factor:
						return _dFactor;
					case MassQuote.TAG_CreditRating:
						return _sCreditRating;
					case MassQuote.TAG_InstrRegistry:
						return _sInstrRegistry;
					case MassQuote.TAG_CountryOfIssue:
						return _sCountryOfIssue;
					case MassQuote.TAG_StateOrProvinceOfIssue:
						return _sStateOrProvinceOfIssue;
					case MassQuote.TAG_LocaleOfIssue:
						return _sLocaleOfIssue;
					case MassQuote.TAG_RedemptionDate:
						return _dtRedemptionDate;
					case MassQuote.TAG_StrikePrice:
						return _dStrikePrice;
					case MassQuote.TAG_StrikeCurrency:
						return _sStrikeCurrency;
					case MassQuote.TAG_OptAttribute:
						return _cOptAttribute;
					case MassQuote.TAG_ContractMultiplier:
						return _dContractMultiplier;
					case MassQuote.TAG_CouponRate:
						return _dCouponRate;
					case MassQuote.TAG_SecurityExchange:
						return _sSecurityExchange;
					case MassQuote.TAG_Issuer:
						return _sIssuer;
					case MassQuote.TAG_EncodedIssuerLen:
						return _iEncodedIssuerLen;
					case MassQuote.TAG_EncodedIssuer:
						return _sEncodedIssuer;
					case MassQuote.TAG_SecurityDesc:
						return _sSecurityDesc;
					case MassQuote.TAG_EncodedSecurityDescLen:
						return _iEncodedSecurityDescLen;
					case MassQuote.TAG_EncodedSecurityDesc:
						return _sEncodedSecurityDesc;
					case MassQuote.TAG_Pool:
						return _sPool;
					case MassQuote.TAG_ContractSettlMonth:
						return _dtContractSettlMonth;
					case MassQuote.TAG_CPProgram:
						return _iCPProgram;
					case MassQuote.TAG_CPRegType:
						return _sCPRegType;
					case MassQuote.TAG_NoEvents:
						return _iNoEvents;
					case MassQuote.TAG_DatedDate:
						return _dtDatedDate;
					case MassQuote.TAG_InterestAccrualDate:
						return _dtInterestAccrualDate;
					case MassQuote.TAG_NoLegs:
						return _iNoLegs;
					case MassQuote.TAG_BidPx:
						return _dBidPx;
					case MassQuote.TAG_OfferPx:
						return _dOfferPx;
					case MassQuote.TAG_BidSize:
						return _iBidSize;
					case MassQuote.TAG_OfferSize:
						return _iOfferSize;
					case MassQuote.TAG_ValidUntilTime:
						return _dtValidUntilTime;
					case MassQuote.TAG_BidSpotRate:
						return _dBidSpotRate;
					case MassQuote.TAG_OfferSpotRate:
						return _dOfferSpotRate;
					case MassQuote.TAG_BidForwardPoints:
						return _dBidForwardPoints;
					case MassQuote.TAG_OfferForwardPoints:
						return _dOfferForwardPoints;
					case MassQuote.TAG_MidPx:
						return _dMidPx;
					case MassQuote.TAG_BidYield:
						return _dBidYield;
					case MassQuote.TAG_MidYield:
						return _dMidYield;
					case MassQuote.TAG_OfferYield:
						return _dOfferYield;
					case MassQuote.TAG_TransactTime:
						return _dtTransactTime;
					case MassQuote.TAG_TradingSessionID:
						return _sTradingSessionID;
					case MassQuote.TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case MassQuote.TAG_SettlDate:
						return _dtSettlDate;
					case MassQuote.TAG_OrdType:
						return _cOrdType;
					case MassQuote.TAG_SettlDate2:
						return _dtSettlDate2;
					case MassQuote.TAG_OrderQty2:
						return _iOrderQty2;
					case MassQuote.TAG_BidForwardPoints2:
						return _dBidForwardPoints2;
					case MassQuote.TAG_OfferForwardPoints2:
						return _dOfferForwardPoints2;
					case MassQuote.TAG_Currency:
						return _sCurrency;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MassQuote.TAG_QuoteEntryID:
						_sQuoteEntryID = (string)value;
						break;
					case MassQuote.TAG_Symbol:
						_sSymbol = (string)value;
						break;
					case MassQuote.TAG_SymbolSfx:
						_sSymbolSfx = (string)value;
						break;
					case MassQuote.TAG_SecurityID:
						_sSecurityID = (string)value;
						break;
					case MassQuote.TAG_SecurityIDSource:
						_sSecurityIDSource = (string)value;
						break;
					case MassQuote.TAG_NoSecurityAltID:
						_iNoSecurityAltID = (int)value;
						break;
					case MassQuote.TAG_Product:
						_iProduct = (int)value;
						break;
					case MassQuote.TAG_CFICode:
						_sCFICode = (string)value;
						break;
					case MassQuote.TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case MassQuote.TAG_SecuritySubType:
						_sSecuritySubType = (string)value;
						break;
					case MassQuote.TAG_MaturityMonthYear:
						_dtMaturityMonthYear = (DateTime)value;
						break;
					case MassQuote.TAG_MaturityDate:
						_dtMaturityDate = (DateTime)value;
						break;
					case MassQuote.TAG_CouponPaymentDate:
						_dtCouponPaymentDate = (DateTime)value;
						break;
					case MassQuote.TAG_IssueDate:
						_dtIssueDate = (DateTime)value;
						break;
					case MassQuote.TAG_RepoCollateralSecurityType:
						_iRepoCollateralSecurityType = (int)value;
						break;
					case MassQuote.TAG_RepurchaseTerm:
						_iRepurchaseTerm = (int)value;
						break;
					case MassQuote.TAG_RepurchaseRate:
						_dRepurchaseRate = (double)value;
						break;
					case MassQuote.TAG_Factor:
						_dFactor = (double)value;
						break;
					case MassQuote.TAG_CreditRating:
						_sCreditRating = (string)value;
						break;
					case MassQuote.TAG_InstrRegistry:
						_sInstrRegistry = (string)value;
						break;
					case MassQuote.TAG_CountryOfIssue:
						_sCountryOfIssue = (string)value;
						break;
					case MassQuote.TAG_StateOrProvinceOfIssue:
						_sStateOrProvinceOfIssue = (string)value;
						break;
					case MassQuote.TAG_LocaleOfIssue:
						_sLocaleOfIssue = (string)value;
						break;
					case MassQuote.TAG_RedemptionDate:
						_dtRedemptionDate = (DateTime)value;
						break;
					case MassQuote.TAG_StrikePrice:
						_dStrikePrice = (double)value;
						break;
					case MassQuote.TAG_StrikeCurrency:
						_sStrikeCurrency = (string)value;
						break;
					case MassQuote.TAG_OptAttribute:
						_cOptAttribute = (char)value;
						break;
					case MassQuote.TAG_ContractMultiplier:
						_dContractMultiplier = (double)value;
						break;
					case MassQuote.TAG_CouponRate:
						_dCouponRate = (double)value;
						break;
					case MassQuote.TAG_SecurityExchange:
						_sSecurityExchange = (string)value;
						break;
					case MassQuote.TAG_Issuer:
						_sIssuer = (string)value;
						break;
					case MassQuote.TAG_EncodedIssuerLen:
						_iEncodedIssuerLen = (int)value;
						break;
					case MassQuote.TAG_EncodedIssuer:
						_sEncodedIssuer = (string)value;
						break;
					case MassQuote.TAG_SecurityDesc:
						_sSecurityDesc = (string)value;
						break;
					case MassQuote.TAG_EncodedSecurityDescLen:
						_iEncodedSecurityDescLen = (int)value;
						break;
					case MassQuote.TAG_EncodedSecurityDesc:
						_sEncodedSecurityDesc = (string)value;
						break;
					case MassQuote.TAG_Pool:
						_sPool = (string)value;
						break;
					case MassQuote.TAG_ContractSettlMonth:
						_dtContractSettlMonth = (DateTime)value;
						break;
					case MassQuote.TAG_CPProgram:
						_iCPProgram = (int)value;
						break;
					case MassQuote.TAG_CPRegType:
						_sCPRegType = (string)value;
						break;
					case MassQuote.TAG_NoEvents:
						_iNoEvents = (int)value;
						break;
					case MassQuote.TAG_DatedDate:
						_dtDatedDate = (DateTime)value;
						break;
					case MassQuote.TAG_InterestAccrualDate:
						_dtInterestAccrualDate = (DateTime)value;
						break;
					case MassQuote.TAG_NoLegs:
						_iNoLegs = (int)value;
						break;
					case MassQuote.TAG_BidPx:
						_dBidPx = (double)value;
						break;
					case MassQuote.TAG_OfferPx:
						_dOfferPx = (double)value;
						break;
					case MassQuote.TAG_BidSize:
						_iBidSize = (int)value;
						break;
					case MassQuote.TAG_OfferSize:
						_iOfferSize = (int)value;
						break;
					case MassQuote.TAG_ValidUntilTime:
						_dtValidUntilTime = (DateTime)value;
						break;
					case MassQuote.TAG_BidSpotRate:
						_dBidSpotRate = (double)value;
						break;
					case MassQuote.TAG_OfferSpotRate:
						_dOfferSpotRate = (double)value;
						break;
					case MassQuote.TAG_BidForwardPoints:
						_dBidForwardPoints = (double)value;
						break;
					case MassQuote.TAG_OfferForwardPoints:
						_dOfferForwardPoints = (double)value;
						break;
					case MassQuote.TAG_MidPx:
						_dMidPx = (double)value;
						break;
					case MassQuote.TAG_BidYield:
						_dBidYield = (double)value;
						break;
					case MassQuote.TAG_MidYield:
						_dMidYield = (double)value;
						break;
					case MassQuote.TAG_OfferYield:
						_dOfferYield = (double)value;
						break;
					case MassQuote.TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case MassQuote.TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case MassQuote.TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case MassQuote.TAG_SettlDate:
						_dtSettlDate = (DateTime)value;
						break;
					case MassQuote.TAG_OrdType:
						_cOrdType = (char)value;
						break;
					case MassQuote.TAG_SettlDate2:
						_dtSettlDate2 = (DateTime)value;
						break;
					case MassQuote.TAG_OrderQty2:
						_iOrderQty2 = (int)value;
						break;
					case MassQuote.TAG_BidForwardPoints2:
						_dBidForwardPoints2 = (double)value;
						break;
					case MassQuote.TAG_OfferForwardPoints2:
						_dOfferForwardPoints2 = (double)value;
						break;
					case MassQuote.TAG_Currency:
						_sCurrency = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MassQuoteQuoteEntrieList
	{
		private ArrayList _al;
		private MassQuoteQuoteEntrie _last;

		public MassQuoteQuoteEntrie this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MassQuoteQuoteEntrie)_al[i];
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

		public void Add(MassQuoteQuoteEntrie item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MassQuoteQuoteEntrie item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MassQuoteQuoteEntrie Last
		{
			get { return _last; }
		}
	}

	public class MassQuoteSecurityAltID
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
					case MassQuote.TAG_SecurityAltID:
						return _sSecurityAltID;
					case MassQuote.TAG_SecurityAltIDSource:
						return _sSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MassQuote.TAG_SecurityAltID:
						_sSecurityAltID = (string)value;
						break;
					case MassQuote.TAG_SecurityAltIDSource:
						_sSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MassQuoteSecurityAltIDList
	{
		private ArrayList _al;
		private MassQuoteSecurityAltID _last;

		public MassQuoteSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MassQuoteSecurityAltID)_al[i];
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

		public void Add(MassQuoteSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MassQuoteSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MassQuoteSecurityAltID Last
		{
			get { return _last; }
		}
	}

	public class MassQuoteEvent
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
					case MassQuote.TAG_EventType:
						return _iEventType;
					case MassQuote.TAG_EventDate:
						return _dtEventDate;
					case MassQuote.TAG_EventPx:
						return _dEventPx;
					case MassQuote.TAG_EventText:
						return _sEventText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MassQuote.TAG_EventType:
						_iEventType = (int)value;
						break;
					case MassQuote.TAG_EventDate:
						_dtEventDate = (DateTime)value;
						break;
					case MassQuote.TAG_EventPx:
						_dEventPx = (double)value;
						break;
					case MassQuote.TAG_EventText:
						_sEventText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MassQuoteEventList
	{
		private ArrayList _al;
		private MassQuoteEvent _last;

		public MassQuoteEvent this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MassQuoteEvent)_al[i];
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

		public void Add(MassQuoteEvent item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MassQuoteEvent item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MassQuoteEvent Last
		{
			get { return _last; }
		}
	}

	public class MassQuoteLeg
	{
		private string _sLegSymbol;
		private string _sLegSymbolSfx;
		private string _sLegSecurityID;
		private string _sLegSecurityIDSource;
		private int _iNoLegSecurityAltID;
		private MassQuoteLegSecurityAltIDList _listLegSecurityAltID = new MassQuoteLegSecurityAltIDList();
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
		public MassQuoteLegSecurityAltIDList LegSecurityAltID 
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
					case MassQuote.TAG_LegSymbol:
						return _sLegSymbol;
					case MassQuote.TAG_LegSymbolSfx:
						return _sLegSymbolSfx;
					case MassQuote.TAG_LegSecurityID:
						return _sLegSecurityID;
					case MassQuote.TAG_LegSecurityIDSource:
						return _sLegSecurityIDSource;
					case MassQuote.TAG_NoLegSecurityAltID:
						return _iNoLegSecurityAltID;
					case MassQuote.TAG_LegProduct:
						return _iLegProduct;
					case MassQuote.TAG_LegCFICode:
						return _sLegCFICode;
					case MassQuote.TAG_LegSecurityType:
						return _sLegSecurityType;
					case MassQuote.TAG_LegSecuritySubType:
						return _sLegSecuritySubType;
					case MassQuote.TAG_LegMaturityMonthYear:
						return _dtLegMaturityMonthYear;
					case MassQuote.TAG_LegMaturityDate:
						return _dtLegMaturityDate;
					case MassQuote.TAG_LegCouponPaymentDate:
						return _dtLegCouponPaymentDate;
					case MassQuote.TAG_LegIssueDate:
						return _dtLegIssueDate;
					case MassQuote.TAG_LegRepoCollateralSecurityType:
						return _iLegRepoCollateralSecurityType;
					case MassQuote.TAG_LegRepurchaseTerm:
						return _iLegRepurchaseTerm;
					case MassQuote.TAG_LegRepurchaseRate:
						return _dLegRepurchaseRate;
					case MassQuote.TAG_LegFactor:
						return _dLegFactor;
					case MassQuote.TAG_LegCreditRating:
						return _sLegCreditRating;
					case MassQuote.TAG_LegInstrRegistry:
						return _sLegInstrRegistry;
					case MassQuote.TAG_LegCountryOfIssue:
						return _sLegCountryOfIssue;
					case MassQuote.TAG_LegStateOrProvinceOfIssue:
						return _sLegStateOrProvinceOfIssue;
					case MassQuote.TAG_LegLocaleOfIssue:
						return _sLegLocaleOfIssue;
					case MassQuote.TAG_LegRedemptionDate:
						return _dtLegRedemptionDate;
					case MassQuote.TAG_LegStrikePrice:
						return _dLegStrikePrice;
					case MassQuote.TAG_LegStrikeCurrency:
						return _sLegStrikeCurrency;
					case MassQuote.TAG_LegOptAttribute:
						return _cLegOptAttribute;
					case MassQuote.TAG_LegContractMultiplier:
						return _dLegContractMultiplier;
					case MassQuote.TAG_LegCouponRate:
						return _dLegCouponRate;
					case MassQuote.TAG_LegSecurityExchange:
						return _sLegSecurityExchange;
					case MassQuote.TAG_LegIssuer:
						return _sLegIssuer;
					case MassQuote.TAG_EncodedLegIssuerLen:
						return _iEncodedLegIssuerLen;
					case MassQuote.TAG_EncodedLegIssuer:
						return _sEncodedLegIssuer;
					case MassQuote.TAG_LegSecurityDesc:
						return _sLegSecurityDesc;
					case MassQuote.TAG_EncodedLegSecurityDescLen:
						return _iEncodedLegSecurityDescLen;
					case MassQuote.TAG_EncodedLegSecurityDesc:
						return _sEncodedLegSecurityDesc;
					case MassQuote.TAG_LegRatioQty:
						return _dLegRatioQty;
					case MassQuote.TAG_LegSide:
						return _cLegSide;
					case MassQuote.TAG_LegCurrency:
						return _sLegCurrency;
					case MassQuote.TAG_LegPool:
						return _sLegPool;
					case MassQuote.TAG_LegDatedDate:
						return _dtLegDatedDate;
					case MassQuote.TAG_LegContractSettlMonth:
						return _dtLegContractSettlMonth;
					case MassQuote.TAG_LegInterestAccrualDate:
						return _dtLegInterestAccrualDate;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MassQuote.TAG_LegSymbol:
						_sLegSymbol = (string)value;
						break;
					case MassQuote.TAG_LegSymbolSfx:
						_sLegSymbolSfx = (string)value;
						break;
					case MassQuote.TAG_LegSecurityID:
						_sLegSecurityID = (string)value;
						break;
					case MassQuote.TAG_LegSecurityIDSource:
						_sLegSecurityIDSource = (string)value;
						break;
					case MassQuote.TAG_NoLegSecurityAltID:
						_iNoLegSecurityAltID = (int)value;
						break;
					case MassQuote.TAG_LegProduct:
						_iLegProduct = (int)value;
						break;
					case MassQuote.TAG_LegCFICode:
						_sLegCFICode = (string)value;
						break;
					case MassQuote.TAG_LegSecurityType:
						_sLegSecurityType = (string)value;
						break;
					case MassQuote.TAG_LegSecuritySubType:
						_sLegSecuritySubType = (string)value;
						break;
					case MassQuote.TAG_LegMaturityMonthYear:
						_dtLegMaturityMonthYear = (DateTime)value;
						break;
					case MassQuote.TAG_LegMaturityDate:
						_dtLegMaturityDate = (DateTime)value;
						break;
					case MassQuote.TAG_LegCouponPaymentDate:
						_dtLegCouponPaymentDate = (DateTime)value;
						break;
					case MassQuote.TAG_LegIssueDate:
						_dtLegIssueDate = (DateTime)value;
						break;
					case MassQuote.TAG_LegRepoCollateralSecurityType:
						_iLegRepoCollateralSecurityType = (int)value;
						break;
					case MassQuote.TAG_LegRepurchaseTerm:
						_iLegRepurchaseTerm = (int)value;
						break;
					case MassQuote.TAG_LegRepurchaseRate:
						_dLegRepurchaseRate = (double)value;
						break;
					case MassQuote.TAG_LegFactor:
						_dLegFactor = (double)value;
						break;
					case MassQuote.TAG_LegCreditRating:
						_sLegCreditRating = (string)value;
						break;
					case MassQuote.TAG_LegInstrRegistry:
						_sLegInstrRegistry = (string)value;
						break;
					case MassQuote.TAG_LegCountryOfIssue:
						_sLegCountryOfIssue = (string)value;
						break;
					case MassQuote.TAG_LegStateOrProvinceOfIssue:
						_sLegStateOrProvinceOfIssue = (string)value;
						break;
					case MassQuote.TAG_LegLocaleOfIssue:
						_sLegLocaleOfIssue = (string)value;
						break;
					case MassQuote.TAG_LegRedemptionDate:
						_dtLegRedemptionDate = (DateTime)value;
						break;
					case MassQuote.TAG_LegStrikePrice:
						_dLegStrikePrice = (double)value;
						break;
					case MassQuote.TAG_LegStrikeCurrency:
						_sLegStrikeCurrency = (string)value;
						break;
					case MassQuote.TAG_LegOptAttribute:
						_cLegOptAttribute = (char)value;
						break;
					case MassQuote.TAG_LegContractMultiplier:
						_dLegContractMultiplier = (double)value;
						break;
					case MassQuote.TAG_LegCouponRate:
						_dLegCouponRate = (double)value;
						break;
					case MassQuote.TAG_LegSecurityExchange:
						_sLegSecurityExchange = (string)value;
						break;
					case MassQuote.TAG_LegIssuer:
						_sLegIssuer = (string)value;
						break;
					case MassQuote.TAG_EncodedLegIssuerLen:
						_iEncodedLegIssuerLen = (int)value;
						break;
					case MassQuote.TAG_EncodedLegIssuer:
						_sEncodedLegIssuer = (string)value;
						break;
					case MassQuote.TAG_LegSecurityDesc:
						_sLegSecurityDesc = (string)value;
						break;
					case MassQuote.TAG_EncodedLegSecurityDescLen:
						_iEncodedLegSecurityDescLen = (int)value;
						break;
					case MassQuote.TAG_EncodedLegSecurityDesc:
						_sEncodedLegSecurityDesc = (string)value;
						break;
					case MassQuote.TAG_LegRatioQty:
						_dLegRatioQty = (double)value;
						break;
					case MassQuote.TAG_LegSide:
						_cLegSide = (char)value;
						break;
					case MassQuote.TAG_LegCurrency:
						_sLegCurrency = (string)value;
						break;
					case MassQuote.TAG_LegPool:
						_sLegPool = (string)value;
						break;
					case MassQuote.TAG_LegDatedDate:
						_dtLegDatedDate = (DateTime)value;
						break;
					case MassQuote.TAG_LegContractSettlMonth:
						_dtLegContractSettlMonth = (DateTime)value;
						break;
					case MassQuote.TAG_LegInterestAccrualDate:
						_dtLegInterestAccrualDate = (DateTime)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MassQuoteLegList
	{
		private ArrayList _al;
		private MassQuoteLeg _last;

		public MassQuoteLeg this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MassQuoteLeg)_al[i];
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

		public void Add(MassQuoteLeg item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MassQuoteLeg item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MassQuoteLeg Last
		{
			get { return _last; }
		}
	}

	public class MassQuoteLegSecurityAltID
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
					case MassQuote.TAG_LegSecurityAltID:
						return _sLegSecurityAltID;
					case MassQuote.TAG_LegSecurityAltIDSource:
						return _sLegSecurityAltIDSource;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MassQuote.TAG_LegSecurityAltID:
						_sLegSecurityAltID = (string)value;
						break;
					case MassQuote.TAG_LegSecurityAltIDSource:
						_sLegSecurityAltIDSource = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MassQuoteLegSecurityAltIDList
	{
		private ArrayList _al;
		private MassQuoteLegSecurityAltID _last;

		public MassQuoteLegSecurityAltID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MassQuoteLegSecurityAltID)_al[i];
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

		public void Add(MassQuoteLegSecurityAltID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MassQuoteLegSecurityAltID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MassQuoteLegSecurityAltID Last
		{
			get { return _last; }
		}
	}
}
