

using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class SingleValueListConverterTests
    {
        private const string Data = "some data";

        private static readonly WellFormedContainer WellFormedInstance = new WellFormedContainer
        {
            ComplexTypes = new List<ComplexType>
            {
                new ComplexType
                {
                    ID = 1,
                    Data = Data
                }
            }
        };

        private static readonly PoorlyFormedContainer PoorlyFormedInstance = new PoorlyFormedContainer
        {
            ComplexTypes = new ComplexType
            {
                ID = 1,
                Data = Data
            }
        };

        private readonly static string ListJson = JsonConvert.SerializeObject(WellFormedInstance);
        private readonly static string ObjectJson = JsonConvert.SerializeObject(PoorlyFormedInstance);

        [Test]
        public void DeserializesList()
        {
            var converted = JsonConvert.DeserializeObject(ListJson, typeof(WellFormedContainer));
            Assert.IsInstanceOf<WellFormedContainer>(converted);
            var instance = (WellFormedContainer)converted;
            Assert.AreEqual(1, instance.ComplexTypes.Count);
            Assert.AreEqual(1, instance.ComplexTypes[0].ID);
            Assert.AreEqual(Data, instance.ComplexTypes[0].Data);
        }

        [Test]
        public void DeserializesSingleValue()
        {
            var converted = JsonConvert.DeserializeObject(ObjectJson, typeof(WellFormedContainer));
            Assert.IsInstanceOf<WellFormedContainer>(converted);
            var instance = (WellFormedContainer)converted;
            Assert.AreEqual(1, instance.ComplexTypes.Count);
            Assert.AreEqual(1, instance.ComplexTypes[0].ID);
            Assert.AreEqual(Data, instance.ComplexTypes[0].Data);
        }

        [Test]
        public void SerializesListWithOneValue()
        {
            var serialized = JsonConvert.SerializeObject(WellFormedInstance);
            Assert.AreEqual(ListJson, serialized);
        }

        class WellFormedContainer
        {
            [JsonConverter(typeof(SingleValueListConverter<ComplexType>))]
            public List<ComplexType> ComplexTypes;
        }

        class PoorlyFormedContainer
        {
            public ComplexType ComplexTypes;
        }

        class ComplexType
        {
            public int ID;
            public string Data;
        }
    }
}
