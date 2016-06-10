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

namespace TradingClientSample
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
			this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectTradingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disconnectTradingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetTradingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tradingSessionBreakConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.newOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.marketDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectMarketDataSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disconnectMarketDataSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.marketDataResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.marketDataBreakConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.subscribeSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unsubscribeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sessionsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.connectTradingSessionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.disconnectTradingSessionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openOrderLogFileToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonNewOrder = new System.Windows.Forms.ToolStripButton();
			this.modifyOrderToolBarButton = new System.Windows.Forms.ToolStripButton();
			this.cancelOrderToolBarButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.connectMarketDataSessionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.disconnectMarketDataSessionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openMarketDataLogFileToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.subscribeSymbolToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.unsubscribeToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonClearEventLog = new System.Windows.Forms.ToolStripButton();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tradingSessionStateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.marketDataSessionStateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageEvents = new System.Windows.Forms.TabPage();
			this.eventView = new Onixs.FixControls.EventViewUserControl();
			this.tabPageOrders = new System.Windows.Forms.TabPage();
			this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
			this.columnClientOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnCumQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnLastPx = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenuStripOrders = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newOrderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.modifyOrderContextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelOrderContextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageMarketData = new System.Windows.Forms.TabPage();
			this.contextMenuStripEvents = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.clearEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageSecurityDefinitions = new System.Windows.Forms.TabPage();
			this.tabPageTrades = new System.Windows.Forms.TabPage();
			this.marketDataView = new TradingClientSample.MarketDataViewControl();
			this.securityDefinitionsViewControl = new TradingClientSample.SecurityDefinitionsViewControl();
			this.tradesViewControl = new TradingClientSample.TradesViewControl();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageEvents.SuspendLayout();
			this.tabPageOrders.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
			this.contextMenuStripOrders.SuspendLayout();
			this.tabPageMarketData.SuspendLayout();
			this.contextMenuStripEvents.SuspendLayout();
			this.tabPageSecurityDefinitions.SuspendLayout();
			this.tabPageTrades.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripStatusLabel1
			// 
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(93, 17);
			toolStripStatusLabel1.Text = "Trading Session:";
			// 
			// toolStripStatusLabel2
			// 
			toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			toolStripStatusLabel2.Size = new System.Drawing.Size(116, 17);
			toolStripStatusLabel2.Text = "Market Data Session:";
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sessionToolStripMenuItem,
            this.marketDataToolStripMenuItem,
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
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// sessionToolStripMenuItem
			// 
			this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectTradingSessionToolStripMenuItem,
            this.disconnectTradingSessionToolStripMenuItem,
            this.resetTradingSessionToolStripMenuItem,
            this.tradingSessionBreakConnectionToolStripMenuItem,
            this.toolStripSeparator3,
            this.newOrderToolStripMenuItem,
            this.cancelOrderToolStripMenuItem});
			this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
			this.sessionToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.sessionToolStripMenuItem.Text = "&Trading";
			// 
			// connectTradingSessionToolStripMenuItem
			// 
			this.connectTradingSessionToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.Connect;
			this.connectTradingSessionToolStripMenuItem.Name = "connectTradingSessionToolStripMenuItem";
			this.connectTradingSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.connectTradingSessionToolStripMenuItem.Text = "&Connect";
			this.connectTradingSessionToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
			// 
			// disconnectTradingSessionToolStripMenuItem
			// 
			this.disconnectTradingSessionToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.Disconnect;
			this.disconnectTradingSessionToolStripMenuItem.Name = "disconnectTradingSessionToolStripMenuItem";
			this.disconnectTradingSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.disconnectTradingSessionToolStripMenuItem.Text = "&Disconnect";
			this.disconnectTradingSessionToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
			// 
			// resetTradingSessionToolStripMenuItem
			// 
			this.resetTradingSessionToolStripMenuItem.Name = "resetTradingSessionToolStripMenuItem";
			this.resetTradingSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.resetTradingSessionToolStripMenuItem.Text = "&Reset";
			this.resetTradingSessionToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// tradingSessionBreakConnectionToolStripMenuItem
			// 
			this.tradingSessionBreakConnectionToolStripMenuItem.Name = "tradingSessionBreakConnectionToolStripMenuItem";
			this.tradingSessionBreakConnectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.tradingSessionBreakConnectionToolStripMenuItem.Text = "&Break Connection";
			this.tradingSessionBreakConnectionToolStripMenuItem.Click += new System.EventHandler(this.breakConnectionToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
			// 
			// newOrderToolStripMenuItem
			// 
			this.newOrderToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.AddDocument;
			this.newOrderToolStripMenuItem.Name = "newOrderToolStripMenuItem";
			this.newOrderToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.newOrderToolStripMenuItem.Text = "&New Order";
			this.newOrderToolStripMenuItem.Click += new System.EventHandler(this.newOrderToolStripMenuItem2_Click);
			// 
			// cancelOrderToolStripMenuItem
			// 
			this.cancelOrderToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.DeleteDocument;
			this.cancelOrderToolStripMenuItem.Name = "cancelOrderToolStripMenuItem";
			this.cancelOrderToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.cancelOrderToolStripMenuItem.Text = "&Cancel Order";
			this.cancelOrderToolStripMenuItem.Click += new System.EventHandler(this.cancelOrderToolStripMenuItem1_Click);
			// 
			// marketDataToolStripMenuItem
			// 
			this.marketDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectMarketDataSessionToolStripMenuItem,
            this.disconnectMarketDataSessionToolStripMenuItem,
            this.marketDataResetToolStripMenuItem,
            this.marketDataBreakConnectionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.subscribeSymbolToolStripMenuItem,
            this.unsubscribeToolStripMenuItem});
			this.marketDataToolStripMenuItem.Name = "marketDataToolStripMenuItem";
			this.marketDataToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
			this.marketDataToolStripMenuItem.Text = "&Market Data";
			// 
			// connectMarketDataSessionToolStripMenuItem
			// 
			this.connectMarketDataSessionToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.ConnectMarketData;
			this.connectMarketDataSessionToolStripMenuItem.Name = "connectMarketDataSessionToolStripMenuItem";
			this.connectMarketDataSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.connectMarketDataSessionToolStripMenuItem.Text = "&Connect";
			this.connectMarketDataSessionToolStripMenuItem.Click += new System.EventHandler(this.connectMarketDataSessionToolStripMenuItem_Click);
			// 
			// disconnectMarketDataSessionToolStripMenuItem
			// 
			this.disconnectMarketDataSessionToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.DisconnectMarketData;
			this.disconnectMarketDataSessionToolStripMenuItem.Name = "disconnectMarketDataSessionToolStripMenuItem";
			this.disconnectMarketDataSessionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.disconnectMarketDataSessionToolStripMenuItem.Text = "&Disconnect";
			this.disconnectMarketDataSessionToolStripMenuItem.Click += new System.EventHandler(this.disconnectMarketDataSessionToolStripMenuItem_Click);
			// 
			// marketDataResetToolStripMenuItem
			// 
			this.marketDataResetToolStripMenuItem.Name = "marketDataResetToolStripMenuItem";
			this.marketDataResetToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.marketDataResetToolStripMenuItem.Text = "&Reset";
			this.marketDataResetToolStripMenuItem.Click += new System.EventHandler(this.marketDataResetToolStripMenuItem_Click);
			// 
			// marketDataBreakConnectionToolStripMenuItem
			// 
			this.marketDataBreakConnectionToolStripMenuItem.Name = "marketDataBreakConnectionToolStripMenuItem";
			this.marketDataBreakConnectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.marketDataBreakConnectionToolStripMenuItem.Text = "&Break Connection";
			this.marketDataBreakConnectionToolStripMenuItem.Click += new System.EventHandler(this.marketDataBreakConnectionToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
			// 
			// subscribeSymbolToolStripMenuItem
			// 
			this.subscribeSymbolToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.SubscribeSymbol;
			this.subscribeSymbolToolStripMenuItem.Name = "subscribeSymbolToolStripMenuItem";
			this.subscribeSymbolToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.subscribeSymbolToolStripMenuItem.Text = "&Subscribe...";
			this.subscribeSymbolToolStripMenuItem.Click += new System.EventHandler(this.subscribeToolStripMenuItem_Click);
			// 
			// unsubscribeToolStripMenuItem
			// 
			this.unsubscribeToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.DeleteDocument;
			this.unsubscribeToolStripMenuItem.Name = "unsubscribeToolStripMenuItem";
			this.unsubscribeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.unsubscribeToolStripMenuItem.Text = "&Unsubscribe";
			this.unsubscribeToolStripMenuItem.Click += new System.EventHandler(this.unsubscribeToolStripMenuItem_Click);
			// 
			// eventsToolStripMenuItem
			// 
			this.eventsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
			this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
			this.eventsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.eventsToolStripMenuItem.Text = "&Events";
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.Trash;
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
			this.clearToolStripMenuItem.Text = "&Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionsSettingsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// sessionsSettingsToolStripMenuItem
			// 
			this.sessionsSettingsToolStripMenuItem.Name = "sessionsSettingsToolStripMenuItem";
			this.sessionsSettingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
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
            this.connectTradingSessionToolStripButton,
            this.disconnectTradingSessionToolStripButton,
            this.openOrderLogFileToolStripButton,
            this.toolStripSeparator1,
            this.toolStripButtonNewOrder,
            this.modifyOrderToolBarButton,
            this.cancelOrderToolBarButton,
            this.toolStripSeparator4,
            this.connectMarketDataSessionToolStripButton,
            this.disconnectMarketDataSessionToolStripButton,
            this.openMarketDataLogFileToolStripButton,
            this.toolStripSeparator2,
            this.subscribeSymbolToolStripButton,
            this.unsubscribeToolStripButton,
            this.toolStripSeparator6,
            this.toolStripButtonClearEventLog});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(882, 25);
			this.toolStrip.TabIndex = 1;
			// 
			// connectTradingSessionToolStripButton
			// 
			this.connectTradingSessionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.connectTradingSessionToolStripButton.Image = global::TradingClientSample.Properties.Resources.Connect;
			this.connectTradingSessionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.connectTradingSessionToolStripButton.Name = "connectTradingSessionToolStripButton";
			this.connectTradingSessionToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.connectTradingSessionToolStripButton.Text = "Connect";
			this.connectTradingSessionToolStripButton.ToolTipText = "Connect Trading FIX Session";
			this.connectTradingSessionToolStripButton.Click += new System.EventHandler(this.toolStripButtonConnect_Click);
			// 
			// disconnectTradingSessionToolStripButton
			// 
			this.disconnectTradingSessionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.disconnectTradingSessionToolStripButton.Image = global::TradingClientSample.Properties.Resources.Disconnect;
			this.disconnectTradingSessionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.disconnectTradingSessionToolStripButton.Name = "disconnectTradingSessionToolStripButton";
			this.disconnectTradingSessionToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.disconnectTradingSessionToolStripButton.Text = "toolStripButtonDisconnect";
			this.disconnectTradingSessionToolStripButton.ToolTipText = "Terminate FIX Session";
			this.disconnectTradingSessionToolStripButton.Click += new System.EventHandler(this.toolStripButtonDisconnect_Click);
			// 
			// openOrderLogFileToolStripButton
			// 
			this.openOrderLogFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openOrderLogFileToolStripButton.Image = global::TradingClientSample.Properties.Resources.FixAnalyser;
			this.openOrderLogFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openOrderLogFileToolStripButton.Name = "openOrderLogFileToolStripButton";
			this.openOrderLogFileToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openOrderLogFileToolStripButton.Text = "Open FIX Message log file";
			this.openOrderLogFileToolStripButton.Click += new System.EventHandler(this.openOrderLogFileToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonNewOrder
			// 
			this.toolStripButtonNewOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonNewOrder.Image = global::TradingClientSample.Properties.Resources.AddDocument;
			this.toolStripButtonNewOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonNewOrder.Name = "toolStripButtonNewOrder";
			this.toolStripButtonNewOrder.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonNewOrder.Text = "New Odrer";
			this.toolStripButtonNewOrder.Click += new System.EventHandler(this.toolStripButtonNewOrder_Click);
			// 
			// modifyOrderToolBarButton
			// 
			this.modifyOrderToolBarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.modifyOrderToolBarButton.Image = ((System.Drawing.Image)(resources.GetObject("modifyOrderToolBarButton.Image")));
			this.modifyOrderToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.modifyOrderToolBarButton.Name = "modifyOrderToolBarButton";
			this.modifyOrderToolBarButton.Size = new System.Drawing.Size(23, 22);
			this.modifyOrderToolBarButton.Text = "toolStripButton1";
			this.modifyOrderToolBarButton.ToolTipText = "Modify Order";
			this.modifyOrderToolBarButton.Click += new System.EventHandler(this.modifyOrderToolBarButton_Click);
			// 
			// cancelOrderToolBarButton
			// 
			this.cancelOrderToolBarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cancelOrderToolBarButton.Image = global::TradingClientSample.Properties.Resources.DeleteDocument;
			this.cancelOrderToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cancelOrderToolBarButton.Name = "cancelOrderToolBarButton";
			this.cancelOrderToolBarButton.Size = new System.Drawing.Size(23, 22);
			this.cancelOrderToolBarButton.Text = "Cancel Order";
			this.cancelOrderToolBarButton.Click += new System.EventHandler(this.toolStripButtonCancelOrder_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// connectMarketDataSessionToolStripButton
			// 
			this.connectMarketDataSessionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.connectMarketDataSessionToolStripButton.Image = global::TradingClientSample.Properties.Resources.ConnectMarketData;
			this.connectMarketDataSessionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.connectMarketDataSessionToolStripButton.Name = "connectMarketDataSessionToolStripButton";
			this.connectMarketDataSessionToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.connectMarketDataSessionToolStripButton.Text = "Connet Market Data FIX Session";
			this.connectMarketDataSessionToolStripButton.ToolTipText = "Connect Market Data FIX Session";
			this.connectMarketDataSessionToolStripButton.Click += new System.EventHandler(this.connectMarketDataSessionToolStripButton_Click);
			// 
			// disconnectMarketDataSessionToolStripButton
			// 
			this.disconnectMarketDataSessionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.disconnectMarketDataSessionToolStripButton.Enabled = false;
			this.disconnectMarketDataSessionToolStripButton.Image = global::TradingClientSample.Properties.Resources.DisconnectMarketData;
			this.disconnectMarketDataSessionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.disconnectMarketDataSessionToolStripButton.Name = "disconnectMarketDataSessionToolStripButton";
			this.disconnectMarketDataSessionToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.disconnectMarketDataSessionToolStripButton.Text = "Disconnet Market Data FIX Session";
			this.disconnectMarketDataSessionToolStripButton.Click += new System.EventHandler(this.disconnectMarketDataSessionToolStripButton_Click);
			// 
			// openMarketDataLogFileToolStripButton
			// 
			this.openMarketDataLogFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openMarketDataLogFileToolStripButton.Image = global::TradingClientSample.Properties.Resources.FixAnalyser;
			this.openMarketDataLogFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openMarketDataLogFileToolStripButton.Name = "openMarketDataLogFileToolStripButton";
			this.openMarketDataLogFileToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openMarketDataLogFileToolStripButton.Text = "Open FIX Message log file";
			this.openMarketDataLogFileToolStripButton.Click += new System.EventHandler(this.openMarketDataLogFileToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// subscribeSymbolToolStripButton
			// 
			this.subscribeSymbolToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.subscribeSymbolToolStripButton.Image = global::TradingClientSample.Properties.Resources.SubscribeSymbol;
			this.subscribeSymbolToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.subscribeSymbolToolStripButton.Name = "subscribeSymbolToolStripButton";
			this.subscribeSymbolToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.subscribeSymbolToolStripButton.Text = "Subscribe Symbol";
			this.subscribeSymbolToolStripButton.Click += new System.EventHandler(this.subscribeSymbolToolStripButton_Click);
			// 
			// unsubscribeToolStripButton
			// 
			this.unsubscribeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.unsubscribeToolStripButton.Image = global::TradingClientSample.Properties.Resources.DeleteDocument;
			this.unsubscribeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.unsubscribeToolStripButton.Name = "unsubscribeToolStripButton";
			this.unsubscribeToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.unsubscribeToolStripButton.Click += new System.EventHandler(this.unsubscribeToolStripButton_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonClearEventLog
			// 
			this.toolStripButtonClearEventLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonClearEventLog.Image = global::TradingClientSample.Properties.Resources.Trash;
			this.toolStripButtonClearEventLog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonClearEventLog.Name = "toolStripButtonClearEventLog";
			this.toolStripButtonClearEventLog.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonClearEventLog.Text = "Clear Events";
			this.toolStripButtonClearEventLog.Click += new System.EventHandler(this.toolStripButtonClearEventLog_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus,
            toolStripStatusLabel1,
            this.tradingSessionStateToolStripStatusLabel,
            toolStripStatusLabel2,
            this.marketDataSessionStateToolStripStatusLabel});
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
			// tradingSessionStateToolStripStatusLabel
			// 
			this.tradingSessionStateToolStripStatusLabel.AutoSize = false;
			this.tradingSessionStateToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.tradingSessionStateToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
			this.tradingSessionStateToolStripStatusLabel.Name = "tradingSessionStateToolStripStatusLabel";
			this.tradingSessionStateToolStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.tradingSessionStateToolStripStatusLabel.Size = new System.Drawing.Size(160, 17);
			this.tradingSessionStateToolStripStatusLabel.Text = "DISCONNECTED";
			this.tradingSessionStateToolStripStatusLabel.ToolTipText = "FIX Session State";
			// 
			// marketDataSessionStateToolStripStatusLabel
			// 
			this.marketDataSessionStateToolStripStatusLabel.AutoSize = false;
			this.marketDataSessionStateToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.marketDataSessionStateToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
			this.marketDataSessionStateToolStripStatusLabel.Name = "marketDataSessionStateToolStripStatusLabel";
			this.marketDataSessionStateToolStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.marketDataSessionStateToolStripStatusLabel.Size = new System.Drawing.Size(160, 17);
			this.marketDataSessionStateToolStripStatusLabel.Text = "DISCONNECTED";
			this.marketDataSessionStateToolStripStatusLabel.ToolTipText = "FIX Session State";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageEvents);
			this.tabControl.Controls.Add(this.tabPageOrders);
			this.tabControl.Controls.Add(this.tabPageSecurityDefinitions);
			this.tabControl.Controls.Add(this.tabPageMarketData);
			this.tabControl.Controls.Add(this.tabPageTrades);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 49);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(882, 391);
			this.tabControl.TabIndex = 3;
			// 
			// tabPageEvents
			// 
			this.tabPageEvents.Controls.Add(this.eventView);
			this.tabPageEvents.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabPageEvents.Location = new System.Drawing.Point(4, 22);
			this.tabPageEvents.Name = "tabPageEvents";
			this.tabPageEvents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageEvents.Size = new System.Drawing.Size(874, 365);
			this.tabPageEvents.TabIndex = 1;
			this.tabPageEvents.Text = "Events";
			this.tabPageEvents.UseVisualStyleBackColor = true;
			// 
			// eventView
			// 
			this.eventView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.eventView.Location = new System.Drawing.Point(3, 3);
			this.eventView.MinimumSize = new System.Drawing.Size(543, 100);
			this.eventView.Name = "eventView";
			this.eventView.Size = new System.Drawing.Size(868, 359);
			this.eventView.TabIndex = 0;
			// 
			// tabPageOrders
			// 
			this.tabPageOrders.Controls.Add(this.dataGridViewOrders);
			this.tabPageOrders.Location = new System.Drawing.Point(4, 22);
			this.tabPageOrders.Name = "tabPageOrders";
			this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageOrders.Size = new System.Drawing.Size(874, 365);
			this.tabPageOrders.TabIndex = 0;
			this.tabPageOrders.Text = "Orders";
			this.tabPageOrders.UseVisualStyleBackColor = true;
			// 
			// dataGridViewOrders
			// 
			this.dataGridViewOrders.AllowUserToAddRows = false;
			this.dataGridViewOrders.AllowUserToDeleteRows = false;
			this.dataGridViewOrders.AllowUserToOrderColumns = true;
			this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnClientOrderID,
            this.columnText,
            this.columnOrderID,
            this.columnOrderStatus,
            this.columnSymbol,
            this.columnSide,
            this.columnOrderType,
            this.columnQuantity,
            this.columnPrice,
            this.columnCumQty,
            this.columnLastPx});
			this.dataGridViewOrders.ContextMenuStrip = this.contextMenuStripOrders;
			this.dataGridViewOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewOrders.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewOrders.MultiSelect = false;
			this.dataGridViewOrders.Name = "dataGridViewOrders";
			this.dataGridViewOrders.ReadOnly = true;
			this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewOrders.Size = new System.Drawing.Size(868, 359);
			this.dataGridViewOrders.TabIndex = 0;
			this.dataGridViewOrders.SelectionChanged += new System.EventHandler(this.dataGridViewOrders_SelectionChanged);
			// 
			// columnClientOrderID
			// 
			this.columnClientOrderID.HeaderText = "Client Order ID";
			this.columnClientOrderID.Name = "columnClientOrderID";
			this.columnClientOrderID.ReadOnly = true;
			this.columnClientOrderID.ToolTipText = "ClOrdID (11) field - unique identifier for Order as assigned by institution";
			// 
			// columnText
			// 
			this.columnText.HeaderText = "Text";
			this.columnText.Name = "columnText";
			this.columnText.ReadOnly = true;
			this.columnText.ToolTipText = "Field Text (58) - Free format text string.";
			this.columnText.Width = 50;
			// 
			// columnOrderID
			// 
			this.columnOrderID.HeaderText = "Broker Order ID";
			this.columnOrderID.Name = "columnOrderID";
			this.columnOrderID.ReadOnly = true;
			this.columnOrderID.ToolTipText = "OrderID (37) field - unique identifier for Order as assigned by broker";
			// 
			// columnOrderStatus
			// 
			this.columnOrderStatus.HeaderText = "Order Status";
			this.columnOrderStatus.Name = "columnOrderStatus";
			this.columnOrderStatus.ReadOnly = true;
			this.columnOrderStatus.Width = 70;
			// 
			// columnSymbol
			// 
			this.columnSymbol.HeaderText = "Symbol";
			this.columnSymbol.Name = "columnSymbol";
			this.columnSymbol.ReadOnly = true;
			this.columnSymbol.Width = 80;
			// 
			// columnSide
			// 
			this.columnSide.HeaderText = "Side";
			this.columnSide.Name = "columnSide";
			this.columnSide.ReadOnly = true;
			this.columnSide.Width = 50;
			// 
			// columnOrderType
			// 
			this.columnOrderType.HeaderText = "Order Type";
			this.columnOrderType.Name = "columnOrderType";
			this.columnOrderType.ReadOnly = true;
			this.columnOrderType.Width = 50;
			// 
			// columnQuantity
			// 
			this.columnQuantity.HeaderText = "Quantity";
			this.columnQuantity.Name = "columnQuantity";
			this.columnQuantity.ReadOnly = true;
			this.columnQuantity.Width = 70;
			// 
			// columnPrice
			// 
			this.columnPrice.HeaderText = "Price";
			this.columnPrice.Name = "columnPrice";
			this.columnPrice.ReadOnly = true;
			this.columnPrice.Width = 70;
			// 
			// columnCumQty
			// 
			this.columnCumQty.HeaderText = "Filled Quantity";
			this.columnCumQty.Name = "columnCumQty";
			this.columnCumQty.ReadOnly = true;
			this.columnCumQty.ToolTipText = "CumQty (14) field - total number of shares filled";
			this.columnCumQty.Width = 70;
			// 
			// columnLastPx
			// 
			this.columnLastPx.HeaderText = "Last Fill Price";
			this.columnLastPx.Name = "columnLastPx";
			this.columnLastPx.ReadOnly = true;
			this.columnLastPx.ToolTipText = "LastPx (31) field - price of last fill";
			this.columnLastPx.Width = 70;
			// 
			// contextMenuStripOrders
			// 
			this.contextMenuStripOrders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newOrderToolStripMenuItem1,
            this.modifyOrderContextToolStripMenuItem,
            this.cancelOrderContextToolStripMenuItem});
			this.contextMenuStripOrders.Name = "contextMenuStripOrders";
			this.contextMenuStripOrders.Size = new System.Drawing.Size(146, 70);
			this.contextMenuStripOrders.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripOrders_Opening);
			// 
			// newOrderToolStripMenuItem1
			// 
			this.newOrderToolStripMenuItem1.Image = global::TradingClientSample.Properties.Resources.AddDocument;
			this.newOrderToolStripMenuItem1.Name = "newOrderToolStripMenuItem1";
			this.newOrderToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
			this.newOrderToolStripMenuItem1.Text = "&New Order";
			this.newOrderToolStripMenuItem1.Click += new System.EventHandler(this.newOrderToolStripMenuItem1_Click);
			// 
			// modifyOrderContextToolStripMenuItem
			// 
			this.modifyOrderContextToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.EditDocument;
			this.modifyOrderContextToolStripMenuItem.Name = "modifyOrderContextToolStripMenuItem";
			this.modifyOrderContextToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.modifyOrderContextToolStripMenuItem.Text = "Modify Order";
			this.modifyOrderContextToolStripMenuItem.Click += new System.EventHandler(this.modifyOrderContextToolStripMenuItem_Click);
			// 
			// cancelOrderContextToolStripMenuItem
			// 
			this.cancelOrderContextToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.DeleteDocument;
			this.cancelOrderContextToolStripMenuItem.Name = "cancelOrderContextToolStripMenuItem";
			this.cancelOrderContextToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.cancelOrderContextToolStripMenuItem.Text = "&Cancel Order";
			this.cancelOrderContextToolStripMenuItem.Click += new System.EventHandler(this.cancelOrderContextToolStripMenuItem_Click);
			// 
			// tabPageMarketData
			// 
			this.tabPageMarketData.Controls.Add(this.marketDataView);
			this.tabPageMarketData.Location = new System.Drawing.Point(4, 22);
			this.tabPageMarketData.Name = "tabPageMarketData";
			this.tabPageMarketData.Size = new System.Drawing.Size(874, 365);
			this.tabPageMarketData.TabIndex = 2;
			this.tabPageMarketData.Text = "Market Data";
			this.tabPageMarketData.UseVisualStyleBackColor = true;
			// 
			// contextMenuStripEvents
			// 
			this.contextMenuStripEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearEventsToolStripMenuItem});
			this.contextMenuStripEvents.Name = "contextMenuStripEvents";
			this.contextMenuStripEvents.Size = new System.Drawing.Size(139, 26);
			// 
			// clearEventsToolStripMenuItem
			// 
			this.clearEventsToolStripMenuItem.Image = global::TradingClientSample.Properties.Resources.Trash;
			this.clearEventsToolStripMenuItem.Name = "clearEventsToolStripMenuItem";
			this.clearEventsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.clearEventsToolStripMenuItem.Text = "&Clear Events";
			this.clearEventsToolStripMenuItem.Click += new System.EventHandler(this.clearEventsToolStripMenuItem_Click);
			// 
			// tabPageSecurityDefinitions
			// 
			this.tabPageSecurityDefinitions.Controls.Add(this.securityDefinitionsViewControl);
			this.tabPageSecurityDefinitions.Location = new System.Drawing.Point(4, 22);
			this.tabPageSecurityDefinitions.Name = "tabPageSecurityDefinitions";
			this.tabPageSecurityDefinitions.Size = new System.Drawing.Size(874, 365);
			this.tabPageSecurityDefinitions.TabIndex = 3;
			this.tabPageSecurityDefinitions.Text = "Security Definitions";
			this.tabPageSecurityDefinitions.UseVisualStyleBackColor = true;
			// 
			// tabPageTrades
			// 
			this.tabPageTrades.Controls.Add(this.tradesViewControl);
			this.tabPageTrades.Location = new System.Drawing.Point(4, 22);
			this.tabPageTrades.Name = "tabPageTrades";
			this.tabPageTrades.Size = new System.Drawing.Size(874, 365);
			this.tabPageTrades.TabIndex = 4;
			this.tabPageTrades.Text = "Trades";
			this.tabPageTrades.UseVisualStyleBackColor = true;
			// 
			// marketDataView
			// 
			this.marketDataView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.marketDataView.Location = new System.Drawing.Point(0, 0);
			this.marketDataView.Name = "marketDataView";
			this.marketDataView.Size = new System.Drawing.Size(874, 365);
			this.marketDataView.TabIndex = 0;
			// 
			// securityDefinitionsViewControl
			// 
			this.securityDefinitionsViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.securityDefinitionsViewControl.Location = new System.Drawing.Point(0, 0);
			this.securityDefinitionsViewControl.Name = "securityDefinitionsViewControl";
			this.securityDefinitionsViewControl.Size = new System.Drawing.Size(874, 365);
			this.securityDefinitionsViewControl.TabIndex = 0;
			// 
			// tradesViewControl
			// 
			this.tradesViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tradesViewControl.Location = new System.Drawing.Point(0, 0);
			this.tradesViewControl.Name = "tradesViewControl";
			this.tradesViewControl.Size = new System.Drawing.Size(874, 365);
			this.tradesViewControl.TabIndex = 0;
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
			this.Text = "Trading Client SAMPLE";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageEvents.ResumeLayout(false);
			this.tabPageOrders.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
			this.contextMenuStripOrders.ResumeLayout(false);
			this.tabPageMarketData.ResumeLayout(false);
			this.contextMenuStripEvents.ResumeLayout(false);
			this.tabPageSecurityDefinitions.ResumeLayout(false);
			this.tabPageTrades.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectTradingSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem disconnectTradingSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
		private System.Windows.Forms.ToolStripStatusLabel tradingSessionStateToolStripStatusLabel;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageOrders;
		private System.Windows.Forms.TabPage tabPageEvents;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
		private System.Windows.Forms.ToolStripButton toolStripButtonNewOrder;
		private System.Windows.Forms.ToolStripButton cancelOrderToolBarButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton connectTradingSessionToolStripButton;
        private System.Windows.Forms.ToolStripButton disconnectTradingSessionToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem resetTradingSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearEventLog;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripOrders;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripEvents;
		private System.Windows.Forms.ToolStripMenuItem clearEventsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newOrderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelOrderContextToolStripMenuItem;

#endregion

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton modifyOrderToolBarButton;
        private System.Windows.Forms.ToolStripMenuItem modifyOrderContextToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnClientOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnText;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSide;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCumQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLastPx;
        private System.Windows.Forms.TabPage tabPageMarketData;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionsSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectMarketDataSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectMarketDataSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton connectMarketDataSessionToolStripButton;
        private System.Windows.Forms.ToolStripButton disconnectMarketDataSessionToolStripButton;
        private MarketDataViewControl marketDataView;
        private System.Windows.Forms.ToolStripStatusLabel marketDataSessionStateToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem newOrderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cancelOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscribeSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton subscribeSymbolToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tradingSessionBreakConnectionToolStripMenuItem;
        private Onixs.FixControls.EventViewUserControl eventView;
        private System.Windows.Forms.ToolStripButton openOrderLogFileToolStripButton;
		private System.Windows.Forms.ToolStripButton openMarketDataLogFileToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem marketDataResetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem marketDataBreakConnectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem unsubscribeToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton unsubscribeToolStripButton;
		private System.Windows.Forms.TabPage tabPageSecurityDefinitions;
		private System.Windows.Forms.TabPage tabPageTrades;
		private SecurityDefinitionsViewControl securityDefinitionsViewControl;
		private TradesViewControl tradesViewControl;

    }
}

