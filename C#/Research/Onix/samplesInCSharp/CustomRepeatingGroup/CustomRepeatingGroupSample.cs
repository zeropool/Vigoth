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
using System.Reflection;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX44;

namespace CustomRepeatingGroupSample
{
	class CustomRepeatingGroupSample
	{
		static void Log(String msg)
		{
			Console.Out.WriteLine(msg);
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				EngineSettings settings = new EngineSettings();
				settings.ListenPort = -1;
				settings.Dialect = "SampleFixDialectDescription.xml";

				Engine.Init(settings);	 			
			
				Message customMessage = CreateCustomMessage();

				string nativeFixMessage = customMessage.ToString();

                Log("FIX message in the native (tag=value) format:\n\n" + nativeFixMessage);

				Log("\nThe same message in human-readable format:\n\n" + customMessage.ToString(Message.StringFormat.TAG_NAME, ' '));
				
				Message readMessage = ReadFixMessage(nativeFixMessage);

				Log("\n\nRead FIX message:\n\n" + readMessage.ToString());
			
				Engine.Instance.Shutdown();
			}
			catch(Exception ex)
			{
				Log("Exception: " + ex);	
			}						
		}

		/// <summary>
		/// Read (parses) the given string that contains the native (tag=value) representation of the FIX message.
		/// </summary>
		/// <param name="nativeFixMsg"></param>
		/// <returns></returns>
		static Message ReadFixMessage(string nativeFixMsg)
		{
			return new Message(nativeFixMsg);
		}

		/// <summary>
		/// Creates a custom FIX message with a custom repeating group.
		/// </summary>
		static Message CreateCustomMessage()
		{
			Message message = new Message("SampleCustomFixMessage", ProtocolVersion.FIX44);

			message.Set(Tags.TargetStrategy, "1002"); 
			message.Set(Tags.EffectiveTime, "20050606-14:00:00");
			message.Set(Tags.ExpireTime , "20050606-18:00:00");

			const int NoStrategyParameters = 957;

			Group group = message.SetGroup(NoStrategyParameters, 2);

			const int StrategyParameterName = 958;
			const int StrategyParameterType = 959;
			const int StrategyParameterValue = 960;

			group.Set(StrategyParameterName, 0, "MinimumVolume");
			group.Set(StrategyParameterType, 0, 11);
			group.Set(StrategyParameterValue, 0, 11);

			group.Set(StrategyParameterName, 1, "Aggressive");
			group.Set(StrategyParameterType, 1, 13);
			group.Set(StrategyParameterValue, 1, "Y");

			return message;
		}		
	}
}
