using System;
using System.Configuration;
using System.Xml;

namespace SocketEngineBasic
{
    public class FixFieldsConfigurationSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            FIX4NET.FieldCollection fields = new FIX4NET.FieldCollection();

            foreach (XmlNode node in section.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element && string.Equals(node.Name, "field"))
                {
                    XmlElement element = (XmlElement)node;
                    int tag = int.Parse(element.GetAttribute("tag"));
                    string value = element.GetAttribute("value");
                    FIX4NET.IField field = new FIX4NET.FIX.Field(tag, value);
                    fields.Add(field);
                }
            }

            return fields;
        }

    }
}
