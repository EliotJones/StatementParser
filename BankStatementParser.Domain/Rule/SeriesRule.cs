namespace BankStatementParser.Domain.Rule
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities;

    public abstract class SeriesRule
    {
        public abstract IEnumerable<RuleResult> Run(Transaction transaction,
            IOrderedEnumerable<Transaction> transactions);
    }
}
