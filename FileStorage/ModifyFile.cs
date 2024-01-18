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
using System.Diagnostics.Eventing.Reader;

namespace FileStorage
{
    public partial class ModifyFile : Form
    {
        SqlConnection sqlCon = Login.sqlCon;
        public ModifyFile(object dbHandling)
        {
            InitializeComponent();
            comboBoxFill();
            label4.Text = FileStorage.SetValueForText2;
            label5.Text = FileStorage.SetValueForText3;
            label6.Text = FileStorage.SetValueForText4;

            sqlCon.Open();
            SqlCommand usid = new SqlCommand(@"SELECT idUser FROM Users WHERE username = '" + label5.Text.ToString() + "'", sqlCon);
            int idus = Convert.ToInt32(usid.ExecuteScalar());
            SqlCommand folid = new SqlCommand(@"SELECT idFolders FROM Folders WHERE folderName = '" + label4.Text.ToString() + "' AND idUser = " + idus, sqlCon);
            int idfol = Convert.ToInt32(folid.ExecuteScalar());
            SqlCommand idfile = new SqlCommand(@"SELECT id FROM Files WHERE idFolder= " + idfol + " AND fileName = '" + label6.Text + "'", sqlCon);
            int fileid = Convert.ToInt32(idfile.ExecuteScalar());
            SqlCommand chktype = new SqlCommand(@"SELECT idType FROM Files WHERE id = " + fileid, sqlCon);
            int cht = Convert.ToInt32(chktype.ExecuteScalar());
            SqlCommand comb = new SqlCommand(@"SELECT typeName FROM FileTypes WHERE idType = " + cht, sqlCon);
            string type = (string)comb.ExecuteScalar();
            typeComboBox.Text = type;
            sqlCon.Close();
        }
        private void ModifyFile_Load(object sender, EventArgs e)
        {
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

        private void modifyButton_Click(object sender, EventArgs e)
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
            SqlCommand idt = new SqlCommand("SELECT idType FROM FileTypes WHERE typeName = '" + typeComboBox.Text.ToString() + "'", sqlCon);
            int idtype = Convert.ToInt32(idt.ExecuteScalar());
            SqlCommand idfile = new SqlCommand(@"SELECT id FROM Files WHERE idFolder= " + idfol + " AND fileName = '" + label6.Text + "'", sqlCon);
            int fileid = Convert.ToInt32(idfile.ExecuteScalar());
            if (String.IsNullOrEmpty(location) && String.IsNullOrEmpty(name))
            {
                MessageBox.Show("No data was given!");
            }
            else if (String.IsNullOrEmpty(location) && name != null)
            {
                SqlCommand chkname = new SqlCommand(@"SELECT fileName FROM Files WHERE id = " + fileid, sqlCon);
                string chn = (string)chkname.ExecuteScalar();
                if (chn == name)
                {
                    MessageBox.Show("The file's name is the same as before!");
                }
                else
                {
                    SqlCommand modname = new SqlCommand(@"SET IDENTITY_INSERT Files ON; UPDATE Files SET fileName = '" + name + "', idType = " + idtype + " WHERE id = " + fileid + " SET IDENTITY_INSERT Files OFF", sqlCon);
                    modname.ExecuteNonQuery();
                    MessageBox.Show("Changed name!");
                    sqlCon.Close();
                    this.Close();
                }
            }
            else if (String.IsNullOrEmpty(name) && location != null)
            {
                using (FileStream fs = new FileStream(@location, FileMode.Open, FileAccess.Read))
                {
                    file = new byte[fs.Length];
                    fs.Read(file, 0, (int)fs.Length);
                }
                using (SqlCommand add = new SqlCommand(@"SET IDENTITY_INSERT Files ON; UPDATE Files SET Data = (@binarydata), idType = " + idtype + " WHERE id = " + fileid + " SET IDENTITY_INSERT Files OFF", sqlCon))
                {
                    add.Parameters.Add(new SqlParameter("@binarydata", file));
                    add.ExecuteNonQuery();
                }
                MessageBox.Show("File data edited successfuly!");
                sqlCon.Close();
                this.Close();
            }
            else
            {
                using (FileStream fs = new FileStream(@location, FileMode.Open, FileAccess.Read))
                {
                    file = new byte[fs.Length];
                    fs.Read(file, 0, (int)fs.Length);
                }
                using (SqlCommand add = new SqlCommand(@"SET IDENTITY_INSERT Files ON; UPDATE Files SET fileName = '" + name + "', Data = (@binarydata) idType = " + idtype + " WHERE id = " + fileid + " SET IDENTITY_INSERT Files OFF", sqlCon))
                {
                    add.Parameters.Add(new SqlParameter("@binarydata", file));
                    add.ExecuteNonQuery();
                }
                MessageBox.Show("File edited successfuly!");
                sqlCon.Close();
                this.Close();
            }
        }


    //SqlCommand chkfilname = new SqlCommand(@"SELECT fileName FROM Files WHERE idFolder = " + idfol, sqlCon);
    //string filchk = (string)chkfilname.ExecuteScalar(); 
    //SqlCommand idt = new SqlCommand("SELECT idType FROM FileTypes WHERE typeName = '" + typeComboBox.Text.ToString() + "'", sqlCon);
    //int idtype = Convert.ToInt32(idt.ExecuteScalar());
    //SqlCommand chkfilname = new SqlCommand(@"SELECT fileName FROM Files WHERE idFolder = " + idfol, sqlCon);
    //string filchk = (string)chkfilname.ExecuteScalar();


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
