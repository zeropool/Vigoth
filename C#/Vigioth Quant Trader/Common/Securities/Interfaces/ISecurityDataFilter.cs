using VigiothCapital.QuantTrader.Data;
namespace VigiothCapital.QuantTrader.Securities.Interfaces
{
    public interface ISecurityDataFilter 
    {
        bool Filter(Security vehicle, BaseData data);
    }     
}    
