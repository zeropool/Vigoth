

using System;
using System.Collections.Generic;
using NodaTime;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Custom;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// Daily Fx demonstration to call on and use the FXCM Calendar API
    /// </summary>
    public class DailyFxAlgorithm : QCAlgorithm
    {
        /// <summary>
        /// Add the Daily FX type to our algorithm and use its events.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2016, 05, 26);  //Set Start Date
            SetEndDate(2016, 05, 27);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            AddData<DailyFx>("DFX", Resolution.Second, DateTimeZone.Utc);
        }

        private int _sliceCount = 0;
        public override void OnData(Slice slice)
        {
            var result = slice.Get<DailyFx>();
            Console.WriteLine("SLICE >> {0} : {1}", _sliceCount++, result);
        }

        /// <summary>
        /// Trigger an event on a complete calendar event which has an actual value.
        /// </summary>
        private int _eventCount = 0;
        private Dictionary<string, DailyFx> _uniqueConfirmation = new Dictionary<string, DailyFx>();
        public void OnData(DailyFx calendar)
        {
            _uniqueConfirmation.Add(calendar.ToString(), calendar);
            Console.WriteLine("ONDATA >> {0}: {1}", _eventCount++, calendar);
        }
    }
}