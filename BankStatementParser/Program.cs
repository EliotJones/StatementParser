namespace BankStatementParser
{
    using System;
    using DataReader;
    using DataReader.RuleContainers;
    using Domain;
    using Domain.Rule;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Program
    {
        private static readonly string DataLocation = "..\\..\\data\\test-data.csv";
        private static readonly string RulesLocation = "rules\\Descriptions.json";

        public static void Main(string[] args)
        {
            var dataReader = new DataReader.DataReader();
            var fileLoader = new StreamFileLoader();

            var serializer = new JsonSerializer
            {
                Converters = { new StringEnumConverter(), new WeightingConverter() }
            };

            var engine = new RuleEngine(new AggregateRuleContainer(new[]
            {
                new JsonRuleContainer(serializer, RulesLocation, fileLoader) 
            }));
            
            var transactions = dataReader.Read(fileLoader.ReadAsString(DataLocation));

            engine.Run(transactions);

            Console.ReadKey();
        }
    }
}
