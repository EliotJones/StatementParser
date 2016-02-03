namespace BankStatementParser.DataReader
{
    using System;
    using Domain.Entities;
    using Newtonsoft.Json;

    public class WeightingConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }

            var weighting = (Weighting)value;

            writer.WriteValue(weighting.Value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return new Weighting(0);
            }

            var value = reader.Value.ToString();
            int v;
            if (int.TryParse(value, out v))
            {
                return new Weighting(v);
            }

            throw new ArgumentException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Weighting);
        }
    }
}
