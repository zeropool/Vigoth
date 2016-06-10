using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeGenerator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Generate_Click(object sender, EventArgs e)
		{
			try
			{
				GenFix44 gen = new GenFix44();
				gen.OutputDir = OutputDirectory.Text;
				gen.Initialize(XmlFile.Text);
				gen.Run();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error generating code:\n" + ex.Message + "\n" + ex.StackTrace, "Error", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}