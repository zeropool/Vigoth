#region Copyright
/*
* Copyright Onix Solutions Limited [OnixS]. All rights reserved.
*
* This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
* and international copyright treaties.
*
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting
* a non-assignable, non-transferable and non-exclusive license to use the software
* for it's own data processing purposes under the terms defined in the Agreement.
*
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited.
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with
* the terms of the Agreement is a violation of copyright law.
*/
#endregion

using System;
using System.Collections.Generic;
using FIXForge.NET.FIX;

namespace PluggableSessionStorage
{
    class MySessionStorage : ISessionStorage
    {
        public void Clear()
        {
        }

        public void Close(bool keepSequenceNumbersBetweenFixConnections, bool doBackup)
        {
            this.keepSequenceNumbers = keepSequenceNumbersBetweenFixConnections;
            this.doBackup = doBackup;
        }

        public String Id
        {
            get
            {
                return "MyStorage";
            }
        }

        public int InSeqNum
        {
            get
            {
                return inSeqNum;
            }
            set
            {
                inSeqNum = value;
            }
        }

        public Message FindOutboundMessage(int messageSequenceNumber)
        {
            if (outboundMessages.ContainsKey(messageSequenceNumber))
            {
                return outboundMessages[messageSequenceNumber];
            }
            else
            {
                return null;
            }
        }

        public void SetSessionTerminationStatus(bool terminated)
        {            
        }

        public void StoreInboundMessage(Message message, bool keepMessage)
        {
            inSeqNum = message.SeqNum;

            lastInboundMessage = message;
        }

        public void StoreOutboundMessage(Message message, bool keepMessage)
        {
            outSeqNum = message.SeqNum;

            lastOutboundMessage = message;

            if (keepMessage && !outboundMessages.ContainsKey(message.SeqNum))
            {
                outboundMessages.Add(message.SeqNum, message);
            }
        }

        public void StoreOutboundMessage(FIXForge.NET.FIX.SerializedMessage message, int sequenceNumber, bool keepMessage)
        {
            outSeqNum = sequenceNumber;
        }

        public int OutSeqNum
        {
            get
            {
                return outSeqNum;
            }
            set
            {
                outSeqNum = value;
            }
        }

        private Message lastInboundMessage;

        public Message LastInboundMessage
        {
            get { return lastInboundMessage; }
        }

        private Message lastOutboundMessage;

        public Message LastOutboundMessage
        {
            get { return lastOutboundMessage; }
        }

        private Dictionary<int, Message> outboundMessages = new Dictionary<int, Message>();

        private int inSeqNum;

        private int outSeqNum;

        private bool keepSequenceNumbers;

        public bool KeepSequenceNumbers
        {
            get { return keepSequenceNumbers; }
            set { keepSequenceNumbers = value; }
        }

        private System.DateTime sessionCreationTime = Session.UnknownSessionCreationTime;

        public System.DateTime SessionCreationTime
        {
            get { return sessionCreationTime; }
            set { sessionCreationTime = value; }
        }

        private bool doBackup;

        public bool DoBakup
        {
            get { return doBackup; }
            set { doBackup = value; }
        }

        public void Flush()
        {

        }

        public int ResendingQueueSize
        {
            get { return -1; }
            set { }
        }
    }
}
