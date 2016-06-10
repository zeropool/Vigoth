

using System;
using NodaTime;
using NUnit.Framework;

namespace VigiothCapital.QuantTrader.Tests.Common
{
    [TestFixture]
    public class TimeZonesTest
    {
        [Test]
        public void TimeZonesLoadFromTzdb()
        {
            // verifies each of the fields in the TimeZones class can be retrieved.
            foreach (var field in typeof(TimeZones).GetFields())
            {
                var value = field.GetValue(null);
                Assert.IsNotNull(value);
                Assert.IsInstanceOf(typeof (DateTimeZone), value);
                Console.WriteLine(((DateTimeZone)value).Id);
            }
        }
    }
}
