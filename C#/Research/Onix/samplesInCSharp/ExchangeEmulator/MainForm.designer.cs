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
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
			System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tradingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetTradingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.replayLogFileTradingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.breakTradingConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.marketDataSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetMarketDataSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.replayLogFileMarketDataSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.breakMarketDataConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.emulationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sessionsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.modeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tradingSessionStateToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.marketDataSessionStateToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPaigeEvents = new System.Windows.Forms.TabPage();
			this.eventView = new Onixs.FixControls.EventViewUserControl();
			this.contextMenuStripEvents = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openMarketDataLogFileToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonConnect = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonDisconnect = new System.Windows.Forms.ToolStripButton();
			this.openOrderLogFileToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.connectMarketDataSessionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.disconnectMarketDataSessionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonClearEventLog = new System.Windows.Forms.ToolStripButton();
			this.connectTradingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disconnectTradingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectMarketDataSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disconnectMarketDataSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPaigeEvents.SuspendLayout();
			this.contextMenuStripEvents.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripStatusLabel1
			// 
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(116, 17);
			toolStripStatusLabel1.Text = "Market Data Session:";
			// 
			// toolStripStatusLabel2
			// 
			toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			toolStripStatusLabel2.Size = new System.Drawing.Size(93, 17);
			toolStripStatusLabel2.Text = "Trading Session:";
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tradingSessionToolStripMenuItem,
            this.marketDataSessionToolStripMenuItem,
            this.eventsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(882, 24);
			this.menuStrip.TabIndex = 0;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// tradingSessionToolStripMenuItem
			// 
			this.tradingSessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectTradingSessionToolStripMenuItem,
            this.disconnectTradingSessionToolStripMenuItem,
            this.resetTradingSessionToolStripMenuItem,
            this.breakTradingConnectionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.replayLogFileTradingSessionToolStripMenuItem});
			this.tradingSessionToolStripMenuItem.Name = "tradingSessionToolStripMenuItem";
			this.tradingSessionToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.tradingSessionToolStripMenuItem.Text = "&Trading";
			// 
			// resetTradingSessionToolStripMenuItem
			// 
			this.resetTradingSessionToolStripMenuItem.Name = "resetTradingSessionToolStripMenuItem";
			this.resetTradingSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.resetTradingSessionToolStripMenuItem.Text = "&Reset";
			this.resetTradingSessionToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 6);
			// 
			// replayLogFileTradingSessionToolStripMenuItem
			// 
			this.replayLogFileTradingSessionToolStripMenuItem.Name = "replayLogFileTradingSessionToolStripMenuItem";
			this.replayLogFileTradingSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.replayLogFileTradingSessionToolStripMenuItem.Text = "Replay &Log File...";
			this.replayLogFileTradingSessionToolStripMenuItem.Click += new System.EventHandler(this.replayLogFileToolStripMenuItem_Click);
			// 
			// breakTradingConnectionToolStripMenuItem
			// 
			this.breakTradingConnectionToolStripMenuItem.Name = "breakTradingConnectionToolStripMenuItem";
			this.breakTradingConnectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.breakTradingConnectionToolStripMenuItem.Text = "&Break Connection";
			this.breakTradingConnectionToolStripMenuItem.ToolTipText = "Breaks the FIX Connection non-gracefully (without the exchange of Logout (MsgType" +
				"=5) messages). ";
			this.breakTradingConnectionToolStripMenuItem.Click += new System.EventHandler(this.breakTradingConnectionToolStripMenuItem_Click);
			// 
			// marketDataSessionToolStripMenuItem
			// 
			this.marketDataSessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectMarketDataSessionToolStripMenuItem,
            this.disconnectMarketDataSessionToolStripMenuItem,
            this.resetMarketDataSessionToolStripMenuItem,
            this.breakMarketDataConnectionToolStripMenuItem,
            this.toolStripSeparator4,
            this.replayLogFileMarketDataSessionToolStripMenuItem});
			this.marketDataSessionToolStripMenuItem.Name = "marketDataSessionToolStripMenuItem";
			this.marketDataSessionToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
			this.marketDataSessionToolStripMenuItem.Text = "&Market Data";
			// 
			// resetMarketDataSessionToolStripMenuItem
			// 
			this.resetMarketDataSessionToolStripMenuItem.Name = "resetMarketDataSessionToolStripMenuItem";
			this.resetMarketDataSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.resetMarketDataSessionToolStripMenuItem.Text = "&Reset";
			this.resetMarketDataSessionToolStripMenuItem.Click += new System.EventHandler(this.resetMarketDataSessionToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
			// 
			// replayLogFileMarketDataSessionToolStripMenuItem
			// 
			this.replayLogFileMarketDataSessionToolStripMenuItem.Name = "replayLogFileMarketDataSessionToolStripMenuItem";
			this.replayLogFileMarketDataSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.replayLogFileMarketDataSessionToolStripMenuItem.Text = "Replay &Log File...";
			this.replayLogFileMarketDataSessionToolStripMenuItem.Click += new System.EventHandler(this.replayLogFileMarketDataSessionToolStripMenuItem_Click);
			// 
			// breakMarketDataConnectionToolStripMenuItem
			// 
			this.breakMarketDataConnectionToolStripMenuItem.Name = "breakMarketDataConnectionToolStripMenuItem";
			this.breakMarketDataConnectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.breakMarketDataConnectionToolStripMenuItem.Text = "&Break Connection";
			this.breakMarketDataConnectionToolStripMenuItem.Click += new System.EventHandler(this.breakMarketDataConnectionToolStripMenuItem_Click);
			// 
			// eventsToolStripMenuItem
			// 
			this.eventsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
			this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
			this.eventsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.eventsToolStripMenuItem.Text = "&Events";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emulationSettingsToolStripMenuItem,
            this.sessionsSettingsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// emulationSettingsToolStripMenuItem
			// 
			this.emulationSettingsToolStripMenuItem.Name = "emulationSettingsToolStripMenuItem";
			this.emulationSettingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.emulationSettingsToolStripMenuItem.Text = "&Emulation Settings...";
			this.emulationSettingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
			// 
			// sessionsSettingsToolStripMenuItem
			// 
			this.sessionsSettingsToolStripMenuItem.Name = "sessionsSettingsToolStripMenuItem";
			this.sessionsSettingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.sessionsSettingsToolStripMenuItem.Text = "&Sessions Settings...";
			this.sessionsSettingsToolStripMenuItem.Click += new System.EventHandler(this.sessionsSettingsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonConnect,
            this.toolStripButtonDisconnect,
            this.toolStripLabel1,
            this.modeToolStripComboBox,
            this.openOrderLogFileToolStripButton,
            this.toolStripSeparator1,
            this.connectMarketDataSessionToolStripButton,
            this.disconnectMarketDataSessionToolStripButton,
            this.openMarketDataLogFileToolStripButton,
            this.toolStripSeparator3,
            this.toolStripButtonClearEventLog});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(882, 25);
			this.toolStrip.TabIndex = 1;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(41, 22);
			this.toolStripLabel1.Text = "Mode:";
			this.toolStripLabel1.ToolTipText = "Emulation Mode";
			// 
			// modeToolStripComboBox
			// 
			this.modeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.modeToolStripComboBox.Name = "modeToolStripComboBox";
			this.modeToolStripComboBox.Size = new System.Drawing.Size(121, 25);
			this.modeToolStripComboBox.ToolTipText = "Emulation Mode";
			this.modeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.modeToolStripComboBox_SelectedIndexChanged);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus,
            toolStripStatusLabel2,
            this.tradingSessionStateToolStripLabel,
            toolStripStatusLabel1,
            this.marketDataSessionStateToolStripLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 440);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(882, 22);
			this.statusStrip.TabIndex = 2;
			// 
			// toolStripStatusLabelStatus
			// 
			this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
			this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(338, 17);
			this.toolStripStatusLabelStatus.Spring = true;
			this.toolStripStatusLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tradingSessionStateToolStripLabel
			// 
			this.tradingSessionStateToolStripLabel.AutoSize = false;
			this.tradingSessionStateToolStripLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.tradingSessionStateToolStripLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
			this.tradingSessionStateToolStripLabel.Name = "tradingSessionStateToolStripLabel";
			this.tradingSessionStateToolStripLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.tradingSessionStateToolStripLabel.Size = new System.Drawing.Size(160, 17);
			this.tradingSessionStateToolStripLabel.Text = "DISCONNECTED";
			// 
			// marketDataSessionStateToolStripLabel
			// 
			this.marketDataSessionStateToolStripLabel.AutoSize = false;
			this.marketDataSessionStateToolStripLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.marketDataSessionStateToolStripLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
			this.marketDataSessionStateToolStripLabel.Name = "marketDataSessionStateToolStripLabel";
			this.marketDataSessionStateToolStripLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.marketDataSessionStateToolStripLabel.Size = new System.Drawing.Size(160, 17);
			this.marketDataSessionStateToolStripLabel.Text = "DISCONNECTED";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPaigeEvents);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 49);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(882, 391);
			this.tabControl.TabIndex = 3;
			// 
			// tabPaigeEvents
			// 
			this.tabPaigeEvents.Controls.Add(this.eventView);
			this.tabPaigeEvents.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabPaigeEvents.Location = new System.Drawing.Point(4, 22);
			this.tabPaigeEvents.Name = "tabPaigeEvents";
			this.tabPaigeEvents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPaigeEvents.Size = new System.Drawing.Size(874, 365);
			this.tabPaigeEvents.TabIndex = 1;
			this.tabPaigeEvents.Text = "Events";
			this.tabPaigeEvents.UseVisualStyleBackColor = true;
			// 
			// eventView
			// 
			this.eventView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.eventView.Location = new System.Drawing.Point(3, 3);
			this.eventView.MinimumSize = new System.Drawing.Size(633, 115);
			this.eventView.Name = "eventView";
			this.eventView.Size = new System.Drawing.Size(868, 359);
			this.eventView.TabIndex = 0;
			// 
			// contextMenuStripEvents
			// 
			this.contextMenuStripEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearEventsToolStripMenuItem});
			this.contextMenuStripEvents.Name = "contextMenuStripEvents";
			this.contextMenuStripEvents.Size = new System.Drawing.Size(139, 26);
			// 
			// openMarketDataLogFileToolStripButton
			// 
			this.openMarketDataLogFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openMarketDataLogFileToolStripButton.Image = global::ExchangeEmulator.Properties.Resources.FixAnalyser;
			this.openMarketDataLogFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openMarketDataLogFileToolStripButton.Name = "openMarketDataLogFileToolStripButton";
			this.openMarketDataLogFileToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openMarketDataLogFileToolStripButton.Text = "Open FIX Message log file";
			this.openMarketDataLogFileToolStripButton.Click += new System.EventHandler(this.openMarketDataLogFileToolStripButton_Click);
			// 
			// toolStripButtonConnect
			// 
			this.toolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonConnect.Image = global::ExchangeEmulator.Properties.Resources.Connect;
			this.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonConnect.Name = "toolStripButtonConnect";
			this.toolStripButtonConnect.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonConnect.Text = "Connect FIX Session";
			this.toolStripButtonConnect.Click += new System.EventHandler(this.toolStripButtonConnect_Click);
			// 
			// toolStripButtonDisconnect
			// 
			this.toolStripButtonDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonDisconnect.Image = global::ExchangeEmulator.Properties.Resources.Disconnect;
			this.toolStripButtonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonDisconnect.Name = "toolStripButtonDisconnect";
			this.toolStripButtonDisconnect.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonDisconnect.Text = "Disconnect FIX Session";
			this.toolStripButtonDisconnect.Click += new System.EventHandler(this.toolStripButtonDisconnect_Click);
			// 
			// openOrderLogFileToolStripButton
			// 
			this.openOrderLogFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openOrderLogFileToolStripButton.Image = global::ExchangeEmulator.Properties.Resources.FixAnalyser;
			this.openOrderLogFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openOrderLogFileToolStripButton.Name = "openOrderLogFileToolStripButton";
			this.openOrderLogFileToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openOrderLogFileToolStripButton.Text = "Open FIX Message log file";
			this.openOrderLogFileToolStripButton.Click += new System.EventHandler(this.openOrderLogFileToolStripButton_Click);
			// 
			// connectMarketDataSessionToolStripButton
			// 
			this.connectMarketDataSessionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.connectMarketDataSessionToolStripButton.Image = global::ExchangeEmulator.Properties.Resources.ConnectMarketData;
			this.connectMarketDataSessionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.connectMarketDataSessionToolStripButton.Name = "connectMarketDataSessionToolStripButton";
			this.connectMarketDataSessionToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.connectMarketDataSessionToolStripButton.Text = "toolStripButton1";
			this.connectMarketDataSessionToolStripButton.ToolTipText = "Connect Market Data FIX Session";
			this.connectMarketDataSessionToolStripButton.Click += new System.EventHandler(this.connectMarketDataSessionToolStripButton_Click);
			// 
			// disconnectMarketDataSessionToolStripButton
			// 
			this.disconnectMarketDataSessionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.disconnectMarketDataSessionToolStripButton.Image = global::ExchangeEmulator.Properties.Resources.DisconnectMarketData;
			this.disconnectMarketDataSessionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.disconnectMarketDataSessionToolStripButton.Name = "disconnectMarketDataSessionToolStripButton";
			this.disconnectMarketDataSessionToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.disconnectMarketDataSessionToolStripButton.Text = "toolStripButton2";
			this.disconnectMarketDataSessionToolStripButton.ToolTipText = "Disconnect Market Data FIX Session";
			this.disconnectMarketDataSessionToolStripButton.Click += new System.EventHandler(this.disconnectMarketDataSessionToolStripButton_Click);
			// 
			// toolStripButtonClearEventLog
			// 
			this.toolStripButtonClearEventLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonClearEventLog.Image = global::ExchangeEmulator.Properties.Resources.Trash;
			this.toolStripButtonClearEventLog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonClearEventLog.Name = "toolStripButtonClearEventLog";
			this.toolStripButtonClearEventLog.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonClearEventLog.Text = "Clear Events";
			// 
			// connectTradingSessionToolStripMenuItem
			// 
			this.connectTradingSessionToolStripMenuItem.Image = global::ExchangeEmulator.Properties.Resources.Connect;
			this.connectTradingSessionToolStripMenuItem.Name = "connectTradingSessionToolStripMenuItem";
			this.connectTradingSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.connectTradingSessionToolStripMenuItem.Text = "&Connect";
			this.connectTradingSessionToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
			// 
			// disconnectTradingSessionToolStripMenuItem
			// 
			this.disconnectTradingSessionToolStripMenuItem.Image = global::ExchangeEmulator.Properties.Resources.Disconnect;
			this.disconnectTradingSessionToolStripMenuItem.Name = "disconnectTradingSessionToolStripMenuItem";
			this.disconnectTradingSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.disconnectTradingSessionToolStripMenuItem.Text = "&Disconnect";
			this.disconnectTradingSessionToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
			// 
			// connectMarketDataSessionToolStripMenuItem
			// 
			this.connectMarketDataSessionToolStripMenuItem.Image = global::ExchangeEmulator.Properties.Resources.ConnectMarketData;
			this.connectMarketDataSessionToolStripMenuItem.Name = "connectMarketDataSessionToolStripMenuItem";
			this.connectMarketDataSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.connectMarketDataSessionToolStripMenuItem.Text = "&Connect";
			this.connectMarketDataSessionToolStripMenuItem.Click += new System.EventHandler(this.connectMarketDataSessionToolStripMenuItem_Click);
			// 
			// disconnectMarketDataSessionToolStripMenuItem
			// 
			this.disconnectMarketDataSessionToolStripMenuItem.Image = global::ExchangeEmulator.Properties.Resources.DisconnectMarketData;
			this.disconnectMarketDataSessionToolStripMenuItem.Name = "disconnectMarketDataSessionToolStripMenuItem";
			this.disconnectMarketDataSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.disconnectMarketDataSessionToolStripMenuItem.Text = "&Disconnect";
			this.disconnectMarketDataSessionToolStripMenuItem.Click += new System.EventHandler(this.disconnectMarketDataSessionToolStripMenuItem_Click);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Image = global::ExchangeEmulator.Properties.Resources.Trash;
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.clearToolStripMenuItem.Text = "&Clear";
			// 
			// clearEventsToolStripMenuItem
			// 
			this.clearEventsToolStripMenuItem.Image = global::ExchangeEmulator.Properties.Resources.Trash;
			this.clearEventsToolStripMenuItem.Name = "clearEventsToolStripMenuItem";
			this.clearEventsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.clearEventsToolStripMenuItem.Text = "&Clear Events";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(882, 462);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "Exchange Emulator Sample";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPaigeEvents.ResumeLayout(false);
			this.contextMenuStripEvents.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tradingSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectTradingSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem disconnectTradingSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
		private System.Windows.Forms.ToolStripStatusLabel tradingSessionStateToolStripLabel;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPaigeEvents;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButtonConnect;
		private System.Windows.Forms.ToolStripButton toolStripButtonDisconnect;
		private System.Windows.Forms.ToolStripMenuItem resetTradingSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButtonClearEventLog;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripEvents;
        private System.Windows.Forms.ToolStripMenuItem clearEventsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem emulationSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem replayLogFileTradingSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox modeToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem sessionsSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketDataSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectMarketDataSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectMarketDataSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetMarketDataSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton connectMarketDataSessionToolStripButton;
        private System.Windows.Forms.ToolStripButton disconnectMarketDataSessionToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel marketDataSessionStateToolStripLabel;
        private System.Windows.Forms.ToolStripMenuItem breakTradingConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem breakMarketDataConnectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem replayLogFileMarketDataSessionToolStripMenuItem;
        private Onixs.FixControls.EventViewUserControl eventView;
		private System.Windows.Forms.ToolStripButton openOrderLogFileToolStripButton;
		private System.Windows.Forms.ToolStripButton openMarketDataLogFileToolStripButton;
	}
}

