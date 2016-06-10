namespace VigiothCapital.QuantTrader.Views.WinForms
{
    partial class LeanWinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeanWinForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.FormToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormToolStripStatusStringLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatisticsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitPanel = new System.Windows.Forms.SplitContainer();
            this.groupLog = new System.Windows.Forms.GroupBox();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).BeginInit();
            this.splitPanel.Panel2.SuspendLayout();
            this.splitPanel.SuspendLayout();
            this.groupLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormToolStripStatusLabel,
            this.FormToolStripStatusStringLabel,
            this.StatisticsToolStripStatusLabel,
            this.FormToolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 8, 0);
            this.statusStrip1.Size = new System.Drawing.Size(787, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FormToolStripStatusLabel
            // 
            this.FormToolStripStatusLabel.Name = "FormToolStripStatusLabel";
            this.FormToolStripStatusLabel.Size = new System.Drawing.Size(105, 17);
            this.FormToolStripStatusLabel.Text = "Loading Complete";
            // 
            // FormToolStripStatusStringLabel
            // 
            this.FormToolStripStatusStringLabel.Name = "FormToolStripStatusStringLabel";
            this.FormToolStripStatusStringLabel.Size = new System.Drawing.Size(480, 17);
            this.FormToolStripStatusStringLabel.Spring = true;
            // 
            // StatisticsToolStripStatusLabel
            // 
            this.StatisticsToolStripStatusLabel.Name = "StatisticsToolStripStatusLabel";
            this.StatisticsToolStripStatusLabel.Size = new System.Drawing.Size(136, 17);
            this.StatisticsToolStripStatusLabel.Text = "Statistics: CPU:    Ram:    ";
            // 
            // FormToolStripProgressBar
            // 
            this.FormToolStripProgressBar.Name = "FormToolStripProgressBar";
            this.FormToolStripProgressBar.Size = new System.Drawing.Size(55, 16);
            // 
            // splitPanel
            // 
            this.splitPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanel.Location = new System.Drawing.Point(0, 0);
            this.splitPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitPanel.Name = "splitPanel";
            this.splitPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitPanel.Panel2
            // 
            this.splitPanel.Panel2.Controls.Add(this.groupLog);
            this.splitPanel.Panel2MinSize = 100;
            this.splitPanel.Size = new System.Drawing.Size(787, 467);
            this.splitPanel.SplitterDistance = 362;
            this.splitPanel.SplitterWidth = 5;
            this.splitPanel.TabIndex = 2;
            // 
            // groupLog
            // 
            this.groupLog.Controls.Add(this.LogTextBox);
            this.groupLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLog.Location = new System.Drawing.Point(0, 0);
            this.groupLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupLog.Name = "groupLog";
            this.groupLog.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupLog.Size = new System.Drawing.Size(783, 96);
            this.groupLog.TabIndex = 0;
            this.groupLog.TabStop = false;
            this.groupLog.Text = "Log";
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(2, 15);
            this.LogTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.Size = new System.Drawing.Size(779, 79);
            this.LogTextBox.TabIndex = 0;
            this.LogTextBox.Text = "";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // LeanWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 489);
            this.Controls.Add(this.splitPanel);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(566, 434);
            this.Name = "LeanWinForm";
            this.Text = "VigiothCapital.QuantTrader.Algorithmic Trading Engine: v0.00";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LeanWinForm_FormClosed);
            this.Load += new System.EventHandler(this.LeanWinForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).EndInit();
            this.splitPanel.ResumeLayout(false);
            this.groupLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitPanel;
        private System.Windows.Forms.GroupBox groupLog;
        private System.Windows.Forms.ToolStripStatusLabel FormToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel FormToolStripStatusStringLabel;
        private System.Windows.Forms.ToolStripStatusLabel StatisticsToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar FormToolStripProgressBar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.RichTextBox LogTextBox;
    }
}