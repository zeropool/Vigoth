

using System.Drawing;
using Newtonsoft.Json;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class ColorJsonConverterTests
    {
        [Test]
        public void ConvertsKnownColorToJson()
        {
            var container = new ColorContainer { Color = Color.Blue };
            var json = JsonConvert.SerializeObject(container);
            Assert.AreEqual("{\"Color\":\"#0000FF\"}", json);
        }
        [Test]
        public void ConvertsEmptyColorToJson()
        {
            var container = new ColorContainer { Color = Color.Empty };
            var json = JsonConvert.SerializeObject(container);
            Assert.AreEqual("{\"Color\":\"\"}", json);
        }

        [Test]
        public void ConvertJsonToColorTest()
        {
            const string jsonValue = "{ 'Color': '#FFFFFF' }";
            var converted = JsonConvert.DeserializeObject<ColorContainer>(jsonValue).Color;
            Assert.AreEqual(Color.White.ToArgb(), converted.ToArgb());
        }

        struct ColorContainer
        {
            [JsonConverter(typeof(ColorJsonConverter))]
            public Color Color;
        }
    }
}