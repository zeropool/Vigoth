using System.Collections.Generic;
using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Interfaces
{
    [InheritedExport(typeof(IDataQueueHandler))]
    public interface IDataQueueHandler
    {
        IEnumerable<BaseData> GetNextTicks();
        void Subscribe(LiveNodePacket job, IEnumerable<Symbol> symbols);
        void Unsubscribe(LiveNodePacket job, IEnumerable<Symbol> symbols);
    }
}
