using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Data.Auxiliary;
namespace VigiothCapital.QuantTrader.Interfaces
{
    [InheritedExport(typeof(IMapFileProvider))]
    public interface IMapFileProvider
    {
        MapFileResolver Get(string market);
    }
}
