

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class MemoizingEnumerableTests
    {
        [Test]
        public void EnumeratesList()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            var memoized = new MemoizingEnumerable<int>(list);
            CollectionAssert.AreEqual(list, memoized);
        }

        [Test]
        public void EnumeratesOnce()
        {
            int i = 0;
            var enumerable = Enumerable.Range(0, 10).Select(x => i++);
            var memoized = new MemoizingEnumerable<int>(enumerable);
            // enumerating memoized twice shouldn't matter
            CollectionAssert.AreEqual(memoized.ToList(), memoized.ToList());
        }
    }
}
