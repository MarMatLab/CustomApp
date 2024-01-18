namespace FileStorage
{
    partial class ModifyFile
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
            modifyButton = new Button();
            fileTextBox = new TextBox();
            nameTextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            typeComboBox = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            searchButton = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // modifyButton
            // 
            modifyButton.Location = new Point(92, 297);
            modifyButton.Name = "modifyButton";
            modifyButton.Size = new Size(160, 37);
            modifyButton.TabIndex = 12;
            modifyButton.Text = "Modify File";
            modifyButton.UseVisualStyleBackColor = true;
            modifyButton.Click += modifyButton_Click;
            // 
            // fileTextBox
            // 
            fileTextBox.Location = new Point(85, 237);
            fileTextBox.Name = "fileTextBox";
            fileTextBox.Size = new Size(149, 27);
            fileTextBox.TabIndex = 11;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(85, 56);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(174, 27);
            nameTextBox.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(137, 214);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 9;
            label3.Text = "File Path";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 122);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 8;
            label2.Text = "File Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 33);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 7;
            label1.Text = "File Name";
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(85, 145);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(167, 28);
            typeComboBox.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 17);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 19;
            label5.Text = "label5";
            label5.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 9);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 18;
            label4.Text = "label4";
            label4.Visible = false;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(234, 237);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(25, 27);
            searchButton.TabIndex = 20;
            searchButton.Text = "...";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(130, 9);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 21;
            label6.Text = "label6";
            label6.Visible = false;
            // 
            // ModifyFile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 357);
            Controls.Add(label6);
            Controls.Add(searchButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(typeComboBox);
            Controls.Add(modifyButton);
            Controls.Add(fileTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ModifyFile";
            Text = "Modify File";
            Load += ModifyFile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button modifyButton;
        private TextBox fileTextBox;
        private TextBox nameTextBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox typeComboBox;
        private Label label5;
        private Label label4;
        private Button searchButton;
        private Label label6;
    }
}