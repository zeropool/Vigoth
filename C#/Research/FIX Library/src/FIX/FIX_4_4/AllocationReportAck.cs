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
	/// Summary description for AllocationReportAck.
	/// </summary>
	public class AllocationReportAck : Message
	{
		public const int TAG_AllocReportID = 755;
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
		public const int TAG_AllocReportType = 794;
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

		private string _sAllocReportID;
		private string _sAllocID;
		private int _iNoPartyIDs;
		private AllocationReportAckPartyIDList _listPartyID = new AllocationReportAckPartyIDList();
		private string _sSecondaryAllocID;
		private DateTime _dtTradeDate;
		private DateTime _dtTransactTime;
		private int _iAllocStatus;
		private int _iAllocRejCode;
		private int _iAllocReportType;
		private int _iAllocIntermedReqType;
		private char _cMatchStatus;
		private int _iProduct;
		private string _sSecurityType;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private int _iNoAllocs;
		private AllocationReportAckAllocList _listAlloc = new AllocationReportAckAllocList();

		public AllocationReportAck() : base()
		{
			_sMsgType = Values.MsgType.AllocationReportAck;
		}

		public string AllocReportID
		{
			get { return _sAllocReportID; }
			set { _sAllocReportID = value; }
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
		public AllocationReportAckPartyIDList PartyID 
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
		public int AllocReportType
		{
			get { return _iAllocReportType; }
			set { _iAllocReportType = value; }
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
		public AllocationReportAckAllocList Alloc 
		{
			get { return _listAlloc; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_AllocReportID:
						return _sAllocReportID;
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
					case TAG_AllocReportType:
						return _iAllocReportType;
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
					case TAG_AllocReportID:
						_sAllocReportID = (string)value;
						break;
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
					case TAG_AllocReportType:
						_iAllocReportType = (int)value;
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

	public class AllocationReportAckPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private AllocationReportAckPartySubIDList _listPartySubID = new AllocationReportAckPartySubIDList();

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
		public AllocationReportAckPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case AllocationReportAck.TAG_PartyID:
						return _sPartyID;
					case AllocationReportAck.TAG_PartyIDSource:
						return _cPartyIDSource;
					case AllocationReportAck.TAG_PartyRole:
						return _iPartyRole;
					case AllocationReportAck.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationReportAck.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case AllocationReportAck.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case AllocationReportAck.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case AllocationReportAck.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationReportAckPartyIDList
	{
		private ArrayList _al;
		private AllocationReportAckPartyID _last;

		public AllocationReportAckPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationReportAckPartyID)_al[i];
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

		public void Add(AllocationReportAckPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationReportAckPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationReportAckPartyID Last
		{
			get { return _last; }
		}
	}

	public class AllocationReportAckPartySubID
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
					case AllocationReportAck.TAG_PartySubID:
						return _sPartySubID;
					case AllocationReportAck.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationReportAck.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case AllocationReportAck.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationReportAckPartySubIDList
	{
		private ArrayList _al;
		private AllocationReportAckPartySubID _last;

		public AllocationReportAckPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationReportAckPartySubID)_al[i];
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

		public void Add(AllocationReportAckPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationReportAckPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationReportAckPartySubID Last
		{
			get { return _last; }
		}
	}

	public class AllocationReportAckAlloc
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
					case AllocationReportAck.TAG_AllocAccount:
						return _sAllocAccount;
					case AllocationReportAck.TAG_AllocAcctIDSource:
						return _iAllocAcctIDSource;
					case AllocationReportAck.TAG_AllocPrice:
						return _dAllocPrice;
					case AllocationReportAck.TAG_IndividualAllocID:
						return _sIndividualAllocID;
					case AllocationReportAck.TAG_IndividualAllocRejCode:
						return _iIndividualAllocRejCode;
					case AllocationReportAck.TAG_AllocText:
						return _sAllocText;
					case AllocationReportAck.TAG_EncodedAllocTextLen:
						return _iEncodedAllocTextLen;
					case AllocationReportAck.TAG_EncodedAllocText:
						return _sEncodedAllocText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case AllocationReportAck.TAG_AllocAccount:
						_sAllocAccount = (string)value;
						break;
					case AllocationReportAck.TAG_AllocAcctIDSource:
						_iAllocAcctIDSource = (int)value;
						break;
					case AllocationReportAck.TAG_AllocPrice:
						_dAllocPrice = (double)value;
						break;
					case AllocationReportAck.TAG_IndividualAllocID:
						_sIndividualAllocID = (string)value;
						break;
					case AllocationReportAck.TAG_IndividualAllocRejCode:
						_iIndividualAllocRejCode = (int)value;
						break;
					case AllocationReportAck.TAG_AllocText:
						_sAllocText = (string)value;
						break;
					case AllocationReportAck.TAG_EncodedAllocTextLen:
						_iEncodedAllocTextLen = (int)value;
						break;
					case AllocationReportAck.TAG_EncodedAllocText:
						_sEncodedAllocText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class AllocationReportAckAllocList
	{
		private ArrayList _al;
		private AllocationReportAckAlloc _last;

		public AllocationReportAckAlloc this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (AllocationReportAckAlloc)_al[i];
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

		public void Add(AllocationReportAckAlloc item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(AllocationReportAckAlloc item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public AllocationReportAckAlloc Last
		{
			get { return _last; }
		}
	}
}
