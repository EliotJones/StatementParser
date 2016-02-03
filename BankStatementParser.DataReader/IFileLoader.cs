namespace BankStatementParser.DataReader
{
    public interface IFileLoader
    {
        string ReadAsString(string filePath);
    }
}
