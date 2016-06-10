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
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;
using FIXForge.NET.FIX;

namespace TradingClientSample
{
    public partial class SessionsSettingsForm : Form
    {
		public SessionsSettingsForm(int tradingInSeqNum, int tradingOutSeqNum, int marketDataInSeqNum, int marketDataOutSeqNum)
        {
            InitializeComponent();

			tradingSessionSettingsControl.InSeqNum = tradingInSeqNum;
			tradingSessionSettingsControl.OutSeqNum = tradingOutSeqNum;
			marketDataSessionSettingsControl.InSeqNum = marketDataInSeqNum;
			marketDataSessionSettingsControl.OutSeqNum = marketDataOutSeqNum;
		}


		public int TradingInSeqNum
		{
			get
			{
				return tradingSessionSettingsControl.InSeqNum;
			}
		}

		public int TradingOutSeqNum
		{
			get
			{
				return tradingSessionSettingsControl.OutSeqNum;
			}
		}

		public int MarketDataInSeqNum
		{
			get
			{
				return marketDataSessionSettingsControl.InSeqNum;
			}
		}

		public int MarketDataOutSeqNum
		{
			get
			{
				return marketDataSessionSettingsControl.OutSeqNum;
			}
		}

		private void Save()
		{
			tradingSessionSettingsControl.Save();
			marketDataSessionSettingsControl.Save();
		}

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void SessionsSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
			{
				if (tradingSessionSettingsControl.SessionKey == marketDataSessionSettingsControl.SessionKey)
				{
					MessageBox.Show(this, "SenderCompID and TargetCompID and ProtocolVersion must be different for both sessions.",
						"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					e.Cancel = true;
				}
				else
				{
					Save();
					e.Cancel = false;
				}
			}
		}

    }
}