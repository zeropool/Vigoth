

using System;
using System.ComponentModel.Composition;

namespace VigiothCapital.QuantTrader.Logging
{
    /// <summary>
    /// Interface for redirecting log output
    /// </summary>
    [InheritedExport(typeof(ILogHandler))]
    public interface ILogHandler : IDisposable
    {
        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="text">The error text to log</param>
        void Error(string text);
       
        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The debug text to log</param>
        void Debug(string text);
       
        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The trace text to log</param>
        void Trace(string text);
    }
}