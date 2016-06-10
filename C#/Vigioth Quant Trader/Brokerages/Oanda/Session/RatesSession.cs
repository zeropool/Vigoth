

using System.Collections.Generic;
using System.Net;
using VigiothCapital.QuantTrader.Brokerages.Oanda.DataType;
using VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.Session
{
#pragma warning disable 1591
    public class RatesSession : StreamSession<RateStreamResponse>
    {
        private readonly OandaBrokerage _brokerage;
        private readonly List<Instrument> _instruments;

        public RatesSession(OandaBrokerage brokerage, int accountId, List<Instrument> instruments)
            : base(accountId)
        {
            _brokerage = brokerage;
            _instruments = instruments;
        }

        protected override WebResponse GetSession()
        {
            return _brokerage.StartRatesSession(_instruments, _accountId);
        }
    }
#pragma warning restore 1591
}
