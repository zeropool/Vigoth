namespace CodeGenerator
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
			this.XmlFile = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Generate = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.OutputDirectory = new System.Windows.Forms.TextBox();
			this.CloseButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// XmlFile
			// 
			this.XmlFile.Location = new System.Drawing.Point(113, 36);
			this.XmlFile.Name = "XmlFile";
			this.XmlFile.Size = new System.Drawing.Size(223, 20);
			this.XmlFile.TabIndex = 0;
			this.XmlFile.Text = "C:\\quickfix_1_12_4\\spec\\FIX44.xml";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "XML File";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Generate
			// 
			this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Generate.Location = new System.Drawing.Point(248, 105);
			this.Generate.Name = "Generate";
			this.Generate.Size = new System.Drawing.Size(88, 59);
			this.Generate.TabIndex = 2;
			this.Generate.Text = "&Generate";
			this.Generate.UseVisualStyleBackColor = true;
			this.Generate.Click += new System.EventHandler(this.Generate_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Output Directory";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// OutputDirectory
			// 
			this.OutputDirectory.Location = new System.Drawing.Point(113, 62);
			this.OutputDirectory.Name = "OutputDirectory";
			this.OutputDirectory.Size = new System.Drawing.Size(223, 20);
			this.OutputDirectory.TabIndex = 3;
			this.OutputDirectory.Text = "C:\\Dev\\FIX4NET\\src\\FIX\\FIX_4_4";
			// 
			// CloseButton
			// 
			this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CloseButton.Location = new System.Drawing.Point(154, 105);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(88, 59);
			this.CloseButton.TabIndex = 5;
			this.CloseButton.Text = "&Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "FIX Version";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(113, 10);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 8;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size(348, 176);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.OutputDirectory);
			this.Controls.Add(this.Generate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.XmlFile);
			this.Name = "Form1";
			this.Text = "FIX4NET Code Generator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox XmlFile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Generate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox OutputDirectory;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}

