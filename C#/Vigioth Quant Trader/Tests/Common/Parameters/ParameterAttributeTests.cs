

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Parameters;

namespace VigiothCapital.QuantTrader.Tests.Common.Parameters
{
    [TestFixture]
    public class ParameterAttributeTests
    {
        [Test]
        public void SetsParameterValues()
        {
            var instance = new Instance();
            var parameters = new Dictionary<string, string>
            {
                {"PublicField", "1"},
                {"PublicProperty", "1"},
                {"ProtectedField", "1"},
                {"ProtectedProperty", "1"},
                {"InternalField", "1"},
                {"InternalProperty", "1"},
                {"PrivateField", "1"},
                {"PrivateProperty", "1"},
            };

            ParameterAttribute.ApplyAttributes(parameters, instance);
        }

        [Test]
        public void FindsParameters()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var parameters = ParameterAttribute.GetParametersFromAssembly(assembly);
            foreach (var field in typeof(Instance).GetFields(ParameterAttribute.BindingFlags).Where(x => !x.Name.Contains(">k__")))
            {
                Assert.IsTrue(parameters.ContainsKey(field.Name), "Failed on Field: " + field.Name);
            }
            foreach (var property in typeof(Instance).GetProperties(ParameterAttribute.BindingFlags))
            {
                Assert.IsTrue(parameters.ContainsKey(property.Name), "Failed on Property: " + property.Name);
            }
        }

        [Test]
        public void FindsParametersUsingReflection()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var parameters = ParameterAttribute.GetParametersFromAssembly(assembly);
            foreach (var field in typeof(Instance).GetFields(ParameterAttribute.BindingFlags).Where(x => !x.Name.Contains(">k__")))
            {
                Assert.IsTrue(parameters.ContainsKey(field.Name), "Failed on Field: " + field.Name);
            }
            foreach (var property in typeof(Instance).GetProperties(ParameterAttribute.BindingFlags))
            {
                Assert.IsTrue(parameters.ContainsKey(property.Name), "Failed on Property: " + property.Name);
            }
        }

        class Instance
        {
            [Parameter]
            public int PublicField;
            [Parameter]
            public int PublicProperty { get; set; }
            [Parameter]
            protected int ProtectedField;
            [Parameter]
            protected int ProtectedProperty { get; set; }
            [Parameter]
            internal int InternalField;
            [Parameter]
            internal int InternalProperty { get; set; }
            [Parameter]
            private int PrivateField;
            [Parameter]
            private int PrivateProperty { get; set; }

            public void AssertValues(int expected)
            {

                Assert.AreEqual(expected, PublicField);
                Assert.AreEqual(expected, PublicProperty);
                Assert.AreEqual(expected, ProtectedField);
                Assert.AreEqual(expected, ProtectedProperty);
                Assert.AreEqual(expected, InternalField);
                Assert.AreEqual(expected, InternalProperty);
                Assert.AreEqual(expected, PrivateField);
                Assert.AreEqual(expected, PrivateProperty);
            }
        }
    }
}
