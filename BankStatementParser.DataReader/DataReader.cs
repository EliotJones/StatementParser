namespace BankStatementParser.DataReader
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using Domain.Entities;

    public class DataReader
    {
        public IEnumerable<Transaction> Read(string csvFileContents)
        {
            using (var textReader = new StringReader(csvFileContents))
            {
                var parser = new CsvReader(textReader);

                parser.Configuration.Delimiter = ";";
                parser.Configuration.RegisterClassMap<SantanderCsvMap>();

                var data = parser.GetRecords<SantanderCsvData>();

                return data.Select(d => new Transaction(d.Date, d.Description, d.Amount)).ToArray();
            }
        }
    }
}
