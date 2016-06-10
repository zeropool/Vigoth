

using System;
using System.Collections.Generic;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class FuncTextWriterTests
    {
        [Test]
        public void RedirectsWriteAndWriteLine()
        {
            var messages = new List<string>();
            Action<string> redirector = s => messages.Add(s);
            var writer = new FuncTextWriter(redirector);

            writer.Write("message");
            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual("message", messages[0]);

            writer.WriteLine("message2");
            Assert.AreEqual(2, messages.Count);
            Assert.AreEqual("message2", messages[1]);
        }

        [Test]
        public void RedirectsConsoleOutAndError()
        {
            var messages = new List<string>();
            Action<string> redirector = s => messages.Add(s);
            var writer = new FuncTextWriter(redirector);

            Console.SetOut(writer);
            Console.SetError(writer);

            Console.WriteLine("message");
            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual("message", messages[0]);

            Console.Error.WriteLine("message2");
            Assert.AreEqual(2, messages.Count);
            Assert.AreEqual("message2", messages[1]);
        }
    }
}
