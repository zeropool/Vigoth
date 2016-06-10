
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader
{
    /// <summary>
    /// Defines a <see cref="JsonConverter"/> to be used when deserializing to 
    /// the <see cref="Symbol"/> class.
    /// </summary>
    public class SymbolJsonConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var symbol = value as Symbol;
            if (symbol == null) return;
            writer.WriteStartObject();
            writer.WritePropertyName("$type");
            writer.WriteValue("VigiothCapital.QuantTrader.Symbol, VigiothCapital.QuantTrader.Common");
            writer.WritePropertyName("Value");
            writer.WriteValue(symbol.Value);
            writer.WritePropertyName("ID");
            writer.WriteValue(symbol.ID.ToString());
            writer.WritePropertyName("Permtick");
            writer.WriteValue(symbol.Value);
            writer.WriteEndObject();
        }
        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jobject = JObject.Load(reader);
            return new Symbol(SecurityIdentifier.Parse(jobject["ID"].ToString()), jobject["Value"].ToString());
        }
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Symbol);
        }
    }
}