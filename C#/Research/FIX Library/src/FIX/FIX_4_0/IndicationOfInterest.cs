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

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_0
{
	/// <summary>
	/// Indication of interest messages are used to market merchandise which the broker is 
	/// buying or selling in either a proprietary or agency capacity.  The indications can 
	/// be time bound with a specific expiration value.  Indications are distributed with the 
	/// understanding that other firms may react to the message first and that the merchandise 
	/// may no longer be available due to prior trade.
	/// Indication messages can be transmitted in various transaction types; NEW, CANCEL, 
	/// and REPLACE.  All message types other than NEW modify the state of the message 
	/// identified in IOIRefID.
	/// </summary>
	public class IndicationOfInterest : Message
	{
		public const int TAG_IOIid = 23;
		public const int TAG_IOITransType = 28;
		public const int TAG_IOIRefID = 26;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_Issuer = 106;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_Side = 54;
		public const int TAG_IOIShares = 27;
		public const int TAG_Price = 44;
		public const int TAG_Currency = 15;
		public const int TAG_ValidUntilTime = 62;
		public const int TAG_IOIQltyInd = 25;
		public const int TAG_IOIOthSvc = 24;
		public const int TAG_IOINaturalFlag = 130;
		public const int TAG_IOIQualifier = 104;
		public const int TAG_Text = 58;

		private string _sIOIid;
		private char _cIOITransType;
		private string _sIOIRefID;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sIssuer;
		private string _sSecurityDesc;
		private char _cSide;
		private string _sIOIShares;
		private double _dPrice;
		private double _dCurrency;
		private DateTime _dtValidUntilTime;
		private char _cIOIQltyInd;
		private char _cIOIOthSvc;
		private bool _bIOINaturalFlag;
		private char _cIOIQualifier;
		private string _sText;

		internal IndicationOfInterest() : base()
		{
			_sMsgType = Values.MsgType.IndicationOfInterest;
		}

		public string IOIid
		{
			get { return _sIOIid; }
			set { _sIOIid = value; }
		}
		public char IOITransType
		{
			get { return _cIOITransType; }
			set { _cIOITransType = value; }
		}
		public string IOIRefID
		{
			get { return _sIOIRefID; }
			set { _sIOIRefID = value; }
		}
		public string Symbol
		{
			get { return _sSymbol; }
			set { _sSymbol = value; }
		}
		public string SymbolSfx
		{
			get { return _sSymbolSfx; }
			set { _sSymbolSfx = value; }
		}
		public string SecurityID
		{
			get { return _sSecurityID; }
			set { _sSecurityID = value; }
		}
		public string IDSource
		{
			get { return _sIDSource; }
			set { _sIDSource = value; }
		}
		public string Issuer
		{
			get { return _sIssuer; }
			set { _sIssuer = value; }
		}
		public string SecurityDesc
		{
			get { return _sSecurityDesc; }
			set { _sSecurityDesc = value; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
		}
		public string IOIShares
		{
			get { return _sIOIShares; }
			set { _sIOIShares = value; }
		}
		public double Price
		{
			get { return _dPrice; }
			set { _dPrice = value; }
		}
		public double Currency
		{
			get { return _dCurrency; }
			set { _dCurrency = value; }
		}
		public DateTime ValidUntilTime
		{
			get { return _dtValidUntilTime; }
			set { _dtValidUntilTime = value; }
		}
		public char IOIQltyInd
		{
			get { return _cIOIQltyInd; }
			set { _cIOIQltyInd = value; }
		}
		public char IOIOthSvc
		{
			get { return _cIOIOthSvc; }
			set { _cIOIOthSvc = value; }
		}
		public bool IOINaturalFlag
		{
			get { return _bIOINaturalFlag; }
			set { _bIOINaturalFlag = value; }
		}
		public char IOIQualifier
		{
			get { return _cIOIQualifier; }
			set { _cIOIQualifier = value; }
		}
		public string Text
		{
			get { return _sText; }
			set { _sText = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				if (iTag == TAG_IOIid)
					return _sIOIid;
				else if (iTag == TAG_IOITransType)
					return _cIOITransType;
				else if (iTag == TAG_IOIRefID)
					return _sIOIRefID;
				else if (iTag == TAG_Symbol)
					return _sSymbol;
				else if (iTag == TAG_SymbolSfx)
					return _sSymbolSfx;
				else if (iTag == TAG_SecurityID)
					return _sSecurityID;
				else if (iTag == TAG_IDSource)
					return _sIDSource;
				else if (iTag == TAG_Issuer)
					return _sIssuer;
				else if (iTag == TAG_SecurityDesc)
					return _sSecurityDesc;
				else if (iTag == TAG_Side)
					return _cSide;
				else if (iTag == TAG_IOIShares)
					return _sIOIShares;
				else if (iTag == TAG_Price)
					return _dPrice;
				else if (iTag == TAG_Currency)
					return _dCurrency;
				else if (iTag == TAG_ValidUntilTime)
					return _dtValidUntilTime;
				else if (iTag == TAG_IOIQltyInd)
					return _cIOIQltyInd;
				else if (iTag == TAG_IOIOthSvc)
					return _cIOIOthSvc;
				else if (iTag == TAG_IOINaturalFlag)
					return _bIOINaturalFlag;
				else if (iTag == TAG_IOIQualifier)
					return _cIOIQualifier;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_IOIid)
					_sIOIid = (string)value;
				else if (iTag == TAG_IOITransType)
					_cIOITransType = (char)value;
				else if (iTag == TAG_IOIRefID)
					_sIOIRefID = (string)value;
				else if (iTag == TAG_Symbol)
					_sSymbol = (string)value;
				else if (iTag == TAG_SymbolSfx)
					_sSymbolSfx = (string)value;
				else if (iTag == TAG_SecurityID)
					_sSecurityID = (string)value;
				else if (iTag == TAG_IDSource)
					_sIDSource = (string)value;
				else if (iTag == TAG_Issuer)
					_sIssuer = (string)value;
				else if (iTag == TAG_SecurityDesc)
					_sSecurityDesc = (string)value;
				else if (iTag == TAG_Side)
					_cSide = (char)value;
				else if (iTag == TAG_IOIShares)
					_sIOIShares = (string)value;
				else if (iTag == TAG_Price)
					_dPrice = (double)value;
				else if (iTag == TAG_Currency)
					_dCurrency = (double)value;
				else if (iTag == TAG_ValidUntilTime)
					_dtValidUntilTime = (DateTime)value;
				else if (iTag == TAG_IOIQltyInd)
					_cIOIQltyInd = (char)value;
				else if (iTag == TAG_IOIOthSvc)
					_cIOIOthSvc = (char)value;
				else if (iTag == TAG_IOINaturalFlag)
					_bIOINaturalFlag = (bool)value;
				else if (iTag == TAG_IOIQualifier)
					_cIOIQualifier = (char)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}
	}
}
