using System;
using System.Configuration;
using System.IO;

using FIX4NET;
using FIX4NET.FIX;
using FIX4NET.MessageCache.FlatFile;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace MessageCacheFlatFileOpen
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            if (log.IsDebugEnabled) log.Debug("Main");

            Program program = new Program();
            try
            {
                program.ReadConfig();
                program.Run();
            }
            catch (Exception ex)
            {
                log.Error("Main - Exception caught", ex);
                Console.WriteLine("ERROR {0}", ex);
            }

            Console.WriteLine("press <Enter> to exit...");
            Console.ReadLine();
        }

        private string _senderCompID;
        private string _senderSubID;
        private string _targetCompID;
        private string _targetSubID;
        private DateTime _processingDate;

        public string SenderCompID { get { return _senderCompID; } set { _senderCompID = value; } }
        public string SenderSubID { get { return _senderSubID; } set { _senderSubID = value; } }
        public string TargetCompID { get { return _targetCompID; } set { _targetCompID = value; } }
        public string TargetSubID { get { return _targetSubID; } set { _targetSubID = value; } }
        public DateTime ProcessingDate { get { return _processingDate; } set { _processingDate = value; } }

        private void ReadConfig()
        {
            if (log.IsDebugEnabled) log.Debug("ReadConfig");

            SenderCompID = ConfigurationManager.AppSettings["SenderCompID"];
            SenderSubID = ConfigurationManager.AppSettings["SenderSubID"];
            TargetCompID = ConfigurationManager.AppSettings["TargetCompID"];
            TargetSubID = ConfigurationManager.AppSettings["TargetSubID"];
            ProcessingDate = DateTime.Parse(ConfigurationManager.AppSettings["ProcessingDate"]);
        }

        public void Run()
        {
            if (log.IsDebugEnabled) log.Debug("Run");

            MessageCacheFlatFile messageCache = new MessageCacheFlatFile();
            messageCache.Initialize(new MessageFactoryFIX());
            messageCache.Open(SenderCompID, SenderSubID, TargetCompID, TargetSubID, ProcessingDate, false);

            IMessage message = null;

            if (log.IsDebugEnabled) log.Debug("Run - Replay message In");
            for (int i = 1; i <= messageCache.MsgSeqNumIn; i++)
            {
                message = messageCache[MessageDirection.In, i];
                if (message != null && message.MsgSeqNum != i)
                    throw new Exception(string.Format("MsgSeqNum={0} did not match / Expected={1}", message.MsgSeqNum, i));
            }

            if (log.IsDebugEnabled) log.Debug("Run - Replay message Out");
            for (int i = 1; i <= messageCache.MsgSeqNumOut; i++)
            {
                message = messageCache[MessageDirection.Out, i];
                if (message != null && message.MsgSeqNum != i)
                    throw new Exception(string.Format("MsgSeqNum={0} did not match / Expected={1}", message.MsgSeqNum, i));
            }
        }
    }
}
