using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OBDZ_lab1
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resultText.Clear();
            Dock = DockStyle.Fill;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            resultText.Text = resultText.Text.Remove(resultText.Text.Length - 1, 1);
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            var result = Convert.ToDouble(new DataTable().Compute(resultText.Text, null));    // calculate an arithmetic expression in the current textBox
            resultText.Text = (result * 0.01).ToString();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            resultText.Text = default;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            var result = new DataTable().Compute(resultText.Text, null);    // calculate an arithmetic expression in the current textBox
            resultText.Text = result.ToString();
            //if (!decimal.TryParse(resultText.Text, out _)) { resultText.Text = double.NaN.ToString(); }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            resultText.Text += "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            resultText.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            resultText.Text += "2";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            resultText.Text += ",";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            resultText.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            resultText.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            resultText.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            resultText.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            resultText.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            resultText.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            resultText.Text += "9";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            resultText.Text += "+";
        }

        private void btnSubstract_Click(object sender, EventArgs e)
        {
            resultText.Text += "-";
        }

        private void btnMultipl_Click(object sender, EventArgs e)
        {
            resultText.Text += "*";
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            resultText.Text += "/";
        }

        private void btnBrackets_Click(object sender, EventArgs e)
        {
            if (resultText.Text.Count<char>(x => x == '(') == resultText.Text.Count<char>(x => x == ')'))
            {
                resultText.Text += '(';
            }
            else { resultText.Text += ')'; }
        }
    }
}
