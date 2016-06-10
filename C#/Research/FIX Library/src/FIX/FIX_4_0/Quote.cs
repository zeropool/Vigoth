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
	/// The quote message is used as the response to a quote request message and 
	/// can be used to publish unsolicited quotes.
	/// 
	/// Quotes supplied as the result of a Quote Request message are tagged with the 
	/// appropriate QuoteReqID, unsolicited quotes can be identified by the absence 
	/// of a  QuoteReqID.
	/// 
	/// The symbol used for forex quotes is, in ISO codes, “currency1.currency2” (e.g. GBP.USD) 
	/// and the quote will be returned as a rate expressed as currency1/currency2.  BidPx 
	/// indicates the rate at which the broker is willing to buy currency1 and deliver 
	/// currency2, OfferPx indicates the rate at which the broker is willing to sell currency1 
	/// and receive currency2.  Indicative rates are quoted in the BidPx field and may contain 
	/// a level in the BidSize field.
	/// 
	/// Orders can be generated based on Quotes, quoted orders include the QuoteID and 
	/// are OrdType=Quoted Order.
	/// </summary>
	public class Quote : Message
	{
		public const int TAG_QuoteReqID = 131;
		public const int TAG_QuoteID = 117;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_Issuer = 106;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_BidPx = 132;
		public const int TAG_OfferPx = 133;
		public const int TAG_BidSize = 134;
		public const int TAG_OfferSize = 135;
		public const int TAG_ValidUntilTime = 62;

		private string _sQuoteReqID;
		private string _sQuoteID;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sIssuer;
		private string _sSecurityDesc;
		private double _dBidPx;
		private double _dOfferPx;
		private int _iBidSize;
		private int _iOfferSize;
		private DateTime _dtValidUntilTime;

		internal Quote()
			: base()
		{
			_sMsgType = Values.MsgType.Quote;
		}

		public string QuoteReqID
		{
			get { return _sQuoteReqID; }
			set { _sQuoteReqID = value; }
		}
		public string QuoteID
		{
			get { return _sQuoteID; }
			set { _sQuoteID = value; }
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
		public double BidPx
		{
			get { return _dBidPx; }
			set { _dBidPx = value; }
		}
		public double OfferPx
		{
			get { return _dOfferPx; }
			set { _dOfferPx = value; }
		}
		public int BidSize
		{
			get { return _iBidSize; }
			set { _iBidSize = value; }
		}
		public int OfferSize
		{
			get { return _iOfferSize; }
			set { _iOfferSize = value; }
		}
		public DateTime ValidUntilTime
		{
			get { return _dtValidUntilTime; }
			set { _dtValidUntilTime = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				if (iTag == TAG_QuoteReqID)
					return _sQuoteReqID;
				else if (iTag == TAG_QuoteID)
					return _sQuoteID;
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
				else if (iTag == TAG_BidPx)
					return _dBidPx;
				else if (iTag == TAG_OfferPx)
					return _dOfferPx;
				else if (iTag == TAG_BidSize)
					return _iBidSize;
				else if (iTag == TAG_OfferSize)
					return _iOfferSize;
				else if (iTag == TAG_ValidUntilTime)
					return _dtValidUntilTime;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_QuoteReqID)
					_sQuoteReqID = (string)value;
				else if (iTag == TAG_QuoteID)
					_sQuoteID = (string)value;
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
				else if (iTag == TAG_BidPx)
					_dBidPx = (double)value;
				else if (iTag == TAG_OfferPx)
					_dOfferPx = (double)value;
				else if (iTag == TAG_BidSize)
					_iBidSize = (int)value;
				else if (iTag == TAG_OfferSize)
					_iOfferSize = (int)value;
				else if (iTag == TAG_ValidUntilTime)
					_dtValidUntilTime = (DateTime)value;
				else
					base[iTag] = value;
			}
		}
	}
}
