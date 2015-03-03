using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Xml;

internal class Serializer
{
    internal static string Serialize(object o, Type type)
    {
        string xml = string.Empty;
        XmlSerializer ser = new XmlSerializer(type);
        using (MemoryStream memStream = new MemoryStream())
        {
            using (XmlTextWriter xmlWriter = new XmlTextWriter(memStream, Encoding.UTF8))
            {
                ser.Serialize(xmlWriter, o);
                xml = Encoding.UTF8.GetString(memStream.GetBuffer()).Trim();
            }
        }
        return xml;
    }

    internal static object DeSerialize(string xml, Type type)
    {
        object o = null;
        XmlSerializer ser = new XmlSerializer(type);
        using (StringReader stringReader = new StringReader(xml))
        {
            using (XmlTextReader xmlReader = new XmlTextReader(stringReader))
            {
                o = ser.Deserialize(xmlReader);
            }
        }
        return o;
    }
}