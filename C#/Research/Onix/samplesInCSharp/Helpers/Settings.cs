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
using System.Configuration;
using FIXForge.NET.FIX;
using System.Globalization;

namespace Helpers
{
    /// <summary>
    /// Application Settings.
    /// </summary>
    public static class Settings
    {
        public static string Get(string key)
        {
            string v = ConfigurationManager.AppSettings[key];
            if (null == v)
            {
                throw new ApplicationException("Cannot find the '" + key + "' setting in the configuration file");
            }
            return v;
        }

        public static int GetInteger(string key)
        {
            string v = Get(key);
			return int.Parse(v, CultureInfo.InvariantCulture);
        }

        public static Boolean GetBoolean(string key)
        {
            string v = Get(key);
            return (v.ToUpperInvariant().Trim() == "TRUE");
        }

        public static string GetOptional(string key)
        {
            string v = ConfigurationManager.AppSettings[key];
            return v;
        }

        public static string GetOptional(string key, string defaultValue)
        {
            string v = ConfigurationManager.AppSettings[key];
            if (null == v)
            {
                return defaultValue;
            }
            return v;
        }

        [CLSCompliantAttribute(false)]
        public static ProtocolVersion GetVersion()
        {
            string str = Get("FIX version");
            switch (str)
            {
                case "4.0":
                    return ProtocolVersion.FIX40;

                case "4.1":
                    return ProtocolVersion.FIX41;

                case "4.2":
                    return ProtocolVersion.FIX42;

                case "4.3":
                    return ProtocolVersion.FIX43;

                case "4.4":
                    return ProtocolVersion.FIX44;
            }
            throw new ApplicationException("Unknown FIX version: '" + str + "'");
        }
    }
}