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

using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FIXForge.NET.FIX;
using Message=FIXForge.NET.FIX.Message;

namespace Parsing
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public class MainForm : Form
    {
        private GroupBox groupBox1;
        private Label labelSmall;
        private ProgressBar progressBar;
        private Button buttonStart;
        private Label labelMedium;
        private Label labelLarge;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxSmallMsg;
        private TextBox textBoxMediumMsg;
        private TextBox textBoxLargeMsg;
        private TextBox textBoxSmallKb;
        private TextBox textBoxMediumKb;
        private TextBox textBoxLargeKb;
        private Label label4;
        private Label label5;
        private Label label6;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        [STAThread]
        private static void Main(string[] args)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            try
            {
                Engine.Init(-1); // '-1' disables the telecommunication level.

                Application.Run(new MainForm());

                Engine.Instance.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.labelSmall = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelMedium = new System.Windows.Forms.Label();
            this.labelLarge = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSmallMsg = new System.Windows.Forms.TextBox();
            this.textBoxMediumMsg = new System.Windows.Forms.TextBox();
            this.textBoxLargeMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSmallKb = new System.Windows.Forms.TextBox();
            this.textBoxMediumKb = new System.Windows.Forms.TextBox();
            this.textBoxLargeKb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSmall
            // 
            this.labelSmall.Location = new System.Drawing.Point(8, 24);
            this.labelSmall.Name = "labelSmall";
            this.labelSmall.Size = new System.Drawing.Size(40, 16);
            this.labelSmall.TabIndex = 0;
            this.labelSmall.Text = "Small:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(8, 112);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(344, 23);
            this.progressBar.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(8, 144);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(344, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelMedium
            // 
            this.labelMedium.Location = new System.Drawing.Point(8, 48);
            this.labelMedium.Name = "labelMedium";
            this.labelMedium.Size = new System.Drawing.Size(48, 16);
            this.labelMedium.TabIndex = 0;
            this.labelMedium.Text = "Medium:";
            // 
            // labelLarge
            // 
            this.labelLarge.Location = new System.Drawing.Point(8, 72);
            this.labelLarge.Name = "labelLarge";
            this.labelLarge.Size = new System.Drawing.Size(40, 16);
            this.labelLarge.TabIndex = 0;
            this.labelLarge.Text = "Large:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxSmallMsg);
            this.groupBox1.Controls.Add(this.labelSmall);
            this.groupBox1.Controls.Add(this.labelMedium);
            this.groupBox1.Controls.Add(this.labelLarge);
            this.groupBox1.Controls.Add(this.textBoxMediumMsg);
            this.groupBox1.Controls.Add(this.textBoxLargeMsg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxSmallKb);
            this.groupBox1.Controls.Add(this.textBoxMediumKb);
            this.groupBox1.Controls.Add(this.textBoxLargeKb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Messages";
            // 
            // textBoxSmallMsg
            // 
            this.textBoxSmallMsg.Location = new System.Drawing.Point(56, 24);
            this.textBoxSmallMsg.Name = "textBoxSmallMsg";
            this.textBoxSmallMsg.ReadOnly = true;
            this.textBoxSmallMsg.Size = new System.Drawing.Size(80, 20);
            this.textBoxSmallMsg.TabIndex = 1;
            this.textBoxSmallMsg.Text = "";
            // 
            // textBoxMediumMsg
            // 
            this.textBoxMediumMsg.Location = new System.Drawing.Point(56, 48);
            this.textBoxMediumMsg.Name = "textBoxMediumMsg";
            this.textBoxMediumMsg.ReadOnly = true;
            this.textBoxMediumMsg.Size = new System.Drawing.Size(80, 20);
            this.textBoxMediumMsg.TabIndex = 1;
            this.textBoxMediumMsg.Text = "";
            // 
            // textBoxLargeMsg
            // 
            this.textBoxLargeMsg.Location = new System.Drawing.Point(56, 72);
            this.textBoxLargeMsg.Name = "textBoxLargeMsg";
            this.textBoxLargeMsg.ReadOnly = true;
            this.textBoxLargeMsg.Size = new System.Drawing.Size(80, 20);
            this.textBoxLargeMsg.TabIndex = 1;
            this.textBoxLargeMsg.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(136, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "msg/sec";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "msg/sec";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(136, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "msg/sec";
            // 
            // textBoxSmallKb
            // 
            this.textBoxSmallKb.Location = new System.Drawing.Point(216, 24);
            this.textBoxSmallKb.Name = "textBoxSmallKb";
            this.textBoxSmallKb.ReadOnly = true;
            this.textBoxSmallKb.Size = new System.Drawing.Size(80, 20);
            this.textBoxSmallKb.TabIndex = 1;
            this.textBoxSmallKb.Text = "";
            // 
            // textBoxMediumKb
            // 
            this.textBoxMediumKb.Location = new System.Drawing.Point(216, 48);
            this.textBoxMediumKb.Name = "textBoxMediumKb";
            this.textBoxMediumKb.ReadOnly = true;
            this.textBoxMediumKb.Size = new System.Drawing.Size(80, 20);
            this.textBoxMediumKb.TabIndex = 1;
            this.textBoxMediumKb.Text = "";
            // 
            // textBoxLargeKb
            // 
            this.textBoxLargeKb.Location = new System.Drawing.Point(216, 72);
            this.textBoxLargeKb.Name = "textBoxLargeKb";
            this.textBoxLargeKb.ReadOnly = true;
            this.textBoxLargeKb.Size = new System.Drawing.Size(80, 20);
            this.textBoxLargeKb.TabIndex = 1;
            this.textBoxLargeKb.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(296, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "kb/sec";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(296, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "kb/sec";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(296, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "kb/sec";
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(362, 176);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Parsing Benchmark";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private const int N_CYCLES = 10000;
        private const int n = 1000;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                progressBar.Value = 0;
                progressBar.Maximum = (N_CYCLES/n)*3;

                textBoxLargeMsg.Text = string.Empty;
                textBoxLargeKb.Text = string.Empty;
                textBoxMediumMsg.Text = string.Empty;
                textBoxMediumKb.Text = string.Empty;
                textBoxSmallMsg.Text = string.Empty;
                textBoxSmallKb.Text = string.Empty;

                double kbPerSec = 0;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["Large message file"]))
                {
                    textBoxLargeMsg.Text = Benchmark(sr, out kbPerSec);
                    textBoxLargeKb.Text = ((int) kbPerSec).ToString();
                }

                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["Medium message file"]))
                {
                    textBoxMediumMsg.Text = Benchmark(sr, out kbPerSec);
                    textBoxMediumKb.Text = ((int) kbPerSec).ToString();
                }

                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["Small message file"]))
                {
                    textBoxSmallMsg.Text = Benchmark(sr, out kbPerSec);
                    textBoxSmallKb.Text = ((int) kbPerSec).ToString();
                }
            }
            finally
            {
                buttonStart.Enabled = true;
                Cursor.Current = old;
            }
        }

        private string Benchmark(StreamReader sr, out double kbPerSec)
        {
            kbPerSec = 0;
            string rawMsg = sr.ReadLine();

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < N_CYCLES; ++i)
            {
                Message msg = new Message(rawMsg);
                if (i%n == 0)
                {
                    progressBar.Increment(1);
                    Application.DoEvents();
                }
                msg.Dispose();
            }
            stopwatch.Stop();

            double performance = 0;
            if (0 != stopwatch.ElapsedMilliseconds)
            {
                performance = Math.Floor((double)N_CYCLES * 1000 / stopwatch.ElapsedMilliseconds);
            }
            kbPerSec = (sr.BaseStream.Length*performance)/1024;
            return performance.ToString();
        }
    }
}