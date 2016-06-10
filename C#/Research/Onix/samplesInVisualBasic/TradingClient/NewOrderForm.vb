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
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms

Imports FIXForge.NET.FIX
Imports FF = FIXForge.NET.FIX
Imports FIXForge.NET.FIX.FIX44
Imports FIX44 = FIXForge.NET.FIX.FIX44
Imports Message = FIXForge.NET.FIX.Message


Namespace Biz.Onixs.TradingClientSample
   
   Public Class NewOrderForm
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
         Me.components = New System.ComponentModel.Container()
         Me.label1 = New System.Windows.Forms.Label()
         Me.textBoxClOrdID = New System.Windows.Forms.TextBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.textBoxQuantity = New System.Windows.Forms.TextBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me.textBoxPrice = New System.Windows.Forms.TextBox()
         Me.label6 = New System.Windows.Forms.Label()
         Me.buttonSend = New System.Windows.Forms.Button()
         Me.buttonClose = New System.Windows.Forms.Button()
         Me.comboBoxSymbol = New System.Windows.Forms.ComboBox()
         Me.comboBoxSide = New System.Windows.Forms.ComboBox()
         Me.comboBoxOrderType = New System.Windows.Forms.ComboBox()
         Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
         CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(34, 29)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(44, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "ClOrdID"
         ' 
         ' textBoxClOrdID
         ' 
         Me.textBoxClOrdID.Location = New System.Drawing.Point(100, 26)
         Me.textBoxClOrdID.Name = "textBoxClOrdID"
         Me.textBoxClOrdID.Size = New System.Drawing.Size(176, 20)
         Me.textBoxClOrdID.TabIndex = 1
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(34, 63)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(41, 13)
         Me.label2.TabIndex = 2
         Me.label2.Text = "Symbol"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(34, 97)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(28, 13)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Side"
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(34, 131)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(60, 13)
         Me.label4.TabIndex = 6
         Me.label4.Text = "Order Type"
         ' 
         ' textBoxQuantity
         ' 
         Me.textBoxQuantity.Location = New System.Drawing.Point(100, 161)
         Me.textBoxQuantity.Name = "textBoxQuantity"
         Me.textBoxQuantity.Size = New System.Drawing.Size(176, 20)
         Me.textBoxQuantity.TabIndex = 9
         Me.textBoxQuantity.Text = "10"
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(34, 164)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(46, 13)
         Me.label5.TabIndex = 8
         Me.label5.Text = "Quantity"
         ' 
         ' textBoxPrice
         ' 
         Me.textBoxPrice.Location = New System.Drawing.Point(100, 194)
         Me.textBoxPrice.Name = "textBoxPrice"
         Me.textBoxPrice.Size = New System.Drawing.Size(176, 20)
         Me.textBoxPrice.TabIndex = 11
         Me.textBoxPrice.Text = "80"
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(34, 197)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(31, 13)
         Me.label6.TabIndex = 10
         Me.label6.Text = "Price"
         ' 
         ' buttonSend
         ' 
         Me.buttonSend.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonSend.Location = New System.Drawing.Point(34, 238)
         Me.buttonSend.Name = "buttonSend"
         Me.buttonSend.Size = New System.Drawing.Size(75, 23)
         Me.buttonSend.TabIndex = 12
         Me.buttonSend.Text = "Send"
         Me.buttonSend.UseVisualStyleBackColor = True
         ' 
         ' buttonClose
         ' 
         Me.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonClose.Location = New System.Drawing.Point(201, 238)
         Me.buttonClose.Name = "buttonClose"
         Me.buttonClose.Size = New System.Drawing.Size(75, 23)
         Me.buttonClose.TabIndex = 13
         Me.buttonClose.Text = "Close"
         Me.buttonClose.UseVisualStyleBackColor = True
         ' 
         ' comboBoxSymbol
         ' 
         Me.comboBoxSymbol.FormattingEnabled = True
         Me.comboBoxSymbol.Items.AddRange(New Object() {"MSFT", "JPM", "CSCO"})
         Me.comboBoxSymbol.Location = New System.Drawing.Point(100, 59)
         Me.comboBoxSymbol.Name = "comboBoxSymbol"
         Me.comboBoxSymbol.Size = New System.Drawing.Size(176, 21)
         Me.comboBoxSymbol.TabIndex = 14
         ' 
         ' comboBoxSide
         ' 
         Me.comboBoxSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBoxSide.FormattingEnabled = True
         Me.comboBoxSide.Items.AddRange(New Object() {"1 - Buy", "2 - Sell"})
         Me.comboBoxSide.Location = New System.Drawing.Point(100, 93)
         Me.comboBoxSide.Name = "comboBoxSide"
         Me.comboBoxSide.Size = New System.Drawing.Size(176, 21)
         Me.comboBoxSide.TabIndex = 15
         ' 
         ' comboBoxOrderType
         ' 
         Me.comboBoxOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBoxOrderType.FormattingEnabled = True
         Me.comboBoxOrderType.Items.AddRange(New Object() {"1 - Market", "2 - Limit"})
         Me.comboBoxOrderType.Location = New System.Drawing.Point(100, 127)
         Me.comboBoxOrderType.Name = "comboBoxOrderType"
         Me.comboBoxOrderType.Size = New System.Drawing.Size(176, 21)
         Me.comboBoxOrderType.TabIndex = 16
         ' 
         ' errorProvider
         ' 
         Me.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
         Me.errorProvider.ContainerControl = Me
         ' 
         ' NewOrderForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me.buttonClose
         Me.ClientSize = New System.Drawing.Size(313, 287)
         Me.Controls.Add(comboBoxOrderType)
         Me.Controls.Add(comboBoxSide)
         Me.Controls.Add(comboBoxSymbol)
         Me.Controls.Add(buttonClose)
         Me.Controls.Add(buttonSend)
         Me.Controls.Add(textBoxPrice)
         Me.Controls.Add(label6)
         Me.Controls.Add(textBoxQuantity)
         Me.Controls.Add(label5)
         Me.Controls.Add(label4)
         Me.Controls.Add(label3)
         Me.Controls.Add(label2)
         Me.Controls.Add(textBoxClOrdID)
         Me.Controls.Add(label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.MaximizeBox = False
         Me.Name = "NewOrderForm"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
         Me.Text = "New Order"
         CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()
      End Sub 'InitializeComponent 
      
      #End Region
      
      Private label1 As System.Windows.Forms.Label
      Private WithEvents textBoxClOrdID As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private WithEvents textBoxQuantity As System.Windows.Forms.TextBox
      Private label5 As System.Windows.Forms.Label
      Private WithEvents textBoxPrice As System.Windows.Forms.TextBox
      Private label6 As System.Windows.Forms.Label
      Private WithEvents buttonSend As System.Windows.Forms.Button
      Private WithEvents buttonClose As System.Windows.Forms.Button
      Private WithEvents comboBoxSymbol As System.Windows.Forms.ComboBox
      Private comboBoxSide As System.Windows.Forms.ComboBox
      Private comboBoxOrderType As System.Windows.Forms.ComboBox
      Private errorProvider As System.Windows.Forms.ErrorProvider
      
      Private session As Session
        Private mainForm_ As MainForm
      
      
        Public Sub New(ByVal session As Session, ByVal mainForm_ As MainForm)
            InitializeComponent()

            Me.Left = mainForm_.Left + (mainForm_.Width - Me.Width) / 2
            Me.Top = mainForm_.Top + (mainForm_.Height - Me.Height) / 2

            Me.session = session
            Me.mainForm_ = mainForm_
            AddHandler mainForm_.OnConnect, AddressOf mainForm_OnConnect
            AddHandler mainForm_.OnDisconnect, AddressOf mainForm_OnDisconnect

            comboBoxOrderType.SelectedIndex = 0
            comboBoxSide.SelectedIndex = 0
            comboBoxSymbol.SelectedIndex = 0
            textBoxClOrdID.Text = CreateClOrdID()
        End Sub 'New
      
      
      Sub mainForm_OnDisconnect(sender As Object, e As EventArgs)
         buttonSend.Enabled = False
      End Sub 'mainForm_OnDisconnect
      
      
      Sub mainForm_OnConnect(sender As Object, e As EventArgs)
         buttonSend.Enabled = True
      End Sub 'mainForm_OnConnect
      
      
      Public Function CreateClOrdID() As String
         Dim r As New Random()
         Return DateTime.Now.ToString("yyyyMMdd-HHmmssfffff-") + r.Next(0, 9).ToString()
      End Function 'CreateClOrdID
      
      
      Private Sub buttonClose_Click(sender As Object, e As EventArgs) Handles buttonClose.Click
            RemoveHandler mainForm_.OnConnect, AddressOf mainForm_OnConnect
            RemoveHandler mainForm_.OnDisconnect, AddressOf mainForm_OnDisconnect
         Close()
      End Sub 'buttonClose_Click
      
      
      Private Sub buttonSend_Click(sender As Object, e As EventArgs) Handles buttonSend.Click
         Dim isErrors As Boolean = False
         If String.IsNullOrEmpty(textBoxClOrdID.Text) Then
            errorProvider.SetIconPadding(textBoxClOrdID, 4)
            errorProvider.SetError(textBoxClOrdID, "ClOrdID must be specified")
            isErrors = True
         End If
            If mainForm_.OrderChainExist(textBoxClOrdID.Text) Then
                errorProvider.SetIconPadding(textBoxClOrdID, 4)
                errorProvider.SetError(textBoxClOrdID, "ClOrdID must be unique")
                isErrors = True
            End If
            If String.IsNullOrEmpty(comboBoxSymbol.Text) Then
                errorProvider.SetIconPadding(comboBoxSymbol, 4)
                errorProvider.SetError(comboBoxSymbol, "Symbol must be specified")
                isErrors = True
            End If
            Dim price As Double = Double.NaN
            If Not Double.TryParse(textBoxPrice.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, price) Then
                errorProvider.SetIconPadding(textBoxPrice, 4)
                errorProvider.SetError(textBoxPrice, "Price must be specified as correct number")
                isErrors = True
            End If
            Dim quantity As Integer = -1
            If Not Integer.TryParse(textBoxQuantity.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, quantity) Then
                errorProvider.SetIconPadding(textBoxQuantity, 4)
                errorProvider.SetError(textBoxQuantity, "Quantity must be specified as correct number")
                isErrors = True
            End If

            If isErrors Then
                Return
            End If
            Dim msg As New Message("D", session.Version)

            msg(FIX44.Tags.ClOrdID) = textBoxClOrdID.Text
            msg(FIX44.Tags.HandlInst) = "1"
            msg(FIX44.Tags.Symbol) = comboBoxSymbol.Text
            msg(FIX44.Tags.Side) = comboBoxSide.Text(0).ToString()
            msg(FIX44.Tags.TransactTime) = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            msg(FIX44.Tags.OrdType) = comboBoxOrderType.Text(0).ToString()
            If price <> Double.NaN Then
                msg(FIX44.Tags.Price) = price.ToString(CultureInfo.InvariantCulture)
            End If
            If quantity <> -1 Then
                msg(FIX44.Tags.OrderQty) = quantity.ToString(CultureInfo.InvariantCulture)
            End If
            Try
                session.Send(msg)
            Catch ex As Exception
                mainForm_.AddEvent(mainForm.EventType.Error, Color.Red, "Cannot send message: " + ex.Message)
                MessageBox.Show(Me, ex.Message, "Cannot send message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
         textBoxClOrdID.Text = CreateClOrdID()
      End Sub 'buttonSend_Click
      
      
      Private Sub textBoxClOrdID_TextChanged(sender As Object, e As EventArgs) Handles textBoxClOrdID.TextChanged, textBoxQuantity.TextChanged, textBoxPrice.TextChanged, comboBoxSymbol.TextChanged
         errorProvider.SetError(CType(sender, Control), "")
      End Sub 'textBoxClOrdID_TextChanged
   End Class 'NewOrderForm 
End Namespace 'Biz.Onixs.TradingClientSample 