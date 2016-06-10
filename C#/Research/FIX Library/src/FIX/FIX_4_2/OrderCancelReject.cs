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

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_2
{
	/// <summary>
	/// Summary description for OrderCancelReject.
	/// </summary>
	public class OrderCancelReject : Message
	{
		public const int TAG_OrderID = 37;
		public const int TAG_ClOrdID = 11;
		public const int TAG_ClientID = 109;
		public const int TAG_Account = 1;
		public const int TAG_ExecBroker = 76;
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

		private string _sOrderID;
		private string _sClOrdID;
		private string _sClientID;
		private string _sAccount;
		private string _sExecBroker;
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

		public OrderCancelReject() : base()
		{
			_sMsgType = Values.MsgType.OrderCancelReject;
		}

		public string OrderID 
		{ 
			get { return _sOrderID; } 
			set { _sOrderID = value; } 
		}
		public string ClOrdID 
		{ 
			get { return _sClOrdID; } 
			set { _sClOrdID = value; } 
		}
		public string ClientID 
		{ 
			get { return _sClientID; } 
			set { _sClientID = value; } 
		}
		public string Account 
		{ 
			get { return _sAccount; } 
			set { _sAccount = value; } 
		}
		public string ExecBroker 
		{ 
			get { return _sExecBroker; } 
			set { _sExecBroker = value; } 
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

		public override object this[int iTag] 
		{
			get 
			{
				if(iTag == TAG_OrderID)
					return _sOrderID;
				else if(iTag == TAG_ClOrdID)
					return _sClOrdID;
				else if(iTag == TAG_ClientID)
					return _sClientID;
				else if(iTag == TAG_Account)
					return _sAccount;
				else if(iTag == TAG_ExecBroker)
					return _sExecBroker;
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
				else
					return base[iTag];
			}
			set 
			{
				if(iTag == TAG_OrderID)
					_sOrderID = (string) value;
				else if(iTag == TAG_ClOrdID)
					_sClOrdID = (string) value;
				else if(iTag == TAG_ClientID)
					_sClientID = (string) value;
				else if(iTag == TAG_Account)
					_sAccount = (string) value;
				else if(iTag == TAG_ExecBroker)
					_sExecBroker = (string) value;
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
				else
					base[iTag] = value;
			}
		}
	}
}
