using System;
using System.Collections.Generic;
using System.Configuration;

using FIX4NET;
using FIX4NET.FIX;
using FIX4NET.Net;
using FIX4NET.Utils;
using FIX4NET.MessageCache.FlatFile;
//using FIX_4_0 = FIX4NET.FIX.FIX_4_0;
//using FIX_4_2 = FIX4NET.FIX.FIX_4_2;
//using FIX_4_4 = FIX4NET.FIX.FIX_4_4;

[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace SocketListen
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private static IMessageFactory _factory;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			log.Debug("--> Main");

			SocketListener listener = new SocketListener();

            IMessageFactory factory = new MessageFactoryFIX(ConfigurationManager.AppSettings["BeginString"]);
			//IMessageFactory factory = new FIX_4_2.MessageFactoryFIX();
			_factory = factory;

			IEngine engine = new SocketEngine();
            engine.MessageCacheFactory = new MessageCacheFlatFileFactory();
            engine.MessageFactory = factory;
            engine.Initialize(
                ConfigurationManager.AppSettings["SenderCompID"], null,
                ConfigurationManager.AppSettings["TargetCompID"], null);
			engine.Received += new MessageEventHandler(engine_Received);
			engine.Sent += new MessageEventHandler(engine_Sent);

			listener.Add(engine);

            int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
			listener.Init(port);

			Console.WriteLine("press <Enter> to exit...");
			Console.ReadLine();

			listener.Dispose();
			engine.Dispose();

			log.Debug("<-- Main");
		}

		private static void engine_Received(IEngine engine, IMessage message)
		{
			if (log.IsDebugEnabled)
				log.DebugFormat("engine_Received - MsgType={0}", message.MsgType);
		}

		private static void engine_Sent(IEngine engine, IMessage message)
		{
			if (log.IsInfoEnabled)
				log.InfoFormat("engine_Sent - MsgType={0}", message.MsgType);
		}
	}
}
