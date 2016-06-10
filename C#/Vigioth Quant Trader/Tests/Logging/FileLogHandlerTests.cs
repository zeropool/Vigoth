

using System;
using System.IO;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Logging;

namespace VigiothCapital.QuantTrader.Tests.Logging
{
    [TestFixture]
    public class FileLogHandlerTests
    {
        [Test]
        public void WritesMessageToFile()
        {
            const string file = "log.txt";
            File.Delete(file);

            var debugMessage = "*debug message*" + DateTime.UtcNow.ToString("o");
            using (var log = new FileLogHandler(file))
            {
                log.Debug(debugMessage);
            }

            var contents = File.ReadAllText(file);
            Assert.IsNotNull(contents);
            Assert.IsTrue(contents.Contains(debugMessage));

            File.Delete(file);
        }
    }
}
