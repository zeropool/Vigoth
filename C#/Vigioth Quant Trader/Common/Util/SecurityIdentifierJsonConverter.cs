
using Newtonsoft.Json;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// A <see cref="JsonConverter"/> implementation that serializes a <see cref="SecurityIdentifier"/> as a string
    /// </summary>
    public class SecurityIdentifierJsonConverter : TypeChangeJsonConverter<SecurityIdentifier, string>
    {
        /// <summary>
        /// Converts as security identifier to a string
        /// </summary>
        /// <param name="value">The input value to be converted before serialziation</param>
        /// <returns>A new instance of TResult that is to be serialzied</returns>
        protected override string Convert(SecurityIdentifier value)
        {
            return value.ToString();
        }
        /// <summary>
        /// Converts the input string to a security identifier
        /// </summary>
        /// <param name="value">The deserialized value that needs to be converted to T</param>
        /// <returns>The converted value</returns>
        protected override SecurityIdentifier Convert(string value)
        {
            return SecurityIdentifier.Parse(value);
        }
    }
}