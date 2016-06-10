
using System.Collections.Generic;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications
{
#pragma warning disable 1591
    /// <summary>
    /// Represents the current active positions from Oanda.
    /// </summary>
    public class PositionsResponse
    {
        public List<Position> positions;
    }
#pragma warning restore 1591
}
