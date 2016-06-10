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
	/// Summary description for RegistrationInstructionsResponse.
	/// </summary>
	public class RegistrationInstructionsResponse : Message
	{
		public const int TAG_RegistID = 513;
		public const int TAG_RegistTransType = 514;
		public const int TAG_RegistRefID = 508;
		public const int TAG_ClOrdID = 11;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_Account = 1;
		public const int TAG_AcctIDSource = 660;
		public const int TAG_RegistStatus = 506;
		public const int TAG_RegistRejReasonCode = 507;
		public const int TAG_RegistRejReasonText = 496;

		private string _sRegistID;
		private char _cRegistTransType;
		private string _sRegistRefID;
		private string _sClOrdID;
		private int _iNoPartyIDs;
		private RegistrationInstructionsResponsePartyIDList _listPartyID = new RegistrationInstructionsResponsePartyIDList();
		private string _sAccount;
		private int _iAcctIDSource;
		private char _cRegistStatus;
		private int _iRegistRejReasonCode;
		private string _sRegistRejReasonText;

		public RegistrationInstructionsResponse() : base()
		{
			_sMsgType = Values.MsgType.RegistrationInstructionsResponse;
		}

		public string RegistID
		{
			get { return _sRegistID; }
			set { _sRegistID = value; }
		}
		public char RegistTransType
		{
			get { return _cRegistTransType; }
			set { _cRegistTransType = value; }
		}
		public string RegistRefID
		{
			get { return _sRegistRefID; }
			set { _sRegistRefID = value; }
		}
		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public RegistrationInstructionsResponsePartyIDList PartyID 
		{
			get { return _listPartyID; }
		}
		public string Account
		{
			get { return _sAccount; }
			set { _sAccount = value; }
		}
		public int AcctIDSource
		{
			get { return _iAcctIDSource; }
			set { _iAcctIDSource = value; }
		}
		public char RegistStatus
		{
			get { return _cRegistStatus; }
			set { _cRegistStatus = value; }
		}
		public int RegistRejReasonCode
		{
			get { return _iRegistRejReasonCode; }
			set { _iRegistRejReasonCode = value; }
		}
		public string RegistRejReasonText
		{
			get { return _sRegistRejReasonText; }
			set { _sRegistRejReasonText = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_RegistID:
						return _sRegistID;
					case TAG_RegistTransType:
						return _cRegistTransType;
					case TAG_RegistRefID:
						return _sRegistRefID;
					case TAG_ClOrdID:
						return _sClOrdID;
					case TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case TAG_Account:
						return _sAccount;
					case TAG_AcctIDSource:
						return _iAcctIDSource;
					case TAG_RegistStatus:
						return _cRegistStatus;
					case TAG_RegistRejReasonCode:
						return _iRegistRejReasonCode;
					case TAG_RegistRejReasonText:
						return _sRegistRejReasonText;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_RegistID:
						_sRegistID = (string)value;
						break;
					case TAG_RegistTransType:
						_cRegistTransType = (char)value;
						break;
					case TAG_RegistRefID:
						_sRegistRefID = (string)value;
						break;
					case TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case TAG_Account:
						_sAccount = (string)value;
						break;
					case TAG_AcctIDSource:
						_iAcctIDSource = (int)value;
						break;
					case TAG_RegistStatus:
						_cRegistStatus = (char)value;
						break;
					case TAG_RegistRejReasonCode:
						_iRegistRejReasonCode = (int)value;
						break;
					case TAG_RegistRejReasonText:
						_sRegistRejReasonText = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class RegistrationInstructionsResponsePartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private RegistrationInstructionsResponsePartySubIDList _listPartySubID = new RegistrationInstructionsResponsePartySubIDList();

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
		public RegistrationInstructionsResponsePartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case RegistrationInstructionsResponse.TAG_PartyID:
						return _sPartyID;
					case RegistrationInstructionsResponse.TAG_PartyIDSource:
						return _cPartyIDSource;
					case RegistrationInstructionsResponse.TAG_PartyRole:
						return _iPartyRole;
					case RegistrationInstructionsResponse.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case RegistrationInstructionsResponse.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case RegistrationInstructionsResponse.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case RegistrationInstructionsResponse.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case RegistrationInstructionsResponse.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class RegistrationInstructionsResponsePartyIDList
	{
		private ArrayList _al;
		private RegistrationInstructionsResponsePartyID _last;

		public RegistrationInstructionsResponsePartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (RegistrationInstructionsResponsePartyID)_al[i];
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

		public void Add(RegistrationInstructionsResponsePartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(RegistrationInstructionsResponsePartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public RegistrationInstructionsResponsePartyID Last
		{
			get { return _last; }
		}
	}

	public class RegistrationInstructionsResponsePartySubID
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
					case RegistrationInstructionsResponse.TAG_PartySubID:
						return _sPartySubID;
					case RegistrationInstructionsResponse.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case RegistrationInstructionsResponse.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case RegistrationInstructionsResponse.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class RegistrationInstructionsResponsePartySubIDList
	{
		private ArrayList _al;
		private RegistrationInstructionsResponsePartySubID _last;

		public RegistrationInstructionsResponsePartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (RegistrationInstructionsResponsePartySubID)_al[i];
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

		public void Add(RegistrationInstructionsResponsePartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(RegistrationInstructionsResponsePartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public RegistrationInstructionsResponsePartySubID Last
		{
			get { return _last; }
		}
	}
}
