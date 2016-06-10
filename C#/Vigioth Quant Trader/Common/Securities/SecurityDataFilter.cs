
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Securities.Interfaces;
namespace VigiothCapital.QuantTrader.Securities 
{
    /// <summary>
    /// Base class implementation for packet by packet data filtering mechanism to dynamically detect bad ticks.
    /// </summary>
    public class SecurityDataFilter : ISecurityDataFilter
    {
        /// <summary>
        /// Initialize data filter class
        /// </summary>
        public SecurityDataFilter()
        { }
        /// <summary>
        /// Filter the data packet passing through this method by returning true to accept, or false to fail/reject the data point.
        /// </summary>
        /// <param name="data">BasData data object we're filtering</param>
        /// <param name="vehicle">Security vehicle for filter</param>
        public virtual bool Filter(Security vehicle, BaseData data)
        {
            //By default the filter does not change data.
            return true;
        }
    } //End Filter
} //End Namespace