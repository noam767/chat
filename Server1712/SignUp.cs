using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client1712
{
    
    public partial class SignUp : Form
    {
        Socket _clientSocket;
        public SignUp(Socket sok)
        //constractor. Sets the given socket connection   
        {
            InitializeComponent(); 
            this._clientSocket = sok;
        }
        public bool all_nums(string st)
        //checks if the string contains only digits?
        {
            int count = 0;
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] >= '0' && st[i] <= '9')
                    count++;
            }
            return count == st.Length;
        }
        public bool IsCompleted(string st)
            //Checks if the given string isn't empty
        {
            return st.Length > 0;
        }
        public bool all_ABC(string st)
        //checks if the string contains only abc letters?
        {
            int count = 0;
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] >= 'a' && st[i] <= 'z' || st[i] >= 'A' && st[i] <= 'Z')
                    count++;
            }
            return count == st.Length ;
        }
        public bool isPassValid(string s, string a)
        //Checks if the passwords(given strings) are the same
        {
            return s.Equals(a);
        }
        public bool INCludeMailInfo(string st)
        //Checks if the Emails was written properly
        {
            int count1 = 0, count2 = 0;
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == '@')
                    count1++;
            }
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == '.')
                    count2++;
            }
            return count1 == 1 && (count2 == 1 || count2 == 2);
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

                byte[] buffer = new byte[1024];
               int rec = _clientSocket.Receive(buffer);
               string returnFormServer = Encoding.Unicode.GetString(buffer, 0, rec);
               string[] messageInfo = returnFormServer.Split(';');
               if (messageInfo[0].Equals("Register"))
               {
                  if(messageInfo[1].Equals("ok"))
                    {
                        MessageBox.Show("You're signed up!");
                        TBFirstName.Text = string.Empty;
                        TBName.Text = string.Empty;
                        TBEmail.Text = string.Empty;
                        TBPassword.Text = string.Empty;
                        TBUserName.Text = string.Empty;
                        TBConfirmPass.Text = string.Empty;
                        this.Visible = false;
                        this.Close();//after registeration, the window is closed.
                    }
               }

            }
            
        }

        private void btSignUp_Click(object sender, EventArgs e)
        {
            //Error check
            LBFirstname_E.Visible = (all_ABC(TBFirstName.Text)&& IsCompleted(TBFirstName.Text))== false;

            LBLastName_E.Visible = (all_ABC(TBName.Text) && IsCompleted(TBName.Text)) == false;

            LBEmail_E.Visible =  (INCludeMailInfo(TBEmail.Text) && IsCompleted(TBEmail.Text)) == false;

            LBUsername_E.Visible = (all_ABC(TBUserName.Text) && IsCompleted(TBUserName.Text)) == false;

            LBPassword_E.Visible = (all_nums(TBPassword.Text) && IsCompleted(TBPassword.Text)) == false;

            LbConfirmPass_E.Visible = (all_nums(TBConfirmPass.Text) && isPassValid(TBPassword.Text, TBConfirmPass.Text) && IsCompleted(TBConfirmPass.Text)) == false;

            if (LbConfirmPass_E.Visible || LBPassword_E.Visible || LBUsername_E.Visible || LBEmail_E.Visible || LBLastName_E.Visible || LBFirstname_E.Visible)
            {//If there is any mistake:
                MessageBox.Show("error : please try again");
            }
            else
            {
                SendInformationToServer("Register;" + TBFirstName.Text + ";" + TBName.Text + ";" + TBEmail.Text
                    + ";" + TBUserName.Text + ";" + TBPassword.Text + ";" + TBConfirmPass.Text);
                TBFirstName.Text = string.Empty;
                TBName.Text = string.Empty;

            }

        }

        private void BTReset_Click(object sender, EventArgs e)
        //Clears all the registeration fields
        {
            TBFirstName.Text = string.Empty;
            TBName.Text = string.Empty;
            TBEmail.Text = string.Empty;
            TBPassword.Text = string.Empty;
            TBUserName.Text = string.Empty;
            TBConfirmPass.Text = string.Empty;
        }
    }
    
}
