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
	/// The news message is intended for use as a general free format message between the 
	/// broker and institution.  The message contains flags to identify the news item's 
	/// urgency and to allow sorting by subject company (symbol).  The News record can be 
	/// originated at either the broker or institution side.
	/// </summary>
	public class News : Message
	{
		public const int TAG_OrigTime = 42;
		public const int TAG_Urgency = 61;
		public const int TAG_RelatdSym = 46;
		public const int TAG_LinesOfText = 33;
		public const int TAG_Text = 58;

		private DateTime _dtOrigTime;
		private char _cUrgency;
		private string _sRelatdSym;
		private int _iLinesOfText;
		private string _sText;

		internal News()
			: base()
		{
			_sMsgType = Values.MsgType.News;
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
		public string RelatdSym
		{
			get { return _sRelatdSym; }
			set { _sRelatdSym = value; }
		}
		public int LinesOfText
		{
			get { return _iLinesOfText; }
			set { _iLinesOfText = value; }
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
				if (iTag == TAG_OrigTime)
					return _dtOrigTime;
				else if (iTag == TAG_Urgency)
					return _cUrgency;
				else if (iTag == TAG_RelatdSym)
					return _sRelatdSym;
				else if (iTag == TAG_LinesOfText)
					return _iLinesOfText;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_OrigTime)
					_dtOrigTime = (DateTime)value;
				else if (iTag == TAG_Urgency)
					_cUrgency = (char)value;
				else if (iTag == TAG_RelatdSym)
					_sRelatdSym = (string)value;
				else if (iTag == TAG_LinesOfText)
					_iLinesOfText = (int)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}
	}
}
