using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Windows.Forms;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Engine;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Launcher
{
    public class Program
    {
        private const string _collapseMessage = "Unhandled exception breaking past controls and causing collapse of algorithm node. This is likely a memory leak of an external dependency or the underlying OS terminating the LEAN engine.";

        static void Main(string[] args)
        {
            var mode = "RELEASE";
            #if DEBUG
                mode = "DEBUG";
            #endif

            var environment = Config.Get("environment");
            var liveMode = Config.GetBool("live-mode");
            Log.DebuggingEnabled = Config.GetBool("debug-mode");
            Log.LogHandler = Composer.Instance.GetExportedValueByTypeName<ILogHandler>(Config.Get("log-handler", "CompositeLogHandler"));
   
            Thread.CurrentThread.Name = "Algorithm Analysis Thread";
            Log.Trace("Engine.Main(): LEAN ALGORITHMIC TRADING ENGINE v" + Globals.Version + " Mode: " + mode);
            Log.Trace("Engine.Main(): Started " + DateTime.Now.ToShortTimeString());
            Log.Trace("Engine.Main(): Memory " + OS.ApplicationMemoryUsed + "Mb-App  " + +OS.TotalPhysicalMemoryUsed + "Mb-Used  " + OS.TotalPhysicalMemory + "Mb-Total");

            LeanEngineSystemHandlers leanEngineSystemHandlers;
            try
            {
                leanEngineSystemHandlers = LeanEngineSystemHandlers.FromConfiguration(Composer.Instance);
            }
            catch (CompositionException compositionException)
            {
                Log.Error("Engine.Main(): Failed to load library: " + compositionException);
                throw;
            }

            leanEngineSystemHandlers.Initialize();

            string assemblyPath;
            var job = leanEngineSystemHandlers.JobQueue.NextJob(out assemblyPath);

            if (job == null)
            {
                throw new Exception("Engine.Main(): Job was null.");
            }
            
            LeanEngineAlgorithmHandlers leanEngineAlgorithmHandlers;
            try
            {
                leanEngineAlgorithmHandlers = LeanEngineAlgorithmHandlers.FromConfiguration(Composer.Instance);
            }
            catch (CompositionException compositionException)
            {
                Log.Error("Engine.Main(): Failed to load library: " + compositionException);
                throw;
            }

            if (environment == "backtesting-desktop")
            {
                Application.EnableVisualStyles();
                var messagingHandler = leanEngineSystemHandlers.Notify;
                var thread = new Thread(() => LaunchUX(messagingHandler, job));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }

            Log.Trace("JOB HANDLERS: ");
            Log.Trace("         DataFeed:     " + leanEngineAlgorithmHandlers.DataFeed.GetType().FullName);
            Log.Trace("         Setup:        " + leanEngineAlgorithmHandlers.Setup.GetType().FullName);
            Log.Trace("         RealTime:     " + leanEngineAlgorithmHandlers.RealTime.GetType().FullName);
            Log.Trace("         Results:      " + leanEngineAlgorithmHandlers.Results.GetType().FullName);
            Log.Trace("         Transactions: " + leanEngineAlgorithmHandlers.Transactions.GetType().FullName);
            Log.Trace("         History:      " + leanEngineAlgorithmHandlers.HistoryProvider.GetType().FullName);
            Log.Trace("         Commands:     " + leanEngineAlgorithmHandlers.CommandQueue.GetType().FullName);
            if (job is LiveNodePacket) Log.Trace("         Brokerage:    " + ((LiveNodePacket)job).Brokerage);

            if (VersionHelper.IsNotEqualVersion(job.Version) || job.Redelivered)
            {
                Log.Error("Engine.Run(): Job Version: " + job.Version + "  Deployed Version: " + Globals.Version + " Redelivered: " + job.Redelivered);
                leanEngineSystemHandlers.Api.SetAlgorithmStatus(job.AlgorithmId, AlgorithmStatus.RuntimeError, _collapseMessage);
                leanEngineSystemHandlers.Notify.SetAuthentication(job);
                leanEngineSystemHandlers.Notify.Send(new RuntimeErrorPacket(job.AlgorithmId, _collapseMessage));
                leanEngineSystemHandlers.JobQueue.AcknowledgeJob(job);
                return;
            }

            try
            {
                var engine = new Engine.Engine(leanEngineSystemHandlers, leanEngineAlgorithmHandlers, liveMode);
                engine.Run(job, assemblyPath);
            }
            finally
            {
                leanEngineSystemHandlers.JobQueue.AcknowledgeJob(job);
                Log.Trace("Engine.Main(): Packet removed from queue: " + job.AlgorithmId);

                leanEngineSystemHandlers.Dispose();
                leanEngineAlgorithmHandlers.Dispose();
                Log.LogHandler.Dispose();
            }
        }

        static void LaunchUX(IMessagingHandler messaging, AlgorithmNodePacket job)
        {
            var form = new Views.WinForms.LeanWinForm(messaging, job);
            Application.Run(form);
        }
    }
}
