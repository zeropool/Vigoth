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
using System.IO;

using NUnit.Framework;

using FIX4NET.FIX;
using FIX4NET.MessageCache.FlatFile;

namespace FIX4NET.Tests.MessageCache.FlatFile
{
    [TestFixture]
    public class MessageCacheFlatFileTestFixture
    {
        private string _path;

        private MessageCacheFlatFile Create()
        {
            MessageFactoryFIX factory = new MessageFactoryFIX("FIX.4.2");

            MessageCacheFlatFile cache = new MessageCacheFlatFile();
            cache.Initialize(factory);
            cache.Path = _path;
            cache.Open("TEST", null, "TEST", null, DateTime.MinValue);
            return cache;
        }

        [Test]
        public void ResetMsgSeqNumInShouldPass()
        {
            _path = Path.GetTempPath();

            if (File.Exists(_path + "TEST__TEST__00010101.LOG")) File.Delete(_path + "TEST__TEST__00010101.LOG");
            if (File.Exists(_path + "TEST__TEST__00010101.LDX")) File.Delete(_path + "TEST__TEST__00010101.LDX");

            MessageCacheFlatFile cache;

            cache = Create();
            cache.ResetMsgSeqNumIn(11);
            Assert.AreEqual(10, cache.MsgSeqNumIn);
            cache.Close();

            cache = Create();
            Assert.AreEqual(10, cache.MsgSeqNumIn);
            cache.Close();
        }

        [Test]
        public void ResetMsgSeqNumOutShouldPass()
        {
            _path = Path.GetTempPath();

            if (File.Exists(_path + "TEST__TEST__00010101.LOG")) File.Delete(_path + "TEST__TEST__00010101.LOG");
            if (File.Exists(_path + "TEST__TEST__00010101.LDX")) File.Delete(_path + "TEST__TEST__00010101.LDX");

            MessageCacheFlatFile cache;

            cache = Create();
            cache.ResetMsgSeqNumOut(11);
            Assert.AreEqual(10, cache.MsgSeqNumOut);
            cache.Close();

            cache = Create();
            Assert.AreEqual(10, cache.MsgSeqNumOut);
            cache.Close();
        }

        [Test]
        public void ResetMsgSeqNumMultipleTimesShouldPass()
        {
            _path = Path.GetTempPath();

            if (File.Exists(_path + "TEST__TEST__00010101.LOG")) File.Delete(_path + "TEST__TEST__00010101.LOG");
            if (File.Exists(_path + "TEST__TEST__00010101.LDX")) File.Delete(_path + "TEST__TEST__00010101.LDX");

            MessageCacheFlatFile cache;

            cache = Create();
            cache.ResetMsgSeqNumIn(100);
            cache.ResetMsgSeqNumIn(200);
            cache.ResetMsgSeqNumIn(5);
            cache.ResetMsgSeqNumIn(11);
            cache.ResetMsgSeqNumOut(11);
            Assert.AreEqual(10, cache.MsgSeqNumIn);
            Assert.AreEqual(10, cache.MsgSeqNumOut);
            cache.Close();

            cache = Create();
            Assert.AreEqual(10, cache.MsgSeqNumIn);
            Assert.AreEqual(10, cache.MsgSeqNumOut);
            cache.Close();
        }

        [Test]
        public void ResetMsgSeqNumInWithExistingMessagesShouldPass()
        {
            _path = Path.GetTempPath();
            MessageFactoryFIX factory = new MessageFactoryFIX("FIX.4.2");

            if (File.Exists(_path + "TEST__TEST__00010101.LOG")) File.Delete(_path + "TEST__TEST__00010101.LOG");
            if (File.Exists(_path + "TEST__TEST__00010101.LDX")) File.Delete(_path + "TEST__TEST__00010101.LDX");

            MessageCacheFlatFile cache;

            cache = Create();
            for (int j = 1; j < 100; j++)
            {
                IMessage message = factory.CreateInstance("D");
                message.Direction = MessageDirection.In;
                message.MsgSeqNum = j;
                for (int i = 10000; i < 10100; i++)
                    message.Fields.Add(new Field(i, "VALUE" + i));
                factory.Build(message);
                cache.AddMessage(message);
            }
            Assert.AreEqual(99, cache.MsgSeqNumIn);
            cache.Close();

            cache = Create();
            cache.ResetMsgSeqNumIn(200);
            Assert.AreEqual(199, cache.MsgSeqNumIn);
            cache.Close();

            cache = Create();
            Assert.AreEqual(199, cache.MsgSeqNumIn);
            cache.ResetMsgSeqNumIn(300);
            Assert.AreEqual(299, cache.MsgSeqNumIn);
            cache.Close();

            cache = Create();
            Assert.AreEqual(299, cache.MsgSeqNumIn);
            cache.Close();
        }
    }
}