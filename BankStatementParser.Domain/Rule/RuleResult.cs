namespace BankStatementParser.Domain.Rule
{
    using System.Collections.Generic;

    public class RuleResult
    {
        public bool HasResults
        {
            get { return Weightings != null && Weightings.Count > 0; } 
        }

        public ICollection<TypeWeighting> Weightings { get; private set; }

        public RuleResult()
        {
        }

        public RuleResult(ICollection<TypeWeighting> weightings)
        {
            Weightings = weightings;
        }

        public RuleResult(TypeWeighting weighting)
        {
            Weightings = new List<TypeWeighting> { weighting };
        }
    }
}
