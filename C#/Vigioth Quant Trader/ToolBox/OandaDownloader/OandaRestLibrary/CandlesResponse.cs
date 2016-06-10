

using System.Collections.Generic;

namespace VigiothCapital.QuantTrader.ToolBox.OandaDownloader.OandaRestLibrary
{
    public class CandlesResponse
    {
	    public string instrument;
	    public string granularity;
        public List<Candle> candles;
    }
}
