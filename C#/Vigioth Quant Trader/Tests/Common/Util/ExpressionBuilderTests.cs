

using System;
using System.Linq.Expressions;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests.Common.Util
{
    [TestFixture]
    public class ExpressionBuilderTests
    {
        [Test]
        public void MakesPropertyOrFieldSelectorThatWorks()
        {
            const string DayOfYear = "DayOfYear";
            Expression<Func<DateTime, int>> expected = x => x.DayOfYear;

            var actual = ExpressionBuilder.MakePropertyOrFieldSelector<DateTime, int>(DayOfYear);

            DateTime now = DateTime.UtcNow;

            Assert.AreEqual(expected.Compile().Invoke(now), actual.Compile().Invoke(now));
        }
        [Test]
        public void NonGenericMakesPropertyOrFieldSelectorThatWorks()
        {
            const string DayOfYear = "DayOfYear";
            Expression<Func<DateTime, int>> expected = x => x.DayOfYear;

            var actual = ExpressionBuilder.MakePropertyOrFieldSelector(typeof (DateTime), DayOfYear) as Expression<Func<DateTime, int>>; 
            Assert.IsNotNull(actual);

            DateTime now = DateTime.UtcNow;
            Assert.AreEqual(expected.Compile().Invoke(now), actual.Compile().Invoke(now));
        }
    }
}
