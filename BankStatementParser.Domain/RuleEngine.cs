namespace BankStatementParser.Domain
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Entities;
    using Rule;

    public class RuleEngine
    {
        private readonly IList<PointRule> pointRules;

        public RuleEngine(AggregateRuleContainer ruleContainer)
        {
            pointRules = ruleContainer.PointRules;
        }

        public void Run(IEnumerable<Transaction> transactions)
        {
            var ruleOutcomes = new List<RulesOutcome>();

            foreach (var transaction in transactions)
            {
                var ruleOutcome = new RulesOutcome(transaction);

                RunPointRules(transaction, ruleOutcome);

                ruleOutcomes.Add(ruleOutcome);
            }

            Debug.Write(ruleOutcomes.Count);
        }

        private RulesOutcome RunPointRules(Transaction transaction, RulesOutcome ruleOutcome)
        {
            foreach (var pointRule in pointRules)
            {
                ruleOutcome.Add(pointRule.Run(transaction));
            }

            return ruleOutcome;
        }
    }
}
