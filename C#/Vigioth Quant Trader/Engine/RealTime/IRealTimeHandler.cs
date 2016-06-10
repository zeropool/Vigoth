

using System;
using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Engine.Results;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Scheduling;

namespace VigiothCapital.QuantTrader.Engine.RealTime
{
    /// <summary>
    /// Real time event handler, trigger functions at regular or pretimed intervals
    /// </summary>
    [InheritedExport(typeof(IRealTimeHandler))]
    public interface IRealTimeHandler : IEventSchedule
    {
        /// <summary>
        /// Thread status flag.
        /// </summary>
        bool IsActive
        {
            get;
        }

        /// <summary>
        /// Intializes the real time handler for the specified algorithm and job
        /// </summary>
        void Setup(IAlgorithm algorithm, AlgorithmNodePacket job, IResultHandler resultHandler, IApi api);

        /// <summary>
        /// Main entry point to scan and trigger the realtime events.
        /// </summary>
        void Run();
        
        /// <summary>
        /// Set the current time for the event scanner (so we can use same code for backtesting and live events)
        /// </summary>
        /// <param name="time">Current real or backtest time.</param>
        void SetTime(DateTime time);

        /// <summary>
        /// Trigger and exit signal to terminate real time event scanner.
        /// </summary>
        void Exit();
    }
}
