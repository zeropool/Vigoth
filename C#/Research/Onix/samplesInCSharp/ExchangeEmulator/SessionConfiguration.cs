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

using System.Configuration;
using FIXForge.NET.FIX;

namespace ExchangeEmulator
{
    /// <summary>
    /// Configuration of the FIX Session.
    /// </summary>    
    class SessionConfiguration : ConfigurationSection
    {
		[ConfigurationProperty("senderCompID", IsRequired = true)]
		public string SenderCompID
		{
			get { return (string)this["senderCompID"]; }
			set { this["senderCompID"] = value; }
		}

		[ConfigurationProperty("targetCompID", IsRequired = true)]
		public string TargetCompID
		{
			get { return (string)this["targetCompID"]; }
			set { this["targetCompID"] = value; }
		}

		[ConfigurationProperty("fixVersion", IsRequired = true)]
		public ProtocolVersion Version
		{
			get
			{
				return (ProtocolVersion)this["fixVersion"];
			}
			set { this["fixVersion"] = value; }
		}

		[ConfigurationProperty("heartbeatInterval", IsRequired = true)]

		public int HeartbeatInterval
		{
			get { return (int)this["heartbeatInterval"]; }
			set { this["heartbeatInterval"] = value; }
		}

		[ConfigurationProperty("keepSequenceNumbersAfterLogout", IsRequired = true)]
		public bool KeepSequenceNumbersAfterLogout
		{
			get { return (bool)this["keepSequenceNumbersAfterLogout"]; }
			set { this["keepSequenceNumbersAfterLogout"] = value; }
		}

		[ConfigurationProperty("setResetSeqNumFlag")]
		public bool SetResetSeqNumFlag
		{
			get { return (bool)this["setResetSeqNumFlag"]; }
			set { this["setResetSeqNumFlag"] = value; }
		}

		[ConfigurationProperty("username")]
		public string Username
		{
			get { return (string)this["username"]; }
			set { this["username"] = value; }
		}

		[ConfigurationProperty("password")]
		public string Password
		{
			get { return (string)this["password"]; }
			set { this["password"] = value; }
		}

		[ConfigurationProperty("rawData")]
		public string RawData
		{
			get { return (string)this["rawData"]; }
			set { this["rawData"] = value; }
		}

		[ConfigurationProperty("senderSubID")]
		public string SenderSubID
		{
			get { return (string)this["senderSubID"]; }
			set { this["senderSubID"] = value; }
		}

		[ConfigurationProperty("senderLocationID")]
		public string SenderLocationID
		{
			get { return (string)this["senderLocationID"]; }
			set { this["senderLocationID"] = value; }
		}

		[ConfigurationProperty("targetSubID")]
		public string TargetSubID
		{
			get { return (string)this["targetSubID"]; }
			set { this["targetSubID"] = value; }
		}

		[ConfigurationProperty("clientID")]
		public string ClientID
		{
			get { return (string)this["clientID"]; }
			set { this["clientID"] = value; }
		}

		[ConfigurationProperty("targetLocationID")]
		public string TargetLocationID
		{
			get { return (string)this["targetLocationID"]; }
			set { this["targetLocationID"] = value; }
		}

		[ConfigurationProperty("useSslEncryption")]
		public bool UseSslEncryption
		{
			get { return (bool)this["useSslEncryption"]; }
			set { this["useSslEncryption"] = value; }
		}

		[ConfigurationProperty("sslCertificateFile")]
		public string SslCertificateFile
		{
			get { return (string)this["sslCertificateFile"]; }
			set { this["sslCertificateFile"] = value; }
		}

		[ConfigurationProperty("account")]
		public string Account
		{
			get { return (string)this["account"]; }
			set { this["account"] = value; }
		}                                                                              
    }
}
