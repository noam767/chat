namespace Client1712
{
    partial class clientForm
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
            this.LBloginUsers = new System.Windows.Forms.ListBox();
            this.LBroomList = new System.Windows.Forms.ListBox();
            this.LBroomUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RTBroomChat = new System.Windows.Forms.RichTextBox();
            this.TBroomChat = new System.Windows.Forms.TextBox();
            this.BTsendChatRoom = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BTstartGame = new System.Windows.Forms.Button();
            this.BTcreate = new System.Windows.Forms.Button();
            this.BTjoin = new System.Windows.Forms.Button();
            this.LBuserName = new System.Windows.Forms.Label();
            this.TBroomName = new System.Windows.Forms.TextBox();
            this.PANglobalchat = new System.Windows.Forms.Panel();
            this.BTsendChatGlobal = new System.Windows.Forms.Button();
            this.TBglobalChat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RTBglobalChat = new System.Windows.Forms.RichTextBox();
            this.PANgameBoard = new System.Windows.Forms.Panel();
            this.LBTimer = new System.Windows.Forms.Label();
            this.PANglobalchat.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBloginUsers
            // 
            this.LBloginUsers.FormattingEnabled = true;
            this.LBloginUsers.ItemHeight = 16;
            this.LBloginUsers.Location = new System.Drawing.Point(1001, 71);
            this.LBloginUsers.Name = "LBloginUsers";
            this.LBloginUsers.Size = new System.Drawing.Size(120, 660);
            this.LBloginUsers.TabIndex = 0;
            // 
            // LBroomList
            // 
            this.LBroomList.FormattingEnabled = true;
            this.LBroomList.ItemHeight = 16;
            this.LBroomList.Location = new System.Drawing.Point(851, 71);
            this.LBroomList.Name = "LBroomList";
            this.LBroomList.Size = new System.Drawing.Size(120, 196);
            this.LBroomList.TabIndex = 1;
            // 
            // LBroomUsers
            // 
            this.LBroomUsers.FormattingEnabled = true;
            this.LBroomUsers.ItemHeight = 16;
            this.LBroomUsers.Location = new System.Drawing.Point(851, 398);
            this.LBroomUsers.Name = "LBroomUsers";
            this.LBroomUsers.Size = new System.Drawing.Size(120, 292);
            this.LBroomUsers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(848, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "room list";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(998, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "login users";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(848, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "room users";
            // 
            // RTBroomChat
            // 
            this.RTBroomChat.Location = new System.Drawing.Point(41, 492);
            this.RTBroomChat.Name = "RTBroomChat";
            this.RTBroomChat.Size = new System.Drawing.Size(791, 195);
            this.RTBroomChat.TabIndex = 8;
            this.RTBroomChat.Text = "";
            // 
            // TBroomChat
            // 
            this.TBroomChat.Location = new System.Drawing.Point(41, 702);
            this.TBroomChat.Name = "TBroomChat";
            this.TBroomChat.Size = new System.Drawing.Size(571, 22);
            this.TBroomChat.TabIndex = 10;
            // 
            // BTsendChatRoom
            // 
            this.BTsendChatRoom.Location = new System.Drawing.Point(618, 700);
            this.BTsendChatRoom.Name = "BTsendChatRoom";
            this.BTsendChatRoom.Size = new System.Drawing.Size(214, 28);
            this.BTsendChatRoom.TabIndex = 12;
            this.BTsendChatRoom.Text = "send";
            this.BTsendChatRoom.UseVisualStyleBackColor = true;
            this.BTsendChatRoom.Click += new System.EventHandler(this.BTsendChatRoom_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "room chat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "user name";
            // 
            // BTstartGame
            /*
            this.BTstartGame.Location = new System.Drawing.Point(851, 696);
            this.BTstartGame.Name = "BTstartGame";
            this.BTstartGame.Size = new System.Drawing.Size(120, 35);
            this.BTstartGame.TabIndex = 15;
            this.BTstartGame.Text = "start game";
            this.BTstartGame.UseVisualStyleBackColor = true;
            this.BTstartGame.Click += new System.EventHandler(this.BTstartGame_Click);
            */ 
            // BTcreate
            // 
            this.BTcreate.Location = new System.Drawing.Point(851, 313);
            this.BTcreate.Name = "BTcreate";
            this.BTcreate.Size = new System.Drawing.Size(58, 35);
            this.BTcreate.TabIndex = 16;
            this.BTcreate.Text = "create";
            this.BTcreate.UseVisualStyleBackColor = true;
            this.BTcreate.Click += new System.EventHandler(this.BTcreate_Click);
            // 
            // BTjoin
            // 
            this.BTjoin.Location = new System.Drawing.Point(923, 313);
            this.BTjoin.Name = "BTjoin";
            this.BTjoin.Size = new System.Drawing.Size(48, 35);
            this.BTjoin.TabIndex = 17;
            this.BTjoin.Text = "join";
            this.BTjoin.UseVisualStyleBackColor = true;
            this.BTjoin.Click += new System.EventHandler(this.BTjoin_Click);
            // 
            // LBuserName
            // 
            this.LBuserName.AutoSize = true;
            this.LBuserName.Location = new System.Drawing.Point(128, 22);
            this.LBuserName.Name = "LBuserName";
            this.LBuserName.Size = new System.Drawing.Size(144, 17);
            this.LBuserName.TabIndex = 18;
            this.LBuserName.Text = "_________________";
            // 
            // TBroomName
            // 
            this.TBroomName.Location = new System.Drawing.Point(851, 285);
            this.TBroomName.Name = "TBroomName";
            this.TBroomName.Size = new System.Drawing.Size(120, 22);
            this.TBroomName.TabIndex = 19;
            // 
            // PANglobalchat
            // 
            this.PANglobalchat.Controls.Add(this.BTsendChatGlobal);
            this.PANglobalchat.Controls.Add(this.TBglobalChat);
            this.PANglobalchat.Controls.Add(this.label4);
            this.PANglobalchat.Controls.Add(this.RTBglobalChat);
            this.PANglobalchat.Location = new System.Drawing.Point(41, 71);
            this.PANglobalchat.Name = "PANglobalchat";
            this.PANglobalchat.Size = new System.Drawing.Size(793, 399);
            this.PANglobalchat.TabIndex = 20;
            // 
            // BTsendChatGlobal
            // 
            this.BTsendChatGlobal.Location = new System.Drawing.Point(713, 365);
            this.BTsendChatGlobal.Name = "BTsendChatGlobal";
            this.BTsendChatGlobal.Size = new System.Drawing.Size(77, 31);
            this.BTsendChatGlobal.TabIndex = 15;
            this.BTsendChatGlobal.Text = "send";
            this.BTsendChatGlobal.UseVisualStyleBackColor = true;
            // 
            // TBglobalChat
            // 
            this.TBglobalChat.Location = new System.Drawing.Point(3, 377);
            this.TBglobalChat.Name = "TBglobalChat";
            this.TBglobalChat.Size = new System.Drawing.Size(704, 22);
            this.TBglobalChat.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "global chat";
            // 
            // RTBglobalChat
            // 
            this.RTBglobalChat.Location = new System.Drawing.Point(2, 27);
            this.RTBglobalChat.Name = "RTBglobalChat";
            this.RTBglobalChat.Size = new System.Drawing.Size(791, 332);
            this.RTBglobalChat.TabIndex = 12;
            this.RTBglobalChat.Text = "";
            // 
            // PANgameBoard
            // 
            this.PANgameBoard.Location = new System.Drawing.Point(39, 71);
            this.PANgameBoard.Name = "PANgameBoard";
            this.PANgameBoard.Size = new System.Drawing.Size(793, 399);
            this.PANgameBoard.TabIndex = 21;
            
            // 
            // LBTimer
            // 
            this.LBTimer.AutoSize = true;
            this.LBTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBTimer.Location = new System.Drawing.Point(522, 10);
            this.LBTimer.Name = "LBTimer";
            this.LBTimer.Size = new System.Drawing.Size(137, 58);
            this.LBTimer.TabIndex = 22;
            this.LBTimer.Text = "0:0:0";
            // 
            // clientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 759);
            this.Controls.Add(this.LBTimer);
            this.Controls.Add(this.PANgameBoard);
            this.Controls.Add(this.PANglobalchat);
            this.Controls.Add(this.TBroomName);
            this.Controls.Add(this.LBuserName);
            this.Controls.Add(this.BTjoin);
            this.Controls.Add(this.BTcreate);
            this.Controls.Add(this.BTstartGame);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BTsendChatRoom);
            this.Controls.Add(this.TBroomChat);
            this.Controls.Add(this.RTBroomChat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBroomUsers);
            this.Controls.Add(this.LBroomList);
            this.Controls.Add(this.LBloginUsers);
            this.Name = "clientForm";
            this.Text = "client form";
            this.PANglobalchat.ResumeLayout(false);
            this.PANglobalchat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBloginUsers;
        private System.Windows.Forms.ListBox LBroomList;
        private System.Windows.Forms.ListBox LBroomUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox RTBroomChat;
        private System.Windows.Forms.TextBox TBroomChat;
        private System.Windows.Forms.Button BTsendChatRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTstartGame;
        private System.Windows.Forms.Button BTcreate;
        private System.Windows.Forms.Button BTjoin;
        private System.Windows.Forms.Label LBuserName;
        private System.Windows.Forms.TextBox TBroomName;
        private System.Windows.Forms.Panel PANglobalchat;
        private System.Windows.Forms.Button BTsendChatGlobal;
        private System.Windows.Forms.TextBox TBglobalChat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox RTBglobalChat;
        private System.Windows.Forms.Panel PANgameBoard;
        private System.Windows.Forms.Label LBTimer;
    }
}