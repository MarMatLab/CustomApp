using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FileStorage
{
    public partial class Login : Form
    {
        MacAddresDBHandling dBHandling = null;

        public static string SetValueForText1 = "";
        public static string conString = "server = " + Properties.Settings.Default.host + ";database=FileStorage; uid = " + Properties.Settings.Default.uname + "; pwd= " + Properties.Settings.Default.pwd;
        public static SqlConnection sqlCon = new SqlConnection(conString);

        public Login()
        {
            InitializeComponent();
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            Form frm1 = new NewUser(dBHandling);
            frm1.ShowDialog();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = userTextBox.Text.ToString();
            string pwd = passwordTextBox.Text.ToString();
            sqlCon.Open();
            SqlCommand cmd1 = new SqlCommand(@"SELECT username FROM Users WHERE username = '" + username + "'", sqlCon);
            string unamechk = Convert.ToString(cmd1.ExecuteScalar());
            sqlCon.Close();
            if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("No credentials were given!");
            }
            else if (String.IsNullOrEmpty(username))
            {
                MessageBox.Show("No username was given!");
            }
            else if (String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("No password was given!");
            }
            else if (unamechk != username)
            {
                label4.Visible = true;
                label4.Text = "Wrong user name!";
            }
            else if (unamechk == username)
            {
                sqlCon.Open();
                SqlCommand cmd2 = new SqlCommand(@"SELECT password FROM Users WHERE username = '" + username + "'", sqlCon);
                string chkpwd = Convert.ToString(cmd2.ExecuteScalar());
                sqlCon.Close();
                if (chkpwd != pwd)
                {
                    label4.Visible = true;
                    label4.Text = "Wrong password!";
                }
                else
                {
                    SetValueForText1 = userTextBox.Text.ToString();
                    FileStorage frm2 = new FileStorage(dBHandling);
                    frm2.Show();
                }
            }
        }
    }
    public class MacAddresDBHandling
    {

    }
}