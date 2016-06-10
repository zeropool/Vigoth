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

using FIX4NET;
using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_2
{
	/// <summary>
	/// Summary description for SequenceReset.
	/// </summary>
	public class SequenceReset : Message, IMessageSequenceReset
	{
		public const int TAG_GapFillFlag = 123;
		public const int TAG_NewSeqNo = 36;

		private bool _bGapFillFlag;
		private int _iNewSeqNo;

		internal SequenceReset() : base()
		{
			_sMsgType = Values.MsgType.SequenceReset;
		}

		public bool GapFillFlag 
		{
			get { return _bGapFillFlag; }
			set { _bGapFillFlag = value; }
		}

		public int NewSeqNo 
		{
			get { return _iNewSeqNo; }
			set { _iNewSeqNo = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				switch(iTag)
				{
					case TAG_GapFillFlag:
						return _bGapFillFlag;
					case TAG_NewSeqNo:
						return _iNewSeqNo;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch(iTag)
				{
					case TAG_GapFillFlag:
						_bGapFillFlag = (bool)value;
						break;
					case TAG_NewSeqNo:
						_iNewSeqNo = (int)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}
	}
}
