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
using System.Text;
using System.Collections;

using FIX4NET;
using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_2
{
	/// <summary>
	/// Summary description for News.
	/// </summary>
	public class News : Message
	{
		public const int TAG_OrigTime = 42;
		public const int TAG_Urgency = 61;
		public const int TAG_Headline = 148;
		public const int TAG_EncodedHeadlineLen = 358;
		public const int TAG_EncodedHeadline = 359;
		public const int TAG_NoRoutingIDs = 215;
		public const int TAG_RoutingType = 216;
		public const int TAG_RoutingID = 217;
		public const int TAG_NoRelatedSym = 146;
		public const int TAG_RelatdSym = 46;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_SecurityType = 167;
		public const int TAG_MaturityMonthYear = 200;
		public const int TAG_MaturityDay = 205;
		public const int TAG_PutOrCall = 201;
		public const int TAG_StrikePrice = 202;
		public const int TAG_OptAttribute = 206;
		public const int TAG_ContractMultiplier = 231;
		public const int TAG_CouponRate = 223;
		public const int TAG_SecurityExchange = 207;
		public const int TAG_Issuer = 106;
		public const int TAG_EncodedIssuerLen = 348;
		public const int TAG_EncodedIssuer = 349;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_EncodedSecurityDescLen = 350;
		public const int TAG_EncodedSecurityDesc = 351;
		public const int TAG_LinesOfText = 33;
		public const int TAG_Text = 58;
		public const int TAG_URLLink = 149;
		public const int TAG_RawDataLength = 95;

		private DateTime _dtOrigTime;
		private char _cUrgency;
		private string _sHeadline;
		private int _iEncodedHeadlineLen;
		private int _iNoRoutingIDs;
		private NewsRouteIDList _listRouteID;
		private int _iNoRelatedSym;
		private NewsRelatedSymList _listRelatedSym;
		private int _iLinesOfText;
		private NewsTextList _listText;
		private string _sURLLink;
		private int _iRawDataLength;

		public News() : base()
		{
			_sMsgType = Values.MsgType.News;
			_listText = new NewsTextList();
			_listRelatedSym = new NewsRelatedSymList();
			_listRouteID = new NewsRouteIDList();
		}

		public DateTime OrigTime 
		{ 
			get { return _dtOrigTime; } 
			set { _dtOrigTime = value; } 
		}
		public char Urgency 
		{ 
			get { return _cUrgency; } 
			set { _cUrgency = value; } 
		}
		public string Headline 
		{ 
			get { return _sHeadline; } 
			set { _sHeadline = value; } 
		}
		public int EncodedHeadlineLen 
		{ 
			get { return _iEncodedHeadlineLen; } 
			set { _iEncodedHeadlineLen = value; } 
		}
		public int NoRoutingIDs 
		{ 
			get { return _iNoRoutingIDs; } 
			set { _iNoRoutingIDs = value; } 
		}
		public NewsRouteIDList RouteID 
		{
			get { return _listRouteID; }
		}
		public int NoRelatedSym 
		{ 
			get { return _iNoRelatedSym; } 
			set { _iNoRelatedSym = value; } 
		}
		public NewsRelatedSymList RelatedSym
		{
			get { return _listRelatedSym; }
		}
		public int LinesOfText 
		{ 
			get { return _iLinesOfText; } 
			set { _iLinesOfText = value; }
		}
		public NewsTextList Text 
		{
			get { return _listText; }
		}
		public string URLLink 
		{ 
			get { return _sURLLink; } 
			set { _sURLLink = value; } 
		}
		public int RawDataLength 
		{ 
			get { return _iRawDataLength; } 
			set { _iRawDataLength = value; } 
		}

		public override object this[int iTag] 
		{
			get 
			{
				if(iTag == TAG_OrigTime)
					return _dtOrigTime;
				else if(iTag == TAG_Urgency)
					return _cUrgency;
				else if(iTag == TAG_Headline)
					return _sHeadline;
				else if(iTag == TAG_EncodedHeadlineLen)
					return _iEncodedHeadlineLen;
				else if(iTag == TAG_NoRoutingIDs)
					return _iNoRoutingIDs;
				else if(iTag == TAG_NoRelatedSym)
					return _iNoRelatedSym;
				else if(iTag == TAG_LinesOfText)
					return _iLinesOfText;
				else if(iTag == TAG_URLLink)
					return _sURLLink;
				else if(iTag == TAG_RawDataLength)
					return _iRawDataLength;
				else
					return base[iTag];
			}
			set 
			{
				if(iTag == TAG_OrigTime)
					_dtOrigTime = (DateTime) value;
				else if(iTag == TAG_Urgency)
					_cUrgency = (char) value;
				else if(iTag == TAG_Headline)
					_sHeadline = (string) value;
				else if(iTag == TAG_EncodedHeadlineLen)
					_iEncodedHeadlineLen = (int) value;
				else if(iTag == TAG_NoRoutingIDs)
					_iNoRoutingIDs = (int) value;
				else if(iTag == TAG_NoRelatedSym)
					_iNoRelatedSym = (int) value;
				else if(iTag == TAG_LinesOfText)
					_iLinesOfText = (int) value;
				else if(iTag == TAG_URLLink)
					_sURLLink = (string) value;
				else if(iTag == TAG_RawDataLength)
					_iRawDataLength = (int) value;
				else
					base[iTag] = value;
			}
		}
	}

	public class NewsText
	{
		private string _sText;

		public string Text
		{
			get { return _sText; }
			set { _sText = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case News.TAG_Text:
						return _sText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case News.TAG_Text:
						_sText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NewsTextList
	{
		private ArrayList _al;
		private NewsText _last;

		public NewsText this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NewsText)_al[i];
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

		public void Add(NewsText item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewsText item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewsText Last
		{
			get { return _last; }
		}
	}

	public class NewsRelatdSym 
	{
		private string _sRelatdSym;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sSecurityType;
		private DateTime _dtMaturityMonthYear;
		private byte _iMaturityDay;
		private int _iPutOrCall;
		private double _dStrikePrice;
		private char _cOptAttribute;
		private double _dContractMultiplier;
		private double _dCouponRate;
		private string _sSecurityExchange;
		private string _sIssuer;
		private int _iEncodedIssuerLen;
		private string _sSecurityDesc;
		private int _iEncodedSecurityDescLen;

		public string RelatdSym 
		{ 
			get { return _sRelatdSym; } 
			set { _sRelatdSym = value; } 
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
		public string SecurityType 
		{ 
			get { return _sSecurityType; } 
			set { _sSecurityType = value; } 
		}
		public DateTime MaturityMonthYear 
		{ 
			get { return _dtMaturityMonthYear; } 
			set { _dtMaturityMonthYear = value; } 
		}
		public byte MaturityDay 
		{ 
			get { return _iMaturityDay; } 
			set { _iMaturityDay = value; } 
		}
		public int PutOrCall 
		{ 
			get { return _iPutOrCall; } 
			set { _iPutOrCall = value; } 
		}
		public double StrikePrice 
		{ 
			get { return _dStrikePrice; } 
			set { _dStrikePrice = value; } 
		}
		public char OptAttribute 
		{ 
			get { return _cOptAttribute; } 
			set { _cOptAttribute = value; } 
		}
		public double ContractMultiplier 
		{ 
			get { return _dContractMultiplier; } 
			set { _dContractMultiplier = value; } 
		}
		public double CouponRate 
		{ 
			get { return _dCouponRate; } 
			set { _dCouponRate = value; } 
		}
		public string SecurityExchange 
		{ 
			get { return _sSecurityExchange; } 
			set { _sSecurityExchange = value; } 
		}
		public string Issuer 
		{ 
			get { return _sIssuer; } 
			set { _sIssuer = value; } 
		}
		public int EncodedIssuerLen 
		{ 
			get { return _iEncodedIssuerLen; } 
			set { _iEncodedIssuerLen = value; } 
		}
		public string SecurityDesc 
		{ 
			get { return _sSecurityDesc; } 
			set { _sSecurityDesc = value; } 
		}
		public int EncodedSecurityDescLen 
		{ 
			get { return _iEncodedSecurityDescLen; } 
			set { _iEncodedSecurityDescLen = value; } 
		}

		public object this[int iTag] 
		{
			get 
			{
				if(iTag == News.TAG_RelatdSym)
					return _sRelatdSym;
				else if(iTag == News.TAG_SymbolSfx)
					return _sSymbolSfx;
				else if(iTag == News.TAG_SecurityID)
					return _sSecurityID;
				else if(iTag == News.TAG_IDSource)
					return _sIDSource;
				else if(iTag == News.TAG_SecurityType)
					return _sSecurityType;
				else if(iTag == News.TAG_MaturityMonthYear)
					return _dtMaturityMonthYear;
				else if(iTag == News.TAG_MaturityDay)
					return _iMaturityDay;
				else if(iTag == News.TAG_PutOrCall)
					return _iPutOrCall;
				else if(iTag == News.TAG_StrikePrice)
					return _dStrikePrice;
				else if(iTag == News.TAG_OptAttribute)
					return _cOptAttribute;
				else if(iTag == News.TAG_ContractMultiplier)
					return _dContractMultiplier;
				else if(iTag == News.TAG_CouponRate)
					return _dCouponRate;
				else if(iTag == News.TAG_SecurityExchange)
					return _sSecurityExchange;
				else if(iTag == News.TAG_Issuer)
					return _sIssuer;
				else if(iTag == News.TAG_EncodedIssuerLen)
					return _iEncodedIssuerLen;
				else if(iTag == News.TAG_SecurityDesc)
					return _sSecurityDesc;
				else if(iTag == News.TAG_EncodedSecurityDescLen)
					return _iEncodedSecurityDescLen;
				else
					throw new Exception("Unknown field");
			}
			set 
			{
				if(iTag == News.TAG_RelatdSym)
					_sRelatdSym = (string) value;
				else if(iTag == News.TAG_SymbolSfx)
					_sSymbolSfx = (string) value;
				else if(iTag == News.TAG_SecurityID)
					_sSecurityID = (string) value;
				else if(iTag == News.TAG_IDSource)
					_sIDSource = (string) value;
				else if(iTag == News.TAG_SecurityType)
					_sSecurityType = (string) value;
				else if(iTag == News.TAG_MaturityMonthYear)
					_dtMaturityMonthYear = (DateTime) value;
				else if(iTag == News.TAG_MaturityDay)
					_iMaturityDay = (byte) value;
				else if(iTag == News.TAG_PutOrCall)
					_iPutOrCall = (int) value;
				else if(iTag == News.TAG_StrikePrice)
					_dStrikePrice = (double) value;
				else if(iTag == News.TAG_OptAttribute)
					_cOptAttribute = (char) value;
				else if(iTag == News.TAG_ContractMultiplier)
					_dContractMultiplier = (double) value;
				else if(iTag == News.TAG_CouponRate)
					_dCouponRate = (double) value;
				else if(iTag == News.TAG_SecurityExchange)
					_sSecurityExchange = (string) value;
				else if(iTag == News.TAG_Issuer)
					_sIssuer = (string) value;
				else if(iTag == News.TAG_EncodedIssuerLen)
					_iEncodedIssuerLen = (int) value;
				else if(iTag == News.TAG_SecurityDesc)
					_sSecurityDesc = (string) value;
				else if(iTag == News.TAG_EncodedSecurityDescLen)
					_iEncodedSecurityDescLen = (int) value;
				else
					throw new Exception("Unknown field");
			}
		}
	}

	public class NewsRelatedSymList
	{
		private ArrayList _al;
		private NewsRelatdSym _last;

		public NewsRelatdSym this[int i] 
		{
			get 
			{
				if(_al != null && i < _al.Count) 
					return (NewsRelatdSym) _al[i];
				else
					return null;
			}
		}

		public int Count
		{
			get 
			{
				if(_al != null)
					return _al.Count; 
				else
					return 0;
			}
		}

		public void Clear() 
		{
			_al = null;
		}

		public void Add(NewsRelatdSym item) 
		{
			if(_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewsRelatdSym item) 
		{
			if(_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex) 
		{
			if(_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewsRelatdSym Last 
		{
			get { return _last; }
		}
	}

	public class NewsRouteID 
	{
		private int _iRoutingType;
		private string _sRoutingID;

		public int RoutingType 
		{
			get { return _iRoutingType; }
			set { _iRoutingType = value; }
		}

		public string RoutingID 
		{
			get { return _sRoutingID; }
			set { _sRoutingID = value; }
		}

		public object this[int iTag] 
		{
			get 
			{
				if(iTag == News.TAG_RoutingType)
					return _iRoutingType;
				else if(iTag == News.TAG_RoutingID)
					return _sRoutingID;
				else
					throw new Exception("Unknown field");
			}
			set 
			{
				if(iTag == News.TAG_RoutingType)
					_iRoutingType = (int) value;
				else if(iTag == News.TAG_RoutingID)
					_sRoutingID = (string) value;
				else
					throw new Exception("Unknown field");				
			}
		}
	}

	public class NewsRouteIDList 
	{
		private ArrayList _al;
		private NewsRouteID _last;

		public NewsRouteID this[int index] 
		{
			get 
			{
				if(_al != null)
					return (NewsRouteID) _al[index];
				else
					return null;
			}
		}

		public int Count
		{
			get 
			{
				if(_al != null)
					return _al.Count; 
				else
					return 0;
			}
		}

		public void Clear() 
		{
			_al = null;
		}

		public void Add(NewsRouteID item) 
		{
			if(_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NewsRouteID item) 
		{
			if(_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex) 
		{
			if(_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NewsRouteID Last 
		{
			get { return _last; }
		}
	}
}
