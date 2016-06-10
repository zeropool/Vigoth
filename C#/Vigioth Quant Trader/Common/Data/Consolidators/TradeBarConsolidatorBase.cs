using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public abstract class TradeBarConsolidatorBase<T> : PeriodCountConsolidatorBase<T, TradeBar>
        where T : BaseData
    {
        protected TradeBarConsolidatorBase(TimeSpan period)
            : base(period)
        {
        }
        protected TradeBarConsolidatorBase(int maxCount)
            : base(maxCount)
        {
        }
        protected TradeBarConsolidatorBase(int maxCount, TimeSpan period)
            : base(maxCount, period)
        {
        }
        public TradeBar WorkingBar
        {
            get { return (TradeBar) WorkingData; }
        }
    }
}