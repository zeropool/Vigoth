

using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class BusyBlockingCollectionTests
    {
        [Test]
        public void IsNotBusyWithZeroItemsWaiting()
        {
            var collection = new BusyBlockingCollection<int>();
            Assert.IsTrue(collection.WaitHandle.WaitOne(0));
        }

        [Test]
        public void IsBusyWithItemsWaiting()
        {
            var collection = new BusyBlockingCollection<int>();
            collection.Add(1);
            Assert.IsFalse(collection.WaitHandle.WaitOne(0));
        }

        [Test]
        public void GetConsumingEnumerableReturnsItemsInOrder()
        {
            var collection = new BusyBlockingCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.CompleteAdding();
            CollectionAssert.AreEquivalent(new[]{1,2,3}, collection.GetConsumingEnumerable());
        }

        [Test]
        public void WaitForProcessingCompletedDuringGetConsumingEnumerable()
        {
            var collection = new BusyBlockingCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.CompleteAdding();
            Assert.IsFalse(collection.WaitHandle.WaitOne(0));
            foreach (var item in collection.GetConsumingEnumerable())
            {
                Assert.IsFalse(collection.WaitHandle.WaitOne(0));
            }
            Assert.IsTrue(collection.WaitHandle.WaitOne(0));
        }
    }
}
