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

using FIX4NET;

namespace FIX4NET.FIX.FIX_4_2
{
	/// <summary>
	/// Summary description for ParseFieldException_4_2.
	/// </summary>
	public class ParseFieldExceptionFIX : ParseFieldException
	{
		private string _sRefMsgType;
		private int _iRefTagID;
		private int _iSessionRejectReason = -1;

		public ParseFieldExceptionFIX(string sMessage, Exception exInner) : base(sMessage, exInner)
		{
		}

		public string RefMsgType 
		{
			get { return _sRefMsgType; }
			set { _sRefMsgType = value; }
		}

		public int RefTagID 
		{
			get { return _iRefTagID; }
			set { _iRefTagID = value; }
		}

		public int SessionRejectReason 
		{
			get { return _iSessionRejectReason; }
			set { _iSessionRejectReason = value; }
		}
	}
}
