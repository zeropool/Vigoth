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
	/// The list status message is issued as the response to a List 
	/// Status Request message and indicates the current state of the 
	/// orders within the list as they exists at the broker's site.
	/// 
	/// Orders within the list are statused at the summary level.  Individual 
	/// executions are not reported, rather, the current state of the 
	/// order is reported.
	/// 
	/// The message contains repeating fields for each order.  The 
	/// relative position of the repeating fields is important in this 
	/// record,  i.e. each instance of ClOrdID, CumQty, CxlQty and AvgPx 
	/// must be in the order shown below.
	/// 
	/// Each list status message will report on only a maximum of 50 
	/// orders; if the list contains more than 50 orders multiple 
	/// status messages will be required.
	/// </summary>
	public class ListStatus : Message
	{
		public const int TAG_ListID = 66;
		public const int TAG_WaveNo = 105;
		public const int TAG_NoRpts = 82;
		public const int TAG_RptSeq = 83;
		public const int TAG_NoOrders = 73;
		public const int TAG_ClOrdID = 11;
		public const int TAG_CumQty = 14;
		public const int TAG_CxlQty = 84;
		public const int TAG_AvgPx = 6;

		private string _sListID;
		private string _sWaveNo;
		private int _iNoRpts;
		private int _iRptSeq;
		private int _iNoOrders;
		private ListStatusOrderList _listStatusOrderList;

		internal ListStatus()
			: base()
		{
			_sMsgType = Values.MsgType.ListStatus;
			_listStatusOrderList = new ListStatusOrderList();
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
		public int NoRpts
		{
			get { return _iNoRpts; }
			set { _iNoRpts = value; }
		}
		public int RptSeq
		{
			get { return _iRptSeq; }
			set { _iRptSeq = value; }
		}
		public int NoOrders
		{
			get { return _iNoOrders; }
			set { _iNoOrders = value; }
		}
		public ListStatusOrderList Order {
			get { return _listStatusOrderList; }
		}

		public override object this[int iTag]
		{
			get
			{
				if (iTag == TAG_ListID)
					return _sListID;
				else if (iTag == TAG_WaveNo)
					return _sWaveNo;
				else if (iTag == TAG_NoRpts)
					return _iNoRpts;
				else if (iTag == TAG_RptSeq)
					return _iRptSeq;
				else if (iTag == TAG_NoOrders)
					return _iNoOrders;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_ListID)
					_sListID = (string)value;
				else if (iTag == TAG_WaveNo)
					_sWaveNo = (string)value;
				else if (iTag == TAG_NoRpts)
					_iNoRpts = (int)value;
				else if (iTag == TAG_RptSeq)
					_iRptSeq = (int)value;
				else if (iTag == TAG_NoOrders)
					_iNoOrders = (int)value;
				else
					base[iTag] = value;
			}
		}
	}

	public class ListStatusOrder
	{
		private string _sClOrdID;
		private int _iCumQty;
		private int _iCxlQty;
		private double _dAvgPx;

		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public int CumQty
		{
			get { return _iCumQty; }
			set { _iCumQty = value; }
		}
		public int CxlQty
		{
			get { return _iCxlQty; }
			set { _iCxlQty = value; }
		}
		public double AvgPx
		{
			get { return _dAvgPx; }
			set { _dAvgPx = value; }
		}

		public object this[int iTag]
		{
			get
			{
				if (iTag == ListStatus.TAG_ClOrdID)
					return _sClOrdID;
				else if (iTag == ListStatus.TAG_CumQty)
					return _iCumQty;
				else if (iTag == ListStatus.TAG_CxlQty)
					return _iCxlQty;
				else if (iTag == ListStatus.TAG_AvgPx)
					return _dAvgPx;
				else 
					throw new Exception("Unkown field");
			}
			set
			{
				if (iTag == ListStatus.TAG_ClOrdID)
					_sClOrdID = (string)value;
				else if (iTag == ListStatus.TAG_CumQty)
					_iCumQty = (int)value;
				else if (iTag == ListStatus.TAG_CxlQty)
					_iCxlQty = (int)value;
				else if (iTag == ListStatus.TAG_AvgPx)
					_dAvgPx = (double)value;
				else 
					throw new Exception("Unkown field");
			}
		}
	}

	public class ListStatusOrderList : RepeatingGroup
	{
		public ListStatusOrder this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ListStatusOrder)_al[i];
				else
					return null;
			}
		}

		public void Add(ListStatusOrder item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
		}

		public void Remove(ListStatusOrder item)
		{
			if (_al != null)
				_al.Remove(item);
		}
	}
}
