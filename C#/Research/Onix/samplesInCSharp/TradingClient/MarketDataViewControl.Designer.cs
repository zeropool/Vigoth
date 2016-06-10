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
    partial class MarketDataViewControl
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.symbolColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bidSizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.offerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.offerSizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.symbolColumn,
            this.bidColumn,
            this.bidSizeColumn,
            this.offerColumn,
            this.offerSizeColumn});
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.MultiSelect = false;
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(639, 338);
			this.dataGridView.TabIndex = 0;
			// 
			// symbolColumn
			// 
			this.symbolColumn.HeaderText = "Symbol";
			this.symbolColumn.Name = "symbolColumn";
			this.symbolColumn.ReadOnly = true;
			// 
			// bidColumn
			// 
			this.bidColumn.HeaderText = "Bid";
			this.bidColumn.Name = "bidColumn";
			this.bidColumn.ReadOnly = true;
			// 
			// bidSizeColumn
			// 
			this.bidSizeColumn.HeaderText = "Bid Size";
			this.bidSizeColumn.Name = "bidSizeColumn";
			this.bidSizeColumn.ReadOnly = true;
			// 
			// offerColumn
			// 
			this.offerColumn.HeaderText = "Offer";
			this.offerColumn.Name = "offerColumn";
			this.offerColumn.ReadOnly = true;
			// 
			// offerSizeColumn
			// 
			this.offerSizeColumn.HeaderText = "Offer Size";
			this.offerSizeColumn.Name = "offerSizeColumn";
			this.offerSizeColumn.ReadOnly = true;
			// 
			// MarketDataViewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dataGridView);
			this.Name = "MarketDataViewControl";
			this.Size = new System.Drawing.Size(639, 338);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn symbolColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn bidColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn bidSizeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn offerColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn offerSizeColumn;
    }
}
