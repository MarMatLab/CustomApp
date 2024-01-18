namespace FileStorage
{
    partial class AddFile
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            nameTextBox = new TextBox();
            fileTextBox = new TextBox();
            addButton = new Button();
            typeComboBox = new ComboBox();
            label4 = new Label();
            searchButton = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 32);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "File Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 121);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "File Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(141, 213);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 2;
            label3.Text = "File Path";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(89, 55);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(174, 27);
            nameTextBox.TabIndex = 3;
            // 
            // fileTextBox
            // 
            fileTextBox.Location = new Point(89, 236);
            fileTextBox.Name = "fileTextBox";
            fileTextBox.Size = new Size(149, 27);
            fileTextBox.TabIndex = 5;
            // 
            // addButton
            // 
            addButton.Location = new Point(96, 296);
            addButton.Name = "addButton";
            addButton.Size = new Size(160, 37);
            addButton.TabIndex = 6;
            addButton.Text = "Add File";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(89, 144);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(174, 28);
            typeComboBox.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(275, 5);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 15;
            label4.Text = "label4";
            label4.Visible = false;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(238, 236);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(25, 26);
            searchButton.TabIndex = 16;
            searchButton.Text = "...";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(214, 13);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 17;
            label5.Text = "label5";
            label5.Visible = false;
            // 
            // AddFile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 348);
            Controls.Add(label5);
            Controls.Add(searchButton);
            Controls.Add(label4);
            Controls.Add(typeComboBox);
            Controls.Add(addButton);
            Controls.Add(fileTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddFile";
            Text = "Add File";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox nameTextBox;
        private TextBox fileTextBox;
        private Button addButton;
        private ComboBox typeComboBox;
        private Label label4;
        private Button searchButton;
        private Label label5;
    }
}