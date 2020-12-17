using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CRWHomework.Formatters
{
	public class XmlFormat : IFormat
	{
		public Document ReadFormat(string input)
		{
			var xdoc = XDocument.Parse(input);
			var doc = new Document
			{
				Title = xdoc.Root.Element("title").Value,
				Text = xdoc.Root.Element("text").Value
			};
			return doc;
		}

		public string WriteFormat(Document value)
		{
			 var xsSubmit = new XmlSerializer(typeof(Document));
			 var subReq = new Document();
			 var xml = "";

			 using(var sww = new StringWriter())
			 {
				 using(XmlWriter writer = XmlWriter.Create(sww))
				 {
					 xsSubmit.Serialize(writer, subReq);
					 xml = sww.ToString();
				 }
			 }
			 return xml;
		}
	}
}
