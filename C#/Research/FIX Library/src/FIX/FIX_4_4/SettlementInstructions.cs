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
	/// Summary description for SettlementInstructions.
	/// </summary>
	public class SettlementInstructions : Message
	{
		public const int TAG_SettlInstMsgID = 777;
		public const int TAG_SettlInstReqID = 791;
		public const int TAG_SettlInstMode = 160;
		public const int TAG_SettlInstReqRejCode = 792;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_SettlInstSource = 165;
		public const int TAG_ClOrdID = 11;
		public const int TAG_TransactTime = 60;
		public const int TAG_NoSettlInst = 778;
		public const int TAG_SettlInstID = 162;
		public const int TAG_SettlInstTransType = 163;
		public const int TAG_SettlInstRefID = 214;
		public const int TAG_NoPartyIDs = 453;
		public const int TAG_PartyID = 448;
		public const int TAG_PartyIDSource = 447;
		public const int TAG_PartyRole = 452;
		public const int TAG_NoPartySubIDs = 802;
		public const int TAG_PartySubID = 523;
		public const int TAG_PartySubIDType = 803;
		public const int TAG_Side = 54;
		public const int TAG_Product = 460;
		public const int TAG_SecurityType = 167;
		public const int TAG_CFICode = 461;
		public const int TAG_EffectiveTime = 168;
		public const int TAG_ExpireTime = 126;
		public const int TAG_LastUpdateTime = 779;
		public const int TAG_SettlDeliveryType = 172;
		public const int TAG_StandInstDbType = 169;
		public const int TAG_StandInstDbName = 170;
		public const int TAG_StandInstDbID = 171;
		public const int TAG_NoDlvyInst = 85;
		public const int TAG_DlvyInstType = 787;
		public const int TAG_NoSettlPartyIDs = 781;
		public const int TAG_SettlPartyID = 782;
		public const int TAG_SettlPartyIDSource = 783;
		public const int TAG_SettlPartyRole = 784;
		public const int TAG_NoSettlPartySubIDs = 801;
		public const int TAG_SettlPartySubID = 785;
		public const int TAG_SettlPartySubIDType = 786;
		public const int TAG_PaymentMethod = 492;
		public const int TAG_PaymentRef = 476;
		public const int TAG_CardHolderName = 488;
		public const int TAG_CardNumber = 489;
		public const int TAG_CardStartDate = 503;
		public const int TAG_CardExpDate = 490;
		public const int TAG_CardIssNum = 491;
		public const int TAG_PaymentDate = 504;
		public const int TAG_PaymentRemitterID = 505;

		private string _sSettlInstMsgID;
		private string _sSettlInstReqID;
		private char _cSettlInstMode;
		private int _iSettlInstReqRejCode;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private char _cSettlInstSource;
		private string _sClOrdID;
		private DateTime _dtTransactTime;
		private int _iNoSettlInst;
		private SettlementInstructionsSettlInstList _listSettlInst = new SettlementInstructionsSettlInstList();

		public SettlementInstructions() : base()
		{
			_sMsgType = Values.MsgType.SettlementInstructions;
		}

		public string SettlInstMsgID
		{
			get { return _sSettlInstMsgID; }
			set { _sSettlInstMsgID = value; }
		}
		public string SettlInstReqID
		{
			get { return _sSettlInstReqID; }
			set { _sSettlInstReqID = value; }
		}
		public char SettlInstMode
		{
			get { return _cSettlInstMode; }
			set { _cSettlInstMode = value; }
		}
		public int SettlInstReqRejCode
		{
			get { return _iSettlInstReqRejCode; }
			set { _iSettlInstReqRejCode = value; }
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
		public char SettlInstSource
		{
			get { return _cSettlInstSource; }
			set { _cSettlInstSource = value; }
		}
		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public DateTime TransactTime
		{
			get { return _dtTransactTime; }
			set { _dtTransactTime = value; }
		}
		public int NoSettlInst
		{
			get { return _iNoSettlInst; }
			set { _iNoSettlInst = value; }
		}
		public SettlementInstructionsSettlInstList SettlInst 
		{
			get { return _listSettlInst; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_SettlInstMsgID:
						return _sSettlInstMsgID;
					case TAG_SettlInstReqID:
						return _sSettlInstReqID;
					case TAG_SettlInstMode:
						return _cSettlInstMode;
					case TAG_SettlInstReqRejCode:
						return _iSettlInstReqRejCode;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
					case TAG_SettlInstSource:
						return _cSettlInstSource;
					case TAG_ClOrdID:
						return _sClOrdID;
					case TAG_TransactTime:
						return _dtTransactTime;
					case TAG_NoSettlInst:
						return _iNoSettlInst;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_SettlInstMsgID:
						_sSettlInstMsgID = (string)value;
						break;
					case TAG_SettlInstReqID:
						_sSettlInstReqID = (string)value;
						break;
					case TAG_SettlInstMode:
						_cSettlInstMode = (char)value;
						break;
					case TAG_SettlInstReqRejCode:
						_iSettlInstReqRejCode = (int)value;
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
					case TAG_SettlInstSource:
						_cSettlInstSource = (char)value;
						break;
					case TAG_ClOrdID:
						_sClOrdID = (string)value;
						break;
					case TAG_TransactTime:
						_dtTransactTime = (DateTime)value;
						break;
					case TAG_NoSettlInst:
						_iNoSettlInst = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class SettlementInstructionsSettlInst
	{
		private string _sSettlInstID;
		private char _cSettlInstTransType;
		private string _sSettlInstRefID;
		private int _iNoPartyIDs;
		private SettlementInstructionsPartyIDList _listPartyID = new SettlementInstructionsPartyIDList();
		private char _cSide;
		private int _iProduct;
		private string _sSecurityType;
		private string _sCFICode;
		private DateTime _dtEffectiveTime;
		private DateTime _dtExpireTime;
		private DateTime _dtLastUpdateTime;
		private int _iSettlDeliveryType;
		private int _iStandInstDbType;
		private string _sStandInstDbName;
		private string _sStandInstDbID;
		private int _iNoDlvyInst;
		private SettlementInstructionsDlvyInstList _listDlvyInst = new SettlementInstructionsDlvyInstList();
		private int _iPaymentMethod;
		private string _sPaymentRef;
		private string _sCardHolderName;
		private string _sCardNumber;
		private DateTime _dtCardStartDate;
		private DateTime _dtCardExpDate;
		private string _sCardIssNum;
		private DateTime _dtPaymentDate;
		private string _sPaymentRemitterID;

		public string SettlInstID
		{
			get { return _sSettlInstID; }
			set { _sSettlInstID = value; }
		}
		public char SettlInstTransType
		{
			get { return _cSettlInstTransType; }
			set { _cSettlInstTransType = value; }
		}
		public string SettlInstRefID
		{
			get { return _sSettlInstRefID; }
			set { _sSettlInstRefID = value; }
		}
		public int NoPartyIDs
		{
			get { return _iNoPartyIDs; }
			set { _iNoPartyIDs = value; }
		}
		public SettlementInstructionsPartyIDList PartyID 
		{
			get { return _listPartyID; }
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
		public int SettlDeliveryType
		{
			get { return _iSettlDeliveryType; }
			set { _iSettlDeliveryType = value; }
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
		public int NoDlvyInst
		{
			get { return _iNoDlvyInst; }
			set { _iNoDlvyInst = value; }
		}
		public SettlementInstructionsDlvyInstList DlvyInst 
		{
			get { return _listDlvyInst; }
		}
		public int PaymentMethod
		{
			get { return _iPaymentMethod; }
			set { _iPaymentMethod = value; }
		}
		public string PaymentRef
		{
			get { return _sPaymentRef; }
			set { _sPaymentRef = value; }
		}
		public string CardHolderName
		{
			get { return _sCardHolderName; }
			set { _sCardHolderName = value; }
		}
		public string CardNumber
		{
			get { return _sCardNumber; }
			set { _sCardNumber = value; }
		}
		public DateTime CardStartDate
		{
			get { return _dtCardStartDate; }
			set { _dtCardStartDate = value; }
		}
		public DateTime CardExpDate
		{
			get { return _dtCardExpDate; }
			set { _dtCardExpDate = value; }
		}
		public string CardIssNum
		{
			get { return _sCardIssNum; }
			set { _sCardIssNum = value; }
		}
		public DateTime PaymentDate
		{
			get { return _dtPaymentDate; }
			set { _dtPaymentDate = value; }
		}
		public string PaymentRemitterID
		{
			get { return _sPaymentRemitterID; }
			set { _sPaymentRemitterID = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_SettlInstID:
						return _sSettlInstID;
					case SettlementInstructions.TAG_SettlInstTransType:
						return _cSettlInstTransType;
					case SettlementInstructions.TAG_SettlInstRefID:
						return _sSettlInstRefID;
					case SettlementInstructions.TAG_NoPartyIDs:
						return _iNoPartyIDs;
					case SettlementInstructions.TAG_Side:
						return _cSide;
					case SettlementInstructions.TAG_Product:
						return _iProduct;
					case SettlementInstructions.TAG_SecurityType:
						return _sSecurityType;
					case SettlementInstructions.TAG_CFICode:
						return _sCFICode;
					case SettlementInstructions.TAG_EffectiveTime:
						return _dtEffectiveTime;
					case SettlementInstructions.TAG_ExpireTime:
						return _dtExpireTime;
					case SettlementInstructions.TAG_LastUpdateTime:
						return _dtLastUpdateTime;
					case SettlementInstructions.TAG_SettlDeliveryType:
						return _iSettlDeliveryType;
					case SettlementInstructions.TAG_StandInstDbType:
						return _iStandInstDbType;
					case SettlementInstructions.TAG_StandInstDbName:
						return _sStandInstDbName;
					case SettlementInstructions.TAG_StandInstDbID:
						return _sStandInstDbID;
					case SettlementInstructions.TAG_NoDlvyInst:
						return _iNoDlvyInst;
					case SettlementInstructions.TAG_PaymentMethod:
						return _iPaymentMethod;
					case SettlementInstructions.TAG_PaymentRef:
						return _sPaymentRef;
					case SettlementInstructions.TAG_CardHolderName:
						return _sCardHolderName;
					case SettlementInstructions.TAG_CardNumber:
						return _sCardNumber;
					case SettlementInstructions.TAG_CardStartDate:
						return _dtCardStartDate;
					case SettlementInstructions.TAG_CardExpDate:
						return _dtCardExpDate;
					case SettlementInstructions.TAG_CardIssNum:
						return _sCardIssNum;
					case SettlementInstructions.TAG_PaymentDate:
						return _dtPaymentDate;
					case SettlementInstructions.TAG_PaymentRemitterID:
						return _sPaymentRemitterID;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_SettlInstID:
						_sSettlInstID = (string)value;
						break;
					case SettlementInstructions.TAG_SettlInstTransType:
						_cSettlInstTransType = (char)value;
						break;
					case SettlementInstructions.TAG_SettlInstRefID:
						_sSettlInstRefID = (string)value;
						break;
					case SettlementInstructions.TAG_NoPartyIDs:
						_iNoPartyIDs = (int)value;
						break;
					case SettlementInstructions.TAG_Side:
						_cSide = (char)value;
						break;
					case SettlementInstructions.TAG_Product:
						_iProduct = (int)value;
						break;
					case SettlementInstructions.TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case SettlementInstructions.TAG_CFICode:
						_sCFICode = (string)value;
						break;
					case SettlementInstructions.TAG_EffectiveTime:
						_dtEffectiveTime = (DateTime)value;
						break;
					case SettlementInstructions.TAG_ExpireTime:
						_dtExpireTime = (DateTime)value;
						break;
					case SettlementInstructions.TAG_LastUpdateTime:
						_dtLastUpdateTime = (DateTime)value;
						break;
					case SettlementInstructions.TAG_SettlDeliveryType:
						_iSettlDeliveryType = (int)value;
						break;
					case SettlementInstructions.TAG_StandInstDbType:
						_iStandInstDbType = (int)value;
						break;
					case SettlementInstructions.TAG_StandInstDbName:
						_sStandInstDbName = (string)value;
						break;
					case SettlementInstructions.TAG_StandInstDbID:
						_sStandInstDbID = (string)value;
						break;
					case SettlementInstructions.TAG_NoDlvyInst:
						_iNoDlvyInst = (int)value;
						break;
					case SettlementInstructions.TAG_PaymentMethod:
						_iPaymentMethod = (int)value;
						break;
					case SettlementInstructions.TAG_PaymentRef:
						_sPaymentRef = (string)value;
						break;
					case SettlementInstructions.TAG_CardHolderName:
						_sCardHolderName = (string)value;
						break;
					case SettlementInstructions.TAG_CardNumber:
						_sCardNumber = (string)value;
						break;
					case SettlementInstructions.TAG_CardStartDate:
						_dtCardStartDate = (DateTime)value;
						break;
					case SettlementInstructions.TAG_CardExpDate:
						_dtCardExpDate = (DateTime)value;
						break;
					case SettlementInstructions.TAG_CardIssNum:
						_sCardIssNum = (string)value;
						break;
					case SettlementInstructions.TAG_PaymentDate:
						_dtPaymentDate = (DateTime)value;
						break;
					case SettlementInstructions.TAG_PaymentRemitterID:
						_sPaymentRemitterID = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SettlementInstructionsSettlInstList
	{
		private ArrayList _al;
		private SettlementInstructionsSettlInst _last;

		public SettlementInstructionsSettlInst this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SettlementInstructionsSettlInst)_al[i];
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

		public void Add(SettlementInstructionsSettlInst item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SettlementInstructionsSettlInst item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SettlementInstructionsSettlInst Last
		{
			get { return _last; }
		}
	}

	public class SettlementInstructionsPartyID
	{
		private string _sPartyID;
		private char _cPartyIDSource;
		private int _iPartyRole;
		private int _iNoPartySubIDs;
		private SettlementInstructionsPartySubIDList _listPartySubID = new SettlementInstructionsPartySubIDList();

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
		public SettlementInstructionsPartySubIDList PartySubID 
		{
			get { return _listPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_PartyID:
						return _sPartyID;
					case SettlementInstructions.TAG_PartyIDSource:
						return _cPartyIDSource;
					case SettlementInstructions.TAG_PartyRole:
						return _iPartyRole;
					case SettlementInstructions.TAG_NoPartySubIDs:
						return _iNoPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_PartyID:
						_sPartyID = (string)value;
						break;
					case SettlementInstructions.TAG_PartyIDSource:
						_cPartyIDSource = (char)value;
						break;
					case SettlementInstructions.TAG_PartyRole:
						_iPartyRole = (int)value;
						break;
					case SettlementInstructions.TAG_NoPartySubIDs:
						_iNoPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SettlementInstructionsPartyIDList
	{
		private ArrayList _al;
		private SettlementInstructionsPartyID _last;

		public SettlementInstructionsPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SettlementInstructionsPartyID)_al[i];
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

		public void Add(SettlementInstructionsPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SettlementInstructionsPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SettlementInstructionsPartyID Last
		{
			get { return _last; }
		}
	}

	public class SettlementInstructionsPartySubID
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
					case SettlementInstructions.TAG_PartySubID:
						return _sPartySubID;
					case SettlementInstructions.TAG_PartySubIDType:
						return _iPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_PartySubID:
						_sPartySubID = (string)value;
						break;
					case SettlementInstructions.TAG_PartySubIDType:
						_iPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SettlementInstructionsPartySubIDList
	{
		private ArrayList _al;
		private SettlementInstructionsPartySubID _last;

		public SettlementInstructionsPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SettlementInstructionsPartySubID)_al[i];
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

		public void Add(SettlementInstructionsPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SettlementInstructionsPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SettlementInstructionsPartySubID Last
		{
			get { return _last; }
		}
	}

	public class SettlementInstructionsDlvyInst
	{
		private char _cSettlInstSource;
		private char _cDlvyInstType;
		private int _iNoSettlPartyIDs;
		private SettlementInstructionsSettlPartyIDList _listSettlPartyID = new SettlementInstructionsSettlPartyIDList();

		public char SettlInstSource
		{
			get { return _cSettlInstSource; }
			set { _cSettlInstSource = value; }
		}
		public char DlvyInstType
		{
			get { return _cDlvyInstType; }
			set { _cDlvyInstType = value; }
		}
		public int NoSettlPartyIDs
		{
			get { return _iNoSettlPartyIDs; }
			set { _iNoSettlPartyIDs = value; }
		}
		public SettlementInstructionsSettlPartyIDList SettlPartyID 
		{
			get { return _listSettlPartyID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_SettlInstSource:
						return _cSettlInstSource;
					case SettlementInstructions.TAG_DlvyInstType:
						return _cDlvyInstType;
					case SettlementInstructions.TAG_NoSettlPartyIDs:
						return _iNoSettlPartyIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_SettlInstSource:
						_cSettlInstSource = (char)value;
						break;
					case SettlementInstructions.TAG_DlvyInstType:
						_cDlvyInstType = (char)value;
						break;
					case SettlementInstructions.TAG_NoSettlPartyIDs:
						_iNoSettlPartyIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SettlementInstructionsDlvyInstList
	{
		private ArrayList _al;
		private SettlementInstructionsDlvyInst _last;

		public SettlementInstructionsDlvyInst this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SettlementInstructionsDlvyInst)_al[i];
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

		public void Add(SettlementInstructionsDlvyInst item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SettlementInstructionsDlvyInst item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SettlementInstructionsDlvyInst Last
		{
			get { return _last; }
		}
	}

	public class SettlementInstructionsSettlPartyID
	{
		private string _sSettlPartyID;
		private char _cSettlPartyIDSource;
		private int _iSettlPartyRole;
		private int _iNoSettlPartySubIDs;
		private SettlementInstructionsSettlPartySubIDList _listSettlPartySubID = new SettlementInstructionsSettlPartySubIDList();

		public string SettlPartyID
		{
			get { return _sSettlPartyID; }
			set { _sSettlPartyID = value; }
		}
		public char SettlPartyIDSource
		{
			get { return _cSettlPartyIDSource; }
			set { _cSettlPartyIDSource = value; }
		}
		public int SettlPartyRole
		{
			get { return _iSettlPartyRole; }
			set { _iSettlPartyRole = value; }
		}
		public int NoSettlPartySubIDs
		{
			get { return _iNoSettlPartySubIDs; }
			set { _iNoSettlPartySubIDs = value; }
		}
		public SettlementInstructionsSettlPartySubIDList SettlPartySubID 
		{
			get { return _listSettlPartySubID; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_SettlPartyID:
						return _sSettlPartyID;
					case SettlementInstructions.TAG_SettlPartyIDSource:
						return _cSettlPartyIDSource;
					case SettlementInstructions.TAG_SettlPartyRole:
						return _iSettlPartyRole;
					case SettlementInstructions.TAG_NoSettlPartySubIDs:
						return _iNoSettlPartySubIDs;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_SettlPartyID:
						_sSettlPartyID = (string)value;
						break;
					case SettlementInstructions.TAG_SettlPartyIDSource:
						_cSettlPartyIDSource = (char)value;
						break;
					case SettlementInstructions.TAG_SettlPartyRole:
						_iSettlPartyRole = (int)value;
						break;
					case SettlementInstructions.TAG_NoSettlPartySubIDs:
						_iNoSettlPartySubIDs = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SettlementInstructionsSettlPartyIDList
	{
		private ArrayList _al;
		private SettlementInstructionsSettlPartyID _last;

		public SettlementInstructionsSettlPartyID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SettlementInstructionsSettlPartyID)_al[i];
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

		public void Add(SettlementInstructionsSettlPartyID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SettlementInstructionsSettlPartyID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SettlementInstructionsSettlPartyID Last
		{
			get { return _last; }
		}
	}

	public class SettlementInstructionsSettlPartySubID
	{
		private string _sSettlPartySubID;
		private int _iSettlPartySubIDType;

		public string SettlPartySubID
		{
			get { return _sSettlPartySubID; }
			set { _sSettlPartySubID = value; }
		}
		public int SettlPartySubIDType
		{
			get { return _iSettlPartySubIDType; }
			set { _iSettlPartySubIDType = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_SettlPartySubID:
						return _sSettlPartySubID;
					case SettlementInstructions.TAG_SettlPartySubIDType:
						return _iSettlPartySubIDType;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SettlementInstructions.TAG_SettlPartySubID:
						_sSettlPartySubID = (string)value;
						break;
					case SettlementInstructions.TAG_SettlPartySubIDType:
						_iSettlPartySubIDType = (int)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SettlementInstructionsSettlPartySubIDList
	{
		private ArrayList _al;
		private SettlementInstructionsSettlPartySubID _last;

		public SettlementInstructionsSettlPartySubID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SettlementInstructionsSettlPartySubID)_al[i];
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

		public void Add(SettlementInstructionsSettlPartySubID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SettlementInstructionsSettlPartySubID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SettlementInstructionsSettlPartySubID Last
		{
			get { return _last; }
		}
	}
}
