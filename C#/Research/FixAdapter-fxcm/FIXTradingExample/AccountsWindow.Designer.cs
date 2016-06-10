namespace FIXTradingExample
{
  partial class AccountsWindow
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
      this.grdAccounts = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.grdAccounts)).BeginInit();
      this.SuspendLayout();
      // 
      // grdAccounts
      // 
      this.grdAccounts.AllowUserToAddRows = false;
      this.grdAccounts.AllowUserToDeleteRows = false;
      this.grdAccounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.grdAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdAccounts.Location = new System.Drawing.Point(0, 0);
      this.grdAccounts.Name = "grdAccounts";
      this.grdAccounts.ReadOnly = true;
      this.grdAccounts.RowHeadersVisible = false;
      this.grdAccounts.Size = new System.Drawing.Size(327, 97);
      this.grdAccounts.TabIndex = 0;
      // 
      // AccountsWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(327, 97);
      this.Controls.Add(this.grdAccounts);
      this.Location = new System.Drawing.Point(597, 0);
      this.Name = "AccountsWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "AccountsWindow";
      ((System.ComponentModel.ISupportInitialize)(this.grdAccounts)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView grdAccounts;
  }
}