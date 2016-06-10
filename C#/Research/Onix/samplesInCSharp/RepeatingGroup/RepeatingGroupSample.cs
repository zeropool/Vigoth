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
using System.Diagnostics;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX44;

namespace RepeatingGroupSample
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class RepeatingGroupSample
	{
		static void Log(String msg)
		{
			Console.Out.WriteLine(msg);
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				EngineSettings settings = new EngineSettings();
				settings.ListenPort = -1;

				Engine.Init(settings);	 			
			
				Message marketDataRequest = CreateMarketDataRequestMessage();

                Log("Created FIX message in the native (tag=value) format:\n\n" + marketDataRequest);

                Log("\nThe same message in human-readable format:\n\n" + marketDataRequest.ToString(Message.StringFormat.TAG_NAME, ' '));

			    ProcessMarketDataRequestMessage(marketDataRequest);

                Message order = CreateMessageWithNestedRepeatingGroups();

                ProcessMessageWithNestedRepeatingGroups(order);
			
				Engine.Instance.Shutdown();
			}
			catch(Exception ex)
			{
				Log("Exception: " + ex);	
			}			
		}
		
		/// <summary>
		/// Creates a Market Data Request (MsgType=V) message.
		/// </summary>
		static Message CreateMarketDataRequestMessage()
		{
			Message request = new Message(MsgType.MarketDataRequest, ProtocolVersion.FIX44);
		    request.Set(Tags.MDReqID, "1");			
		    request.Set(Tags.SubscriptionRequestType, SubscriptionRequestType.SnapshotUpdate);
            request.Set(Tags.MarketDepth, "0");
            request.Set(Tags.MDUpdateType, MDUpdateType.Full);
            
            Group marketDataEntryTypes = request.SetGroup(Tags.NoMDEntryTypes, 3);
		    marketDataEntryTypes.Set(Tags.MDEntryType, 0, MDEntryType.Bid);
            marketDataEntryTypes.Set(Tags.MDEntryType, 1, MDEntryType.Offer);
            marketDataEntryTypes.Set(Tags.MDEntryType, 2, MDEntryType.Trade);

		    Group relatedSymbols = request.SetGroup(Tags.NoRelatedSym, 2);
            relatedSymbols.Set(Tags.Symbol, 0, "EUR/USD");
            relatedSymbols.Set(Tags.Symbol, 1, "GPS/USD");
           
            request.Validate();

			return request;
		}

        static void ProcessMarketDataRequestMessage(Message request)
        {
            Debug.Assert(MsgType.MarketDataRequest == request.Type);

            Group marketDataEntryTypes = request.GetGroup(Tags.NoMDEntryTypes);

            Console.WriteLine("\nProcessing " + request.ToString(' ') + "\n");

            for(int index = 0; index < marketDataEntryTypes.NumberOfInstances; ++index)
            {
                Console.WriteLine("Market Data Entry # " + index + " : MDEntryType = " + marketDataEntryTypes.Get(Tags.MDEntryType, index));
            }
        }

        static Message CreateMessageWithNestedRepeatingGroups()
        {
            Message order = new Message(MsgType.NewOrderSingle, ProtocolVersion.FIX50);
           
            order.Set(Tags.ClOrdID, "ClOrdID value");               
            Group partiesGroup = order.SetGroup(FIXForge.NET.FIX.FIX50.Tags.NoPartyIDs, 1);

            partiesGroup.Set(FIXForge.NET.FIX.FIX50.Tags.PartyID, 0, "Party ID value");

            // Nested repeating group:
            Group partiesSubGroup = partiesGroup.SetGroup(FIXForge.NET.FIX.FIX50.Tags.NoPartySubIDs, 0, 3);

            partiesSubGroup.Set(FIXForge.NET.FIX.FIX50.Tags.PartySubID, 0, "PartySubID value0");
            partiesSubGroup.Set(FIXForge.NET.FIX.FIX50.Tags.PartySubID, 1, "PartySubID value1");
            partiesSubGroup.Set(FIXForge.NET.FIX.FIX50.Tags.PartySubID, 2, "PartySubID value2");

            Console.WriteLine("\n\nMessage with nested repeating group:\n" + order);

            return order;
        }

        static void ProcessMessageWithNestedRepeatingGroups(Message order)
        {
            Debug.Assert(MsgType.NewOrderSingle == order.Type);

            Group partiesGroup = order.GetGroup(FIXForge.NET.FIX.FIX50.Tags.NoPartyIDs);

            Console.WriteLine("\nProcessing " + order.ToString(' ') + "\n");

            for (int index = 0; index < partiesGroup.NumberOfInstances; ++index)
            {
                Group partiesSubGroup = partiesGroup.GetGroup(FIXForge.NET.FIX.FIX50.Tags.NoPartySubIDs, index);

                for (int nestedIndex = 0; nestedIndex < partiesSubGroup.NumberOfInstances; ++nestedIndex)
                {
                    Console.WriteLine("Parties SubGroup # " + nestedIndex + " : PartySubID = " + partiesSubGroup.Get(FIXForge.NET.FIX.FIX50.Tags.PartySubID, nestedIndex));
                }                
            }
        }

    }
}
