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
	partial class SettingsForm
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
            this.tbBidPrice = new System.Windows.Forms.TextBox();
            this.tbAskPrice = new System.Windows.Forms.TextBox();
            this.tbPriceIncrement = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbBidPrice
            // 
            this.tbBidPrice.Location = new System.Drawing.Point(119, 38);
            this.tbBidPrice.Name = "tbBidPrice";
            this.tbBidPrice.Size = new System.Drawing.Size(208, 20);
            this.tbBidPrice.TabIndex = 51;
            // 
            // tbAskPrice
            // 
            this.tbAskPrice.Location = new System.Drawing.Point(119, 12);
            this.tbAskPrice.Name = "tbAskPrice";
            this.tbAskPrice.Size = new System.Drawing.Size(208, 20);
            this.tbAskPrice.TabIndex = 43;
            // 
            // tbPriceIncrement
            // 
            this.tbPriceIncrement.Location = new System.Drawing.Point(119, 64);
            this.tbPriceIncrement.Name = "tbPriceIncrement";
            this.tbPriceIncrement.Size = new System.Drawing.Size(208, 20);
            this.tbPriceIncrement.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(14, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 23);
            this.label13.TabIndex = 52;
            this.label13.Text = "Price Increment";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(14, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 23);
            this.label8.TabIndex = 42;
            this.label8.Text = "Ask Price";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(14, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 23);
            this.label12.TabIndex = 50;
            this.label12.Text = "Bid Price";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(48, 90);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 57;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(226, 90);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 58;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(339, 125);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.tbBidPrice);
            this.Controls.Add(this.tbAskPrice);
            this.Controls.Add(this.tbPriceIncrement);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbBidPrice;
		private System.Windows.Forms.TextBox tbAskPrice;
		private System.Windows.Forms.TextBox tbPriceIncrement;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button bOk;
		private System.Windows.Forms.Button bCancel;
	}
}