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
	/// Summary description for ConfirmationRequest.
	/// </summary>
	public class ConfirmationRequest : Message
	{
		public const int TAG_ConfirmReqID = 859;
		public const int TAG_ConfirmType = 773;
		public const int TAG_NoOrders = 73;
		public const int TAG_ClOrdID = 11;
		public const int TAG_OrderID = 37;
		public const int TAG_SecondaryOrderID = 198;
		public const int TAG_SecondaryClOrdID = 526;
		public const int TAG_ListID = 66;
		public const int TAG_NoNested2PartyIDs = 756;
		public const int TAG_Nested2PartyID = 757;
		public const int TAG_Nested2PartyIDSource = 758;
		public const int TAG_Nested2PartyRole = 759;
		public const int TAG_NoNested2PartySubIDs = 806;
		public const int TAG_Nested2PartySubID = 760;
		public const int TAG_Nested2PartySubIDType = 807;
		public const int TAG_OrderQty = 38;
		public const int TAG_OrderAvgPx = 799;
		public const int TAG_OrderBookingQty = 800;
		public const int TAG_AllocID = 70;
		public const int TAG_SecondaryAllocID = 793;
		public const int TAG_IndividualAllocID = 467;
		public const int TAG_TransactTime = 60;
		public const int TAG_AllocAccount = 79;
		public const int TAG_AllocAcctIDSource = 661;
		public const int TAG_AllocAccountType = 798;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sConfirmReqID;
		private int _iConfirmType;
		private int _iNoOrders;
		private ConfirmationRequestOrderList _listOrder = new ConfirmationRequestOrderList();
		private string _sAllocID;
		private string _sSecondaryAllocID;
		private string _sIndividualAllocID;
		private DateTime _dtTransactTime;
		private string _sAllocAccount;
		private int _iAllocAcctIDSource;
		private int _iAllocAccountType;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public ConfirmationRequest() : base()
		{
			_sMsgType = Values.MsgType.ConfirmationRequest;
		}

		public string ConfirmReqID
		{
			get { return _sConfirmReqID; }
			set { _sConfirmReqID = value; }
		}
		public int ConfirmType
		{
			get { return _iConfirmType; }
			set { _iConfirmType = value; }
		}
		public int NoOrders
		{
			get { return _iNoOrders; }
			set { _iNoOrders = value; }
		}
		public ConfirmationRequestOrderList Order 
		{
			get { return _listOrder; }
		}
		public string AllocID
		{
			get { return _sAllocID; }
			set { _sAllocID = value; }
		}
		public string SecondaryAllocID
		{
			get { return _sSecondaryAllocID; }
			set { _sSecondaryAllocID = value; }
		}
		public string IndividualAllocID
		{
			get { return _sIndividualAllocID; }
			set { _sIndividualAllocID = value; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public string AllocAccount
		{
			get { return _sAllocAccount; }
			set { _sAllocAccount = value; }
		}
		public int AllocAcctIDSource
		{
			get { return _iAllocAcctIDSource; }
			set { _iAllocAcctIDSource = value; }
		}
		public int AllocAccountType
		{
			get { return _iAllocAccountType; }
			set { _iAllocAccountType = value; }
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

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_ConfirmReqID:
						return _sConfirmReqID;
					case TAG_ConfirmType:
						return _iConfirmType;
					case TAG_NoOrders:
						return _iNoOrders;
					case TAG_AllocID:
						return _sAllocID;
					case TAG_SecondaryAllocID:
						return _sSecondaryAllocID;
					case TAG_IndividualAllocID:
						return _sIndividualAllocID;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_AllocAccount:
						return _sAllocAccount;
					case TAG_AllocAcctIDSource:
						return _iAllocAcctIDSource;
					case TAG_AllocAccountType:
						return _iAllocAccountType;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_ConfirmReqID:
						_sConfirmReqID = (string)value;
						break;
					case TAG_ConfirmType:
						_iConfirmType = (int)value;
						break;
					case TAG_NoOrders:
						_iNoOrders = (int)value;
						break;
					case TAG_AllocID:
						_sAllocID = (string)value;
						break;
					case TAG_SecondaryAllocID:
						_sSecondaryAllocID = (string)value;
						break;
					case TAG_IndividualAllocID:
						_sIndividualAllocID = (string)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_AllocAccount:
						_sAllocAccount = (string)value;
						break;
					case TAG_AllocAcctIDSource:
						_iAllocAcctIDSource = (int)value;
						break;
					case TAG_AllocAccountType:
						_iAllocAccountType = (int)value;
						break;
					case TAG_Text:
						_sText = (string)value;
						break;
					case TAG_EncodedTextLen:
						_iEncodedTextLen = (int)value;
						break;
					case TAG_EncodedText:
						_sEncodedText = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class ConfirmationRequestOrder
	{
		private string _sClOrdID;
		private string _sOrderID;
		private string _sSecondaryOrderID;
		private string _sSecondaryClOrdID;
		private string _sListID;
		private int _iNoNested2PartyIDs;
		private ConfirmationRequestNested2PartyIDList _listNested2PartyID = new ConfirmationRequestNested2PartyIDList();
		private int _iOrderQty;
		private double _dOrderAvgPx;
		private int _iOrderBookingQty;

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
		public string SecondaryOrderID
		{
			get { return _sSecondaryOrderID; }
			set { _sSecondaryOrderID = value; }
		}
		public string SecondaryClOrdID
		{
			get { return _sSecondaryClOrdID; }
			set { _sSecondaryClOrdID = value; }
		}
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public int NoNested2PartyIDs
		{
			get { return _iNoNested2PartyIDs; }
			set { _iNoNested2PartyIDs = value; }
		}
		public ConfirmationRequestNested2PartyIDList Nested2PartyID 
		{
			get { return _listNested2PartyID; }
		}
		public int OrderQty
		{
			get { return _iOrderQty; }
			set { _iOrderQty = value; }
		}
		public double OrderAvgPx
		{
			get { return _dOrderAvgPx; }
			set { _dOrderAvgPx = value; }
		}
		public int OrderBookingQty
		{
			get { return _iOrderBookingQty; }
			set { _iOrderBookingQty = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case ConfirmationRequest.TAG_ClOrdID:
						return _sClOrdID;
					case ConfirmationRequest.TAG_OrderID:
						return _sOrderID;
					case ConfirmationRequest.TAG_SecondaryOrderID:
						return _sSecondaryOrderID;
					case ConfirmationRequest.TAG_SecondaryClOrdID:
						return _sSecondaryClOrdID;
					case ConfirmationRequest.TAG_ListID:
						return _sListID;
					case ConfirmationRequest.TAG_NoNested2PartyIDs:
						return _iNoNested2PartyIDs;
					case ConfirmationRequest.TAG_OrderQty:
						return _iOrderQty;
					case ConfirmationRequest.TAG_OrderAvgPx:
						return _dOrderAvgPx;
					case ConfirmationRequest.TAG_OrderBookingQty:
						return _iOrderBookingQty;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ConfirmationRequest.TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case ConfirmationRequest.TAG_OrderID:
						_sOrderID = (string)value;
						break;
					case ConfirmationRequest.TAG_SecondaryOrderID:
						_sSecondaryOrderID = (string)value;
						break;
					case ConfirmationRequest.TAG_SecondaryClOrdID:
						_sSecondaryClOrdID = (string)value;
						break;
					case ConfirmationRequest.TAG_ListID:
						_sListID = (string)value;
						break;
					case ConfirmationRequest.TAG_NoNested2PartyIDs:
						_iNoNested2PartyIDs = (int)value;
						break;
					case ConfirmationRequest.TAG_OrderQty:
						_iOrderQty = (int)value;
						break;
					case ConfirmationRequest.TAG_OrderAvgPx:
						_dOrderAvgPx = (double)value;
						break;
					case ConfirmationRequest.TAG_OrderBookingQty:
						_iOrderBookingQty = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationRequestOrderList
	{
		private ArrayList _al;
		private ConfirmationRequestOrder _last;

		public ConfirmationRequestOrder this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationRequestOrder)_al[i];
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

		public void Add(ConfirmationRequestOrder item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationRequestOrder item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationRequestOrder Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationRequestNested2PartyID
	{
		private string _sNested2PartyID;
		private char _cNested2PartyIDSource;
		private int _iNested2PartyRole;
		private int _iNoNested2PartySubIDs;
		private ConfirmationRequestNested2PartySubIDList _listNested2PartySubID = new ConfirmationRequestNested2PartySubIDList();

		public string Nested2PartyID
		{
			get { return _sNested2PartyID; }
			set { _sNested2PartyID = value; }
		}
		public char Nested2PartyIDSource
		{
			get { return _cNested2PartyIDSource; }
			set { _cNested2PartyIDSource = value; }
		}
		public int Nested2PartyRole
		{
			get { return _iNested2PartyRole; }
			set { _iNested2PartyRole = value; }
		}
		public int NoNested2PartySubIDs
		{
			get { return _iNoNested2PartySubIDs; }
			set { _iNoNested2PartySubIDs = value; }
		}
		public ConfirmationRequestNested2PartySubIDList Nested2PartySubID 
		{
			get { return _listNested2PartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case ConfirmationRequest.TAG_Nested2PartyID:
						return _sNested2PartyID;
					case ConfirmationRequest.TAG_Nested2PartyIDSource:
						return _cNested2PartyIDSource;
					case ConfirmationRequest.TAG_Nested2PartyRole:
						return _iNested2PartyRole;
					case ConfirmationRequest.TAG_NoNested2PartySubIDs:
						return _iNoNested2PartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ConfirmationRequest.TAG_Nested2PartyID:
						_sNested2PartyID = (string)value;
						break;
					case ConfirmationRequest.TAG_Nested2PartyIDSource:
						_cNested2PartyIDSource = (char)value;
						break;
					case ConfirmationRequest.TAG_Nested2PartyRole:
						_iNested2PartyRole = (int)value;
						break;
					case ConfirmationRequest.TAG_NoNested2PartySubIDs:
						_iNoNested2PartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationRequestNested2PartyIDList
	{
		private ArrayList _al;
		private ConfirmationRequestNested2PartyID _last;

		public ConfirmationRequestNested2PartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationRequestNested2PartyID)_al[i];
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

		public void Add(ConfirmationRequestNested2PartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationRequestNested2PartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationRequestNested2PartyID Last
		{
			get { return _last; }
		}
	}

	public class ConfirmationRequestNested2PartySubID
	{
		private string _sNested2PartySubID;
		private int _iNested2PartySubIDType;

		public string Nested2PartySubID
		{
			get { return _sNested2PartySubID; }
			set { _sNested2PartySubID = value; }
		}
		public int Nested2PartySubIDType
		{
			get { return _iNested2PartySubIDType; }
			set { _iNested2PartySubIDType = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case ConfirmationRequest.TAG_Nested2PartySubID:
						return _sNested2PartySubID;
					case ConfirmationRequest.TAG_Nested2PartySubIDType:
						return _iNested2PartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case ConfirmationRequest.TAG_Nested2PartySubID:
						_sNested2PartySubID = (string)value;
						break;
					case ConfirmationRequest.TAG_Nested2PartySubIDType:
						_iNested2PartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class ConfirmationRequestNested2PartySubIDList
	{
		private ArrayList _al;
		private ConfirmationRequestNested2PartySubID _last;

		public ConfirmationRequestNested2PartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (ConfirmationRequestNested2PartySubID)_al[i];
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

		public void Add(ConfirmationRequestNested2PartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(ConfirmationRequestNested2PartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public ConfirmationRequestNested2PartySubID Last
		{
			get { return _last; }
		}
	}
}
