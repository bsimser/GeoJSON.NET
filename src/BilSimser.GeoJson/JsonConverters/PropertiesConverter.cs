using System;
using BilSimser.GeoJson.GeoJson;
using Newtonsoft.Json;

namespace BilSimser.GeoJson.JsonConverters
{
    public class PropertiesConverter : JsonConverter
    {
        private readonly Type _type;

        public PropertiesConverter(Type type)
        {
            _type = type;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var properties = value as Properties;
            if (properties == null) return;
            if (properties.values == null) return;
            var list = properties.values;
            writer.WriteStartObject();
            foreach (var item in list)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteValue(item.Value);
            }
            writer.WriteEndObject();
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