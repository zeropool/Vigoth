

using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Configuration;

namespace VigiothCapital.QuantTrader.Tests.Configuration
{
    [TestFixture]
    public class ConfigTests
    {
        [Test]
        public void SetRespectsEnvironment()
        {
            bool betaMode = Config.GetBool("beta-mode");
            var env = Config.Get("environment");
            Config.Set(env + ".beta-mode", betaMode ? "false" : "true");


            bool betaMode2 = Config.GetBool("beta-mode");
            Assert.AreNotEqual(betaMode, betaMode2);
        }

        [Test]
        public void FlattenTest()
        {
            // read in and rewrite the environment based on the settings
            const string overrideEnvironment = "live-paper.beta";

            var config = JObject.Parse(
@"{
   'some-setting': 'false',                 
    environments: {
        'live-paper': {
            'some-setting': 'true',
            'environments': {
                'beta': {
                    'some-setting2': 'true'
                }
            }
        }
    }
}");

            var configCopy = config.DeepClone();

            var clone = Config.Flatten(config, overrideEnvironment);

            // remove environments
            Assert.IsNull(clone.Property("environment"));
            Assert.IsNull(clone.Property("environments"));

            // properly applied environment
            Assert.AreEqual("true", clone.Property("some-setting").Value.ToString());
            Assert.AreEqual("true", clone.Property("some-setting2").Value.ToString());

            Assert.AreEqual(configCopy, config);
        }

        [Test]
        public void GetValueHandlesDateTime()
        {
            GetValueHandles(new DateTime(2015, 1, 2, 3, 4, 5));
        }

        [Test]
        public void GetValueHandlesTimeSpan()
        {
            GetValueHandles(new TimeSpan(1, 2, 3, 4, 5));
        }

        private void GetValueHandles<T>(T value)
        {
            var configValue = value.ToString();
            Config.Set("temp-value", configValue);
            var actual = Config.GetValue<T>("temp-value");
            Assert.AreEqual(value, actual);
        }
    }
}
