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
	/// Summary description for OrderCancelReplaceRequest.
	/// </summary>
	public class OrderCancelReplaceRequest : Message
	{
		public const int TAG_OrderID = 37;
		public const int TAG_ClientID = 109;
		public const int TAG_ExecBroker = 76;
		public const int TAG_OrigClOrdID = 41;
		public const int TAG_ClOrdID = 11;
		public const int TAG_ListID = 66;
		public const int TAG_Account = 1;
		public const int TAG_NoAllocs = 78;
		public const int TAG_SettlmntTyp = 63;
		public const int TAG_FutSettDate = 64;
		public const int TAG_HandlInst = 21;
		public const int TAG_ExecInst = 18;
		public const int TAG_MinQty = 110;
		public const int TAG_MaxFloor = 111;
		public const int TAG_ExDestination = 100;
		public const int TAG_NoTradingSessions = 386;
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
		public const int TAG_TransactTime = 60;
		public const int TAG_OrderQty = 38;
		public const int TAG_CashOrderQty = 152;
		public const int TAG_OrdType = 40;
		public const int TAG_Price = 44;
		public const int TAG_StopPx = 99;
		public const int TAG_PegDifference = 211;
		public const int TAG_DiscretionInst = 388;
		public const int TAG_DiscretionOffset = 389;
		public const int TAG_ComplianceID = 376;
		public const int TAG_SolicitedFlag = 377;
		public const int TAG_Currency = 15;
		public const int TAG_TimeInForce = 59;
		public const int TAG_EffectiveTime = 168;
		public const int TAG_ExpireDate = 432;
		public const int TAG_ExpireTime = 126;
		public const int TAG_GTBookingInst = 427;
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_Rule80A = 47;
		public const int TAG_ForexReq = 121;
		public const int TAG_SettlCurrency = 120;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_FutSettDate2 = 193;
		public const int TAG_OrderQty2 = 192;
		public const int TAG_OpenClose = 77;
		public const int TAG_CoveredOrUncovered = 203;
		public const int TAG_CustomerOrFirm = 204;
		public const int TAG_MaxShow = 210;
		public const int TAG_LocateReqd = 114;
		public const int TAG_ClearingFirm = 439;
		public const int TAG_ClearingAccount = 440;

		private string _sOrderID;
		private string _sClientID;
		private string _sExecBroker;
		private string _sOrigClOrdID;
		private string _sClOrdID;
		private string _sListID;
		private string _sAccount;
		private int _iNoAllocs;
		private char _cSettlmntTyp;
		private DateTime _dtFutSettDate;
		private char _cHandlInst;
		private string _sExecInst;
		private int _iMinQty;
		private int _iMaxFloor;
		private string _sExDestination;
		private int _iNoTradingSessions;
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
		private DateTime _dtTransactTime;
		private int _iOrderQty;
		private int _iCashOrderQty;
		private char _cOrdType;
		private double _dPrice;
		private double _dStopPx;
		private double _dPegDifference;
		private char _cDiscretionInst;
		private double _dDiscretionOffset;
		private string _sComplianceID;
		private bool _bSolicitedFlag;
		private double _dCurrency;
		private char _cTimeInForce;
		private DateTime _dtEffectiveTime;
		private DateTime _dtExpireDate;
		private DateTime _dtExpireTime;
		private int _iGTBookingInst;
		private double _dCommission;
		private char _cCommType;
		private char _cRule80A;
		private bool _bForexReq;
		private double _dSettlCurrency;
		private string _sText;
		private int _iEncodedTextLen;
		private DateTime _dtFutSettDate2;
		private int _iOrderQty2;
		private char _cOpenClose;
		private int _iCoveredOrUncovered;
		private int _iCustomerOrFirm;
		private int _iMaxShow;
		private bool _bLocateReqd;
		private string _sClearingFirm;
		private string _sClearingAccount;

		public OrderCancelReplaceRequest() : base()
		{
			_sMsgType = Values.MsgType.OrderCancelReplaceRequest;
		}

		public string OrderID 
		{ 
			get { return _sOrderID; } 
			set { _sOrderID = value; } 
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
		public string ListID 
		{ 
			get { return _sListID; } 
			set { _sListID = value; } 
		}
		public string Account 
		{ 
			get { return _sAccount; } 
			set { _sAccount = value; } 
		}
		public int NoAllocs 
		{ 
			get { return _iNoAllocs; } 
			set { _iNoAllocs = value; } 
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
		public int NoTradingSessions 
		{ 
			get { return _iNoTradingSessions; } 
			set { _iNoTradingSessions = value; } 
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
		public DateTime TransactTime 
		{ 
			get { return _dtTransactTime; } 
			set { _dtTransactTime = value; } 
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
		public double PegDifference 
		{ 
			get { return _dPegDifference; } 
			set { _dPegDifference = value; } 
		}
		public char DiscretionInst 
		{ 
			get { return _cDiscretionInst; } 
			set { _cDiscretionInst = value; } 
		}
		public double DiscretionOffset 
		{ 
			get { return _dDiscretionOffset; } 
			set { _dDiscretionOffset = value; } 
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
		public double Currency 
		{ 
			get { return _dCurrency; } 
			set { _dCurrency = value; } 
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
		public int GTBookingInst 
		{ 
			get { return _iGTBookingInst; } 
			set { _iGTBookingInst = value; } 
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
		public int EncodedTextLen 
		{ 
			get { return _iEncodedTextLen; } 
			set { _iEncodedTextLen = value; } 
		}
		public DateTime FutSettDate2 
		{ 
			get { return _dtFutSettDate2; } 
			set { _dtFutSettDate2 = value; } 
		}
		public int OrderQty2 
		{ 
			get { return _iOrderQty2; } 
			set { _iOrderQty2 = value; } 
		}
		public char OpenClose 
		{ 
			get { return _cOpenClose; } 
			set { _cOpenClose = value; } 
		}
		public int CoveredOrUncovered 
		{ 
			get { return _iCoveredOrUncovered; } 
			set { _iCoveredOrUncovered = value; } 
		}
		public int CustomerOrFirm 
		{ 
			get { return _iCustomerOrFirm; } 
			set { _iCustomerOrFirm = value; } 
		}
		public int MaxShow 
		{ 
			get { return _iMaxShow; } 
			set { _iMaxShow = value; } 
		}
		public bool LocateReqd 
		{ 
			get { return _bLocateReqd; } 
			set { _bLocateReqd = value; } 
		}
		public string ClearingFirm 
		{ 
			get { return _sClearingFirm; } 
			set { _sClearingFirm = value; } 
		}
		public string ClearingAccount 
		{ 
			get { return _sClearingAccount; } 
			set { _sClearingAccount = value; } 
		}

		public override object this[int iTag] 
		{
			get 
			{
				if(iTag == TAG_OrderID)
					return _sOrderID;
				else if(iTag == TAG_ClientID)
					return _sClientID;
				else if(iTag == TAG_ExecBroker)
					return _sExecBroker;
				else if(iTag == TAG_OrigClOrdID)
					return _sOrigClOrdID;
				else if(iTag == TAG_ClOrdID)
					return _sClOrdID;
				else if(iTag == TAG_ListID)
					return _sListID;
				else if(iTag == TAG_Account)
					return _sAccount;
				else if(iTag == TAG_NoAllocs)
					return _iNoAllocs;
				else if(iTag == TAG_SettlmntTyp)
					return _cSettlmntTyp;
				else if(iTag == TAG_FutSettDate)
					return _dtFutSettDate;
				else if(iTag == TAG_HandlInst)
					return _cHandlInst;
				else if(iTag == TAG_ExecInst)
					return _sExecInst;
				else if(iTag == TAG_MinQty)
					return _iMinQty;
				else if(iTag == TAG_MaxFloor)
					return _iMaxFloor;
				else if(iTag == TAG_ExDestination)
					return _sExDestination;
				else if(iTag == TAG_NoTradingSessions)
					return _iNoTradingSessions;
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
				else if(iTag == TAG_TransactTime)
					return _dtTransactTime;
				else if(iTag == TAG_OrderQty)
					return _iOrderQty;
				else if(iTag == TAG_CashOrderQty)
					return _iCashOrderQty;
				else if(iTag == TAG_OrdType)
					return _cOrdType;
				else if(iTag == TAG_Price)
					return _dPrice;
				else if(iTag == TAG_StopPx)
					return _dStopPx;
				else if(iTag == TAG_PegDifference)
					return _dPegDifference;
				else if(iTag == TAG_DiscretionInst)
					return _cDiscretionInst;
				else if(iTag == TAG_DiscretionOffset)
					return _dDiscretionOffset;
				else if(iTag == TAG_ComplianceID)
					return _sComplianceID;
				else if(iTag == TAG_SolicitedFlag)
					return _bSolicitedFlag;
				else if(iTag == TAG_Currency)
					return _dCurrency;
				else if(iTag == TAG_TimeInForce)
					return _cTimeInForce;
				else if(iTag == TAG_EffectiveTime)
					return _dtEffectiveTime;
				else if(iTag == TAG_ExpireDate)
					return _dtExpireDate;
				else if(iTag == TAG_ExpireTime)
					return _dtExpireTime;
				else if(iTag == TAG_GTBookingInst)
					return _iGTBookingInst;
				else if(iTag == TAG_Commission)
					return _dCommission;
				else if(iTag == TAG_CommType)
					return _cCommType;
				else if(iTag == TAG_Rule80A)
					return _cRule80A;
				else if(iTag == TAG_ForexReq)
					return _bForexReq;
				else if(iTag == TAG_SettlCurrency)
					return _dSettlCurrency;
				else if(iTag == TAG_Text)
					return _sText;
				else if(iTag == TAG_EncodedTextLen)
					return _iEncodedTextLen;
				else if(iTag == TAG_FutSettDate2)
					return _dtFutSettDate2;
				else if(iTag == TAG_OrderQty2)
					return _iOrderQty2;
				else if(iTag == TAG_OpenClose)
					return _cOpenClose;
				else if(iTag == TAG_CoveredOrUncovered)
					return _iCoveredOrUncovered;
				else if(iTag == TAG_CustomerOrFirm)
					return _iCustomerOrFirm;
				else if(iTag == TAG_MaxShow)
					return _iMaxShow;
				else if(iTag == TAG_LocateReqd)
					return _bLocateReqd;
				else if(iTag == TAG_ClearingFirm)
					return _sClearingFirm;
				else if(iTag == TAG_ClearingAccount)
					return _sClearingAccount;
				else
					return base[iTag];
			}
			set 
			{
				if(iTag == TAG_OrderID)
					_sOrderID = (string) value;
				else if(iTag == TAG_ClientID)
					_sClientID = (string) value;
				else if(iTag == TAG_ExecBroker)
					_sExecBroker = (string) value;
				else if(iTag == TAG_OrigClOrdID)
					_sOrigClOrdID = (string) value;
				else if(iTag == TAG_ClOrdID)
					_sClOrdID = (string) value;
				else if(iTag == TAG_ListID)
					_sListID = (string) value;
				else if(iTag == TAG_Account)
					_sAccount = (string) value;
				else if(iTag == TAG_NoAllocs)
					_iNoAllocs = (int) value;
				else if(iTag == TAG_SettlmntTyp)
					_cSettlmntTyp = (char) value;
				else if(iTag == TAG_FutSettDate)
					_dtFutSettDate = (DateTime) value;
				else if(iTag == TAG_HandlInst)
					_cHandlInst = (char) value;
				else if(iTag == TAG_ExecInst)
					_sExecInst = (string) value;
				else if(iTag == TAG_MinQty)
					_iMinQty = (int) value;
				else if(iTag == TAG_MaxFloor)
					_iMaxFloor = (int) value;
				else if(iTag == TAG_ExDestination)
					_sExDestination = (string) value;
				else if(iTag == TAG_NoTradingSessions)
					_iNoTradingSessions = (int) value;
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
				else if(iTag == TAG_TransactTime)
					_dtTransactTime = (DateTime) value;
				else if(iTag == TAG_OrderQty)
					_iOrderQty = (int) value;
				else if(iTag == TAG_CashOrderQty)
					_iCashOrderQty = (int) value;
				else if(iTag == TAG_OrdType)
					_cOrdType = (char) value;
				else if(iTag == TAG_Price)
					_dPrice = (double) value;
				else if(iTag == TAG_StopPx)
					_dStopPx = (double) value;
				else if(iTag == TAG_PegDifference)
					_dPegDifference = (double) value;
				else if(iTag == TAG_DiscretionInst)
					_cDiscretionInst = (char) value;
				else if(iTag == TAG_DiscretionOffset)
					_dDiscretionOffset = (double) value;
				else if(iTag == TAG_ComplianceID)
					_sComplianceID = (string) value;
				else if(iTag == TAG_SolicitedFlag)
					_bSolicitedFlag = (bool) value;
				else if(iTag == TAG_Currency)
					_dCurrency = (double) value;
				else if(iTag == TAG_TimeInForce)
					_cTimeInForce = (char) value;
				else if(iTag == TAG_EffectiveTime)
					_dtEffectiveTime = (DateTime) value;
				else if(iTag == TAG_ExpireDate)
					_dtExpireDate = (DateTime) value;
				else if(iTag == TAG_ExpireTime)
					_dtExpireTime = (DateTime) value;
				else if(iTag == TAG_GTBookingInst)
					_iGTBookingInst = (int) value;
				else if(iTag == TAG_Commission)
					_dCommission = (double) value;
				else if(iTag == TAG_CommType)
					_cCommType = (char) value;
				else if(iTag == TAG_Rule80A)
					_cRule80A = (char) value;
				else if(iTag == TAG_ForexReq)
					_bForexReq = (bool) value;
				else if(iTag == TAG_SettlCurrency)
					_dSettlCurrency = (double) value;
				else if(iTag == TAG_Text)
					_sText = (string) value;
				else if(iTag == TAG_EncodedTextLen)
					_iEncodedTextLen = (int) value;
				else if(iTag == TAG_FutSettDate2)
					_dtFutSettDate2 = (DateTime) value;
				else if(iTag == TAG_OrderQty2)
					_iOrderQty2 = (int) value;
				else if(iTag == TAG_OpenClose)
					_cOpenClose = (char) value;
				else if(iTag == TAG_CoveredOrUncovered)
					_iCoveredOrUncovered = (int) value;
				else if(iTag == TAG_CustomerOrFirm)
					_iCustomerOrFirm = (int) value;
				else if(iTag == TAG_MaxShow)
					_iMaxShow = (int) value;
				else if(iTag == TAG_LocateReqd)
					_bLocateReqd = (bool) value;
				else if(iTag == TAG_ClearingFirm)
					_sClearingFirm = (string) value;
				else if(iTag == TAG_ClearingAccount)
					_sClearingAccount = (string) value;
				else
					base[iTag] = value;
			}
		}
	}
}
