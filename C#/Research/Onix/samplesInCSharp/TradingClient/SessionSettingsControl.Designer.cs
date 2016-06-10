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
	partial class SessionSettingsControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label27;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label16;
			System.Windows.Forms.Label label11;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label14;
			System.Windows.Forms.Label label15;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label10;
			this.tradingSetResetSeqNumFlagCheckBox = new System.Windows.Forms.CheckBox();
			this.txtSslCertificateFile = new System.Windows.Forms.TextBox();
			this.clientIdTextBox = new System.Windows.Forms.TextBox();
			this.cbKeepSequenceNumbersAfterLogout = new System.Windows.Forms.CheckBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cbUseSslEncryption = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtAccount = new System.Windows.Forms.TextBox();
			this.txtTargetLocationID = new System.Windows.Forms.TextBox();
			this.groupBoxSequenceNumbers = new System.Windows.Forms.GroupBox();
			this.nudOutgoingSeqNum = new System.Windows.Forms.NumericUpDown();
			this.nudIncomingSeqNum = new System.Windows.Forms.NumericUpDown();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.btnOpenFileDialog = new System.Windows.Forms.Button();
			this.txtSenderLocationID = new System.Windows.Forms.TextBox();
			this.txtHBI = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtRawData = new System.Windows.Forms.TextBox();
			this.cmbVersion = new System.Windows.Forms.ComboBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.txtSenderCompId = new System.Windows.Forms.TextBox();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.txtTargetSubId = new System.Windows.Forms.TextBox();
			this.txtSenderSubId = new System.Windows.Forms.TextBox();
			this.txtTargetCompId = new System.Windows.Forms.TextBox();
			this.groupBoxSSL = new System.Windows.Forms.GroupBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			label3 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			this.groupBoxSequenceNumbers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudOutgoingSeqNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudIncomingSeqNum)).BeginInit();
			this.groupBoxSSL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			label3.Location = new System.Drawing.Point(3, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(96, 23);
			label3.TabIndex = 88;
			label3.Text = "Target Host:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label27
			// 
			label27.Location = new System.Drawing.Point(5, 176);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(96, 23);
			label27.TabIndex = 104;
			label27.Text = "ClientId (109):";
			label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			label6.Location = new System.Drawing.Point(3, 201);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(96, 23);
			label6.TabIndex = 91;
			label6.Text = "SenderSubID (50):";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 281);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(120, 13);
			label2.TabIndex = 98;
			label2.Text = "TargetLocationID (143):";
			// 
			// label16
			// 
			label16.Location = new System.Drawing.Point(4, 151);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(96, 23);
			label16.TabIndex = 102;
			label16.Text = "Account (1):";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			label11.Location = new System.Drawing.Point(4, 326);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(113, 23);
			label11.TabIndex = 96;
			label11.Text = "Password (554):";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			label9.Location = new System.Drawing.Point(4, 126);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(96, 23);
			label9.TabIndex = 94;
			label9.Text = "HeartBtInt (108):";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			label1.Location = new System.Drawing.Point(3, 226);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(123, 23);
			label1.TabIndex = 97;
			label1.Text = "SenderLocationID (142):";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			label5.Location = new System.Drawing.Point(3, 76);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(113, 23);
			label5.TabIndex = 90;
			label5.Text = "SenderCompID (49):";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			label8.Location = new System.Drawing.Point(3, 251);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(96, 23);
			label8.TabIndex = 93;
			label8.Text = "TargetSubID (57):";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			label14.Location = new System.Drawing.Point(4, 351);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(96, 23);
			label14.TabIndex = 99;
			label14.Text = "RawData (96):";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(4, 55);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(103, 13);
			label15.TabIndex = 101;
			label15.Text = "FIX ProtocolVersion:";
			// 
			// label7
			// 
			label7.Location = new System.Drawing.Point(3, 101);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(100, 23);
			label7.TabIndex = 92;
			label7.Text = "TargetCompID (56):";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			label4.Location = new System.Drawing.Point(4, 25);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(96, 23);
			label4.TabIndex = 89;
			label4.Text = "Port:";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			label10.Location = new System.Drawing.Point(4, 301);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(100, 23);
			label10.TabIndex = 95;
			label10.Text = "Username (553):";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tradingSetResetSeqNumFlagCheckBox
			// 
			this.tradingSetResetSeqNumFlagCheckBox.AutoSize = true;
			this.tradingSetResetSeqNumFlagCheckBox.Location = new System.Drawing.Point(13, 98);
			this.tradingSetResetSeqNumFlagCheckBox.Name = "tradingSetResetSeqNumFlagCheckBox";
			this.tradingSetResetSeqNumFlagCheckBox.Size = new System.Drawing.Size(281, 17);
			this.tradingSetResetSeqNumFlagCheckBox.TabIndex = 3;
			this.tradingSetResetSeqNumFlagCheckBox.Text = "Both Sides Should Reset Sequence Numbers (141=Y)";
			this.tradingSetResetSeqNumFlagCheckBox.UseVisualStyleBackColor = true;
			// 
			// txtSslCertificateFile
			// 
			this.txtSslCertificateFile.Location = new System.Drawing.Point(13, 44);
			this.txtSslCertificateFile.Name = "txtSslCertificateFile";
			this.txtSslCertificateFile.Size = new System.Drawing.Size(268, 20);
			this.txtSslCertificateFile.TabIndex = 1;
			// 
			// clientIdTextBox
			// 
			this.clientIdTextBox.Location = new System.Drawing.Point(132, 177);
			this.clientIdTextBox.Name = "clientIdTextBox";
			this.clientIdTextBox.Size = new System.Drawing.Size(205, 20);
			this.clientIdTextBox.TabIndex = 103;
			this.clientIdTextBox.Tag = "Firm identifier used in third party-transaction";
			// 
			// cbKeepSequenceNumbersAfterLogout
			// 
			this.cbKeepSequenceNumbersAfterLogout.Location = new System.Drawing.Point(13, 75);
			this.cbKeepSequenceNumbersAfterLogout.Name = "cbKeepSequenceNumbersAfterLogout";
			this.cbKeepSequenceNumbersAfterLogout.Size = new System.Drawing.Size(224, 17);
			this.cbKeepSequenceNumbersAfterLogout.TabIndex = 2;
			this.cbKeepSequenceNumbersAfterLogout.Text = "Keep Sequence Numbers After Logout";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(29, 46);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(96, 23);
			this.label13.TabIndex = 52;
			this.label13.Text = "OutgoingSeqNum";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbUseSslEncryption
			// 
			this.cbUseSslEncryption.AutoSize = true;
			this.cbUseSslEncryption.Location = new System.Drawing.Point(13, 23);
			this.cbUseSslEncryption.Name = "cbUseSslEncryption";
			this.cbUseSslEncryption.Size = new System.Drawing.Size(121, 17);
			this.cbUseSslEncryption.TabIndex = 0;
			this.cbUseSslEncryption.Text = "Use SSL Encryption";
			this.cbUseSslEncryption.UseVisualStyleBackColor = true;
			this.cbUseSslEncryption.CheckedChanged += new System.EventHandler(this.cbUseSslEncryption_CheckedChanged);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(29, 23);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(96, 23);
			this.label12.TabIndex = 50;
			this.label12.Text = "IncomingSeqNum";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAccount
			// 
			this.txtAccount.Location = new System.Drawing.Point(132, 152);
			this.txtAccount.Name = "txtAccount";
			this.txtAccount.Size = new System.Drawing.Size(205, 20);
			this.txtAccount.TabIndex = 79;
			// 
			// txtTargetLocationID
			// 
			this.txtTargetLocationID.Location = new System.Drawing.Point(132, 277);
			this.txtTargetLocationID.Name = "txtTargetLocationID";
			this.txtTargetLocationID.Size = new System.Drawing.Size(205, 20);
			this.txtTargetLocationID.TabIndex = 83;
			// 
			// groupBoxSequenceNumbers
			// 
			this.groupBoxSequenceNumbers.Controls.Add(this.nudOutgoingSeqNum);
			this.groupBoxSequenceNumbers.Controls.Add(this.nudIncomingSeqNum);
			this.groupBoxSequenceNumbers.Controls.Add(this.tradingSetResetSeqNumFlagCheckBox);
			this.groupBoxSequenceNumbers.Controls.Add(this.cbKeepSequenceNumbersAfterLogout);
			this.groupBoxSequenceNumbers.Controls.Add(this.label13);
			this.groupBoxSequenceNumbers.Controls.Add(this.label12);
			this.groupBoxSequenceNumbers.Location = new System.Drawing.Point(8, 380);
			this.groupBoxSequenceNumbers.Name = "groupBoxSequenceNumbers";
			this.groupBoxSequenceNumbers.Size = new System.Drawing.Size(329, 126);
			this.groupBoxSequenceNumbers.TabIndex = 100;
			this.groupBoxSequenceNumbers.TabStop = false;
			this.groupBoxSequenceNumbers.Text = " Sequence Numbers  ";
			// 
			// nudOutgoingSeqNum
			// 
			this.nudOutgoingSeqNum.Location = new System.Drawing.Point(124, 49);
			this.nudOutgoingSeqNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nudOutgoingSeqNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudOutgoingSeqNum.Name = "nudOutgoingSeqNum";
			this.nudOutgoingSeqNum.Size = new System.Drawing.Size(157, 20);
			this.nudOutgoingSeqNum.TabIndex = 54;
			this.nudOutgoingSeqNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// nudIncomingSeqNum
			// 
			this.nudIncomingSeqNum.Location = new System.Drawing.Point(124, 26);
			this.nudIncomingSeqNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nudIncomingSeqNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudIncomingSeqNum.Name = "nudIncomingSeqNum";
			this.nudIncomingSeqNum.Size = new System.Drawing.Size(157, 20);
			this.nudIncomingSeqNum.TabIndex = 53;
			this.nudIncomingSeqNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(132, 302);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(205, 20);
			this.txtUsername.TabIndex = 84;
			// 
			// btnOpenFileDialog
			// 
			this.btnOpenFileDialog.Location = new System.Drawing.Point(287, 41);
			this.btnOpenFileDialog.Name = "btnOpenFileDialog";
			this.btnOpenFileDialog.Size = new System.Drawing.Size(36, 23);
			this.btnOpenFileDialog.TabIndex = 2;
			this.btnOpenFileDialog.Text = "...";
			this.btnOpenFileDialog.UseVisualStyleBackColor = true;
			this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
			// 
			// txtSenderLocationID
			// 
			this.txtSenderLocationID.Location = new System.Drawing.Point(132, 227);
			this.txtSenderLocationID.Name = "txtSenderLocationID";
			this.txtSenderLocationID.Size = new System.Drawing.Size(205, 20);
			this.txtSenderLocationID.TabIndex = 81;
			// 
			// txtHBI
			// 
			this.txtHBI.Location = new System.Drawing.Point(132, 127);
			this.txtHBI.Name = "txtHBI";
			this.txtHBI.Size = new System.Drawing.Size(205, 20);
			this.txtHBI.TabIndex = 78;
			this.txtHBI.Text = "30";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(132, 327);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(205, 20);
			this.txtPassword.TabIndex = 85;
			// 
			// txtRawData
			// 
			this.txtRawData.Location = new System.Drawing.Point(132, 352);
			this.txtRawData.Name = "txtRawData";
			this.txtRawData.Size = new System.Drawing.Size(205, 20);
			this.txtRawData.TabIndex = 86;
			// 
			// cmbVersion
			// 
			this.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVersion.FormattingEnabled = true;
			this.cmbVersion.Location = new System.Drawing.Point(132, 51);
			this.cmbVersion.Name = "cmbVersion";
			this.cmbVersion.Size = new System.Drawing.Size(205, 21);
			this.cmbVersion.TabIndex = 75;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(132, 26);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(205, 20);
			this.txtPort.TabIndex = 74;
			this.txtPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtPort_Validating);
			// 
			// txtSenderCompId
			// 
			this.txtSenderCompId.Location = new System.Drawing.Point(132, 77);
			this.txtSenderCompId.Name = "txtSenderCompId";
			this.txtSenderCompId.Size = new System.Drawing.Size(205, 20);
			this.txtSenderCompId.TabIndex = 76;
			// 
			// txtHost
			// 
			this.txtHost.Location = new System.Drawing.Point(132, 1);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(205, 20);
			this.txtHost.TabIndex = 73;
			// 
			// txtTargetSubId
			// 
			this.txtTargetSubId.Location = new System.Drawing.Point(132, 252);
			this.txtTargetSubId.Name = "txtTargetSubId";
			this.txtTargetSubId.Size = new System.Drawing.Size(205, 20);
			this.txtTargetSubId.TabIndex = 82;
			// 
			// txtSenderSubId
			// 
			this.txtSenderSubId.Location = new System.Drawing.Point(132, 202);
			this.txtSenderSubId.Name = "txtSenderSubId";
			this.txtSenderSubId.Size = new System.Drawing.Size(205, 20);
			this.txtSenderSubId.TabIndex = 80;
			// 
			// txtTargetCompId
			// 
			this.txtTargetCompId.Location = new System.Drawing.Point(132, 102);
			this.txtTargetCompId.Name = "txtTargetCompId";
			this.txtTargetCompId.Size = new System.Drawing.Size(205, 20);
			this.txtTargetCompId.TabIndex = 77;
			// 
			// groupBoxSSL
			// 
			this.groupBoxSSL.Controls.Add(this.btnOpenFileDialog);
			this.groupBoxSSL.Controls.Add(this.txtSslCertificateFile);
			this.groupBoxSSL.Controls.Add(this.cbUseSslEncryption);
			this.groupBoxSSL.Location = new System.Drawing.Point(8, 516);
			this.groupBoxSSL.Name = "groupBoxSSL";
			this.groupBoxSSL.Size = new System.Drawing.Size(329, 79);
			this.groupBoxSSL.TabIndex = 87;
			this.groupBoxSSL.TabStop = false;
			this.groupBoxSSL.Text = " SSL  ";
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// toolTip
			// 
			this.toolTip.AutomaticDelay = 100;
			this.toolTip.AutoPopDelay = 5000;
			this.toolTip.InitialDelay = 100;
			this.toolTip.ReshowDelay = 20;
			// 
			// openFileDialog
			// 
			this.openFileDialog.RestoreDirectory = true;
			// 
			// SessionSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.clientIdTextBox);
			this.Controls.Add(label3);
			this.Controls.Add(label27);
			this.Controls.Add(this.txtAccount);
			this.Controls.Add(this.txtTargetLocationID);
			this.Controls.Add(label6);
			this.Controls.Add(this.groupBoxSequenceNumbers);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(label2);
			this.Controls.Add(label16);
			this.Controls.Add(this.txtSenderLocationID);
			this.Controls.Add(label11);
			this.Controls.Add(label9);
			this.Controls.Add(this.txtHBI);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtRawData);
			this.Controls.Add(this.cmbVersion);
			this.Controls.Add(label1);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(label5);
			this.Controls.Add(label8);
			this.Controls.Add(this.txtSenderCompId);
			this.Controls.Add(this.txtHost);
			this.Controls.Add(label14);
			this.Controls.Add(label15);
			this.Controls.Add(this.txtTargetSubId);
			this.Controls.Add(this.txtSenderSubId);
			this.Controls.Add(label7);
			this.Controls.Add(label4);
			this.Controls.Add(this.txtTargetCompId);
			this.Controls.Add(label10);
			this.Controls.Add(this.groupBoxSSL);
			this.Name = "SessionSettingsControl";
			this.Size = new System.Drawing.Size(342, 599);
			this.Load += new System.EventHandler(this.SessionSettingsControl_Load);
			this.groupBoxSequenceNumbers.ResumeLayout(false);
			this.groupBoxSequenceNumbers.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudOutgoingSeqNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudIncomingSeqNum)).EndInit();
			this.groupBoxSSL.ResumeLayout(false);
			this.groupBoxSSL.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox tradingSetResetSeqNumFlagCheckBox;
		private System.Windows.Forms.TextBox txtSslCertificateFile;
		private System.Windows.Forms.TextBox clientIdTextBox;
		private System.Windows.Forms.CheckBox cbKeepSequenceNumbersAfterLogout;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox cbUseSslEncryption;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtAccount;
		private System.Windows.Forms.TextBox txtTargetLocationID;
		private System.Windows.Forms.GroupBox groupBoxSequenceNumbers;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Button btnOpenFileDialog;
		private System.Windows.Forms.TextBox txtSenderLocationID;
		private System.Windows.Forms.TextBox txtHBI;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtRawData;
		private System.Windows.Forms.ComboBox cmbVersion;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.TextBox txtSenderCompId;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.TextBox txtTargetSubId;
		private System.Windows.Forms.TextBox txtSenderSubId;
		private System.Windows.Forms.TextBox txtTargetCompId;
		private System.Windows.Forms.GroupBox groupBoxSSL;
		private System.Windows.Forms.NumericUpDown nudOutgoingSeqNum;
		private System.Windows.Forms.NumericUpDown nudIncomingSeqNum;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}
