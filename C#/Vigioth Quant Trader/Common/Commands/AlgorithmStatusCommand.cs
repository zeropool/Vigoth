using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Commands
{
    public class AlgorithmStatusCommand : ICommand
    {
        public AlgorithmStatus Status { get; set; }
        public AlgorithmStatusCommand()
        {
            Status = AlgorithmStatus.Running;
        }
        public AlgorithmStatusCommand(AlgorithmStatus status)
        {
            Status = status;
        }
        public CommandResultPacket Run(IAlgorithm algorithm)
        {
            algorithm.Status = Status;
            return new CommandResultPacket(this, true);
        }
    }
}