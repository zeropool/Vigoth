using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Commands
{
    public sealed class LiquidateCommand : ICommand
    {
        public CommandResultPacket Run(IAlgorithm algorithm)
        {
            algorithm.Liquidate();
            return new CommandResultPacket(this, true);
        }
    }
}