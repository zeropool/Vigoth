

using NUnit.Framework;
using VigiothCapital.QuantTrader.Securities.Forex;

namespace VigiothCapital.QuantTrader.Tests.Common
{
    [TestFixture]
    public class CurrenciesTests
    {
        [Test]
        public void HasCurrencySymbolForEachPair()
        {
            foreach (var currencyPair in Currencies.CurrencyPairs)
            {
                string quotec, basec;
                Forex.DecomposeCurrencyPair(currencyPair, out basec, out quotec);
                Assert.IsTrue(Currencies.CurrencySymbols.ContainsKey(basec), "Missing currency symbol for: " + basec);
                Assert.IsTrue(Currencies.CurrencySymbols.ContainsKey(quotec), "Missing currency symbol for: " + quotec);
            }
        }
    }
}
