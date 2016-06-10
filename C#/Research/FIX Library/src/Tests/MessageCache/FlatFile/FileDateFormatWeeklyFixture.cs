//    Copyright 2006, 2007, 2008 East Tech Incorporated
//
//    This file is part of FIX4NET.
//
//    FIX4NET is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Lesser General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    FIX4NET is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with FIX4NET.  If not, see <http://www.gnu.org/licenses/>.
//
using System;

using NUnit.Framework;

using FIX4NET.MessageCache.FlatFile;

namespace FIX4NET.Tests.MessageCache.FlatFile
{
    [TestFixture]
    public class FileDateFormatWeeklyFixture
    {
        private FileDateFormatWeekly Create()
        {
            return new FileDateFormatWeekly();
        }

        [Test]
        public void ToStringWhenSundayShouldStartWeek()
        {
            DateTime date = new DateTime(2008, 10, 19);
            string name = Create().ToString(date);
            Assert.AreEqual("20081019_20081025", name);
        }

        [Test]
        public void ToStringWhenSaturdayShouldEndWeek()
        {
            DateTime date = new DateTime(2008, 10, 25);
            string name = Create().ToString(date);
            Assert.AreEqual("20081019_20081025", name);
        }
    }
}
