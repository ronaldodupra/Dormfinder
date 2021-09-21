using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using HashidsNet;

namespace DormFinder.Web.Core.Hashids
{
    public class HashidsJsonConverter : JsonConverter<HashidInt>
    {
        private readonly IHashids _hashids;

        public HashidsJsonConverter()
        {
            _hashids = new HashidsNet.Hashids("secret");
        }

        public override HashidInt Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string stringValue = reader.GetString();
                return _hashids.Decode(stringValue)[0];
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt32();
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, HashidInt value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_hashids.Encode(value));
        }
    }
}
