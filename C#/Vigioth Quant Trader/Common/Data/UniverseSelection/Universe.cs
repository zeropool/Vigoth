using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.UniverseSelection
{
    public abstract class Universe
    {
        public static readonly UnchangedUniverse Unchanged = UnchangedUniverse.Instance;
        private HashSet<Symbol> _previousSelections; 
        private readonly ConcurrentDictionary<Symbol, Member> _securities;
        public SecurityType SecurityType
        {
            get { return Configuration.SecurityType; }
        }
        public string Market
        {
            get { return Configuration.Market; }
        }
        public abstract UniverseSettings UniverseSettings
        {
            get;
        }
        public SubscriptionDataConfig Configuration
        {
            get; private set;
        }
        public ISecurityInitializer SecurityInitializer
        {
            get; private set;
        }
        public Dictionary<Symbol, Security> Members
        {
            get { return _securities.Select(x => x.Value.Security).ToDictionary(x => x.Symbol); }
        }
        protected Universe(SubscriptionDataConfig config, ISecurityInitializer securityInitializer = null)
        {
            _previousSelections = new HashSet<Symbol>();
            _securities = new ConcurrentDictionary<Symbol, Member>();
            Configuration = config;
            SecurityInitializer = securityInitializer ?? Securities.SecurityInitializer.Null;
        }
        public virtual bool CanRemoveMember(DateTime utcTime, Security security)
        {
            Member member;
            if (_securities.TryGetValue(security.Symbol, out member))
            {
                var timeInUniverse = utcTime - member.Added;
                if (timeInUniverse >= UniverseSettings.MinimumTimeInUniverse)
                {
                    return true;
                }
            }
            return false;
        }
        public IEnumerable<Symbol> PerformSelection(DateTime utcTime, BaseDataCollection data)
        {
            var result = SelectSymbols(utcTime, data);
            if (ReferenceEquals(result, Unchanged))
            {
                return Unchanged;
            }
            var selections = result.ToHashSet();
            var hasDiffs = _previousSelections.Except(selections).Union(selections.Except(_previousSelections)).Any();
            _previousSelections = selections;
            if (!hasDiffs)
            {
                return Unchanged;
            }
            return selections;
        }
        public abstract IEnumerable<Symbol> SelectSymbols(DateTime utcTime, BaseDataCollection data);
        public virtual Security CreateSecurity(Symbol symbol, IAlgorithm algorithm, MarketHoursDatabase marketHoursDatabase, SymbolPropertiesDatabase symbolPropertiesDatabase)
        {
            return SecurityManager.CreateSecurity(algorithm.Portfolio, algorithm.SubscriptionManager, marketHoursDatabase, symbolPropertiesDatabase,
                SecurityInitializer, symbol, UniverseSettings.Resolution, UniverseSettings.FillForward, UniverseSettings.Leverage,
                UniverseSettings.ExtendedMarketHours, false, false, symbol.ID.SecurityType == SecurityType.Option);
        }
        public virtual IEnumerable<SubscriptionDataConfig> GetSubscriptions(Security security)
        {
            return security.Subscriptions;
        }
        public bool ContainsMember(Symbol symbol)
        {
            return _securities.ContainsKey(symbol);
        }
        internal bool AddMember(DateTime utcTime, Security security)
        {
            if (_securities.ContainsKey(security.Symbol))
            {
                return false;
            }
            return _securities.TryAdd(security.Symbol, new Member(utcTime, security));
        }
        internal bool RemoveMember(DateTime utcTime, Security security)
        {
            if (CanRemoveMember(utcTime, security))
            {
                Member member;
                return _securities.TryRemove(security.Symbol, out member);
            }
            return false;
        }
        public sealed class UnchangedUniverse : IEnumerable<string>, IEnumerable<Symbol>
        {
            public static readonly UnchangedUniverse Instance = new UnchangedUniverse();
            private UnchangedUniverse() { }
            IEnumerator<Symbol> IEnumerable<Symbol>.GetEnumerator() { yield break; }
            IEnumerator<string> IEnumerable<string>.GetEnumerator() { yield break; }
            IEnumerator IEnumerable.GetEnumerator() { yield break; }
        }
        private sealed class Member
        {
            public readonly DateTime Added;
            public readonly Security Security;
            public Member(DateTime added, Security security)
            {
                Added = added;
                Security = security;
            }
        }
    }
}