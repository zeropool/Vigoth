
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CloneExtensions;
using Fasterflect;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Provides methods for creating new instances of objects
    /// </summary>
    public static class ObjectActivator
    {
        private static readonly object _lock = new object();
        private static readonly object[] _emptyObjectArray = new object[0];
        private static readonly Dictionary<Type, MethodInvoker> _cloneMethodsByType = new Dictionary<Type, MethodInvoker>();
        private static readonly Dictionary<Type, Func<object[], object>> _activatorsByType = new Dictionary<Type, Func<object[], object>>();
        static ObjectActivator()
        {
            // we can reuse the symbol instance in the clone since it's immutable
            ((HashSet<Type>) CloneFactory.KnownImmutableTypes).Add(typeof (Symbol));
            ((HashSet<Type>) CloneFactory.KnownImmutableTypes).Add(typeof (SecurityIdentifier));
        }
        /// <summary>
        /// Fast Object Creator from Generic Type:
        /// Modified from http://rogeralsing.com/2008/02/28/linq-expressions-creating-objects/
        /// </summary>
        /// <remarks>This assumes that the type has a parameterless, default constructor</remarks>
        /// <param name="dataType">Type of the object we wish to create</param>
        /// <returns>Method to return an instance of object</returns>
        public static Func<object[], object> GetActivator(Type dataType)
        {
            lock (_lock)
            {
                // if we already have it, just use it
                Func<object[], object> factory;
                if (_activatorsByType.TryGetValue(dataType, out factory))
                {
                    return factory;
                }
                var ctor = dataType.GetConstructor(new Type[] {});
                //User has forgotten to include a parameterless constructor:
                if (ctor == null) return null;
                var paramsInfo = ctor.GetParameters();
                //create a single param of type object[]
                var param = Expression.Parameter(typeof (object[]), "args");
                var argsExp = new Expression[paramsInfo.Length];
                for (var i = 0; i < paramsInfo.Length; i++)
                {
                    var index = Expression.Constant(i);
                    var paramType = paramsInfo[i].ParameterType;
                    var paramAccessorExp = Expression.ArrayIndex(param, index);
                    var paramCastExp = Expression.Convert(paramAccessorExp, paramType);
                    argsExp[i] = paramCastExp;
                }
                var newExp = Expression.New(ctor, argsExp);
                var lambda = Expression.Lambda(typeof (Func<object[], object>), newExp, param);
                factory = (Func<object[], object>) lambda.Compile();
                // save it for later
                _activatorsByType.Add(dataType, factory);
                return factory;
            }
        }
        /// <summary>
        /// Clones the specified instance using reflection
        /// </summary>
        /// <param name="instanceToClone">The instance to be cloned</param>
        /// <returns>A field/property wise, non-recursive clone of the instance</returns>
        public static object Clone(object instanceToClone)
        {
            var type = instanceToClone.GetType();
            MethodInvoker func;
            if (_cloneMethodsByType.TryGetValue(type, out func))
            {
                return func(null, instanceToClone);
            }
            // public static T GetClone<T>(this T source, CloningFlags flags)
            var method = typeof (CloneFactory).GetMethods().FirstOrDefault(x => x.Name == "GetClone" && x.GetParameters().Length == 1);
            method = method.MakeGenericMethod(type);
            func = method.DelegateForCallMethod();
            _cloneMethodsByType[type] = func;
            return func(null, instanceToClone);
        }
        /// <summary>
        /// Clones the specified instance and then casts it to T before returning
        /// </summary>
        public static T Clone<T>(T instanceToClone) where T : class
        {
            var clone = Clone((object)instanceToClone) as T;
            if (clone == null)
            {
                throw new Exception("Unable to clone instance of type " + instanceToClone.GetType().Name + " to " + typeof(T).Name);
            }
            return clone;
        }
    }
}
