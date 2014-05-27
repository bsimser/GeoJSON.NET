using System;
using BilSimser.GeoJson.GeoJson;
using Newtonsoft.Json;

namespace BilSimser.GeoJson.JsonConverters
{
    public class LineStringConverter : JsonConverter
    {
        private readonly Type _type;

        public LineStringConverter(Type type)
        {
            _type = type;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var lineString = value as LineString;
            writer.WriteStartArray();
            foreach (var position in lineString.coordinates)
            {
                writer.WriteStartArray();
                writer.WriteValue(position.x);
                writer.WriteValue(position.y);
                writer.WriteValue(position.z);
                writer.WriteEndArray();
            }
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