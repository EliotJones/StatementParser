namespace BankStatementParser.DataReader
{
    using CsvHelper.Configuration;
    using Domain.Entities;

    internal sealed class SantanderCsvMap : CsvClassMap<SantanderCsvData>
    {
        public SantanderCsvMap()
        {
            Map(m => m.Date).Index(0);
            Map(m => m.Description).ConvertUsing(r => new Description(r[1]));
            Map(m => m.Amount).ConvertUsing(r =>  decimal.Parse(r[2].Substring(1)));
        }
    }
}
