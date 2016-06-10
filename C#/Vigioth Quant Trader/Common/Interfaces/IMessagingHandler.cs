using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Notifications;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Interfaces
{
    [InheritedExport(typeof(IMessagingHandler))]
    public interface IMessagingHandler
    {
        bool HasSubscribers { get; set; }
        void Initialize();
        void SetAuthentication(AlgorithmNodePacket job);
        void Send(Packet packet);
        void SendNotification(Notification notification);
    }
}
