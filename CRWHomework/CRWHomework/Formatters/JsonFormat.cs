
using Newtonsoft.Json;

namespace CRWHomework.Formatters
{
	public class JsonFormat : IFormat
	{
		public Document ReadFormat(string value)
		{
			return (Document)JsonConvert.DeserializeObject(value);
		}

		public string WriteFormat(Document doc)
{
			return JsonConvert.SerializeObject(doc, Formatting.Indented);
		}
	}
}
