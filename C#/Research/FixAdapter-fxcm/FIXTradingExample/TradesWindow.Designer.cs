namespace FIXTradingExample
{
  partial class TradesWindow
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.grdOrders = new System.Windows.Forms.DataGridView();
      this.grdTrades = new System.Windows.Forms.DataGridView();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdTrades)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // grdOrders
      // 
      this.grdOrders.AllowUserToAddRows = false;
      this.grdOrders.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.grdOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.grdOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.grdOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.grdOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdOrders.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdOrders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.grdOrders.Location = new System.Drawing.Point(3, 28);
      this.grdOrders.Name = "grdOrders";
      this.grdOrders.RowHeadersVisible = false;
      this.grdOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.grdOrders.ShowEditingIcon = false;
      this.grdOrders.Size = new System.Drawing.Size(303, 405);
      this.grdOrders.TabIndex = 2;
      // 
      // grdTrades
      // 
      this.grdTrades.AllowUserToAddRows = false;
      this.grdTrades.AllowUserToDeleteRows = false;
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.grdTrades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
      this.grdTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.grdTrades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.grdTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdTrades.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdTrades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.grdTrades.Location = new System.Drawing.Point(3, 28);
      this.grdTrades.Name = "grdTrades";
      this.grdTrades.RowHeadersVisible = false;
      this.grdTrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.grdTrades.ShowEditingIcon = false;
      this.grdTrades.Size = new System.Drawing.Size(299, 405);
      this.grdTrades.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(303, 25);
      this.label1.TabIndex = 4;
      this.label1.Text = "Orders";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(299, 25);
      this.label2.TabIndex = 5;
      this.label2.Text = "Trades";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // splitContainer1
      // 
      this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.IsSplitterFixed = true;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
      this.splitContainer1.Size = new System.Drawing.Size(626, 440);
      this.splitContainer1.SplitterDistance = 313;
      this.splitContainer1.TabIndex = 4;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Controls.Add(this.grdOrders, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(309, 436);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.ColumnCount = 1;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
      this.tableLayoutPanel3.Controls.Add(this.grdTrades, 0, 1);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 2;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(305, 436);
      this.tableLayoutPanel3.TabIndex = 0;
      // 
      // TradesWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(626, 440);
      this.Controls.Add(this.splitContainer1);
      this.Location = new System.Drawing.Point(597, 125);
      this.Name = "TradesWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "TradesWindow";
      ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdTrades)).EndInit();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView grdOrders;
    private System.Windows.Forms.DataGridView grdTrades;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

  }
}