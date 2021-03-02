using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OBDZ_lab1
{
    public partial class LogIn : Form
    {
        public string[,] matrix;
        DataTable dt;

        public LogIn()
        {
            InitializeComponent();

            string IPSQLserver = "193.93.216.145"; // such IP for PC and home laptops
            string LogSQLserver = "sqlkn19_2_kn";  //my login on SQL server
            string PasSQLserver = "kn19_kn";   // my password on SQL server

            H.ConStr = $"server = {IPSQLserver}; characterset = cp1251; user = {LogSQLserver}; database = {LogSQLserver}; " +
                $"password = {PasSQLserver}";

            dt = H.myfundDt("Select * from UserName");  // read UserName table in dt
            int count = dt.Rows.Count;

            matrix = new String[count, 4];
            for (int i = 0; i < count; i++) // write dt into matrix
            {
                matrix[i, 0] = dt.Rows[i].Field<int>("id").ToString();
                matrix[i, 1] = dt.Rows[i].Field<string>("userName");
                matrix[i, 2] = dt.Rows[i].Field<int>("type").ToString();
                matrix[i, 3] = dt.Rows[i].Field<string>("password");
                cbxUser.Items.Add(matrix[i, 1]);    //form a list of users in cbxUser comboBox 
            }
            cbxUser.Text = matrix[0, 1];    // init. the first user
            txtPassword.UseSystemPasswordChar = true;
            cbxUser.Focus();    // set input focus to this control
        }
         
        private void Authorization()
        {
            bool flUser = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (string.Equals(cbxUser.Text.ToUpper(), matrix[i, 1].ToUpper()))
                {
                    flUser = true;
                    if (string.Equals(txtPassword.Text, matrix[i, 3]))
                    {
                        H.nameUser = matrix[i, 1];
                        H.typeUser = matrix[i, 2];
                        cbxUser.Text = "";
                        txtPassword.Text = "";
                        this.Hide();    // close the project
                        MainForm mainForm = new MainForm();
                        mainForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Введіть правильний пароль!", "Помилка авторизації", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        txtPassword.Text = "";
                        txtPassword.Focus();
                    }
                }
            }
            if (!flUser)
            {
                MessageBox.Show($"Користувач {cbxUser.Text} не зареєстрований в системі\nЗверніться до адміна...",
                    "Помилка авторизації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxUser.Text = "";
                cbxUser.Focus();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        static class H
        {
            public static string ConStr { get; set; }
            public static string typeUser { get; set; }
            public static string nameUser { get; set; }
            public static BindingSource bs1 { get; set; }

            public static DataTable myfundDt(string commandStr)
            {
                var dt = new DataTable();
                using (MySqlConnection con = new MySqlConnection(H.ConStr))
                {
                    MySqlCommand cmd = new MySqlCommand(commandStr, con);
                    try
                    {
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dt.Load(dr);
                            }
                        }
                        con.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Неможливо з'єднатися з SQL-сервером!\nПеревірте інтернет-з'єднання...",
                            "Помилка з'єднання", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return dt;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Authorization();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
