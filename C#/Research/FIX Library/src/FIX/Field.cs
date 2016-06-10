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
	/// <summary>
	/// Summary description for Field.
	/// </summary>
	public class Field : IField
	{
		public int _tag;
		public string _value;

		public int Tag { get { return _tag; } set { _tag = value; } }
		public string Value { get { return _value; } set { _value = value; } }

		private Field() { }

		public Field(int tag, string value)
		{
			_tag = tag;
			_value = value;
		}

		public override string ToString()
		{
			return string.Format("{0}={1}", _tag, _value);
		}

		public void CopyTo(IField to)
		{
			Field field = (Field)to;
			field._tag = _tag;
			field._value = _value;
		}

		public IField Clone()
		{
			IField field = new Field();
			CopyTo(field);
			return field;
		}
	}
}
