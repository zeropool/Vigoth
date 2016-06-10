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

namespace PrettyPrintSample
{
	class PrettyPrintSample
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

                Message message = CreateMessageWithNestedRepeatingGroups();

                PrintMessage(message);

				Engine.Instance.Shutdown();
			}
			catch(Exception ex)
			{
				Log("Exception: " + ex);	
			}			
		}

        private static void PrintMessage(Message message)
        {
            PrintFieldSet(message, string.Empty);
            //PrintFieldSet(message, message.Dialect.GetMessageFields(message.Type), string.Empty);
        }

        private static void PrintFieldSet(FieldSet fieldSet, FieldInfo[] fields, string prefix)
        {
            foreach (var field in fields)
            {
                if (fieldSet.Contain(field.Tag))
                {
                    if (field.ChildFields.Length > 0)
                    {
                        Group group = fieldSet.GetGroup(field.Tag);
                        Log(prefix + field.Tag.ToString() + "=> group of " + group.NumberOfInstances + " item(s)");
                        PrintGroup(group, field.ChildFields, prefix + "  ");
                        Log(prefix + "<= end of group");
                    }
                    else
                    {
                        Log(prefix + field.Tag.ToString() + '=' + fieldSet.Get(field.Tag));
                    }
                }
            }
        }

        private static void PrintGroup(Group group, FieldInfo[] fields, string prefix)
        {
            for (int i = 0; i < group.NumberOfInstances; i++)
            {
                string groupPrefix = prefix + i.ToString() + ": ";
                PrintFieldSet(group[i], fields, groupPrefix);
            }
        }

        private static void PrintFieldSet(FieldSet fieldSet, string prefix)
        {
            foreach (var field in fieldSet.Fields)
            {
                Group group;
                if (fieldSet.TryGetGroup(field.Tag, out group))
                {
                    Log(prefix + field.Tag.ToString() + "=> group of " + group.NumberOfInstances + " item(s)");
                    PrintGroup(group, prefix + "  ");
                    Log(prefix + "<= end of group");
                }
                else
                {
                    Log(prefix + field.Tag.ToString() + '=' + field.Value);
                }
            }
        }

        private static void PrintGroup(Group group, string prefix)
        {
            for (int i = 0; i < group.NumberOfInstances; i++)
            {
                string groupPrefix = prefix + i.ToString() + ": ";
                PrintFieldSet(group[i], groupPrefix);
            }
        }
		
        private static Message CreateMessageWithNestedRepeatingGroups()
        {
            Message order = new Message(MsgType.NewOrderSingle, ProtocolVersion.FIX50);
           
            order.Set(Tags.ClOrdID, "ClOrdID value");
            order.Set(10000, "Custom tag");
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

    }
}
