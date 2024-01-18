using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FileStorage
{
    public partial class NewUser : System.Windows.Forms.Form
    {
        private object dbHandling;
        SqlConnection sqlCon = Login.sqlCon;
        public NewUser(MacAddresDBHandling dBHandling)
        {
            InitializeComponent();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text.ToString();
            string mail = mailTextBox.Text.ToString();

            SqlCommand cmd1 = new SqlCommand(@"SELECT username FROM Users WHERE username = '" + username + "'", sqlCon);
            string chkuname = Convert.ToString(cmd1.ExecuteScalar());
            SqlCommand cmd2 = new SqlCommand(@"SELECT email FROM Users WHERE email = '" + mail + "'", sqlCon);
            string chkmail = Convert.ToString(cmd2.ExecuteScalar());
            sqlCon.Close();
            if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(password) && String.IsNullOrEmpty(mail))
            {
                MessageBox.Show("No data was given!");
            }
            else if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(mail))
            {
                MessageBox.Show("All data must be given!");
            }
            else if (username == chkuname)
            {
                MessageBox.Show("Username already exists!");
            }
            else if (mail == chkmail)
            {
                MessageBox.Show("This e-mail is already used!");
            }
            else
            {
                sqlCon.Open();
                SqlCommand add = new SqlCommand(@"INSERT INTO Users (username, password, email) VALUES ('" + username + "', '" + password + "', '" + mail + "')", sqlCon);
                add.ExecuteNonQuery();
                MessageBox.Show("User added successfuly!");
                sqlCon.Close();
                this.Close();
            }
        }
    }
}
