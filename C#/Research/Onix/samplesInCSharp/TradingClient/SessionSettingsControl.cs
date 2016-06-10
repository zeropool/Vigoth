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
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using FIXForge.NET.FIX;
using System.Globalization;

namespace TradingClientSample
{
	public partial class SessionSettingsControl : UserControl
	{
		private bool willSave = false;

		public SessionSettingsControl()
		{
			InitializeComponent();
		}

		private static bool IsInDesignMode(IComponent component)
		{
			bool ret = false;
			if (null != component)
			{
				ISite site = component.Site;
				if (null != site)
				{
					ret = site.DesignMode;
				}
				else if (component is System.Windows.Forms.Control)
				{
					IComponent parent = ((System.Windows.Forms.Control)component).Parent;
					ret = IsInDesignMode(parent);
				}
			}

			return ret;
		}

		public string SectionName
		{
            get { return sectionName; }
            set { sectionName = value; }
        }
        private string sectionName;

		private void SessionSettingsControl_Load(object sender, EventArgs e)
		{
			if (!IsInDesignMode(this))
			{
				Configuration config = ConfigurationHelper.GetConfiguration();
				{
					SessionConfiguration settings = (SessionConfiguration)config.GetSection(SectionName);

					txtHost.Text = settings.Host;
					txtPort.Text = settings.Port.ToString(CultureInfo.InvariantCulture);

					cmbVersion.Items.AddRange(Enum.GetNames(typeof(ProtocolVersion)));
					cmbVersion.Items.RemoveAt(0);

					int fixVersionIndex = cmbVersion.FindString(settings.Version.ToString());
					cmbVersion.SelectedIndex = fixVersionIndex;
					txtSenderCompId.Text = settings.SenderCompID;
					txtAccount.Text = settings.Account;
					txtSenderSubId.Text = settings.SenderSubID;
					txtSenderLocationID.Text = settings.SenderLocationID;
					txtTargetCompId.Text = settings.TargetCompID;
					txtTargetSubId.Text = settings.TargetSubID;
					clientIdTextBox.Text = settings.ClientID;
					txtTargetLocationID.Text = settings.TargetLocationID;
					txtHBI.Text = settings.HeartbeatInterval.ToString(CultureInfo.InvariantCulture);
					txtUsername.Text = settings.Username;
					txtPassword.Text = settings.Password;
					txtRawData.Text = settings.RawData;
					txtSslCertificateFile.Text = settings.SslCertificateFile;

					cbKeepSequenceNumbersAfterLogout.Checked = settings.KeepSequenceNumbersAfterLogout;
					tradingSetResetSeqNumFlagCheckBox.Checked = settings.SetResetSeqNumFlag;
					cbUseSslEncryption.Checked = settings.UseSslEncryption;
					OnUseSslEncryptionCheckedChanged();
				}
				willSave = true;
			}
		}

		public void Save()
		{
			if (willSave)
			{
				Configuration config = ConfigurationHelper.GetConfiguration();
				{
					SessionConfiguration settings = (SessionConfiguration)config.GetSection(SectionName);

					settings.Host = txtHost.Text.Trim();
					settings.Port = int.Parse(txtPort.Text, CultureInfo.InvariantCulture);
					settings.Version = (ProtocolVersion)Enum.Parse(typeof(ProtocolVersion), cmbVersion.Text);
					settings.SenderCompID = txtSenderCompId.Text.Trim();
					settings.SenderSubID = txtSenderSubId.Text.Trim();
					settings.Account = txtAccount.Text.Trim();
					settings.SenderLocationID = txtSenderLocationID.Text.Trim();
					settings.ClientID = clientIdTextBox.Text.Trim();
					settings.TargetCompID = txtTargetCompId.Text.Trim();
					settings.TargetSubID = txtTargetSubId.Text.Trim();
					settings.TargetLocationID = txtTargetLocationID.Text.Trim();
					settings.HeartbeatInterval = int.Parse(txtHBI.Text, CultureInfo.InvariantCulture);
					settings.Username = txtUsername.Text.Trim();
					settings.Password = txtPassword.Text.Trim();
					settings.RawData = txtRawData.Text.Trim();
					settings.KeepSequenceNumbersAfterLogout = cbKeepSequenceNumbersAfterLogout.Checked;
					settings.SetResetSeqNumFlag = tradingSetResetSeqNumFlagCheckBox.Checked;
					settings.UseSslEncryption = cbUseSslEncryption.Checked;
					settings.SslCertificateFile = txtSslCertificateFile.Text.Trim();
				}

				config.Save();
				ConfigurationManager.RefreshSection(SectionName);
			}
		}

		public int InSeqNum
		{
			get
			{
				return (int)nudIncomingSeqNum.Value;
			}
			set
			{
				nudIncomingSeqNum.Value = value;
			}
		}

		public int OutSeqNum
		{
			get
			{
				return (int)nudOutgoingSeqNum.Value;
			}
			set
			{
				nudOutgoingSeqNum.Value = value;
			}
		}

		internal string SessionKey
		{
			get
			{
				return txtSenderCompId + "|" + txtTargetCompId + "|" + cmbVersion.Text;
			}
		}

		private void txtPort_Validating(object sender, CancelEventArgs e)
		{
			try
			{
				int x = int.Parse(txtPort.Text, CultureInfo.InvariantCulture);
				errorProvider.SetError(txtPort, "");

				if (x <= 0)
				{
					errorProvider.SetError(txtPort, "Port number must be positive.");
					e.Cancel = true;
				}
			}
			catch (Exception)
			{
				errorProvider.SetError(txtPort, "Not an integer value.");
				e.Cancel = true;
			}
		}

		private void btnOpenFileDialog_Click(object sender, EventArgs e)
		{
			if (DialogResult.OK == openFileDialog.ShowDialog(this))
			{
				txtSslCertificateFile.Text = openFileDialog.FileName;
			}
		}

		private void cbUseSslEncryption_CheckedChanged(object sender, EventArgs e)
		{
			OnUseSslEncryptionCheckedChanged();
		}

		private void OnUseSslEncryptionCheckedChanged()
		{
			txtSslCertificateFile.Enabled = btnOpenFileDialog.Enabled = cbUseSslEncryption.Checked;
		}
	}
}
