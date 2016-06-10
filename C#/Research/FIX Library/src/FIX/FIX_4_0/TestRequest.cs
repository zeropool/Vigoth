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

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_0
{
	/// <summary>
	/// Summary description for TestRequest.
	/// </summary>
	public class TestRequest : Message, IMessageTestRequest
	{

		public const int TAG_TestReqID = 112;

		private string _sTestReqID = null;

		internal TestRequest() : base()
		{
			_sMsgType = Values.MsgType.TestRequest;
		}

		public string TestReqID 
		{
			get 
			{
				return _sTestReqID;
			}
			set 
			{
				_sTestReqID = value;
			}
		}

		public override object this[int iTag]
		{
			get
			{
				switch(iTag)
				{
					case TAG_TestReqID:
						return _sTestReqID;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch(iTag) 
				{
					case TAG_TestReqID:
						_sTestReqID = (string)value;
						break;
					default:
						base[iTag] = value;
						break;
				}
			}
		}
	}
}
