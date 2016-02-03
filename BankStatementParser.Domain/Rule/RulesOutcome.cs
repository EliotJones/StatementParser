namespace BankStatementParser.Domain.Rule
{
    using System.Collections.Generic;
    using Entities;

    public class RulesOutcome
    {
        public Transaction Transaction { get; }

        public IList<RuleResult> Results { get; }

        public RulesOutcome(Transaction transaction)
        {
            Transaction = transaction;
            Results = new List<RuleResult>();
        }

        public void Add(RuleResult result)
        {
            if (result != null)
            {
                Results.Add(result);
            }
        }
    }
}
