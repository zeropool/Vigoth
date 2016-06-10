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
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using FIX4NET;
using FIX4NET.FIX;

namespace FIX4NET.Tests.FIX
{
    [TestFixture]
    public class MessageFactoryFIXTestFixture
    {
        [Test]
        public void ParseTest()
        {
            string text = "8=FIX.4.235=81=1331=111=1111=111111=11=112=11=1331=111=1111=111111=11=112=11=1331=111=1111=111111=1";
            MessageFactoryFIX factory = new MessageFactoryFIX("FIX.4.2");
            IMessage message = factory.Parse(text);
            Assert.AreEqual(19, message.Fields.Count, "Message.Fields.Count");
        }
    }
}
