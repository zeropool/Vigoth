

using System.Threading;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class ReaderWriterLockSlimExtensionsTests
    {
        [Test]
        public void EntersReadLock()
        {
            var slim = new ReaderWriterLockSlim();

            var token = slim.Read();

            Assert.IsTrue(slim.IsReadLockHeld);
            slim.ExitReadLock();

            slim.Dispose();
        }
        [Test]
        public void ExitsReadLock()
        {
            var slim = new ReaderWriterLockSlim();

            var token = slim.Read();
            token.Dispose();
            Assert.IsFalse(slim.IsReadLockHeld);

            slim.Dispose();
        }

        [Test]
        public void EntersWriteLock()
        {
            var slim = new ReaderWriterLockSlim();

            var token = slim.Write();
            Assert.IsTrue(slim.IsWriteLockHeld);
            slim.ExitWriteLock();

            slim.Dispose();
        }
        [Test]
        public void ExitsWriteLock()
        {
            var slim = new ReaderWriterLockSlim();

            var token = slim.Read();
            token.Dispose();
            Assert.IsFalse(slim.IsReadLockHeld);

            slim.Dispose();
        }
    }
}
