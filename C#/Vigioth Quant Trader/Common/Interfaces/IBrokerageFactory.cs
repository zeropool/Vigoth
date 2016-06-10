using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Brokerages;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Interfaces
{
    [InheritedExport(typeof(IBrokerageFactory))]
    public interface IBrokerageFactory : IDisposable
    {
        Type BrokerageType { get; }
        Dictionary<string, string> BrokerageData { get; }
        IBrokerageModel BrokerageModel { get; }
        IBrokerage CreateBrokerage(LiveNodePacket job, IAlgorithm algorithm);
    }
}