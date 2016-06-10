

using NUnit.Framework;
using VigiothCapital.QuantTrader.Algorithm;
using VigiothCapital.QuantTrader.Brokerages.InteractiveBrokers;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Brokerages.InteractiveBrokers
{
    [TestFixture]
    [Ignore("These tests require the IBController and IB TraderWorkstation to be installed.")]
    public class InteractiveBrokersBrokerageFactoryTests
    {
        public static readonly IAlgorithm AlgorithmDependency = new InteractiveBrokersBrokerageFactoryAlgorithmDependency();

        [Test]
        public void InitializesInstanceFromComposer()
        {
            var composer = Composer.Instance;
            using (var factory = composer.Single<IBrokerageFactory>(instance => instance.BrokerageType == typeof (InteractiveBrokersBrokerage)))
            {
                Assert.IsNotNull(factory);

                var job = new LiveNodePacket {BrokerageData = factory.BrokerageData};
                var brokerage = factory.CreateBrokerage(job, AlgorithmDependency);
                Assert.IsNotNull(brokerage);
                Assert.IsInstanceOf<InteractiveBrokersBrokerage>(brokerage);

                brokerage.Connect();
                Assert.IsTrue(brokerage.IsConnected);
            }
        }

        class InteractiveBrokersBrokerageFactoryAlgorithmDependency : QCAlgorithm
        {
        }
    }
}
