namespace BankStatementParser.DataReader.RuleContainers
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Rule;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class JsonRuleContainer : IRuleContainer
    {
        public JsonRuleContainer(JsonSerializer serializer, string fileLocation, IFileLoader fileLoader)
        {
            var content = fileLoader.ReadAsString(fileLocation);
            
            var result = JsonConvert.DeserializeObject<JObject>(content);

            var descriptionRules = result["PointRules"]["DescriptionRules"].Select(t => t.ToObject<DescriptionRule>(serializer)).ToList();

            PointRules = new List<PointRule>(descriptionRules);

            SeriesRules = new List<SeriesRule>();
        }

        public IList<PointRule> PointRules { get; }
        public IList<SeriesRule> SeriesRules { get; }
    }
}
