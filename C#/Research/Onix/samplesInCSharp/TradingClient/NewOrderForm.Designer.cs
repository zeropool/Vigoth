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
	partial class NewOrderForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            this.txtClOrdID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.cmbSymbol = new System.Windows.Forms.ComboBox();
            this.cmbSide = new System.Windows.Forms.ComboBox();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtText = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(68, 13);
            label1.TabIndex = 0;
            label1.Text = "ClOrdID (11):";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(label1, "Unique identifier for Order as assigned by institution");
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(27, 220);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(73, 13);
            label7.TabIndex = 18;
            label7.Text = "Currency (15):";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(label7, "Identifies currency used for price. Absence of this field is interpreted as the d" +
                    "efault for the security.");
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(27, 251);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(52, 13);
            label8.TabIndex = 19;
            label8.Text = "Text (58):";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClOrdID
            // 
            this.txtClOrdID.Location = new System.Drawing.Point(107, 27);
            this.txtClOrdID.Name = "txtClOrdID";
            this.txtClOrdID.Size = new System.Drawing.Size(162, 20);
            this.txtClOrdID.TabIndex = 6;
            this.txtClOrdID.TextChanged += new System.EventHandler(this.textBoxClOrdID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Symbol (55):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label2, "Ticker symbol");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Side (54):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label3, "Side of Order");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "OrdType (40):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label4, "Order type");
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(107, 154);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(162, 20);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.Text = "100000";
            this.txtQuantity.TextChanged += new System.EventHandler(this.textBoxClOrdID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = " OrderQty (38):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label5, "Number of shares ordered. This represents the number of shares for equities or ba" +
                    "sed on normal convention the number of contracts for options, futures, convertib" +
                    "le bonds, etc.");
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(107, 185);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(162, 20);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.Text = "80";
            this.txtPrice.TextChanged += new System.EventHandler(this.textBoxClOrdID_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Price (44):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label6, "Price per share");
            // 
            // buttonSend
            // 
            this.buttonSend.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSend.Location = new System.Drawing.Point(30, 292);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 20);
            this.buttonSend.TabIndex = 7;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(195, 292);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 20);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // cmbSymbol
            // 
            this.cmbSymbol.FormattingEnabled = true;
            this.cmbSymbol.Items.AddRange(new object[] {
            "MSFT",
            "EUR/USD",
            "JPM",
            "CSCO"});
            this.cmbSymbol.Location = new System.Drawing.Point(107, 58);
            this.cmbSymbol.Name = "cmbSymbol";
            this.cmbSymbol.Size = new System.Drawing.Size(162, 21);
            this.cmbSymbol.TabIndex = 0;
            this.cmbSymbol.TextChanged += new System.EventHandler(this.textBoxClOrdID_TextChanged);
            // 
            // cmbSide
            // 
            this.cmbSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSide.FormattingEnabled = true;
            this.cmbSide.Location = new System.Drawing.Point(107, 90);
            this.cmbSide.Name = "cmbSide";
            this.cmbSide.Size = new System.Drawing.Size(162, 21);
            this.cmbSide.TabIndex = 1;
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Location = new System.Drawing.Point(107, 122);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(162, 21);
            this.cmbOrderType.TabIndex = 2;
            this.cmbOrderType.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderType_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
            "USD",
            "EUR"});
            this.cmbCurrency.Location = new System.Drawing.Point(107, 216);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(162, 21);
            this.cmbCurrency.TabIndex = 5;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(107, 247);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(162, 20);
            this.txtText.TabIndex = 20;
            // 
            // NewOrderForm
            // 
            this.AcceptButton = this.buttonSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(313, 341);
            this.Controls.Add(this.txtText);
            this.Controls.Add(label8);
            this.Controls.Add(label7);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.cmbOrderType);
            this.Controls.Add(this.cmbSide);
            this.Controls.Add(this.cmbSymbol);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClOrdID);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewOrderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "New Order";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox txtClOrdID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtQuantity;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonSend;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.ComboBox cmbSymbol;
		private System.Windows.Forms.ComboBox cmbSide;
		private System.Windows.Forms.ComboBox cmbOrderType;
		private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.TextBox txtText;
	}
}