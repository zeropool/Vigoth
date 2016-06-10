

using NUnit.Framework;
using VigiothCapital.QuantTrader.Logging;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class WhoCalledMeTests
    {
        [Test]
        public void GetMethodNameTest()
        {
            string expected = "WhoCalledMeTests.GetMethodNameTest";
            string actual = WhoCalledMe.GetMethodName(0);
            Assert.AreEqual(expected, actual);
        }
    }
}
