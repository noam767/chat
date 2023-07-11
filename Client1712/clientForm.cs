using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client1712
{
    public partial class clientForm : Form
    {
        Socket _clientSocket;
        string _userName;
        Thread waitToReciveFromServer;
        string _roomName = "";
        System.Windows.Forms.Timer T;
        int min = 0, hour = 0, sec = 0;
        PacmanPlayer Pac1;
        bool TurnFlag = false;
        int val;
        public clientForm(Socket s, string name)
        {
            InitializeComponent();
            PANgameBoard.Visible = false;
            _clientSocket = s;
            _userName = name;
            LBuserName.Text = _userName;
           
            waitToReciveFromServer = new Thread(ReceiveInformationFromServer);
            waitToReciveFromServer.Start();
            startClientForm();
        }
        private void addToListBox(ListBox lb, string name)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { addToListBox(lb, name); }));
                return;
            }
            lb.Items.Add(name);
        }


        private void startClientForm()
        {



            byte[] userData = Encoding.Unicode.GetBytes("users;new");
            _clientSocket.Send(userData);

        }
        private bool ownerNotInList(string v)
        {
            bool userExsit = false;
            int index = 0;
            while (!userExsit && index < LBroomList.Items.Count)
            {
                userExsit = LBroomList.Items[index].ToString() == v;
                index++;
            }
            return !userExsit;
        }
        private void ReceiveInformationFromServer()
        {
            byte[] buffer = new byte[1024];
            bool ownerExist = false;
            BTstartGame.Visible = false;
            while (_clientSocket.Connected)
            {
                int rec = _clientSocket.Receive(buffer);
                byte[] tempBuffer = new byte[rec];
                Array.Copy(buffer, tempBuffer, rec);
                string serverInformation = Encoding.Unicode.GetString(tempBuffer);
                string[] messageInfo = serverInformation.Split(';');
                string Command = messageInfo[0];
                string option = messageInfo[1];
                if (Command.Equals("users"))
                {
                    if (option.Equals("new"))
                    {

                        int RoomStart = FindChar(messageInfo);
                        for (int i = 2; i < RoomStart; i += 2)
                        {
                            string user = messageInfo[i];
                            addToListBox(LBloginUsers, user);
                        }
                        for (int i = RoomStart + 1; i < messageInfo.Length; i += 2)
                        {
                            string roomName = messageInfo[i];
                            string owner = messageInfo[i + 1];
                            addToListBox(LBroomList, roomName + "---->" + owner);
                        }
                    }
                    if (option.Equals("add"))
                    {
                        string LastuserConnected = messageInfo[2];
                        addToListBox(LBloginUsers, LastuserConnected);
                    }
                }
                if (Command.Equals("room"))
                {
                    if (option.Equals("exist"))
                    {
                        MessageBox.Show("room with this name allready exist");
                    }
                    if (option.Equals("add"))
                    {
                        string username = messageInfo[2];
                        string Rname = messageInfo[3];
                        addToListBox(LBroomList, username + "---->" + Rname);
                    }
                    if (option.Equals("join"))
                    {
                        string typeAct = messageInfo[2];
                        if (typeAct.Equals("add"))
                        {
                            string Ownername = messageInfo[5];
                            string roomName = messageInfo[6];
                            string zero = messageInfo[4];
                            string userName_ = messageInfo[3];
                            if (_userName == Ownername && ownerNotInList(Ownername))
                            {

                                _roomName = roomName;
                                if (!ownerExist)
                                {
                                    addToListBox(LBroomUsers, Ownername + "---->" + zero);
                                    ownerExist = true;
                                }
                            }
                            addToListBox(LBroomUsers, userName_ + "---->" + zero);
                        }
                        if (typeAct.Equals("new"))
                        {

                            for (int i = 3; i < messageInfo.Length; i += 2)
                            {
                                string userName = messageInfo[i];
                                string zero = messageInfo[i + 1];
                                addToListBox(LBroomUsers, userName + "---->" + zero);
                            }
                        }
                    }

                }
                if (Command.Equals("chat"))
                {
                    string UserName = messageInfo[2];
                    string TXT = messageInfo[3];
                    if (option.Equals("Global"))
                    {
                        writeToChat(RTBglobalChat, UserName, TXT);
                    }
                    if (option.Equals("Room"))
                    {
                        writeToChat(RTBroomChat, UserName, TXT);
                    }
                }
                /*if (Command.Equals("game"))
                {
                    if (option.Equals("intru"))
                    {
                        openGameBoard();
                    }
                    if (option.Equals("PacDirection"))
                    {
                        string Pacdir = messageInfo[2];
                        Pac1.dir = Pacdir;
                    }
                    if (option.Equals("Wall"))
                    {
                        string Pacdir = messageInfo[2];
                        Pac1.dir = Pacdir;
                    }
                    if (option.Equals("port"))
                    {
                        TurnFlag = bool.Parse(messageInfo[2]);
                    }
                }*/

            }
        }


        /*
        private void openGameBoard()
        {

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { openGameBoard(); }));
                return;
            }
            PANglobalchat.Visible = false;
            PANgameBoard.Visible = true;
            drawGameBoard();
        }

        private void drawGameBoard()
        {
            TurnFlag = true;
            Pac1 = new PacmanPlayer(_userName, "pacRight");

            int Ystart = 0;
            int Xstart = 0;
            int Yend = PANgameBoard.Height;
            int Xend = PANgameBoard.Width;
            LBTimer.Text = hour + ":" + min + ":" + sec;
            Pac1.drawBoardGame(PANgameBoard, Xstart, Ystart);
            T = new System.Windows.Forms.Timer();
            T.Interval = 1000;
            T.Enabled = true;
            T.Start();
            T.Tick += T_Tick;

        }

        private void T_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 60)
            {
                sec = 0; min++;
            }
            if (min == 60)
            {
                hour++; min = 0;
            }
            LBTimer.Text = hour + ":" + min + ":" + sec;
            val = Pac1.Move(Pac1.dir);
            Debug.WriteLine(Pac1.dir);
            if (val == 3 && TurnFlag)
            {
                string userInfo = "game;port;" + _userName + ";" + _roomName;
                SendInformationToServer(userInfo);

            }
            if(val ==1 && TurnFlag)
            {   
                string ReverseDir = reverseDir(Pac1.dir);
                SendInformationToServer("game;Wall;" + ReverseDir + ";" + _roomName);
               
            }

        }

        private string reverseDir(string dir)
        {
            if (dir.Equals("pacRight"))
                return "pacLeft";
            if (dir.Equals("pacLeft"))
                return "pacRight";
            if (dir.Equals("pacUp"))
                return "pacDown";
            if (dir.Equals("pacDown"))
                return "pacUp";
            return "";
        }

        private void BTstartGame_Click(object sender, EventArgs e)
        {   
            string userInfo = "game;intru;"+_roomName;
            SendInformationToServer(userInfo);

        }
        private void visibleStartGameButton()
        {
            if (InvokeRequired)//אם יש קראיה מפונקצה חיצונית אז 
            {
                Invoke(new MethodInvoker(delegate { visibleStartGameButton(); }));//מבצע קריאה נוספת אל לא מבחוץ
                return;
            }
            BTstartGame.Visible = true;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            
            if (TurnFlag)
            {
                if (keyData == Keys.Up)// if the user try to move up
                { Pac1.dir = "pacUp"; }
                if (keyData == Keys.Down)// if the user try to move down
                { Pac1.dir = "pacDown"; }
                if (keyData == Keys.Right)// if the user try to move right
                { Pac1.dir = "pacRight"; }

                if (keyData == Keys.Left)// if the user try to move left
                { Pac1.dir = "pacLeft"; }
                string UserInfo = "game;PacDirection;" + Pac1.dir + ";" + _roomName;

                SendInformationToServer(UserInfo);
            }
            return base.ProcessDialogKey(keyData);
        }
        */
        private void writeToChat(RichTextBox RTB, string v1, string v2)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { writeToChat(RTB, v1, v2); }));
                return;
            }
            RTB.AppendText(v1 + " : " + v2 + "\n");
        }

        private int FindChar(string[] messageInfo)
        {
            int index = 0;
            bool flag = false;
            while (index < messageInfo.Length && flag == false)
            {
                if (messageInfo[index].Equals("#"))
                    flag = true;
                else index++;
            }
            return index;
        }

        

        private void BTcreate_Click(object sender, EventArgs e)
        {
            string UserInfo = "room;create;" + TBroomName.Text.ToString() + ";" + _userName ;
            TBroomName.Text = "";
            SendInformationToServer(UserInfo);

        }
        private void SendInformationToServer(string userInfo)
        //Sends infromation to the server
        //Recievs info and message the client accordinally
        {
            if (_clientSocket.Connected)
            {
                // 1 convert the form informatino to byte array
                byte[] userData = Encoding.Unicode.GetBytes(userInfo);
                // send data to the server as byte array
                _clientSocket.Send(userData);
            }
        }
        
        private void BTjoin_Click(object sender, EventArgs e)
        {
            if (_roomName == "")
            {
                if (LBroomList.SelectedIndex == -1)
                    MessageBox.Show("you mast select one of rooms in the list");
                else
                {
                    _roomName = LBroomList.SelectedItem.ToString();
                    string[] checkOwner = _roomName.Split('-');
                    if (!checkOwner[0].Equals(_userName))
                    {
                        string[] getroom = _roomName.Split('>');
                        _roomName = getroom[1];
                        SendInformationToServer("room;join;" + _userName + ";" + _roomName);
                    }
                    else
                    {
                        MessageBox.Show("you can't join the room you are the owner");
                    }

                }
            }
            else
            {
                MessageBox.Show("you can join only to one room");
            }
        }

        

        

        private void BTsendChatGlobal_Click(object sender, EventArgs e)
        {
            string userInfo = "chat;Global;" + _userName + ";" + TBglobalChat.Text;
            SendInformationToServer(userInfo);
            TBglobalChat.Text = "";
        }
        
        private void BTsendChatRoom_Click(object sender, EventArgs e)
        {
            string userInfo = "chat;Room;" + _userName + ";" + TBroomChat.Text + ";" + _roomName;
            SendInformationToServer(userInfo);
            TBroomChat.Text = "";
        }
    }
}



