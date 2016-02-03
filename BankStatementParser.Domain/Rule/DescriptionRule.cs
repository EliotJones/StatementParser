namespace BankStatementParser.Domain.Rule
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities;

    public class DescriptionRule : PointRule
    {
        public IList<string> Terms { get; }
        public TextLookup Location { get; }
        public TransactionType SuggestedType { get; }
        public Weighting Weighting { get; }

        public DescriptionRule(IList<string> terms, TextLookup location, TransactionType suggestedType, Weighting weighting)
        {
            Terms = terms;
            Location = location;
            SuggestedType = suggestedType;
            Weighting = weighting;
        }

        public override RuleResult Run(Transaction transaction)
        {
            var descriptionContainsTerm = false;

            switch (Location)
            {
                case TextLookup.StartsWith:
                    descriptionContainsTerm = Terms.Any(transaction.Description.StartsWithFragment);
                    break;
                case TextLookup.EndsWith:
                    descriptionContainsTerm = Terms.Any(transaction.Description.EndWithFragment);
                    break;
                case TextLookup.Entire:
                    descriptionContainsTerm = Terms.Any(transaction.Description.IsFragment);
                    break;
                case TextLookup.ContainsWord:
                    descriptionContainsTerm = Terms.Any(transaction.Description.ContainsFragmentAsWord);
                    break;
                default:
                    descriptionContainsTerm = Terms.Any(transaction.Description.ContainsFragment);
                    break;
            }

            if (descriptionContainsTerm)
            {
                return new RuleResult(new TypeWeighting(SuggestedType, Weighting));
            }

            return null;
        }
    }
}
