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
    partial class MarketDataUnsubscribeRequestForm
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
			this.symbolComboBox = new System.Windows.Forms.ComboBox();
			this.sendButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 13);
			label1.TabIndex = 0;
			label1.Text = "Symbol:";
			this.toolTip.SetToolTip(label1, "Currency pair or instrument.");
			// 
			// symbolComboBox
			// 
			this.symbolComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.symbolComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.symbolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.symbolComboBox.FormattingEnabled = true;
			this.symbolComboBox.Location = new System.Drawing.Point(63, 18);
			this.symbolComboBox.Name = "symbolComboBox";
			this.symbolComboBox.Size = new System.Drawing.Size(188, 21);
			this.symbolComboBox.TabIndex = 0;
			// 
			// sendButton
			// 
			this.sendButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sendButton.Location = new System.Drawing.Point(17, 45);
			this.sendButton.Name = "sendButton";
			this.sendButton.Size = new System.Drawing.Size(75, 23);
			this.sendButton.TabIndex = 2;
			this.sendButton.Text = "Send";
			this.sendButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(176, 45);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// MarketDataUnsubscribeRequestForm
			// 
			this.AcceptButton = this.sendButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(271, 88);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.sendButton);
			this.Controls.Add(this.symbolComboBox);
			this.Controls.Add(label1);
			this.Name = "MarketDataUnsubscribeRequestForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Market Data Request";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox symbolComboBox;
        private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip toolTip;
    }
}