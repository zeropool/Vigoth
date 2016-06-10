

using System.Collections.Generic;
using System.Net;
using VigiothCapital.QuantTrader.Brokerages.Oanda.DataType;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.Session
{
#pragma warning disable 1591
    /// <summary>
    /// Initialise an events sessions for Oanda Brokerage.
    /// </summary>
    public class EventsSession : StreamSession<Event>
    {
        private readonly OandaBrokerage _brokerage;

        public EventsSession(OandaBrokerage brokerage, int accountId)
            : base(accountId)
        {
            _brokerage = brokerage;
        }

        protected override WebResponse GetSession()
        {
            return _brokerage.StartEventsSession(new List<int> {_accountId});
        }
    }
#pragma warning restore 1591
}