

using System;
using System.Threading;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Engine.Results;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Packets;

namespace VigiothCapital.QuantTrader.Engine
{
    /// <summary>
    /// Algorithm status monitor reads the central command directive for this algorithm/backtest. When it detects
    /// the backtest has been deleted or cancelled the backtest is aborted.
    /// </summary>
    public class StateCheck
    {
        /// DB Ping Class
        public class Ping
        {
            // set to true to break while loop in Run()
            private ManualResetEventSlim _exitEvent;

            private readonly AlgorithmNodePacket _job;
            private readonly AlgorithmManager _algorithmManager;
            private readonly IApi _api;
            private readonly IResultHandler _resultHandler;
            private readonly IMessagingHandler _messagingHandler;

            /// <summary>
            /// Creates an instance of the <see cref="Ping"/> class
            /// </summary>
            public Ping(AlgorithmManager algorithmManager, IApi api, IResultHandler resultHandler, IMessagingHandler messagingHandler, AlgorithmNodePacket job)
            {
                _api = api;
                _job = job;
                _resultHandler = resultHandler;
                _messagingHandler = messagingHandler;
                _algorithmManager = algorithmManager;
                _exitEvent = new ManualResetEventSlim(false);
            }

            /// DB Ping Run Method:
            public void Run()
            {
                while (!_exitEvent.Wait(1000))
                {
                    try
                    {
                        if (_algorithmManager.AlgorithmId != "" && _algorithmManager.QuitState == false)
                        {
                            //Get the state from the central server:
                            var state = _api.GetAlgorithmStatus(_algorithmManager.AlgorithmId, _job.UserId);

                            //Set state via get/set method:
                            _algorithmManager.SetStatus(state.Status);

                            //Set which chart the user is look at, so we can reduce excess messaging (e.g. trading 100 symbols, only send 1).
                            _resultHandler.SetChartSubscription(state.ChartSubscription);

                            _messagingHandler.HasSubscribers = state.HasSubscribers;
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        return;
                    }
                    catch (Exception err)
                    {
                        Log.Error(err);
                    }
                }

                Log.Trace("StateCheck.Ping.Run(): Exited thread.");
            }

            /// <summary>
            /// Send an exit signal to the thread
            /// </summary>
            public void Exit()
            {
                _exitEvent.Set();
            }
        }
    }
}
