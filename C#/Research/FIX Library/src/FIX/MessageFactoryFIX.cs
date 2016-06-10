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
using System.Text;

using FIX4NET;
using FIX4NET.Utils;

namespace FIX4NET.FIX
{
	/// <summary>
	/// Summary description for MessageFactoryFIX.
	/// </summary>
	public class MessageFactoryFIX : IMessageFactory
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// Delimiter between tag and value in a FIX message.
		/// </summary>
		public const char TAG_DELIM = '=';
		/// <summary>
		/// Delimiter between tags in a FIX message.
		/// </summary>
		public const char FIELD_DELIM = (char)1;

		private string _beginString;
		private string _sSearchStringMessageBegin;
		private string _sSearchStringMessageEndPrefix = 
			FIELD_DELIM + Message.TAG_CheckSum.ToString() + TAG_DELIM;
		private string _sSearchStringMessageEndSuffix = new string(FIELD_DELIM, 1);

        private FieldCollection _fields = new FieldCollection();

		/// <summary>
		/// Base constructor to initialize a MessageFactoryFIX.
		/// </summary>
		public MessageFactoryFIX(string beginString)
		{
			SetBeginString(beginString);
		}

		public MessageFactoryFIX() { }

		public virtual void SetConfig(string name, object value)
		{
			switch (name)
			{
				case "BeginString":
					SetBeginString((string)value);
					break;
				default:
					log.WarnFormat("SetConfig - Unkown configuration name / Name={0} Value={1}", name, value);
					throw new Exception("Unkown configuration name");
			}
		}

		public void SetBeginString(string value)
		{
			_beginString = value;
			_sSearchStringMessageBegin = "8=" + value + FIELD_DELIM;
		}

		#region IMessageFactory Members

		/// <summary>
		/// Checks if the string is a relevent FIX message with the proper BeginString.
		/// </summary>
		public virtual bool IsRelatedMessage(string sMessage)
		{
			return sMessage.StartsWith(_sSearchStringMessageBegin);
		}

        public void AddField(IField field)
        {
            _fields.Add(field);
        }

        public FieldCollection GetFields()
        {
            return _fields;
        }

		/// <summary>
		/// Creates an instance of a specified message type.
		/// </summary>
		public virtual IMessage CreateInstance(string msgType)
		{
			IMessage message;
			switch (msgType)
			{
				case Values.MsgType.Logon:
					message= new Logon();
					break;
				case Values.MsgType.Logout:
					message = new Logout();
					break;
				case Values.MsgType.Heartbeat:
					message = new Heartbeat();
					break;
				case Values.MsgType.TestRequest:
					message = new TestRequest();
					break;
				case Values.MsgType.ResendRequest:
					message = new ResendRequest();
					break;
				case Values.MsgType.SequenceReset:
					message = new SequenceReset();
					break;
				case Values.MsgType.Reject:
					message = new Reject();
					break;
				default:
					message = new Message(msgType);
					break;
			}
			message.BeginString = _beginString;

            foreach (IField field in _fields)
                message.Fields.Add(field);

			return message;
		}

		/// <summary>
		/// Creates an instance of a Logon message.
		/// </summary>
		public IMessageLogon CreateInstanceLogon()
		{
			return (IMessageLogon)CreateInstance(Values.MsgType.Logon);
		}

		/// <summary>
		/// Creates an instance of a Logout message.
		/// </summary>
		public IMessageLogout CreateInstanceLogout()
		{
			return (IMessageLogout)CreateInstance(Values.MsgType.Logout);
		}

		/// <summary>
		/// Creates an instance of a Heartbeat message.
		/// </summary>
		public IMessageHeartbeat CreateInstanceHeartbeat()
		{
			return (IMessageHeartbeat)CreateInstance(Values.MsgType.Heartbeat);
		}

		/// <summary>
		/// Creates an instance of a TestRequest message.
		/// </summary>
		public IMessageTestRequest CreateInstanceTestRequest()
		{
			return (IMessageTestRequest)CreateInstance(Values.MsgType.TestRequest);
		}

		/// <summary>
		/// Creates an instance of a ResendRequest message.
		/// </summary>
		public IMessageResendRequest CreateInstanceResendRequest()
		{
			return (IMessageResendRequest)CreateInstance(Values.MsgType.ResendRequest);
		}

		/// <summary>
		/// Creates an instance of a SequenceReset message.
		/// </summary>
		public IMessageSequenceReset CreateInstanceSequenceReset()
		{
			return (IMessageSequenceReset)CreateInstance(Values.MsgType.SequenceReset);
		}

		/// <summary>
		/// Creates an instance of a Reject message.
		/// </summary>
		public IMessageReject CreateInstanceReject()
		{
			return (IMessageReject)CreateInstance(Values.MsgType.Reject);
		}

		/// <summary>
		/// Creates an instance of a Reject message with a ParseFieldException object.
		/// </summary>
		public virtual IMessageReject CreateInstanceReject(ParseFieldException exParse)
		{
			IMessageReject reject = CreateInstanceReject();
			reject.RefSeqNum = exParse.RefSeqNum;
			reject.Text = exParse.Text;
			return reject;
		}

		/// <summary>
		/// Creates an instance of the ParseFieldException class.
		/// </summary>
		protected virtual ParseFieldException CreateInstanceParseFieldException(
			string sMessage, Exception exInner, IField field, string sMessageRaw)
		{
			ParseFieldException ex = new ParseFieldException(sMessage, exInner);
			ex.RefSeqNum = ParseMsgSeqNum(sMessageRaw);
			ex.Text = string.Format("PARSE ERROR ON TAG {0}", field.Tag);
			return ex;
		}

		/// <summary>
		/// Compares the checksum suplied in the message to a calculated value.  
		/// If any transmission errors occured the checksum could be different. 
		/// </summary>
		public bool ValidateFixChecksum(string sMessage)
		{
			bool bValid = false;

			try
			{
				if (sMessage != null)
				{
					if (sMessage.Length > 8 &&
						sMessage[sMessage.Length - 8] == FIELD_DELIM &&
						sMessage[sMessage.Length - 1] == FIELD_DELIM)
					{

						string sTrailer = sMessage.Substring(sMessage.Length - 7);
						if (sTrailer.StartsWith("10="))
						{
							byte iCheckSumMessage = ParseByte(sTrailer, 3, 3);
							byte iCheckSumCalc = CalcCheckSum(sMessage, 0, sMessage.Length - 7);
							if (iCheckSumMessage == iCheckSumCalc)
							{
								bValid = true;
							}
							else
							{
								if (log.IsDebugEnabled)
									log.DebugFormat("ValidateFixChecksum - Failed because CheckSum does not match / CheckSum(Message)={0} CheckSum(Calc)={1}",
										iCheckSumMessage, iCheckSumCalc);
							}
						}
						else
						{
							if (log.IsDebugEnabled)
								log.Debug("ValidateFixChecksum - Failed because CheckSum tag is not present or in correct location");
						}
					}
					else
					{
						if (log.IsDebugEnabled)
							log.Debug("ValidateFixChecksum - Failed because message does not have proper field delimiters at CheckSum tag");
					}
				}
				else
				{
					if (log.IsDebugEnabled)
						log.Debug("ValidateFixChecksum - Failed because Message is null");
				}
			}
			catch (Exception ex)
			{
				log.Error("ValidateFixChecksum - Exception caught", ex);
			}

			return bValid;
		}

		private static string BODY_TAG = (char)1 + "9=";

		/// <summary>
		/// Compares the BodyLen supplied in the message to a calculated value.  
		/// If transmission errors occured this could fail.
		/// </summary>
		public bool ValidateBodyLength(string sMessage)
		{
			bool bValid = false;

			try
			{
				if (sMessage != null)
				{
					int iStart = sMessage.IndexOf(BODY_TAG);
					if (iStart > 4)
					{
						iStart += BODY_TAG.Length;
						int iEnd = sMessage.IndexOf(FIELD_DELIM, iStart);
						if (iEnd > iStart)
						{
							int iBodyLenMessage = ParseInt(sMessage, iStart, iEnd - iStart);
							int iBodyLenCalc = sMessage.Length - iEnd - 1 - 7;
							if (iBodyLenMessage == iBodyLenCalc)
							{
								bValid = true;
							}
							else
							{
								if (log.IsDebugEnabled)
									log.DebugFormat("ValidateBodyLength - Failed because body lenght does not match / BodyLen(Message)={0} BodyLen{Calc)={1}",
										iBodyLenMessage, iBodyLenCalc);
							}
						}
						else
						{
							if (log.IsDebugEnabled)
								log.Debug("ValidateBodyLength - Failed because could not find end of body length tag");
						}
					}
					else
					{
						if (log.IsDebugEnabled)
							log.Debug("ValidateBodyLength - Failed because could not find body length tag");
					}
				}
				else
				{
					if (log.IsDebugEnabled)
						log.Debug("ValidateBodyLength - Failed because Message is null");
				}

			}
			catch (Exception ex)
			{
				log.Error("ValidateBodyLength - Exception caught", ex);
			}

			return bValid;
		}

		/// <summary>
		/// Checks if the message supplied is a ResendRequest message.
		/// </summary>
		public bool IsResendRequestMessage(IMessage message)
		{
			return string.Equals(Values.MsgType.ResendRequest,message.MsgType);
		}

		/// <summary>
		/// Checks if the message supplied is a Logout message.
		/// </summary>
		public bool IsLogoutMessage(IMessage message)
		{
			return string.Equals(Values.MsgType.Logout , message.MsgType);
		}

		/// <summary>
		/// Checks if the message supplied is a SequenceReset message.
		/// </summary>
		public bool IsSequenceResetMessage(IMessage message)
		{
			return string.Equals(Values.MsgType.SequenceReset , message.MsgType);
		}

		/// <summary>
		/// Checks if the message supplied is a Logon message.
		/// </summary>
		public bool IsLogonMessage(IMessage message)
		{
			return string.Equals(Values.MsgType.Logon , message.MsgType);
		}

		/// <summary>
		/// Checks if the message supplied is a TestRequest message.
		/// </summary>
		public bool IsTestRequestMessage(IMessage message)
		{
			return string.Equals(Values.MsgType.TestRequest , message.MsgType);
		}

		/// <summary>
		/// Checks if the message supplied is a administrative message.  
		/// Administrative messages don't get re-trasmitted when a ResendRequest is received.
		/// </summary>
		public virtual bool IsAdminitrativeMessage(IMessage message)
		{
			string msgType = message.MsgType;
			switch (msgType)
			{
				case Values.MsgType.Logon:
					return true;
				case Values.MsgType.Logout:
					return true;
				case Values.MsgType.Heartbeat:
					return true;
				case Values.MsgType.TestRequest:
					return true;
				case Values.MsgType.ResendRequest:
					return true;
				case Values.MsgType.SequenceReset:
					return true;
				case Values.MsgType.Reject:
					return true;
				default:
					return false;
			}
		}

        protected virtual void BuildHeader(MessageHelper helper, StringBuilder sb)
        {
            helper.BuildHeader(sb);
        }

		/// <summary>
		/// Converts to a string representation of a FIX message for possible tranmission.
		/// </summary>
        public string Build(IMessage message)
        {
            StringBuilder sb = new StringBuilder();

            //Create MessageHelper
            MessageHelper helper = CreateMessageHelper(message);

            //Build Header
            BuildHeader(helper, sb);

            //Build Body
            helper.BuildBody(sb);

            //Other Tags
            if (message.Fields.Count > 0)
                foreach (IField field in message.Fields)
                {
                    sb.Append(field.Tag);
                    sb.Append(TAG_DELIM);
                    sb.Append(field.Value);
                    sb.Append(FIELD_DELIM);
                }

            //Header
            //This information must be INSERTED in the begining of the message.  Since we are inserting it must be done in REVERSE order.
            message.BodyLength = sb.Length;
            helper.InsertHeader(sb);

            //Trailer
            message.CheckSum = CalcCheckSum(sb);
            helper.AppendTrailer(sb);

            message.MessageRaw = sb.ToString();

            return message.MessageRaw;
        }

        public IMessage Parse(string sMessage)
        {
            IMessage message;
            FieldCollection fields = new FieldCollection();
            string sMsgType = null;
            IField field;

            FieldReaderFIX reader = new FieldReaderFIX(sMessage);
            while ((field = reader.GetNextField()) != null)
            {
                fields.Add(field);

                if (field.Tag == Message.TAG_MsgType && field.Value != null && field.Value.Length > 0)
                    sMsgType = field.Value;
            }

            if (sMsgType == null || sMsgType.Length == 0)
            {
                if (log.IsWarnEnabled)
                    log.WarnFormat("Parse - Failed to parse MsgType from message / Message={0}", sMessage);
                throw new Exception("Unable to parse MsgType");
            }
            message = CreateInstance(sMsgType);
            if (message == null)
            {
                if (log.IsWarnEnabled)
                    log.WarnFormat("Parse - Failed to create instance of the message / MsgType={0}", sMsgType);
                throw new Exception("Failed to create instance of the message");
            }

            MessageHelper helper = CreateMessageHelper(message);
            if (helper == null)
            {
                if (log.IsWarnEnabled)
                    log.WarnFormat("Parse - Failed to create instance of MessageHelper / MsgType={0}", sMsgType);
                throw new Exception("Failed to create instance of MessageHelper");
            }

            message.MessageRaw = sMessage;

            //Parse individual fields
            field = null;
            try
            {
                for (int i = 0; i < fields.Count; i++)
                {
                    field = fields[i];
                    helper.ParseField(field);
                }
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Parse - Error parsing {0}", field), ex);
                if (field == null)
                    throw new Exception(string.Format("Error parsing {0}", field), ex);
                else
                {
                    Exception exParse = CreateInstanceParseFieldException(
                        string.Format("Error parsing {0}", field), ex, field, sMessage);
                    throw exParse;
                }
            }

            return message;
        }

		private static string sMsgTypePrefix = FIELD_DELIM + "35=";

		/// <summary>
		/// Parses the MsgType value from a supplied FIX message.
		/// </summary>
		public string ParseMsgType(string sMessage)
		{
			int iStart = sMessage.IndexOf(sMsgTypePrefix);
			if (iStart == -1)
				return null;
			iStart += sMsgSeqNumPrefix.Length;

			int iEnd = sMessage.IndexOf(FIELD_DELIM, iStart);
			if (iEnd == -1)
				return null;

			string sMsgType = sMessage.Substring(iStart, iEnd - iStart); 

			return sMsgType;
		}

		private static string sMsgSeqNumPrefix = FIELD_DELIM + "34=";

		/// <summary>
		/// Parses the MsgSeqNum value from a supplied FIX message.
		/// </summary>
		public int ParseMsgSeqNum(string sMessage)
		{
			int iMsgSeqNum = -1;

			int iStart = sMessage.IndexOf(sMsgSeqNumPrefix);
			if (iStart >= 0)
			{
				iStart += sMsgSeqNumPrefix.Length;
				int iEnd = sMessage.IndexOf(FIELD_DELIM, iStart);
				if (iEnd > iStart)
				{
					try
					{
						iMsgSeqNum = ParseInt(sMessage, iStart, iEnd - iStart);
					}
					catch { }
				}
			}

			return iMsgSeqNum;
		}

		/// <summary>
		/// Returns the string prefix that ends FIX message.  
		/// Useful when you have a stream with many FIX messages and need to find the end of one message.
		/// </summary>
		public string GetSearchStringMessageEndPrefix()
		{
			return _sSearchStringMessageEndPrefix;
		}

		/// <summary>
		/// Returns the string suffix that ends FIX message.  
		/// Useful when you have a stream with many FIX messages and need to find the end of one message.
		/// </summary>
		public string GetSearchStringMessageEndSuffix()
		{
			return _sSearchStringMessageEndSuffix;
		}

		#endregion

		/// <summary>
		/// Calculates the FIX checksum of a message in a StringBuilder.
		/// </summary>
		public static byte CalcCheckSum(StringBuilder sb)
		{
			int iCheckSum = 0;
			int iLen = sb.Length;
			for (int i = 0; i < iLen; i++)
				iCheckSum += sb[i];

			return (byte)(iCheckSum - (int)(iCheckSum / 256) * 256);
		}

		/// <summary>
		/// Calculates the FIX checksum of a message in a String.
		/// </summary>
		public static byte CalcCheckSum(string s, int iIndex, int iLen)
		{
			int iCheckSum = 0;
			int iEnd = iIndex + iLen;
			for (int i = iIndex; i < iEnd; i++)
				iCheckSum += s[i];

			return (byte)(iCheckSum - (int)(iCheckSum / 256) * 256);
		}

		/// <summary>
		/// Parses a int32 from a string.
		/// </summary>
		/// <param name="s">string that gets parsed</param>
		/// <returns>int value of string</returns>
		public static int ParseInt(string s)
		{
			return Utils.Convert.ParseInt(s);
		}

		/// <summary>
		/// Parses a int32 from a string.
		/// </summary>
		public static int ParseInt(string s, int iIndex, int iLen)
		{
            return Utils.Convert.ParseInt(s, iIndex, iLen);
		}

		/// <summary>
		/// Parses a int16 from a string.
		/// </summary>
		public static byte ParseByte(string s, int iIndex, int iLen)
		{
            return Utils.Convert.ParseByte(s, iIndex, iLen);
		}

		/// <summary>
		/// Converts from a DateTime object to the standard FIX UTC Timestamp format.
		/// </summary>
		public static string ToFIXUTCTimestamp(DateTime dt)
		{
			return dt.ToString("yyyyMMdd-HH:mm:ss");
		}

		/// <summary>
		/// Converts from the standard FIX UTC Timestamp to a DateTime object.
		/// </summary>
		public static DateTime FromFIXUTCTimestamp(string s)
		{
			int iYear = ParseInt(s, 0, 4);
			int iMonth = ParseInt(s, 4, 2);
			int iDay = ParseInt(s, 6, 2);
			int iHour = ParseInt(s, 9, 2);
			int iMin = ParseInt(s, 12, 2);
			int iSec = ParseInt(s, 15, 2);
			DateTime dt = new DateTime(iYear, iMonth, iDay, iHour, iMin, iSec);
			return dt;
		}

		/// <summary>
		/// Converts from the standard FIX Month-Year to a DateTime object.
		/// </summary>
		public static DateTime FromFIXMonthYear(string s)
		{
			int iYear = ParseInt(s, 0, 4);
			int iMonth = ParseInt(s, 4, 2);
			return new DateTime(iYear, iMonth, 1);
		}

		/// <summary>
		/// Converts from a DateTime object to the standard FIX Month-Year format.
		/// </summary>
		public static string ToFIXMonthYear(DateTime dt)
		{
			return dt.ToString("yyyyMM");
		}

		private const char FIX_TRUE = 'Y';
		private const char FIX_FALSE = 'N';

		/// <summary>
		/// Converts from a Boolean to the standard FIX format.
		/// </summary>
		public static char ToFIXBoolean(bool b)
		{
			if (b)
				return FIX_TRUE;
			else
				return FIX_FALSE;
		}

		/// <summary>
		/// Converts from the standard FIX to a Boolean.
		/// </summary>
		public static bool FromFIXBoolean(char c)
		{
			return FIX_TRUE == c;
		}

		/// <summary>
		/// Converts from the standard FIX to a Boolean.
		/// </summary>
		public static bool FromFIXBoolean(string s)
		{
			if (s == null || s.Length == 0)
				return false;
			else
				return FIX_TRUE == s[0];
		}

		/// <summary>
		/// Converts from the standard FIX to a LocalMktDate to a DateTime object.
		/// </summary>
		public static DateTime FromFIXLocalMktDate(string s)
		{
			int iYear = ParseInt(s, 0, 4);
			int iMonth = ParseInt(s, 4, 2);
			int iDay = ParseInt(s, 6, 2);
			return new DateTime(iYear, iMonth, iDay);
		}

		/// <summary>
		/// Converts from DateTime object to the standard FIX LocalMktDate format.
		/// </summary>
		public static string ToFIXLocalMktDate(DateTime dt)
		{
			return dt.ToString("yyyyMMdd");
		}

		/// <summary>
		/// Abstract method to creat a MessageHelper instance used in the build/parse process.
		/// </summary>
		protected virtual MessageHelper CreateMessageHelper(IMessage message)
		{
			string msgType = message.MsgType;
			switch (msgType)
			{
				case Values.MsgType.Logon:
					return new MessageHelperLogon(message);
				case Values.MsgType.Logout:
					return new MessageHelperLogout(message);
				case Values.MsgType.Heartbeat:
					return new MessageHelperHeartbeat(message);
				case Values.MsgType.TestRequest:
					return new MessageHelperTestRequest(message);
				case Values.MsgType.ResendRequest:
					return new MessageHelperResendRequest(message);
				case Values.MsgType.SequenceReset:
					return new MessageHelperSequenceReset(message);
				case Values.MsgType.Reject:
					return new MessageHelperReject(message);
				default:
					return new MessageHelper(message);
			}
		}

		/// <summary>
		/// MessageHelper class to build/parse messages.
		/// Understands how to build/parse the standard healder/trailer.
		/// The different messages will inherit and build on top of this.
		/// </summary>
		protected class MessageHelper
		{
			private static string TAG_PREFIX_BeginString = Message.TAG_BeginString.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_BodyLength = Message.TAG_BodyLength.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MsgType = Message.TAG_MsgType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SenderCompID = Message.TAG_SenderCompID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TargetCompID = Message.TAG_TargetCompID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OnBehalfOfCompID = Message.TAG_OnBehalfOfCompID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DeliverToCompID = Message.TAG_DeliverToCompID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecureDataLen = Message.TAG_SecureDataLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecureData = Message.TAG_SecureData.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MsgSeqNum = Message.TAG_MsgSeqNum.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SenderSubID = Message.TAG_SenderSubID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TargetSubID = Message.TAG_TargetSubID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OnBehalfOfSubID = Message.TAG_OnBehalfOfSubID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DeliverToSubID = Message.TAG_DeliverToSubID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PossDupFlag = Message.TAG_PossDupFlag.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PossResend = Message.TAG_PossResend.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SendingTime = Message.TAG_SendingTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrigSendingTime = Message.TAG_OrigSendingTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CheckSum = Message.TAG_CheckSum.ToString() + TAG_DELIM;

			private Message _message;

			/// <summary>
			/// Initialize instance of MessageHelper.
			/// </summary>
			public MessageHelper(IMessage message)
			{
				_message = (Message)message;
			}

            public virtual void BuildHeader(StringBuilder sb)
            {
                sb.Append(TAG_PREFIX_MsgType).Append(_message.MsgType).Append(FIELD_DELIM);
                sb.Append(TAG_PREFIX_SenderCompID).Append(_message.SenderCompID).Append(FIELD_DELIM);
                sb.Append(TAG_PREFIX_TargetCompID).Append(_message.TargetCompID).Append(FIELD_DELIM);
                if (_message.OnBehalfOfCompID != null && _message.OnBehalfOfCompID.Length > 0)
                    sb.Append(TAG_PREFIX_OnBehalfOfCompID).Append(_message.OnBehalfOfCompID).Append(FIELD_DELIM);
                if (_message.DeliverToCompID != null && _message.DeliverToCompID.Length > 0)
                    sb.Append(TAG_PREFIX_DeliverToCompID).Append(_message.DeliverToCompID).Append(FIELD_DELIM);
                sb.Append(TAG_PREFIX_MsgSeqNum).Append(_message.MsgSeqNum).Append(FIELD_DELIM);
                if (_message.SenderSubID != null && _message.SenderSubID.Length > 0)
                    sb.Append(TAG_PREFIX_SenderSubID).Append(_message.SenderSubID).Append(FIELD_DELIM);
                if (_message.TargetSubID != null && _message.TargetSubID.Length > 0)
                    sb.Append(TAG_PREFIX_TargetSubID).Append(_message.TargetSubID).Append(FIELD_DELIM);
                if (_message.OnBehalfOfSubID != null && _message.OnBehalfOfSubID.Length > 0)
                    sb.Append(TAG_PREFIX_OnBehalfOfSubID).Append(_message.OnBehalfOfSubID).Append(FIELD_DELIM);
                if (_message.DeliverToSubID != null && _message.DeliverToSubID.Length > 0)
                    sb.Append(TAG_PREFIX_DeliverToSubID).Append(_message.DeliverToSubID).Append(FIELD_DELIM);
                if (_message.PossDupFlag)
                    sb.Append(TAG_PREFIX_PossDupFlag).Append(ToFIXBoolean(_message.PossDupFlag)).Append(FIELD_DELIM);
                if (_message.PossResend)
                    sb.Append(TAG_PREFIX_PossResend).Append(ToFIXBoolean(_message.PossResend)).Append(FIELD_DELIM);
                sb.Append(TAG_PREFIX_SendingTime).Append(ToFIXUTCTimestamp(_message.SendingTime)).Append(FIELD_DELIM);
                if (_message.OrigSendingTime > DateTime.MinValue)
                    sb.Append(TAG_PREFIX_OrigSendingTime).Append(ToFIXUTCTimestamp(_message.OrigSendingTime)).Append(FIELD_DELIM);
            }

			/// <summary>
			/// Build the standard body tags and values into a StringBuilder.
			/// </summary>
            public virtual void BuildBody(StringBuilder sb)
			{
			}

			/// <summary>
			/// Inserts standard header tags and values into a message.  
			/// The BeginString and BodyLen are only 2 that need to be inserted.
			/// </summary>
			public virtual void InsertHeader(StringBuilder sb)
			{
				//This information must be INSERTED in the begining of the message.  Since we are inserting it must be done in REVERSE order.
				sb.Insert(0, FIELD_DELIM).Insert(0, _message.BodyLength).Insert(0, TAG_PREFIX_BodyLength);
				sb.Insert(0, FIELD_DELIM).Insert(0, _message.BeginString).Insert(0, TAG_PREFIX_BeginString);
			}

			/// <summary>
			/// Appends the standard trailer tags and values into a message.
			/// Only the CheckSum is appended.
			/// </summary>
			public virtual void AppendTrailer(StringBuilder sb)
			{
				sb.Append(TAG_PREFIX_CheckSum).Append(_message.CheckSum.ToString("000")).Append(FIELD_DELIM);
			}

			/// <summary>
			/// Parse a Field object into a FIX message object.
			/// The Field object contains a FIX string that must be converted to the proper data type.
			/// </summary>
			public virtual void ParseField(IField field)
			{
				if (Message.TAG_BeginString == field.Tag)
					_message.BeginString = field.Value;
				else if (Message.TAG_BodyLength == field.Tag)
					_message.BodyLength = int.Parse(field.Value);
				else if (Message.TAG_MsgType == field.Tag)
					_message.MsgType = field.Value;
				else if (Message.TAG_SenderCompID == field.Tag)
					_message.SenderCompID = field.Value;
				else if (Message.TAG_TargetCompID == field.Tag)
					_message.TargetCompID = field.Value;
				else if (Message.TAG_OnBehalfOfCompID == field.Tag)
					_message.OnBehalfOfCompID = field.Value;
				else if (Message.TAG_DeliverToCompID == field.Tag)
					_message.DeliverToCompID = field.Value;
				else if (Message.TAG_MsgSeqNum == field.Tag)
					_message.MsgSeqNum = int.Parse(field.Value);
				else if (Message.TAG_SenderSubID == field.Tag)
					_message.SenderSubID = field.Value;
				else if (Message.TAG_TargetSubID == field.Tag)
					_message.TargetSubID = field.Value;
				else if (Message.TAG_OnBehalfOfSubID == field.Tag)
					_message.OnBehalfOfSubID = field.Value;
				else if (Message.TAG_DeliverToSubID == field.Tag)
					_message.DeliverToSubID = field.Value;
				else if (Message.TAG_PossDupFlag == field.Tag)
					_message.PossDupFlag = FromFIXBoolean(field.Value);
				else if (Message.TAG_PossResend == field.Tag)
					_message.PossResend = FromFIXBoolean(field.Value);
				else if (Message.TAG_SendingTime == field.Tag)
					_message.SendingTime = FromFIXUTCTimestamp(field.Value);
				else if (Message.TAG_OrigSendingTime == field.Tag)
					_message.OrigSendingTime = FromFIXUTCTimestamp(field.Value);
				else if (Message.TAG_CheckSum == field.Tag)
					_message.CheckSum = byte.Parse(field.Value);
				else
					_message.Fields.Add(field);
			}
		}

		protected class MessageHelperLogon : MessageHelper
		{
			private static string TAG_PREFIX_EncryptMethod = Logon.TAG_EncryptMethod.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_HeartBtInt = Logon.TAG_HeartBtInt.ToString() + TAG_DELIM;

			private Logon _message;

			public MessageHelperLogon(IMessage message)
				: base(message)
			{
				_message = (Logon)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				sb.Append(TAG_PREFIX_EncryptMethod).Append(_message.EncryptMethod).Append(FIELD_DELIM);
				sb.Append(TAG_PREFIX_HeartBtInt).Append(_message.HeartBtInt).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Logon.TAG_EncryptMethod == field.Tag)
					_message.EncryptMethod = ParseInt(field.Value);
				else if (Logon.TAG_HeartBtInt == field.Tag)
					_message.HeartBtInt = ParseInt(field.Value);
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperLogout : MessageHelper
		{
			private static string TAG_PREFIX_Text = Logout.TAG_Text.ToString() + TAG_DELIM;

			private Logout _message;

			public MessageHelperLogout(IMessage message)
				: base(message)
			{
				_message = (Logout)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Logout.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperHeartbeat : MessageHelper
		{
			private static string TAG_PREFIX_TestReqID = Heartbeat.TAG_TestReqID.ToString() + TAG_DELIM;

			private Heartbeat _message;

			public MessageHelperHeartbeat(IMessage message)
				: base(message)
			{
				_message = (Heartbeat)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.TestReqID != null)
					sb.Append(TAG_PREFIX_TestReqID).Append(_message.TestReqID).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Heartbeat.TAG_TestReqID == field.Tag)
					_message.TestReqID = field.Value;
				else
					base.ParseField(field);
			}
		}
		protected class MessageHelperTestRequest : MessageHelper
		{
			private static string TAG_PREFIX_TestReqID = TestRequest.TAG_TestReqID.ToString() + TAG_DELIM;

			private TestRequest _message;

			public MessageHelperTestRequest(IMessage message)
				: base(message)
			{
				_message = (TestRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.TestReqID != null)
					sb.Append(TAG_PREFIX_TestReqID).Append(_message.TestReqID).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (TestRequest.TAG_TestReqID == field.Tag)
					_message.TestReqID = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperResendRequest : MessageHelper
		{
			private static string TAG_PREFIX_BeginSeqNo = ResendRequest.TAG_BeginSeqNo.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EndSeqNo = ResendRequest.TAG_EndSeqNo.ToString() + TAG_DELIM;

			private ResendRequest _message;

			public MessageHelperResendRequest(IMessage message)
				: base(message)
			{
				_message = (ResendRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
                if (_message.BeginSeqNo != int.MinValue)
                    sb.Append(TAG_PREFIX_BeginSeqNo).Append(_message.BeginSeqNo).Append(FIELD_DELIM);
                if (_message.EndSeqNo != int.MinValue)
                    sb.Append(TAG_PREFIX_EndSeqNo).Append(_message.EndSeqNo).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (ResendRequest.TAG_BeginSeqNo == field.Tag)
					_message.BeginSeqNo = ParseInt(field.Value);
				else if (ResendRequest.TAG_EndSeqNo == field.Tag)
					_message.EndSeqNo = ParseInt(field.Value);
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperSequenceReset : MessageHelper
		{
			private static string TAG_PREFIX_GapFillFlag = SequenceReset.TAG_GapFillFlag.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NewSeqNo = SequenceReset.TAG_NewSeqNo.ToString() + TAG_DELIM;

			private SequenceReset _message;

			public MessageHelperSequenceReset(IMessage message)
				: base(message)
			{
				_message = (SequenceReset)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.GapFillFlag)
					sb.Append(TAG_PREFIX_GapFillFlag).Append(ToFIXBoolean(_message.GapFillFlag)).Append(FIELD_DELIM);
				sb.Append(TAG_PREFIX_NewSeqNo).Append(_message.NewSeqNo).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (SequenceReset.TAG_GapFillFlag == field.Tag)
					_message.GapFillFlag = FromFIXBoolean(field.Value);
				else if (SequenceReset.TAG_NewSeqNo == field.Tag)
					_message.NewSeqNo = ParseInt(field.Value);
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperReject : MessageHelper
		{
			private static string TAG_PREFIX_RefSeqNum = Reject.TAG_RefSeqNum.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = Reject.TAG_Text.ToString() + TAG_DELIM;

			private Reject _message;

			public MessageHelperReject(IMessage message)
				: base(message)
			{
				_message = (Reject)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				sb.Append(TAG_PREFIX_RefSeqNum).Append(_message.RefSeqNum).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Reject.TAG_RefSeqNum == field.Tag)
					_message.RefSeqNum = ParseInt(field.Value);
				else if (Reject.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}
	}
}
