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
	/// The execution report message is used to:
	/// 1.	confirm the receipt of an order 
	/// 2.	confirm changes to an existing order (i.e. accept cancel and replace requests)
	/// 3.	relay order status information
	/// 4.	relay fill information as orders are worked
	/// 5.	reject orders
	/// 6.	report miscellaneous fees calculations associated with a trade
	/// 
	/// NOTE:	Execution reports do not replace the end-of-day confirm.  Execution reports 
	/// are to be regarded only as replacements for the existing fill messages currently 
	/// communicated via telephone.
	/// 
	/// Each execution message will contain information that will describe the current state 
	/// of the order and execution status as understood by the broker.   
	/// 
	/// Execution report messages can be transmitted as transaction types (ExecTransType) 
	/// NEW, CANCEL, CORRECT or STATUS.  Transaction types CANCEL and CORRECT modify the 
	/// state of the message identified in field ExecRefID.  Transaction type STATUS 
	/// indicates that the execution message contains no new information, only summary 
	/// information regarding order status.
	/// *	The NEW transaction type indicates that this message represents a new order, 
	///		a change in status of the order, or a new fill against an existing order.  The 
	///		combination of the ExecTransType and OrdStatus fields will indicate how the 
	///		message is to be applied to an order.
	/// *	The CANCEL transaction type applies at the execution level.  The Cancel 
	///		transaction  will be used to cancel an execution which has been reported in 
	///		error.  The canceled execution will be identified in the ExecRefID field.
	/// *	The CORRECT transaction type applies at the execution level and is used to 
	///		modify an incorrectly reported fill.  The incorrect execution will be identified 
	///		in the ExecRefID field.  Note:  Data reported in the CumQty and AvgPx fields 
	///		represent the status of the order as of the time of the correction, not as 
	///		of the time of the originally reported execution.
	/// 
	/// The OrdStatus field is used to identify the status of the current order.  The 
	/// order statuses are as follows:
	///		New - Outstanding order with no executions 
	///		Partially Filled - Outstanding order with executions and remaining quantity
	///		Filled - Order completely filled, no remaining quantity
	///		Done for Day - Order not, or partially, filled;  no further executions forthcoming
	///		Canceled - Canceled order with or without executions
	///		Replaced - Replaced order with or without executions
	///		Pending Cancel/Replace - Order with cancel request pending, used to confirm receipt 
	///			of cancel or replace request.  DOES NOT INDICATE THAT THE ORDER HAS BEEN CANCELED OR REPLACED.
	///		Stopped - Order has been stopped at the exchange
	///		Rejected - Order has been rejected by broker.  NOTE:  An order can be rejected subsequent 
	///			to order acknowledgment, i.e. an order can pass from New to Rejected status.
	///		Suspended - Order has been placed in suspended state at the request of the client.
	///		Pending New - Order has been received by brokers system but not yet accepted for 
	///			execution.  An execution message with this status will only be sent in response 
	///			to a Status Request message.  
	///		Expired - Order has been canceled in broker's system due to time in force instructions.  
	///		Calculated - Order has been completed for the day (either filled or done for day).  Miscellaneous 
	///			fees have been calculated and reported in this execution message
	/// 
	/// NOTE:  The canceled and replaced order status is set in response to accepted cancel and 
	///		replace requests.  These requests are only acted upon when there is an outstanding 
	///		order quantity.  Requests to replace OrderQty to a level less than the CumQty 
	///		will be rejected (OrderQty = CumQty + LeavesQty).  Requests to change price on a filled 
	///		order will be rejected (see Order Cancel Reject message type).  
	/// 
	/// The CumQty and AvgPx fields should be calculated to reflect the fills on all versions 
	///	of an order.  For example, if partially filled order A were replaced by order B, the CumQty 
	/// and AvgPx on order B's fills should represent the fills on order A plus those on order B. 
	/// 
	/// The field ClOrdID is provided for institutions to affix an identification number to an 
	/// order to coincide with internal systems.  The OrderId field is populated with the 
	/// broker-generated order number.
	/// </summary>
	public class ExecutionReport : Message
	{
		public const int TAG_OrderID = 37;
		public const int TAG_ClOrdID = 11;
		public const int TAG_ClientID = 109;
		public const int TAG_ExecBroker = 76;
		public const int TAG_ListID = 66;
		public const int TAG_ExecID = 17;
		public const int TAG_ExecTransType = 20;
		public const int TAG_ExecRefID = 19;
		public const int TAG_OrdStatus = 39;
		public const int TAG_OrdRejReason = 103;
		public const int TAG_Account = 1;
		public const int TAG_SettlmntTyp = 63;
		public const int TAG_FutSettDate = 64;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_Issuer = 106;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_Side = 54;
		public const int TAG_OrderQty = 38;
		public const int TAG_OrdType = 40;
		public const int TAG_Price = 44;
		public const int TAG_StopPx = 99;
		public const int TAG_Currency = 15;
		public const int TAG_TimeInForce = 59;
		public const int TAG_ExpireTime = 126;
		public const int TAG_ExecInst = 18;
		public const int TAG_Rule80A = 47;
		public const int TAG_LastShares = 32;
		public const int TAG_LastPx = 31;
		public const int TAG_LastMkt = 30;
		public const int TAG_LastCapacity = 29;
		public const int TAG_CumQty = 14;
		public const int TAG_AvgPx = 6;
		public const int TAG_TradeDate = 75;
		public const int TAG_TransactTime = 60;
		public const int TAG_ReportToExch = 113;
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_NoMiscFees = 136;
		public const int TAG_MiscFeeAmt = 137;
		public const int TAG_MiscFeeCurr = 138;
		public const int TAG_MiscFeeType = 139;
		public const int TAG_NetMoney = 118;
		public const int TAG_SettlCurrAmt = 119;
		public const int TAG_SettlCurrency = 120;
		public const int TAG_Text = 58;

		private string _sOrderID;
		private string _sClOrdID;
		private string _sClientID;
		private string _sExecBroker;
		private string _sListID;
		private string _sExecID;
		private char _cExecTransType;
		private string _sExecRefID;
		private char _cOrdStatus;
		private int _iOrdRejReason;
		private string _sAccount;
		private char _cSettlmntTyp;
		private DateTime _dtFutSettDate;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sIssuer;
		private string _sSecurityDesc;
		private char _cSide;
		private int _iOrderQty;
		private char _cOrdType;
		private double _dPrice;
		private double _dStopPx;
		private double _dCurrency;
		private char _cTimeInForce;
		private DateTime _dtExpireTime;
		private string _sExecInst;
		private char _cRule80A;
		private int _iLastShares;
		private double _dLastPx;
		private string _sLastMkt;
		private char _cLastCapacity;
		private int _iCumQty;
		private double _dAvgPx;
		private DateTime _dtTradeDate;
		private DateTime _dtTransactTime;
		private bool _bReportToExch;
		private double _dCommission;
		private char _cCommType;
		private int _iNoMiscFees;
		private double _dMiscFeeAmt;
		private double _dMiscFeeCurr;
		private char _cMiscFeeType;
		private double _dNetMoney;
		private double _dSettlCurrAmt;
		private double _dSettlCurrency;
		private string _sText;

		internal ExecutionReport()
			: base()
		{
			_sMsgType = Values.MsgType.ExecutionReport;
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
		public string ExecBroker
		{
			get { return _sExecBroker; }
			set { _sExecBroker = value; }
		}
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public string ExecID
		{
			get { return _sExecID; }
			set { _sExecID = value; }
		}
		public char ExecTransType
		{
			get { return _cExecTransType; }
			set { _cExecTransType = value; }
		}
		public string ExecRefID
		{
			get { return _sExecRefID; }
			set { _sExecRefID = value; }
		}
		public char OrdStatus
		{
			get { return _cOrdStatus; }
			set { _cOrdStatus = value; }
		}
		public int OrdRejReason
		{
			get { return _iOrdRejReason; }
			set { _iOrdRejReason = value; }
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
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
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
		public string ExecInst
		{
			get { return _sExecInst; }
			set { _sExecInst = value; }
		}
		public char Rule80A
		{
			get { return _cRule80A; }
			set { _cRule80A = value; }
		}
		public int LastShares
		{
			get { return _iLastShares; }
			set { _iLastShares = value; }
		}
		public double LastPx
		{
			get { return _dLastPx; }
			set { _dLastPx = value; }
		}
		public string LastMkt
		{
			get { return _sLastMkt; }
			set { _sLastMkt = value; }
		}
		public char LastCapacity
		{
			get { return _cLastCapacity; }
			set { _cLastCapacity = value; }
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
		public int NoMiscFees
		{
			get { return _iNoMiscFees; }
			set { _iNoMiscFees = value; }
		}
		public double MiscFeeAmt
		{
			get { return _dMiscFeeAmt; }
			set { _dMiscFeeAmt = value; }
		}
		public double MiscFeeCurr
		{
			get { return _dMiscFeeCurr; }
			set { _dMiscFeeCurr = value; }
		}
		public char MiscFeeType
		{
			get { return _cMiscFeeType; }
			set { _cMiscFeeType = value; }
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
				if (iTag == TAG_OrderID)
					return _sOrderID;
				else if (iTag == TAG_ClOrdID)
					return _sClOrdID;
				else if (iTag == TAG_ClientID)
					return _sClientID;
				else if (iTag == TAG_ExecBroker)
					return _sExecBroker;
				else if (iTag == TAG_ListID)
					return _sListID;
				else if (iTag == TAG_ExecID)
					return _sExecID;
				else if (iTag == TAG_ExecTransType)
					return _cExecTransType;
				else if (iTag == TAG_ExecRefID)
					return _sExecRefID;
				else if (iTag == TAG_OrdStatus)
					return _cOrdStatus;
				else if (iTag == TAG_OrdRejReason)
					return _iOrdRejReason;
				else if (iTag == TAG_Account)
					return _sAccount;
				else if (iTag == TAG_SettlmntTyp)
					return _cSettlmntTyp;
				else if (iTag == TAG_FutSettDate)
					return _dtFutSettDate;
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
				else if (iTag == TAG_Side)
					return _cSide;
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
				else if (iTag == TAG_TimeInForce)
					return _cTimeInForce;
				else if (iTag == TAG_ExpireTime)
					return _dtExpireTime;
				else if (iTag == TAG_ExecInst)
					return _sExecInst;
				else if (iTag == TAG_Rule80A)
					return _cRule80A;
				else if (iTag == TAG_LastShares)
					return _iLastShares;
				else if (iTag == TAG_LastPx)
					return _dLastPx;
				else if (iTag == TAG_LastMkt)
					return _sLastMkt;
				else if (iTag == TAG_LastCapacity)
					return _cLastCapacity;
				else if (iTag == TAG_CumQty)
					return _iCumQty;
				else if (iTag == TAG_AvgPx)
					return _dAvgPx;
				else if (iTag == TAG_TradeDate)
					return _dtTradeDate;
				else if (iTag == TAG_TransactTime)
					return _dtTransactTime;
				else if (iTag == TAG_ReportToExch)
					return _bReportToExch;
				else if (iTag == TAG_Commission)
					return _dCommission;
				else if (iTag == TAG_CommType)
					return _cCommType;
				else if (iTag == TAG_NoMiscFees)
					return _iNoMiscFees;
				else if (iTag == TAG_MiscFeeAmt)
					return _dMiscFeeAmt;
				else if (iTag == TAG_MiscFeeCurr)
					return _dMiscFeeCurr;
				else if (iTag == TAG_MiscFeeType)
					return _cMiscFeeType;
				else if (iTag == TAG_NetMoney)
					return _dNetMoney;
				else if (iTag == TAG_SettlCurrAmt)
					return _dSettlCurrAmt;
				else if (iTag == TAG_SettlCurrency)
					return _dSettlCurrency;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_OrderID)
					_sOrderID = (string)value;
				else if (iTag == TAG_ClOrdID)
					_sClOrdID = (string)value;
				else if (iTag == TAG_ClientID)
					_sClientID = (string)value;
				else if (iTag == TAG_ExecBroker)
					_sExecBroker = (string)value;
				else if (iTag == TAG_ListID)
					_sListID = (string)value;
				else if (iTag == TAG_ExecID)
					_sExecID = (string)value;
				else if (iTag == TAG_ExecTransType)
					_cExecTransType = (char)value;
				else if (iTag == TAG_ExecRefID)
					_sExecRefID = (string)value;
				else if (iTag == TAG_OrdStatus)
					_cOrdStatus = (char)value;
				else if (iTag == TAG_OrdRejReason)
					_iOrdRejReason = (int)value;
				else if (iTag == TAG_Account)
					_sAccount = (string)value;
				else if (iTag == TAG_SettlmntTyp)
					_cSettlmntTyp = (char)value;
				else if (iTag == TAG_FutSettDate)
					_dtFutSettDate = (DateTime)value;
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
				else if (iTag == TAG_Side)
					_cSide = (char)value;
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
				else if (iTag == TAG_TimeInForce)
					_cTimeInForce = (char)value;
				else if (iTag == TAG_ExpireTime)
					_dtExpireTime = (DateTime)value;
				else if (iTag == TAG_ExecInst)
					_sExecInst = (string)value;
				else if (iTag == TAG_Rule80A)
					_cRule80A = (char)value;
				else if (iTag == TAG_LastShares)
					_iLastShares = (int)value;
				else if (iTag == TAG_LastPx)
					_dLastPx = (double)value;
				else if (iTag == TAG_LastMkt)
					_sLastMkt = (string)value;
				else if (iTag == TAG_LastCapacity)
					_cLastCapacity = (char)value;
				else if (iTag == TAG_CumQty)
					_iCumQty = (int)value;
				else if (iTag == TAG_AvgPx)
					_dAvgPx = (double)value;
				else if (iTag == TAG_TradeDate)
					_dtTradeDate = (DateTime)value;
				else if (iTag == TAG_TransactTime)
					_dtTransactTime = (DateTime)value;
				else if (iTag == TAG_ReportToExch)
					_bReportToExch = (bool)value;
				else if (iTag == TAG_Commission)
					_dCommission = (double)value;
				else if (iTag == TAG_CommType)
					_cCommType = (char)value;
				else if (iTag == TAG_NoMiscFees)
					_iNoMiscFees = (int)value;
				else if (iTag == TAG_MiscFeeAmt)
					_dMiscFeeAmt = (double)value;
				else if (iTag == TAG_MiscFeeCurr)
					_dMiscFeeCurr = (double)value;
				else if (iTag == TAG_MiscFeeType)
					_cMiscFeeType = (char)value;
				else if (iTag == TAG_NetMoney)
					_dNetMoney = (double)value;
				else if (iTag == TAG_SettlCurrAmt)
					_dSettlCurrAmt = (double)value;
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
