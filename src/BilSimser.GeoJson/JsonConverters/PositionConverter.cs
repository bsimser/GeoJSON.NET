using System;
using BilSimser.GeoJson.GeoJson;
using Newtonsoft.Json;

namespace BilSimser.GeoJson.JsonConverters
{
    public class PositionConverter : JsonConverter
    {
        private readonly Type _type;

        public PositionConverter(Type type)
        {
            _type = type;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var p = value as Position;
            writer.WriteStartArray();
            writer.WriteValue(p.x);
            writer.WriteValue(p.y);
            writer.WriteValue(p.z);
            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == _type;
        }
    }
}