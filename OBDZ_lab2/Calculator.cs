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
            try
            {
                double num = double.NaN;    // set num as NaN
                num = double.Parse(new DataTable().Compute(resultText.Text.Replace(',', '.'), null).ToString());    // calculate an arithmetic expression in the current textBox; need to replace ',' into '.' to avoid Error
                resultText.Text = Math.Round(num * 0.01, 10, MidpointRounding.ToEven) + "";
            }
            catch (Exception)
            {
                resultText.Text = "Error";
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            resultText.Text = default;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                var result = double.NaN;    // set num as NaN
                result = double.Parse(new DataTable().Compute(resultText.Text.Replace(',', '.'), null).ToString());    // calculate an arithmetic expression in the current textBox; need to replace ',' into '.' to avoid Error
                resultText.Text = Math.Round(result, 10, MidpointRounding.ToEven) + ""; //rounding number
            }
            catch (Exception)
            {
                resultText.Text = "Error";
            }
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
            resultText.Text += ".";
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
