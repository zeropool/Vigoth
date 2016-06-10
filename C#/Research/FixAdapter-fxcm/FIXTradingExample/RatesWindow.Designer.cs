namespace FIXTradingExample
{
  partial class RatesWindow
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
      this.grdRates = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.grdRates)).BeginInit();
      this.SuspendLayout();
      // 
      // grdRates
      // 
      this.grdRates.AllowUserToAddRows = false;
      this.grdRates.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.grdRates.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.grdRates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
      this.grdRates.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.grdRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.grdRates.DefaultCellStyle = dataGridViewCellStyle2;
      this.grdRates.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdRates.Location = new System.Drawing.Point(0, 0);
      this.grdRates.Name = "grdRates";
      this.grdRates.RowHeadersVisible = false;
      this.grdRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.grdRates.Size = new System.Drawing.Size(588, 617);
      this.grdRates.TabIndex = 0;
      this.grdRates.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdRates_DataError);
      // 
      // RatesWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(588, 617);
      this.Controls.Add(this.grdRates);
      this.Name = "RatesWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Rates";
      ((System.ComponentModel.ISupportInitialize)(this.grdRates)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView grdRates;
  }
}