namespace CRWHomework
{
	public interface IDataAccess
	{
		public string Read(string connectionString);

		public void Write(string connectionString, string file);
	}
}
