using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Commands;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Interfaces
{
    [InheritedExport(typeof(ICommandQueueHandler))]
    public interface ICommandQueueHandler : IDisposable
    {
        void Initialize(AlgorithmNodePacket job, IAlgorithm algorithm);
        IEnumerable<ICommand> GetCommands();
    }
}
