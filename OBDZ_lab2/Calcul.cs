using System;
using System.Windows.Forms;

namespace OBDZ_lab1
{
    public partial class Calcul : Form
    {
        public Calcul()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Calcul_Load(object sender, EventArgs e)
        {
            cmbxAct.Items.Add("+");
            cmbxAct.Items.Add("-");
            cmbxAct.Items.Add("*");
            cmbxAct.Items.Add("/");

            cmbxAct.Text = "+";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            double ch1, ch2;
            if (txtCh1.Text == "") { ch1 = 0; } else { double.TryParse(txtCh1.Text, out ch1); }
            if (txtCh2.Text == "") { ch2 = 0; } else { double.TryParse(txtCh2.Text, out ch2); }

            switch (cmbxAct.SelectedIndex)
            {
                case 0: txtRez.Text = (ch1 + ch2).ToString(); break;
                case 1: txtRez.Text = (ch1 - ch2).ToString(); break;
                case 2: txtRez.Text = (ch1 * ch2).ToString(); break;
                case 3: txtRez.Text = (ch1 / ch2).ToString(); break;
                default: txtRez.Text = double.NaN.ToString(); break;
            }
        }
    }
}
