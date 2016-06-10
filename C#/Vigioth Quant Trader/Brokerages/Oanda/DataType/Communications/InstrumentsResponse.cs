
using System.Collections.Generic;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications
{
#pragma warning disable 1591
    /// <summary>
    /// Represent web response for the list of active/tradable instruments provided by Oanda.
    /// </summary>
    public class InstrumentsResponse
    {
        public List<Instrument> instruments;
    }
#pragma warning restore 1591
}
