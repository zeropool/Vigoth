

using NUnit.Framework;

namespace VigiothCapital.QuantTrader.Tests.Common
{
    [TestFixture]
    public class OSTests
    {
        [Test]
        public void GetServerStatisticsDoesntThrow()
        {
            var serverStatistics = OS.GetServerStatistics();
            //var maxKeyLength = serverStatistics.Keys.Max(x => x.Length);
            //foreach (var statistic in serverStatistics)
            //{
            //    Console.WriteLine("{0, -" + maxKeyLength + "} - {1}", statistic.Key, statistic.Value);
            //}
        }
    }
}
