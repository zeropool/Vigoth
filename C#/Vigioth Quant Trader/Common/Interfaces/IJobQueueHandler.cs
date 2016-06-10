using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Interfaces
{
    [InheritedExport(typeof(IJobQueueHandler))]
    public interface IJobQueueHandler
    {
        void Initialize();
        AlgorithmNodePacket NextJob(out string algorithmPath);
        void AcknowledgeJob(AlgorithmNodePacket job);
    }
}
