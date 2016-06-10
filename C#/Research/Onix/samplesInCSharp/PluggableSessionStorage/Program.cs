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
using System.Collections.Generic;
using System.Reflection;
using FIXForge.NET.FIX;

namespace PluggableSessionStorage
{
    class Program
    {
        private static void InitializeFixEngine()
        {
			EngineSettings settings = new EngineSettings();
			settings.ListenPort = listenPort;
			Engine.Init(settings);          
        }

        const int listenPort = 4500;

        private static void CleanUp()
        {
            if (Engine.IsInitialized())
                Engine.Instance.Shutdown();
        }

        public static void Main(String[] args)
        {
            try
            {
                InitializeFixEngine();

                Sample sample = new Sample();                
                sample.Run(listenPort);                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing sample: {0}", ex);
            }
            finally
            {
                CleanUp();
            }
        }
    }
}
