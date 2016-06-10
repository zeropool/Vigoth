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
    partial class ReplayLogFileForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(34, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(26, 13);
            label1.TabIndex = 0;
            label1.Text = "File:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(34, 72);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(32, 13);
            label2.TabIndex = 6;
            label2.Text = "Filter:";
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(82, 31);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(197, 20);
            this.fileTextBox.TabIndex = 0;
            // 
            // filterComboBox
            // 
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
            "All application-level messages",
            "New Order - Single  (D) messages",
            "Execution Report (8) messages",
            "Market Data - Incremental Refresh (X) messages",
            "Snapshot/Full Refresh (W) messages"});
            this.filterComboBox.Location = new System.Drawing.Point(82, 68);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(221, 21);
            this.filterComboBox.TabIndex = 2;
            // 
            // OKbutton
            // 
            this.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbutton.Location = new System.Drawing.Point(34, 115);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 3;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(228, 115);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(280, 30);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(23, 23);
            this.fileButton.TabIndex = 1;
            this.fileButton.Text = "...";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Input files|*.in|Output files|*.out|Summary files|*.summary|All files|*.*";
            this.openFileDialog.FilterIndex = 3;
            this.openFileDialog.RestoreDirectory = true;
            // 
            // ReplayLogFileForm
            // 
            this.AcceptButton = this.OKbutton;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(348, 167);
            this.Controls.Add(label2);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(label1);
            this.Name = "ReplayLogFileForm";
            this.Text = "Replay Log File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
