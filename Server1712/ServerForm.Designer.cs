namespace Server1712
{
    partial class ServerForm
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
            this.ServerLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServerLB
            // 
            this.ServerLB.AutoSize = true;
            this.ServerLB.Location = new System.Drawing.Point(306, 100);
            this.ServerLB.Name = "ServerLB";
            this.ServerLB.Size = new System.Drawing.Size(50, 17);
            this.ServerLB.TabIndex = 0;
            this.ServerLB.Text = "Server";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ServerLB);
            this.Name = "ServerForm";
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerLB;
    }
}

