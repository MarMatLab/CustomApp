namespace FileStorage
{
    partial class FileStorage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fileTree = new TreeView();
            label1 = new Label();
            label2 = new Label();
            addFolderButton = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            cancelButton = new Button();
            addButton = new Button();
            addFileButton = new Button();
            modifyFileButton = new Button();
            deleteFileButton = new Button();
            deleteFolderButton = new Button();
            folderChangeButton = new Button();
            downloadButton = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // fileTree
            // 
            fileTree.Location = new Point(12, 12);
            fileTree.Name = "fileTree";
            fileTree.Size = new Size(248, 574);
            fileTree.TabIndex = 0;
            fileTree.AfterSelect += fileTree_AfterSelect;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(338, 12);
            label1.Name = "label1";
            label1.Size = new Size(67, 30);
            label1.TabIndex = 1;
            label1.Text = "User:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(302, 42);
            label2.Name = "label2";
            label2.Size = new Size(55, 23);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // addFolderButton
            // 
            addFolderButton.Location = new Point(309, 83);
            addFolderButton.Name = "addFolderButton";
            addFolderButton.Size = new Size(124, 44);
            addFolderButton.TabIndex = 3;
            addFolderButton.Text = "Add Folder";
            addFolderButton.UseVisualStyleBackColor = true;
            addFolderButton.Click += addFolderButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 130);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 4;
            label3.Text = "Folder Name";
            label3.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(291, 153);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(164, 27);
            textBox1.TabIndex = 5;
            textBox1.Visible = false;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(318, 186);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(115, 30);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Visible = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(318, 222);
            addButton.Name = "addButton";
            addButton.Size = new Size(116, 36);
            addButton.TabIndex = 7;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Visible = false;
            addButton.Click += addButton_Click;
            // 
            // addFileButton
            // 
            addFileButton.Location = new Point(317, 395);
            addFileButton.Name = "addFileButton";
            addFileButton.Size = new Size(112, 45);
            addFileButton.TabIndex = 8;
            addFileButton.Text = "Add File";
            addFileButton.UseVisualStyleBackColor = true;
            addFileButton.Visible = false;
            addFileButton.Click += addFileButton_Click;
            // 
            // modifyFileButton
            // 
            modifyFileButton.Location = new Point(317, 496);
            modifyFileButton.Name = "modifyFileButton";
            modifyFileButton.Size = new Size(113, 43);
            modifyFileButton.TabIndex = 9;
            modifyFileButton.Text = "Modify File";
            modifyFileButton.UseVisualStyleBackColor = true;
            modifyFileButton.Visible = false;
            modifyFileButton.Click += modifyFileButton_Click;
            // 
            // deleteFileButton
            // 
            deleteFileButton.Location = new Point(317, 545);
            deleteFileButton.Name = "deleteFileButton";
            deleteFileButton.Size = new Size(113, 42);
            deleteFileButton.TabIndex = 10;
            deleteFileButton.Text = "DeleteFile";
            deleteFileButton.UseVisualStyleBackColor = true;
            deleteFileButton.Visible = false;
            deleteFileButton.Click += deleteFileButton_Click;
            // 
            // deleteFolderButton
            // 
            deleteFolderButton.Location = new Point(317, 321);
            deleteFolderButton.Name = "deleteFolderButton";
            deleteFolderButton.Size = new Size(115, 45);
            deleteFolderButton.TabIndex = 11;
            deleteFolderButton.Text = "Delete Folder";
            deleteFolderButton.UseVisualStyleBackColor = true;
            deleteFolderButton.Visible = false;
            deleteFolderButton.Click += deleteFolderButton_Click;
            // 
            // folderChangeButton
            // 
            folderChangeButton.Location = new Point(317, 264);
            folderChangeButton.Name = "folderChangeButton";
            folderChangeButton.Size = new Size(116, 51);
            folderChangeButton.TabIndex = 12;
            folderChangeButton.Text = "Change folder name";
            folderChangeButton.UseVisualStyleBackColor = true;
            folderChangeButton.Visible = false;
            folderChangeButton.Click += folderChangeButton_Click;
            // 
            // downloadButton
            // 
            downloadButton.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            downloadButton.Location = new Point(317, 446);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(112, 44);
            downloadButton.TabIndex = 13;
            downloadButton.Text = "Download File";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Visible = false;
            downloadButton.Click += downloadButton_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(421, 0);
            button1.Name = "button1";
            button1.Size = new Size(67, 42);
            button1.TabIndex = 14;
            button1.Text = "Reset Form";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FileStorage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 598);
            Controls.Add(button1);
            Controls.Add(downloadButton);
            Controls.Add(folderChangeButton);
            Controls.Add(deleteFolderButton);
            Controls.Add(deleteFileButton);
            Controls.Add(modifyFileButton);
            Controls.Add(addFileButton);
            Controls.Add(addButton);
            Controls.Add(cancelButton);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(addFolderButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fileTree);
            Name = "FileStorage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "File Storage";
            Load += FileStorage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView fileTree;
        private Label label1;
        private Label label2;
        private Button addFolderButton;
        private Label label3;
        private TextBox textBox1;
        private Button cancelButton;
        private Button addButton;
        private Button addFileButton;
        private Button modifyFileButton;
        private Button deleteFileButton;
        private Button deleteFolderButton;
        private Button folderChangeButton;
        private Button downloadButton;
        private Button button1;
        private Label label4;
    }
}