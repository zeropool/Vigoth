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

namespace FIX4NET.FIX
{
	public class Reject : Message, IMessageReject
	{
		public const int TAG_RefSeqNum = 45;
		public const int TAG_Text = 58;

		private int _iRefSeqNum;
		private string _sText;

		internal Reject()
			: base()
		{
			_sMsgType = Values.MsgType.Reject;
		}

		public int RefSeqNum
		{
			get { return _iRefSeqNum; }
			set { _iRefSeqNum = value; }
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
				switch (iTag)
				{
					case TAG_RefSeqNum:
						return _iRefSeqNum;
					case TAG_Text:
						return _sText;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch (iTag)
				{
					case TAG_RefSeqNum:
						_iRefSeqNum = (int)value;
						break;
					case TAG_Text:
						_sText = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}
	}
}