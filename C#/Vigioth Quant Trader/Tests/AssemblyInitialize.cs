

using NUnit.Framework;
using VigiothCapital.QuantTrader.Logging;

[SetUpFixture]
public class AssemblyInitialize
{
    [SetUp]
    public void SetLogHandler()
    {
        // save output to file as well
        Log.LogHandler = new ConsoleLogHandler();
    }
}
