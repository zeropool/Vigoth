

using System;

namespace VigiothCapital.QuantTrader.Logging
{
    /// <summary>
    /// Log entry wrapper to make logging simpler:
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Time of the log entry
        /// </summary>
        public DateTime Time;

        /// <summary>
        /// Message of the log entry
        /// </summary>
        public string Message;

        /// <summary>
        /// Descriptor of the message type.
        /// </summary>
        public LogType MessageType;

        /// <summary>
        /// Create a default log message with the current time.
        /// </summary>
        /// <param name="message"></param>
        public LogEntry(string message)
        {
            Time = DateTime.UtcNow;
            Message = message;
            MessageType = LogType.Trace;
        }

        /// <summary>
        /// Create a log entry at a specific time in the analysis (for a backtest).
        /// </summary>
        /// <param name="message">Message for log</param>
        /// <param name="time">Time of the message</param>
        /// <param name="type">Type of the log entry</param>
        public LogEntry(string message, DateTime time, LogType type = LogType.Trace)
        {
            Time = time.ToUniversalTime();
            Message = message;
            MessageType = type;
        }

        /// <summary>
        /// Helper override on the log entry.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Time.ToString("o"), MessageType, Message);
        }
    }
}
