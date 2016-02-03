namespace BankStatementParser.Domain.Entities
{
    using System;

    public class Transaction
    {
        public DateTime Date { get; private set; }

        public Description Description { get; private set; }

        public decimal Amount { get; private set; }

        public Transaction(DateTime date, Description description, decimal amount)
        {
            Date = date;
            Description = description;
            Amount = amount;
        }
    }
}
