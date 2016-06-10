

using System;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// QCU Scheduled Events Algorithm
    /// </summary>
    public class ScheduledEventsAlgorithm : QCAlgorithm
    {
        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 10, 07);  //Set Start Date
            SetEndDate(2013, 10, 11);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            // Find more symbols here: http://quantconnect.com/data
            AddSecurity(SecurityType.Equity, "SPY", Resolution.Minute);

            // events are scheduled using date and time rules
            // date rules specify on what dates and event will fire
            // time rules specify at what time on thos dates the event will fire

            // schedule an event to fire at a specific date/time
            Schedule.On(DateRules.On(2013, 10, 7), TimeRules.At(13, 0), () =>
            {
                Log("SpecificTime: Fired at : " + Time);
            });

            // schedule an event to fire every trading day for a security
            // the time rule here tells it to fire 10 minutes after SPY's market open
            Schedule.On(DateRules.EveryDay("SPY"), TimeRules.AfterMarketOpen("SPY", 10), () =>
            {
                Log("EveryDay.SPY 10 min after open: Fired at: " + Time);
            });

            // schedule an event to fire every trading day for a security
            // the time rule here tells it to fire 10 minutes before SPY's market close
            Schedule.On(DateRules.EveryDay("SPY"), TimeRules.BeforeMarketClose("SPY", 10), () =>
            {
                Log("EveryDay.SPY 10 min before close: Fired at: " + Time);
            });

            // schedule an event to fire on certain days of the week
            Schedule.On(DateRules.Every(DayOfWeek.Monday, DayOfWeek.Friday), TimeRules.At(12, 0), () =>
            {
                Log("Mon/Fri at 12pm: Fired at: " + Time);
            });


            // the scheduling methods return the ScheduledEvent object which can be used for other things
            // here I set the event up to check the portfolio value every 10 minutes, and liquidate if we have too many losses
            Schedule.On(DateRules.EveryDay(), TimeRules.Every(TimeSpan.FromMinutes(10)), () =>
            {
                // if we have over 1000 dollars in unrealized losses, liquidate
                if (Portfolio.TotalUnrealizedProfit < -1000)
                {
                    Log("Liquidated due to unrealized losses at: " + Time);
                    Liquidate();
                }
            });

            // schedule an event to fire at the beginning of the month, the symbol is optional if
            // specified, it will fire the first trading day for that symbol of the month, if not specified
            // it will fire on the first day of the month
            Schedule.On(DateRules.MonthStart("SPY"), TimeRules.AfterMarketOpen("SPY"), () =>
            {
                // good spot for rebalancing code?
            });
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
            if (!Portfolio.Invested)
            {
                SetHoldings("SPY", 1);
            }
        }
    }
}