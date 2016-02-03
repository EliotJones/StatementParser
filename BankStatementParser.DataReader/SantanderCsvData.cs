namespace BankStatementParser.DataReader
{
    using System;
    using Domain.Entities;

    internal class SantanderCsvData
    {
        public DateTime Date { get; set; }

        public Description Description { get; set; }

        public decimal Amount { get; set; }
    }
}