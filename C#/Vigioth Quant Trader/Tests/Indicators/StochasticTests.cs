

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class StochasticTests
    {
        [Test]
        public void ComparesAgainstExternalDataOnStochasticsK()
        {
            var stochastics = new Stochastic("sto", 12, 3, 5);

            const double epsilon = 1e-3;

            TestHelper.TestIndicator(stochastics, "spy_with_stoch12k3.txt", "Stochastics 12 %K 3",
                (ind, expected) => Assert.AreEqual(expected, (double) ((Stochastic) ind).StochK.Current.Value, epsilon)
                );
        }

        [Test]
        public void PrimaryOutputIsFastStochProperty()
        {
            var stochastics = new Stochastic("sto", 12, 3, 5);

            TestHelper.TestIndicator(stochastics, "spy_with_stoch12k3.txt", "Stochastics 12 %K 3",
                (ind, expected) => Assert.AreEqual((double) ((Stochastic) ind).FastStoch.Current.Value, ind.Current.Value)
                );
        }

        [Test]
        public void ComparesAgainstExternalDataOnStochasticsD()
        {
            var stochastics = new Stochastic("sto", 12, 3, 5);

            const double epsilon = 1e-3;
            TestHelper.TestIndicator(stochastics, "spy_with_stoch12k3.txt", "%D 5",
                (ind, expected) => Assert.AreEqual(expected, (double) ((Stochastic) ind).StochD.Current.Value, epsilon)
                );
        }

        [Test]
        public void ResetsProperly()
        {
            var stochastics = new Stochastic("sto", 12, 3, 5);

            foreach (var bar in TestHelper.GetTradeBarStream("spy_with_stoch12k3.txt", false))
            {
                stochastics.Update(bar);
            }
            Assert.IsTrue(stochastics.IsReady);
            Assert.IsTrue(stochastics.FastStoch.IsReady);
            Assert.IsTrue(stochastics.StochK.IsReady);
            Assert.IsTrue(stochastics.StochD.IsReady);

            stochastics.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(stochastics);
            TestHelper.AssertIndicatorIsInDefaultState(stochastics.FastStoch);
            TestHelper.AssertIndicatorIsInDefaultState(stochastics.StochK);
            TestHelper.AssertIndicatorIsInDefaultState(stochastics.StochD);
        }

        [Test]
        public void HandlesEqualMinAndMax()
        {
            var reference = new DateTime(2015, 09, 01);
            var stochastics = new Stochastic("sto", 2, 2, 2);
            for (int i = 0; i < 4; i++)
            {
                var bar = new TradeBar{Time = reference.AddSeconds(i)};
                bar.Open = bar.Close = bar.High = bar.Low = bar.Volume = 1;
                stochastics.Update(bar);
                Assert.AreEqual(0m, stochastics.Current.Value);
            }
        }
    }
}
