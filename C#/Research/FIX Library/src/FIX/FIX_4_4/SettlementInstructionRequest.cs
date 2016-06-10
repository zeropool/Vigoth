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
	/// Summary description for SettlementInstructionRequest.
	/// </summary>
	public class SettlementInstructionRequest : Message
	{
		public const int TAG_SettlInstReqID = 791;
		public const int TAG_TransactTime = 60;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_AllocAccount = 79;
		public const int TAG_AllocAcctIDSource = 661;
		public const int TAG_Side = 54;
		public const int TAG_Product = 460;
		public const int TAG_SecurityType = 167;
		public const int TAG_CFICode = 461;
		public const int TAG_EffectiveTime = 168;
		public const int TAG_ExpireTime = 126;
		public const int TAG_LastUpdateTime = 779;
		public const int TAG_StandInstDbType = 169;
		public const int TAG_StandInstDbName = 170;
		public const int TAG_StandInstDbID = 171;

		private string _sSettlInstReqID;
		private DateTime _dtTransactTime;
		private int _iNoPartyIDs;
		private SettlementInstructionRequestPartyIDList _listPartyID = new SettlementInstructionRequestPartyIDList();
		private string _sAllocAccount;
		private int _iAllocAcctIDSource;
		private char _cSide;
		private int _iProduct;
		private string _sSecurityType;
		private string _sCFICode;
		private DateTime _dtEffectiveTime;
		private DateTime _dtExpireTime;
		private DateTime _dtLastUpdateTime;
		private int _iStandInstDbType;
		private string _sStandInstDbName;
		private string _sStandInstDbID;

		public SettlementInstructionRequest() : base()
		{
			_sMsgType = Values.MsgType.SettlementInstructionRequest;
		}

		public string SettlInstReqID
		{
			get { return _sSettlInstReqID; }
			set { _sSettlInstReqID = value; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public SettlementInstructionRequestPartyIDList PartyID 
		{
			get { return _listPartyID; }
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
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
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
		public string CFICode
		{
			get { return _sCFICode; }
			set { _sCFICode = value; }
		}
		public DateTime EffectiveTime
		{
			get { return _dtEffectiveTime; }
			set { _dtEffectiveTime = value; }
		}
		public DateTime ExpireTime
		{
			get { return _dtExpireTime; }
			set { _dtExpireTime = value; }
		}
		public DateTime LastUpdateTime
		{
			get { return _dtLastUpdateTime; }
			set { _dtLastUpdateTime = value; }
		}
		public int StandInstDbType
		{
			get { return _iStandInstDbType; }
			set { _iStandInstDbType = value; }
		}
		public string StandInstDbName
		{
			get { return _sStandInstDbName; }
			set { _sStandInstDbName = value; }
		}
		public string StandInstDbID
		{
			get { return _sStandInstDbID; }
			set { _sStandInstDbID = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_SettlInstReqID:
						return _sSettlInstReqID;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case TAG_AllocAccount:
						return _sAllocAccount;
					case TAG_AllocAcctIDSource:
						return _iAllocAcctIDSource;
					case TAG_Side:
						return _cSide;
					case TAG_Product:
						return _iProduct;
					case TAG_SecurityType:
						return _sSecurityType;
					case TAG_CFICode:
						return _sCFICode;
					case TAG_EffectiveTime:
						return _dtEffectiveTime;
					case TAG_ExpireTime:
						return _dtExpireTime;
					case TAG_LastUpdateTime:
						return _dtLastUpdateTime;
					case TAG_StandInstDbType:
						return _iStandInstDbType;
					case TAG_StandInstDbName:
						return _sStandInstDbName;
					case TAG_StandInstDbID:
						return _sStandInstDbID;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_SettlInstReqID:
						_sSettlInstReqID = (string)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case TAG_AllocAccount:
						_sAllocAccount = (string)value;
						break;
					case TAG_AllocAcctIDSource:
						_iAllocAcctIDSource = (int)value;
						break;
					case TAG_Side:
						_cSide = (char)value;
						break;
					case TAG_Product:
						_iProduct = (int)value;
						break;
					case TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case TAG_CFICode:
						_sCFICode = (string)value;
						break;
					case TAG_EffectiveTime:
						_dtEffectiveTime = (DateTime)value;
						break;
					case TAG_ExpireTime:
						_dtExpireTime = (DateTime)value;
						break;
					case TAG_LastUpdateTime:
						_dtLastUpdateTime = (DateTime)value;
						break;
					case TAG_StandInstDbType:
						_iStandInstDbType = (int)value;
						break;
					case TAG_StandInstDbName:
						_sStandInstDbName = (string)value;
						break;
					case TAG_StandInstDbID:
						_sStandInstDbID = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class SettlementInstructionRequestPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private SettlementInstructionRequestPartySubIDList _listPartySubID = new SettlementInstructionRequestPartySubIDList();

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
		public SettlementInstructionRequestPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case SettlementInstructionRequest.TAG_PartyID:
						return _sPartyID;
					case SettlementInstructionRequest.TAG_PartyIDSource:
						return _cPartyIDSource;
					case SettlementInstructionRequest.TAG_PartyRole:
						return _iPartyRole;
					case SettlementInstructionRequest.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SettlementInstructionRequest.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case SettlementInstructionRequest.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case SettlementInstructionRequest.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case SettlementInstructionRequest.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SettlementInstructionRequestPartyIDList
	{
		private ArrayList _al;
		private SettlementInstructionRequestPartyID _last;

		public SettlementInstructionRequestPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SettlementInstructionRequestPartyID)_al[i];
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

		public void Add(SettlementInstructionRequestPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SettlementInstructionRequestPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SettlementInstructionRequestPartyID Last
		{
			get { return _last; }
		}
	}

	public class SettlementInstructionRequestPartySubID
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
					case SettlementInstructionRequest.TAG_PartySubID:
						return _sPartySubID;
					case SettlementInstructionRequest.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SettlementInstructionRequest.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case SettlementInstructionRequest.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SettlementInstructionRequestPartySubIDList
	{
		private ArrayList _al;
		private SettlementInstructionRequestPartySubID _last;

		public SettlementInstructionRequestPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SettlementInstructionRequestPartySubID)_al[i];
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

		public void Add(SettlementInstructionRequestPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SettlementInstructionRequestPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SettlementInstructionRequestPartySubID Last
		{
			get { return _last; }
		}
	}
}
