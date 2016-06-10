using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data
{
    public abstract class DynamicData : BaseData, IDynamicMetaObjectProvider
    {
        private readonly IDictionary<string, object> _storage = new Dictionary<string, object>();
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new DynamicDataMetaObject(parameter, this);
        }
        public object SetProperty(string name, object value)
        {
            name = name.ToLower();
            if (name == "time")
            {
                Time = (DateTime)value;
            }
            if (name == "value")
            {
                Value = (decimal)value;
            }
            if (name == "symbol")
            {
                if (value is string)
                {
                    Symbol = SymbolCache.GetSymbol((string) value);
                }
                else
                {
                    Symbol = (Symbol) value;
                }
            }
            _storage[name] = value;
            return value;
        }
        public object GetProperty(string name)
        {
            name = name.ToLower();
            if (name == "time")
            {
                return Time;
            }
            if (name == "value")
            {
                return Value;
            }
            if (name == "symbol")
            {
                return Symbol;
            }
            if (name == "price")
            {
                return Price;
            }
            object value;
            if (!_storage.TryGetValue(name, out value))
            {
                throw new Exception("Property with name '" + name + "' does not exist. Properties: Time, Symbol, Value " + string.Join(", ", _storage.Keys));
            }
            return value;
        }
        public bool HasProperty(string name)
        {
            return _storage.ContainsKey(name.ToLower());
        }
        public override BaseData Clone()
        {
            var clone = ObjectActivator.Clone(this);
            foreach (var kvp in _storage)
            {
                clone._storage.Add(kvp);
            }
            return clone;
        }
        private class DynamicDataMetaObject : DynamicMetaObject
        {
            private static readonly MethodInfo SetPropertyMethodInfo = typeof(DynamicData).GetMethod("SetProperty");
            private static readonly MethodInfo GetPropertyMethodInfo = typeof(DynamicData).GetMethod("GetProperty");
            public DynamicDataMetaObject(Expression expression, DynamicData instance)
                : base(expression, BindingRestrictions.Empty, instance)
            {
            }
            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                var args = new Expression[]
                {
                    Expression.Constant(binder.Name),
                    Expression.Convert(value.Expression, typeof (object))
                };
                var self = Expression.Convert(Expression, LimitType);
                var call = Expression.Call(self, SetPropertyMethodInfo, args);
                return new DynamicMetaObject(call, restrictions);
            }
            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                var args = new Expression[]
                {
                    Expression.Constant(binder.Name)
                };
                var self = Expression.Convert(Expression, LimitType);
                var call = Expression.Call(self, GetPropertyMethodInfo, args);
                return new DynamicMetaObject(call, restrictions);
            }
        }
    }
}
