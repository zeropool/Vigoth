

using System;

namespace VigiothCapital.QuantTrader.Brokerages
{
    /// <summary>
    /// Represents an error retuned from a broker's server
    /// </summary>
    public class BrokerageException : Exception
    {
        /// <summary>
        /// Creates a new BrokerageException with the specified message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public BrokerageException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a new BrokerageException with the specified message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public BrokerageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
