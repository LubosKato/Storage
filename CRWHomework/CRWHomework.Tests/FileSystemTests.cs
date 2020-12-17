using CRWHomework.DataAccess;
using NUnit.Framework;

namespace CRWHomework.Tests
{
	public class FileSystemTests
	{
		FileSystem fileSystem;
		// TODO from config
		const string inputPath = "..\\..\\..\\Source Files\\Document1.xml";
		const string outputPath = "..\\..\\..\\Target Files\\Document1.json";

		[SetUp]
		public void Setup()
		{
			fileSystem = new FileSystem();
		}

		[Test]
		public void ShouldReadFromFileSystem()
		{
			var result = fileSystem.Read(inputPath);
			Assert.IsTrue(result.Contains("Document"));
		}

		[Test]
		public void ShouldWriteToFileSystem()
		{
			fileSystem.Write(outputPath, "xxx");
			var result = fileSystem.Read(outputPath);
			Assert.IsTrue(result.Contains("xxx"));
		}
	}
}