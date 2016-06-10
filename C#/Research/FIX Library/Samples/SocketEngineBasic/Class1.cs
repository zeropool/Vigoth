using System;
using System.Net;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

using FIX4NET;
using FIX4NET.FIX;
using FIX4NET.Net;
using FIX4NET.Utils;
using FIX4NET.MessageCache.FlatFile;
//using FIX_4_0 = FIX4NET.FIX.FIX_4_0;
//using FIX_4_2 = FIX4NET.FIX.FIX_4_2;
//using FIX_4_4 = FIX4NET.FIX.FIX_4_4;

[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace SocketEngineBasic
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private static IMessageFactory _factory;
        private static IEngine _engine;

        private static string _idPrefix = DateTime.Now.ToString("yyyyMMddHHmmss");
        private static int _idNext;
        private static object _idLock = new object();
        private static string _idLast;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			log.Debug("--> Main");

			try 
			{
				SocketLogonArgs logonArgs = new SocketLogonArgs();
                logonArgs.IPAddress = IPAddress.Parse(ConfigurationManager.AppSettings["Host"]);
				logonArgs.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);

                //set additional logon tags
                FIX4NET.FieldCollection fieldsLogon = (FIX4NET.FieldCollection)ConfigurationManager.GetSection("fixLogonFieldsSection");
                if (fieldsLogon != null)
                    foreach (IField field in fieldsLogon)
                        logonArgs.AddField(field);

                MessageFactoryFIX factory = new MessageFactoryFIX(ConfigurationManager.AppSettings["BeginString"]);
				//IMessageFactory factory = new FIX_4_4.MessageFactoryFIX();
				//IMessageFactory factory = new FIX_4_2.MessageFactoryFIX();
				_factory = factory;

                //additional tags for factory to append on every message
                FIX4NET.FieldCollection fields = (FIX4NET.FieldCollection)ConfigurationManager.GetSection("fixMessageFieldsSection");
                if (fields != null)
                    foreach (FIX4NET.IField field in fields)
                        factory.AddField(field);
                //create instance of FIX engine
				SocketEngine engine = new SocketEngine();

                //set message timeout
                string messageTimeout = ConfigurationManager.AppSettings["MessageTimeout"];
                if (!string.IsNullOrEmpty(messageTimeout))
                    engine.MessageTimeout = int.Parse(messageTimeout);
                
                //initialize FIX engine
                _engine = engine;
                _engine.MessageCacheFactory = new MessageCacheFlatFileFactory();
                _engine.MessageFactory = factory;
				_engine.Initialize(
                    ConfigurationManager.AppSettings["SenderCompID"], ConfigurationManager.AppSettings["SenderSubID"],
                    ConfigurationManager.AppSettings["TargetCompID"], ConfigurationManager.AppSettings["TargetSubID"]);
				_engine.AllowOfflineSend = true;

				_engine.Received += new MessageEventHandler(engine_Received);
				_engine.Sent += new MessageEventHandler(engine_Sent);

                //reset MsgSeqNum(Out)
                string resetMsgSeqNumOut = ConfigurationManager.AppSettings["ResetMsgSeqNumOut"];
                if (!string.IsNullOrEmpty(resetMsgSeqNumOut))
                    _engine.ResetMsgSeqNumOut(int.Parse(resetMsgSeqNumOut));

                //reset MsgSeqNum(In)
                string resetMsgSeqNumIn = ConfigurationManager.AppSettings["ResetMsgSeqNumIn"];
                if (!string.IsNullOrEmpty(resetMsgSeqNumIn))
                    _engine.ResetMsgSeqNumIn(int.Parse(resetMsgSeqNumIn));
				
				_engine.Logon(logonArgs);
				if (!_engine.IsConnected)
					throw new Exception("Logong failed");

                Console.WriteLine("press <Enter> to continue...");
                Console.ReadLine();

                string sendMessageFromFile = ConfigurationManager.AppSettings["SendMessagesFromFile"];
                if (!string.IsNullOrEmpty(sendMessageFromFile))
                    SendMessagesFromFile(sendMessageFromFile);

				Console.WriteLine("press <Enter> to exit...");
				Console.ReadLine();

				_engine.Logout("USER LOGOUT REQUESTED");
				_engine.Dispose();

			}
			catch(Exception ex) 
			{
				log.Error("Error running FIX test", ex);
			}

			log.Debug("<-- Main");
		}

		private static string GetNextID() 
		{
			int id;
			lock(_idLock) 
			{
				id = _idNext;
				_idNext += 1;
			}

            _idLast = _idPrefix + id.ToString("0000");
            return _idLast;
		}

        private static string GetLastID()
        {
            return _idLast;
        }

		private static void engine_Received(IEngine _engine, IMessage message)
		{
			if (log.IsDebugEnabled)
				log.DebugFormat("engine_Sent - MsgType={0}", message.MsgType);
		}

		private static void engine_Sent(IEngine _engine, IMessage message)
		{
			if (log.IsDebugEnabled)
				log.DebugFormat("engine_Sent - MsgType={0}", message.MsgType);
		}


        private static void SendMessagesFromFile(string fileName)
        {
            StreamReader fileReader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), Encoding.UTF8);

            while (!fileReader.EndOfStream)
            {
                Console.WriteLine("press <Enter> to send next message");
                Console.ReadLine();

                IMessage message = null;

                string line = fileReader.ReadLine();
                FieldReaderFIX fieldReader = new FieldReaderFIX(line);
                IField field;

                while ((field = fieldReader.GetNextField()) != null)
                {
                    if (message == null && field.Tag == 35)
                    {
                        message = _factory.CreateInstance(field.Value);
                        field = null;
                    }
                    else if (message == null)
                        throw new Exception("MsgType(35) missing");
                    else if (string.Equals(field.Value, "{$ID}"))
                        field.Value = GetNextID();
                    else if (string.Equals(field.Value, "{$ID.LAST}"))
                        field.Value = GetLastID();
                    else if (string.Equals(field.Value, "{$UTCTimestamp}"))
                        field.Value = MessageFactoryFIX.ToFIXUTCTimestamp(DateTime.Now.ToUniversalTime());

                    if (field != null)
                        message.Fields.Add(field);
                }

                _engine.Send(message);
            }
        }
	}
}
