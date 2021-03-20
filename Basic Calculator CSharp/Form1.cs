using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Calculator_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDisplay.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
        }

        private void btnNum_Click(object btn, EventArgs e)
        {
            txtDisplay.Text += (btn as Button).Text;
        }

        private void btnplus_Click(object btn, EventArgs e)
        {
            txtDisplay.Text += (btn as Button).Text;

        }

        private void btnMinus_Click(object btn, EventArgs e)
        {
            txtDisplay.Text += (btn as Button).Text;

        }

        private void btnMul_Click(object btn, EventArgs e)
        {
            txtDisplay.Text += (btn as Button).Text;

        }

        private void btnDiv_Click(object btn, EventArgs e)
        {
            txtDisplay.Text += (btn as Button).Text;

        }
    }
}
