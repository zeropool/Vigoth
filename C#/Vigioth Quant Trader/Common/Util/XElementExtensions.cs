
using System;
using System.Linq;
using System.Xml.Linq;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Provides extension methods for the XML to LINQ types
    /// </summary>
    public static class XElementExtensions
    {
        /// <summary>
        /// Gets the value from the element and converts it to the specified type.
        /// </summary>
        /// <typeparam name="T">The output type</typeparam>
        /// <param name="element">The element to access</param>
        /// <param name="name">The attribute name to access on the element</param>
        /// <returns>The converted value</returns>
        public static T Get<T>(this XElement element, string name) 
            where T : IConvertible
        {
            var xAttribute = element.Descendants(name).Single();
            string value = xAttribute.Value;
            return value.ConvertTo<T>();
        }
    }
}
