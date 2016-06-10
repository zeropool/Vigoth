namespace FIXTradingExample
{
  partial class LoginWindow
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.txtActions = new System.Windows.Forms.TextBox();
      this.btnLogin = new System.Windows.Forms.Button();
      this.btnLogout = new System.Windows.Forms.Button();
      this.btnRunExample = new System.Windows.Forms.Button();
      this.chkRedirect = new System.Windows.Forms.CheckBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.txtActions, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.btnLogin, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.btnLogout, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.btnRunExample, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.chkRedirect, 0, 3);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 211);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // txtActions
      // 
      this.txtActions.AcceptsReturn = true;
      this.txtActions.AcceptsTab = true;
      this.txtActions.BackColor = System.Drawing.SystemColors.Info;
      this.txtActions.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtActions.Location = new System.Drawing.Point(3, 103);
      this.txtActions.Multiline = true;
      this.txtActions.Name = "txtActions";
      this.txtActions.ReadOnly = true;
      this.txtActions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtActions.Size = new System.Drawing.Size(411, 105);
      this.txtActions.TabIndex = 6;
      this.txtActions.Text = "[Redirected Console]\r\n";
      // 
      // btnLogin
      // 
      this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnLogin.Location = new System.Drawing.Point(32, 0);
      this.btnLogin.Margin = new System.Windows.Forms.Padding(32, 0, 32, 0);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(353, 25);
      this.btnLogin.TabIndex = 7;
      this.btnLogin.Text = "Login";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // btnLogout
      // 
      this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnLogout.Enabled = false;
      this.btnLogout.Location = new System.Drawing.Point(32, 50);
      this.btnLogout.Margin = new System.Windows.Forms.Padding(32, 0, 32, 0);
      this.btnLogout.Name = "btnLogout";
      this.btnLogout.Size = new System.Drawing.Size(353, 25);
      this.btnLogout.TabIndex = 8;
      this.btnLogout.Text = "Logout";
      this.btnLogout.UseVisualStyleBackColor = true;
      this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
      // 
      // btnRunExample
      // 
      this.btnRunExample.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnRunExample.Enabled = false;
      this.btnRunExample.Location = new System.Drawing.Point(32, 25);
      this.btnRunExample.Margin = new System.Windows.Forms.Padding(32, 0, 32, 0);
      this.btnRunExample.Name = "btnRunExample";
      this.btnRunExample.Size = new System.Drawing.Size(353, 25);
      this.btnRunExample.TabIndex = 9;
      this.btnRunExample.Text = "Run Example";
      this.btnRunExample.UseVisualStyleBackColor = true;
      this.btnRunExample.Click += new System.EventHandler(this.btnRunExample_Click);
      // 
      // chkRedirect
      // 
      this.chkRedirect.AutoSize = true;
      this.chkRedirect.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chkRedirect.Location = new System.Drawing.Point(3, 78);
      this.chkRedirect.Name = "chkRedirect";
      this.chkRedirect.Size = new System.Drawing.Size(411, 19);
      this.chkRedirect.TabIndex = 10;
      this.chkRedirect.Text = "Redirect Console";
      this.chkRedirect.UseVisualStyleBackColor = true;
      this.chkRedirect.CheckedChanged += new System.EventHandler(this.chkRedirect_CheckedChanged);
      // 
      // LoginWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(417, 211);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "LoginWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FIXTradingExample";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TextBox txtActions;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnLogout;
    private System.Windows.Forms.Button btnRunExample;
    private System.Windows.Forms.CheckBox chkRedirect;
  }
}

