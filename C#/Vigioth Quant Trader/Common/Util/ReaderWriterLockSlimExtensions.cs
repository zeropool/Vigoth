
using System;
using System.Threading;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Provides extension methods to make working with the <see cref="ReaderWriterLockSlim"/> class easier
    /// </summary>
    public static class ReaderWriterLockSlimExtensions
    {
        /// <summary>
        /// Opens the read lock
        /// </summary>
        /// <param name="readerWriterLockSlim">The lock to open for read</param>
        /// <returns>A disposable reference which will release the lock upon disposal</returns>
        public static IDisposable Read(this ReaderWriterLockSlim readerWriterLockSlim)
        {
            return new ReaderLockToken(readerWriterLockSlim);
        }
        /// <summary>
        /// Opens the write lock
        /// </summary>
        /// <param name="readerWriterLockSlim">The lock to open for write</param>
        /// <returns>A disposale reference which will release thelock upon disposal</returns>
        public static IDisposable Write(this ReaderWriterLockSlim readerWriterLockSlim)
        {
            return new WriteLockToken(readerWriterLockSlim);
        }
        private sealed class ReaderLockToken : ReaderWriterLockSlimToken
        {
            public ReaderLockToken(ReaderWriterLockSlim readerWriterLockSlim)
                : base(readerWriterLockSlim)
            {
            }
            protected override void EnterLock(ReaderWriterLockSlim readerWriterLockSlim)
            {
                readerWriterLockSlim.EnterReadLock();
            }
            protected override void ExitLock(ReaderWriterLockSlim readerWriterLockSlim)
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }
        private sealed class WriteLockToken : ReaderWriterLockSlimToken
        {
            public WriteLockToken(ReaderWriterLockSlim readerWriterLockSlim)
                : base(readerWriterLockSlim)
            {
            }
            protected override void EnterLock(ReaderWriterLockSlim readerWriterLockSlim)
            {
                readerWriterLockSlim.EnterWriteLock();
            }
            protected override void ExitLock(ReaderWriterLockSlim readerWriterLockSlim)
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }
        private abstract class ReaderWriterLockSlimToken : IDisposable
        {
            private ReaderWriterLockSlim _readerWriterLockSlim;
            public ReaderWriterLockSlimToken(ReaderWriterLockSlim readerWriterLockSlim)
            {
                _readerWriterLockSlim = readerWriterLockSlim;
                // ReSharper disable once DoNotCallOverridableMethodsInConstructor -- we control the subclasses, this is fine
                EnterLock(_readerWriterLockSlim);
            }
            protected abstract void EnterLock(ReaderWriterLockSlim readerWriterLockSlim);
            protected abstract void ExitLock(ReaderWriterLockSlim readerWriterLockSlim);
            public void Dispose()
            {
                if (_readerWriterLockSlim != null)
                {
                    ExitLock(_readerWriterLockSlim);
                    _readerWriterLockSlim = null;
                }
            }
        }
    }
}
