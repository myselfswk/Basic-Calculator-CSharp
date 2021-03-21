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
            previousOperation = operation.None;
            txtDisplay.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                double d;
                if (!double.TryParse(txtDisplay.Text[txtDisplay.Text.Length - 1].ToString(), out d))
                {
                    previousOperation = operation.None;
                }
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
        }

        private void btnNum_Click(object btn, EventArgs e)
        {
            txtDisplay.Text += (btn as Button).Text;
        }

        private void performCalculation(operation previousOperation)
        {
            List<double> listNums = new List<double>();
            switch (previousOperation)
            {
                case operation.Plus:
                    if (currentOperation == operation.Minus)
                    {
                        currentOperation = operation.Plus;
                        return;
                    }
                    listNums = txtDisplay.Text.Split('+').Select(double.Parse).ToList();
                    txtDisplay.Text = (listNums[0] + listNums[1]).ToString();
                    break;
                case operation.Minus:
                    //listNums = txtDisplay.Text.Split('-').Select(double.Parse).ToList();
                    //txtDisplay.Text = (listNums[0] - listNums[1]).ToString();
                    int idx = txtDisplay.Text.LastIndexOf('-'); // To handle ex: -9-2
                    if (idx > 0)
                    {
                        var op1 = Convert.ToDouble(txtDisplay.Text.Substring(0, idx));
                        var op2 = Convert.ToDouble(txtDisplay.Text.Substring(idx + 1));
                        txtDisplay.Text = (op1 - op2).ToString();
                    }
                    break;
                case operation.Mul:
                    listNums = txtDisplay.Text.Split('x').Select(double.Parse).ToList();
                    txtDisplay.Text = (listNums[0] * listNums[1]).ToString();
                    break;
                case operation.Div:
                    try
                    {
                        listNums = txtDisplay.Text.Split('/').Select(double.Parse).ToList();
                        txtDisplay.Text = (listNums[0] / listNums[1]).ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        txtDisplay.Text = "EEEEEEEE";
                        throw;
                    }
                    break;
                case operation.None:
                    break;
                default:
                    break;
            }
        }

        private void btnplus_Click(object btn, EventArgs e)
        {
            if (previousOperation != operation.None)
            {
                performCalculation(previousOperation);
            }
            previousOperation = operation.Plus;
            txtDisplay.Text += (btn as Button).Text;

        }

        private void btnMinus_Click(object btn, EventArgs e)
        {
            if (previousOperation != operation.None)
            {
                performCalculation(previousOperation);
            }
            previousOperation = operation.Minus;
            txtDisplay.Text += (btn as Button).Text;

        }

        private void btnMul_Click(object btn, EventArgs e)
        {
            if (previousOperation != operation.None)
            {
                performCalculation(previousOperation);
            }
            previousOperation = operation.Mul;
            txtDisplay.Text += (btn as Button).Text;

        }

        private void btnDiv_Click(object btn, EventArgs e)
        {
            if (previousOperation == operation.None)
            {
                performCalculation(previousOperation);
            }
            previousOperation = operation.Div;
            txtDisplay.Text += (btn as Button).Text;

        }

        enum operation
        {
            Plus,
            Minus,
            Mul,
            Div,
            None
        }

        static operation previousOperation = operation.None;
        static operation currentOperation = operation.None;

        private void btnequal_Click(object sender, EventArgs e)
        {
            if (previousOperation == operation.None)
            {
                return;
            }
            else
            {
                performCalculation(previousOperation);
            }
        }
    }
}
