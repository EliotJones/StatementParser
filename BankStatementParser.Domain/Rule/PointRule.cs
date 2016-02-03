namespace BankStatementParser.Domain.Rule
{
    using Entities;

    public abstract class PointRule
    {
        public abstract RuleResult Run(Transaction transaction);
    }
}
