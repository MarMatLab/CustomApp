namespace FileStorage
{
    partial class NewUser
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
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            mailTextBox = new TextBox();
            addUserButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 25);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 79);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 132);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 2;
            label3.Text = "e-mail";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(22, 49);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(134, 27);
            usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(22, 102);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(136, 27);
            passwordTextBox.TabIndex = 4;
            // 
            // mailTextBox
            // 
            mailTextBox.Location = new Point(22, 155);
            mailTextBox.Name = "mailTextBox";
            mailTextBox.Size = new Size(130, 27);
            mailTextBox.TabIndex = 5;
            // 
            // addUserButton
            // 
            addUserButton.Location = new Point(211, 79);
            addUserButton.Name = "addUserButton";
            addUserButton.Size = new Size(150, 50);
            addUserButton.TabIndex = 6;
            addUserButton.Text = "Add User";
            addUserButton.UseVisualStyleBackColor = true;
            addUserButton.Click += addUserButton_Click;
            // 
            // NewUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 189);
            Controls.Add(addUserButton);
            Controls.Add(mailTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NewUser";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New User";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private TextBox mailTextBox;
        private Button addUserButton;
    }
}