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

using FIX4NET.Net;

namespace FIX4NET.Tests.FIX
{
    [TestFixture]
    public class SocketEngineSendResendTestFixture
    {
        [Test]
        public void ResendShouldBeSentOnlyOnce()
        {
            MySocketEngine engine = new MySocketEngine();
            engine.MySendResendRequest();
            engine.MySendResendRequest();
            Assert.AreEqual(1, engine.ResendCount);
        }

        [Test]
        public void ResendShouldBeSentMultipleTimes()
        {
            MySocketEngine engine = new MySocketEngine();
            engine.MySendResendRequest();
            engine.SetLastResendRequestTimestamp(DateTime.MinValue);
            engine.MySendResendRequest();
            Assert.AreEqual(2, engine.ResendCount);
        }

        private class MySocketEngine : SocketEngine
        {
            private int _resendCount;
            public int ResendCount { get { return _resendCount; } }

            public MySocketEngine()
            {
                _messageFactory = new FIX4NET.FIX.MessageFactoryFIX();
            }

            public void MySendResendRequest()
            {
                SendResendRequest();
            }

            public override void Send(IMessage message)
            {
                if (MessageFactory.IsResendRequestMessage(message))
                    _resendCount++;
            }

            public void SetLastResendRequestTimestamp(DateTime timestamp)
            {
                _lastResendRequestTimestamp = timestamp;
            }
        }
    }
}
