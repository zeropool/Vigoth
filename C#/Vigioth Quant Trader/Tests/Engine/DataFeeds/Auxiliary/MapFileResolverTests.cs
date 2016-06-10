

using System;
using System.Collections.Generic;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Auxiliary;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds.Auxiliary
{
    [TestFixture]
    public class MapFileResolverTests
    {
        private readonly MapFileResolver _resolver = CreateMapFileResolver();

        [Test]
        public void ResolvesStraightMapping()
        {
            var spyMapFile = _resolver.ResolveMapFile("SPY", new DateTime(2015, 08, 23));
            Assert.IsNotNull(spyMapFile);
            Assert.AreEqual("SPY", spyMapFile.GetMappedSymbol(new DateTime(2015, 08, 23)));
        }

        [Test]
        public void ResolvesMapFilesOnNonSpecifiedDates()
        {
            var mapFile = _resolver.ResolveMapFile("GOOG", new DateTime(2014, 04, 01));
            Assert.AreEqual("GOOGL", mapFile.Permtick);

            mapFile = _resolver.ResolveMapFile("GOOG", new DateTime(2014, 04, 03));
            Assert.AreEqual("GOOG", mapFile.Permtick);
        }

        [Test]
        public void ResolvesOldSymbolRemapped()
        {
            // on 2014.04.02 a symbol GOOG traded its last day, the following day it would trade under GOOGL
            var april2 = new DateTime(2014, 04, 02);
            var googMapFile = _resolver.ResolveMapFile("GOOG", april2);
            Assert.IsNotNull(googMapFile);
            Assert.AreEqual("GOOG", googMapFile.GetMappedSymbol(april2));
            Assert.AreEqual("GOOGL", googMapFile.GetMappedSymbol(april2.AddDays(1)));
        }

        [Test]
        public void ResolvesExactMapping()
        {
            var oih1 = _resolver.ResolveMapFile("OIH.1", new DateTime(2011, 12, 20));
            Assert.IsNotNull(oih1);
            Assert.AreEqual("OIH", oih1.GetMappedSymbol(new DateTime(2010, 02, 06)));
            Assert.AreEqual("OIH", oih1.GetMappedSymbol(new DateTime(2010, 02, 07)));
            Assert.AreEqual("OIH", oih1.GetMappedSymbol(new DateTime(2011, 12, 20)));
            Assert.AreEqual(string.Empty, oih1.GetMappedSymbol(new DateTime(2011, 12, 21)));
        }

        private static MapFileResolver CreateMapFileResolver()
        {
            return new MapFileResolver(new List<MapFile>
            {
                // remapped
                new MapFile("goog", new List<MapFileRow>
                {
                    new MapFileRow(new DateTime(2014, 03, 27), "goocv"),
                    new MapFileRow(new DateTime(2014, 04, 02), "goocv"),
                    new MapFileRow(new DateTime(2050, 12, 31), "goog")
                }),
                new MapFile("googl", new List<MapFileRow>
                {
                    new MapFileRow(new DateTime(2004, 08, 19), "goog"),
                    new MapFileRow(new DateTime(2014, 04, 02), "goog"),
                    new MapFileRow(new DateTime(2050, 12, 31), "googl")
                }),
                // straight mapping
                new MapFile("spy", new List<MapFileRow>
                {
                    new MapFileRow(new DateTime(1998, 01, 02), "spy"),
                    new MapFileRow(new DateTime(2050, 12, 31), "spy")
                }),
                // new share class overtakes old share class same symbol
                new MapFile("oih.1", new List<MapFileRow>
                {
                    new MapFileRow(new DateTime(2010, 02, 07), "oih"),
                    new MapFileRow(new DateTime(2011, 12, 20), "oih")
                }),
                new MapFile("oih", new List<MapFileRow>
                {
                    new MapFileRow(new DateTime(2011, 12, 21), "oih"),
                    new MapFileRow(new DateTime(2050, 12, 31), "oih")
                }),
            });
        }
    }
}