using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.UniverseSelection
{
    public class SecurityChanges
    {
        public static readonly SecurityChanges None = new SecurityChanges(new List<Security>(), new List<Security>());
        private readonly HashSet<Security> _addedSecurities;
        private readonly HashSet<Security> _removedSecurities;
        public IReadOnlyList<Security> AddedSecurities
        {
            get { return _addedSecurities.OrderBy(x => x.Symbol.Value).ToList(); }
        }
        public IReadOnlyList<Security> RemovedSecurities
        {
            get { return _removedSecurities.OrderBy(x => x.Symbol.Value).ToList(); }
        }
        public SecurityChanges(IEnumerable<Security> addedSecurities, IEnumerable<Security> removedSecurities)
        {
            _addedSecurities = addedSecurities.ToHashSet();
            _removedSecurities = removedSecurities.ToHashSet();
        }
        public static SecurityChanges Added(params Security[] securities)
        {
            if (securities == null || securities.Length == 0) return None;
            return new SecurityChanges(securities.ToList(), new List<Security>());
        }
        public static SecurityChanges Removed(params Security[] securities)
        {
            if (securities == null || securities.Length == 0) return None;
            return new SecurityChanges(new List<Security>(), securities.ToList());
        }
        public static SecurityChanges operator +(SecurityChanges left, SecurityChanges right)
        {
            if (left == None) return right;
            if (right == None) return left;
            var additions = left.AddedSecurities.Union(right.AddedSecurities).ToList();
            var removals = left.RemovedSecurities.Union(right.RemovedSecurities).Where(x => !additions.Contains(x)).ToList();
            return new SecurityChanges(additions, removals);
        }
        #region Overrides of Object
        public override string ToString()
        {
            if (AddedSecurities.Count == 0 && RemovedSecurities.Count == 0)
            {
                return "SecurityChanges: None";
            }
            var added = string.Empty;
            if (AddedSecurities.Count != 0)
            {
                added = " Added: " + string.Join(",", AddedSecurities.Select(x => x.Symbol.ID));
            }
            var removed = string.Empty;
            if (RemovedSecurities.Count != 0)
            {
                removed = " Removed: " + string.Join(",", RemovedSecurities.Select(x => x.Symbol.ID));
            }
            return "SecurityChanges: " + added + removed;
        }
        #endregion
    }
}