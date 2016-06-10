

using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class CashBookTests
    {
        [Test]
        public void InitializesWithAccountCurrencyAdded()
        {
            var book = new CashBook();
            Assert.AreEqual(1, book.Count);
            var cash = book.Single().Value;
            Assert.AreEqual(CashBook.AccountCurrency, cash.Symbol);
            Assert.AreEqual(0, cash.Amount);
            Assert.AreEqual(1m, cash.ConversionRate);
        }

        [Test]
        public void ComputesValueInAccountCurrency()
        {
            var book = new CashBook();
            book["USD"].SetAmount(1000);
            book.Add("JPY", 1000, 1/100m);
            book.Add("GBP", 1000, 2m);

            decimal expected = book["USD"].ValueInAccountCurrency + book["JPY"].ValueInAccountCurrency + book["GBP"].ValueInAccountCurrency;
            Assert.AreEqual(expected, book.TotalValueInAccountCurrency);
        }

        [Test]
        public void ConvertsProperly()
        {
            var book = new CashBook();
            book.Add("EUR", 0, 1.10m);
            book.Add("GBP", 0, 0.71m);

            var expected = 781m;
            var actual = book.Convert(1000, "EUR", "GBP");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConvertsToAccountCurrencyProperly()
        {
            var book = new CashBook();
            book.Add("EUR", 0, 1.10m);

            var expected = 1100m;
            var actual = book.ConvertToAccountCurrency(1000, "EUR");
            Assert.AreEqual(expected, actual);
        }
    }
}
