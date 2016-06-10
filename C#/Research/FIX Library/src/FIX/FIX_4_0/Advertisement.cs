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
	/// Advertisement messages are used to announce completed transactions.  
	/// The advertisement message can be transmitted in various transaction types; NEW, CANCEL and REPLACE.  
	/// All message types other than NEW modify the state of a previously transmitted advertisement identified in AdvRefID.
	/// </summary>
	public class Advertisement : Message
	{
		public const int TAG_AdvId = 2;
		public const int TAG_AdvTransType = 5;
		public const int TAG_AdvRefID = 3;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_Issuer = 106;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_AdvSide = 4;
		public const int TAG_Shares = 53;
		public const int TAG_Price = 44;
		public const int TAG_Currency = 15;
		public const int TAG_TransactTime = 60;
		public const int TAG_Text = 58;

		private int _iAdvId;
		private char _cAdvTransType;
		private int _iAdvRefID;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sIssuer;
		private string _sSecurityDesc;
		private char _cAdvSide;
		private int _iShares;
		private double _dPrice;
		private string _sCurrency;
		private DateTime _dtTransactTime;
		private string _sText;

		internal Advertisement() : base()
		{
			_sMsgType = Values.MsgType.Advertisement;
		}

		public int AdvId 
		{ 
			get { return _iAdvId; } 
			set { _iAdvId = value; } 
		}
		public char AdvTransType 
		{ 
			get { return _cAdvTransType; } 
			set { _cAdvTransType = value; } 
		}
		public int AdvRefID 
		{ 
			get { return _iAdvRefID; } 
			set { _iAdvRefID = value; } 
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
		public char AdvSide 
		{ 
			get { return _cAdvSide; } 
			set { _cAdvSide = value; } 
		}
		public int Shares 
		{ 
			get { return _iShares; } 
			set { _iShares = value; } 
		}
		public double Price 
		{ 
			get { return _dPrice; } 
			set { _dPrice = value; } 
		}
		public string Currency 
		{ 
			get { return _sCurrency; } 
			set { _sCurrency = value; } 
		}
		public DateTime TransactTime 
		{ 
			get { return _dtTransactTime; } 
			set { _dtTransactTime = value; } 
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
				if(iTag == TAG_AdvId)
					return _iAdvId;
				else if(iTag == TAG_AdvTransType)
					return _cAdvTransType;
				else if(iTag == TAG_AdvRefID)
					return _iAdvRefID;
				else if(iTag == TAG_Symbol)
					return _sSymbol;
				else if(iTag == TAG_SymbolSfx)
					return _sSymbolSfx;
				else if(iTag == TAG_SecurityID)
					return _sSecurityID;
				else if(iTag == TAG_IDSource)
					return _sIDSource;
				else if(iTag == TAG_Issuer)
					return _sIssuer;
				else if(iTag == TAG_SecurityDesc)
					return _sSecurityDesc;
				else if(iTag == TAG_AdvSide)
					return _cAdvSide;
				else if(iTag == TAG_Shares)
					return _iShares;
				else if(iTag == TAG_Price)
					return _dPrice;
				else if(iTag == TAG_Currency)
					return _sCurrency;
				else if(iTag == TAG_TransactTime)
					return _dtTransactTime;
				else if(iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if(iTag == TAG_AdvId) 
					_iAdvId = (int) value;
				else if(iTag == TAG_AdvTransType) 
					_cAdvTransType = (char) value;
				else if(iTag == TAG_AdvRefID) 
					_iAdvRefID = (int) value;
				else if(iTag == TAG_Symbol)
					_sSymbol = (string) value;
				else if(iTag == TAG_SymbolSfx)
					_sSymbolSfx = (string) value;
				else if(iTag == TAG_SecurityID)
					_sSecurityID = (string) value;
				else if(iTag == TAG_IDSource)
					_sIDSource = (string) value;
				else if(iTag == TAG_Issuer)
					_sIssuer = (string) value;
				else if(iTag == TAG_SecurityDesc)
					_sSecurityDesc = (string) value;
				else if(iTag == TAG_AdvSide)
					_cAdvSide = (char) value;
				else if(iTag == TAG_Shares)
					_iShares = (int) value;
				else if(iTag == TAG_Price)
					_dPrice = (double) value;
				else if(iTag == TAG_Currency)
					_sCurrency = (string) value;
				else if(iTag == TAG_TransactTime)
					_dtTransactTime = (DateTime) value;
				else if(iTag == TAG_Text)
					_sText = (string) value;
				else
					base[iTag] = value;
			}
		}
	}
}
