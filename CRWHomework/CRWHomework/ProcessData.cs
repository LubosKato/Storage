using CRWHomework.DataAccess;
using CRWHomework.Formatters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CRWHomework
{
	public class ProcessData
	{
		private readonly IDataAccess fileDataAccess;
		private readonly IDataAccess cloudDataAccess;
		private readonly IFormat xmlFormat;
		private readonly IFormat jsonFormat;
		            
		// TODO add to config
		const string inputPath = "..\\..\\..\\Source Files\\Document1.xml";
		const string outputPath = "..\\..\\..\\Target Files\\Document1.json";

		public ProcessData(IEnumerable<IDataAccess> acesses, IEnumerable<IFormat> formats)
		{
			this.fileDataAccess = acesses.First(o => o.GetType() == typeof(FileSystem));
            this.cloudDataAccess = acesses.First(o => o.GetType() == typeof(Cloud));
            this.xmlFormat = formats.First(o => o.GetType() == typeof(XmlFormat));
            this.jsonFormat = formats.First(o => o.GetType() == typeof(JsonFormat));
		}

		public void Logic()
		{
			var input = this.fileDataAccess.Read(Path.Combine(Environment.CurrentDirectory, inputPath));
            var formated = this.xmlFormat.ReadFormat(input);
            var formatToWrite = this.jsonFormat.WriteFormat(formated);
			this.fileDataAccess.Write(Path.Combine(Environment.CurrentDirectory, outputPath), formatToWrite);
			// use this for cloud upload
            // this.cloudDataAccess.Write(Path.Combine(Environment.CurrentDirectory, outputPath), formatToWrite);
		}
	}
}
