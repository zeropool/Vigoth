using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator
{
	class FieldDefinition
	{
		private int _tag;
		private string _name;
		private DataTypes _dataType;
		private bool _required;
		private List<FieldDefinition> _group;

		public int Tag { get { return _tag; } set { _tag = value; } }
		public string Name { get { return _name; } set { _name = value; } }
		public DataTypes DataType { get { return _dataType; } set { _dataType = value; } }
		public bool Required { get { return _required; } set { _required = value; } }

		public List<FieldDefinition> Group { get { return _group; } }
		public void CreateGroup()
		{
			if (_group == null)
				_group = new List<FieldDefinition>();
		}
		public void DeleteGroup()
		{
			_group = null;
		}
		public bool IsGroup()
		{
			return _group != null;
		}

		public enum DataTypes
		{
			Boolean,
			Int,
			Double,
			Char,
			String,
			DateTimeUTC,
			DateLocal,
			DateMonthYear,
			DateUTC,
			TimeUTC,
		}

		public FieldDefinition Clone()
		{
			FieldDefinition field = new FieldDefinition();
			field._tag = _tag;
			field._name = _name;
			field._dataType = _dataType;
			field._required = _required;
			field._group = _group;
			return field;
		}
	}
}
