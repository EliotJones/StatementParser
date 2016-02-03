namespace BankStatementParser.Tests.Fakes
{
    using DataReader;

    public class TestFileLoader : IFileLoader
    {
        public string ReturnValue { get; set; }

        public string ReadAsString(string filePath)
        {
            return ReturnValue;
        }
    }
}
