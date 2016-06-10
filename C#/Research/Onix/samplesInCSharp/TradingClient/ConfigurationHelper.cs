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
using System.Text;
using System.Reflection;
using System.Configuration;
using System.IO;
using System.Globalization;

namespace TradingClientSample
{
	static class ConfigurationHelper
	{
		public static string GetConfigurationPath()
		{
			AssemblyName assemblyName = Assembly.GetEntryAssembly().GetName();

			string configPath = assemblyName.Name + ".exe.config";

			if (!File.Exists(configPath))
			{
				Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (!Directory.Exists(Path.GetDirectoryName(configPath)))
					Directory.CreateDirectory(Path.GetDirectoryName(configPath));
				if (File.Exists(cfg.FilePath))
					File.Copy(cfg.FilePath, configPath);
			}
			return configPath;
		}

		public static Configuration GetConfiguration()
		{
			string configPath = GetConfigurationPath();
			ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
			fileMap.ExeConfigFilename = configPath;

			Configuration cfg = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
			if (cfg == null)
			{
				throw new ApplicationException("Cannot find configuration file: " + configPath);
			}

			return cfg;
		}

		public static ConfigurationSection GetSection(string name)
		{
			string configPath = GetConfigurationPath();

			ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
			fileMap.ExeConfigFilename = configPath;

			Configuration cfg = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
			if (cfg == null)
			{
				throw new ApplicationException("Cannot find configuration file: " + configPath);
			}

			ConfigurationSection section = cfg.GetSection(name);
			if (section == null)
			{
				throw new ApplicationException("Cannot find the '" + name + "' section in the configuration file: " + configPath);
			}
			return section;
		}

		public static string Get(string key)
		{
			string configPath = GetConfigurationPath();

			ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
			fileMap.ExeConfigFilename = configPath;

			Configuration cfg = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
			if (cfg == null)
			{
				throw new ApplicationException("Cannot find configuration file: " + configPath);
			}

			KeyValueConfigurationElement elem = cfg.AppSettings.Settings[key];
			if (elem == null)
			{
				throw new ApplicationException("Cannot find the '" + key + "' setting in the configuration file: " + configPath);
			}
			string v = elem.Value;
			if (null == v)
			{
				throw new ApplicationException("Cannot find the '" + key + "' setting in the configuration file: " + configPath);
			}
			return v;
		}

		public static int GetInteger(string key)
		{
			string v = Get(key);
			return int.Parse(v, CultureInfo.InvariantCulture);
		}

		public static double GetDouble(string key)
		{
			string v = Get(key);
			return double.Parse(v, CultureInfo.InvariantCulture);
		}
	}
}
