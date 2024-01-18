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
    public partial class AddFile : Form
    {
        SqlConnection sqlCon = Login.sqlCon;

        public AddFile(object dbHandling)
        {
            InitializeComponent();
            comboBoxFill();
            label4.Text = FileStorage.SetValueForText2;
            label5.Text = FileStorage.SetValueForText3;
        }

        private void comboBoxFill()
        {
            sqlCon.Open();
            SqlCommand comb = new SqlCommand(@"SELECT typeName FROM FileTypes", sqlCon);
            SqlDataReader readtypes = comb.ExecuteReader();
            while (readtypes.Read())
            {
                string fill = readtypes.GetString(0);
                typeComboBox.Items.Add(fill);
            }
            sqlCon.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            byte[] file;
            string name = nameTextBox.Text.ToString();
            string location = fileTextBox.Text.ToString();

            sqlCon.Open();
            SqlCommand usid = new SqlCommand(@"SELECT idUser FROM Users WHERE username = '" + label5.Text.ToString() + "'", sqlCon);
            int idus = Convert.ToInt32(usid.ExecuteScalar());
            SqlCommand folid = new SqlCommand(@"SELECT idFolders FROM Folders WHERE folderName = '" + label4.Text.ToString() + "' AND idUser = " + idus, sqlCon);
            int idfol = Convert.ToInt32(folid.ExecuteScalar());
            if (String.IsNullOrEmpty(location))
            {
                MessageBox.Show("All data must be given!");
            }
            else
            {
                SqlCommand idt = new SqlCommand("SELECT idType FROM FileTypes WHERE typeName = '" + typeComboBox.Text.ToString() + "'", sqlCon);
                int idtype = Convert.ToInt32(idt.ExecuteScalar());
                SqlCommand chkfilname = new SqlCommand(@"SELECT fileName FROM Files WHERE idFolder = " + idfol, sqlCon);
                string filchk = (string)chkfilname.ExecuteScalar();
                if (filchk == name)
                {
                    MessageBox.Show("Can't add a file with this name to this folder!");
                    sqlCon.Close();
                }
                else if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(location))
                {
                    MessageBox.Show("All data must be given!");
                    sqlCon.Close();
                }
                else if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(location))
                {
                    MessageBox.Show("All data must be given!");
                    sqlCon.Close();
                }
                else
                {
                    using (FileStream fs = new FileStream(@location, FileMode.Open, FileAccess.Read))
                    {
                        file = new byte[fs.Length];
                        fs.Read(file, 0, (int)fs.Length);
                    }
                    using (SqlCommand add = new SqlCommand(@"INSERT INTO Files (idFile, fileName, idFolder, Data, idType) VALUES (NEWID(), '" + name + "', " + idfol + ", @binarydata, " + idtype + ")", sqlCon))
                    {
                        add.Parameters.Add(new SqlParameter("@binarydata", file));
                        add.ExecuteNonQuery();
                    }
                    MessageBox.Show("File added successfuly!");
                    sqlCon.Close();
                    this.Close();
                }
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = ofd.FileName;
            }
        }
    }
}
