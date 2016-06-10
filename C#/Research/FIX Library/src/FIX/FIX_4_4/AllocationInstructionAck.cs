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
	/// Summary description for AllocationInstructionAck.
	/// </summary>
	public class AllocationInstructionAck : Message
	{
		public const int TAG_AllocID = 70;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_SecondaryAllocID = 793;
		public const int TAG_TradeDate = 75;
		public const int TAG_TransactTime = 60;
		public const int TAG_AllocStatus = 87;
		public const int TAG_AllocRejCode = 88;
		public const int TAG_AllocType = 626;
		public const int TAG_AllocIntermedReqType = 808;
		public const int TAG_MatchStatus = 573;
		public const int TAG_Product = 460;
		public const int TAG_SecurityType = 167;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_NoAllocs = 78;
		public const int TAG_AllocAccount = 79;
		public const int TAG_AllocAcctIDSource = 661;
		public const int TAG_AllocPrice = 366;
		public const int TAG_IndividualAllocID = 467;
		public const int TAG_IndividualAllocRejCode = 776;
		public const int TAG_AllocText = 161;
		public const int TAG_EncodedAllocTextLen = 360;
		public const int TAG_EncodedAllocText = 361;

		private string _sAllocID;
		private int _iNoPartyIDs;
		private AllocationInstructionAckPartyIDList _listPartyID = new AllocationInstructionAckPartyIDList();
		private string _sSecondaryAllocID;
		private DateTime _dtTradeDate;
		private DateTime _dtTransactTime;
		private int _iAllocStatus;
		private int _iAllocRejCode;
		private int _iAllocType;
		private int _iAllocIntermedReqType;
		private char _cMatchStatus;
		private int _iProduct;
		private string _sSecurityType;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private int _iNoAllocs;
		private AllocationInstructionAckAllocList _listAlloc = new AllocationInstructionAckAllocList();

		public AllocationInstructionAck() : base()
		{
			_sMsgType = Values.MsgType.AllocationInstructionAck;
		}

		public string AllocID
		{
			get { return _sAllocID; }
			set { _sAllocID = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public AllocationInstructionAckPartyIDList PartyID 
		{
			get { return _listPartyID; }
		}
		public string SecondaryAllocID
		{
			get { return _sSecondaryAllocID; }
			set { _sSecondaryAllocID = value; }
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
		public int AllocType
		{
			get { return _iAllocType; }
			set { _iAllocType = value; }
		}
		public int AllocIntermedReqType
		{
			get { return _iAllocIntermedReqType; }
			set { _iAllocIntermedReqType = value; }
		}
		public char MatchStatus
		{
			get { return _cMatchStatus; }
			set { _cMatchStatus = value; }
		}
		public int Product
		{
			get { return _iProduct; }
			set { _iProduct = value; }
		}
		public string SecurityType
		{
			get { return _sSecurityType; }
			set { _sSecurityType = value; }
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
		public int NoAllocs
		{
			get { return _iNoAllocs; }
			set { _iNoAllocs = value; }
		}
		public AllocationInstructionAckAllocList Alloc 
		{
			get { return _listAlloc; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_AllocID:
						return _sAllocID;
					case TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case TAG_SecondaryAllocID:
						return _sSecondaryAllocID;
					case TAG_TradeDate:
						return _dtTradeDate;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_AllocStatus:
						return _iAllocStatus;
					case TAG_AllocRejCode:
						return _iAllocRejCode;
					case TAG_AllocType:
						return _iAllocType;
					case TAG_AllocIntermedReqType:
						return _iAllocIntermedReqType;
					case TAG_MatchStatus:
						return _cMatchStatus;
					case TAG_Product:
						return _iProduct;
					case TAG_SecurityType:
						return _sSecurityType;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
					case TAG_NoAllocs:
						return _iNoAllocs;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_AllocID:
						_sAllocID = (string)value;
						break;
					case TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case TAG_SecondaryAllocID:
						_sSecondaryAllocID = (string)value;
						break;
					case TAG_TradeDate:
						_dtTradeDate = (DateTime)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_AllocStatus:
						_iAllocStatus = (int)value;
						break;
					case TAG_AllocRejCode:
						_iAllocRejCode = (int)value;
						break;
					case TAG_AllocType:
						_iAllocType = (int)value;
						break;
					case TAG_AllocIntermedReqType:
						_iAllocIntermedReqType = (int)value;
						break;
					case TAG_MatchStatus:
						_cMatchStatus = (char)value;
						break;
					case TAG_Product:
						_iProduct = (int)value;
						break;
					case TAG_SecurityType:
						_sSecurityType = (string)value;
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
					case TAG_NoAllocs:
						_iNoAllocs = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class AllocationInstructionAckPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private AllocationInstructionAckPartySubIDList _listPartySubID = new AllocationInstructionAckPartySubIDList();

		public string PartyID
		{
			get { return _sPartyID; }
			set { _sPartyID = value; }
		}
		public char PartyIDSource
		{
			get { return _cPartyIDSource; }
			set { _cPartyIDSource = value; }
		}
		public int PartyRole
		{
			get { return _iPartyRole; }
			set { _iPartyRole = value; }
		}
		public int NoPartySubIDs
		{
			get { return _iNoPartySubIDs; }
			set { _iNoPartySubIDs = value; }
		}
		public AllocationInstructionAckPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstructionAck.TAG_PartyID:
						return _sPartyID;
					case AllocationInstructionAck.TAG_PartyIDSource:
						return _cPartyIDSource;
					case AllocationInstructionAck.TAG_PartyRole:
						return _iPartyRole;
					case AllocationInstructionAck.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstructionAck.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case AllocationInstructionAck.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case AllocationInstructionAck.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case AllocationInstructionAck.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionAckPartyIDList
	{
		private ArrayList _al;
		private AllocationInstructionAckPartyID _last;

		public AllocationInstructionAckPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionAckPartyID)_al[i];
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

		public void Add(AllocationInstructionAckPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionAckPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionAckPartyID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionAckPartySubID
	{
		private string _sPartySubID;
		private int _iPartySubIDType;

		public string PartySubID
		{
			get { return _sPartySubID; }
			set { _sPartySubID = value; }
		}
		public int PartySubIDType
		{
			get { return _iPartySubIDType; }
			set { _iPartySubIDType = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstructionAck.TAG_PartySubID:
						return _sPartySubID;
					case AllocationInstructionAck.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstructionAck.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case AllocationInstructionAck.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionAckPartySubIDList
	{
		private ArrayList _al;
		private AllocationInstructionAckPartySubID _last;

		public AllocationInstructionAckPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionAckPartySubID)_al[i];
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

		public void Add(AllocationInstructionAckPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionAckPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionAckPartySubID Last
		{
			get { return _last; }
		}
	}

	public class AllocationInstructionAckAlloc
	{
		private string _sAllocAccount;
		private int _iAllocAcctIDSource;
		private double _dAllocPrice;
		private string _sIndividualAllocID;
		private int _iIndividualAllocRejCode;
		private string _sAllocText;
		private int _iEncodedAllocTextLen;
		private string _sEncodedAllocText;

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
		public double AllocPrice
		{
			get { return _dAllocPrice; }
			set { _dAllocPrice = value; }
		}
		public string IndividualAllocID
		{
			get { return _sIndividualAllocID; }
			set { _sIndividualAllocID = value; }
		}
		public int IndividualAllocRejCode
		{
			get { return _iIndividualAllocRejCode; }
			set { _iIndividualAllocRejCode = value; }
		}
		public string AllocText
		{
			get { return _sAllocText; }
			set { _sAllocText = value; }
		}
		public int EncodedAllocTextLen
		{
			get { return _iEncodedAllocTextLen; }
			set { _iEncodedAllocTextLen = value; }
		}
		public string EncodedAllocText
		{
			get { return _sEncodedAllocText; }
			set { _sEncodedAllocText = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationInstructionAck.TAG_AllocAccount:
						return _sAllocAccount;
					case AllocationInstructionAck.TAG_AllocAcctIDSource:
						return _iAllocAcctIDSource;
					case AllocationInstructionAck.TAG_AllocPrice:
						return _dAllocPrice;
					case AllocationInstructionAck.TAG_IndividualAllocID:
						return _sIndividualAllocID;
					case AllocationInstructionAck.TAG_IndividualAllocRejCode:
						return _iIndividualAllocRejCode;
					case AllocationInstructionAck.TAG_AllocText:
						return _sAllocText;
					case AllocationInstructionAck.TAG_EncodedAllocTextLen:
						return _iEncodedAllocTextLen;
					case AllocationInstructionAck.TAG_EncodedAllocText:
						return _sEncodedAllocText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationInstructionAck.TAG_AllocAccount:
						_sAllocAccount = (string)value;
						break;
					case AllocationInstructionAck.TAG_AllocAcctIDSource:
						_iAllocAcctIDSource = (int)value;
						break;
					case AllocationInstructionAck.TAG_AllocPrice:
						_dAllocPrice = (double)value;
						break;
					case AllocationInstructionAck.TAG_IndividualAllocID:
						_sIndividualAllocID = (string)value;
						break;
					case AllocationInstructionAck.TAG_IndividualAllocRejCode:
						_iIndividualAllocRejCode = (int)value;
						break;
					case AllocationInstructionAck.TAG_AllocText:
						_sAllocText = (string)value;
						break;
					case AllocationInstructionAck.TAG_EncodedAllocTextLen:
						_iEncodedAllocTextLen = (int)value;
						break;
					case AllocationInstructionAck.TAG_EncodedAllocText:
						_sEncodedAllocText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationInstructionAckAllocList
	{
		private ArrayList _al;
		private AllocationInstructionAckAlloc _last;

		public AllocationInstructionAckAlloc this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationInstructionAckAlloc)_al[i];
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

		public void Add(AllocationInstructionAckAlloc item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationInstructionAckAlloc item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationInstructionAckAlloc Last
		{
			get { return _last; }
		}
	}
}
