

using System.IO;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Engine.DataFeeds.Transport;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Transport
{
    [TestFixture]
    public class LocalFileSubscriptionStreamReaderTests
    {
        [Test]
        public void ReadsFromSpecificZipEntry()
        {
            var source = Path.Combine("TestData", "multizip.zip");
            const string entryName = "multizip/three.txt";
            using (var reader = new LocalFileSubscriptionStreamReader(source, entryName))
            {
                var line = reader.ReadLine();
                Assert.AreEqual("3", line);
            }
        }
    }
}
