using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Client1712
{
    public partial class login : Form
    {
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        
        
        
        public login()
        {
            InitializeComponent();
            ConnectToServer();
        }
        public bool IsCompleted(string st)
        {
            return st.Length > 0;
        }
        public bool all_nums(string st)
        {
            int count = 0;
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] >= '0' && st[i] <= '9')
                    count++;
            }
            return count == st.Length;
        }
        public bool all_ABC(string st)
        {
            int count = 0;
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] >= 'a' && st[i] <= 'z' || st[i] >= 'A' && st[i] <= 'Z')
                    count++;
            }
            return count == st.Length;
        }
   
      
       
        private void ConnectToServer()
        {
            if (!_clientSocket.Connected)
            {
                try
                {
                    _clientSocket.Connect(IPAddress.Loopback, 50000);
                   //_clientSocket.Connect(IPAddress.Parse("192.168.13.7"), 50000);

                }
                catch (SocketException)
                {
                    MessageBox.Show(":not connected.");
                }
                if (_clientSocket.Connected)
                {
                    MessageBox.Show(":connected to the server");
                }
            }
        }

    

        private void SendInformationToServer(string userInfo, string userName)
        {
            if (_clientSocket.Connected)
            {
                // 1 convert the form informatino to byte array
                byte[] userData = Encoding.Unicode.GetBytes(userInfo);
                // send data to the server as byte array
                _clientSocket.Send(userData);


                byte[] buffer = new byte[1024];
                int recieve = _clientSocket.Receive(buffer);
               
                byte[] dataBuff = new byte[recieve];
                Array.Copy(buffer, dataBuff, recieve);
                 string returnFormServer = Encoding.Unicode.GetString(dataBuff);

                string[] messageInfo = returnFormServer.Split(';');
                if (messageInfo[0].Equals("Login"))
                {
                    if (messageInfo[1].Equals("ok"))
                    {
                        MessageBox.Show("Welcome!");
                        textBoxUN.Text = string.Empty;
                        textBoxPass.Text = string.Empty;
                       clientForm x = new clientForm(_clientSocket, userName);
                        x.Show();
                        this.Visible = false;
                    }
                    if (messageInfo[1].Equals("Error"))
                    {
                        MessageBox.Show("Error! try again.");
                        textBoxUN.Text = string.Empty;
                        textBoxPass.Text = string.Empty;

                    }
                }
            }
        }

      

        private void BTLog_Click_1(object sender, EventArgs e)
        {
            
            LabeluN_E.Visible = (all_ABC(textBoxUN.Text)&& IsCompleted(textBoxUN.Text))== false;
            LabelPass_E.Visible = (all_nums(textBoxPass.Text) && IsCompleted(textBoxPass.Text))== false;
            
            if (LabelPass_E.Visible || LabeluN_E.Visible)
            {
                MessageBox.Show("error : please try again");
            }
            else
            {
                SendInformationToServer("Login;" + textBoxUN.Text + ";" + textBoxPass.Text,textBoxUN.Text);
             
                textBoxUN.Text = string.Empty;
                textBoxPass.Text = string.Empty;
            }

        }

        private void BTSignUp_Click(object sender, EventArgs e)
        {
            SignUp x = new SignUp(_clientSocket);
            x.Show();
        }

        
    }
}
