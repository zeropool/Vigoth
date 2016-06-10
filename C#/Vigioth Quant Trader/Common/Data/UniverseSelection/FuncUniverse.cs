using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Data.UniverseSelection
{
    public class FuncUniverse : Universe
    {
        private readonly UniverseSettings _universeSettings;
        private readonly Func<IEnumerable<BaseData>, IEnumerable<Symbol>> _universeSelector;
        public override UniverseSettings UniverseSettings
        {
            get { return _universeSettings; }
        }
        public FuncUniverse(SubscriptionDataConfig configuration, UniverseSettings universeSettings, ISecurityInitializer securityInitializer, Func<IEnumerable<BaseData>, IEnumerable<Symbol>> universeSelector)
            : base(configuration, securityInitializer)
        {
            _universeSelector = universeSelector;
            _universeSettings = universeSettings;
        }
        public override IEnumerable<Symbol> SelectSymbols(DateTime utcTime, BaseDataCollection data)
        {
            return _universeSelector(data.Data);
        }
    }
}