using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Commands
{
    public interface ICommand
    {
        CommandResultPacket Run(IAlgorithm algorithm);
    }
}
