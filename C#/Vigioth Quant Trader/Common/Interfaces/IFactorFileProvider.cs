using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Data.Auxiliary;
namespace VigiothCapital.QuantTrader.Interfaces
{
    [InheritedExport(typeof(IFactorFileProvider))]
    public interface IFactorFileProvider
    {
        FactorFile Get(Symbol symbol);
    }
}