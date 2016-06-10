using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using FIX4NET;
using FIX4NET.FIX;
using FIX4NET.Utils;
using FIX4NET.MessageCache.FlatFile;
using FIX_4_2 = FIX4NET.FIX.FIX_4_2;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace MessageCacheResetMsgSeqNo
{
	class Program
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		
		static void Main(string[] args)
		{
			log.Debug("--> Main");

			const string SENDER_COMP_ID = "SENDER";
			const string TARGET_COMP_ID = "TARGET";

			IMessage message;
			int i;

			try
			{
				IMessageFactory factory = new FIX_4_2.MessageFactoryFIX();
				IMessageCache cache = new MessageCacheFlatFile();
				cache.Initialize(factory);
				cache.Open(SENDER_COMP_ID, null, TARGET_COMP_ID, null);

				//Add 1000 messages in cache
				Console.WriteLine("Appending 1000 In messages");
				for (i = 1; i <= 1000; i++)
				{
					message = factory.CreateInstanceHeartbeat();
					message.Direction = MessageDirection.In;
					message.SenderCompID = SENDER_COMP_ID;
					message.TargetCompID = TARGET_COMP_ID;
					message.SendingTime = DateTime.Now;
					message.MsgSeqNum = cache.MsgSeqNumIn + 1;
					factory.Build(message);
					cache.AddMessage(message);
				}
				Console.WriteLine("MsgSeqNumIn / {0}", cache.MsgSeqNumIn);

				//Reset MsgSeqNum In to 100
				Console.WriteLine("ResetMsgSeqNumIn to 100");
				cache.ResetMsgSeqNumIn(100);
				Console.WriteLine("MsgSeqNumIn (Expected 99) / {0}", cache.MsgSeqNumIn);

				//Close and Open file to check MsgSeqNum
				Console.WriteLine("Close/Open file");
				cache.Close();
				cache.Open(SENDER_COMP_ID, null, TARGET_COMP_ID, null);
				Console.WriteLine("MsgSeqNumIn (Expected 99) / {0}", cache.MsgSeqNumIn);

				//Reset MsgSeqNum In to 1000
				Console.WriteLine("ResetMsgSeqNumIn to 1000");
				cache.ResetMsgSeqNumIn(1000);
				Console.WriteLine("MsgSeqNumIn (Expected 999) / {0}", cache.MsgSeqNumIn);

				//Close and Open file to check MsgSeqNum
				Console.WriteLine("Close/Open file");
				cache.Close();
				cache.Open(SENDER_COMP_ID, null, TARGET_COMP_ID, null);
				Console.WriteLine("MsgSeqNumIn (Expected 999) / {0}", cache.MsgSeqNumIn);

				//Add 1000 messages in cache
				Console.WriteLine("Appending 1000 In messages");
				for (i = 1; i <= 1000; i++)
				{
					message = factory.CreateInstanceHeartbeat();
					message.Direction = MessageDirection.In;
					message.SenderCompID = SENDER_COMP_ID;
					message.TargetCompID = TARGET_COMP_ID;
					message.SendingTime = DateTime.Now;
					message.MsgSeqNum = cache.MsgSeqNumIn + 1;
					factory.Build(message);
					cache.AddMessage(message);
				}
				Console.WriteLine("MsgSeqNumIn / {0}", cache.MsgSeqNumIn);

				//Read Messages from Cache to check MsgSeqNum
				Console.WriteLine("Reading Cache to check MsgSeqNum");
				for (i = 1; i <= cache.MsgSeqNumIn; i++)
				{
					message = cache[MessageDirection.In, i];
					if (message != null)
					{
						if(message.MsgSeqNum != i) {
							Console.WriteLine("MsgSeqNum did NOT match / MsgSeqNum(Expected)={0} MsgSeqNum(Message)={1}", 
								i, message.MsgSeqNum);
						}
					}
				}
				Console.WriteLine("Reading Cache to check MsgSeqNum - COMPLETE / i={0}", i);

				//Close cache
				cache.Close();

			}
			catch (Exception ex)
			{
				log.Error("Error running FIX test", ex);
			}

			log.Debug("<-- Main");

			Console.WriteLine("press <Enter> to exit...");
			Console.ReadLine();
		}
	}
}
