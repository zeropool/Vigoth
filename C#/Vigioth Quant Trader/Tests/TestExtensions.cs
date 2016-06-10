

using System.Threading;
using NUnit.Framework;

namespace VigiothCapital.QuantTrader.Tests
{
    /// <summary>
    /// Provides extension methods to make test code easier to read/write
    /// </summary>
    public static class TestExtensions
    {
        /// <summary>
        /// Calls <see cref="WaitHandle.WaitOne(int)"/> on the specified <see cref="WaitHandle"></see> and then
        /// call <see cref="Assert.Fail(string)"/> if <paramref name="wait"/> was not set.
        /// </summary>
        /// <param name="wait">The <see cref="WaitHandle"/></param> instance to wait on
        /// <param name="milliseconds">The timeout, in milliseconds</param>
        /// <param name="message">The message to fail with, null to fail with no message</param>
        public static void WaitOneAssertFail(this WaitHandle wait, int milliseconds, string message = null)
        {
            if (!wait.WaitOne(milliseconds))
            {
                Assert.Fail(message);
            }
        }
    }
}
