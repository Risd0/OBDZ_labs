using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBDZ_lab1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void калькулятор1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calcul calcul = new Calcul();
            calcul.Show();
        }

        private void калькулятор2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var calc = new Calculator();
            calc.Show();
        }
    }
}
