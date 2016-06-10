' Copyright Onix Solutions Limited [OnixS]. All rights reserved.
'
' This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
' and international copyright treaties.
'
' Access to and use of the software is governed by the terms of the applicable ONIXS Software
' Services Agreement (the Agreement) and Customer end user license agreements granting
' a non-assignable, non-transferable and non-exclusive license to use the software
' for it's own data processing purposes under the terms defined in the Agreement.
'
' Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
' of this source code or associated reference material to any other location for further reproduction
' or redistribution, and any amendments to this copyright notice, are expressly prohibited.
'
' Any reproduction or redistribution for sale or hiring of the Software not in accordance with
' the terms of the Agreement is a violation of copyright law.

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Configuration
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports FIXForge.NET.FIX
Imports FF = FIXForge.NET.FIX
Imports FIXForge.NET.FIX.FIX44
Imports FIX44 = FIXForge.NET.FIX.FIX44
Imports Message = FIXForge.NET.FIX.Message


Namespace Biz.Onixs.TradingClientSample
   
   Public Class MainForm
      Inherits Form
      
      '/ <summary>
      '/ Required designer variable.
      '/ </summary>
      Private components As System.ComponentModel.IContainer = Nothing
      
      
      '/ <summary>
      '/ Clean up any resources being used.
      '/ </summary>
      '/ <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso Not (components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose
      
      #Region "Windows Form Designer generated code"
      
      
      '/ <summary>
      '/ Required method for Designer support - do not modify
      '/ the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
            Me.menuStrip = New System.Windows.Forms.MenuStrip
            Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.sessionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.connectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.disconnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.resetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
            Me.settingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ordersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.newOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.cancelOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.eventsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.clearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStrip = New System.Windows.Forms.ToolStrip
            Me.toolStripButtonConnect = New System.Windows.Forms.ToolStripButton
            Me.toolStripButtonDisconnect = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripButtonNewOrder = New System.Windows.Forms.ToolStripButton
            Me.toolStripButtonCancelOrder = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripButtonClearEventLog = New System.Windows.Forms.ToolStripButton
            Me.statusStrip = New System.Windows.Forms.StatusStrip
            Me.toolStripStatusLabelStatus = New System.Windows.Forms.ToolStripStatusLabel
            Me.toolStripStatusLabelSessionState = New System.Windows.Forms.ToolStripStatusLabel
            Me.tabControl = New System.Windows.Forms.TabControl
            Me.tabPageOrders = New System.Windows.Forms.TabPage
            Me.dataGridViewOrders = New System.Windows.Forms.DataGridView
            Me.columnClOrdID = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.columnOrderID = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.columnOrderStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.columnSymbol = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.columnSide = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.columnOrderType = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.columnQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.columnPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.columnCumQty = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.columnAvgPx = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.contextMenuStripOrders = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.newOrderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
            Me.cancelOrderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
            Me.tabPaigeEvents = New System.Windows.Forms.TabPage
            Me.daTagsridViewEventLog = New System.Windows.Forms.DataGridView
            Me.columnEventLogIcon = New System.Windows.Forms.DataGridViewImageColumn
            Me.columnEvent = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.contextMenuStripEvents = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.clearEventsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.menuStrip.SuspendLayout()
            Me.toolStrip.SuspendLayout()
            Me.statusStrip.SuspendLayout()
            Me.tabControl.SuspendLayout()
            Me.tabPageOrders.SuspendLayout()
            CType(Me.dataGridViewOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.contextMenuStripOrders.SuspendLayout()
            Me.tabPaigeEvents.SuspendLayout()
            CType(Me.daTagsridViewEventLog, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.contextMenuStripEvents.SuspendLayout()
            Me.SuspendLayout()
            '
            'menuStrip
            '
            Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.sessionToolStripMenuItem, Me.ordersToolStripMenuItem, Me.eventsToolStripMenuItem, Me.helpToolStripMenuItem})
            Me.menuStrip.Location = New System.Drawing.Point(0, 0)
            Me.menuStrip.Name = "menuStrip"
            Me.menuStrip.Size = New System.Drawing.Size(882, 24)
            Me.menuStrip.TabIndex = 0
            '
            'fileToolStripMenuItem
            '
            Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exitToolStripMenuItem})
            Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
            Me.fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
            Me.fileToolStripMenuItem.Text = "&File"
            '
            'exitToolStripMenuItem
            '
            Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
            Me.exitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
            Me.exitToolStripMenuItem.Text = "E&xit"
            '
            'sessionToolStripMenuItem
            '
            Me.sessionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.connectToolStripMenuItem, Me.disconnectToolStripMenuItem, Me.resetToolStripMenuItem, Me.toolStripMenuItem2, Me.settingsToolStripMenuItem})
            Me.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem"
            Me.sessionToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
            Me.sessionToolStripMenuItem.Text = "&Session"
            '
            'connectToolStripMenuItem
            '
            Me.connectToolStripMenuItem.Name = "connectToolStripMenuItem"
            Me.connectToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
            Me.connectToolStripMenuItem.Text = "&Connect"
            '
            'disconnectToolStripMenuItem
            '
            Me.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem"
            Me.disconnectToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
            Me.disconnectToolStripMenuItem.Text = "&Disconnect"
            '
            'resetToolStripMenuItem
            '
            Me.resetToolStripMenuItem.Name = "resetToolStripMenuItem"
            Me.resetToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
            Me.resetToolStripMenuItem.Text = "&Reset"
            '
            'toolStripMenuItem2
            '
            Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
            Me.toolStripMenuItem2.Size = New System.Drawing.Size(134, 6)
            '
            'settingsToolStripMenuItem
            '
            Me.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem"
            Me.settingsToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
            Me.settingsToolStripMenuItem.Text = "&Settings"
            '
            'ordersToolStripMenuItem
            '
            Me.ordersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newOrderToolStripMenuItem, Me.cancelOrderToolStripMenuItem})
            Me.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem"
            Me.ordersToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
            Me.ordersToolStripMenuItem.Text = "&Orders"
            '
            'newOrderToolStripMenuItem
            '
            Me.newOrderToolStripMenuItem.Name = "newOrderToolStripMenuItem"
            Me.newOrderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
            Me.newOrderToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
            Me.newOrderToolStripMenuItem.Text = "&New Order"
            '
            'cancelOrderToolStripMenuItem
            '
            Me.cancelOrderToolStripMenuItem.Name = "cancelOrderToolStripMenuItem"
            Me.cancelOrderToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
            Me.cancelOrderToolStripMenuItem.Text = "&Cancel Order"
            '
            'eventsToolStripMenuItem
            '
            Me.eventsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.clearToolStripMenuItem})
            Me.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem"
            Me.eventsToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
            Me.eventsToolStripMenuItem.Text = "&Events"
            '
            'clearToolStripMenuItem
            '
            Me.clearToolStripMenuItem.Name = "clearToolStripMenuItem"
            Me.clearToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
            Me.clearToolStripMenuItem.Text = "&Clear"
            '
            'helpToolStripMenuItem
            '
            Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
            Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
            Me.helpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
            Me.helpToolStripMenuItem.Text = "&Help"
            '
            'aboutToolStripMenuItem
            '
            Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
            Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
            Me.aboutToolStripMenuItem.Text = "&About"
            '
            'toolStrip
            '
            Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonConnect, Me.toolStripButtonDisconnect, Me.toolStripSeparator1, Me.toolStripButtonNewOrder, Me.toolStripButtonCancelOrder, Me.toolStripSeparator2, Me.toolStripButtonClearEventLog})
            Me.toolStrip.Location = New System.Drawing.Point(0, 24)
            Me.toolStrip.Name = "toolStrip"
            Me.toolStrip.Size = New System.Drawing.Size(882, 25)
            Me.toolStrip.TabIndex = 1
            '
            'toolStripButtonConnect
            '
            Me.toolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonConnect.Image = Global.TradingClient.My.Resources.Resources.Connect
            Me.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonConnect.Name = "toolStripButtonConnect"
            Me.toolStripButtonConnect.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonConnect.Text = "Connect"
            Me.toolStripButtonConnect.ToolTipText = "Establish FIX Session"
            '
            'toolStripButtonDisconnect
            '
            Me.toolStripButtonDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonDisconnect.Image = Global.TradingClient.My.Resources.Resources.Disconnect

            Me.toolStripButtonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonDisconnect.Name = "toolStripButtonDisconnect"
            Me.toolStripButtonDisconnect.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonDisconnect.Text = "toolStripButtonDisconnect"
            Me.toolStripButtonDisconnect.ToolTipText = "Terminate FIX Session"
            '
            'toolStripSeparator1
            '
            Me.toolStripSeparator1.Name = "toolStripSeparator1"
            Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripButtonNewOrder
            '
            Me.toolStripButtonNewOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonNewOrder.Image = Global.TradingClient.My.Resources.Resources.AddDocument

            Me.toolStripButtonNewOrder.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonNewOrder.Name = "toolStripButtonNewOrder"
            Me.toolStripButtonNewOrder.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonNewOrder.Text = "New Odrer"
            '
            'toolStripButtonCancelOrder
            '
            Me.toolStripButtonCancelOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonCancelOrder.Image = Global.TradingClient.My.Resources.Resources.DeleteDocument

            Me.toolStripButtonCancelOrder.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonCancelOrder.Name = "toolStripButtonCancelOrder"
            Me.toolStripButtonCancelOrder.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonCancelOrder.Text = "Cancel Order"
            '
            'toolStripSeparator2
            '
            Me.toolStripSeparator2.Name = "toolStripSeparator2"
            Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripButtonClearEventLog
            '
            Me.toolStripButtonClearEventLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonClearEventLog.Image = Global.TradingClient.My.Resources.Resources.Trash

            Me.toolStripButtonClearEventLog.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonClearEventLog.Name = "toolStripButtonClearEventLog"
            Me.toolStripButtonClearEventLog.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonClearEventLog.Text = "Clear Events"
            '
            'statusStrip
            '
            Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabelStatus, Me.toolStripStatusLabelSessionState})
            Me.statusStrip.Location = New System.Drawing.Point(0, 440)
            Me.statusStrip.Name = "statusStrip"
            Me.statusStrip.Size = New System.Drawing.Size(882, 22)
            Me.statusStrip.TabIndex = 2
            '
            'toolStripStatusLabelStatus
            '
            Me.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus"
            Me.toolStripStatusLabelStatus.Size = New System.Drawing.Size(707, 17)
            Me.toolStripStatusLabelStatus.Spring = True
            Me.toolStripStatusLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'toolStripStatusLabelSessionState
            '
            Me.toolStripStatusLabelSessionState.AutoSize = False
            Me.toolStripStatusLabelSessionState.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
            Me.toolStripStatusLabelSessionState.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
            Me.toolStripStatusLabelSessionState.Name = "toolStripStatusLabelSessionState"
            Me.toolStripStatusLabelSessionState.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
            Me.toolStripStatusLabelSessionState.Size = New System.Drawing.Size(160, 17)
            Me.toolStripStatusLabelSessionState.Text = "DISCONNECTED"
            Me.toolStripStatusLabelSessionState.ToolTipText = "FIX Session State"
            '
            'tabControl
            '
            Me.tabControl.Controls.Add(Me.tabPageOrders)
            Me.tabControl.Controls.Add(Me.tabPaigeEvents)
            Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabControl.Location = New System.Drawing.Point(0, 49)
            Me.tabControl.Name = "tabControl"
            Me.tabControl.SelectedIndex = 0
            Me.tabControl.Size = New System.Drawing.Size(882, 391)
            Me.tabControl.TabIndex = 3
            '
            'tabPageOrders
            '
            Me.tabPageOrders.Controls.Add(Me.dataGridViewOrders)
            Me.tabPageOrders.Location = New System.Drawing.Point(4, 22)
            Me.tabPageOrders.Name = "tabPageOrders"
            Me.tabPageOrders.Padding = New System.Windows.Forms.Padding(3)
            Me.tabPageOrders.Size = New System.Drawing.Size(874, 365)
            Me.tabPageOrders.TabIndex = 0
            Me.tabPageOrders.Text = "Orders"
            Me.tabPageOrders.UseVisualStyleBackColor = True
            '
            'daTagsridViewOrders
            '
            Me.dataGridViewOrders.AllowUserToAddRows = False
            Me.dataGridViewOrders.AllowUserToDeleteRows = False
            Me.dataGridViewOrders.AllowUserToOrderColumns = True
            Me.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataGridViewOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnClOrdID, Me.columnOrderID, Me.columnOrderStatus, Me.columnSymbol, Me.columnSide, Me.columnOrderType, Me.columnQuantity, Me.columnPrice, Me.columnCumQty, Me.columnAvgPx})
            Me.dataGridViewOrders.ContextMenuStrip = Me.contextMenuStripOrders
            Me.dataGridViewOrders.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dataGridViewOrders.Location = New System.Drawing.Point(3, 3)
            Me.dataGridViewOrders.MultiSelect = False
            Me.dataGridViewOrders.Name = "daTagsridViewOrders"
            Me.dataGridViewOrders.ReadOnly = True
            Me.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dataGridViewOrders.Size = New System.Drawing.Size(868, 359)
            Me.dataGridViewOrders.TabIndex = 0
            '
            'columnClOrdID
            '
            Me.columnClOrdID.HeaderText = "ClOrdID"
            Me.columnClOrdID.Name = "columnClOrdID"
            Me.columnClOrdID.ReadOnly = True
            '
            'columnOrderID
            '
            Me.columnOrderID.HeaderText = "OrderID"
            Me.columnOrderID.Name = "columnOrderID"
            Me.columnOrderID.ReadOnly = True
            '
            'columnOrderStatus
            '
            Me.columnOrderStatus.HeaderText = "Order Status"
            Me.columnOrderStatus.Name = "columnOrderStatus"
            Me.columnOrderStatus.ReadOnly = True
            Me.columnOrderStatus.Width = 90
            '
            'columnSymbol
            '
            Me.columnSymbol.HeaderText = "Symbol"
            Me.columnSymbol.Name = "columnSymbol"
            Me.columnSymbol.ReadOnly = True
            Me.columnSymbol.Width = 80
            '
            'columnSide
            '
            Me.columnSide.HeaderText = "Side"
            Me.columnSide.Name = "columnSide"
            Me.columnSide.ReadOnly = True
            Me.columnSide.Width = 60
            '
            'columnOrderType
            '
            Me.columnOrderType.HeaderText = "Order Type"
            Me.columnOrderType.Name = "columnOrderType"
            Me.columnOrderType.ReadOnly = True
            Me.columnOrderType.Width = 90
            '
            'columnQuantity
            '
            Me.columnQuantity.HeaderText = "Quantity"
            Me.columnQuantity.Name = "columnQuantity"
            Me.columnQuantity.ReadOnly = True
            Me.columnQuantity.Width = 70
            '
            'columnPrice
            '
            Me.columnPrice.HeaderText = "Price"
            Me.columnPrice.Name = "columnPrice"
            Me.columnPrice.ReadOnly = True
            Me.columnPrice.Width = 70
            '
            'columnCumQty
            '
            Me.columnCumQty.HeaderText = "CumQty"
            Me.columnCumQty.Name = "columnCumQty"
            Me.columnCumQty.ReadOnly = True
            Me.columnCumQty.Width = 70
            '
            'columnAvgPx
            '
            Me.columnAvgPx.HeaderText = "AvgPx"
            Me.columnAvgPx.Name = "columnAvgPx"
            Me.columnAvgPx.ReadOnly = True
            Me.columnAvgPx.Width = 70
            '
            'contextMenuStripOrders
            '
            Me.contextMenuStripOrders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newOrderToolStripMenuItem1, Me.cancelOrderToolStripMenuItem1})
            Me.contextMenuStripOrders.Name = "contextMenuStripOrders"
            Me.contextMenuStripOrders.Size = New System.Drawing.Size(149, 48)
            '
            'newOrderToolStripMenuItem1
            '
            Me.newOrderToolStripMenuItem1.Name = "newOrderToolStripMenuItem1"
            Me.newOrderToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
            Me.newOrderToolStripMenuItem1.Text = "&New Order"
            '
            'cancelOrderToolStripMenuItem1
            '
            Me.cancelOrderToolStripMenuItem1.Name = "cancelOrderToolStripMenuItem1"
            Me.cancelOrderToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
            Me.cancelOrderToolStripMenuItem1.Text = "&Cancel Order"
            '
            'tabPaigeEvents
            '
            Me.tabPaigeEvents.Controls.Add(Me.daTagsridViewEventLog)
            Me.tabPaigeEvents.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.tabPaigeEvents.Location = New System.Drawing.Point(4, 22)
            Me.tabPaigeEvents.Name = "tabPaigeEvents"
            Me.tabPaigeEvents.Padding = New System.Windows.Forms.Padding(3)
            Me.tabPaigeEvents.Size = New System.Drawing.Size(874, 365)
            Me.tabPaigeEvents.TabIndex = 1
            Me.tabPaigeEvents.Text = "Events"
            Me.tabPaigeEvents.UseVisualStyleBackColor = True
            '
            'daTagsridViewEventLog
            '
            Me.daTagsridViewEventLog.AllowUserToAddRows = False
            Me.daTagsridViewEventLog.AllowUserToDeleteRows = False
            Me.daTagsridViewEventLog.AllowUserToOrderColumns = True
            Me.daTagsridViewEventLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.daTagsridViewEventLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnEventLogIcon, Me.columnEvent})
            Me.daTagsridViewEventLog.ContextMenuStrip = Me.contextMenuStripEvents
            Me.daTagsridViewEventLog.Dock = System.Windows.Forms.DockStyle.Fill
            Me.daTagsridViewEventLog.Location = New System.Drawing.Point(3, 3)
            Me.daTagsridViewEventLog.Name = "daTagsridViewEventLog"
            Me.daTagsridViewEventLog.ReadOnly = True
            Me.daTagsridViewEventLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.daTagsridViewEventLog.Size = New System.Drawing.Size(868, 359)
            Me.daTagsridViewEventLog.TabIndex = 0
            '
            'columnEventLogIcon
            '
            Me.columnEventLogIcon.HeaderText = ""
            Me.columnEventLogIcon.Name = "columnEventLogIcon"
            Me.columnEventLogIcon.ReadOnly = True
            Me.columnEventLogIcon.Width = 22
            '
            'columnEvent
            '
            Me.columnEvent.HeaderText = ""
            Me.columnEvent.Name = "columnEvent"
            Me.columnEvent.ReadOnly = True
            Me.columnEvent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.columnEvent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.columnEvent.Width = 800
            '
            'contextMenuStripEvents
            '
            Me.contextMenuStripEvents.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.clearEventsToolStripMenuItem})
            Me.contextMenuStripEvents.Name = "contextMenuStripEvents"
            Me.contextMenuStripEvents.Size = New System.Drawing.Size(147, 26)
            '
            'clearEventsToolStripMenuItem
            '
            Me.clearEventsToolStripMenuItem.Name = "clearEventsToolStripMenuItem"
            Me.clearEventsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
            Me.clearEventsToolStripMenuItem.Text = "&Clear Events"
            '
            'MainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(882, 462)
            Me.Controls.Add(Me.tabControl)
            Me.Controls.Add(Me.statusStrip)
            Me.Controls.Add(Me.toolStrip)
            Me.Controls.Add(Me.menuStrip)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MainMenuStrip = Me.menuStrip
            Me.Name = "MainForm"
            Me.Text = "Trading Client Sample"
            Me.menuStrip.ResumeLayout(False)
            Me.menuStrip.PerformLayout()
            Me.toolStrip.ResumeLayout(False)
            Me.toolStrip.PerformLayout()
            Me.statusStrip.ResumeLayout(False)
            Me.statusStrip.PerformLayout()
            Me.tabControl.ResumeLayout(False)
            Me.tabPageOrders.ResumeLayout(False)
            CType(Me.dataGridViewOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.contextMenuStripOrders.ResumeLayout(False)
            Me.tabPaigeEvents.ResumeLayout(False)
            CType(Me.daTagsridViewEventLog, System.ComponentModel.ISupportInitialize).EndInit()
            Me.contextMenuStripEvents.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub 'InitializeComponent 

#End Region

        Private menuStrip As System.Windows.Forms.MenuStrip
        Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents newOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private sessionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents connectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents disconnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
        Private WithEvents settingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStrip As System.Windows.Forms.ToolStrip
        Private statusStrip As System.Windows.Forms.StatusStrip
        Private toolStripStatusLabelStatus As System.Windows.Forms.ToolStripStatusLabel
        Private toolStripStatusLabelSessionState As System.Windows.Forms.ToolStripStatusLabel
        Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private tabControl As System.Windows.Forms.TabControl
        Private tabPageOrders As System.Windows.Forms.TabPage
        Private tabPaigeEvents As System.Windows.Forms.TabPage
        Private dataGridViewOrders As System.Windows.Forms.DataGridView
        Private daTagsridViewEventLog As System.Windows.Forms.DataGridView
        Private WithEvents toolStripButtonNewOrder As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonCancelOrder As System.Windows.Forms.ToolStripButton
        Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Private WithEvents toolStripButtonConnect As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonDisconnect As System.Windows.Forms.ToolStripButton
        Private ordersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents resetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private eventsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents clearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Private WithEvents toolStripButtonClearEventLog As System.Windows.Forms.ToolStripButton
        Private WithEvents cancelOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private contextMenuStripOrders As System.Windows.Forms.ContextMenuStrip
        Private contextMenuStripEvents As System.Windows.Forms.ContextMenuStrip
        Private WithEvents clearEventsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents newOrderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents cancelOrderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
        Private columnClOrdID As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnOrderID As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnOrderStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnSymbol As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnSide As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnOrderType As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnPrice As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnCumQty As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnAvgPx As System.Windows.Forms.DataGridViewTextBoxColumn
        Private columnEventLogIcon As System.Windows.Forms.DataGridViewImageColumn
        Private columnEvent As System.Windows.Forms.DataGridViewTextBoxColumn



        Public Enum EventType
            Notification
            Warning
            [Error]
            IncomingApplicationLevelMessage
            OutgoingApplicationLevelMessage
            IncomingSessionLevelMessage
            OutgoingSessionLevelMessage
        End Enum 'EventType


        Private Class OrderChain
            Public ClOrdIDs As New List(Of String)
            Public OrderIDs As New List(Of String)
            Public Row As DataGridViewRow
        End Class 'OrderChain

        Private isDisposedForm As Boolean = False
        Private session As Session

        Private chainsByOrderID As New Dictionary(Of String, OrderChain)
        Private chainsByClOrdID As New Dictionary(Of String, OrderChain)

        Public Sub New()

            Try
                FIXForge.NET.FIX.Engine.Init()

                InitializeComponent()

                AddHandler HandleDestroyed, AddressOf MainForm_HandleDestroyed
                OnDisconnectSetMenuItems()
                CreateSession()

            Catch ex As Exception
                MessageBox.Show("Exception during initialization: " + ex.Message, "Cannot Start", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub 'New


        Sub MainForm_HandleDestroyed(ByVal sender As Object, ByVal e As EventArgs)
            isDisposedForm = True
        End Sub 'MainForm_HandleDestroyed


        Private Sub ShowAboutDialog()
            Dim form As New AboutDlg()
            form.ShowDialog(Me)
        End Sub 'ShowAboutDialog

#Region "BusinessLogic"


        Private Sub NewOrder()
            Dim newOrderForm As New NewOrderForm(session, Me)
            newOrderForm.Show(Me)
            newOrderForm.Focus()
        End Sub 'NewOrder


        Delegate Sub ProcessMessageDelegate(ByVal msg As Message)


        Private Sub ProcessMessage(ByVal msg As Message)
            If Not Disposing AndAlso Not isDisposedForm Then
                ' formStatusBar.BeginInvoke(New UpdateSessionStateDelegate(AddressOf Me.UpdateSessionState), New Object() {e.NewState.ToString()})

                BeginInvoke(New ProcessMessageDelegate(AddressOf Me.ProcessIncomingMessageSafe), msg)
            End If
        End Sub 'ProcessMessage

        Private Sub ProcessIncomingMessageSafe(ByVal msg As Message)
            Select Case msg.Type
                Case "8", "D"
                    ProcessOrder(msg)
            End Select
        End Sub 'ProcessIncomingMessageSafe


        Private Sub ProcessOrder(ByVal msg As Message)
            SyncLock chainsByClOrdID
                Dim oc As OrderChain = FindOrderChain(msg)

                If oc Is Nothing Then
                    oc = New OrderChain()
                    Dim rowIndex As Integer = dataGridViewOrders.Rows.Add()
                    oc.Row = dataGridViewOrders.Rows(rowIndex)
                End If

                UpdateOrderCollections(oc, msg)
                UpdateOrderRow(oc.Row, msg)
            End SyncLock
        End Sub 'ProcessOrder


        Private Sub UpdateOrderRow(ByVal row As DataGridViewRow, ByVal msg As Message)
            Dim val As String
            val = msg(FIX44.Tags.AvgPx)
            If Not String.IsNullOrEmpty(val) Then
                row.Cells(columnAvgPx.Index).Value = val
            End If
            val = msg(FIX44.Tags.ClOrdID)
            If Not String.IsNullOrEmpty(val) Then
                row.Cells(columnClOrdID.Index).Value = val
            End If
            val = msg(FIX44.Tags.CumQty)
            If Not String.IsNullOrEmpty(val) Then
                row.Cells(columnCumQty.Index).Value = val
            End If
            val = msg(FIX44.Tags.OrderID)
            If Not String.IsNullOrEmpty(val) Then
                row.Cells(columnOrderID.Index).Value = val
            End If
            val = msg(FIX44.Tags.OrdStatus)
            If Not String.IsNullOrEmpty(val) Then

                Select Case val
                    Case "0"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "New"
                    Case "1"
                        row.DefaultCellStyle.ForeColor = Color.Green
                        row.Cells(columnOrderStatus.Index).Value = "Partially filled"
                    Case "2"
                        row.DefaultCellStyle.ForeColor = Color.Blue
                        row.Cells(columnOrderStatus.Index).Value = "Filled"
                    Case "3"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "Done for day"
                    Case "4"
                        row.DefaultCellStyle.ForeColor = Color.Gray
                        row.Cells(columnOrderStatus.Index).Value = "Cancelled"
                    Case "5"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "Replaced"
                    Case "6"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "Pending Cancel"
                    Case "8"
                        row.DefaultCellStyle.ForeColor = Color.Orange
                        row.Cells(columnOrderStatus.Index).Value = "Rejected"
                    Case "9"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "Suspended"
                    Case "A"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "Pending New"
                    Case "B"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "Calculated"
                    Case "C"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "Expired"
                    Case "D"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "Accepted for bidding"
                    Case "E"
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = "Pending Replace"

                    Case Else
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.Cells(columnOrderStatus.Index).Value = val
                End Select
            End If
            val = msg(FIX44.Tags.OrdType)
            If Not String.IsNullOrEmpty(val) Then
                Select Case val
                    Case "1"
                        row.Cells(columnOrderType.Index).Value = "Market"
                    Case "2"
                        row.Cells(columnOrderType.Index).Value = "Limit"
                    Case "3"
                        row.Cells(columnOrderType.Index).Value = "Stop"
                    Case "4"
                        row.Cells(columnOrderType.Index).Value = "Stop limit"
                    Case "5"
                        row.Cells(columnOrderType.Index).Value = "Market on close"
                    Case "6"
                        row.Cells(columnOrderType.Index).Value = "With or without"
                    Case "7"
                        row.Cells(columnOrderType.Index).Value = "Limit or better"
                    Case "8"
                        row.Cells(columnOrderType.Index).Value = "Limit with or without"
                    Case "9"
                        row.Cells(columnOrderType.Index).Value = "On basis"
                    Case "A"
                        row.Cells(columnOrderType.Index).Value = "On close"
                    Case "B"
                        row.Cells(columnOrderType.Index).Value = "Limit on close"
                    Case "C"
                        row.Cells(columnOrderType.Index).Value = "Forex - Market"
                    Case "D"
                        row.Cells(columnOrderType.Index).Value = "Previously quoted"
                    Case "E"
                        row.Cells(columnOrderType.Index).Value = "Previously indicated"
                    Case "F"
                        row.Cells(columnOrderType.Index).Value = "Forex - Limit"
                    Case "G"
                        row.Cells(columnOrderType.Index).Value = "Forex - Swap"
                    Case "H"
                        row.Cells(columnOrderType.Index).Value = "Forex - Previously Quoted"
                    Case "I"
                        row.Cells(columnOrderType.Index).Value = "Funari"
                    Case "P"
                        row.Cells(columnOrderType.Index).Value = "Pegged"
                    Case Else
                        row.Cells(columnOrderType.Index).Value = val
                End Select
            End If
            val = msg(FIX44.Tags.Price)
            If Not String.IsNullOrEmpty(val) Then
                row.Cells(columnPrice.Index).Value = val
            End If
            val = msg(FIX44.Tags.OrderQty)
            If Not String.IsNullOrEmpty(val) Then
                row.Cells(columnQuantity.Index).Value = val
            End If
            val = msg(FIX44.Tags.Side)
            If Not String.IsNullOrEmpty(val) Then
                Select Case val
                    Case "1"
                        row.Cells(columnSide.Index).Value = "Buy"
                    Case "2"
                        row.Cells(columnSide.Index).Value = "Sell"
                    Case "3"
                        row.Cells(columnSide.Index).Value = "Buy minus"
                    Case "4"
                        row.Cells(columnSide.Index).Value = "Sell plus"
                    Case "5"
                        row.Cells(columnSide.Index).Value = "Sell short"
                    Case "6"
                        row.Cells(columnSide.Index).Value = "Sell short exempt"
                    Case "7"
                        row.Cells(columnSide.Index).Value = "Undisclosed"
                    Case "8"
                        row.Cells(columnSide.Index).Value = "Cross"
                    Case "9"
                        row.Cells(columnSide.Index).Value = "Cross short"
                    Case Else
                        row.Cells(columnSide.Index).Value = val
                End Select
            End If
            val = msg(FIX44.Tags.Symbol)
            If Not String.IsNullOrEmpty(val) Then
                row.Cells(columnSymbol.Index).Value = val
            End If
        End Sub 'UpdateOrderRow


        Private Sub UpdateOrderCollections(ByVal oc As OrderChain, ByVal msg As Message)
            Dim clOrdID As String = msg(FIX44.Tags.ClOrdID)
            Dim orderID As String = msg(FIX44.Tags.OrderID)
            Dim origClOrdID As String = msg(FIX44.Tags.OrigClOrdID)
            If Not String.IsNullOrEmpty(clOrdID) Then
                If Not chainsByClOrdID.ContainsKey(clOrdID) Then
                    chainsByClOrdID.Add(clOrdID, oc)
                End If
                If Not oc.ClOrdIDs.Contains(clOrdID) Then
                    oc.ClOrdIDs.Add(clOrdID)
                End If
            End If
            If Not String.IsNullOrEmpty(origClOrdID) Then
                If Not chainsByClOrdID.ContainsKey(origClOrdID) Then
                    chainsByClOrdID.Add(origClOrdID, oc)
                End If
                If Not oc.ClOrdIDs.Contains(origClOrdID) Then
                    oc.ClOrdIDs.Add(origClOrdID)
                End If
            End If
            If Not String.IsNullOrEmpty(orderID) Then
                If Not chainsByOrderID.ContainsKey(orderID) Then
                    chainsByOrderID.Add(orderID, oc)
                End If
                If Not oc.OrderIDs.Contains(orderID) Then
                    oc.OrderIDs.Add(orderID)
                End If
            End If
        End Sub 'UpdateOrderCollections

        Public Function OrderChainExist(ByVal clOrdID As String) As Boolean
            SyncLock chainsByClOrdID
                Return chainsByClOrdID.ContainsKey(clOrdID)
            End SyncLock
        End Function 'OrderChainExist

        Private Function FindOrderChain(ByVal msg As Message) As OrderChain
            Dim clOrdID As String = msg(FIX44.Tags.ClOrdID)
            If Not String.IsNullOrEmpty(clOrdID) AndAlso chainsByClOrdID.ContainsKey(clOrdID) Then
                Return chainsByClOrdID(clOrdID)
            End If
            Dim orderID As String = msg(FIX44.Tags.OrderID)
            If Not String.IsNullOrEmpty(orderID) AndAlso chainsByOrderID.ContainsKey(orderID) Then
                Return chainsByOrderID(orderID)
            End If
            Dim origClOrdID As String = msg(FIX44.Tags.OrigClOrdID)
            If Not String.IsNullOrEmpty(origClOrdID) AndAlso chainsByClOrdID.ContainsKey(origClOrdID) Then
                Return chainsByClOrdID(origClOrdID)
            End If
            Return Nothing
        End Function 'FindOrderChain


        Private Sub CancelOrder()
            If dataGridViewOrders.SelectedRows.Count = 1 Then
                Dim row As DataGridViewRow = dataGridViewOrders.SelectedRows(0)
                If Nothing = row.Cells(columnClOrdID.Index).Value Then
                    Return
                End If
                Dim clOrdID As String = row.Cells(columnClOrdID.Index).Value.ToString()
                Dim msg As New Message(MsgType.OrderCancelRequest, session.Version)
                Dim r As New Random()
                msg(FIX44.Tags.ClOrdID) = DateTime.Now.ToString("yyyyMMdd-HHmmss-") + r.Next(0, 9).ToString()
                msg(FIX44.Tags.OrigClOrdID) = clOrdID
                msg(FIX44.Tags.Symbol) = row.Cells(columnSymbol.Index).Value.ToString()
                msg(FIX44.Tags.Side) = row.Cells(columnSide.Index).Value.ToString()
                msg(FIX44.Tags.TransactTime) = DateTime.Now.ToString()
                Try
                    session.Send(msg)
                Catch ex As Exception
                    AddEvent(EventType.Error, Color.Red, "Cannot send message: " + ex.Message)
                    MessageBox.Show(Me, ex.Message, "Cannot send message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If
        End Sub 'CancelOrder

#End Region
      
      #Region "EventLog"
      
      Delegate Sub AddEventDelegate(eventType As EventType, color As Color, msg As String)
      
      
      Private Sub AddEventSafe(eventType As EventType, color As Color, msg As String)
         Dim img As Image = Nothing
         Select Case eventType
            Case EventType.IncomingApplicationLevelMessage, EventType.IncomingSessionLevelMessage
                    img = New Bitmap(Global.TradingClient.My.Resources.Resources.RightArrow, 16, 16)
          
                Case EventType.OutgoingApplicationLevelMessage, EventType.OutgoingSessionLevelMessage
                    img = New Bitmap(Global.TradingClient.My.Resources.LeftArrow, 16, 16)
                   
                Case EventType.Notification
                    img = New Bitmap(Global.TradingClient.My.Resources.information, 16, 16)
                    
            Case EventType.Error
                    img = New Bitmap(Global.TradingClient.My.Resources._Error, 16, 16)

                Case eventType.Warning
                    img = New Bitmap(Global.TradingClient.My.Resources.warning, 16, 16)                    
            End Select
         Dim i As Integer = daTagsridViewEventLog.Rows.Add(img, msg)
         daTagsridViewEventLog.Rows(i).DefaultCellStyle.ForeColor = color
      End Sub 'AddEventSafe
      
      
      Public Sub AddEvent(eventType As EventType, color As Color, msg As String)
            If Not Disposing AndAlso Not isDisposedForm Then             
                Me.BeginInvoke(New AddEventDelegate(AddressOf Me.AddEventSafe), eventType, color, msg)
            End If
      End Sub 'AddEvent
       
      Private Sub ClearEventLog()
         daTagsridViewEventLog.Rows.Clear()
      End Sub 'ClearEventLog
      #End Region
      
      #Region "Session Routines"
      
      Overloads Private Sub CreateSession(inSeqNum As Integer, outSeqNum As Integer)
         CreateSession()
         If inSeqNum > 0 AndAlso session.InSeqNum <> inSeqNum Then
            session.InSeqNum = inSeqNum
         End If
         If outSeqNum > 0 AndAlso session.OutSeqNum <> outSeqNum Then
            session.OutSeqNum = outSeqNum
         End If
      End Sub 'CreateSession
       
      Overloads Private Sub CreateSession()
         If Not (session Is Nothing) Then
                RemoveHandler session.InboundApplicationMsgEvent, AddressOf session_InboundApplicationMsgEvent
                RemoveHandler session.InboundSessionMsgEvent, AddressOf session_InboundSessionMsgEvent
                RemoveHandler session.OutboundApplicationMsgEvent, AddressOf session_OutboundApplicationMsgEvent
                RemoveHandler session.OutboundSessionMsgEvent, AddressOf session_OutboundSessionMsgEvent
                RemoveHandler session.MessageResending, AddressOf session_ResendRequestEvent
                RemoveHandler session.StateChangeEvent, AddressOf session_StateChangeEvent
                RemoveHandler session.WarningEvent, AddressOf session_WarningEvent

            session.Dispose()
         End If
         
         Dim keepSeqNum As Boolean = True
         Boolean.TryParse(ConfigurationManager.AppSettings("KeepSeqNum"), keepSeqNum)
            session = New Session(ConfigurationManager.AppSettings("SenderCompID"), ConfigurationManager.AppSettings("TargetCompID"), ProtocolVersion.FIX44, keepSeqNum)
         session.SenderSubID = ConfigurationManager.AppSettings("SenderSubID")
         session.SenderLocationID = ConfigurationManager.AppSettings("SenderLocationID")
         session.TargetSubID = ConfigurationManager.AppSettings("TargetSubID")
         
         AddHandler session.InboundApplicationMsgEvent, AddressOf session_InboundApplicationMsgEvent
         AddHandler session.InboundSessionMsgEvent, AddressOf session_InboundSessionMsgEvent
         AddHandler session.OutboundApplicationMsgEvent, AddressOf session_OutboundApplicationMsgEvent
         AddHandler session.OutboundSessionMsgEvent, AddressOf session_OutboundSessionMsgEvent
         AddHandler session.MessageResending, AddressOf session_ResendRequestEvent
         AddHandler session.StateChangeEvent, AddressOf session_StateChangeEvent
         AddHandler session.WarningEvent, AddressOf session_WarningEvent
      End Sub 'CreateSession
      
      
      Private Sub Connect()
         Dim user As String = ConfigurationManager.AppSettings("Username")
         Dim pwd As String = ConfigurationManager.AppSettings("Password")
         If Not String.IsNullOrEmpty(user) OrElse Not String.IsNullOrEmpty(pwd) Then
            Dim customLogon As New Message("A", session.Version)
            ' 553 Username N
            If Not String.IsNullOrEmpty(user) Then
               customLogon.Set(553, user)
            End If 
            ' 554 Password N Note: minimal security exists without transport-level encryption. 
            If Not String.IsNullOrEmpty(pwd) Then
               customLogon.Set(554, pwd)
            End If
            Try
               session.LogonAsInitiator(ConfigurationManager.AppSettings("Host"), Integer.Parse(ConfigurationManager.AppSettings("Port")), Integer.Parse(ConfigurationManager.AppSettings("HBI")), customLogon, True)
            Catch ex As Exception
               AddEvent(EventType.Error, Color.Red, "Cannot connect: " + ex.Message)
               MessageBox.Show(Me, ex.Message, "Cannot connect", MessageBoxButtons.OK, MessageBoxIcon.Error)
               Return
            End Try
         Else
            Try
               session.LogonAsInitiator(ConfigurationManager.AppSettings("Host"), Integer.Parse(ConfigurationManager.AppSettings("Port")), Integer.Parse(ConfigurationManager.AppSettings("HBI")), True)
            Catch ex As Exception
               AddEvent(EventType.Error, Color.Red, "Cannot connect: " + ex.Message)
               MessageBox.Show(Me, ex.Message, "Cannot connect", MessageBoxButtons.OK, MessageBoxIcon.Error)
               Return
            End Try
         End If
         OnConnectSetMenuItems()
            'If Not (OnConnect Is Nothing) Then
            RaiseEvent OnConnect(session, EventArgs.Empty)
            'End If
      End Sub 'Connect
       
      Private Sub Disconnect()
         Try
            Try
               session.Logout()
            Catch ex As Exception
               AddEvent(EventType.Error, Color.Red, "Cannot disconnect: " + ex.Message)
               MessageBox.Show(Me, ex.Message, "Cannot disconnect", MessageBoxButtons.OK, MessageBoxIcon.Error)
               Return
            End Try
         Finally
            OnDisconnectSetMenuItems()
                'If Not (OnDisconnect Is Nothing) Then
                RaiseEvent OnDisconnect(session, EventArgs.Empty)
                'End If
         End Try
      End Sub 'Disconnect
       
      Private Sub OnConnectSetMenuItems()
         toolStripButtonDisconnect.Enabled = True
         disconnectToolStripMenuItem.Enabled = True
         toolStripButtonConnect.Enabled = False
         connectToolStripMenuItem.Enabled = False
         resetToolStripMenuItem.Enabled = False
         settingsToolStripMenuItem.Enabled = False
         toolStripButtonCancelOrder.Enabled = True
         toolStripButtonNewOrder.Enabled = True
         newOrderToolStripMenuItem.Enabled = True
         newOrderToolStripMenuItem1.Enabled = True
         cancelOrderToolStripMenuItem.Enabled = True
         cancelOrderToolStripMenuItem1.Enabled = True
      End Sub 'OnConnectSetMenuItems
      
      
      Private Sub OnDisconnectSetMenuItems()
         toolStripButtonDisconnect.Enabled = False
         disconnectToolStripMenuItem.Enabled = False
         toolStripButtonConnect.Enabled = True
         connectToolStripMenuItem.Enabled = True
         resetToolStripMenuItem.Enabled = True
         settingsToolStripMenuItem.Enabled = True
         toolStripButtonCancelOrder.Enabled = False
         toolStripButtonNewOrder.Enabled = False
         newOrderToolStripMenuItem.Enabled = False
         newOrderToolStripMenuItem1.Enabled = False
         cancelOrderToolStripMenuItem.Enabled = False
         cancelOrderToolStripMenuItem1.Enabled = False
      End Sub 'OnDisconnectSetMenuItems
      
      Public Event OnConnect As EventHandler
      Public Event OnDisconnect As EventHandler
      
      
      Private Sub Reset()
         Try
                session.ResetLocalSequenceNumbers()
         Catch ex As Exception
            AddEvent(EventType.Error, Color.Red, "Cannot reset session: " + ex.Message)
            MessageBox.Show(Me, ex.Message, "Cannot reset session", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
         End Try
      End Sub 'Reset
      
      
      Private Sub SetSessionSettings()
         Dim sessionSettingsForm As New SessionSettingsForm(session.InSeqNum, session.OutSeqNum)
         If sessionSettingsForm.ShowDialog(Me) = DialogResult.OK Then
            Dim inSeqNum As Integer = sessionSettingsForm.InSeqNum
            Dim outSeqNum As Integer = sessionSettingsForm.OutSeqNum
            CreateSession(inSeqNum, outSeqNum)
         End If
      End Sub 'SetSessionSettings
      
      #Region "Session Handlers"
      
        Sub session_WarningEvent(sender As Object, args As WarningEventArgs)
            AddEvent(EventType.Warning, Color.Brown, args.Reason.ToString())
        End Sub 'session_WarningEvent
      
      
        Sub session_StateChangeEvent(sender As Object, args As FIXForge.NET.FIX.StateChangeEventArgs)
            AddEvent(EventType.Notification, Color.Black, String.Format("Session state changed from {0} to {1}", args.PrevState, args.NewState))
            BeginInvoke(New UpdateSesionStateDelegate(AddressOf Me.SafeUpdateSesionState), args)
        End Sub 'session_StateChangeEvent
      
      
        Delegate Sub UpdateSesionStateDelegate(args As FIXForge.NET.FIX.StateChangeEventArgs)
      
      
        Private Sub SafeUpdateSesionState(args As FIXForge.NET.FIX.StateChangeEventArgs)
            If args.NewState = SessionState.DISCONNECTED AndAlso args.PrevState <> SessionState.DISCONNECTED Then
                OnDisconnectSetMenuItems()
                'If Not (OnConnect Is Nothing) Then
                RaiseEvent OnConnect(session, EventArgs.Empty)
                'End If
            End If
            toolStripStatusLabelSessionState.Text = args.NewState.ToString()
            If args.NewState = SessionState.ACTIVE Then
                toolStripStatusLabelSessionState.ForeColor = Color.Green
            ElseIf args.NewState = SessionState.RECONNECTING Then
                toolStripStatusLabelSessionState.ForeColor = Color.Orange
            Else
                toolStripStatusLabelSessionState.ForeColor = Color.Black
            End If
        End Sub 'SafeUpdateSesionState
       
        Sub session_ResendRequestEvent(ByVal sender As Object, ByVal args As MessageResendingEventArgs)
            AddEvent(EventType.Notification, Color.Black, String.Format("Resend request for message {0}", args.Msg))
            args.AllowResending = True
        End Sub 'session_ResendRequestEvent
      
      
        Sub session_OutboundSessionMsgEvent(sender As Object, args As OutboundSessionMsgEventArgs)
            AddEvent(EventType.OutgoingSessionLevelMessage, GetColorForMessage(args.Msg), args.Msg.ToString())
        End Sub 'session_OutboundSessionMsgEvent
      
      
        Sub session_OutboundApplicationMsgEvent(sender As Object, args As OutboundApplicationMsgEventArgs)
            AddEvent(EventType.OutgoingApplicationLevelMessage, GetColorForMessage(args.Msg), args.Msg.ToString())
            ProcessMessage(args.Msg)
        End Sub 'session_OutboundApplicationMsgEvent
      
      
        Sub session_InboundSessionMsgEvent(sender As Object, args As InboundSessionMsgEventArgs)
            AddEvent(EventType.IncomingSessionLevelMessage, GetColorForMessage(args.Msg), args.Msg.ToString())
        End Sub 'session_InboundSessionMsgEvent
      
      
        Sub session_InboundApplicationMsgEvent(sender As Object, args As InboundApplicationMsgEventArgs)
            AddEvent(EventType.IncomingApplicationLevelMessage, GetColorForMessage(args.Msg), args.Msg.ToString())
            ProcessMessage(args.Msg)
        End Sub 'session_InboundApplicationMsgEvent
      
      
      Private Function GetColorForMessage(msg As Message) As Color
         Dim color As Color
         If msg.Type = "0" Then
            color = Color.Gray
         ElseIf msg.Type = "D" Then
            color = Color.Blue
         ElseIf msg.Type = "F" OrElse msg.Type = "G" Then
            color = Color.Coral
         ElseIf msg.Type = "9" Then
            color = Color.Brown
         ElseIf msg.Type = "8" Then
            color = Color.Green
         Else
            color = Color.Black
         End If
         Return color
      End Function 'GetColorForMessage
      #End Region
      
      #End Region
      
      #Region "Handlers"
      
      Private Sub toolStripButtonNewOrder_Click(sender As Object, e As EventArgs) Handles toolStripButtonNewOrder.Click
         NewOrder()
      End Sub 'toolStripButtonNewOrder_Click
      
      
      Private Sub newOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles newOrderToolStripMenuItem.Click
         NewOrder()
      End Sub 'newOrderToolStripMenuItem_Click
      
      
      Private Sub settingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles settingsToolStripMenuItem.Click
         SetSessionSettings()
      End Sub 'settingsToolStripMenuItem_Click
      
      
      Private Sub toolStripButtonConnect_Click(sender As Object, e As EventArgs) Handles toolStripButtonConnect.Click
         Connect()
      End Sub 'toolStripButtonConnect_Click
      
      
      Private Sub toolStripButtonDisconnect_Click(sender As Object, e As EventArgs) Handles toolStripButtonDisconnect.Click
         Disconnect()
      End Sub 'toolStripButtonDisconnect_Click
      
      
      Private Sub connectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles connectToolStripMenuItem.Click
         Connect()
      End Sub 'connectToolStripMenuItem_Click
      
      
      Private Sub disconnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles disconnectToolStripMenuItem.Click
         Disconnect()
      End Sub 'disconnectToolStripMenuItem_Click
      
      
      Private Sub resetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles resetToolStripMenuItem.Click
         Reset()
      End Sub 'resetToolStripMenuItem_Click
      
      
      Private Sub toolStripButtonCancelOrder_Click(sender As Object, e As EventArgs) Handles toolStripButtonCancelOrder.Click
         CancelOrder()
      End Sub 'toolStripButtonCancelOrder_Click
      
      
      Private Sub cancelOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cancelOrderToolStripMenuItem.Click
         CancelOrder()
      End Sub 'cancelOrderToolStripMenuItem_Click
      
      
      Private Sub clearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles clearToolStripMenuItem.Click
         ClearEventLog()
      End Sub 'clearToolStripMenuItem_Click
      
      
      Private Sub toolStripButtonClearEventLog_Click(sender As Object, e As EventArgs) Handles toolStripButtonClearEventLog.Click
         ClearEventLog()
      End Sub 'toolStripButtonClearEventLog_Click
      
      
      Private Sub aboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles aboutToolStripMenuItem.Click
         ShowAboutDialog()
      End Sub 'aboutToolStripMenuItem_Click
      
      
      Private Sub clearEventsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles clearEventsToolStripMenuItem.Click
         ClearEventLog()
      End Sub 'clearEventsToolStripMenuItem_Click
      
      
      Private Sub newOrderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles newOrderToolStripMenuItem1.Click
         NewOrder()
      End Sub 'newOrderToolStripMenuItem1_Click
      
      
      Private Sub cancelOrderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles cancelOrderToolStripMenuItem1.Click
         CancelOrder()
      End Sub 'cancelOrderToolStripMenuItem1_Click
      
      
      Private Sub exitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exitToolStripMenuItem.Click
         Close()
      End Sub 'exitToolStripMenuItem_Click
      #End Region
   End Class 'MainForm 
End Namespace 'Biz.Onixs.TradingClientSample