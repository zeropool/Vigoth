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
using System.Collections;
using System.IO;
using System.Text;

using FIX4NET;
using FIX4NET.Utils;

//TODO:  Support reseting MsgSeqNum In/Out to a lower #
//TODO:  Recovery from Log file does not calculate correct message length when multi-byte characters are in message.

namespace FIX4NET.MessageCache.FlatFile
{
	/// <summary>
	/// Summary description for MessageCacheDisk.
	/// </summary>
	public class MessageCacheFlatFile : IMessageCache
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private const char DELIMITER = ' ';
		private const string PREFIX_IN = "I ";
		private const string PREFIX_OUT = "O ";
		private const string PREFIX_NONE = "? ";

		private ArrayList _alMessagesIn = ArrayList.Synchronized(new ArrayList());
		private ArrayList _alMessagesOut = ArrayList.Synchronized(new ArrayList());
		private ArrayList _alMessages = ArrayList.Synchronized(new ArrayList());

        private string _sPath;
        private IFileDateFormat _fileDateFormat = new FileDateFormat();
		private string _sFileIndex;
		private string _sFileLog;

		private BinaryWriter _bwIndex;
		private StreamWriter _swLog;
		private FileStream _sLog;
		private Encoding _encoding = Encoding.UTF8;
		private int _iMsgIndexReader = 0;

		private IMessageFactory _messageFactory;

		private object _lockClose = new object();
		private object _lockWrite = new object();
		private object _lockRead = new object();

		private struct MessageIndex
		{
			public MessageDirection Direction;
			public int MsgSeqNo;
			public int Length;

			public MessageIndex(MessageDirection direction, int iMsgSeqNo, int iLength)
			{
				Direction = direction;
				MsgSeqNo = iMsgSeqNo;
				Length = iLength;
			}
		}

		public void Dispose()
		{
            try
            {
                Close();
            }
            catch { }
            
            _alMessagesIn = null;
			_alMessagesOut = null;
			_alMessages = null;
		}

		/// <summary>
		/// Gets a message by the index position.
		/// </summary>
		public IMessage this[int iMsgIndex]
		{
			get
			{
				IMessage message = MessageRead(iMsgIndex);
				if(message.MsgSeqNum != -1)
					return message;
				else
					return null;
			}
		}

        /// <summary>
        /// Get/Set the path where data/index files will be stored.
        /// </summary>
        public string Path
        {
            get { return _sPath; }
            set { _sPath = value; }
        }

        /// <summary>
        /// Format class used to generate the date trailer on the end of a file name.
        /// </summary>
        public IFileDateFormat FileDateFormat
        {
            get { return _fileDateFormat; }
            set { _fileDateFormat = value; }
        }

		/// <summary>
		/// Get a message by the MessageDirection and MsgSeqNum.
		/// </summary>
		public IMessage this[MessageDirection direction, int iMsgSeqNum]
		{
			get
			{
				int iMsgIndex = -1;

				if (direction == MessageDirection.In)
					iMsgIndex = GetMessageIndexIn(iMsgSeqNum);
				else if (direction == MessageDirection.Out)
					iMsgIndex = GetMessageIndexOut(iMsgSeqNum);

				if (iMsgIndex >= 0)
					return this[iMsgIndex];
				else
					return null;
			}
		}

		/// <summary>
		/// Add a message.
		/// </summary>
		public void AddMessage(IMessage msg)
		{
			if (msg == null)
			{
				if (log.IsErrorEnabled)
					log.Error("Add - IMessage is null");
				throw new Exception("IMessage is null");
			}

			int iMsgSeqNum = GetMsgSeqNum(msg.Direction);
			if (msg.MsgSeqNum <= iMsgSeqNum)
			{
				if (log.IsErrorEnabled)
					log.ErrorFormat("Add - Trying to cache a invalid MsgSeqNo / Direction={0} MsgSeqNum(Message)={1} MsgSeqNum(Cache)={2}",
						msg.Direction, msg.MsgSeqNum, iMsgSeqNum);
				throw new Exception("Trying to cache a invalid MsgSeqNo");
			}

			MessageWrite(msg);
		}

		/// <summary>
		/// Current MsgIndex for messages.  This updates in real-time as messages are added.
		/// </summary>
		public int MsgIndex
		{
			get { return _alMessages.Count; }
		}

		/// <summary>
		/// Current MsgSeqNum for incoming messages.  This updates in real-time as messages are added.
		/// </summary>
		public int MsgSeqNumOut
		{
			get { return _alMessagesOut.Count; }
		}
		/// <summary>
		/// Current MsgSeqNum for outgoing messages.  This updates in real-time as messages are added.
		/// </summary>
		public int MsgSeqNumIn
		{
			get { return _alMessagesIn.Count; }
		}

		/// <summary>
		/// Get current MsgSeqNum by MessageDirection.  This updates in real-time as messages are added.
		/// </summary>
		public int GetMsgSeqNum(MessageDirection direction)
		{
			if (direction == MessageDirection.Out)
				return _alMessagesOut.Count;
			else if (direction == MessageDirection.In)
				return _alMessagesIn.Count;
			else
				throw new Exception("MessageDirection is invalid");
		}

		/// <summary>
		/// Initialize the cache.
		/// </summary>
		public void Initialize(IMessageFactory messageFactory)
		{
			if (messageFactory == null)
				throw new Exception("Message Factory can not be null");
			_messageFactory = messageFactory;
		}

		/// <summary>
		/// Opens the cache for read/write access.
		/// </summary>
		public void Open(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID)
		{
			Open(sSenderCompID, sSenderSubID, sTargetCompID, sTargetSubID, DateTime.Today, true);
		}

		/// <summary>
		/// Opens the cache for read/write access of a specific date.
		/// </summary>
		public void Open(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID, DateTime dtOpen)
		{
			Open(sSenderCompID, sSenderSubID, sTargetCompID, sTargetSubID, dtOpen, true);
		}

		/// <summary>
		/// Opens the cache for read or read/write access.
		/// </summary>
		public void Open(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID, bool bWrite)
		{
			Open(sSenderCompID, sSenderSubID, sTargetCompID, sTargetSubID, DateTime.Today, bWrite);
		}

		/// <summary>
		/// Opens the cache for read or read/write access of a specific date.
		/// </summary>
		public void Open(string sSenderCompID, string sSenderSubID, string sTargetCompID, string sTargetSubID, DateTime dtOpen, bool bWrite)
		{
			if (_sLog != null || _swLog != null || _bwIndex != null)
				throw new Exception("Message cache has already been inialized");

			try
			{
                string sFile = sSenderCompID + "_" + sSenderSubID + "_" + sTargetCompID + "_" + sTargetSubID;
                if (_fileDateFormat != null)
                    sFile = sFile + "_" + _fileDateFormat.ToString(dtOpen);
                if (log.IsDebugEnabled) log.DebugFormat("Open - File name base is {0}", sFile);

                if (_sPath != null && _sPath.Length > 0)
                {
                    if (!Directory.Exists(_sPath))
                    {
                        if (log.IsDebugEnabled) log.DebugFormat("Open - Creating directory because path does not exist / Path={0}", _sPath);
                        Directory.CreateDirectory(_sPath);
                    }
                    sFile = System.IO.Path.Combine(_sPath, sFile);
                }

				_sFileLog = sFile + ".LOG";
				_sFileIndex = sFile + ".LDX";

				bool bLogExists = File.Exists(sFile + ".LOG");
				bool bIndexExists = File.Exists(sFile + ".LDX");

                if (log.IsDebugEnabled) 
                    log.DebugFormat("Open - FileLog={0} FileIndex={1} LogExist={2} IndexExist={3}", 
                        _sFileLog, _sFileIndex, bLogExists, bIndexExists);

				if (bWrite)
				{
					_bwIndex = new BinaryWriter(new FileStream(_sFileIndex, FileMode.Append, FileAccess.Write, FileShare.Read));
					_swLog = new StreamWriter(new FileStream(_sFileLog, FileMode.Append, FileAccess.Write, FileShare.Read));
				}
				else if (!bIndexExists)
				{
					_bwIndex = new BinaryWriter(new FileStream(_sFileIndex, FileMode.Append, FileAccess.Write, FileShare.Read));
				}

				_sLog = new FileStream(_sFileLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				_iMsgIndexReader = 0;

				if (bIndexExists)
					RecoverIndex(_sFileIndex);
				else if (bLogExists)
					RecoverLog(_sFileLog);

				UpdateMsgSeqNo();

				if (log.IsDebugEnabled)
					log.DebugFormat("Open - Recovery complete / MsgSeqNumIn={0:N0} MsgSeqNumOut={1:N0}", _alMessagesIn.Count, _alMessagesOut.Count);
			}
			catch (Exception ex)
			{
				log.Error("Error opening FIX files", ex);
				Close();
				throw new Exception("Failed to open FIX log file", ex);
			}
		}

        public void Close()
        {
            lock (_lockClose)
            {
                if (_alMessagesIn != null)
                    _alMessagesIn.Clear();

                if (_alMessagesOut != null)
                    _alMessagesOut.Clear();

                if (_alMessages != null)
                    _alMessages.Clear();

                if (_bwIndex != null)
                    _bwIndex.Close();
                _bwIndex = null;

                if (_swLog != null)
                    _swLog.Close();
                _swLog = null;

                if (_sLog != null)
                    _sLog.Close();
                _sLog = null;
            }
        }

		private int GetMessageIndex(ArrayList alIndex, int iMsgSeqNum)
		{
			Object o = alIndex[iMsgSeqNum - 1];
			if (o == null)
				return -1;
			else
				return (int)o;
		}

		private int GetMessageIndexIn(int iMsgSeqNumIn)
		{
			return GetMessageIndex(_alMessagesIn, iMsgSeqNumIn);
		}

		private int GetMessageIndexOut(int iMsgSeqNumOut)
		{
			return GetMessageIndex(_alMessagesOut, iMsgSeqNumOut);
		}

		private ArrayList GetMessageDirectionArrayList(MessageDirection direction)
		{
			if (direction == MessageDirection.In)
				return _alMessagesIn;
			else if (direction == MessageDirection.Out)
				return _alMessagesOut;
			else
				return null;
		}

		private void AddDirectionIndex(MessageDirection direction, int iMsgSeqNum, int iMsgIndex)
		{
			ArrayList al = GetMessageDirectionArrayList(direction);
			if (al != null)
				AddDirectionIndex(al, iMsgSeqNum, iMsgIndex);
		}

		private void AddDirectionIndex(ArrayList al, int iMsgSeqNum, int iMsgIndex)
		{
			//If the MsgSeqNo causes gap then insert rows until it matches
			while (iMsgSeqNum > al.Count + 1)
				al.Add(null);

			al.Add(iMsgIndex);
		}

		private char MessageDirectionToChar(MessageDirection direction)
		{
			if (direction == MessageDirection.In)
				return 'I';
			else if (direction == MessageDirection.Out)
				return 'O';
			else
				return '?';
		}

		private MessageDirection MessageDirectionFromChar(char cDirection)
		{
			if (cDirection == 'I')
				return MessageDirection.In;
			else if (cDirection == 'O')
				return MessageDirection.Out;
			else
				return MessageDirection.None;
		}

		private string MessageDirectionToPrefix(MessageDirection direction)
		{
			if (direction == MessageDirection.In)
				return PREFIX_IN;
			else if (direction == MessageDirection.Out)
				return PREFIX_OUT;
			else
				return PREFIX_NONE;
		}

		private void RecoverIndex(string sFile)
		{
			BinaryReader reader = new BinaryReader(new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
			try
			{
				MessageDirection direction;
				int iMsgSeqNo, iLength;
				int iMsgIndex;

				IMessageSequenceReset reset;
				ArrayList alIndex;

				while (true)
				{
					direction = (MessageDirection)reader.ReadByte();
					iMsgSeqNo = reader.ReadInt32();
					iLength = reader.ReadInt32();

					iMsgIndex = _alMessages.Add(new MessageIndex(direction, iMsgSeqNo, iLength));

					if (iMsgSeqNo != -1)
					{
						AddDirectionIndex(direction, iMsgSeqNo, iMsgIndex);
					}
					else
					{
						reset = (IMessageSequenceReset)MessageRead(iMsgIndex);
						alIndex = GetMessageDirectionArrayList(direction);
						ProcessSystemResetMsgSeqNum(reset.NewSeqNo, alIndex);
					}
				}
			}
			catch (EndOfStreamException)
			{
				//Normal error when EOF is reached.
			}
			catch (Exception ex)
			{
				log.Error("Error recovering index file", ex);
				throw new Exception("Failed to recover FIX log file", ex);
			}
			finally
			{
				reader.Close();
			}
		}

		private void RecoverLog(string sFile)
		{
			const int BUFFER_COUNT = 4096;

			StreamReader srLog = new StreamReader(new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), _encoding);
            try
            {
                StringBuilder sb = new StringBuilder();
                char[] cBuffer = new char[BUFFER_COUNT];
                int iCharactersRead = BUFFER_COUNT;
                string sFindPrefix = _messageFactory.GetSearchStringMessageEndPrefix();
                string sFindSuffix = _messageFactory.GetSearchStringMessageEndSuffix() + Environment.NewLine;
                if (log.IsDebugEnabled) log.DebugFormat("RecoverLog - FindPrefix={0} FindSuffix={1}", sFindPrefix, sFindSuffix);
                int iFindStart = 0;
                int iMessageEnd;

                string sMessage;
                MessageDirection direction;
                IMessage message;
                int iIndex;
                int recordLength;
                bool parseNext;

                IMessageSequenceReset reset;
                ArrayList alIndex;

                while (iCharactersRead != 0)
                {
                    iCharactersRead = srLog.Read(cBuffer, 0, BUFFER_COUNT);
                    sb.Append(cBuffer, 0, iCharactersRead);
                    if (log.IsDebugEnabled)
                        log.DebugFormat("RecoverLog - CharactersRead={0} StringBuilder.Length={1}", iCharactersRead, sb.Length);

                    do
                    {
                        parseNext = false;

                        iMessageEnd = StringBuilderUtils.Find(sb, sFindPrefix, iFindStart);
                        if (iMessageEnd > 0)
                        {
                            iFindStart = iMessageEnd;
                            iMessageEnd = StringBuilderUtils.Find(sb, sFindSuffix, iMessageEnd + sFindPrefix.Length);
                            if (iMessageEnd > 0)
                            {
                                iFindStart = 0;
                                direction = MessageDirectionFromChar(sb[0]);
                                sMessage = sb.ToString(2, iMessageEnd - 1);
                                recordLength = sMessage.Length + 4;

                                //parse message to object
                                if (log.IsDebugEnabled) log.DebugFormat("RecoverLog - Parse message / Message={0}", sMessage);
                                message = _messageFactory.Parse(sMessage);

                                //write to index file
                                if (log.IsDebugEnabled)
                                    log.DebugFormat("RecoverLog - Write to index file / Direction={0} MsgSeqNum={1} Length={2}",
                                        direction, message.MsgSeqNum, recordLength);
                                _bwIndex.Write((byte)direction);
                                _bwIndex.Write(message.MsgSeqNum);
                                _bwIndex.Write(recordLength);
                                _bwIndex.Flush();

                                //add to memory index
                                iIndex = _alMessages.Add(new MessageIndex(direction, message.MsgSeqNum, recordLength));

                                if (iIndex != -1)
                                {
                                    AddDirectionIndex(direction, message.MsgSeqNum, iIndex);
                                }
                                else
                                {
                                    reset = (IMessageSequenceReset)message;
                                    alIndex = GetMessageDirectionArrayList(direction);
                                    ProcessSystemResetMsgSeqNum(reset.NewSeqNo, alIndex);
                                }

                                //remove from stream
                                sb.Remove(0, recordLength);

                                //check if room for another message in buffer
                                if (sb.Length > sFile.Length)
                                    parseNext = true;
                            }
                        }
                        else
                        {
                            iFindStart = sb.Length - sFindPrefix.Length;
                            if (iFindStart < 0) iFindStart = 0;
                        }

                    } while (parseNext);
                }
            }
            finally
            {
                srLog.Close();
            }
		}

		private IMessage MessageRead(int iMsgIndexFind)
		{
			if (iMsgIndexFind < 0 || iMsgIndexFind >= _alMessages.Count)
				return null;

			MessageIndex messageIndex = (MessageIndex)_alMessages[iMsgIndexFind];

			byte[] tBuffer;
			int iStep;
			int iMsgIndex, iMsgIndexEnd;
			long lOffset = 0;

			lock (_lockRead)
			{
				if (iMsgIndexFind > _iMsgIndexReader)
				{
					iStep = 1;
					iMsgIndex = _iMsgIndexReader;
					iMsgIndexEnd = iMsgIndexFind;
				}
				else
				{
					iStep = -1;
					iMsgIndex = iMsgIndexFind;
					iMsgIndexEnd = _iMsgIndexReader;
				}

				while (iMsgIndex != iMsgIndexEnd)
				{
					lOffset += ((MessageIndex)_alMessages[iMsgIndex]).Length;
					iMsgIndex += 1;
				}
				lOffset *= iStep;

				if (log.IsDebugEnabled)
					log.DebugFormat("MessageRead - Before Seek / Position={0} Offset={1}", _sLog.Position, lOffset);
				_sLog.Seek(lOffset, SeekOrigin.Current);
				if (log.IsDebugEnabled)
					log.DebugFormat("MessageRead - After Seek / Position={0}", _sLog.Position);

				tBuffer = new byte[messageIndex.Length];
				_sLog.Read(tBuffer, 0, messageIndex.Length);

				_iMsgIndexReader = iMsgIndexFind + 1;
			}

			string sMessage = _encoding.GetString(tBuffer, 2, tBuffer.Length - 4);
			if (log.IsDebugEnabled)
				log.DebugFormat("MessageRead - Read message from disk / Message={0}", sMessage);
			IMessage message = _messageFactory.Parse(sMessage);
			message.Direction = messageIndex.Direction;

			return message;
		}

		private int MessageWrite(IMessage msg)
		{
			int iMsgSeqNum = msg.MsgSeqNum;
			MessageDirection direction = msg.Direction;
			ArrayList alIndex = GetMessageDirectionArrayList(direction);

			if (log.IsDebugEnabled)
				log.DebugFormat("MessageWrite - Writing message to disk / Direction={0} MsgSeqNum={1} Message={2}",
					direction, iMsgSeqNum, msg.MessageRaw);

			int iMsgIndex, iLength;
			long lPositionStart;
			string sPrefix = MessageDirectionToPrefix(direction);

			lock (_lockWrite)
			{
				lPositionStart = _swLog.BaseStream.Position;
				_swLog.Write(sPrefix);
				_swLog.WriteLine(msg.MessageRaw);
				_swLog.Flush();
				iLength = (int)(_swLog.BaseStream.Position - lPositionStart);

				_bwIndex.Write((byte)direction);
				_bwIndex.Write(iMsgSeqNum);
				_bwIndex.Write(iLength);
				_bwIndex.Flush();

				iMsgIndex = _alMessages.Add(new MessageIndex(direction, iMsgSeqNum, iLength));

				if (iMsgSeqNum != -1)
				{
					AddDirectionIndex(alIndex, iMsgSeqNum, iMsgIndex);

					if (_messageFactory.IsSequenceResetMessage(msg))
					{
						int iNewSeqNo = ((IMessageSequenceReset)msg).NewSeqNo - 1;
						while (iNewSeqNo > alIndex.Count)
							alIndex.Add(null);
					}
				}
			}

			if (log.IsDebugEnabled)
				log.DebugFormat("MessageWrite - Index data / Direction={0} MsgSeqNum={1} Length={2}",
					direction, iMsgSeqNum, iLength);

			return iMsgIndex;
		}

		public string IndexFile
		{
			get { return _sFileIndex; }
		}

		public string LogFile
		{
			get { return _sFileLog; }
		}

		private void UpdateMsgSeqNo()
		{
			UpdateMsgSeqNo(MessageDirection.In);
			UpdateMsgSeqNo(MessageDirection.Out);
		}

		private void UpdateMsgSeqNo(MessageDirection direction)
		{
			ArrayList alIndex = GetMessageDirectionArrayList(direction);
			if (alIndex.Count > 0)
			{
				int iMsgIndex = GetMessageIndex(alIndex, alIndex.Count);
				IMessage message = MessageRead(iMsgIndex);
				if (message != null && _messageFactory.IsSequenceResetMessage(message))
				{
					int iNewSeqNo = ((IMessageSequenceReset)message).NewSeqNo - 1;
					while (iNewSeqNo > alIndex.Count)
						alIndex.Add(null);
				}
			}
		}

		private void ProcessSystemResetMsgSeqNum(int iMsgSeqNum, ArrayList alIndex)
		{
			int iNewSeqNo = iMsgSeqNum - 1;

			if (iNewSeqNo > alIndex.Count)
			{
				while (iNewSeqNo > alIndex.Count)
					alIndex.Add(null);
			}
			else
			{
				int iMsgIndex;
				MessageIndex messageIndex;
				while (iNewSeqNo < alIndex.Count)
				{
					iMsgIndex = GetMessageIndex(alIndex, alIndex.Count - 1);
					alIndex.RemoveAt(alIndex.Count - 1);
					if (iMsgIndex >= 0)
					{
						messageIndex = (MessageIndex)_alMessages[iMsgIndex];
						messageIndex.MsgSeqNo = -1;
					}
				}
			}
		}

		private void ResetMsgSeqNum(MessageDirection direction, int iMsgSeqNum, ArrayList alIndex)
		{
			if (iMsgSeqNum < 1)
				throw new Exception("MsgSeqNum must be greater then or equal to 1");

			if (iMsgSeqNum == alIndex.Count + 1)
				throw new Exception("MsgSeqNum is already set to that number");

			IMessageSequenceReset reset = _messageFactory.CreateInstanceSequenceReset();
			reset.Direction = direction;
			reset.SenderCompID = "RESET";
			reset.TargetCompID = "RESET";
			reset.MsgSeqNum = -1;
			reset.GapFillFlag = false;
			reset.NewSeqNo = iMsgSeqNum;
			_messageFactory.Build(reset);

			MessageWrite(reset);

			ProcessSystemResetMsgSeqNum(reset.NewSeqNo, alIndex);
		}

		public void ResetMsgSeqNumIn(int iMsgSeqNum)
		{
			ResetMsgSeqNum(MessageDirection.In, iMsgSeqNum, _alMessagesIn);
		}

		public void ResetMsgSeqNumOut(int iMsgSeqNum)
		{
			ResetMsgSeqNum(MessageDirection.Out, iMsgSeqNum, _alMessagesOut);
		}
	}
}
