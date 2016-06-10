

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Consolidators;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Common.Data
{
    [TestFixture]
    public class SequentialConsolidatorTests
    {
        [Test]
        public void SequentialConsolidatorsFiresAllEvents()
        {
            var first = new IdentityDataConsolidator<BaseData>();
            var second = new IdentityDataConsolidator<BaseData>();
            var sequential = new SequentialConsolidator(first, second);

            bool firstFired = false;
            bool secondFired = false;
            bool sequentialFired = false;

            first.DataConsolidated += (sender, consolidated) =>
            {
                firstFired = true;
            };

            second.DataConsolidated += (sender, consolidated) =>
            {
                secondFired = true;
            };

            sequential.DataConsolidated += (sender, consolidated) =>
            {
                sequentialFired = true;
            };

            sequential.Update(new TradeBar());

            Assert.IsTrue(firstFired);
            Assert.IsTrue(secondFired);
            Assert.IsTrue(sequentialFired);
        }

        [Test]
        public void SequentialConsolidatorAcceptsSubTypesForSecondInputType()
        {
            var first = new IdentityDataConsolidator<TradeBar>();
            var second = new IdentityDataConsolidator<BaseData>();
            var sequential = new SequentialConsolidator(first, second);


            bool firstFired = false;
            bool secondFired = false;
            bool sequentialFired = false;

            first.DataConsolidated += (sender, consolidated) =>
            {
                firstFired = true;
            };

            second.DataConsolidated += (sender, consolidated) =>
            {
                secondFired = true;
            };

            sequential.DataConsolidated += (sender, consolidated) =>
            {
                sequentialFired = true;
            };

            sequential.Update(new TradeBar());

            Assert.IsTrue(firstFired);
            Assert.IsTrue(secondFired);
            Assert.IsTrue(sequentialFired);
        }
    }
}
