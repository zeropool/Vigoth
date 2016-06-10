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
using System.Text;

using FIX4NET;
using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_2
{
	/// <summary>
	/// Summary description for IndicationOfInterest.
	/// </summary>
	public class IndicationOfInterest : Message
	{
		public const int TAG_IOIid = 23;
		public const int TAG_IOITransType = 28;
		public const int TAG_IOIRefID = 26;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_SecurityType = 167;
		public const int TAG_MaturityMonthYear = 200;
		public const int TAG_MaturityDay = 205;
		public const int TAG_PutOrCall = 201;
		public const int TAG_StrikePrice = 202;
		public const int TAG_OptAttribute = 206;
		public const int TAG_ContractMultiplier = 231;
		public const int TAG_CouponRate = 223;
		public const int TAG_SecurityExchange = 207;
		public const int TAG_Issuer = 106;
		public const int TAG_EncodedIssuerLen = 348;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_EncodedSecurityDescLen = 350;
		public const int TAG_Side = 54;
		public const int TAG_IOIShares = 27;
		public const int TAG_Price = 44;
		public const int TAG_Currency = 15;
		public const int TAG_ValidUntilTime = 62;
		public const int TAG_IOIQltyInd = 25;
		public const int TAG_IOINaturalFlag = 130;
		public const int TAG_NoIOIQualifiers = 199;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_TransactTime = 60;
		public const int TAG_URLLink = 149;
		public const int TAG_NoRoutingIDs = 215;
		public const int TAG_SpreadToBenchmark = 218;
		public const int TAG_Benchmark = 219;

		private string _sIOIid;
		private char _cIOITransType;
		private string _sIOIRefID;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sSecurityType;
		private DateTime _dtMaturityMonthYear;
		private byte _iMaturityDay;
		private int _iPutOrCall;
		private double _dStrikePrice;
		private char _cOptAttribute;
		private double _dContractMultiplier;
		private double _dCouponRate;
		private string _sSecurityExchange;
		private string _sIssuer;
		private int _iEncodedIssuerLen;
		private string _sSecurityDesc;
		private int _iEncodedSecurityDescLen;
		private char _cSide;
		private string _sIOIShares;
		private double _dPrice;
		private double _dCurrency;
		private DateTime _dtValidUntilTime;
		private char _cIOIQltyInd;
		private bool _bIOINaturalFlag;
		private int _iNoIOIQualifiers;
		private string _sText;
		private int _iEncodedTextLen;
		private DateTime _dtTransactTime;
		private string _sURLLink;
		private int _iNoRoutingIDs;
		private double _dSpreadToBenchmark;
		private char _cBenchmark;

		public IndicationOfInterest() : base()
		{
			_sMsgType = Values.MsgType.IndicationOfInterest;
		}

		public string IOIid 
		{ 
			get { return _sIOIid; } 
			set { _sIOIid = value; } 
		}
		public char IOITransType 
		{ 
			get { return _cIOITransType; } 
			set { _cIOITransType = value; } 
		}
		public string IOIRefID 
		{ 
			get { return _sIOIRefID; } 
			set { _sIOIRefID = value; } 
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
		public string IDSource 
		{ 
			get { return _sIDSource; } 
			set { _sIDSource = value; } 
		}
		public string SecurityType 
		{ 
			get { return _sSecurityType; } 
			set { _sSecurityType = value; } 
		}
		public DateTime MaturityMonthYear 
		{ 
			get { return _dtMaturityMonthYear; } 
			set { _dtMaturityMonthYear = value; } 
		}
		public byte MaturityDay 
		{ 
			get { return _iMaturityDay; } 
			set { _iMaturityDay = value; } 
		}
		public int PutOrCall 
		{ 
			get { return _iPutOrCall; } 
			set { _iPutOrCall = value; } 
		}
		public double StrikePrice 
		{ 
			get { return _dStrikePrice; } 
			set { _dStrikePrice = value; } 
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
		public char Side 
		{ 
			get { return _cSide; } 
			set { _cSide = value; } 
		}
		public string IOIShares 
		{ 
			get { return _sIOIShares; } 
			set { _sIOIShares = value; } 
		}
		public double Price 
		{ 
			get { return _dPrice; } 
			set { _dPrice = value; } 
		}
		public double Currency 
		{ 
			get { return _dCurrency; } 
			set { _dCurrency = value; } 
		}
		public DateTime ValidUntilTime 
		{ 
			get { return _dtValidUntilTime; } 
			set { _dtValidUntilTime = value; } 
		}
		public char IOIQltyInd 
		{ 
			get { return _cIOIQltyInd; } 
			set { _cIOIQltyInd = value; } 
		}
		public bool IOINaturalFlag 
		{ 
			get { return _bIOINaturalFlag; } 
			set { _bIOINaturalFlag = value; } 
		}
		public int NoIOIQualifiers 
		{ 
			get { return _iNoIOIQualifiers; } 
			set { _iNoIOIQualifiers = value; } 
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
		public DateTime TransactTime 
		{ 
			get { return _dtTransactTime; } 
			set { _dtTransactTime = value; } 
		}
		public string URLLink 
		{ 
			get { return _sURLLink; } 
			set { _sURLLink = value; } 
		}
		public int NoRoutingIDs 
		{ 
			get { return _iNoRoutingIDs; } 
			set { _iNoRoutingIDs = value; } 
		}
		public double SpreadToBenchmark 
		{ 
			get { return _dSpreadToBenchmark; } 
			set { _dSpreadToBenchmark = value; } 
		}
		public char Benchmark 
		{ 
			get { return _cBenchmark; } 
			set { _cBenchmark = value; } 
		}

		public override object this[int iTag] 
		{
			get 
			{
				if(iTag == TAG_IOIid)
					return _sIOIid;
				else if(iTag == TAG_IOITransType)
					return _cIOITransType;
				else if(iTag == TAG_IOIRefID)
					return _sIOIRefID;
				else if(iTag == TAG_Symbol)
					return _sSymbol;
				else if(iTag == TAG_SymbolSfx)
					return _sSymbolSfx;
				else if(iTag == TAG_SecurityID)
					return _sSecurityID;
				else if(iTag == TAG_IDSource)
					return _sIDSource;
				else if(iTag == TAG_SecurityType)
					return _sSecurityType;
				else if(iTag == TAG_MaturityMonthYear)
					return _dtMaturityMonthYear;
				else if(iTag == TAG_MaturityDay)
					return _iMaturityDay;
				else if(iTag == TAG_PutOrCall)
					return _iPutOrCall;
				else if(iTag == TAG_StrikePrice)
					return _dStrikePrice;
				else if(iTag == TAG_OptAttribute)
					return _cOptAttribute;
				else if(iTag == TAG_ContractMultiplier)
					return _dContractMultiplier;
				else if(iTag == TAG_CouponRate)
					return _dCouponRate;
				else if(iTag == TAG_SecurityExchange)
					return _sSecurityExchange;
				else if(iTag == TAG_Issuer)
					return _sIssuer;
				else if(iTag == TAG_EncodedIssuerLen)
					return _iEncodedIssuerLen;
				else if(iTag == TAG_SecurityDesc)
					return _sSecurityDesc;
				else if(iTag == TAG_EncodedSecurityDescLen)
					return _iEncodedSecurityDescLen;
				else if(iTag == TAG_Side)
					return _cSide;
				else if(iTag == TAG_IOIShares)
					return _sIOIShares;
				else if(iTag == TAG_Price)
					return _dPrice;
				else if(iTag == TAG_Currency)
					return _dCurrency;
				else if(iTag == TAG_ValidUntilTime)
					return _dtValidUntilTime;
				else if(iTag == TAG_IOIQltyInd)
					return _cIOIQltyInd;
				else if(iTag == TAG_IOINaturalFlag)
					return _bIOINaturalFlag;
				else if(iTag == TAG_NoIOIQualifiers)
					return _iNoIOIQualifiers;
				else if(iTag == TAG_Text)
					return _sText;
				else if(iTag == TAG_EncodedTextLen)
					return _iEncodedTextLen;
				else if(iTag == TAG_TransactTime)
					return _dtTransactTime;
				else if(iTag == TAG_URLLink)
					return _sURLLink;
				else if(iTag == TAG_NoRoutingIDs)
					return _iNoRoutingIDs;
				else if(iTag == TAG_SpreadToBenchmark)
					return _dSpreadToBenchmark;
				else if(iTag == TAG_Benchmark)
					return _cBenchmark;
				else
					return base[iTag];
			}
			set 
			{
				if(iTag == TAG_IOIid)
					_sIOIid = (string) value;
				else if(iTag == TAG_IOITransType)
					_cIOITransType = (char) value;
				else if(iTag == TAG_IOIRefID)
					_sIOIRefID = (string) value;
				else if(iTag == TAG_Symbol)
					_sSymbol = (string) value;
				else if(iTag == TAG_SymbolSfx)
					_sSymbolSfx = (string) value;
				else if(iTag == TAG_SecurityID)
					_sSecurityID = (string) value;
				else if(iTag == TAG_IDSource)
					_sIDSource = (string) value;
				else if(iTag == TAG_SecurityType)
					_sSecurityType = (string) value;
				else if(iTag == TAG_MaturityMonthYear)
					_dtMaturityMonthYear = (DateTime) value;
				else if(iTag == TAG_MaturityDay)
					_iMaturityDay = (byte) value;
				else if(iTag == TAG_PutOrCall)
					_iPutOrCall = (int) value;
				else if(iTag == TAG_StrikePrice)
					_dStrikePrice = (double) value;
				else if(iTag == TAG_OptAttribute)
					_cOptAttribute = (char) value;
				else if(iTag == TAG_ContractMultiplier)
					_dContractMultiplier = (double) value;
				else if(iTag == TAG_CouponRate)
					_dCouponRate = (double) value;
				else if(iTag == TAG_SecurityExchange)
					_sSecurityExchange = (string) value;
				else if(iTag == TAG_Issuer)
					_sIssuer = (string) value;
				else if(iTag == TAG_EncodedIssuerLen)
					_iEncodedIssuerLen = (int) value;
				else if(iTag == TAG_SecurityDesc)
					_sSecurityDesc = (string) value;
				else if(iTag == TAG_EncodedSecurityDescLen)
					_iEncodedSecurityDescLen = (int) value;
				else if(iTag == TAG_Side)
					_cSide = (char) value;
				else if(iTag == TAG_IOIShares)
					_sIOIShares = (string) value;
				else if(iTag == TAG_Price)
					_dPrice = (double) value;
				else if(iTag == TAG_Currency)
					_dCurrency = (double) value;
				else if(iTag == TAG_ValidUntilTime)
					_dtValidUntilTime = (DateTime) value;
				else if(iTag == TAG_IOIQltyInd)
					_cIOIQltyInd = (char) value;
				else if(iTag == TAG_IOINaturalFlag)
					_bIOINaturalFlag = (bool) value;
				else if(iTag == TAG_NoIOIQualifiers)
					_iNoIOIQualifiers = (int) value;
				else if(iTag == TAG_Text)
					_sText = (string) value;
				else if(iTag == TAG_EncodedTextLen)
					_iEncodedTextLen = (int) value;
				else if(iTag == TAG_TransactTime)
					_dtTransactTime = (DateTime) value;
				else if(iTag == TAG_URLLink)
					_sURLLink = (string) value;
				else if(iTag == TAG_NoRoutingIDs)
					_iNoRoutingIDs = (int) value;
				else if(iTag == TAG_SpreadToBenchmark)
					_dSpreadToBenchmark = (double) value;
				else if(iTag == TAG_Benchmark)
					_cBenchmark = (char) value;
				else
					base[iTag] = value;
			}
		}
	}
}
