using CRWHomework.Formatters;
using NUnit.Framework;

namespace CRWHomework.Tests
{
	public class XmlFormatTests
	{
		private XmlFormat format;

		[SetUp]
		public void Setup()
		{
			format = new XmlFormat();
		}

		[Test]
		public void ShouldReadTextFromXMlDocument()
		{
			var testString = @"
				<Document>
				  <title>Jim</title>
				  <text>Smith</text>
				</Document>
				";
			var document = format.ReadFormat(testString);
			Assert.AreEqual(document.Text, "Smith");
		}
	}
}