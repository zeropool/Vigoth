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
	/// The allocation ACK record is used by the broker to acknowledge the receipt 
	/// and status of an allocation record received from the institution.
	/// 
	/// It is possible that multiple Allocation ACK messages can be generated 
	/// for a single allocation to detail the receipt and then the acceptance or 
	/// rejection of the allocation.
	/// </summary>
	public class AllocationACK : Message
	{
		public const int TAG_ClientID = 109;
		public const int TAG_ExecBroker = 76;
		public const int TAG_AllocID = 70;
		public const int TAG_TradeDate = 75;
		public const int TAG_TransactTime = 60;
		public const int TAG_AllocStatus = 87;
		public const int TAG_AllocRejCode = 88;
		public const int TAG_Text = 58;

		private string _sClientID;
		private string _sExecBroker;
		private string _sAllocID;
		private DateTime _dtTradeDate;
		private DateTime _dtTransactTime;
		private int _iAllocStatus;
		private int _iAllocRejCode;
		private string _sText;

		internal AllocationACK()
			: base()
		{
			_sMsgType = Values.MsgType.AllocationACK;
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
		public string AllocID
		{
			get { return _sAllocID; }
			set { _sAllocID = value; }
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
		public int AllocStatus
		{
			get { return _iAllocStatus; }
			set { _iAllocStatus = value; }
		}
		public int AllocRejCode
		{
			get { return _iAllocRejCode; }
			set { _iAllocRejCode = value; }
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
				if (iTag == TAG_ClientID)
					return _sClientID;
				else if (iTag == TAG_ExecBroker)
					return _sExecBroker;
				else if (iTag == TAG_AllocID)
					return _sAllocID;
				else if (iTag == TAG_TradeDate)
					return _dtTradeDate;
				else if (iTag == TAG_TransactTime)
					return _dtTransactTime;
				else if (iTag == TAG_AllocStatus)
					return _iAllocStatus;
				else if (iTag == TAG_AllocRejCode)
					return _iAllocRejCode;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_ClientID)
					_sClientID = (string)value;
				else if (iTag == TAG_ExecBroker)
					_sExecBroker = (string)value;
				else if (iTag == TAG_AllocID)
					_sAllocID = (string)value;
				else if (iTag == TAG_TradeDate)
					_dtTradeDate = (DateTime)value;
				else if (iTag == TAG_TransactTime)
					_dtTransactTime = (DateTime)value;
				else if (iTag == TAG_AllocStatus)
					_iAllocStatus = (int)value;
				else if (iTag == TAG_AllocRejCode)
					_iAllocRejCode = (int)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}
	}
}
