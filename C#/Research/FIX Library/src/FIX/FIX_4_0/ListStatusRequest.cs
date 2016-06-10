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
	public class ListStatusRequest : Message
	{
		public const int TAG_ListID = 66;
		public const int TAG_WaveNo = 105;
		public const int TAG_Text = 58;

		private string _sListID;
		private string _sWaveNo;
		private string _sText;

		internal ListStatusRequest()
			: base()
		{
			_sMsgType = Values.MsgType.ListStatusRequest;
		}

		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public string WaveNo
		{
			get { return _sWaveNo; }
			set { _sWaveNo = value; }
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
				if (iTag == TAG_ListID)
					return _sListID;
				else if (iTag == TAG_WaveNo)
					return _sWaveNo;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_ListID)
					_sListID = (string)value;
				else if (iTag == TAG_WaveNo)
					_sWaveNo = (string)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}
	}
}
