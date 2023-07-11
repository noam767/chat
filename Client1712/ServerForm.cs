using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Serialization;
using System.IO;


namespace Server1712
{
    public partial class ServerForm : Form
    {
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static List<Socket> ClientListSockets = new List<Socket>();
        private static byte[] Buffer = new byte[1024];
        int userNumber;

        List<UserData> userList;
        XmlSerializer xm;
        public ServerForm()
        {
            InitializeComponent();
            userNumber = 0;
            StartServer();
                        userList = new List<UserData>();
            xm = new XmlSerializer(typeof(List<UserData>));
        }
        private void StartServer()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 50000));
            serverSocket.Listen(2);
            serverSocket.BeginAccept(new AsyncCallback(waitForNewConnection), serverSocket);
        }
        private void waitForNewConnection(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            ClientListSockets.Add(socket);
            userNumber++;
            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(RecieveInformation), socket);
            serverSocket.BeginAccept(new AsyncCallback(waitForNewConnection), serverSocket);
        }
        private void RecieveInformation(IAsyncResult AR)
        {
            string response = "";
            Socket socket = (Socket)AR.AsyncState;
            int recieve = socket.EndReceive(AR);
            byte[] dataBuff = new byte[recieve];
            Array.Copy(Buffer, dataBuff, recieve);
            string text = Encoding.ASCII.GetString(dataBuff);
            string[] ClientInformation = text.Split(';');
            if (ClientInformation[0].Equals("Login"))
            {
                ReaduserListFromXmlFile();
                bool flag = false;
                int index = 0;
                while (index<userList.Count && !flag)
                {
                    if (userList[index].userName.Equals(ClientInformation[1]) && userList[index].password.Equals(ClientInformation[2]))
                        flag = true;
                    index++;
                }
                if (flag)
                    response = "Login;ok";
                else
                    response = "Login;Error";
            }
            if (ClientInformation[0].Equals("Register"))
            {
                response = addUserToServerList(ClientInformation);
            }
            returnInformationToClient(socket, response);
        }
        private void returnInformationToClient(Socket socket,string response)
        {
            
            byte[] data = Encoding.Unicode.GetBytes(response);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(EndRecieveInformation), socket);
            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(RecieveInformation), socket);
        }

        private static void EndRecieveInformation(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        private string addUserToServerList(string[] clientInformaion)
        {
            FileStream fs;
            try
            {
                ReaduserListFromXmlFile();
            }
            catch (Exception)
            {
                // MessageBox.Show("קובץ  משתמשים לא קיים בונה קובץ חדש");
            }

            fs = new FileStream(@"data/users.xml", FileMode.Create, FileAccess.Write);  // create nwe xml file
            UserData info = new UserData(clientInformaion[1],
                                         clientInformaion[2],
                                         clientInformaion[3],
                                         clientInformaion[4],
                                         clientInformaion[5],
                                         clientInformaion[6]);
            userList.Add(info);
            xm.Serialize(fs, userList);
            fs.Close();
            return "Register;ok";
        }

        private void ReaduserListFromXmlFile()
        {
            FileStream fs = new FileStream(@"data/users.xml", FileMode.Open, FileAccess.Read);// read from xml file to user list
            userList = (List<UserData>)xm.Deserialize(fs);
            fs.Close();
        }
    }
}

