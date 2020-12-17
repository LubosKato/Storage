using System.IO;

namespace CRWHomework.DataAccess
{
	public class FileSystem : IDataAccess
	{
		public string Read(string connectionString)
		{
			var sourceFileName = Path.Combine(connectionString);
			try
            {
                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                var reader = new StreamReader(sourceStream);
                return reader.ReadToEnd();
            }
            catch
            {
                throw;
            }
		}

		public void Write(string connectionString, string file)
		{
            try  
            {  
            using (StreamWriter writer = new StreamWriter(connectionString))  
                {  
                    writer.Write(file);
                }  
            }  
            catch 
            {  
                throw;
            }
		}
	}
}
