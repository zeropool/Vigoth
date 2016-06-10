

using System;
using System.IO;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Notifications;
using VigiothCapital.QuantTrader.Packets;

namespace VigiothCapital.QuantTrader.Messaging
{
    /// <summary>
    /// Local/desktop implementation of messaging system for Lean Engine.
    /// </summary>
    public class Messaging : IMessagingHandler
    {
        // used to aid in generating regression tests via Cosole.WriteLine(...)
        private static readonly TextWriter Console = System.Console.Out;

        private AlgorithmNodePacket _job;

        /// <summary>
        /// This implementation ignores the <seealso cref="HasSubscribers"/> flag and
        /// instead will always write to the log.
        /// </summary>
        public bool HasSubscribers
        {
            get; 
            set;
        }

        /// <summary>
        /// Initialize the messaging system
        /// </summary>
        public void Initialize()
        {
            //
        }

        /// <summary>
        /// Set the messaging channel
        /// </summary>
        public void SetAuthentication(AlgorithmNodePacket job)
        {
            _job = job;
        }

        /// <summary>
        /// Send a generic base packet without processing
        /// </summary>
        public void Send(Packet packet)
        {
            switch (packet.Type)
            {
                case PacketType.Debug:
                    var debug = (DebugPacket) packet;
                    Log.Trace("Debug: " + debug.Message);
                    break;

                case PacketType.Log:
                    var log = (LogPacket) packet;
                    Log.Trace("Log: " + log.Message);
                    break;

                case PacketType.RuntimeError:
                    var runtime = (RuntimeErrorPacket) packet;
                    var rstack = (!string.IsNullOrEmpty(runtime.StackTrace) ? (Environment.NewLine + " " + runtime.StackTrace) : string.Empty);
                    Log.Error(runtime.Message + rstack);
                    break;

                case PacketType.HandledError:
                    var handled = (HandledErrorPacket) packet;
                    var hstack = (!string.IsNullOrEmpty(handled.StackTrace) ? (Environment.NewLine + " " + handled.StackTrace) : string.Empty);
                    Log.Error(handled.Message + hstack);
                    break;

                case PacketType.BacktestResult:
                    var result = (BacktestResultPacket) packet;

                    if (result.Progress == 1)
                    {
                        // uncomment these code traces to help write regression tests
                        //Console.WriteLine("new Dictionary<string, string>");
                        //Console.WriteLine("\t\t\t{");
                        foreach (var pair in result.Results.Statistics)
                        {
                            Log.Trace("STATISTICS:: " + pair.Key + " " + pair.Value);
                            //Console.WriteLine("\t\t\t\t{{\"{0}\",\"{1}\"}},", pair.Key, pair.Value);
                        }
                        //Console.WriteLine("\t\t\t};");

                        //foreach (var pair in statisticsResults.RollingPerformances)
                        //{
                        //    Log.Trace("ROLLINGSTATS:: " + pair.Key + " SharpeRatio: " + Math.Round(pair.Value.PortfolioStatistics.SharpeRatio, 3));
                        //}
                    }
                    break;
            }


            if (StreamingApi.IsEnabled)
            {
                StreamingApi.Transmit(_job.UserId, _job.Channel, packet);
            }
        }

        /// <summary>
        /// Send any notification with a base type of Notification.
        /// </summary>
        public void SendNotification(Notification notification)
        {
            var type = notification.GetType();
            if (type == typeof (NotificationEmail)
             || type == typeof (NotificationWeb)
             || type == typeof (NotificationSms))
            {
                Log.Error("Messaging.SendNotification(): Send not implemented for notification of type: " + type.Name);
                return;
            }
            notification.Send();
        }
    }
}
