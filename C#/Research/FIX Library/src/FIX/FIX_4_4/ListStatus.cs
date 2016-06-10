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
	/// Summary description for ListStatus.
	/// </summary>
	public class ListStatus : Message
	{
		public const int TAG_ListID = 66;
		public const int TAG_ListStatusType = 429;
		public const int TAG_NoRpts = 82;
		public const int TAG_ListOrderStatus = 431;
		public const int TAG_RptSeq = 83;
		public const int TAG_ListStatusText = 444;
		public const int TAG_EncodedListStatusTextLen = 445;
		public const int TAG_EncodedListStatusText = 446;
		public const int TAG_TransactTime = 60;
		public const int TAG_TotNoOrders = 68;
		public const int TAG_LastFragment = 893;
		public const int TAG_NoOrders = 73;
		public const int TAG_ClOrdID = 11;
		public const int TAG_SecondaryClOrdID = 526;
		public const int TAG_CumQty = 14;
		public const int TAG_OrdStatus = 39;
		public const int TAG_WorkingIndicator = 636;
		public const int TAG_LeavesQty = 151;
		public const int TAG_CxlQty = 84;
		public const int TAG_AvgPx = 6;
		public const int TAG_OrdRejReason = 103;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sListID;
		private int _iListStatusType;
		private int _iNoRpts;
		private int _iListOrderStatus;
		private int _iRptSeq;
		private string _sListStatusText;
		private int _iEncodedListStatusTextLen;
		private string _sEncodedListStatusText;
		private DateTime _dtTransactTime;
		private int _iTotNoOrders;
		private bool _bLastFragment;
		private int _iNoOrders;
		private ListStatusOrderList _listOrder = new ListStatusOrderList();

		public ListStatus() : base()
		{
			_sMsgType = Values.MsgType.ListStatus;
		}

		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public int ListStatusType
		{
			get { return _iListStatusType; }
			set { _iListStatusType = value; }
		}
		public int NoRpts
		{
			get { return _iNoRpts; }
			set { _iNoRpts = value; }
		}
		public int ListOrderStatus
		{
			get { return _iListOrderStatus; }
			set { _iListOrderStatus = value; }
		}
		public int RptSeq
		{
			get { return _iRptSeq; }
			set { _iRptSeq = value; }
		}
		public string ListStatusText
		{
			get { return _sListStatusText; }
			set { _sListStatusText = value; }
		}
		public int EncodedListStatusTextLen
		{
			get { return _iEncodedListStatusTextLen; }
			set { _iEncodedListStatusTextLen = value; }
		}
		public string EncodedListStatusText
		{
			get { return _sEncodedListStatusText; }
			set { _sEncodedListStatusText = value; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public int TotNoOrders
		{
			get { return _iTotNoOrders; }
			set { _iTotNoOrders = value; }
		}
		public bool LastFragment
		{
			get { return _bLastFragment; }
			set { _bLastFragment = value; }
		}
		public int NoOrders
		{
			get { return _iNoOrders; }
			set { _iNoOrders = value; }
		}
		public ListStatusOrderList Order 
		{
			get { return _listOrder; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_ListID:
						return _sListID;
					case TAG_ListStatusType:
						return _iListStatusType;
					case TAG_NoRpts:
						return _iNoRpts;
					case TAG_ListOrderStatus:
						return _iListOrderStatus;
					case TAG_RptSeq:
						return _iRptSeq;
					case TAG_ListStatusText:
						return _sListStatusText;
					case TAG_EncodedListStatusTextLen:
						return _iEncodedListStatusTextLen;
					case TAG_EncodedListStatusText:
						return _sEncodedListStatusText;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_TotNoOrders:
						return _iTotNoOrders;
					case TAG_LastFragment:
						return _bLastFragment;
					case TAG_NoOrders:
						return _iNoOrders;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_ListID:
						_sListID = (string)value;
						break;
					case TAG_ListStatusType:
						_iListStatusType = (int)value;
						break;
					case TAG_NoRpts:
						_iNoRpts = (int)value;
						break;
					case TAG_ListOrderStatus:
						_iListOrderStatus = (int)value;
						break;
					case TAG_RptSeq:
						_iRptSeq = (int)value;
						break;
					case TAG_ListStatusText:
						_sListStatusText = (string)value;
						break;
					case TAG_EncodedListStatusTextLen:
						_iEncodedListStatusTextLen = (int)value;
						break;
					case TAG_EncodedListStatusText:
						_sEncodedListStatusText = (string)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_TotNoOrders:
						_iTotNoOrders = (int)value;
						break;
					case TAG_LastFragment:
						_bLastFragment = (bool)value;
						break;
					case TAG_NoOrders:
						_iNoOrders = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class ListStatusOrder
	{
		private string _sClOrdID;
		private string _sSecondaryClOrdID;
		private int _iCumQty;
		private char _cOrdStatus;
		private bool _bWorkingIndicator;
		private int _iLeavesQty;
		private int _iCxlQty;
		private double _dAvgPx;
		private int _iOrdRejReason;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public string SecondaryClOrdID
		{
			get { return _sSecondaryClOrdID; }
			set { _sSecondaryClOrdID = value; }
		}
		public int CumQty
		{
			get { return _iCumQty; }
			set { _iCumQty = value; }
		}
		public char OrdStatus
		{
			get { return _cOrdStatus; }
			set { _cOrdStatus = value; }
		}
		public bool WorkingIndicator
		{
			get { return _bWorkingIndicator; }
			set { _bWorkingIndicator = value; }
		}
		public int LeavesQty
		{
			get { return _iLeavesQty; }
			set { _iLeavesQty = value; }
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
		public int OrdRejReason
		{
			get { return _iOrdRejReason; }
			set { _iOrdRejReason = value; }
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
		public string EncodedText
		{
			get { return _sEncodedText; }
			set { _sEncodedText = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case ListStatus.TAG_ClOrdID:
						return _sClOrdID;
					case ListStatus.TAG_SecondaryClOrdID:
						return _sSecondaryClOrdID;
					case ListStatus.TAG_CumQty:
						return _iCumQty;
					case ListStatus.TAG_OrdStatus:
						return _cOrdStatus;
					case ListStatus.TAG_WorkingIndicator:
						return _bWorkingIndicator;
					case ListStatus.TAG_LeavesQty:
						return _iLeavesQty;
					case ListStatus.TAG_CxlQty:
						return _iCxlQty;
					case ListStatus.TAG_AvgPx:
						return _dAvgPx;
					case ListStatus.TAG_OrdRejReason:
						return _iOrdRejReason;
					case ListStatus.TAG_Text:
						return _sText;
					case ListStatus.TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case ListStatus.TAG_EncodedText:
						return _sEncodedText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ListStatus.TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case ListStatus.TAG_SecondaryClOrdID:
						_sSecondaryClOrdID = (string)value;
						break;
					case ListStatus.TAG_CumQty:
						_iCumQty = (int)value;
						break;
					case ListStatus.TAG_OrdStatus:
						_cOrdStatus = (char)value;
						break;
					case ListStatus.TAG_WorkingIndicator:
						_bWorkingIndicator = (bool)value;
						break;
					case ListStatus.TAG_LeavesQty:
						_iLeavesQty = (int)value;
						break;
					case ListStatus.TAG_CxlQty:
						_iCxlQty = (int)value;
						break;
					case ListStatus.TAG_AvgPx:
						_dAvgPx = (double)value;
						break;
					case ListStatus.TAG_OrdRejReason:
						_iOrdRejReason = (int)value;
						break;
					case ListStatus.TAG_Text:
						_sText = (string)value;
						break;
					case ListStatus.TAG_EncodedTextLen:
						_iEncodedTextLen = (int)value;
						break;
					case ListStatus.TAG_EncodedText:
						_sEncodedText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ListStatusOrderList
	{
		private ArrayList _al;
		private ListStatusOrder _last;

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

		public void Add(ListStatusOrder item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ListStatusOrder item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ListStatusOrder Last
		{
			get { return _last; }
		}
	}
}
