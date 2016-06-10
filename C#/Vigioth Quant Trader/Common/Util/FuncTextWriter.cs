
using System;
using System.IO;
using System.Text;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Provides an implementation of <see cref="TextWriter"/> that redirects Write(string) and WriteLine(string)
    /// </summary>
    public class FuncTextWriter : TextWriter
    {
        private readonly Action<string> _writer;
        /// <inheritdoc />
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FuncTextWriter"/> that will direct
        /// messages to the algorithm's Debug function.
        /// </summary>
        /// <param name="writer">The algorithm hosting the Debug function where messages will be directed</param>
        public FuncTextWriter(Action<string> writer)
        {
            _writer = writer;
        }
        /// <summary>
        /// Writes the string value using the delegate provided at construction
        /// </summary>
        /// <param name="value">The string value to be written</param>
        public override void Write(string value)
        {
            _writer(value);
        }
        /// <summary>
        /// Writes the string value using the delegate provided at construction
        /// </summary>
        /// <param name="value"></param>
        public override void WriteLine(string value)
        {
            // these are grouped in a list so we don't need to add new line characters here
            _writer(value);
        }
    }
}
