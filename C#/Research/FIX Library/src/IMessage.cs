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

namespace FIX4NET
{
	/// <summary>
	/// Interface for a message.
	/// </summary>
    public interface IMessage
    {
        string MessageRaw { get;set; }
        MessageDirection Direction { get;set; }

        string BeginString { get;set; }
        int BodyLength { get;set; }
        string MsgType { get;set; }
        string SenderCompID { get;set; }
        string TargetCompID { get;set; }
        string OnBehalfOfCompID { get;set; }
        string DeliverToCompID { get;set; }
        int MsgSeqNum { get;set; }
        string SenderSubID { get;set; }
        string TargetSubID { get;set; }
        string OnBehalfOfSubID { get;set; }
        string DeliverToSubID { get;set; }
        bool PossDupFlag { get;set; }
        bool PossResend { get;set; }
        DateTime SendingTime { get;set; }
        DateTime OrigSendingTime { get;set; }
        byte CheckSum { get;set; }

        FieldCollection Fields { get; }

        /// <summary>
        /// Get/Set value using the tag #.
        /// </summary>
        object this[int iTag] { get; set; }

        void CopyTo(IMessage to);
        IMessage Clone();
    }
}
