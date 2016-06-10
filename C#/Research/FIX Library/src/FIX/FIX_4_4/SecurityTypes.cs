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
	/// Summary description for SecurityTypes.
	/// </summary>
	public class SecurityTypes : Message
	{
		public const int TAG_SecurityReqID = 320;
		public const int TAG_SecurityResponseID = 322;
		public const int TAG_SecurityResponseType = 323;
		public const int TAG_TotNoSecurityTypes = 557;
		public const int TAG_LastFragment = 893;
		public const int TAG_NoSecurityTypes = 558;
		public const int TAG_SecurityType = 167;
		public const int TAG_SecuritySubType = 762;
		public const int TAG_Product = 460;
		public const int TAG_CFICode = 461;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_SubscriptionRequestType = 263;

		private string _sSecurityReqID;
		private string _sSecurityResponseID;
		private int _iSecurityResponseType;
		private int _iTotNoSecurityTypes;
		private bool _bLastFragment;
		private int _iNoSecurityTypes;
		private SecurityTypesSecurityTypeList _listSecurityType = new SecurityTypesSecurityTypeList();
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private char _cSubscriptionRequestType;

		public SecurityTypes() : base()
		{
			_sMsgType = Values.MsgType.SecurityTypes;
		}

		public string SecurityReqID
		{
			get { return _sSecurityReqID; }
			set { _sSecurityReqID = value; }
		}
		public string SecurityResponseID
		{
			get { return _sSecurityResponseID; }
			set { _sSecurityResponseID = value; }
		}
		public int SecurityResponseType
		{
			get { return _iSecurityResponseType; }
			set { _iSecurityResponseType = value; }
		}
		public int TotNoSecurityTypes
		{
			get { return _iTotNoSecurityTypes; }
			set { _iTotNoSecurityTypes = value; }
		}
		public bool LastFragment
		{
			get { return _bLastFragment; }
			set { _bLastFragment = value; }
		}
		public int NoSecurityTypes
		{
			get { return _iNoSecurityTypes; }
			set { _iNoSecurityTypes = value; }
		}
		public SecurityTypesSecurityTypeList SecurityType 
		{
			get { return _listSecurityType; }
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
		public string TradingSessionID
		{
			get { return _sTradingSessionID; }
			set { _sTradingSessionID = value; }
		}
		public string TradingSessionSubID
		{
			get { return _sTradingSessionSubID; }
			set { _sTradingSessionSubID = value; }
		}
		public char SubscriptionRequestType
		{
			get { return _cSubscriptionRequestType; }
			set { _cSubscriptionRequestType = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_SecurityReqID:
						return _sSecurityReqID;
					case TAG_SecurityResponseID:
						return _sSecurityResponseID;
					case TAG_SecurityResponseType:
						return _iSecurityResponseType;
					case TAG_TotNoSecurityTypes:
						return _iTotNoSecurityTypes;
					case TAG_LastFragment:
						return _bLastFragment;
					case TAG_NoSecurityTypes:
						return _iNoSecurityTypes;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
					case TAG_TradingSessionID:
						return _sTradingSessionID;
					case TAG_TradingSessionSubID:
						return _sTradingSessionSubID;
					case TAG_SubscriptionRequestType:
						return _cSubscriptionRequestType;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_SecurityReqID:
						_sSecurityReqID = (string)value;
						break;
					case TAG_SecurityResponseID:
						_sSecurityResponseID = (string)value;
						break;
					case TAG_SecurityResponseType:
						_iSecurityResponseType = (int)value;
						break;
					case TAG_TotNoSecurityTypes:
						_iTotNoSecurityTypes = (int)value;
						break;
					case TAG_LastFragment:
						_bLastFragment = (bool)value;
						break;
					case TAG_NoSecurityTypes:
						_iNoSecurityTypes = (int)value;
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
					case TAG_TradingSessionID:
						_sTradingSessionID = (string)value;
						break;
					case TAG_TradingSessionSubID:
						_sTradingSessionSubID = (string)value;
						break;
					case TAG_SubscriptionRequestType:
						_cSubscriptionRequestType = (char)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class SecurityTypesSecurityType
	{
		private string _sSecurityType;
		private string _sSecuritySubType;
		private int _iProduct;
		private string _sCFICode;

		public string SecurityType
		{
			get { return _sSecurityType; }
			set { _sSecurityType = value; }
		}
		public string SecuritySubType
		{
			get { return _sSecuritySubType; }
			set { _sSecuritySubType = value; }
		}
		public int Product
		{
			get { return _iProduct; }
			set { _iProduct = value; }
		}
		public string CFICode
		{
			get { return _sCFICode; }
			set { _sCFICode = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case SecurityTypes.TAG_SecurityType:
						return _sSecurityType;
					case SecurityTypes.TAG_SecuritySubType:
						return _sSecuritySubType;
					case SecurityTypes.TAG_Product:
						return _iProduct;
					case SecurityTypes.TAG_CFICode:
						return _sCFICode;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case SecurityTypes.TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case SecurityTypes.TAG_SecuritySubType:
						_sSecuritySubType = (string)value;
						break;
					case SecurityTypes.TAG_Product:
						_iProduct = (int)value;
						break;
					case SecurityTypes.TAG_CFICode:
						_sCFICode = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class SecurityTypesSecurityTypeList
	{
		private ArrayList _al;
		private SecurityTypesSecurityType _last;

		public SecurityTypesSecurityType this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (SecurityTypesSecurityType)_al[i];
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

		public void Add(SecurityTypesSecurityType item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(SecurityTypesSecurityType item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public SecurityTypesSecurityType Last
		{
			get { return _last; }
		}
	}
}
