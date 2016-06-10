using System;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public delegate void DataConsolidatedHandler(object sender, BaseData consolidated);
    public interface IDataConsolidator
    {
        BaseData Consolidated { get; }
        BaseData WorkingData { get; }
        Type InputType { get; }
        Type OutputType { get; }
        void Update(BaseData data);
        void Scan(DateTime currentLocalTime);
        event DataConsolidatedHandler DataConsolidated;
    }
}