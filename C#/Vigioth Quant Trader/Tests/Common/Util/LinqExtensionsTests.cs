

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class LinqExtensionsTests
    {
        [Test]
        public void ExceptProducesSameResultsAsEnumerableExcept()
        {
            var enumerable = Enumerable.Range(0, 100);
            var set = new HashSet<int>(Enumerable.Range(40, 20));

            var expected = Enumerable.Except(enumerable, set);
            var actual = LinqExtensions.Except(enumerable, set);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
