using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace CodeGenerator
{
	class GenFix44
	{
		XmlDocument _doc;
		Dictionary<string, FieldDefinition> _fieldsByName = new Dictionary<string, FieldDefinition>();
		Dictionary<string, List<FieldDefinition>> _componentsByName = new Dictionary<string, List<FieldDefinition>>();

		private string _outputDir;

		public string OutputDir
		{
			get { return _outputDir; }
			set
			{
				if (string.IsNullOrEmpty(value))
					_outputDir = null;
				else if (!value.EndsWith(@"\"))
					_outputDir = value + @"\";
				else
					_outputDir = value;
			}
		}

		public void Initialize(string fileName)
		{
			_doc = new XmlDocument();
			_doc.Load(fileName);

			InitializeFields();
			InitializeComponents();
		}

		private void InitializeFields()
		{
			foreach (XmlNode node1 in _doc.DocumentElement.ChildNodes)
			{
				if (string.Equals(node1.Name, "fields") && node1.NodeType == XmlNodeType.Element)
					foreach (XmlNode node2 in node1.ChildNodes)
					{
						if (string.Equals(node2.Name, "field") && node2.NodeType == XmlNodeType.Element)
							InitializeField((XmlElement)node2);
					}
			}
		}

		private void InitializeField(XmlElement elemField)
		{
			FieldDefinition def = new FieldDefinition();
			def.Tag = int.Parse(elemField.GetAttribute("number"));
			def.Name = elemField.GetAttribute("name");
			string type = elemField.GetAttribute("type");
			def.DataType = ConvertToFieldDefinitionDataType(type);

			_fieldsByName.Add(def.Name, def);
		}

		private FieldDefinition.DataTypes ConvertToFieldDefinitionDataType(string type)
		{
			if (string.Equals(type, "BOOLEAN"))
				return FieldDefinition.DataTypes.Boolean;

			else if (string.Equals(type, "INT"))
				return FieldDefinition.DataTypes.Int;
			else if (string.Equals(type, "QTY"))
				return FieldDefinition.DataTypes.Int;
			else if (string.Equals(type, "NUMINGROUP"))
				return FieldDefinition.DataTypes.Int;
			else if (string.Equals(type, "LENGTH"))
				return FieldDefinition.DataTypes.Int;
			else if (string.Equals(type, "SEQNUM"))
				return FieldDefinition.DataTypes.Int;

			else if (string.Equals(type, "FLOAT"))
				return FieldDefinition.DataTypes.Double;
			else if (string.Equals(type, "AMT"))
				return FieldDefinition.DataTypes.Double;
			else if (string.Equals(type, "PRICE"))
				return FieldDefinition.DataTypes.Double;
			else if (string.Equals(type, "PRICEOFFSET"))
				return FieldDefinition.DataTypes.Double;
			else if (string.Equals(type, "PERCENTAGE"))
				return FieldDefinition.DataTypes.Double;

			else if (string.Equals(type, "CHAR"))
				return FieldDefinition.DataTypes.Char;

			else if (string.Equals(type, "STRING"))
				return FieldDefinition.DataTypes.String;
			else if (string.Equals(type, "MULTIPLEVALUESTRING"))
				return FieldDefinition.DataTypes.String;
			else if (string.Equals(type, "EXCHANGE"))
				return FieldDefinition.DataTypes.String;
			else if (string.Equals(type, "CURRENCY"))
				return FieldDefinition.DataTypes.String;
			else if (string.Equals(type, "DATA"))
				return FieldDefinition.DataTypes.String;
			else if (string.Equals(type, "COUNTRY"))
				return FieldDefinition.DataTypes.String;

			else if (string.Equals(type, "UTCTIMESTAMP"))
				return FieldDefinition.DataTypes.DateTimeUTC;
			else if (string.Equals(type, "UTCDATEONLY"))
				return FieldDefinition.DataTypes.DateUTC;
			else if (string.Equals(type, "UTCTIMEONLY"))
				return FieldDefinition.DataTypes.TimeUTC;
			else if (string.Equals(type, "LOCALMKTDATE"))
				return FieldDefinition.DataTypes.DateLocal;
			else if (string.Equals(type, "MONTHYEAR"))
				return FieldDefinition.DataTypes.DateMonthYear;

			else
				throw new Exception("Unsupported type - " + type);
		}

		private void InitializeComponents()
		{
			foreach (XmlNode node1 in _doc.DocumentElement.ChildNodes)
			{
				if (string.Equals(node1.Name, "components") && node1.NodeType == XmlNodeType.Element)

					foreach (XmlNode node2 in node1.ChildNodes)
					{
						if (string.Equals(node2.Name, "component") && node2.NodeType == XmlNodeType.Element)
							InitializeComponent((XmlElement)node2);
					}
			}
		}

		private void InitializeComponent_Old(XmlElement elemComponent)
		{
			XmlElement elem;
			List<FieldDefinition> fields = new List<FieldDefinition>();
			FieldDefinition field;
			FieldDefinition fieldComponent;
			string required;

			foreach (XmlNode node in elemComponent.ChildNodes)
			{
				if (node.NodeType == XmlNodeType.Element)
				{
					elem = (XmlElement)node;

					if (string.Equals(node.Name, "field"))
					{
						field = _fieldsByName[elem.GetAttribute("name")];
						if (field != null)
						{
							fieldComponent = field.Clone();
							required = elem.GetAttribute("required");
							fieldComponent.Required = string.Equals(required, "Y");
							fields.Add(fieldComponent);
						}
					}
				}
			}
		}

		private void InitializeComponent(XmlElement elemComponent)
		{
			List<FieldDefinition> fields = GetFieldDefinitions(elemComponent);
			_componentsByName.Add(elemComponent.GetAttribute("name"), fields);
		}

		public void Run()
		{
			foreach (XmlNode node in _doc.DocumentElement.ChildNodes)
			{
				if (string.Equals(node.Name, "messages") && node.NodeType == XmlNodeType.Element)
				{
					GenValuesMsgType((XmlElement)node);
					GenMessages((XmlElement)node);
					GenMessageFactory((XmlElement)node);
				}
			}
		}

		private void GenValuesMsgType(XmlElement elemMessages)
		{
			XmlElement elemMessage;

			//start Values.MsgType
			StreamWriter writer = new StreamWriter(_outputDir + @"Values\MsgType.cs");
			writer.WriteLine(@"using System;");
			writer.WriteLine(@"");
			writer.WriteLine(@"using FIX = FIX4NET.FIX;");
			writer.WriteLine(@"");
			writer.WriteLine(@"namespace FIX4NET.FIX.FIX_4_4.Values");
			writer.WriteLine(@"{");
			writer.WriteLine(@"	public class MsgType : FIX.Values.MsgType");
			writer.WriteLine(@"	{");

			foreach (XmlNode node in elemMessages.ChildNodes)
			{
				if (string.Equals(node.Name, "message") && node.NodeType == XmlNodeType.Element)
				{
					elemMessage = (XmlElement)node;

					//message Values.MsgType
					if (string.Equals(elemMessage.GetAttribute("msgcat"), "app"))
						writer.WriteLine(@"		public const string {0} = ""{1}"";",
							elemMessage.GetAttribute("name"),
							elemMessage.GetAttribute("msgtype"));
				}
			}

			//finish Values.MsgType
			writer.WriteLine(@"	}");
			writer.WriteLine(@"}");

			writer.Close();
		}

		private void GenMessages(XmlElement elemMessages)
		{
			XmlElement elemMessage;
			foreach (XmlNode node in elemMessages.ChildNodes)
			{
				if (string.Equals(node.Name, "message") && node.NodeType == XmlNodeType.Element)
				{
					elemMessage = (XmlElement)node;
					GenMessage(elemMessage);
				}
			}
		}

		private void GenMessageConstants(StreamWriter writer, List<FieldDefinition> fields)
		{
			GenMessageConstants(writer, fields, new List<string>());
		}

		private void GenMessageConstants(StreamWriter writer, List<FieldDefinition> fields, List<string> fieldNames)
		{
			
			foreach (FieldDefinition field in fields)
			{
				if (!fieldNames.Contains(field.Name))
				{
					fieldNames.Add(field.Name);
					writer.WriteLine(@"		public const int TAG_{0} = {1};", field.Name, field.Tag);
				}
				if (field.IsGroup())
					GenMessageConstants(writer, field.Group, fieldNames);
			}
		}

		private string ConvertToGroupName(string countName)
		{
			if (string.Equals(countName, "LinesOfText"))
			{
				return "Text";
			}
			else if (countName.StartsWith("No"))
			{
				if (countName.EndsWith("s"))
				{
					return countName.Substring(2, countName.Length - 2 - 1);
				}
				else
				{
					return countName.Substring(2);
				}
			}
			else
			{
				throw new Exception(string.Format("CountName({0}) is unsupported", countName));
			}
		}

		private void GenMessage(XmlElement elemMessage)
		{
			string name = elemMessage.GetAttribute("name");
			List<FieldDefinition> fields = GetFieldDefinitions(elemMessage);
			string dataTypeName, dataTypePrefix;

			StreamWriter writer = new StreamWriter(_outputDir + name + ".cs");

			//header
			writer.WriteLine(@"using System;");
			writer.WriteLine(@"using System.Collections;");
			writer.WriteLine(@"using System.Text;");
			writer.WriteLine(@"");
			writer.WriteLine(@"using FIX = FIX4NET.FIX;");
			writer.WriteLine(@"");
			writer.WriteLine(@"namespace FIX4NET.FIX.FIX_4_4");
			writer.WriteLine(@"{");
			writer.WriteLine(@"	/// <summary>");
			writer.WriteLine(@"	/// Summary description for {0}.", name);
			writer.WriteLine(@"	/// </summary>");
			string inheritList = GetInheritList(name);
			writer.WriteLine(@"	public class {0} : {1}", name, inheritList);
			writer.WriteLine(@"	{");

			//constants
			GenMessageConstants(writer, fields);

			writer.WriteLine(@"");

			//local variables
			foreach (FieldDefinition field in fields)
			{
				dataTypeName = GetDataTypeName(field.DataType);
				dataTypePrefix = GetDataTypePrefix(field.DataType);
				writer.WriteLine(@"		private {1} _{2}{0};", field.Name, dataTypeName, dataTypePrefix);
				if (field.IsGroup())
				{
					string groupName = ConvertToGroupName(field.Name);
					writer.WriteLine(@"		private {0}{1}List _list{1} = new {0}{1}List();", name, groupName);
				}
			}

			writer.WriteLine(@"");

			//constructor
			writer.WriteLine(@"		public {0}() : base()", name);
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			_sMsgType = Values.MsgType.{0};", name);
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//properties
			foreach (FieldDefinition field in fields)
			{
				dataTypeName = GetDataTypeName(field.DataType);
				dataTypePrefix = GetDataTypePrefix(field.DataType);
				writer.WriteLine(@"		public {1} {0}", field.Name, dataTypeName);
				writer.WriteLine(@"		{");
				writer.WriteLine(@"			get {{ return _{1}{0}; }}", field.Name, dataTypePrefix);
				writer.WriteLine(@"			set {{ _{1}{0} = value; }}", field.Name, dataTypePrefix);
				writer.WriteLine(@"		}");
				if (field.IsGroup())
				{
					string groupName = ConvertToGroupName(field.Name);
					writer.WriteLine(@"		public {0}{1}List {1} ", name, groupName);
					writer.WriteLine(@"		{");
					writer.WriteLine(@"			get {{ return _list{0}; }}", groupName);
					writer.WriteLine(@"		}");					
				}
			}

			writer.WriteLine(@"");

			//this indexer
			//this prefix
			writer.WriteLine(@"		public override object this[int iTag]");
			writer.WriteLine(@"		{");
			//this get prefix
			writer.WriteLine(@"			get");
			writer.WriteLine(@"			{");
			writer.WriteLine(@"				switch (iTag)");
			writer.WriteLine(@"				{");
			//this get fields
			foreach (FieldDefinition field in fields)
			{
				dataTypePrefix = GetDataTypePrefix(field.DataType);
				writer.WriteLine(@"					case TAG_{0}:", field.Name);
				writer.WriteLine(@"						return _{1}{0};", field.Name, dataTypePrefix);
			}
			//this get suffix
			writer.WriteLine(@"					default:");
			writer.WriteLine(@"						return base[iTag];");
			writer.WriteLine(@"				}");
			writer.WriteLine(@"			}");
			//this set prefix
			writer.WriteLine(@"			set");
			writer.WriteLine(@"			{");
			writer.WriteLine(@"				switch (iTag)");
			writer.WriteLine(@"				{");
			//this set fields
			foreach (FieldDefinition field in fields)
			{
				dataTypeName = GetDataTypeName(field.DataType);
				dataTypePrefix = GetDataTypePrefix(field.DataType);
				writer.WriteLine(@"					case TAG_{0}:", field.Name);
				writer.WriteLine(@"						_{2}{0} = ({1})value;", field.Name, dataTypeName, dataTypePrefix);
				writer.WriteLine(@"						break;");
			}
			//this get suffix
			writer.WriteLine(@"					default:");
			writer.WriteLine(@"						base[iTag] = value;");
			writer.WriteLine(@"						break;");
			writer.WriteLine(@"				}");
			writer.WriteLine(@"			}");
			//this suffix
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//end class
			writer.WriteLine(@"	}");

			//group
			GenMessageGroups(writer, name, fields);

			//end namespace
			writer.WriteLine(@"}");

			writer.Close();
		}

		private void GenMessageGroups(StreamWriter writer, string name, List<FieldDefinition> fields)
		{
			string dataTypeName, dataTypePrefix;
			string groupName;

			foreach (FieldDefinition field in fields)
			{
				if (field.IsGroup())
				{
					groupName = ConvertToGroupName(field.Name);
					writer.WriteLine(@"");

					//class for group
					writer.WriteLine(@"	public class {0}{1}", name, groupName);
					writer.WriteLine(@"	{");
					//variables
					foreach (FieldDefinition fieldGroup in field.Group)
					{
						dataTypeName = GetDataTypeName(fieldGroup.DataType);
						dataTypePrefix = GetDataTypePrefix(fieldGroup.DataType);
						writer.WriteLine(@"		private {1} _{2}{0};", fieldGroup.Name, dataTypeName, dataTypePrefix);
						if (fieldGroup.IsGroup())
						{
							string groupName2 = ConvertToGroupName(fieldGroup.Name);
							writer.WriteLine(@"		private {0}{1}List _list{1} = new {0}{1}List();", name, groupName2);
						}
					}
					writer.WriteLine(@"");
					//properties
					foreach (FieldDefinition fieldGroup in field.Group)
					{
						dataTypeName = GetDataTypeName(fieldGroup.DataType);
						dataTypePrefix = GetDataTypePrefix(fieldGroup.DataType);
						writer.WriteLine(@"		public {1} {0}", fieldGroup.Name, dataTypeName);
						writer.WriteLine(@"		{");
						writer.WriteLine(@"			get {{ return _{1}{0}; }}", fieldGroup.Name, dataTypePrefix);
						writer.WriteLine(@"			set {{ _{1}{0} = value; }}", fieldGroup.Name, dataTypePrefix);
						writer.WriteLine(@"		}");
						if (fieldGroup.IsGroup())
						{
							string groupName2 = ConvertToGroupName(fieldGroup.Name);
							writer.WriteLine(@"		public {0}{1}List {1} ", name, groupName2);
							writer.WriteLine(@"		{");
							writer.WriteLine(@"			get {{ return _list{0}; }}", groupName2);
							writer.WriteLine(@"		}");
						}
					}
					writer.WriteLine(@"");
					//this(indexer)
					writer.WriteLine(@"		public object this[int iTag]");
					writer.WriteLine(@"		{");
					writer.WriteLine(@"			get");
					writer.WriteLine(@"			{");
					writer.WriteLine(@"				switch (iTag)");
					writer.WriteLine(@"				{");
					foreach (FieldDefinition fieldGroup in field.Group)
					{
						dataTypePrefix = GetDataTypePrefix(fieldGroup.DataType);
						writer.WriteLine(@"					case {0}.TAG_{1}:", name, fieldGroup.Name);
						writer.WriteLine(@"						return _{1}{0};", fieldGroup.Name, dataTypePrefix);
					}
					writer.WriteLine(@"					default:");
					writer.WriteLine(@"						throw new Exception(""Unknown field"");");
					writer.WriteLine(@"				}");
					writer.WriteLine(@"			}");
					writer.WriteLine(@"			set");
					writer.WriteLine(@"			{");
					writer.WriteLine(@"				switch (iTag)");
					writer.WriteLine(@"				{");
					foreach (FieldDefinition fieldGroup in field.Group)
					{
						dataTypeName = GetDataTypeName(fieldGroup.DataType);
						dataTypePrefix = GetDataTypePrefix(fieldGroup.DataType);
						writer.WriteLine(@"					case {0}.TAG_{1}:", name, fieldGroup.Name);
						writer.WriteLine(@"						_{2}{0} = ({1})value;", fieldGroup.Name, dataTypeName, dataTypePrefix);
						writer.WriteLine(@"						break;");
					}
					writer.WriteLine(@"					default:");
					writer.WriteLine(@"						throw new Exception(""Unknown field"");");
					writer.WriteLine(@"				}");
					writer.WriteLine(@"			}");
					writer.WriteLine(@"		}");
					writer.WriteLine(@"	}");

					//class for group list
					writer.WriteLine(@"");
					writer.WriteLine(@"	public class {0}{1}List", name, groupName);
					writer.WriteLine(@"	{");
					writer.WriteLine(@"		private ArrayList _al;");
					writer.WriteLine(@"		private {0}{1} _last;", name, groupName);
					writer.WriteLine(@"");
					writer.WriteLine(@"		public {0}{1} this[int i]", name, groupName);
					writer.WriteLine(@"		{");
					writer.WriteLine(@"			get");
					writer.WriteLine(@"			{");
					writer.WriteLine(@"				if (_al != null && i < _al.Count)");
					writer.WriteLine(@"					return ({0}{1})_al[i];", name, groupName);
					writer.WriteLine(@"				else");
					writer.WriteLine(@"					return null;");
					writer.WriteLine(@"			}");
					writer.WriteLine(@"		}");
					writer.WriteLine(@"");
					writer.WriteLine(@"		public int Count");
					writer.WriteLine(@"		{");
					writer.WriteLine(@"			get");
					writer.WriteLine(@"			{");
					writer.WriteLine(@"				if (_al != null)");
					writer.WriteLine(@"					return _al.Count;");
					writer.WriteLine(@"				else");
					writer.WriteLine(@"					return 0;");
					writer.WriteLine(@"			}");
					writer.WriteLine(@"		}");
					writer.WriteLine(@"");
					writer.WriteLine(@"		public void Clear()");
					writer.WriteLine(@"		{");
					writer.WriteLine(@"			_al = null;");
					writer.WriteLine(@"		}");
					writer.WriteLine(@"");
					writer.WriteLine(@"		public void Add({0}{1} item)", name, groupName);
					writer.WriteLine(@"		{");
					writer.WriteLine(@"			if (_al == null)");
					writer.WriteLine(@"				_al = new ArrayList();");
					writer.WriteLine(@"			_al.Add(item);");
					writer.WriteLine(@"			_last = item;");
					writer.WriteLine(@"		}");
					writer.WriteLine(@"");
					writer.WriteLine(@"		public void Remove({0}{1} item)", name, groupName);
					writer.WriteLine(@"		{");
					writer.WriteLine(@"			if (_al != null)");
					writer.WriteLine(@"				_al.Remove(item);");
					writer.WriteLine(@"		}");
					writer.WriteLine(@"");
					writer.WriteLine(@"		public void RemoveAt(int iIndex)");
					writer.WriteLine(@"		{");
					writer.WriteLine(@"			if (_al != null && iIndex < _al.Count)");
					writer.WriteLine(@"				_al.RemoveAt(iIndex);");
					writer.WriteLine(@"		}");
					writer.WriteLine(@"");
					writer.WriteLine(@"		public {0}{1} Last", name, groupName);
					writer.WriteLine(@"		{");
					writer.WriteLine(@"			get { return _last; }");
					writer.WriteLine(@"		}");
					writer.WriteLine(@"	}");

					//sub-groups
					GenMessageGroups(writer, name, field.Group);
				}
			}
		}

		private string GetInheritList(string name)
		{
			if (string.Equals(name, "Heartbeat"))
				return "Message, IMessageHeartbeat";
			else if (string.Equals(name, "Logon"))
				return "Message, IMessageLogon";
			else if (string.Equals(name, "Logout"))
				return "Message, IMessageLogout";
			else if (string.Equals(name, "Reject"))
				return "Message, IMessageReject";
			else if (string.Equals(name, "ResendRequest"))
				return "Message, IMessageResendRequest";
			else if (string.Equals(name, "SequenceReset"))
				return "Message, IMessageSequenceReset";
			else if (string.Equals(name, "TestRequest"))
				return "Message, IMessageTestRequest";
			else
				return "Message";
		}

		private List<FieldDefinition> GetFieldDefinitions(XmlElement elemMessage)
		{
			List<FieldDefinition> fields = new List<FieldDefinition>();

			FieldDefinition field = null;
			List<FieldDefinition> fieldsTemp = null;
			string required;

			foreach (XmlNode node in elemMessage.ChildNodes)
			{
				if (node.NodeType == XmlNodeType.Element)
				{
					XmlElement elem = (XmlElement)node;
					switch (elem.Name)
					{

						case "field":
							if (_fieldsByName.TryGetValue(elem.GetAttribute("name"), out field))
							{
								field = field.Clone();
								required = elem.GetAttribute("required");
								field.Required = string.Equals(required, "Y");
								fields.Add(field);
							}
							break;

						case "component":
							if (_componentsByName.TryGetValue(elem.GetAttribute("name"), out fieldsTemp))
							{
								fields.AddRange(fieldsTemp);
							}
							break;

						case "group":
							if (_fieldsByName.TryGetValue(elem.GetAttribute("name"), out field))
							{
								FieldDefinition fieldGroup = field.Clone();
								fieldGroup.CreateGroup();
								fieldsTemp = GetFieldDefinitions(elem);
								fieldsTemp[0].Required = true;
								fieldGroup.Group.AddRange(fieldsTemp);
								fields.Add(fieldGroup);
							}
							break;
					}				
				}
			}

			return fields;
		}

		private string GetDataTypeName(FieldDefinition.DataTypes dataType)
		{
			if (dataType == FieldDefinition.DataTypes.Boolean)
				return "bool";
			else if (dataType == FieldDefinition.DataTypes.Int)
				return "int";
			else if (dataType == FieldDefinition.DataTypes.Double)
				return "double";
			else if (dataType == FieldDefinition.DataTypes.Char)
				return "char";
			else if (dataType == FieldDefinition.DataTypes.String)
				return "string";
			else if (dataType == FieldDefinition.DataTypes.DateTimeUTC)
				return "DateTime";
			else if (dataType == FieldDefinition.DataTypes.DateUTC)
				return "DateTime";
			else if (dataType == FieldDefinition.DataTypes.TimeUTC)
				return "DateTime";
			else if (dataType == FieldDefinition.DataTypes.DateLocal)
				return "DateTime";
			else if (dataType == FieldDefinition.DataTypes.DateMonthYear)
				return "DateTime";
			else
				throw new Exception(string.Format("FieldDefinition.DataType({0}) is not supported", dataType));
		}

		private string GetDataTypePrefix(FieldDefinition.DataTypes dataType)
		{
			if (dataType == FieldDefinition.DataTypes.Boolean)
				return "b";
			else if (dataType == FieldDefinition.DataTypes.Int)
				return "i";
			else if (dataType == FieldDefinition.DataTypes.Double)
				return "d";
			else if (dataType == FieldDefinition.DataTypes.Char)
				return "c";
			else if (dataType == FieldDefinition.DataTypes.String)
				return "s";
			else if (dataType == FieldDefinition.DataTypes.DateTimeUTC)
				return "dt";
			else if (dataType == FieldDefinition.DataTypes.DateUTC)
				return "dt";
			else if (dataType == FieldDefinition.DataTypes.TimeUTC)
				return "dt";
			else if (dataType == FieldDefinition.DataTypes.DateLocal)
				return "dt";
			else if (dataType == FieldDefinition.DataTypes.DateMonthYear)
				return "dt";
			else
				throw new Exception(string.Format("FieldDefinition.DataType({0}) is not supported", dataType));
		}

		private void GenMessageFactory(XmlElement elemMessages)
		{
			XmlElement elemMessage;
			string name;
			List<FieldDefinition> fields;
			string dataTypeName, dataTypePrefix;

			StreamWriter writer = new StreamWriter(_outputDir + @"MessageFactoryFIX.cs");

			//header
			writer.WriteLine(@"using System;");
			writer.WriteLine(@"using System.Collections;");
			writer.WriteLine(@"using System.Text;");
			writer.WriteLine(@"");
			writer.WriteLine(@"using FIX = FIX4NET.FIX;");
			writer.WriteLine(@"");
			writer.WriteLine(@"namespace FIX4NET.FIX.FIX_4_4");
			writer.WriteLine(@"{");
			writer.WriteLine(@"	/// <summary>");
			writer.WriteLine(@"	/// Summary description for MessageFactory.");
			writer.WriteLine(@"	/// </summary>");
			writer.WriteLine(@"	public class MessageFactoryFIX : FIX.MessageFactoryFIX");
			writer.WriteLine(@"	{");
			writer.WriteLine(@"		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);");

			writer.WriteLine(@"");

			//method IsRelatedMessage
			writer.WriteLine(@"		public override bool IsRelatedMessage(string sMessage)");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			return sMessage.StartsWith(""8=FIX.4.4"");");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//method CreateInstance
			writer.WriteLine(@"		public override IMessage CreateInstance(string sMsgType)");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			switch (sMsgType)");
			writer.WriteLine(@"			{");
			foreach (XmlNode node in elemMessages.ChildNodes)
			{
				if (string.Equals(node.Name, "message") && node.NodeType == XmlNodeType.Element)
				{
					elemMessage = (XmlElement)node;
					name = elemMessage.GetAttribute("name");
					writer.WriteLine(@"				case Values.MsgType.{0}:", name);
					writer.WriteLine(@"					return new {0}();", name);
				}
			}
			writer.WriteLine(@"				default:");
			writer.WriteLine(@"					return null;");
			writer.WriteLine(@"			}");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//method CreateInstanceReject
			writer.WriteLine(@"		public override IMessageReject CreateInstanceReject(ParseFieldException exParse)");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			Reject reject = new Reject();");
			writer.WriteLine(@"			reject.RefSeqNum = exParse.RefSeqNum;");
			writer.WriteLine(@"			reject.Text = exParse.Text;");
			writer.WriteLine(@"			if (exParse is ParseFieldExceptionFIX)");
			writer.WriteLine(@"			{");
			writer.WriteLine(@"				ParseFieldExceptionFIX exParseFIX = (ParseFieldExceptionFIX)exParse;");
			writer.WriteLine(@"				reject.RefTagID = exParseFIX.RefTagID;");
			writer.WriteLine(@"				reject.RefMsgType = exParseFIX.RefMsgType;");
			writer.WriteLine(@"				reject.SessionRejectReason = exParseFIX.SessionRejectReason;");
			writer.WriteLine(@"			}");
			writer.WriteLine(@"			return reject;");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//method CreateInstanceParseFieldException
			writer.WriteLine(@"		protected override ParseFieldException CreateInstanceParseFieldException(string sMessage, Exception exInner, Field field, string sMessageRaw)");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			ParseFieldExceptionFIX ex = new ParseFieldExceptionFIX(sMessage, exInner);");
			writer.WriteLine(@"			ex.RefSeqNum = ParseMsgSeqNum(sMessageRaw);");
			writer.WriteLine(@"			ex.RefTagID = field.Tag;");
			writer.WriteLine(@"			ex.RefMsgType = ParseMsgType(sMessageRaw);");
			writer.WriteLine(@"			ex.SessionRejectReason = 5;");
			writer.WriteLine(@"			ex.Text = string.Format(""PARSE ERROR ON TAG {{0}}"", field.Tag);");
			writer.WriteLine(@"			return ex;");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//method ToFIXUTCTimeOnly
			writer.WriteLine(@"		/// <summary>");
			writer.WriteLine(@"		/// Converts from a DateTime object to the standard FIX UTC Timestamp format.");
			writer.WriteLine(@"		/// </summary>");
			writer.WriteLine(@"		public static string ToFIXUTCTimeOnly(DateTime dt)");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			return dt.ToString(""HH:mm:ss"");");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//method FromFIXUTCTimeOnly
			writer.WriteLine(@"		/// <summary>");
			writer.WriteLine(@"		/// Converts from the standard FIX UTC Timestamp to a DateTime object.");
			writer.WriteLine(@"		/// </summary>");
			writer.WriteLine(@"		public static DateTime FromFIXUTCTimeOnly(string s)");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			int iHour = ParseInt(s, 0, 2);");
			writer.WriteLine(@"			int iMin = ParseInt(s, 3, 2);");
			writer.WriteLine(@"			int iSec = ParseInt(s, 6, 2);");
			writer.WriteLine(@"			DateTime dt = new DateTime(1900, 1, 1, iHour, iMin, iSec);");
			writer.WriteLine(@"			return dt;");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//method ToFIXUTCDateOnly
			writer.WriteLine(@"		/// <summary>");
			writer.WriteLine(@"		/// Converts from a DateTime object to the standard FIX UTC Timestamp format.");
			writer.WriteLine(@"		/// </summary>");
			writer.WriteLine(@"		public static string ToFIXUTCDateOnly(DateTime dt)");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			return dt.ToString(""yyyyMMdd"");");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//method FromFIXUTCDateOnly
			writer.WriteLine(@"		/// <summary>");
			writer.WriteLine(@"		/// Converts from the standard FIX UTC Timestamp to a DateTime object.");
			writer.WriteLine(@"		/// </summary>");
			writer.WriteLine(@"		public static DateTime FromFIXUTCDateOnly(string s)");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			int iYear = ParseInt(s, 0, 4);");
			writer.WriteLine(@"			int iMonth = ParseInt(s, 4, 2);");
			writer.WriteLine(@"			int iDay = ParseInt(s, 6, 2);");
			writer.WriteLine(@"			DateTime dt = new DateTime(iYear, iMonth, iDay);");
			writer.WriteLine(@"			return dt;");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//method CreateMessageHelper
			writer.WriteLine(@"		protected override MessageHelper CreateMessageHelper(IMessage message)");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			switch (message.MsgType)");
			writer.WriteLine(@"			{");
			foreach (XmlNode node in elemMessages.ChildNodes)
			{
				if (string.Equals(node.Name, "message") && node.NodeType == XmlNodeType.Element)
				{
					elemMessage = (XmlElement)node;
					name = elemMessage.GetAttribute("name");
					writer.WriteLine(@"				case Values.MsgType.{0}:", name);
					writer.WriteLine(@"					return new MessageHelper{0}(message);", name);
				}
			}
			writer.WriteLine(@"				default:");
			writer.WriteLine(@"					return null;");
			writer.WriteLine(@"			}");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//class MessageHelper_4_4
			writer.WriteLine(@"		protected class MessageHelper_4_4 : MessageHelper");
			writer.WriteLine(@"		{");
			writer.WriteLine(@"			private Message _message;");
			writer.WriteLine(@"			public MessageHelper_4_4(IMessage message)");
			writer.WriteLine(@"				: base(message)");
			writer.WriteLine(@"			{");
			writer.WriteLine(@"				_message = (Message)message;");
			writer.WriteLine(@"			}");
			writer.WriteLine(@"			public override void BuildBody(StringBuilder sb)");
			writer.WriteLine(@"			{");
			writer.WriteLine(@"				base.BuildBody(sb);");
			writer.WriteLine(@"			}");
			writer.WriteLine(@"			public override void ParseField(Field field)");
			writer.WriteLine(@"			{");
			writer.WriteLine(@"				base.ParseField(field);");
			writer.WriteLine(@"			}");
			writer.WriteLine(@"		}");

			writer.WriteLine(@"");

			//class MessageHelper<?>
			foreach (XmlNode node in elemMessages.ChildNodes)
			{
				if (string.Equals(node.Name, "message") && node.NodeType == XmlNodeType.Element)
				{
					elemMessage = (XmlElement)node;
					name = elemMessage.GetAttribute("name");
					fields = GetFieldDefinitions(elemMessage);
					writer.WriteLine(@"		protected class MessageHelper{0} : MessageHelper_4_4", name);
					writer.WriteLine(@"		{");
					//constants
					GenMessageHelperConstants(writer, name, fields);
					writer.WriteLine(@"");
					writer.WriteLine(@"			private {0} _message;", name);
					writer.WriteLine(@"");
					writer.WriteLine(@"			public MessageHelper{0}(IMessage message) : base(message)", name);
					writer.WriteLine(@"			{");
					writer.WriteLine(@"				_message = ({0})message;", name);
					writer.WriteLine(@"			}");
					writer.WriteLine(@"");
					//build
					writer.WriteLine(@"			public override void BuildBody(StringBuilder sb)");
					writer.WriteLine(@"			{");
					writer.WriteLine(@"				base.BuildBody(sb);");
					//build fields
					GenMessageHelplerBuildFields(writer, name, fields, "_message");
					writer.WriteLine(@"			}");
					writer.WriteLine(@"");
					//parse
					writer.WriteLine(@"			public override void ParseField(Field field)");
					writer.WriteLine(@"			{");
					writer.WriteLine(@"				switch (field.Tag)");
					writer.WriteLine(@"				{");
					foreach (FieldDefinition field in fields)
					{
						string parseFormat = GetParseFormat(field.DataType);
						writer.WriteLine(@"					case {0}.TAG_{1}:", name, field.Name);
						writer.WriteLine(parseFormat, field.Name);
						writer.WriteLine(@"						break;");
					}
					writer.WriteLine(@"					default:");
					writer.WriteLine(@"						base.ParseField(field);");
					writer.WriteLine(@"						break;");
					writer.WriteLine(@"				}");
					writer.WriteLine(@"			}");
					writer.WriteLine(@"		}");

					writer.WriteLine(@"");
				}
			}

			//trailer
			writer.WriteLine(@"	}");
			writer.WriteLine(@"}");

			writer.Close();
		}

		private void GenMessageHelperConstants(StreamWriter writer, string name, List<FieldDefinition> fields)
		{
			GenMessageHelperConstants(writer, name, fields, new List<string>());
		}

		private void GenMessageHelperConstants(StreamWriter writer, string name, List<FieldDefinition> fields, List<string> fieldNames)
		{
			foreach (FieldDefinition field in fields)
			{
				if (!fieldNames.Contains(field.Name))
				{
					fieldNames.Add(field.Name);
					writer.WriteLine(@"			private static string TAG_PREFIX_{1} = {0}.TAG_{1}.ToString() + TAG_DELIM;", name, field.Name);
				}
				if (field.IsGroup())
					GenMessageHelperConstants(writer, name, field.Group, fieldNames);
			}
		}

		private void GenMessageHelplerBuildFields(StreamWriter writer, string name, List<FieldDefinition> fields, string varName)
		{
			foreach (FieldDefinition field in fields)
			{
				if (!field.IsGroup())
				{
					string appendCheck = GetAppendCheck(field.DataType);
					string appendFormat = GetAppendFormat(field.DataType);
					if (!field.Required)
						writer.WriteLine(appendCheck, field.Name, varName);
					writer.WriteLine(@"				{");
					writer.WriteLine(@"					sb.Append(TAG_PREFIX_{0});", field.Name);
					writer.WriteLine(appendFormat, field.Name, varName);
					writer.WriteLine(@"					sb.Append(FIELD_DELIM);");
					writer.WriteLine(@"				}");
				}
				else
				{
					GenMessageHelperBuildGroup(writer, name, field, varName);
				}
			}
		}

		private void GenMessageHelperBuildGroup(StreamWriter writer, string name, FieldDefinition field, string varName)
		{
			string groupName = ConvertToGroupName(field.Name);
			writer.WriteLine(@"				{2}.{1} = {2}.{0}.Count;", groupName, field.Name, varName);
			writer.WriteLine(@"				if ({1}.{0} > 0)", field.Name, varName);
			writer.WriteLine(@"				{");
			writer.WriteLine(@"					sb.Append(TAG_PREFIX_{0});", field.Name);
			writer.WriteLine(@"					sb.Append({1}.{0});", field.Name, varName);
			writer.WriteLine(@"					sb.Append(FIELD_DELIM);");
			writer.WriteLine(@"					{0}{1} item{1};", name, groupName);
			writer.WriteLine(@"					for (int i{0} = 0; i{0} < {2}.{1}; i{0}++)", groupName, field.Name, varName);
			writer.WriteLine(@"					{");
			writer.WriteLine(@"						item{0} = {1}.{0}[i{0}];", groupName, varName);
			GenMessageHelplerBuildFields(writer, name, field.Group, "item" + groupName);
			writer.WriteLine(@"					}");
			writer.WriteLine(@"				}");
		}

		private string GetAppendCheck(FieldDefinition.DataTypes dataType)
		{
			switch (dataType)
			{
				case FieldDefinition.DataTypes.Boolean:
					return "				if ({1}.{0})";
				case FieldDefinition.DataTypes.Int:
					return "				if ({1}.{0} > 0)";
				case FieldDefinition.DataTypes.Double:
					return "				if ({1}.{0} > 0)";
				case FieldDefinition.DataTypes.Char:
					return "				if ({1}.{0} != '\\0')";
				case FieldDefinition.DataTypes.String:
					return "				if ({1}.{0} != null && {1}.{0}.Length > 0)";
				case FieldDefinition.DataTypes.DateTimeUTC:
					return "				if ({1}.{0} > DateTime.MinValue)";
				case FieldDefinition.DataTypes.DateUTC:
					return "				if ({1}.{0} > DateTime.MinValue)";
				case FieldDefinition.DataTypes.TimeUTC:
					return "				if ({1}.{0} > DateTime.MinValue)";
				case FieldDefinition.DataTypes.DateLocal:
					return "				if ({1}.{0} > DateTime.MinValue)";
				case FieldDefinition.DataTypes.DateMonthYear:
					return "				if ({1}.{0} > DateTime.MinValue)";
				default:
					throw new Exception(string.Format("FieldDefinition.DataTypes({0}) is not supported", dataType));
			}
		}

		private string GetAppendFormat(FieldDefinition.DataTypes dataType)
		{
			switch (dataType)
			{
				case FieldDefinition.DataTypes.Boolean:
					return "					sb.Append(ToFIXBoolean({1}.{0}));";
				case FieldDefinition.DataTypes.Int:
					return "					sb.Append({1}.{0});";
				case FieldDefinition.DataTypes.Double:
					return "					sb.Append({1}.{0});";
				case FieldDefinition.DataTypes.Char:
					return "					sb.Append({1}.{0});";
				case FieldDefinition.DataTypes.String:
					return "					sb.Append({1}.{0});";
				case FieldDefinition.DataTypes.DateTimeUTC:
					return "					sb.Append(ToFIXUTCTimestamp({1}.{0}));";
				case FieldDefinition.DataTypes.DateUTC:
					return "					sb.Append(ToFIXUTCDateOnly({1}.{0}));";
				case FieldDefinition.DataTypes.TimeUTC:
					return "					sb.Append(ToFIXUTCTimeOnly({1}.{0}));";
				case FieldDefinition.DataTypes.DateLocal:
					return "					sb.Append(ToFIXLocalMktDate({1}.{0}));";
				case FieldDefinition.DataTypes.DateMonthYear:
					return "					sb.Append(ToFIXMonthYear({1}.{0}));";
				default:
					throw new Exception(string.Format("FieldDefinition.DataTypes({0}) is not supported", dataType));
			}
		}

		private string GetParseFormat(FieldDefinition.DataTypes dataType)
		{
			switch (dataType)
			{
				case FieldDefinition.DataTypes.Boolean:
					return "						_message.{0} = FromFIXBoolean(field.Value);";
				case FieldDefinition.DataTypes.Int:
					return "						_message.{0} = ParseInt(field.Value);";
				case FieldDefinition.DataTypes.Double:
					return "						_message.{0} = double.Parse(field.Value);";
				case FieldDefinition.DataTypes.Char:
					return "						_message.{0} = field.Value[0];";
				case FieldDefinition.DataTypes.String:
					return "						_message.{0} = field.Value;";
				case FieldDefinition.DataTypes.DateTimeUTC:
					return "						_message.{0} = FromFIXUTCTimestamp(field.Value);";
				case FieldDefinition.DataTypes.DateUTC:
					return "						_message.{0} = FromFIXUTCTimestamp(field.Value);";
				case FieldDefinition.DataTypes.TimeUTC:
					return "						_message.{0} = FromFIXUTCTimestamp(field.Value);";
				case FieldDefinition.DataTypes.DateLocal:
					return "						_message.{0} = FromFIXLocalMktDate(field.Value);";
				case FieldDefinition.DataTypes.DateMonthYear:
					return "						_message.{0} = FromFIXMonthYear(field.Value);";
				default:
					throw new Exception(string.Format("FieldDefinition.DataTypes({0}) is not supported", dataType));
			}
		}
	}
}
