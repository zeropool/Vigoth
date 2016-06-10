namespace VigiothCapital.QuantTrader.Commands
{
    public sealed class QuitCommand : AlgorithmStatusCommand
    {
        public QuitCommand()
            : base(AlgorithmStatus.Stopped)
        {
        }
    }
}