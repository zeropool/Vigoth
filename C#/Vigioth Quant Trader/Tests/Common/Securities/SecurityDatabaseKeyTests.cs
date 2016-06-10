

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class SecurityDatabaseKeyTests
    {
        [Test]
        public void ConstructorWithNoWildcards()
        {
            var key = new SecurityDatabaseKey(Market.USA, "SPY", SecurityType.Equity);
            Assert.AreEqual(SecurityType.Equity, key.SecurityType);
            Assert.AreEqual(Market.USA, key.Market);
            Assert.AreEqual("SPY", key.Symbol);
        }

        [Test]
        public void ConstructorWithNullSymbolConvertsToWildcard()
        {
            var key = new SecurityDatabaseKey(Market.USA, null, SecurityType.Equity);
            Assert.AreEqual(SecurityType.Equity, key.SecurityType);
            Assert.AreEqual(Market.USA, key.Market);
            Assert.AreEqual("[*]", key.Symbol);
        }

        [Test]
        public void ConstructorWithEmptySymbolConvertsToWildcard()
        {
            var key = new SecurityDatabaseKey(Market.USA, string.Empty, SecurityType.Equity);
            Assert.AreEqual(SecurityType.Equity, key.SecurityType);
            Assert.AreEqual(Market.USA, key.Market);
            Assert.AreEqual("[*]", key.Symbol);
        }

        [Test]
        public void ConstructorWithNullMarketConvertsToWildcard()
        {
            var key = new SecurityDatabaseKey(null, "SPY", SecurityType.Equity);
            Assert.AreEqual(SecurityType.Equity, key.SecurityType);
            Assert.AreEqual("[*]", key.Market);
            Assert.AreEqual("SPY", key.Symbol);
        }

        [Test]
        public void ConstructorWithEmptyMarketConvertsToWildcard()
        {
            var key = new SecurityDatabaseKey(string.Empty, "SPY", SecurityType.Equity);
            Assert.AreEqual(SecurityType.Equity, key.SecurityType);
            Assert.AreEqual("[*]", key.Market);
            Assert.AreEqual("SPY", key.Symbol);
        }

        [Test]
        public void ParsesKeyProperly()
        {
            const string input = "Equity-usa-SPY";
            var key = SecurityDatabaseKey.Parse(input);
            Assert.AreEqual(SecurityType.Equity, key.SecurityType);
            Assert.AreEqual(Market.USA, key.Market);
            Assert.AreEqual("SPY", key.Symbol);
        }

        [Test]
        public void ParsesWildcardSymbol()
        {
            const string input = "Equity-usa-[*]";
            var key = SecurityDatabaseKey.Parse(input);
            Assert.AreEqual(SecurityType.Equity, key.SecurityType);
            Assert.AreEqual(Market.USA, key.Market);
            Assert.AreEqual("[*]", key.Symbol);
        }

        [Test]
        public void ParsesWildcardMarket()
        {
            const string input = "Equity-[*]-SPY";
            var key = SecurityDatabaseKey.Parse(input);
            Assert.AreEqual(SecurityType.Equity, key.SecurityType);
            Assert.AreEqual("[*]", key.Market);
            Assert.AreEqual("SPY", key.Symbol);
        }

        [Test, ExpectedException(typeof(ArgumentException), MatchType = MessageMatch.Contains, ExpectedMessage = "as a SecurityType")]
        public void ThrowsOnWildcardSecurityType()
        {
            const string input = "[*]-usa-SPY";
            SecurityDatabaseKey.Parse(input);
        }

        [Test, ExpectedException(typeof (FormatException), MatchType = MessageMatch.Contains, ExpectedMessage = "expected format")]
        public void ThrowsOnInvalidFormat()
        {
            const string input = "Equity-[*]";
            SecurityDatabaseKey.Parse(input);
        }
    }
}
