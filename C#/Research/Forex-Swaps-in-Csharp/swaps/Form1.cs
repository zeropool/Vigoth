using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swaps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void calcswap_Click(object sender, EventArgs e)
        {
          double tdz = Convert.ToDouble(tradesize.Text);

          double mrktr = Convert.ToDouble(marketrate.Text);

          double Longswaprate1 = Convert.ToDouble(longswaprate.Text);

          double Shortswaprate1 = Convert.ToDouble(shortswaprate.Text);
          
          string[] str = currpair.Text.Split();
            
          //int firstValue = Convert.ToInt32(str[0]); //int
       double secondValue = Convert.ToDouble(str[1]); //double
      
       double pipvalue = ((secondValue / mrktr) * tdz);

       double longswap =  Longswaprate1 * pipvalue;

       double shortswap = Shortswaprate1 * pipvalue;

       pipvaluetxt.Text = pipvalue.ToString();
       longswaptxt.Text = longswap.ToString();
       shortswaptxt.Text = shortswap.ToString();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {
            pipvaluetxt.Text = "";
            longswaptxt.Text = "";
            shortswaptxt.Text = "";
            tradesize.Text = "";
            marketrate.Text = "";
            longswaprate.Text = "";
            shortswaprate.Text = "";
        }


        private void longswaptxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void shortswaptxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pipvaluetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void piplbl_Click(object sender, EventArgs e)
        {

        }

        private void currpair_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void longswaprate_TextChanged(object sender, EventArgs e)
        {

        }

        private void marketrate_TextChanged(object sender, EventArgs e)
        {

        }

        private void tradesize_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
