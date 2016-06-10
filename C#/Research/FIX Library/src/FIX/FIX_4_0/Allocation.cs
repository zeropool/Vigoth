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

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_0
{
	/// <summary>
	/// The allocation record is used to instruct a broker on how to allocate 
	/// executed shares to sub-accounts.  The allocation record can also be 
	/// used as a confirmation message through which third parties can communicate 
	/// execution and settlement instructions between trading partners.
	/// 
	/// An allocation message can be submitted as new, cancel or replace.  The 
	/// AllocTransType field indicates the purpose of the message.  When submitting 
	/// replace or cancel AllocTransType messages the RefAllocID field is required.  
	/// Replacement allocation messages must contain all data for the replacement 
	/// allocation.
	/// 
	/// The allocation record contains repeating fields for each order, sub-account 
	/// and individual execution; the repeating fields are shown below in typeface 
	/// Bold-Italic.  The relative position of the repeating fields is important 
	/// in this record,  i.e. each instance of allocation must be in the order 
	/// shown below.
	/// 
	/// *	The total shares allocated must equal the Shares value which must 
	///		equal the total executed quantity of the original order.  If present, 
	///		the total shares in the execution section must also be equal to 
	///		this value.
	/// *	The number of sub-account instances is indicated in NoAllocs.
	/// *	Multiple orders can be combined for allocation by identifying the number 
	///		of orders in the NoOrders field and each individual order in the OrderID 
	///		fields.  Combined orders must have the same ticker, trade date, settlement 
	///		date and side.
	/// </summary>
	public class Allocation : Message
	{
		public const int TAG_AllocID = 70;
		public const int TAG_AllocTransType = 71;
		public const int TAG_RefAllocID = 72;
		public const int TAG_NoOrders = 73;
		public const int TAG_ClOrdID = 11;
		public const int TAG_OrderID = 37;
		public const int TAG_ListID = 66;
		public const int TAG_WaveNo = 105;
		public const int TAG_NoExecs = 124;
		public const int TAG_ExecID = 17;
		public const int TAG_LastShares = 32;
		public const int TAG_LastPx = 31;
		public const int TAG_LastMkt = 30;
		public const int TAG_Side = 54;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_Issuer = 106;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_Shares = 53;
		public const int TAG_AvgPx = 6;
		public const int TAG_Currency = 15;
		public const int TAG_AvgPrxPrecision = 74;
		public const int TAG_TradeDate = 75;
		public const int TAG_TransactTime = 60;
		public const int TAG_SettlmntTyp = 63;
		public const int TAG_FutSettDate = 64;
		public const int TAG_NetMoney = 118;
		public const int TAG_NoMiscFees = 136;
		public const int TAG_MiscFeeAmt = 137;
		public const int TAG_MiscFeeCurr = 138;
		public const int TAG_MiscFeeType = 139;
		public const int TAG_SettlCurrAmt = 119;
		public const int TAG_SettlCurrency = 120;
		public const int TAG_OpenClose = 77;
		public const int TAG_Text = 58;
		public const int TAG_NoAllocs = 78;
		public const int TAG_AllocAccount = 79;
		public const int TAG_AllocShares = 80;
		public const int TAG_ProcessCode = 81;
		public const int TAG_ExecBroker = 76;
		public const int TAG_ClientID = 109;
		public const int TAG_Commission = 12;
		public const int TAG_CommType = 13;
		public const int TAG_NoDlvyInst = 85;
		public const int TAG_BrokerOfCredit = 92;
		public const int TAG_DlvyInst = 86;

		private string _sAllocID;
		private char _cAllocTransType;
		private string _sRefAllocID;
		private int _iNoOrders;
		private AllocationOrderList _allocationOrderList;
		private int _iNoExecs;
		private AllocationExecList _allocationExecList;
		private char _cSide;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sIssuer;
		private string _sSecurityDesc;
		private int _iShares;
		private double _dAvgPx;
		private double _dCurrency;
		private int _iAvgPrxPrecision;
		private DateTime _dtTradeDate;
		private DateTime _dtTransactTime;
		private char _cSettlmntTyp;
		private DateTime _dtFutSettDate;
		private double _dNetMoney;
		private int _iNoMiscFees;
		private AllocationMiscFeeList _allocationMiscFeeList;
		private double _dSettlCurrAmt;
		private double _dSettlCurrency;
		private char _cOpenClose;
		private string _sText;
		private int _iNoAllocs;
		private AllocationAllocList _allocationAllocList;

		internal Allocation()
			: base()
		{
			_sMsgType = Values.MsgType.Allocation;
			_allocationOrderList = new AllocationOrderList();
			_allocationExecList = new AllocationExecList();
			_allocationMiscFeeList = new AllocationMiscFeeList();
			_allocationAllocList = new AllocationAllocList();
		}

		public string AllocID
		{
			get { return _sAllocID; }
			set { _sAllocID = value; }
		}
		public char AllocTransType
		{
			get { return _cAllocTransType; }
			set { _cAllocTransType = value; }
		}
		public string RefAllocID
		{
			get { return _sRefAllocID; }
			set { _sRefAllocID = value; }
		}
		public int NoOrders
		{
			get { return _iNoOrders; }
			set { _iNoOrders = value; }
		}
		public AllocationOrderList Order
		{
			get { return _allocationOrderList; }
		}
		public int NoExecs
		{
			get { return _iNoExecs; }
			set { _iNoExecs = value; }
		}
		public AllocationExecList Exec
		{
			get { return _allocationExecList; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
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
		public int Shares
		{
			get { return _iShares; }
			set { _iShares = value; }
		}
		public double AvgPx
		{
			get { return _dAvgPx; }
			set { _dAvgPx = value; }
		}
		public double Currency
		{
			get { return _dCurrency; }
			set { _dCurrency = value; }
		}
		public int AvgPrxPrecision
		{
			get { return _iAvgPrxPrecision; }
			set { _iAvgPrxPrecision = value; }
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
		public double NetMoney
		{
			get { return _dNetMoney; }
			set { _dNetMoney = value; }
		}
		public int NoMiscFees
		{
			get { return _iNoMiscFees; }
			set { _iNoMiscFees = value; }
		}
		public AllocationMiscFeeList MiscFee
		{
			get { return _allocationMiscFeeList; }
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
		public char OpenClose
		{
			get { return _cOpenClose; }
			set { _cOpenClose = value; }
		}
		public string Text
		{
			get { return _sText; }
			set { _sText = value; }
		}
		public int NoAllocs
		{
			get { return _iNoAllocs; }
			set { _iNoAllocs = value; }
		}
		public AllocationAllocList Alloc
		{
			get { return _allocationAllocList; }
		}

		public override object this[int iTag]
		{
			get
			{
				if (iTag == TAG_AllocID)
					return _sAllocID;
				else if (iTag == TAG_AllocTransType)
					return _cAllocTransType;
				else if (iTag == TAG_RefAllocID)
					return _sRefAllocID;
				else if (iTag == TAG_NoOrders)
					return _iNoOrders;
				else if (iTag == TAG_NoExecs)
					return _iNoExecs;
				else if (iTag == TAG_Side)
					return _cSide;
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
				else if (iTag == TAG_Shares)
					return _iShares;
				else if (iTag == TAG_AvgPx)
					return _dAvgPx;
				else if (iTag == TAG_Currency)
					return _dCurrency;
				else if (iTag == TAG_AvgPrxPrecision)
					return _iAvgPrxPrecision;
				else if (iTag == TAG_TradeDate)
					return _dtTradeDate;
				else if (iTag == TAG_TransactTime)
					return _dtTransactTime;
				else if (iTag == TAG_SettlmntTyp)
					return _cSettlmntTyp;
				else if (iTag == TAG_FutSettDate)
					return _dtFutSettDate;
				else if (iTag == TAG_NetMoney)
					return _dNetMoney;
				else if (iTag == TAG_NoMiscFees)
					return _iNoMiscFees;
				else if (iTag == TAG_SettlCurrAmt)
					return _dSettlCurrAmt;
				else if (iTag == TAG_SettlCurrency)
					return _dSettlCurrency;
				else if (iTag == TAG_OpenClose)
					return _cOpenClose;
				else if (iTag == TAG_Text)
					return _sText;
				else if (iTag == TAG_NoAllocs)
					return _iNoAllocs;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_AllocID)
					_sAllocID = (string)value;
				else if (iTag == TAG_AllocTransType)
					_cAllocTransType = (char)value;
				else if (iTag == TAG_RefAllocID)
					_sRefAllocID = (string)value;
				else if (iTag == TAG_NoOrders)
					_iNoOrders = (int)value;
				else if (iTag == TAG_NoExecs)
					_iNoExecs = (int)value;
				else if (iTag == TAG_Side)
					_cSide = (char)value;
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
				else if (iTag == TAG_Shares)
					_iShares = (int)value;
				else if (iTag == TAG_AvgPx)
					_dAvgPx = (double)value;
				else if (iTag == TAG_Currency)
					_dCurrency = (double)value;
				else if (iTag == TAG_AvgPrxPrecision)
					_iAvgPrxPrecision = (int)value;
				else if (iTag == TAG_TradeDate)
					_dtTradeDate = (DateTime)value;
				else if (iTag == TAG_TransactTime)
					_dtTransactTime = (DateTime)value;
				else if (iTag == TAG_SettlmntTyp)
					_cSettlmntTyp = (char)value;
				else if (iTag == TAG_FutSettDate)
					_dtFutSettDate = (DateTime)value;
				else if (iTag == TAG_NetMoney)
					_dNetMoney = (double)value;
				else if (iTag == TAG_NoMiscFees)
					_iNoMiscFees = (int)value;
				else if (iTag == TAG_SettlCurrAmt)
					_dSettlCurrAmt = (double)value;
				else if (iTag == TAG_SettlCurrency)
					_dSettlCurrency = (double)value;
				else if (iTag == TAG_OpenClose)
					_cOpenClose = (char)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else if (iTag == TAG_NoAllocs)
					_iNoAllocs = (int)value;
				else
					base[iTag] = value;
			}
		}
	}

	public class AllocationOrder
	{
		private string _sClOrdID;
		private string _sOrderID;
		private string _sListID;
		private string _sWaveNo;

		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public string OrderID
		{
			get { return _sOrderID; }
			set { _sOrderID = value; }
		}
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public string WaveNo
		{
			get { return _sWaveNo; }
			set { _sWaveNo = value; }
		}

		public object this[int iTag]
		{
			get
			{
				if (iTag == Allocation.TAG_ClOrdID)
					return _sClOrdID;
				else if (iTag == Allocation.TAG_OrderID)
					return _sOrderID;
				else if (iTag == Allocation.TAG_ListID)
					return _sListID;
				else if (iTag == Allocation.TAG_WaveNo)
					return _sWaveNo;
				else
					throw new Exception("Unkown field");
			}
			set
			{
				if (iTag == Allocation.TAG_ClOrdID)
					_sClOrdID = (string)value;
				else if (iTag == Allocation.TAG_OrderID)
					_sOrderID = (string)value;
				else if (iTag == Allocation.TAG_ListID)
					_sListID = (string)value;
				else if (iTag == Allocation.TAG_WaveNo)
					_sWaveNo = (string)value;
				else
					throw new Exception("Unkown field");
			}
		}
	}

	public class AllocationOrderList : RepeatingGroup
	{
		public AllocationOrder this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationOrder)_al[i];
				else
					return null;
			}
		}

		public void Add(AllocationOrder item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
		}

		public void Remove(AllocationOrder item)
		{
			if (_al != null)
				_al.Remove(item);
		}
	}

	public class AllocationExec
	{
		private string _sExecID;
		private int _iLastShares;
		private double _dLastPx;
		private string _sLastMkt;

		public string ExecID
		{
			get { return _sExecID; }
			set { _sExecID = value; }
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

		public object this[int iTag]
		{
			get
			{
				if (iTag == Allocation.TAG_ExecID)
					return _sExecID;
				else if (iTag == Allocation.TAG_LastShares)
					return _iLastShares;
				else if (iTag == Allocation.TAG_LastPx)
					return _dLastPx;
				else if (iTag == Allocation.TAG_LastMkt)
					return _sLastMkt;
				else
					throw new Exception("Unkown field");
			}
			set
			{
				if (iTag == Allocation.TAG_ExecID)
					_sExecID = (string)value;
				else if (iTag == Allocation.TAG_LastShares)
					_iLastShares = (int)value;
				else if (iTag == Allocation.TAG_LastPx)
					_dLastPx = (double)value;
				else if (iTag == Allocation.TAG_LastMkt)
					_sLastMkt = (string)value;
				else
					throw new Exception("Unkown field");
			}
		}
	}

	public class AllocationExecList : RepeatingGroup
	{
		public AllocationExec this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationExec)_al[i];
				else
					return null;
			}
		}

		public void Add(AllocationExec item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
		}

		public void Remove(AllocationExec item)
		{
			if (_al != null)
				_al.Remove(item);
		}
	}

	public class AllocationMiscFee
	{
		private double _dMiscFeeAmt;
		private double _dMiscFeeCurr;
		private char _cMiscFeeType;

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

		public object this[int iTag]
		{
			get
			{
				if (iTag == Allocation.TAG_MiscFeeAmt)
					return _dMiscFeeAmt;
				else if (iTag == Allocation.TAG_MiscFeeCurr)
					return _dMiscFeeCurr;
				else if (iTag == Allocation.TAG_MiscFeeType)
					return _cMiscFeeType;
				else
					throw new Exception("Unkown field");
			}
			set
			{
				if (iTag == Allocation.TAG_MiscFeeAmt)
					_dMiscFeeAmt = (double)value;
				else if (iTag == Allocation.TAG_MiscFeeCurr)
					_dMiscFeeCurr = (double)value;
				else if (iTag == Allocation.TAG_MiscFeeType)
					_cMiscFeeType = (char)value;
				else
					throw new Exception("Unkown field");
			}
		}
	}

	public class AllocationMiscFeeList : RepeatingGroup
	{
		public AllocationMiscFee this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationMiscFee)_al[i];
				else
					return null;
			}
		}

		public void Add(AllocationMiscFee item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
		}

		public void Remove(AllocationMiscFee item)
		{
			if (_al != null)
				_al.Remove(item);
		}
	}

	public class AllocationAlloc
	{
		private string _sAllocAccount;
		private int _iAllocShares;
		private char _cProcessCode;
		private string _sExecBroker;
		private string _sClientID;
		private double _dCommission;
		private char _cCommType;
		private int _iNoDlvyInst;
		private AllocationAllocDlvyInstList _allocationAllocDlvyInstList;

		public AllocationAlloc()
		{
			_allocationAllocDlvyInstList = new AllocationAllocDlvyInstList();
		}

		public string AllocAccount
		{
			get { return _sAllocAccount; }
			set { _sAllocAccount = value; }
		}
		public int AllocShares
		{
			get { return _iAllocShares; }
			set { _iAllocShares = value; }
		}
		public char ProcessCode
		{
			get { return _cProcessCode; }
			set { _cProcessCode = value; }
		}
		public string ExecBroker
		{
			get { return _sExecBroker; }
			set { _sExecBroker = value; }
		}
		public string ClientID
		{
			get { return _sClientID; }
			set { _sClientID = value; }
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
		public int NoDlvyInst
		{
			get { return _iNoDlvyInst; }
			set { _iNoDlvyInst = value; }
		}
		public AllocationAllocDlvyInstList DlvyInst
		{
			get { return _allocationAllocDlvyInstList; }
		}

		public object this[int iTag]
		{
			get
			{
				if (iTag == Allocation.TAG_AllocAccount)
					return _sAllocAccount;
				else if (iTag == Allocation.TAG_AllocShares)
					return _iAllocShares;
				else if (iTag == Allocation.TAG_ProcessCode)
					return _cProcessCode;
				else if (iTag == Allocation.TAG_ExecBroker)
					return _sExecBroker;
				else if (iTag == Allocation.TAG_ClientID)
					return _sClientID;
				else if (iTag == Allocation.TAG_Commission)
					return _dCommission;
				else if (iTag == Allocation.TAG_CommType)
					return _cCommType;
				else if (iTag == Allocation.TAG_NoDlvyInst)
					return _iNoDlvyInst;
				else
					throw new Exception("Unkown field");
			}
			set
			{
				if (iTag == Allocation.TAG_AllocAccount)
					_sAllocAccount = (string)value;
				else if (iTag == Allocation.TAG_AllocShares)
					_iAllocShares = (int)value;
				else if (iTag == Allocation.TAG_ProcessCode)
					_cProcessCode = (char)value;
				else if (iTag == Allocation.TAG_ExecBroker)
					_sExecBroker = (string)value;
				else if (iTag == Allocation.TAG_ClientID)
					_sClientID = (string)value;
				else if (iTag == Allocation.TAG_Commission)
					_dCommission = (double)value;
				else if (iTag == Allocation.TAG_CommType)
					_cCommType = (char)value;
				else if (iTag == Allocation.TAG_NoDlvyInst)
					_iNoDlvyInst = (int)value;
				else
					throw new Exception("Unkown field");
			}
		}
	}

	public class AllocationAllocList : RepeatingGroup
	{
		public AllocationAlloc this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationAlloc)_al[i];
				else
					return null;
			}
		}

		public void Add(AllocationAlloc item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
		}

		public void Remove(AllocationAlloc item)
		{
			if (_al != null)
				_al.Remove(item);
		}
	}

	public class AllocationAllocDlvyInst
	{
		private string _sBrokerOfCredit;
		private string _sDlvyInst;

		public string BrokerOfCredit
		{
			get { return _sBrokerOfCredit; }
			set { _sBrokerOfCredit = value; }
		}
		public string DlvyInst
		{
			get { return _sDlvyInst; }
			set { _sDlvyInst = value; }
		}

		public object this[int iTag]
		{
			get
			{
				if (iTag == Allocation.TAG_BrokerOfCredit)
					return _sBrokerOfCredit;
				else if (iTag == Allocation.TAG_DlvyInst)
					return _sDlvyInst;
				else
					throw new Exception("Unkown field");
			}
			set
			{
				if (iTag == Allocation.TAG_BrokerOfCredit)
					_sBrokerOfCredit = (string)value;
				else if (iTag == Allocation.TAG_DlvyInst)
					_sDlvyInst = (string)value;
				else
					throw new Exception("Unkown field");
			}
		}
	}

	public class AllocationAllocDlvyInstList : RepeatingGroup
	{
		public AllocationAllocDlvyInst this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationAllocDlvyInst)_al[i];
				else
					return null;
			}
		}

		public void Add(AllocationAllocDlvyInst item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
		}

		public void Remove(AllocationAllocDlvyInst item)
		{
			if (_al != null)
				_al.Remove(item);
		}
	}
}
