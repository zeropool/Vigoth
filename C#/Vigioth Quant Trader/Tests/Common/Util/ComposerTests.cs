

using System.ComponentModel.Composition;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class ComposerTests
    {
        [Test]
        public void ComposesTypes()
        {
            var instances = Composer.Instance.GetExportedValues<IExport>().ToList();
            Assert.AreEqual(4, instances.Count);
            Assert.AreEqual(1, instances.Count(x => x.GetType() == typeof (Export1)));
            Assert.AreEqual(1, instances.Count(x => x.GetType() == typeof (Export2)));
            Assert.AreEqual(1, instances.Count(x => x.GetType() == typeof (Export3)));
            Assert.AreEqual(1, instances.Count(x => x.GetType() == typeof (Export4)));
        }

        [Test]
        public void GetsInstanceUsingPredicate()
        {
            var instance = Composer.Instance.Single<IExport>(x => x.Id == 3);
            Assert.IsNotNull(instance);
            Assert.IsInstanceOf(typeof (Export3), instance);
        }

        [Test]
        public void ResetsAndCreatesNewInstances()
        {
            var composer = Composer.Instance;
            var export1 = composer.Single<IExport>(x => x.Id == 3);
            Assert.IsNotNull(export1);
            composer.Reset();
            var export2 = composer.Single<IExport>(x => x.Id == 3);
            Assert.AreNotEqual(export1, export2);
        }

        [InheritedExport(typeof(IExport))]
        interface IExport
        {
            int Id { get; }
        }

        class Export1 : IExport
        {
            public int Id { get { return 1; } }
        }
        class Export2 : IExport
        {
            public int Id { get { return 2; } }
        }
        class Export3 : IExport
        {
            public int Id { get { return 3; } }
        }
        class Export4 : IExport
        {
            public int Id { get { return 4; } }
        }
    }
}
