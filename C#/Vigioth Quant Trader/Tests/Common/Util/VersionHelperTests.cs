

using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class VersionHelperTests
    {
        [Test]
        public void CompareVersionsCorrectly()
        {
            // since VersionHelper depends on Globals.Version, we'll rewrite it temporarily and then set it back
            string constantsDotVersion = Globals.Version;
            var field = typeof (Globals).GetProperty("Version");
            const string version = "1.2.3.4";
            field.SetValue(null, version);

            Assert.AreEqual(0, VersionHelper.CompareVersions(version, version));

            string oldVersion = "1.2.3.3";
            Assert.AreEqual(-1, VersionHelper.CompareVersions(oldVersion, version));
            Assert.IsTrue(VersionHelper.IsOlderVersion(oldVersion));

            oldVersion = "1.1.9.9";
            Assert.AreEqual(-1, VersionHelper.CompareVersions(oldVersion, version));
            Assert.IsTrue(VersionHelper.IsOlderVersion(oldVersion));

            oldVersion = "0.9.9.9";
            Assert.AreEqual(-1, VersionHelper.CompareVersions(oldVersion, version));
            Assert.IsTrue(VersionHelper.IsOlderVersion(oldVersion));

            string newVersion = "1.2.3.5";
            Assert.AreEqual(1, VersionHelper.CompareVersions(newVersion, version));
            Assert.IsTrue(VersionHelper.IsNewerVersion(newVersion));

            newVersion = "1.2.4.0";
            Assert.AreEqual(1, VersionHelper.CompareVersions(newVersion, version));
            Assert.IsTrue(VersionHelper.IsNewerVersion(newVersion));

            newVersion = "1.3.0.0";
            Assert.AreEqual(1, VersionHelper.CompareVersions(newVersion, version));
            Assert.IsTrue(VersionHelper.IsNewerVersion(newVersion));

            newVersion = "2.0.0.0";
            Assert.AreEqual(1, VersionHelper.CompareVersions(newVersion, version));
            Assert.IsTrue(VersionHelper.IsNewerVersion(newVersion));

            field.SetValue(null, constantsDotVersion);
        }
    }
}
