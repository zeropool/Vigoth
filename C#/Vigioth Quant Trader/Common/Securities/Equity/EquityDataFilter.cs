using VigiothCapital.QuantTrader.Data;
namespace VigiothCapital.QuantTrader.Securities.Equity 
{
    public class EquityDataFilter : SecurityDataFilter
    {
        public EquityDataFilter() : base()
        {
        }
        public override bool Filter(Security vehicle, BaseData data)
        {
            return true;
        }
    }  
}  