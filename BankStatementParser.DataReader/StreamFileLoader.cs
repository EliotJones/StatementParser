namespace BankStatementParser.DataReader
{
    using System.IO;

    public class StreamFileLoader : IFileLoader
    {
        public string ReadAsString(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}