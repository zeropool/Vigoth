using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using NodaTime;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Packets;
using HistoryRequest = VigiothCapital.QuantTrader.Data.HistoryRequest;
namespace VigiothCapital.QuantTrader.Interfaces
{
    [InheritedExport(typeof(IHistoryProvider))]
    public interface IHistoryProvider
    {
        int DataPointCount { get; }
        void Initialize(AlgorithmNodePacket job, IMapFileProvider mapFileProvider, IFactorFileProvider factorFileProvider, Action<int> statusUpdate);
        IEnumerable<Slice> GetHistory(IEnumerable<HistoryRequest> requests, DateTimeZone sliceTimeZone);
    }
}
