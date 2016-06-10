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

namespace ExchangeEmulator
{
	partial class SessionsSettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tradingTabPage = new System.Windows.Forms.TabPage();
			this.tradingSessionSettingsControl = new ExchangeEmulator.SessionSettingsControl();
			this.marketDataTabPage = new System.Windows.Forms.TabPage();
			this.marketDataSessionSettingsControl = new ExchangeEmulator.SessionSettingsControl();
			this.tabControl.SuspendLayout();
			this.tradingTabPage.SuspendLayout();
			this.marketDataTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// bOk
			// 
			this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bOk.Location = new System.Drawing.Point(28, 603);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(75, 23);
			this.bOk.TabIndex = 15;
			this.bOk.Text = "Ok";
			this.bOk.UseVisualStyleBackColor = true;
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(273, 603);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 16;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tradingTabPage);
			this.tabControl.Controls.Add(this.marketDataTabPage);
			this.tabControl.Location = new System.Drawing.Point(3, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(361, 585);
			this.tabControl.TabIndex = 71;
			// 
			// tradingTabPage
			// 
			this.tradingTabPage.Controls.Add(this.tradingSessionSettingsControl);
			this.tradingTabPage.Location = new System.Drawing.Point(4, 22);
			this.tradingTabPage.Name = "tradingTabPage";
			this.tradingTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.tradingTabPage.Size = new System.Drawing.Size(353, 559);
			this.tradingTabPage.TabIndex = 0;
			this.tradingTabPage.Text = "Trading Session";
			this.tradingTabPage.UseVisualStyleBackColor = true;
			// 
			// tradingSessionSettingsControl
			// 
			this.tradingSessionSettingsControl.InSeqNum = 1;
			this.tradingSessionSettingsControl.Location = new System.Drawing.Point(6, 6);
			this.tradingSessionSettingsControl.Name = "tradingSessionSettingsControl";
			this.tradingSessionSettingsControl.OutSeqNum = 1;
			this.tradingSessionSettingsControl.SectionName = "TradingSession";
			this.tradingSessionSettingsControl.Size = new System.Drawing.Size(342, 613);
			this.tradingSessionSettingsControl.TabIndex = 0;
			// 
			// marketDataTabPage
			// 
			this.marketDataTabPage.Controls.Add(this.marketDataSessionSettingsControl);
			this.marketDataTabPage.Location = new System.Drawing.Point(4, 22);
			this.marketDataTabPage.Name = "marketDataTabPage";
			this.marketDataTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.marketDataTabPage.Size = new System.Drawing.Size(353, 559);
			this.marketDataTabPage.TabIndex = 1;
			this.marketDataTabPage.Text = "Market Data Session";
			this.marketDataTabPage.UseVisualStyleBackColor = true;
			// 
			// marketDataSessionSettingsControl
			// 
			this.marketDataSessionSettingsControl.InSeqNum = 1;
			this.marketDataSessionSettingsControl.Location = new System.Drawing.Point(6, 6);
			this.marketDataSessionSettingsControl.Name = "marketDataSessionSettingsControl";
			this.marketDataSessionSettingsControl.OutSeqNum = 1;
			this.marketDataSessionSettingsControl.SectionName = "MarketDataSession";
			this.marketDataSessionSettingsControl.Size = new System.Drawing.Size(342, 613);
			this.marketDataSessionSettingsControl.TabIndex = 1;
			// 
			// SessionsSettingsForm
			// 
			this.AcceptButton = this.bOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancel;
			this.ClientSize = new System.Drawing.Size(376, 638);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SessionsSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sessions Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SessionsSettingsForm_FormClosing);
			this.tabControl.ResumeLayout(false);
			this.tradingTabPage.ResumeLayout(false);
			this.marketDataTabPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button bOk;
		private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tradingTabPage;
		private System.Windows.Forms.TabPage marketDataTabPage;
		private SessionSettingsControl tradingSessionSettingsControl;
		private SessionSettingsControl marketDataSessionSettingsControl;
	}
}