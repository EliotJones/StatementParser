namespace BankStatementParser.Domain.Rule
{
    using Entities;

    public struct TypeWeighting
    {
        public TransactionType Type { get; private set; }

        public Weighting Weighting { get; private set; }

        public TypeWeighting(TransactionType type, int weighting) : this(type, new Weighting(weighting))
        {
        }

        public TypeWeighting(TransactionType type, Weighting weighting)
        {
            Type = type;
            Weighting = weighting;
        }
    }
}