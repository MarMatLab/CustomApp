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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileStorage
{
    public partial class FileStorage : Form
    {
        private object dbHandling;
        SqlConnection sqlCon = Login.sqlCon;
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        string path = "";
        public FileStorage(MacAddresDBHandling dBHandling)
        {
            InitializeComponent();
            label2.Text = Login.SetValueForText1;
        }

        public void FillTree()
        {
            this.fileTree.Nodes.Clear();

            sqlCon.Open();
            SqlCommand user = new SqlCommand(@"SELECT idUser from Users WHERE username = '" + label2.Text + "'", sqlCon);
            int un = Convert.ToInt32(user.ExecuteScalar());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM Folders WHERE idUser = " + un, sqlCon);
            da.Fill(dt);
            fileTree.Nodes.Add("Folders");
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode parrent = new TreeNode(dr["folderName"].ToString());
                SqlCommand fol = new SqlCommand(@"SELECT idFolders FROM Folders WHERE folderName = '" + dr["folderName"].ToString() + "'", sqlCon);
                int idf = Convert.ToInt32(fol.ExecuteScalar());
                SqlCommand fil = new SqlCommand(@"SELECT fileName FROM Files WHERE idFolder = " + idf, sqlCon);

                SqlDataReader readerchild = fil.ExecuteReader();

                while (readerchild.Read())
                {
                    string fill = readerchild.GetString(0);
                    parrent.Nodes.Add(fill);
                }
                readerchild.Close();
                fileTree.Nodes.Add(parrent);
            }
            sqlCon.Close();
        }

        private void FileStorage_Load(object sender, EventArgs e)
        {
            FillTree();
        }

        private void fileTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sel = fileTree.SelectedNode.Text.ToString();
            folderChangeButton.Visible = false;
            deleteFolderButton.Visible = false;
            addFileButton.Visible = false;
            modifyFileButton.Visible = false;
            deleteFileButton.Visible = false;
            downloadButton.Visible = false;
            sqlCon.Open();
            SqlCommand folder = new SqlCommand(@"SELECT folderName FROM Folders WHERE folderName = '" + sel + "'", sqlCon);
            string folcheck = (string)folder.ExecuteScalar();
            SqlCommand file = new SqlCommand(@"SELECT fileName FROM Files WHERE fileName = '" + sel + "'", sqlCon);
            string filcheck = (string)file.ExecuteScalar();
            if (folcheck == null)
            {
                if (filcheck == null)
                {

                }
                else
                {
                    modifyFileButton.Visible = true;
                    deleteFileButton.Visible = true;
                    downloadButton.Visible = true;
                }
            }
            else
            {
                //SqlCommand id = new SqlCommand(@"SELECT idFolder FROM Folders WHERE folderName = '" + sel + "'", sqlCon);
                //int idfol = Convert.ToInt32(id.ExecuteScalar());
                folderChangeButton.Visible = true;
                deleteFolderButton.Visible = true;
                addFileButton.Visible = true;
            }
            sqlCon.Close();
        }

        private void addFolderButton_Click(object sender, EventArgs e)
        {
            addButton.Visible = true;
            addFolderButton.Visible = false;
            textBox1.Visible = true;
            label3.Visible = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            string folname = textBox1.Text.ToString();
            if (String.IsNullOrEmpty(folname))
            {
                MessageBox.Show("No folder name was given!");
            }
            else if (folname == "Folders")
            {
                MessageBox.Show("Can't add a folder with this name.");
            }
            else
            {
                sqlCon.Open();
                SqlCommand userid = new SqlCommand(@"SELECT idUser FROM Users WHERE username = '" + label2.Text + "'", sqlCon);
                int idu = Convert.ToInt32(userid.ExecuteScalar());
                SqlCommand folnchk = new SqlCommand(@"SELECT folderName FROM Folders WHERE idUser = " + idu, sqlCon);
                string foldername = (string)folnchk.ExecuteScalar();
                if (folname == foldername)
                {
                    MessageBox.Show("A folder with this name already exists for this user!");
                }
                else
                {
                    SqlCommand addfol = new SqlCommand(@"INSERT INTO Folders (folderName, idUser) VALUES ('" + folname + "', " + idu + ")", sqlCon);
                    addfol.ExecuteNonQuery();
                    MessageBox.Show("Folder added successfully!");
                    addButton.Visible = false;
                    addFolderButton.Visible = true;
                    textBox1.Visible = false;
                    label3.Visible = false;
                    textBox1.Text = "";
                    sqlCon.Close();
                    FillTree();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            addButton.Visible = false;
            addFolderButton.Visible = true;
            textBox1.Visible = false;
            label3.Visible = false;
        }

        private void deleteFolderButton_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            var confirm = MessageBox.Show("Do You want to delete this folder? It will also delete all files in it!", "You are about to delete a folder!", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                sqlCon.Open();
                SqlCommand userid = new SqlCommand(@"SELECT idUser FROM Users WHERE username = '" + label2.Text + "'", sqlCon);
                int idu = Convert.ToInt32(userid.ExecuteScalar());
                SqlCommand folid = new SqlCommand(@"SELECT idFolders FROM Folders WHERE folderName = '" + fileTree.SelectedNode.Text + "'", sqlCon);
                int idf = Convert.ToInt32(folid.ExecuteScalar());
                SqlCommand delfile = new SqlCommand(@"DELETE FROM Files WHERE idFolder = " + idf, sqlCon);
                delfile.ExecuteNonQuery();
                SqlCommand delfol = new SqlCommand(@"DELETE FROM Folders WHERE idUser =" + idu + " AND folderName = '" + fileTree.SelectedNode.Text + "'", sqlCon);
                delfol.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted folder");
                sqlCon.Close();
                FillTree();
            }
            else if (confirm == DialogResult.No)
            {

            }
        }

        private void folderChangeButton_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            bool labelvis = label3.Visible;
            if (labelvis == false)
            {
                textBox1.Visible = true;
                label3.Visible = true;
                cancelButton.Visible = true;
            }
            else if (labelvis == true)
            {
                string folname = textBox1.Text.ToString();
                if (String.IsNullOrEmpty(folname))
                {
                    MessageBox.Show("No folder name was given!");
                }
                else if (folname == "Folders")
                {
                    MessageBox.Show("Can't edit a folder to have this name.");
                }
                else
                {
                    sqlCon.Open();
                    SqlCommand userid = new SqlCommand(@"SELECT idUser FROM Users WHERE username = '" + label2.Text + "'", sqlCon);
                    int idu = Convert.ToInt32(userid.ExecuteScalar());
                    SqlCommand folnchk = new SqlCommand(@"SELECT folderName FROM Folders WHERE idUser = " + idu, sqlCon);
                    string foldername = (string)folnchk.ExecuteScalar();
                    if (folname == foldername)
                    {
                        MessageBox.Show("The name won't be changed");
                    }
                    else
                    {
                        SqlCommand addfol = new SqlCommand(@"SET IDENTITY_INSERT Folders ON; UPDATE Folders SET folderName = '" + folname + "' WHERE folderName = '" + foldername + "' AND idUser = " + idu + " SET IDENTITY_INSERT Folders OFF", sqlCon);
                        addfol.ExecuteNonQuery();
                        MessageBox.Show("Folder's name changed successfully!");
                        addButton.Visible = false;
                        addFolderButton.Visible = true;
                        textBox1.Visible = false;
                        label3.Visible = false;
                        cancelButton.Visible = false;
                        textBox1.Text = "";
                        sqlCon.Close();
                        FillTree();
                    }
                }
            }

        }

        private void addFileButton_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            SetValueForText2 = fileTree.SelectedNode.Text.ToString();
            SetValueForText3 = label2.Text.ToString();
            AddFile frm3 = new AddFile(dbHandling);
            frm3.Show();
            sqlCon.Close();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            sqlCon.Close();

                sqlCon.Open();
                SqlCommand userid = new SqlCommand(@"SELECT idUser FROM Users WHERE username = '" + label2.Text + "'", sqlCon);
                int idu = Convert.ToInt32(userid.ExecuteScalar());
                SqlCommand folid = new SqlCommand(@"SELECT idFolders FROM Folders WHERE folderName = '" + fileTree.SelectedNode.Parent.Text + "' AND idUser = " + idu, sqlCon);
                int idf = Convert.ToInt32(folid.ExecuteScalar());
                SqlCommand filid = new SqlCommand(@"SELECT id FROM Files WHERE fileName = '" + fileTree.SelectedNode.Text + "' AND idFolder = " + idf, sqlCon);
                int idfil = Convert.ToInt32(filid.ExecuteScalar());
                SqlCommand type = new SqlCommand(@"SELECT idType FROM Files WHERE id = " + idfil, sqlCon);
                int ftype = Convert.ToInt32(type.ExecuteScalar());
                path = @"C:\FileStorage\" + label2.Text + @"\" + fileTree.SelectedNode.Parent.Text;

                if (Directory.Exists(path))
                {
                if (ftype == 1)
                {
                    SqlCommand pdf = new SqlCommand(@"SELECT Data FROM Files WHERE id = " + idfil, sqlCon);
                    byte[] binaryfile = (byte[])pdf.ExecuteScalar();
                    if (binaryfile != null)
                    {
                        string location = path + @"\" + fileTree.SelectedNode.Text + ".pdf";
                        File.WriteAllBytes(location, binaryfile);
                        MessageBox.Show("Successfully downloaded the file! You can find it at: " + location);
                        sqlCon.Close();
                    }

                }
                if (ftype == 2)
                {
                    SqlCommand txt = new SqlCommand(@"SELECT Data FROM Files WHERE id = " + idfil, sqlCon);
                    byte[] binaryfile = (byte[])txt.ExecuteScalar();
                    if (binaryfile != null)
                    {
                        string location = path + @"\" + fileTree.SelectedNode.Text + ".txt";
                        File.WriteAllBytes(location, binaryfile);
                        MessageBox.Show("Successfully downloaded the file! You can find it at: " + location);
                        sqlCon.Close();
                    }
                }           
                }
                else
                {
                DirectoryInfo di = Directory.CreateDirectory(path);
                if (ftype == 1)
                {
                    SqlCommand pdf = new SqlCommand(@"SELECT Data FROM Files WHERE id = " + idfil, sqlCon);
                    byte[] binaryfile = (byte[])pdf.ExecuteScalar();
                    if (binaryfile != null)
                    {
                        string location = path + @"\" + fileTree.SelectedNode.Text + ".pdf";
                        File.WriteAllBytes(location, binaryfile);
                        MessageBox.Show("Successfully downloaded the file! You can find it at: " + location);
                        sqlCon.Close();
                    }

                }
                if (ftype == 2)
                {
                    SqlCommand txt = new SqlCommand(@"SELECT Data FROM Files WHERE id = " + idfil, sqlCon);
                    byte[] binaryfile = (byte[])txt.ExecuteScalar();
                    if (binaryfile != null)
                    {
                        string location = path + @"\" + fileTree.SelectedNode.Text + ".txt";
                        File.WriteAllBytes(location, binaryfile);
                        MessageBox.Show("Successfully downloaded the file! You can find it at: " + location);
                        sqlCon.Close();
                    }
                }
            
        }
    }

        private void modifyFileButton_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            SetValueForText2 = fileTree.SelectedNode.Parent.Text.ToString();
            SetValueForText3 = label2.Text.ToString();
            SetValueForText4 = fileTree.SelectedNode.Text.ToString();
            ModifyFile frm4 = new ModifyFile(dbHandling);
            frm4.Show();
            sqlCon.Close();
        }

        private void deleteFileButton_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            var confirm = MessageBox.Show("Do You want to delete this file?", "You are about to delete a file!", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                sqlCon.Open();
                SqlCommand userid = new SqlCommand(@"SELECT idUser FROM Users WHERE username = '" + label2.Text + "'", sqlCon);
                int idu = Convert.ToInt32(userid.ExecuteScalar());
                SqlCommand folid = new SqlCommand(@"SELECT idFolders FROM Folders WHERE folderName = '" + fileTree.SelectedNode.Parent.Text + "' AND idUser = " + idu, sqlCon);
                int idf = Convert.ToInt32(folid.ExecuteScalar());
                SqlCommand filid = new SqlCommand(@"SELECT id FROM Files WHERE fileName = '" + fileTree.SelectedNode.Text + "' AND idFolder = " + idf, sqlCon);
                int idfil = Convert.ToInt32(filid.ExecuteScalar());
                SqlCommand delfile = new SqlCommand("DELETE FROM Files WHERE id = " + idfil, sqlCon);
                delfile.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("File deleted successfuly!");
                FillTree();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillTree();
        }
    }
}
