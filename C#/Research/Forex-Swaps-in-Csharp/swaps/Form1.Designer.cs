namespace swaps
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.calcswap = new System.Windows.Forms.Button();
            this.tradesize = new System.Windows.Forms.TextBox();
            this.marketrate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.longswaprate = new System.Windows.Forms.TextBox();
            this.currpair = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.shortswaprate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.piplbl = new System.Windows.Forms.Label();
            this.pipvaluetxt = new System.Windows.Forms.TextBox();
            this.shortswaptxt = new System.Windows.Forms.TextBox();
            this.longswaptxt = new System.Windows.Forms.TextBox();
            this.clear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Swap Calculator";
            this.label1.UseWaitCursor = true;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // calcswap
            // 
            this.calcswap.Location = new System.Drawing.Point(108, 388);
            this.calcswap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.calcswap.Name = "calcswap";
            this.calcswap.Size = new System.Drawing.Size(182, 28);
            this.calcswap.TabIndex = 1;
            this.calcswap.Text = "Calculate Swap";
            this.calcswap.UseVisualStyleBackColor = true;
            this.calcswap.UseWaitCursor = true;
            this.calcswap.Click += new System.EventHandler(this.calcswap_Click);
            // 
            // tradesize
            // 
            this.tradesize.Location = new System.Drawing.Point(108, 80);
            this.tradesize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tradesize.Name = "tradesize";
            this.tradesize.Size = new System.Drawing.Size(177, 22);
            this.tradesize.TabIndex = 3;
            this.tradesize.UseWaitCursor = true;
            this.tradesize.TextChanged += new System.EventHandler(this.tradesize_TextChanged);
            // 
            // marketrate
            // 
            this.marketrate.Location = new System.Drawing.Point(108, 108);
            this.marketrate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.marketrate.Name = "marketrate";
            this.marketrate.Size = new System.Drawing.Size(177, 22);
            this.marketrate.TabIndex = 4;
            this.marketrate.UseWaitCursor = true;
            this.marketrate.TextChanged += new System.EventHandler(this.marketrate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 5;
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 6;
            this.label3.UseWaitCursor = true;
            // 
            // longswaprate
            // 
            this.longswaprate.Location = new System.Drawing.Point(108, 140);
            this.longswaprate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.longswaprate.Name = "longswaprate";
            this.longswaprate.Size = new System.Drawing.Size(177, 22);
            this.longswaprate.TabIndex = 7;
            this.longswaprate.UseWaitCursor = true;
            this.longswaprate.TextChanged += new System.EventHandler(this.longswaprate_TextChanged);
            // 
            // currpair
            // 
            this.currpair.Items.AddRange(new object[] {
            "AUDCAD\t0.00001",
            "AUDCHF\t0.00001",
            "AUDJPY\t0.001",
            "AUDNZD\t0.00001",
            "AUDSGD\t0.00001",
            "AUDUSD\t0.00001",
            "CADCHF\t0.00001",
            "CADJPY\t0.00001",
            "CADSGD\t0.00001",
            "CHFJPY\t0.001",
            "CHFSGD\t0.00001",
            "EURAUD\t0.00001",
            "EURCAD\t0.00001",
            "EURCHF\t0.00001",
            "EURDKK\t0.00001",
            "EURGBP\t0.00001",
            "EURHKD\t0.00001",
            "EURJPY\t0.001",
            "EURMXN\t0.00001",
            "EURNOK\t0.00001",
            "EURNZD\t0.00001",
            "EURPLN\t0.00001",
            "EURSEK\t0.00001",
            "EURSGD\t0.00001",
            "EURTRY\t0.00001",
            "EURUSD\t0.00001",
            "GBPAUD\t0.00001",
            "GBPCAD\t0.00001",
            "GBPCHF\t0.00001",
            "GBPJPY\t0.001",
            "GBPNOK\t0.00001",
            "GBPNZD\t0.00001",
            "GBPSEK\t0.00001",
            "GBPSGD\t0.00001",
            "GBPUSD\t0.00001",
            "HKDJPY\t0.001",
            "MXNJPY\t0.001",
            "NOKJPY\t0.001",
            "NOKSEK\t0.00001",
            "NZDCAD\t0.00001",
            "NZDCHF\t0.00001",
            "NZDJPY\t0.001",
            "NZDSGD\t0.00001",
            "NZDUSD\t0.00001",
            "SEKJPY\t0.001",
            "SGDJPY\t0.001",
            "USDCAD\t0.00001",
            "USDCHF\t0.00001",
            "USDCNH\t0.00001",
            "USDDKK\t0.00001",
            "USDHKD\t0.001",
            "USDJPY\t0.001",
            "USDMXN\t0.00001",
            "USDNOK\t0.00001",
            "USDPLN\t0.00001",
            "USDRUB\t0.0001",
            "USDSEK\t0.00001",
            "USDSGD\t0.00001",
            "USDTRY\t0.00001",
            "USDZAR\t0.00001",
            "XAGUSD\t0.001",
            "XAUUSD\t0.01"});
            this.currpair.Location = new System.Drawing.Point(108, 49);
            this.currpair.Name = "currpair";
            this.currpair.Size = new System.Drawing.Size(177, 24);
            this.currpair.TabIndex = 21;
            this.currpair.UseWaitCursor = true;
            this.currpair.SelectedIndexChanged += new System.EventHandler(this.currpair_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Trade Size";
            this.label5.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Market Rate";
            this.label6.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Long Swap Rate";
            this.label7.UseWaitCursor = true;
            // 
            // shortswaprate
            // 
            this.shortswaprate.Location = new System.Drawing.Point(108, 174);
            this.shortswaprate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.shortswaprate.Name = "shortswaprate";
            this.shortswaprate.Size = new System.Drawing.Size(177, 22);
            this.shortswaprate.TabIndex = 14;
            this.shortswaprate.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Short Swap Rate";
            this.label8.UseWaitCursor = true;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Select Pair";
            this.label9.UseWaitCursor = true;
            // 
            // piplbl
            // 
            this.piplbl.AutoSize = true;
            this.piplbl.Location = new System.Drawing.Point(108, 227);
            this.piplbl.Name = "piplbl";
            this.piplbl.Size = new System.Drawing.Size(0, 16);
            this.piplbl.TabIndex = 17;
            this.piplbl.UseWaitCursor = true;
            this.piplbl.Click += new System.EventHandler(this.piplbl_Click);
            // 
            // pipvaluetxt
            // 
            this.pipvaluetxt.Location = new System.Drawing.Point(108, 256);
            this.pipvaluetxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pipvaluetxt.Name = "pipvaluetxt";
            this.pipvaluetxt.Size = new System.Drawing.Size(177, 22);
            this.pipvaluetxt.TabIndex = 18;
            this.pipvaluetxt.UseWaitCursor = true;
            this.pipvaluetxt.TextChanged += new System.EventHandler(this.pipvaluetxt_TextChanged);
            // 
            // shortswaptxt
            // 
            this.shortswaptxt.Location = new System.Drawing.Point(108, 342);
            this.shortswaptxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.shortswaptxt.Name = "shortswaptxt";
            this.shortswaptxt.Size = new System.Drawing.Size(177, 22);
            this.shortswaptxt.TabIndex = 19;
            this.shortswaptxt.UseWaitCursor = true;
            this.shortswaptxt.TextChanged += new System.EventHandler(this.shortswaptxt_TextChanged);
            // 
            // longswaptxt
            // 
            this.longswaptxt.Location = new System.Drawing.Point(108, 295);
            this.longswaptxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.longswaptxt.Name = "longswaptxt";
            this.longswaptxt.Size = new System.Drawing.Size(177, 22);
            this.longswaptxt.TabIndex = 20;
            this.longswaptxt.UseWaitCursor = true;
            this.longswaptxt.TextChanged += new System.EventHandler(this.longswaptxt_TextChanged);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(108, 444);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(182, 29);
            this.clear.TabIndex = 22;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.UseWaitCursor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Long Swap Rate";
            this.label4.UseWaitCursor = true;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 348);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Short Swap Rate";
            this.label10.UseWaitCursor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "PipValue";
            this.label11.UseWaitCursor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(399, 575);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.longswaptxt);
            this.Controls.Add(this.shortswaptxt);
            this.Controls.Add(this.pipvaluetxt);
            this.Controls.Add(this.piplbl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.shortswaprate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.currpair);
            this.Controls.Add(this.longswaprate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.marketrate);
            this.Controls.Add(this.tradesize);
            this.Controls.Add(this.calcswap);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Swap Calculator";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calcswap;
        private System.Windows.Forms.TextBox tradesize;
        private System.Windows.Forms.TextBox marketrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox longswaprate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox shortswaprate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox currpair;
        private System.Windows.Forms.Label piplbl;
        private System.Windows.Forms.TextBox pipvaluetxt;
        private System.Windows.Forms.TextBox shortswaptxt;
        private System.Windows.Forms.TextBox longswaptxt;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

