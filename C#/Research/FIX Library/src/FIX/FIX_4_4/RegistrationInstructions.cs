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
	/// Summary description for RegistrationInstructions.
	/// </summary>
	public class RegistrationInstructions : Message
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
		public const int TAG_RegistAcctType = 493;
		public const int TAG_TaxAdvantageType = 495;
		public const int TAG_OwnershipType = 517;
		public const int TAG_NoRegistDtls = 473;
		public const int TAG_RegistDtls = 509;
		public const int TAG_RegistEmail = 511;
		public const int TAG_MailingDtls = 474;
		public const int TAG_MailingInst = 482;
		public const int TAG_NoNestedPartyIDs = 539;
		public const int TAG_NestedPartyID = 524;
		public const int TAG_NestedPartyIDSource = 525;
		public const int TAG_NestedPartyRole = 538;
		public const int TAG_NoNestedPartySubIDs = 804;
		public const int TAG_NestedPartySubID = 545;
		public const int TAG_NestedPartySubIDType = 805;
		public const int TAG_OwnerType = 522;
		public const int TAG_DateOfBirth = 486;
		public const int TAG_InvestorCountryOfResidence = 475;
		public const int TAG_NoDistribInsts = 510;
		public const int TAG_DistribPaymentMethod = 477;
		public const int TAG_DistribPercentage = 512;
		public const int TAG_CashDistribCurr = 478;
		public const int TAG_CashDistribAgentName = 498;
		public const int TAG_CashDistribAgentCode = 499;
		public const int TAG_CashDistribAgentAcctNumber = 500;
		public const int TAG_CashDistribPayRef = 501;
		public const int TAG_CashDistribAgentAcctName = 502;

		private string _sRegistID;
		private char _cRegistTransType;
		private string _sRegistRefID;
		private string _sClOrdID;
		private int _iNoPartyIDs;
		private RegistrationInstructionsPartyIDList _listPartyID = new RegistrationInstructionsPartyIDList();
		private string _sAccount;
		private int _iAcctIDSource;
		private string _sRegistAcctType;
		private int _iTaxAdvantageType;
		private char _cOwnershipType;
		private int _iNoRegistDtls;
		private RegistrationInstructionsRegistDtlList _listRegistDtl = new RegistrationInstructionsRegistDtlList();
		private int _iNoDistribInsts;
		private RegistrationInstructionsDistribInstList _listDistribInst = new RegistrationInstructionsDistribInstList();

		public RegistrationInstructions() : base()
		{
			_sMsgType = Values.MsgType.RegistrationInstructions;
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
		public RegistrationInstructionsPartyIDList PartyID 
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
		public string RegistAcctType
		{
			get { return _sRegistAcctType; }
			set { _sRegistAcctType = value; }
		}
		public int TaxAdvantageType
		{
			get { return _iTaxAdvantageType; }
			set { _iTaxAdvantageType = value; }
		}
		public char OwnershipType
		{
			get { return _cOwnershipType; }
			set { _cOwnershipType = value; }
		}
		public int NoRegistDtls
		{
			get { return _iNoRegistDtls; }
			set { _iNoRegistDtls = value; }
		}
		public RegistrationInstructionsRegistDtlList RegistDtl 
		{
			get { return _listRegistDtl; }
		}
		public int NoDistribInsts
		{
			get { return _iNoDistribInsts; }
			set { _iNoDistribInsts = value; }
		}
		public RegistrationInstructionsDistribInstList DistribInst 
		{
			get { return _listDistribInst; }
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
					case TAG_RegistAcctType:
						return _sRegistAcctType;
					case TAG_TaxAdvantageType:
						return _iTaxAdvantageType;
					case TAG_OwnershipType:
						return _cOwnershipType;
					case TAG_NoRegistDtls:
						return _iNoRegistDtls;
					case TAG_NoDistribInsts:
						return _iNoDistribInsts;
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
					case TAG_RegistAcctType:
						_sRegistAcctType = (string)value;
						break;
					case TAG_TaxAdvantageType:
						_iTaxAdvantageType = (int)value;
						break;
					case TAG_OwnershipType:
						_cOwnershipType = (char)value;
						break;
					case TAG_NoRegistDtls:
						_iNoRegistDtls = (int)value;
						break;
					case TAG_NoDistribInsts:
						_iNoDistribInsts = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class RegistrationInstructionsPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private RegistrationInstructionsPartySubIDList _listPartySubID = new RegistrationInstructionsPartySubIDList();

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
		public RegistrationInstructionsPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_PartyID:
						return _sPartyID;
					case RegistrationInstructions.TAG_PartyIDSource:
						return _cPartyIDSource;
					case RegistrationInstructions.TAG_PartyRole:
						return _iPartyRole;
					case RegistrationInstructions.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case RegistrationInstructions.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case RegistrationInstructions.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case RegistrationInstructions.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class RegistrationInstructionsPartyIDList
	{
		private ArrayList _al;
		private RegistrationInstructionsPartyID _last;

		public RegistrationInstructionsPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (RegistrationInstructionsPartyID)_al[i];
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

		public void Add(RegistrationInstructionsPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(RegistrationInstructionsPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public RegistrationInstructionsPartyID Last
		{
			get { return _last; }
		}
	}

	public class RegistrationInstructionsPartySubID
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
					case RegistrationInstructions.TAG_PartySubID:
						return _sPartySubID;
					case RegistrationInstructions.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case RegistrationInstructions.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class RegistrationInstructionsPartySubIDList
	{
		private ArrayList _al;
		private RegistrationInstructionsPartySubID _last;

		public RegistrationInstructionsPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (RegistrationInstructionsPartySubID)_al[i];
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

		public void Add(RegistrationInstructionsPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(RegistrationInstructionsPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public RegistrationInstructionsPartySubID Last
		{
			get { return _last; }
		}
	}

	public class RegistrationInstructionsRegistDtl
	{
		private string _sRegistDtls;
		private string _sRegistEmail;
		private string _sMailingDtls;
		private string _sMailingInst;
		private int _iNoNestedPartyIDs;
		private RegistrationInstructionsNestedPartyIDList _listNestedPartyID = new RegistrationInstructionsNestedPartyIDList();
		private int _iOwnerType;
		private DateTime _dtDateOfBirth;
		private string _sInvestorCountryOfResidence;

		public string RegistDtls
		{
			get { return _sRegistDtls; }
			set { _sRegistDtls = value; }
		}
		public string RegistEmail
		{
			get { return _sRegistEmail; }
			set { _sRegistEmail = value; }
		}
		public string MailingDtls
		{
			get { return _sMailingDtls; }
			set { _sMailingDtls = value; }
		}
		public string MailingInst
		{
			get { return _sMailingInst; }
			set { _sMailingInst = value; }
		}
		public int NoNestedPartyIDs
		{
			get { return _iNoNestedPartyIDs; }
			set { _iNoNestedPartyIDs = value; }
		}
		public RegistrationInstructionsNestedPartyIDList NestedPartyID 
		{
			get { return _listNestedPartyID; }
		}
		public int OwnerType
		{
			get { return _iOwnerType; }
			set { _iOwnerType = value; }
		}
		public DateTime DateOfBirth
		{
			get { return _dtDateOfBirth; }
			set { _dtDateOfBirth = value; }
		}
		public string InvestorCountryOfResidence
		{
			get { return _sInvestorCountryOfResidence; }
			set { _sInvestorCountryOfResidence = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_RegistDtls:
						return _sRegistDtls;
					case RegistrationInstructions.TAG_RegistEmail:
						return _sRegistEmail;
					case RegistrationInstructions.TAG_MailingDtls:
						return _sMailingDtls;
					case RegistrationInstructions.TAG_MailingInst:
						return _sMailingInst;
					case RegistrationInstructions.TAG_NoNestedPartyIDs:
						return _iNoNestedPartyIDs;
					case RegistrationInstructions.TAG_OwnerType:
						return _iOwnerType;
					case RegistrationInstructions.TAG_DateOfBirth:
						return _dtDateOfBirth;
					case RegistrationInstructions.TAG_InvestorCountryOfResidence:
						return _sInvestorCountryOfResidence;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_RegistDtls:
						_sRegistDtls = (string)value;
						break;
					case RegistrationInstructions.TAG_RegistEmail:
						_sRegistEmail = (string)value;
						break;
					case RegistrationInstructions.TAG_MailingDtls:
						_sMailingDtls = (string)value;
						break;
					case RegistrationInstructions.TAG_MailingInst:
						_sMailingInst = (string)value;
						break;
					case RegistrationInstructions.TAG_NoNestedPartyIDs:
						_iNoNestedPartyIDs = (int)value;
						break;
					case RegistrationInstructions.TAG_OwnerType:
						_iOwnerType = (int)value;
						break;
					case RegistrationInstructions.TAG_DateOfBirth:
						_dtDateOfBirth = (DateTime)value;
						break;
					case RegistrationInstructions.TAG_InvestorCountryOfResidence:
						_sInvestorCountryOfResidence = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class RegistrationInstructionsRegistDtlList
	{
		private ArrayList _al;
		private RegistrationInstructionsRegistDtl _last;

		public RegistrationInstructionsRegistDtl this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (RegistrationInstructionsRegistDtl)_al[i];
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

		public void Add(RegistrationInstructionsRegistDtl item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(RegistrationInstructionsRegistDtl item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public RegistrationInstructionsRegistDtl Last
		{
			get { return _last; }
		}
	}

	public class RegistrationInstructionsNestedPartyID
	{
		private string _sNestedPartyID;
		private char _cNestedPartyIDSource;
		private int _iNestedPartyRole;
		private int _iNoNestedPartySubIDs;
		private RegistrationInstructionsNestedPartySubIDList _listNestedPartySubID = new RegistrationInstructionsNestedPartySubIDList();

		public string NestedPartyID
		{
			get { return _sNestedPartyID; }
			set { _sNestedPartyID = value; }
		}
		public char NestedPartyIDSource
		{
			get { return _cNestedPartyIDSource; }
			set { _cNestedPartyIDSource = value; }
		}
		public int NestedPartyRole
		{
			get { return _iNestedPartyRole; }
			set { _iNestedPartyRole = value; }
		}
		public int NoNestedPartySubIDs
		{
			get { return _iNoNestedPartySubIDs; }
			set { _iNoNestedPartySubIDs = value; }
		}
		public RegistrationInstructionsNestedPartySubIDList NestedPartySubID 
		{
			get { return _listNestedPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_NestedPartyID:
						return _sNestedPartyID;
					case RegistrationInstructions.TAG_NestedPartyIDSource:
						return _cNestedPartyIDSource;
					case RegistrationInstructions.TAG_NestedPartyRole:
						return _iNestedPartyRole;
					case RegistrationInstructions.TAG_NoNestedPartySubIDs:
						return _iNoNestedPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_NestedPartyID:
						_sNestedPartyID = (string)value;
						break;
					case RegistrationInstructions.TAG_NestedPartyIDSource:
						_cNestedPartyIDSource = (char)value;
						break;
					case RegistrationInstructions.TAG_NestedPartyRole:
						_iNestedPartyRole = (int)value;
						break;
					case RegistrationInstructions.TAG_NoNestedPartySubIDs:
						_iNoNestedPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class RegistrationInstructionsNestedPartyIDList
	{
		private ArrayList _al;
		private RegistrationInstructionsNestedPartyID _last;

		public RegistrationInstructionsNestedPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (RegistrationInstructionsNestedPartyID)_al[i];
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

		public void Add(RegistrationInstructionsNestedPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(RegistrationInstructionsNestedPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public RegistrationInstructionsNestedPartyID Last
		{
			get { return _last; }
		}
	}

	public class RegistrationInstructionsNestedPartySubID
	{
		private string _sNestedPartySubID;
		private int _iNestedPartySubIDType;

		public string NestedPartySubID
		{
			get { return _sNestedPartySubID; }
			set { _sNestedPartySubID = value; }
		}
		public int NestedPartySubIDType
		{
			get { return _iNestedPartySubIDType; }
			set { _iNestedPartySubIDType = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_NestedPartySubID:
						return _sNestedPartySubID;
					case RegistrationInstructions.TAG_NestedPartySubIDType:
						return _iNestedPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_NestedPartySubID:
						_sNestedPartySubID = (string)value;
						break;
					case RegistrationInstructions.TAG_NestedPartySubIDType:
						_iNestedPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class RegistrationInstructionsNestedPartySubIDList
	{
		private ArrayList _al;
		private RegistrationInstructionsNestedPartySubID _last;

		public RegistrationInstructionsNestedPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (RegistrationInstructionsNestedPartySubID)_al[i];
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

		public void Add(RegistrationInstructionsNestedPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(RegistrationInstructionsNestedPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public RegistrationInstructionsNestedPartySubID Last
		{
			get { return _last; }
		}
	}

	public class RegistrationInstructionsDistribInst
	{
		private int _iDistribPaymentMethod;
		private double _dDistribPercentage;
		private string _sCashDistribCurr;
		private string _sCashDistribAgentName;
		private string _sCashDistribAgentCode;
		private string _sCashDistribAgentAcctNumber;
		private string _sCashDistribPayRef;
		private string _sCashDistribAgentAcctName;

		public int DistribPaymentMethod
		{
			get { return _iDistribPaymentMethod; }
			set { _iDistribPaymentMethod = value; }
		}
		public double DistribPercentage
		{
			get { return _dDistribPercentage; }
			set { _dDistribPercentage = value; }
		}
		public string CashDistribCurr
		{
			get { return _sCashDistribCurr; }
			set { _sCashDistribCurr = value; }
		}
		public string CashDistribAgentName
		{
			get { return _sCashDistribAgentName; }
			set { _sCashDistribAgentName = value; }
		}
		public string CashDistribAgentCode
		{
			get { return _sCashDistribAgentCode; }
			set { _sCashDistribAgentCode = value; }
		}
		public string CashDistribAgentAcctNumber
		{
			get { return _sCashDistribAgentAcctNumber; }
			set { _sCashDistribAgentAcctNumber = value; }
		}
		public string CashDistribPayRef
		{
			get { return _sCashDistribPayRef; }
			set { _sCashDistribPayRef = value; }
		}
		public string CashDistribAgentAcctName
		{
			get { return _sCashDistribAgentAcctName; }
			set { _sCashDistribAgentAcctName = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_DistribPaymentMethod:
						return _iDistribPaymentMethod;
					case RegistrationInstructions.TAG_DistribPercentage:
						return _dDistribPercentage;
					case RegistrationInstructions.TAG_CashDistribCurr:
						return _sCashDistribCurr;
					case RegistrationInstructions.TAG_CashDistribAgentName:
						return _sCashDistribAgentName;
					case RegistrationInstructions.TAG_CashDistribAgentCode:
						return _sCashDistribAgentCode;
					case RegistrationInstructions.TAG_CashDistribAgentAcctNumber:
						return _sCashDistribAgentAcctNumber;
					case RegistrationInstructions.TAG_CashDistribPayRef:
						return _sCashDistribPayRef;
					case RegistrationInstructions.TAG_CashDistribAgentAcctName:
						return _sCashDistribAgentAcctName;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case RegistrationInstructions.TAG_DistribPaymentMethod:
						_iDistribPaymentMethod = (int)value;
						break;
					case RegistrationInstructions.TAG_DistribPercentage:
						_dDistribPercentage = (double)value;
						break;
					case RegistrationInstructions.TAG_CashDistribCurr:
						_sCashDistribCurr = (string)value;
						break;
					case RegistrationInstructions.TAG_CashDistribAgentName:
						_sCashDistribAgentName = (string)value;
						break;
					case RegistrationInstructions.TAG_CashDistribAgentCode:
						_sCashDistribAgentCode = (string)value;
						break;
					case RegistrationInstructions.TAG_CashDistribAgentAcctNumber:
						_sCashDistribAgentAcctNumber = (string)value;
						break;
					case RegistrationInstructions.TAG_CashDistribPayRef:
						_sCashDistribPayRef = (string)value;
						break;
					case RegistrationInstructions.TAG_CashDistribAgentAcctName:
						_sCashDistribAgentAcctName = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class RegistrationInstructionsDistribInstList
	{
		private ArrayList _al;
		private RegistrationInstructionsDistribInst _last;

		public RegistrationInstructionsDistribInst this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (RegistrationInstructionsDistribInst)_al[i];
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

		public void Add(RegistrationInstructionsDistribInst item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(RegistrationInstructionsDistribInst item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public RegistrationInstructionsDistribInst Last
		{
			get { return _last; }
		}
	}
}
