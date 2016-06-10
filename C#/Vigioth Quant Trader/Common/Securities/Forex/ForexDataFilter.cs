using VigiothCapital.QuantTrader.Data;
namespace VigiothCapital.QuantTrader.Securities.Forex 
{
    public class ForexDataFilter : SecurityDataFilter
    {
        public ForexDataFilter()
            : base() 
        {
        }
        public override bool Filter(Security vehicle, BaseData data)
        {
            return true;
        }
    }  
}  