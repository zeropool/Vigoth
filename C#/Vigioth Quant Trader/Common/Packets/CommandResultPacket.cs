using VigiothCapital.QuantTrader.Commands;
namespace VigiothCapital.QuantTrader.Packets
{
    public class CommandResultPacket : Packet
    {
        public string CommandName { get; set; }
        public bool Success { get; set; }
        public CommandResultPacket(ICommand command, bool success)
            : base(PacketType.CommandResult)
        {
            Success = success;
            CommandName = command.GetType().Name;
        }
    }
}
