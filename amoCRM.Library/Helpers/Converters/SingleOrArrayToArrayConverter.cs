using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using amoCRM.Library.Core.Objects;
using Newtonsoft.Json;

namespace amoCRM.Library.Helpers.Converters
{
    public class SingleOrArrayToArrayConverter<T, TKey> : JsonConverter
        where T : IEntity<TKey>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var retVal = new object();
            if (reader.TokenType == JsonToken.StartObject)
            {
                T instance = (T)serializer.Deserialize(reader, typeof(T));

                if (IsParseableAs(instance.Id, out int value)) retVal = value == 0 ? null : new List<T>() { instance };
                else retVal = string.IsNullOrWhiteSpace(Convert.ToString(instance.Id)) ? null : new List<T>() { instance };
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                retVal = serializer.Deserialize(reader, objectType);
            }
            return retVal;
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public static bool IsParseableAs<TInput>(object obj, out TInput value)
        {
            var str = Convert.ToString(obj);
            var type = typeof(TInput);
            value = (TInput)Activator.CreateInstance(type);

            var tryParseMethod = type.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, Type.DefaultBinder,
                new[] { typeof(string), type.MakeByRefType() }, null);
            if (tryParseMethod == null) return false;

            var arguments = new[] { str, (object)value };
            return (bool)tryParseMethod.Invoke(null, arguments);
        }
    }
}
