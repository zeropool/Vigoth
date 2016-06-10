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
	/// Summary description for Logout.
	/// </summary>
	public class Logout : Message, IMessageLogout
	{
		public const int TAG_Text = 58;

		private string _sText = null;
		
		internal Logout() : base()
		{
			_sMsgType = Values.MsgType.Logout;
		}

		public string Text
		{
			get 
			{
				return _sText;
			}
			set 
			{
				_sText = value;
			}
		}

		public override object this[int iTag]
		{
			get
			{
				switch(iTag) 
				{
					case TAG_Text:
						return _sText;
					default:
						return base[iTag];
				}
			}
			set
			{
				switch(iTag) 
				{
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
