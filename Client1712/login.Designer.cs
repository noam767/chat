namespace Client1712
{
    partial class login
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
            this.LBLoginForm = new System.Windows.Forms.Label();
            this.LabelPass_E = new System.Windows.Forms.Label();
            this.LabeluN_E = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxUN = new System.Windows.Forms.TextBox();
            this.LabelPass = new System.Windows.Forms.Label();
            this.BTSignUp = new System.Windows.Forms.Button();
            this.BTLog = new System.Windows.Forms.Button();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LBLoginForm
            // 
            this.LBLoginForm.AutoSize = true;
            this.LBLoginForm.Location = new System.Drawing.Point(324, 51);
            this.LBLoginForm.Name = "LBLoginForm";
            this.LBLoginForm.Size = new System.Drawing.Size(75, 17);
            this.LBLoginForm.TabIndex = 7;
            this.LBLoginForm.Text = "LoginForm";
            this.LBLoginForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelPass_E
            // 
            this.LabelPass_E.AutoSize = true;
            this.LabelPass_E.Location = new System.Drawing.Point(445, 219);
            this.LabelPass_E.Name = "LabelPass_E";
            this.LabelPass_E.Size = new System.Drawing.Size(40, 17);
            this.LabelPass_E.TabIndex = 16;
            this.LabelPass_E.Text = "Error";
            this.LabelPass_E.Visible = false;
            // 
            // LabeluN_E
            // 
            this.LabeluN_E.AutoSize = true;
            this.LabeluN_E.Location = new System.Drawing.Point(445, 149);
            this.LabeluN_E.Name = "LabeluN_E";
            this.LabeluN_E.Size = new System.Drawing.Size(40, 17);
            this.LabeluN_E.TabIndex = 15;
            this.LabeluN_E.Text = "Error";
            this.LabeluN_E.Visible = false;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(327, 218);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(99, 22);
            this.textBoxPass.TabIndex = 14;
            // 
            // textBoxUN
            // 
            this.textBoxUN.Location = new System.Drawing.Point(327, 148);
            this.textBoxUN.Name = "textBoxUN";
            this.textBoxUN.Size = new System.Drawing.Size(99, 22);
            this.textBoxUN.TabIndex = 13;
            // 
            // LabelPass
            // 
            this.LabelPass.AutoSize = true;
            this.LabelPass.Location = new System.Drawing.Point(254, 218);
            this.LabelPass.Name = "LabelPass";
            this.LabelPass.Size = new System.Drawing.Size(68, 17);
            this.LabelPass.TabIndex = 12;
            this.LabelPass.Text = "password";
            // 
            // BTSignUp
            // 
            this.BTSignUp.Location = new System.Drawing.Point(420, 280);
            this.BTSignUp.Name = "BTSignUp";
            this.BTSignUp.Size = new System.Drawing.Size(109, 31);
            this.BTSignUp.TabIndex = 11;
            this.BTSignUp.Text = "Sign Up";
            this.BTSignUp.UseVisualStyleBackColor = true;
            this.BTSignUp.Click += new System.EventHandler(this.BTSignUp_Click);
            // 
            // BTLog
            // 
            this.BTLog.Location = new System.Drawing.Point(246, 280);
            this.BTLog.Name = "BTLog";
            this.BTLog.Size = new System.Drawing.Size(109, 31);
            this.BTLog.TabIndex = 10;
            this.BTLog.Text = "Login";
            this.BTLog.UseVisualStyleBackColor = true;
            this.BTLog.Click += new System.EventHandler(this.BTLog_Click_1);
            // 
            // LabelUserName
            // 
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.Location = new System.Drawing.Point(243, 148);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(77, 17);
            this.LabelUserName.TabIndex = 9;
            this.LabelUserName.Text = "User name";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LabelPass_E);
            this.Controls.Add(this.LabeluN_E);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxUN);
            this.Controls.Add(this.LabelPass);
            this.Controls.Add(this.BTSignUp);
            this.Controls.Add(this.BTLog);
            this.Controls.Add(this.LabelUserName);
            this.Controls.Add(this.LBLoginForm);
            this.Name = "login";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBLoginForm;
        private System.Windows.Forms.Label LabelPass_E;
        private System.Windows.Forms.Label LabeluN_E;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxUN;
        private System.Windows.Forms.Label LabelPass;
        private System.Windows.Forms.Button BTSignUp;
        private System.Windows.Forms.Button BTLog;
        private System.Windows.Forms.Label LabelUserName;
    }
}

