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
	/// In some markets it is the practice to request quotes from brokers prior to 
	/// placement of an order.  The quote request message is used for this purpose.
	/// 
	/// Quotes can be requested on specific securities or for forex rates.
	/// 
	/// Securities quotes can be requested as either market quotes or for a specific 
	/// quantity and side.  If OrderQty and Side are absent, a market-style 
	/// quote (bid x offer, size x size) will be returned.
	/// 
	/// The symbol used for forex quotes is, in ISO codes, “currency1.currency2” (e.g. GBP.USD) 
	/// and the quote will be returned as a rate expressed as currency1/currency2.
	/// 
	/// Forex quotes can be requested as indicative or at a specific quantity level.  If an 
	/// indicative quote is requested (OrderQty and Side are absent), the broker has 
	/// discretion to quote at either a specific trade level and side or to provide an 
	/// indicative quote at the mid-point of the spread.  The broker can also choose to 
	/// respond to an indicative quote by sending multiple quote messages specifying 
	/// various levels and sides.
	/// </summary>
	public class QuoteRequest : Message
	{
		public const int TAG_QuoteReqID = 131;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_Issuer = 106;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_PrevClosePx = 140;
		public const int TAG_Side = 54;
		public const int TAG_OrderQty = 38;

		private string _sQuoteReqID;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sIssuer;
		private string _sSecurityDesc;
		private double _dPrevClosePx;
		private char _cSide;
		private int _iOrderQty;

		public string QuoteReqID
		{
			get { return _sQuoteReqID; }
			set { _sQuoteReqID = value; }
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
		public double PrevClosePx
		{
			get { return _dPrevClosePx; }
			set { _dPrevClosePx = value; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
		}
		public int OrderQty
		{
			get { return _iOrderQty; }
			set { _iOrderQty = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				if (iTag == TAG_QuoteReqID)
					return _sQuoteReqID;
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
				else if (iTag == TAG_PrevClosePx)
					return _dPrevClosePx;
				else if (iTag == TAG_Side)
					return _cSide;
				else if (iTag == TAG_OrderQty)
					return _iOrderQty;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_QuoteReqID)
					_sQuoteReqID = (string)value;
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
				else if (iTag == TAG_PrevClosePx)
					_dPrevClosePx = (double)value;
				else if (iTag == TAG_Side)
					_cSide = (char)value;
				else if (iTag == TAG_OrderQty)
					_iOrderQty = (int)value;
				else
					base[iTag] = value;
			}
		}
	}
}
