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
	/// Summary description for MarketDataRequestReject.
	/// </summary>
	public class MarketDataRequestReject : Message
	{
		public const int TAG_MDReqID = 262;
		public const int TAG_MDReqRejReason = 281;
		public const int TAG_NoAltMDSource = 816;
		public const int TAG_AltMDSourceID = 817;
		public const int TAG_Text = 58;
		public const int TAG_EncodedTextLen = 354;
		public const int TAG_EncodedText = 355;

		private string _sMDReqID;
		private char _cMDReqRejReason;
		private int _iNoAltMDSource;
		private MarketDataRequestRejectAltMDSourceList _listAltMDSource = new MarketDataRequestRejectAltMDSourceList();
		private string _sText;
		private int _iEncodedTextLen;
		private string _sEncodedText;

		public MarketDataRequestReject() : base()
		{
			_sMsgType = Values.MsgType.MarketDataRequestReject;
		}

		public string MDReqID
		{
			get { return _sMDReqID; }
			set { _sMDReqID = value; }
		}
		public char MDReqRejReason
		{
			get { return _cMDReqRejReason; }
			set { _cMDReqRejReason = value; }
		}
		public int NoAltMDSource
		{
			get { return _iNoAltMDSource; }
			set { _iNoAltMDSource = value; }
		}
		public MarketDataRequestRejectAltMDSourceList AltMDSource 
		{
			get { return _listAltMDSource; }
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

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_MDReqID:
						return _sMDReqID;
					case TAG_MDReqRejReason:
						return _cMDReqRejReason;
					case TAG_NoAltMDSource:
						return _iNoAltMDSource;
					case TAG_Text:
						return _sText;
					case TAG_EncodedTextLen:
						return _iEncodedTextLen;
					case TAG_EncodedText:
						return _sEncodedText;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_MDReqID:
						_sMDReqID = (string)value;
						break;
					case TAG_MDReqRejReason:
						_cMDReqRejReason = (char)value;
						break;
					case TAG_NoAltMDSource:
						_iNoAltMDSource = (int)value;
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
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class MarketDataRequestRejectAltMDSource
	{
		private string _sAltMDSourceID;

		public string AltMDSourceID
		{
			get { return _sAltMDSourceID; }
			set { _sAltMDSourceID = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case MarketDataRequestReject.TAG_AltMDSourceID:
						return _sAltMDSourceID;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case MarketDataRequestReject.TAG_AltMDSourceID:
						_sAltMDSourceID = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class MarketDataRequestRejectAltMDSourceList
	{
		private ArrayList _al;
		private MarketDataRequestRejectAltMDSource _last;

		public MarketDataRequestRejectAltMDSource this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (MarketDataRequestRejectAltMDSource)_al[i];
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

		public void Add(MarketDataRequestRejectAltMDSource item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(MarketDataRequestRejectAltMDSource item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public MarketDataRequestRejectAltMDSource Last
		{
			get { return _last; }
		}
	}
}
