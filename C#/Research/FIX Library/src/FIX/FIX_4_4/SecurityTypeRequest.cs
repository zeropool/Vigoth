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
	/// Summary description for SecurityTypeRequest.
	/// </summary>
	public class SecurityTypeRequest : Message
	{
		public const int TAG_SecurityReqID = 320;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;
		public const int TAG_TradingSessionID = 336;
		public const int TAG_TradingSessionSubID = 625;
		public const int TAG_Product = 460;
		public const int TAG_SecurityType = 167;
		public const int TAG_SecuritySubType = 762;

		private string _sSecurityReqID;
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;
		private string _sTradingSessionID;
		private string _sTradingSessionSubID;
		private int _iProduct;
		private string _sSecurityType;
		private string _sSecuritySubType;

		public SecurityTypeRequest() : base()
		{
			_sMsgType = Values.MsgType.SecurityTypeRequest;
		}

		public string SecurityReqID
		{
			get { return _sSecurityReqID; }
			set { _sSecurityReqID = value; }
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
		public string SecuritySubType
		{
			get { return _sSecuritySubType; }
			set { _sSecuritySubType = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_SecurityReqID:
						return _sSecurityReqID;
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
					case TAG_Product:
						return _iProduct;
					case TAG_SecurityType:
						return _sSecurityType;
					case TAG_SecuritySubType:
						return _sSecuritySubType;
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
					case TAG_Product:
						_iProduct = (int)value;
						break;
					case TAG_SecurityType:
						_sSecurityType = (string)value;
						break;
					case TAG_SecuritySubType:
						_sSecuritySubType = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}
}
