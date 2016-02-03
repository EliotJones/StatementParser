namespace BankStatementParser.Domain.Rule
{
    using System.Collections.Generic;

    public interface IRuleContainer
    {
        IList<PointRule> PointRules { get; }

        IList<SeriesRule> SeriesRules { get; } 
    }
}