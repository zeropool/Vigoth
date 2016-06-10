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
	/// Summary description for NetworkStatusResponse.
	/// </summary>
	public class NetworkStatusResponse : Message
	{
		public const int TAG_NetworkStatusResponseType = 937;
		public const int TAG_NetworkRequestID = 933;
		public const int TAG_NetworkResponseID = 932;
		public const int TAG_LastNetworkResponseID = 934;
		public const int TAG_NoCompIDs = 936;
		public const int TAG_RefCompID = 930;
		public const int TAG_RefSubID = 931;
		public const int TAG_LocationID = 283;
		public const int TAG_DeskID = 284;
		public const int TAG_StatusValue = 928;
		public const int TAG_StatusText = 929;

		private int _iNetworkStatusResponseType;
		private string _sNetworkRequestID;
		private string _sNetworkResponseID;
		private string _sLastNetworkResponseID;
		private int _iNoCompIDs;
		private NetworkStatusResponseCompIDList _listCompID = new NetworkStatusResponseCompIDList();

		public NetworkStatusResponse() : base()
		{
			_sMsgType = Values.MsgType.NetworkStatusResponse;
		}

		public int NetworkStatusResponseType
		{
			get { return _iNetworkStatusResponseType; }
			set { _iNetworkStatusResponseType = value; }
		}
		public string NetworkRequestID
		{
			get { return _sNetworkRequestID; }
			set { _sNetworkRequestID = value; }
		}
		public string NetworkResponseID
		{
			get { return _sNetworkResponseID; }
			set { _sNetworkResponseID = value; }
		}
		public string LastNetworkResponseID
		{
			get { return _sLastNetworkResponseID; }
			set { _sLastNetworkResponseID = value; }
		}
		public int NoCompIDs
		{
			get { return _iNoCompIDs; }
			set { _iNoCompIDs = value; }
		}
		public NetworkStatusResponseCompIDList CompID 
		{
			get { return _listCompID; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case TAG_NetworkStatusResponseType:
						return _iNetworkStatusResponseType;
					case TAG_NetworkRequestID:
						return _sNetworkRequestID;
					case TAG_NetworkResponseID:
						return _sNetworkResponseID;
					case TAG_LastNetworkResponseID:
						return _sLastNetworkResponseID;
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
					case TAG_NetworkStatusResponseType:
						_iNetworkStatusResponseType = (int)value;
						break;
					case TAG_NetworkRequestID:
						_sNetworkRequestID = (string)value;
						break;
					case TAG_NetworkResponseID:
						_sNetworkResponseID = (string)value;
						break;
					case TAG_LastNetworkResponseID:
						_sLastNetworkResponseID = (string)value;
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

	public class NetworkStatusResponseCompID
	{
		private string _sRefCompID;
		private string _sRefSubID;
		private string _sLocationID;
		private string _sDeskID;
		private int _iStatusValue;
		private string _sStatusText;

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
		public int StatusValue
		{
			get { return _iStatusValue; }
			set { _iStatusValue = value; }
		}
		public string StatusText
		{
			get { return _sStatusText; }
			set { _sStatusText = value; }
		}

		public object this[int iTag]
		{
			get
			{
				switch (iTag)
				{
					case NetworkStatusResponse.TAG_RefCompID:
						return _sRefCompID;
					case NetworkStatusResponse.TAG_RefSubID:
						return _sRefSubID;
					case NetworkStatusResponse.TAG_LocationID:
						return _sLocationID;
					case NetworkStatusResponse.TAG_DeskID:
						return _sDeskID;
					case NetworkStatusResponse.TAG_StatusValue:
						return _iStatusValue;
					case NetworkStatusResponse.TAG_StatusText:
						return _sStatusText;
					default:
						throw new Exception("Unknown field");
				}
			}
			set
			{
				switch (iTag)
				{
					case NetworkStatusResponse.TAG_RefCompID:
						_sRefCompID = (string)value;
						break;
					case NetworkStatusResponse.TAG_RefSubID:
						_sRefSubID = (string)value;
						break;
					case NetworkStatusResponse.TAG_LocationID:
						_sLocationID = (string)value;
						break;
					case NetworkStatusResponse.TAG_DeskID:
						_sDeskID = (string)value;
						break;
					case NetworkStatusResponse.TAG_StatusValue:
						_iStatusValue = (int)value;
						break;
					case NetworkStatusResponse.TAG_StatusText:
						_sStatusText = (string)value;
						break;
					default:
						throw new Exception("Unknown field");
				}
			}
		}
	}

	public class NetworkStatusResponseCompIDList
	{
		private ArrayList _al;
		private NetworkStatusResponseCompID _last;

		public NetworkStatusResponseCompID this[int i]
		{
			get
			{
				if (_al != null && i < _al.Count)
					return (NetworkStatusResponseCompID)_al[i];
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

		public void Add(NetworkStatusResponseCompID item)
		{
			if (_al == null)
				_al = new ArrayList();
			_al.Add(item);
			_last = item;
		}

		public void Remove(NetworkStatusResponseCompID item)
		{
			if (_al != null)
				_al.Remove(item);
		}

		public void RemoveAt(int iIndex)
		{
			if (_al != null && iIndex < _al.Count)
				_al.RemoveAt(iIndex);
		}

		public NetworkStatusResponseCompID Last
		{
			get { return _last; }
		}
	}
}
