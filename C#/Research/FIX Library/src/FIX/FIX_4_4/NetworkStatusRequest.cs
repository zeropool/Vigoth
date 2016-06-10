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
	/// Summary description for NetworkStatusRequest.
	/// </summary>
	public class NetworkStatusRequest : Message
	{
		public const int TAG_NetworkRequestType = 935;
		public const int TAG_NetworkRequestID = 933;
		public const int TAG_NoCompIDs = 936;
		public const int TAG_RefCompID = 930;
		public const int TAG_RefSubID = 931;
		public const int TAG_LocationID = 283;
		public const int TAG_DeskID = 284;

		private int _iNetworkRequestType;
		private string _sNetworkRequestID;
		private int _iNoCompIDs;
		private NetworkStatusRequestCompIDList _listCompID = new NetworkStatusRequestCompIDList();

		public NetworkStatusRequest() : base()
		{
			_sMsgType = Values.MsgType.NetworkStatusRequest;
		}

		public int NetworkRequestType
		{
			get { return _iNetworkRequestType; }
			set { _iNetworkRequestType = value; }
		}
		public string NetworkRequestID
		{
			get { return _sNetworkRequestID; }
			set { _sNetworkRequestID = value; }
		}
		public int NoCompIDs
		{
			get { return _iNoCompIDs; }
			set { _iNoCompIDs = value; }
		}
		public NetworkStatusRequestCompIDList CompID 
		{
			get { return _listCompID; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_NetworkRequestType:
						return _iNetworkRequestType;
					case TAG_NetworkRequestID:
						return _sNetworkRequestID;
					case TAG_NoCompIDs:
						return _iNoCompIDs;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_NetworkRequestType:
						_iNetworkRequestType = (int)value;
						break;
					case TAG_NetworkRequestID:
						_sNetworkRequestID = (string)value;
						break;
					case TAG_NoCompIDs:
						_iNoCompIDs = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}

	}

	public class NetworkStatusRequestCompID
	{
		private string _sRefCompID;
		private string _sRefSubID;
		private string _sLocationID;
		private string _sDeskID;

		public string RefCompID
		{
			get { return _sRefCompID; }
			set { _sRefCompID = value; }
		}
		public string RefSubID
		{
			get { return _sRefSubID; }
			set { _sRefSubID = value; }
		}
		public string LocationID
		{
			get { return _sLocationID; }
			set { _sLocationID = value; }
		}
		public string DeskID
		{
			get { return _sDeskID; }
			set { _sDeskID = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NetworkStatusRequest.TAG_RefCompID:
						return _sRefCompID;
					case NetworkStatusRequest.TAG_RefSubID:
						return _sRefSubID;
					case NetworkStatusRequest.TAG_LocationID:
						return _sLocationID;
					case NetworkStatusRequest.TAG_DeskID:
						return _sDeskID;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NetworkStatusRequest.TAG_RefCompID:
						_sRefCompID = (string)value;
						break;
					case NetworkStatusRequest.TAG_RefSubID:
						_sRefSubID = (string)value;
						break;
					case NetworkStatusRequest.TAG_LocationID:
						_sLocationID = (string)value;
						break;
					case NetworkStatusRequest.TAG_DeskID:
						_sDeskID = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NetworkStatusRequestCompIDList
	{
		private ArrayList _al;
		private NetworkStatusRequestCompID _last;

		public NetworkStatusRequestCompID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NetworkStatusRequestCompID)_al[i];
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

		public void Add(NetworkStatusRequestCompID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NetworkStatusRequestCompID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NetworkStatusRequestCompID Last
		{
			get { return _last; }
		}
	}
}
