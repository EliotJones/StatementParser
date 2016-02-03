namespace BankStatementParser.Domain.Rule
{
    using System.Collections.Generic;
    using System.Linq;

    public class AggregateRuleContainer : IRuleContainer
    {
        private readonly List<IRuleContainer> containers;
        
        public AggregateRuleContainer() : this(new List<IRuleContainer>())
        {
        }

        public AggregateRuleContainer(IEnumerable<IRuleContainer> containers)
        {
            this.containers = new List<IRuleContainer>(containers);
        }

        public void Add(IRuleContainer ruleContainer)
        {
            containers.Add(ruleContainer);
        }

        public IList<PointRule> PointRules
        {
            get { return containers.SelectMany(c => c.PointRules).ToArray(); }
        }

        public IList<SeriesRule> SeriesRules
        {
            get { return containers.SelectMany(c => c.SeriesRules).ToArray(); }
        }
    }
}
