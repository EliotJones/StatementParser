namespace BankStatementParser.Tests.RuleContainers
{
    using DataReader;
    using DataReader.RuleContainers;
    using Fakes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Shouldly;

    public class JsonRuleContainerTests
    {
        private readonly TestFileLoader fileLoader = new TestFileLoader();
        
        public void CanReadDescriptionRules()
        {
            fileLoader.ReturnValue = @"{
  ""PointRules"": {
    ""DescriptionRules"" : [
        {
                    ""Terms"": [ ""waitrose"", ""sainsbury"", ""tesco"", ""asda"", ""lidl"", ""morrisons"", ""m&s"", ""aldi"" ],
          ""Location"": ""Contains"",
          ""SuggestedType"": ""Food"",
          ""Weighting"": 100
        },
        {
          ""Terms"": [ ""spotify"", ""prime"", ""sky"", ""netflix"", ""blinkbox"" ],
          ""Location"": ""Contains"",
          ""SuggestedType"": ""Entertainment"",
          ""Weighting"": 100
        },
        {
          ""Terms"": [ ""bar"", ""club"" ],
          ""Location"": ""Contains"",
          ""SuggestedType"": ""Entertainment"",
          ""Weighting"" :  100
        }
        ]
    }
}
";

            var container = new JsonRuleContainer(new JsonSerializer
            {
                Converters = { new StringEnumConverter(), new WeightingConverter() }
            }, string.Empty, fileLoader);

            container.PointRules.Count.ShouldBe(3);
        }
    }
}
