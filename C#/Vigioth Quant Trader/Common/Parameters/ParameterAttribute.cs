using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Parameters
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ParameterAttribute : Attribute
    {
        public const BindingFlags BindingFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Instance;
        private static readonly string ParameterAttributeNameProperty = "Name";
        private static readonly string ParameterAttributeFullName = typeof (ParameterAttribute).FullName;
        public string Name { get; private set; }
        public ParameterAttribute(string name = null)
        {
            Name = name;
        }
        public static void ApplyAttributes(Dictionary<string, string> parameters, object instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            var type = instance.GetType();
            var members = type.GetFields(BindingFlags).Concat<MemberInfo>(type.GetProperties(BindingFlags));
            foreach (var memberInfo in members)
            {
                var fieldInfo = memberInfo as FieldInfo;
                var propertyInfo = memberInfo as PropertyInfo;
                if (fieldInfo == null && propertyInfo == null)
                {
                    throw new Exception("Resolved member that is neither FieldInfo or PropertyInfo");
                }
                var attribute = memberInfo.GetCustomAttribute<ParameterAttribute>();
                if (attribute == null) continue;
                var parameterName = attribute.Name ?? memberInfo.Name;
                string parameterValue;
                if (!parameters.TryGetValue(parameterName, out parameterValue)) continue;
                if (propertyInfo != null && !propertyInfo.CanWrite)
                {
                    var message = string.Format("The specified property is read only: {0}.{1}", propertyInfo.DeclaringType, propertyInfo.Name);
                    throw new Exception(message);
                }
                var memberType = fieldInfo != null ? fieldInfo.FieldType : propertyInfo.PropertyType;
                var value = parameterValue.ConvertTo(memberType);
                if (fieldInfo != null)
                {
                    fieldInfo.SetValue(instance, value);
                }
                else
                {
                    propertyInfo.SetValue(instance, value);
                }
            }
        }
        public static Dictionary<string, string> GetParametersFromAssembly(Assembly assembly)
        {
            var parameters = new Dictionary<string, string>();
            foreach (var type in assembly.GetTypes())
            {
                Log.Debug("ParameterAttribute.GetParametersFromAssembly(): Checking type " + type.Name);
                foreach (var field in type.GetFields(BindingFlags))
                {
                    var attribute = field.GetCustomAttribute<ParameterAttribute>();
                    if (attribute != null)
                    {
                        var parameterName = attribute.Name ?? field.Name;
                        parameters[parameterName] = field.FieldType.GetBetterTypeName();
                    }
                }
                foreach (var property in type.GetProperties(BindingFlags))
                {
                    if (!property.CanWrite) continue;
                    var attribute = property.GetCustomAttribute<ParameterAttribute>();
                    if (attribute != null)
                    {
                        var parameterName = attribute.Name ?? property.Name;
                        parameters[parameterName] = property.PropertyType.Name;
                    }
                }
            }
            return parameters;
        }
    }
}
