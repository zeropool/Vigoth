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
Imports System.Text
Imports System.Windows.Forms


Namespace Biz.Onixs.TradingClientSample
   
   Public Class AboutDlg
      Inherits Form
      
      Public Sub New()
         InitializeComponent()
         lVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
      End Sub 'New
      
      
      Private Sub linkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
         System.Diagnostics.Process.Start("http://www.onixs.biz")
      End Sub 'linkLabel1_LinkClicked
      
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutDlg))
            Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
            Me.bOk = New System.Windows.Forms.Button()
            Me.lVersion = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label1 = New System.Windows.Forms.Label()
            Me.pictureBox1 = New System.Windows.Forms.PictureBox()
            CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'linkLabel1
            '
            Me.linkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.linkLabel1.Location = New System.Drawing.Point(10, 114)
            Me.linkLabel1.Name = "linkLabel1"
            Me.linkLabel1.Size = New System.Drawing.Size(100, 26)
            Me.linkLabel1.TabIndex = 12
            Me.linkLabel1.TabStop = True
            Me.linkLabel1.Text = "(c) Onix Solutions"
            '
            'bOk
            '
            Me.bOk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.bOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.bOk.Location = New System.Drawing.Point(170, 111)
            Me.bOk.Name = "bOk"
            Me.bOk.Size = New System.Drawing.Size(70, 27)
            Me.bOk.TabIndex = 11
            Me.bOk.Text = "Ok"
            '
            'lVersion
            '
            Me.lVersion.AutoSize = True
            Me.lVersion.Location = New System.Drawing.Point(213, 58)
            Me.lVersion.Name = "lVersion"
            Me.lVersion.Size = New System.Drawing.Size(40, 13)
            Me.lVersion.TabIndex = 10
            Me.lVersion.Text = "1.0.0.0"
            '
            'label2
            '
            Me.label2.Location = New System.Drawing.Point(162, 58)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(53, 23)
            Me.label2.TabIndex = 9
            Me.label2.Text = "Verison: "
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label1.Location = New System.Drawing.Point(162, 35)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(150, 23)
            Me.label1.TabIndex = 8
            Me.label1.Text = "Trading Client Sample"
            '
            'pictureBox1
            '
            Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
            Me.pictureBox1.Location = New System.Drawing.Point(12, 12)
            Me.pictureBox1.Name = "pictureBox1"
            Me.pictureBox1.Size = New System.Drawing.Size(144, 60)
            Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.pictureBox1.TabIndex = 7
            Me.pictureBox1.TabStop = False
            '
            'AboutDlg
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(307, 158)
            Me.Controls.Add(Me.linkLabel1)
            Me.Controls.Add(Me.bOk)
            Me.Controls.Add(Me.lVersion)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.pictureBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AboutDlg"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "About Trading Client Sample"
            CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub 'InitializeComponent 
      
      #End Region
      
      Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
      Private bOk As System.Windows.Forms.Button
      Private lVersion As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
      Private pictureBox1 As System.Windows.Forms.PictureBox
   End Class 'AboutDlg
End Namespace 'Biz.Onixs.TradingClientSample