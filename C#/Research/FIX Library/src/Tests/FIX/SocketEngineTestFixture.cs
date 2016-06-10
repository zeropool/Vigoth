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
using System.Net;
using System.Threading;
using System.Collections.Generic;

using NUnit.Framework;

using FIX4NET;
using FIX4NET.FIX;
using FIX4NET.Net;
using FIX4NET.MessageCache.FlatFile;

namespace FIX4NET.Tests.FIX
{
    [TestFixture]
    public class SocketEngineTestFixture
    {
        private IEngine engineConnect = null, engineListen = null;
        private SocketListener listener = null;
        private MessageFactoryFIX factory = new MessageFactoryFIX("FIX.4.2");
        private MessageQueueSignal connectReceivQueue = new MessageQueueSignal();
        private MessageQueueSignal connectSendQueue = new MessageQueueSignal();
        private MessageQueueSignal listenReceiveQueue = new MessageQueueSignal();
        private MessageQueueSignal listenSendQueue = new MessageQueueSignal();

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            engineListen = new SocketEngine();
            engineListen.MessageCacheFactory = new MessageCacheFlatFileFactory();
            engineListen.MessageFactory = factory;
            engineListen.AllowOfflineSend = true;
            engineListen.Initialize("LISTEN", "CONNECT");
            engineListen.Received += new MessageEventHandler(engineListen_Received);
            engineListen.Sent += new MessageEventHandler(engineListen_Sent);

            listener = new SocketListener();
            listener.Add(engineListen);
            listener.Init(9050);

            engineConnect = new SocketEngine();
            engineConnect.MessageCacheFactory = new MessageCacheFlatFileFactory();
            engineConnect.MessageFactory = factory;
            engineConnect.AllowOfflineSend = true;
            engineConnect.Initialize("CONNECT", "LISTEN");
            engineConnect.Received += new MessageEventHandler(engineConnect_Received);
            engineConnect.Sent += new MessageEventHandler(engineConnect_Sent);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (engineConnect != null)
            {
                engineConnect.Received -= new MessageEventHandler(engineConnect_Received);
                engineConnect.Dispose();
            }
            if (engineListen != null)
            {
                engineListen.Received -= new MessageEventHandler(engineListen_Received);
                engineListen.Dispose();
            }
            if (listener != null)
                listener.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            connectReceivQueue.Clear();
            connectSendQueue.Clear();
            listenReceiveQueue.Clear();
            listenSendQueue.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            if (engineConnect.IsConnected)
                engineConnect.Logout("TEARDOWN");
        }

        private void engineConnect_Received(IEngine engine, IMessage message)
        {
            connectReceivQueue.Enqueue(message);
        }

        private void engineListen_Received(IEngine engine, IMessage message)
        {
            listenReceiveQueue.Enqueue(message);
        }

        private void engineConnect_Sent(IEngine engine, IMessage message)
        {
            connectSendQueue.Enqueue(message);
        }

        private void engineListen_Sent(IEngine engine, IMessage message)
        {
            listenSendQueue.Enqueue(message);
        }

        private void Logon()
        {
            SocketLogonArgs logonArgs = new SocketLogonArgs();
            logonArgs.IPAddress = IPAddress.Parse("127.0.0.1");
            logonArgs.Port = 9050;
            engineConnect.Logon(logonArgs);

            Assert.IsTrue(engineConnect.IsConnected, "Engine(Connect).IsConnected");
            Assert.IsTrue(engineListen.IsConnected, "Engine(Listen).IsConnected");
        }

        [Test]
        public void LogonTest()
        {
            Logon();
        }

        [Test]
        public void ResendTest()
        {
            Assert.AreEqual(engineConnect.MsgSeqNumIn, engineListen.MsgSeqNumOut, "MsgSeqNumIn=MsgSeqNumOut Before");

            engineListen.ResetMsgSeqNumOut(engineListen.MsgSeqNumOut + 10);

            SocketLogonArgs logonArgs = new SocketLogonArgs();
            logonArgs.IPAddress = IPAddress.Parse("127.0.0.1");
            logonArgs.Port = 9050;
            engineConnect.Logon(logonArgs);

            Assert.IsTrue(engineConnect.IsConnected, "Engine(Connect).IsConnected");

            DateTime timeout = DateTime.Now.AddSeconds(5);
            while (engineConnect.MsgSeqNumIn != engineListen.MsgSeqNumOut && DateTime.Now <= timeout)
                Thread.Sleep(10);

            Assert.AreEqual(engineConnect.MsgSeqNumIn, engineListen.MsgSeqNumOut, "MsgSeqNumIn=MsgSeqNumOut After");
        }

        [Test]
        public void LogoutTest()
        {
            Logon();

            engineConnect.Logout("NUint LogoutTest");

            Assert.IsFalse(engineConnect.IsConnected, "Engine(Connect).IsConnected");
        }

        [Test]
        public void SendTest()
        {
            Logon();

            IMessage messageSend = factory.CreateInstance("D");
            for (int i = 10000; i < 10100; i++)
                messageSend.Fields.Add(new Field(i, "VALUE" + i));

            Assert.AreEqual(100, messageSend.Fields.Count, "Field Count Send");

            engineConnect.Send(messageSend);

            IMessage messageReceive = null;
            bool received = false;
            DateTime timeout = DateTime.Now.AddSeconds(1);
            while (!received && timeout > DateTime.Now)
            {
                messageReceive = listenReceiveQueue.DequeueBlocked(100);
                if (messageReceive != null)
                    received = messageReceive.MsgSeqNum == messageSend.MsgSeqNum;
            }

            Assert.IsTrue(received, "Receive message across engines");
            Assert.AreEqual(messageSend.Fields.Count, messageReceive.Fields.Count, "Field Count Receive");
        }

        [Test]
        public void Send10KTest()
        {
            Logon();

            IMessage messageSend = null;
            for (int j = 0; j < 10000; j++)
            {
                messageSend = factory.CreateInstance("D");
                for (int i = 10000; i < 10100; i++)
                    messageSend.Fields.Add(new Field(i, "VALUE" + i));

                Assert.AreEqual(100, messageSend.Fields.Count, "Field Count Send");

                engineConnect.Send(messageSend);
            }

            IMessage messageReceive = null;
            bool received = false;
            DateTime timeout = DateTime.Now.AddSeconds(5);
            while (!received && timeout > DateTime.Now)
            {
                messageReceive = listenReceiveQueue.DequeueBlocked(100);
                if (messageReceive != null)
                    received = messageReceive.MsgSeqNum == messageSend.MsgSeqNum;
            }

            Assert.IsTrue(received, "Receive message across engines");
            Assert.AreEqual(messageSend.Fields.Count, messageReceive.Fields.Count, "Field Count Receive");
        }
    }
}