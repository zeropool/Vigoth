

using System.Collections.Generic;
using VigiothCapital.QuantTrader.Algorithm;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds
{
    /// <summary>
    /// This type allows tests to easily create an algorith that is mostly initialized in one line
    /// </summary>
    public class AlgorithmStub : QCAlgorithm
    {
        public AlgorithmStub(Resolution resolution = Resolution.Second, List<string> equities = null, List<string> forex = null)
        {
            foreach (var ticker in equities ?? new List<string>())
            {
                AddSecurity(SecurityType.Equity, ticker, resolution);
                var symbol = SymbolCache.GetSymbol(ticker);
                Securities[symbol].Exchange = new SecurityExchange(SecurityExchangeHours.AlwaysOpen(TimeZones.NewYork));
            }
            foreach (var ticker in forex ?? new List<string>())
            {
                AddSecurity(SecurityType.Forex, ticker, resolution);
                var symbol = SymbolCache.GetSymbol(ticker);
                Securities[symbol].Exchange = new SecurityExchange(SecurityExchangeHours.AlwaysOpen(TimeZones.EasternStandard));
            }
        }
    }
}