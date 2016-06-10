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
Imports System.Configuration
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms


Namespace Biz.Onixs.TradingClientSample
   
   Public Class SessionSettingsForm
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
         Me.cbKeepSequenceNumbersAfterLogout = New System.Windows.Forms.CheckBox()
         Me.label10 = New System.Windows.Forms.Label()
         Me.txtHost = New System.Windows.Forms.TextBox()
         Me.txtPassword = New System.Windows.Forms.TextBox()
         Me.txtPort = New System.Windows.Forms.TextBox()
         Me.txtSenderSubId = New System.Windows.Forms.TextBox()
         Me.txtTargetCompId = New System.Windows.Forms.TextBox()
         Me.txtIncomingSeqNum = New System.Windows.Forms.TextBox()
         Me.txtTargetSubId = New System.Windows.Forms.TextBox()
         Me.txtOutgoingSeqNum = New System.Windows.Forms.TextBox()
         Me.txtSenderCompId = New System.Windows.Forms.TextBox()
         Me.txtHBI = New System.Windows.Forms.TextBox()
         Me.txtUsername = New System.Windows.Forms.TextBox()
         Me.label6 = New System.Windows.Forms.Label()
         Me.label11 = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label7 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label13 = New System.Windows.Forms.Label()
         Me.label8 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label9 = New System.Windows.Forms.Label()
         Me.label12 = New System.Windows.Forms.Label()
         Me.bOk = New System.Windows.Forms.Button()
         Me.bCancel = New System.Windows.Forms.Button()
         Me.txtSenderLocationID = New System.Windows.Forms.TextBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
         Me.cbSetResetSeqNumFlag = New System.Windows.Forms.CheckBox()
         Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
         Me.txtTargetLocationID = New System.Windows.Forms.TextBox()
         Me.label2 = New System.Windows.Forms.Label()
         CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' cbKeepSequenceNumbersAfterLogout
         ' 
         Me.cbKeepSequenceNumbersAfterLogout.Location = New System.Drawing.Point(25, 349)
         Me.cbKeepSequenceNumbersAfterLogout.Name = "cbKeepSequenceNumbersAfterLogout"
         Me.cbKeepSequenceNumbersAfterLogout.Size = New System.Drawing.Size(224, 24)
         Me.cbKeepSequenceNumbersAfterLogout.TabIndex = 20
         Me.cbKeepSequenceNumbersAfterLogout.Text = "Keep Sequence Numbers After Logout"
         Me.toolTip.SetToolTip(Me.cbKeepSequenceNumbersAfterLogout, "Option to keep sequence numbers after the Logout exchange.")
         ' 
         ' label10
         ' 
         Me.label10.Location = New System.Drawing.Point(22, 247)
         Me.label10.Name = "label10"
         Me.label10.Size = New System.Drawing.Size(80, 23)
         Me.label10.TabIndex = 46
         Me.label10.Text = "Username"
         Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' txtHost
         ' 
         Me.txtHost.Location = New System.Drawing.Point(127, 23)
         Me.txtHost.Name = "txtHost"
         Me.txtHost.Size = New System.Drawing.Size(183, 20)
         Me.txtHost.TabIndex = 0
         Me.toolTip.SetToolTip(Me.txtHost, "Counterparty's host name or address.")
         ' 
         ' txtPassword
         ' 
         Me.txtPassword.Location = New System.Drawing.Point(127, 273)
         Me.txtPassword.Name = "txtPassword"
         Me.txtPassword.Size = New System.Drawing.Size(183, 20)
         Me.txtPassword.TabIndex = 9
         Me.toolTip.SetToolTip(Me.txtPassword, "Tags 554. Password.")
         ' 
         ' txtPort
         ' 
         Me.txtPort.Location = New System.Drawing.Point(127, 48)
         Me.txtPort.Name = "txtPort"
         Me.txtPort.Size = New System.Drawing.Size(183, 20)
         Me.txtPort.TabIndex = 1
         Me.toolTip.SetToolTip(Me.txtPort, "Counterparty's port number.")
         ' 
         ' txtSenderSubId
         ' 
         Me.txtSenderSubId.Location = New System.Drawing.Point(127, 98)
         Me.txtSenderSubId.Name = "txtSenderSubId"
         Me.txtSenderSubId.Size = New System.Drawing.Size(183, 20)
         Me.txtSenderSubId.TabIndex = 3
         Me.toolTip.SetToolTip(Me.txtSenderSubId, "Tags 50. Assigned value used to identify specific message originator (desk, trader" + ", etc.)")
         ' 
         ' txtTargetCompId
         ' 
         Me.txtTargetCompId.Location = New System.Drawing.Point(127, 148)
         Me.txtTargetCompId.Name = "txtTargetCompId"
         Me.txtTargetCompId.Size = New System.Drawing.Size(183, 20)
         Me.txtTargetCompId.TabIndex = 5
         Me.toolTip.SetToolTip(Me.txtTargetCompId, "Tags 56. Assigned value used to identify receiving firm.")
         ' 
         ' txtIncomingSeqNum
         ' 
         Me.txtIncomingSeqNum.Location = New System.Drawing.Point(127, 298)
         Me.txtIncomingSeqNum.Name = "txtIncomingSeqNum"
         Me.txtIncomingSeqNum.Size = New System.Drawing.Size(183, 20)
         Me.txtIncomingSeqNum.TabIndex = 10
         Me.toolTip.SetToolTip(Me.txtIncomingSeqNum, "Expected sequence number of the next incoming message.")
         ' 
         ' txtTargetSubId
         ' 
         Me.txtTargetSubId.Location = New System.Drawing.Point(127, 173)
         Me.txtTargetSubId.Name = "txtTargetSubId"
         Me.txtTargetSubId.Size = New System.Drawing.Size(183, 20)
         Me.txtTargetSubId.TabIndex = 6
         Me.toolTip.SetToolTip(Me.txtTargetSubId, "Tags 57. Assigned value used to identify specific individual or unit intended to r" + "eceive message. 'ADMIN' reserved for administrative messages not intended for a " + "specific user.")
         ' 
         ' txtOutgoingSeqNum
         ' 
         Me.txtOutgoingSeqNum.Location = New System.Drawing.Point(127, 323)
         Me.txtOutgoingSeqNum.Name = "txtOutgoingSeqNum"
         Me.txtOutgoingSeqNum.Size = New System.Drawing.Size(183, 20)
         Me.txtOutgoingSeqNum.TabIndex = 11
         Me.toolTip.SetToolTip(Me.txtOutgoingSeqNum, "Sequence number of the next outgoing message")
         ' 
         ' txtSenderCompId
         ' 
         Me.txtSenderCompId.Location = New System.Drawing.Point(127, 73)
         Me.txtSenderCompId.Name = "txtSenderCompId"
         Me.txtSenderCompId.Size = New System.Drawing.Size(183, 20)
         Me.txtSenderCompId.TabIndex = 2
         Me.toolTip.SetToolTip(Me.txtSenderCompId, "Tags 49. Assigned value used to identify firm sending message. ")
         ' 
         ' txtHBI
         ' 
         Me.txtHBI.Location = New System.Drawing.Point(127, 223)
         Me.txtHBI.Name = "txtHBI"
         Me.txtHBI.Size = New System.Drawing.Size(183, 20)
         Me.txtHBI.TabIndex = 7
         Me.toolTip.SetToolTip(Me.txtHBI, "Heartbeat interval (seconds).")
         ' 
         ' txtUsername
         ' 
         Me.txtUsername.Location = New System.Drawing.Point(127, 248)
         Me.txtUsername.Name = "txtUsername"
         Me.txtUsername.Size = New System.Drawing.Size(183, 20)
         Me.txtUsername.TabIndex = 8
         Me.toolTip.SetToolTip(Me.txtUsername, "Tags 553. Username.")
         ' 
         ' label6
         ' 
         Me.label6.Location = New System.Drawing.Point(22, 97)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(96, 23)
         Me.label6.TabIndex = 38
         Me.label6.Text = "SenderSubID"
         Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' label11
         ' 
         Me.label11.Location = New System.Drawing.Point(22, 273)
         Me.label11.Name = "label11"
         Me.label11.Size = New System.Drawing.Size(96, 23)
         Me.label11.TabIndex = 48
         Me.label11.Text = "Password"
         Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' label5
         ' 
         Me.label5.Location = New System.Drawing.Point(22, 72)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(96, 23)
         Me.label5.TabIndex = 36
         Me.label5.Text = "SenderCompID "
         Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' label7
         ' 
         Me.label7.Location = New System.Drawing.Point(22, 147)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(96, 23)
         Me.label7.TabIndex = 40
         Me.label7.Text = "TargetCompID"
         Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         Me.toolTip.SetToolTip(Me.label7, "Assigned value used to identify receiving firm (TargetCompID (56) field value in " + "outgoing messages). ")
         ' 
         ' label4
         ' 
         Me.label4.Location = New System.Drawing.Point(22, 47)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(96, 23)
         Me.label4.TabIndex = 34
         Me.label4.Text = "Port"
         Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' label13
         ' 
         Me.label13.Location = New System.Drawing.Point(22, 323)
         Me.label13.Name = "label13"
         Me.label13.Size = New System.Drawing.Size(96, 23)
         Me.label13.TabIndex = 52
         Me.label13.Text = "OutgoingSeqNum"
         Me.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' label8
         ' 
         Me.label8.Location = New System.Drawing.Point(22, 172)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(96, 23)
         Me.label8.TabIndex = 42
         Me.label8.Text = "TargetSubID"
         Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' label3
         ' 
         Me.label3.Location = New System.Drawing.Point(22, 22)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(96, 23)
         Me.label3.TabIndex = 32
         Me.label3.Text = "Host"
         Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' label9
         ' 
         Me.label9.Location = New System.Drawing.Point(22, 222)
         Me.label9.Name = "label9"
         Me.label9.Size = New System.Drawing.Size(96, 23)
         Me.label9.TabIndex = 44
         Me.label9.Text = "HBI"
         Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' label12
         ' 
         Me.label12.Location = New System.Drawing.Point(22, 298)
         Me.label12.Name = "label12"
         Me.label12.Size = New System.Drawing.Size(96, 23)
         Me.label12.TabIndex = 50
         Me.label12.Text = "IncomingSeqNum"
         Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' bOk
         ' 
         Me.bOk.Location = New System.Drawing.Point(49, 416)
         Me.bOk.Name = "bOk"
         Me.bOk.Size = New System.Drawing.Size(75, 23)
         Me.bOk.TabIndex = 21
         Me.bOk.Text = "Ok"
         Me.bOk.UseVisualStyleBackColor = True
         ' 
         ' bCancel
         ' 
         Me.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.bCancel.Location = New System.Drawing.Point(210, 416)
         Me.bCancel.Name = "bCancel"
         Me.bCancel.Size = New System.Drawing.Size(75, 23)
         Me.bCancel.TabIndex = 22
         Me.bCancel.Text = "Cancel"
         Me.bCancel.UseVisualStyleBackColor = True
         ' 
         ' txtSenderLocationID
         ' 
         Me.txtSenderLocationID.Location = New System.Drawing.Point(127, 123)
         Me.txtSenderLocationID.Name = "txtSenderLocationID"
         Me.txtSenderLocationID.Size = New System.Drawing.Size(183, 20)
         Me.txtSenderLocationID.TabIndex = 4
         Me.toolTip.SetToolTip(Me.txtSenderLocationID, "Tags 142. Assigned value used to identify specific message originator's location (" + "i.e. geographic location and/or desk, trader).")
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(22, 122)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(96, 23)
         Me.label1.TabIndex = 59
         Me.label1.Text = "SenderLocationID"
         Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' errorProvider
         ' 
         Me.errorProvider.ContainerControl = Me
         ' 
         ' cbSetResetSeqNumFlag
         ' 
         Me.cbSetResetSeqNumFlag.AutoSize = True
         Me.cbSetResetSeqNumFlag.Location = New System.Drawing.Point(25, 378)
         Me.cbSetResetSeqNumFlag.Name = "cbSetResetSeqNumFlag"
         Me.cbSetResetSeqNumFlag.Size = New System.Drawing.Size(241, 17)
         Me.cbSetResetSeqNumFlag.TabIndex = 60
         Me.cbSetResetSeqNumFlag.Text = "Both Sides Should Reset Sequence Numbers"
         Me.toolTip.SetToolTip(Me.cbSetResetSeqNumFlag, "Option to set the ResetSeqNumFlag(141) in the initial Logon(A) message.")
         Me.cbSetResetSeqNumFlag.UseVisualStyleBackColor = True
         ' 
         ' toolTip
         ' 
         Me.toolTip.AutomaticDelay = 100
         Me.toolTip.AutoPopDelay = 5000
         Me.toolTip.InitialDelay = 100
         Me.toolTip.ReshowDelay = 20
         ' 
         ' txtTargetLocationID
         ' 
         Me.txtTargetLocationID.Location = New System.Drawing.Point(127, 198)
         Me.txtTargetLocationID.Name = "txtTargetLocationID"
         Me.txtTargetLocationID.Size = New System.Drawing.Size(183, 20)
         Me.txtTargetLocationID.TabIndex = 61
         Me.toolTip.SetToolTip(Me.txtTargetLocationID, "Tags 143. Assigned value used to identify specific message destination's location " + "(i.e. geographic location and/or desk, trader)")
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(22, 202)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(90, 13)
         Me.label2.TabIndex = 62
         Me.label2.Text = "TargetLocationID"
         ' 
         ' SessionSettingsForm
         ' 
         Me.AcceptButton = Me.bOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me.bCancel
         Me.ClientSize = New System.Drawing.Size(343, 459)
         Me.Controls.Add(label2)
         Me.Controls.Add(txtTargetLocationID)
         Me.Controls.Add(cbSetResetSeqNumFlag)
         Me.Controls.Add(txtSenderLocationID)
         Me.Controls.Add(label1)
         Me.Controls.Add(bCancel)
         Me.Controls.Add(bOk)
         Me.Controls.Add(cbKeepSequenceNumbersAfterLogout)
         Me.Controls.Add(label10)
         Me.Controls.Add(txtHost)
         Me.Controls.Add(txtPassword)
         Me.Controls.Add(txtPort)
         Me.Controls.Add(txtSenderSubId)
         Me.Controls.Add(txtTargetCompId)
         Me.Controls.Add(txtIncomingSeqNum)
         Me.Controls.Add(txtTargetSubId)
         Me.Controls.Add(txtOutgoingSeqNum)
         Me.Controls.Add(txtSenderCompId)
         Me.Controls.Add(txtHBI)
         Me.Controls.Add(txtUsername)
         Me.Controls.Add(label6)
         Me.Controls.Add(label11)
         Me.Controls.Add(label5)
         Me.Controls.Add(label7)
         Me.Controls.Add(label4)
         Me.Controls.Add(label13)
         Me.Controls.Add(label8)
         Me.Controls.Add(label3)
         Me.Controls.Add(label9)
         Me.Controls.Add(label12)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
         Me.Name = "SessionSettingsForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Session Settings"
         CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()
      End Sub 'InitializeComponent 
      
      #End Region
      
      Private cbKeepSequenceNumbersAfterLogout As System.Windows.Forms.CheckBox
      Private label10 As System.Windows.Forms.Label
      Private txtHost As System.Windows.Forms.TextBox
      Private txtPassword As System.Windows.Forms.TextBox
      Private WithEvents txtPort As System.Windows.Forms.TextBox
      Private txtSenderSubId As System.Windows.Forms.TextBox
      Private txtTargetCompId As System.Windows.Forms.TextBox
      Private WithEvents txtIncomingSeqNum As System.Windows.Forms.TextBox
      Private txtTargetSubId As System.Windows.Forms.TextBox
      Private WithEvents txtOutgoingSeqNum As System.Windows.Forms.TextBox
      Private txtSenderCompId As System.Windows.Forms.TextBox
      Private WithEvents txtHBI As System.Windows.Forms.TextBox
      Private txtUsername As System.Windows.Forms.TextBox
      Private label6 As System.Windows.Forms.Label
      Private label11 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private label7 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private label13 As System.Windows.Forms.Label
      Private label8 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label9 As System.Windows.Forms.Label
      Private label12 As System.Windows.Forms.Label
      Private WithEvents bOk As System.Windows.Forms.Button
      Private WithEvents bCancel As System.Windows.Forms.Button
      Private txtSenderLocationID As System.Windows.Forms.TextBox
      Private label1 As System.Windows.Forms.Label
      Private errorProvider As System.Windows.Forms.ErrorProvider
      Private cbSetResetSeqNumFlag As System.Windows.Forms.CheckBox
      Private toolTip As System.Windows.Forms.ToolTip
      Private txtTargetLocationID As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      
      
      Public Sub New(inSeqNum As Integer, outSeqNum As Integer)
         InitializeComponent()
         
         Me.txtHost.Text = ConfigurationManager.AppSettings("Host")
         Me.txtPort.Text = ConfigurationManager.AppSettings("Port")
         Me.txtSenderCompId.Text = ConfigurationManager.AppSettings("SenderCompID")
         Me.txtSenderSubId.Text = ConfigurationManager.AppSettings("SenderSubID")
         Me.txtSenderLocationID.Text = ConfigurationManager.AppSettings("SenderLocationID")
         Me.txtTargetCompId.Text = ConfigurationManager.AppSettings("TargetCompID")
         Me.txtTargetSubId.Text = ConfigurationManager.AppSettings("TargetSubID")
         Me.txtTargetLocationID.Text = ConfigurationManager.AppSettings("TargetLocationID")
         Me.txtHBI.Text = ConfigurationManager.AppSettings("HBI")
         Me.txtUsername.Text = ConfigurationManager.AppSettings("Username")
         Me.txtPassword.Text = ConfigurationManager.AppSettings("Password")
         
         Dim keepSeqNum As Boolean = True
         Boolean.TryParse(ConfigurationManager.AppSettings("KeepSeqNum"), keepSeqNum)
         Me.cbKeepSequenceNumbersAfterLogout.Checked = keepSeqNum
         
         Dim setResetSeqNumFlag As Boolean = True
         
         Boolean.TryParse(ConfigurationManager.AppSettings("SetResetSeqNumFlag"), setResetSeqNumFlag)
         Me.cbSetResetSeqNumFlag.Checked = setResetSeqNumFlag
         
         txtIncomingSeqNum.Text = inSeqNum.ToString()
         txtOutgoingSeqNum.Text = outSeqNum.ToString()
      End Sub 'New
      
      
      Public ReadOnly Property InSeqNum() As Integer
         Get
            Dim res As Integer = - 1
            Integer.TryParse(txtIncomingSeqNum.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, res)
            Return res
         End Get
      End Property
      
      
      Public ReadOnly Property OutSeqNum() As Integer
         Get
            Dim res As Integer = - 1
            Integer.TryParse(txtOutgoingSeqNum.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, res)
            Return res
         End Get
      End Property
      
      
      Private Sub Save()
         Dim cfg As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
         cfg.AppSettings.Settings("Host").Value = txtHost.Text
         cfg.AppSettings.Settings("Port").Value = txtPort.Text
         cfg.AppSettings.Settings("SenderCompID").Value = txtSenderCompId.Text
         cfg.AppSettings.Settings("SenderSubID").Value = txtSenderSubId.Text
         cfg.AppSettings.Settings("SenderLocationID").Value = txtSenderLocationID.Text
         cfg.AppSettings.Settings("TargetCompID").Value = txtTargetCompId.Text
         cfg.AppSettings.Settings("TargetSubID").Value = txtTargetSubId.Text
         cfg.AppSettings.Settings("TargetLocationID").Value = txtTargetLocationID.Text
         cfg.AppSettings.Settings("HBI").Value = txtHBI.Text
         cfg.AppSettings.Settings("Username").Value = txtUsername.Text
         cfg.AppSettings.Settings("Password").Value = txtPassword.Text
         cfg.AppSettings.Settings("KeepSeqNum").Value = cbKeepSequenceNumbersAfterLogout.Checked.ToString()
         cfg.AppSettings.Settings("SetResetSeqNumFlag").Value = Me.cbSetResetSeqNumFlag.Checked.ToString()
         cfg.Save()
         ConfigurationManager.RefreshSection("appSettings")
      End Sub 'Save
      
      
      Private Sub bCancel_Click(sender As Object, e As EventArgs) Handles bCancel.Click
         Close()
      End Sub 'bCancel_Click
      
      
      Private Sub bOk_Click(sender As Object, e As EventArgs) Handles bOk.Click
         Save()
         Close()
      End Sub 'bOk_Click
      
      
      Private Sub txtPort_Validating(sender As Object, e As CancelEventArgs) Handles txtPort.Validating
         Try
            Dim x As Integer = Integer.Parse(Me.txtPort.Text)
            errorProvider.SetError(txtPort, "")
            
            If x <= 0 Then
               errorProvider.SetError(txtPort, "Port number must be positive.")
               e.Cancel = True
            End If
            Catch
                errorProvider.SetError(txtPort, "Not an integer value.")
                e.Cancel = True
         End Try
      End Sub 'txtPort_Validating
      
      
      Private Sub ValidatePositiveInteger(field As TextBox, name As String, e As CancelEventArgs)
         Try
            Dim x As Integer = Integer.Parse(field.Text)
            errorProvider.SetError(field, "")
            
            If x < 0 Then
               errorProvider.SetError(field, name + " must be positive or 0.")
               e.Cancel = True
            End If
            Catch
                errorProvider.SetError(field, "Not an integer value.")
                e.Cancel = True
         End Try
      End Sub 'ValidatePositiveInteger
      
      
      Private Sub txtHBI_Validating(sender As Object, e As CancelEventArgs) Handles txtHBI.Validating
         ValidatePositiveInteger(Me.txtHBI, "Heartbeat Interval", e)
      End Sub 'txtHBI_Validating
      
      
      Private Sub txtIncomingSeqNum_Validating(sender As Object, e As CancelEventArgs) Handles txtIncomingSeqNum.Validating
         ValidatePositiveInteger(Me.txtIncomingSeqNum, "Incoming MsgSeqNum", e)
      End Sub 'txtIncomingSeqNum_Validating
      
      
      Private Sub txtOutgoingSeqNum_Validating(sender As Object, e As CancelEventArgs) Handles txtOutgoingSeqNum.Validating
         ValidatePositiveInteger(Me.txtOutgoingSeqNum, "Outgoing MsgSeqNum", e)
      End Sub 'txtOutgoingSeqNum_Validating
   End Class 'SessionSettingsForm
End Namespace 'Biz.Onixs.TradingClientSample