

using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zip;
using NUnit.Framework;

namespace VigiothCapital.QuantTrader.Tests.Compression
{
    [TestFixture]
    public class CompressionTests
    {
        [Test]
        public void ReadLinesCountMatchesLineCount()
        {
            const string file = "../../../Data/equity/usa/minute/spy/20131008_trade.zip";

            const int expected = 827;
            int actual = VigiothCapital.QuantTrader.Compression.ReadLines(file).Count();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ZipBytes()
        {
            const string fileContents = "this is the contents of a file!";
            var fileBytes = Encoding.ASCII.GetBytes(fileContents); // using asci because UnzipData uses 1byte=1char
            var zippedBytes = VigiothCapital.QuantTrader.Compression.ZipBytes(fileBytes, "entry");
            File.WriteAllBytes("entry.zip", zippedBytes);
            var unzipped = VigiothCapital.QuantTrader.Compression.Unzip("entry.zip").ToList();
            Assert.AreEqual(1, unzipped.Count);
            Assert.AreEqual("entry", unzipped[0].Key);
            Assert.AreEqual(fileContents, unzipped[0].Value.Single());
        }

        [Test]
        public void ExtractsZipEntryByName()
        {
            var zip = Path.Combine("TestData", "multizip.zip");
            ZipFile zipFile;
            using (var entryStream = VigiothCapital.QuantTrader.Compression.Unzip(zip, "multizip/two.txt", out zipFile))
            using (zipFile)
            {
                var text = entryStream.ReadToEnd();
                Assert.AreEqual("2", text);
            }
        }
    }
}
