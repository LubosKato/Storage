namespace CRWHomework
{
	public interface IFormat
	{
		public Document ReadFormat(string value);

		public string WriteFormat(Document Document);
	}
}
