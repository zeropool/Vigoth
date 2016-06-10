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

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_0
{
	/// <summary>
	/// The new order message type is used by institutions wishing to electronically 
	/// submit securities and forex orders to a broker for execution.
	/// 
	/// Orders can be submitted with special handling instructions and execution 
	/// instructions.  Handling instructions refer to how the broker should handle the 
	/// order on its trading floor (see HandInst field); execution instructions contain 
	/// explicit directions as to how the order should be executed (see ExecInst field).
	/// 
	/// New Order messages received with the PossResend flag set in the header should 
	/// be validated by ClOrdID and order  parameters (side, symbol, quantity, etc.) to 
	/// determine if the order had been previously submitted.  PossResends previously 
	/// received should be acknowledged back to the client via an Execution - Status 
	/// message.  PossResends not previously received should be processed as a new 
	/// order and acknowledged via an Execution - New message.
	/// </summary>
	public class NewOrderSingle : Message
	{
		public const int TAG_ClOrdID = 11;
		public const int TAG_ClientID = 109;
		public const int TAG_ExecBroker = 76;
		public const int TAG_Account = 1;
		public const int TAG_SettlmntTyp = 63;
		public const int TAG_FutSettDate = 64;
		public const int TAG_HandlInst = 21;
		public const int TAG_ExecInst = 18;
		public const int TAG_MinQty = 110;
		public const int TAG_MaxFloor = 111;
		public const int TAG_ExDestination = 100;
		public const int TAG_ProcessCode = 81;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_Issuer = 106;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_PrevClosePx = 140;
		public const int TAG_Side = 54;
		public const int TAG_LocateReqd = 114;
		public const int TAG_OrderQty = 38;
		public const int TAG_OrdType = 40;
		public const int TAG_Price = 44;
		public const int TAG_StopPx = 99;
		public const int TAG_Currency = 15;
		public const int TAG_IOIid = 23;
		public const int TAG_QuoteID = 117;
		public const int TAG_TimeInForce = 59;
		public const int TAG_ExpireTime = 126;
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_Rule80A = 47;
		public const int TAG_ForexReq = 121;
		public const int TAG_SettlCurrency = 120;
		public const int TAG_Text = 58;

		private string _sClOrdID;
		private string _sClientID;
		private string _sExecBroker;
		private string _sAccount;
		private char _cSettlmntTyp;
		private DateTime _dtFutSettDate;
		private char _cHandlInst;
		private string _sExecInst;
		private int _iMinQty;
		private int _iMaxFloor;
		private string _sExDestination;
		private char _cProcessCode;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sIssuer;
		private string _sSecurityDesc;
		private double _dPrevClosePx;
		private char _cSide;
		private bool _bLocateReqd;
		private int _iOrderQty;
		private char _cOrdType;
		private double _dPrice;
		private double _dStopPx;
		private double _dCurrency;
		private string _sIOIid;
		private string _sQuoteID;
		private char _cTimeInForce;
		private DateTime _dtExpireTime;
		private double _dCommission;
		private char _cCommType;
		private char _cRule80A;
		private bool _bForexReq;
		private double _dSettlCurrency;
		private string _sText;

		internal NewOrderSingle()
			: base()
		{
			_sMsgType = Values.MsgType.NewOrderSingle;
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
		public string ExecBroker
		{
			get { return _sExecBroker; }
			set { _sExecBroker = value; }
		}
		public string Account
		{
			get { return _sAccount; }
			set { _sAccount = value; }
		}
		public char SettlmntTyp
		{
			get { return _cSettlmntTyp; }
			set { _cSettlmntTyp = value; }
		}
		public DateTime FutSettDate
		{
			get { return _dtFutSettDate; }
			set { _dtFutSettDate = value; }
		}
		public char HandlInst
		{
			get { return _cHandlInst; }
			set { _cHandlInst = value; }
		}
		public string ExecInst
		{
			get { return _sExecInst; }
			set { _sExecInst = value; }
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
		public string ExDestination
		{
			get { return _sExDestination; }
			set { _sExDestination = value; }
		}
		public char ProcessCode
		{
			get { return _cProcessCode; }
			set { _cProcessCode = value; }
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
		public string Issuer
		{
			get { return _sIssuer; }
			set { _sIssuer = value; }
		}
		public string SecurityDesc
		{
			get { return _sSecurityDesc; }
			set { _sSecurityDesc = value; }
		}
		public double PrevClosePx
		{
			get { return _dPrevClosePx; }
			set { _dPrevClosePx = value; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
		}
		public bool LocateReqd
		{
			get { return _bLocateReqd; }
			set { _bLocateReqd = value; }
		}
		public int OrderQty
		{
			get { return _iOrderQty; }
			set { _iOrderQty = value; }
		}
		public char OrdType
		{
			get { return _cOrdType; }
			set { _cOrdType = value; }
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
		public double Currency
		{
			get { return _dCurrency; }
			set { _dCurrency = value; }
		}
		public string IOIid
		{
			get { return _sIOIid; }
			set { _sIOIid = value; }
		}
		public string QuoteID
		{
			get { return _sQuoteID; }
			set { _sQuoteID = value; }
		}
		public char TimeInForce
		{
			get { return _cTimeInForce; }
			set { _cTimeInForce = value; }
		}
		public DateTime ExpireTime
		{
			get { return _dtExpireTime; }
			set { _dtExpireTime = value; }
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
		public char Rule80A
		{
			get { return _cRule80A; }
			set { _cRule80A = value; }
		}
		public bool ForexReq
		{
			get { return _bForexReq; }
			set { _bForexReq = value; }
		}
		public double SettlCurrency
		{
			get { return _dSettlCurrency; }
			set { _dSettlCurrency = value; }
		}
		public string Text
		{
			get { return _sText; }
			set { _sText = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				if (iTag == TAG_ClOrdID)
					return _sClOrdID;
				else if (iTag == TAG_ClientID)
					return _sClientID;
				else if (iTag == TAG_ExecBroker)
					return _sExecBroker;
				else if (iTag == TAG_Account)
					return _sAccount;
				else if (iTag == TAG_SettlmntTyp)
					return _cSettlmntTyp;
				else if (iTag == TAG_FutSettDate)
					return _dtFutSettDate;
				else if (iTag == TAG_HandlInst)
					return _cHandlInst;
				else if (iTag == TAG_ExecInst)
					return _sExecInst;
				else if (iTag == TAG_MinQty)
					return _iMinQty;
				else if (iTag == TAG_MaxFloor)
					return _iMaxFloor;
				else if (iTag == TAG_ExDestination)
					return _sExDestination;
				else if (iTag == TAG_ProcessCode)
					return _cProcessCode;
				else if (iTag == TAG_Symbol)
					return _sSymbol;
				else if (iTag == TAG_SymbolSfx)
					return _sSymbolSfx;
				else if (iTag == TAG_SecurityID)
					return _sSecurityID;
				else if (iTag == TAG_IDSource)
					return _sIDSource;
				else if (iTag == TAG_Issuer)
					return _sIssuer;
				else if (iTag == TAG_SecurityDesc)
					return _sSecurityDesc;
				else if (iTag == TAG_PrevClosePx)
					return _dPrevClosePx;
				else if (iTag == TAG_Side)
					return _cSide;
				else if (iTag == TAG_LocateReqd)
					return _bLocateReqd;
				else if (iTag == TAG_OrderQty)
					return _iOrderQty;
				else if (iTag == TAG_OrdType)
					return _cOrdType;
				else if (iTag == TAG_Price)
					return _dPrice;
				else if (iTag == TAG_StopPx)
					return _dStopPx;
				else if (iTag == TAG_Currency)
					return _dCurrency;
				else if (iTag == TAG_IOIid)
					return _sIOIid;
				else if (iTag == TAG_QuoteID)
					return _sQuoteID;
				else if (iTag == TAG_TimeInForce)
					return _cTimeInForce;
				else if (iTag == TAG_ExpireTime)
					return _dtExpireTime;
				else if (iTag == TAG_Commission)
					return _dCommission;
				else if (iTag == TAG_CommType)
					return _cCommType;
				else if (iTag == TAG_Rule80A)
					return _cRule80A;
				else if (iTag == TAG_ForexReq)
					return _bForexReq;
				else if (iTag == TAG_SettlCurrency)
					return _dSettlCurrency;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_ClOrdID)
					_sClOrdID = (string)value;
				else if (iTag == TAG_ClientID)
					_sClientID = (string)value;
				else if (iTag == TAG_ExecBroker)
					_sExecBroker = (string)value;
				else if (iTag == TAG_Account)
					_sAccount = (string)value;
				else if (iTag == TAG_SettlmntTyp)
					_cSettlmntTyp = (char)value;
				else if (iTag == TAG_FutSettDate)
					_dtFutSettDate = (DateTime)value;
				else if (iTag == TAG_HandlInst)
					_cHandlInst = (char)value;
				else if (iTag == TAG_ExecInst)
					_sExecInst = (string)value;
				else if (iTag == TAG_MinQty)
					_iMinQty = (int)value;
				else if (iTag == TAG_MaxFloor)
					_iMaxFloor = (int)value;
				else if (iTag == TAG_ExDestination)
					_sExDestination = (string)value;
				else if (iTag == TAG_ProcessCode)
					_cProcessCode = (char)value;
				else if (iTag == TAG_Symbol)
					_sSymbol = (string)value;
				else if (iTag == TAG_SymbolSfx)
					_sSymbolSfx = (string)value;
				else if (iTag == TAG_SecurityID)
					_sSecurityID = (string)value;
				else if (iTag == TAG_IDSource)
					_sIDSource = (string)value;
				else if (iTag == TAG_Issuer)
					_sIssuer = (string)value;
				else if (iTag == TAG_SecurityDesc)
					_sSecurityDesc = (string)value;
				else if (iTag == TAG_PrevClosePx)
					_dPrevClosePx = (double)value;
				else if (iTag == TAG_Side)
					_cSide = (char)value;
				else if (iTag == TAG_LocateReqd)
					_bLocateReqd = (bool)value;
				else if (iTag == TAG_OrderQty)
					_iOrderQty = (int)value;
				else if (iTag == TAG_OrdType)
					_cOrdType = (char)value;
				else if (iTag == TAG_Price)
					_dPrice = (double)value;
				else if (iTag == TAG_StopPx)
					_dStopPx = (double)value;
				else if (iTag == TAG_Currency)
					_dCurrency = (double)value;
				else if (iTag == TAG_IOIid)
					_sIOIid = (string)value;
				else if (iTag == TAG_QuoteID)
					_sQuoteID = (string)value;
				else if (iTag == TAG_TimeInForce)
					_cTimeInForce = (char)value;
				else if (iTag == TAG_ExpireTime)
					_dtExpireTime = (DateTime)value;
				else if (iTag == TAG_Commission)
					_dCommission = (double)value;
				else if (iTag == TAG_CommType)
					_cCommType = (char)value;
				else if (iTag == TAG_Rule80A)
					_cRule80A = (char)value;
				else if (iTag == TAG_ForexReq)
					_bForexReq = (bool)value;
				else if (iTag == TAG_SettlCurrency)
					_dSettlCurrency = (double)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}
	}
}
