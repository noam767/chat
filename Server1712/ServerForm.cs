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
        //Connection defenition
        private static List<Socket> ClientListSockets = new List<Socket>();//List of connections
        private static byte[] Buffer = new byte[1024];//Byte array which contains data
        List<UserLogin> ClientLoginUsers= new List<UserLogin>();
        List<Room> GameRooms = new List<Room>();
        List<UserData> userList;
        XmlSerializer xm;//serializes ans deserializies into and from xml files
        public ServerForm()
        {
            InitializeComponent();
            StartServer();
           userList = new List<UserData>();
            xm = new XmlSerializer(typeof(List<UserData>));//Xml file type of build
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
            string text = Encoding.Unicode.GetString(dataBuff);
            string[] ClientInformation = text.Split(';');
            string command = ClientInformation[0];
            string option = ClientInformation[1];
            if (command.Equals("Login"))
            {
                ReaduserListFromXmlFile();
                bool flag = false;
                int index = 0;
                string userName = ClientInformation[1];
                string password = ClientInformation[2];
                while (index<userList.Count && flag==false)
                {
                    if (userList[index].userName.Equals(userName) && userList[index].password.Equals(password))
                        flag = true;
                    index++;
                }
                if (flag==true)
                { response = "Login;ok";//If the user is logged in
                    ClientLoginUsers.Add(new UserLogin(userName, socket));
                }

                else
                    response = "Login;Error";
            }
            if (command.Equals("Register"))
            {
                response = addUserToServerList(ClientInformation);
            }
            if (command.Equals("users"))
            {

                if (option.Equals("new"))
                {
                    string lastUser = ClientLoginUsers[ClientLoginUsers.Count - 1]._username;
                    response = "users;add;" + lastUser + ";";
                    byte[] temp = Encoding.Unicode.GetBytes(response);
                    for (int i = 0; i < ClientLoginUsers.Count; i++)
                    {
                        if (ClientLoginUsers[i]._ClientSocket != socket)
                            ClientLoginUsers[i]._ClientSocket.Send(temp);
                    }

                    response = "users;new";
                    for (int i = 0; i < ClientLoginUsers.Count; i++)
                    {
                        response += ";" + ClientLoginUsers[i]._username + ";";
                    }
                    response += ";#";
                    for(int k=0; k<GameRooms.Count; k++)
                    {
                        response += ";" + GameRooms[k]._RoomName + ";" + GameRooms[k]._Owner;
                    }

                }
                
            }
            if(command.Equals("room"))
            {
                
                if(option.Equals("create"))
                {
                    
                    bool roomExist = false;
                    int index = 0;
                    string R_Name = ClientInformation[2];
                    string userName = ClientInformation[3];
                    while (!roomExist && index < GameRooms.Count)
                    {
                        if (GameRooms[index]._RoomName.Equals(R_Name))
                            roomExist = true;
                        index++;
                    }
                    if (roomExist)
                    {
                        response = "room;exist";
                    }
                    else
                    {
                        Room TempRoom = new Room(R_Name,  userName, socket);
                        GameRooms.Add(TempRoom);
                        response = "room;add;" + userName + ";" +R_Name;
                        for (int i = 0; i < ClientLoginUsers.Count; i++)
                        {
                            if (ClientLoginUsers[i]._ClientSocket != socket)
                            {
                                byte[] data = Encoding.Unicode.GetBytes(response);
                                ClientLoginUsers[i]._ClientSocket.Send(data);
                            }
                        }
                    }
                }
                if(option.Equals("join"))
                {
                    string userName = ClientInformation[2];
                    int roomIndex = findRoom(ClientInformation[3]);
                    GameRooms[roomIndex].AddUser(userName, socket);
                    string RoomOwner = GameRooms[roomIndex]._Owner;
                    string RoomName = GameRooms[roomIndex]._RoomName;
                    response = "room;join;add;" + userName + ";0;" + RoomOwner + ";" + RoomName;
                    byte[] sendInfo = Encoding.Unicode.GetBytes(response);
                    for(int i=0; i<GameRooms[roomIndex]._RoomUsers.Count; i++)
                    {
                        if (GameRooms[roomIndex]._RoomUsers[i]._ClientSocket != socket)
                            GameRooms[roomIndex]._RoomUsers[i]._ClientSocket.Send(sendInfo);
                    }
                    response = "room;join;new";//לכולם
                    for (int i = 0; i < GameRooms[roomIndex]._RoomUsers.Count; i++)
                    {
                        response += ";" + GameRooms[roomIndex]._RoomUsers[i]._username + ";0";
                    }
                }
            }
            if(command.Equals("chat"))
            {
                string userName = ClientInformation[2];
                string txt = ClientInformation[3];
                if (option.Equals("Global"))
                {
                    
                    response = "chat;Global;" + userName + ";" + txt;
                    for (int i = 0; i < ClientLoginUsers.Count; i++)
                    {
                        if (ClientLoginUsers[i]._ClientSocket != socket)
                        {
                            byte[] data = Encoding.Unicode.GetBytes(response);
                            ClientLoginUsers[i]._ClientSocket.Send(data);
                        }
                    }//for
                }
                if (option.Equals("Room"))
                {
                    response = "chat;Room;" +userName + ";" +txt;
                    byte[] sendInfo = Encoding.Unicode.GetBytes(response);
                    string r_name = ClientInformation[4];
                    int roomIndex = findRoom(r_name);

                    for (int i = 0; i < GameRooms[roomIndex]._RoomUsers.Count; i++)
                    {
                        if (GameRooms[roomIndex]._RoomUsers[i]._ClientSocket != socket)
                            GameRooms[roomIndex]._RoomUsers[i]._ClientSocket.Send(sendInfo);
                    }
                }

            }
            /*if(command.Equals("game"))
            {//x2;d4;ddd;rrr
             //0;  1;  2; 3        //ddd
                if (option.Equals("intru"))
                {
                    string roomName = ClientInformation[2];
                    Room gameRoom = GameRooms[findRoom(roomName)];
                    response = "game;intru";
                    for(int i=0;i<gameRoom._RoomUsers.Count;i++)
                    {
                        if (socket != gameRoom._RoomUsers[i]._ClientSocket)
                        {
                            byte[] data1 = Encoding.Unicode.GetBytes(response);
                            gameRoom._RoomUsers[i]._ClientSocket.Send(data1);
                        }
                    }
                }
                if(option.Equals("PacDirection"))
                {
                    string direction = ClientInformation[2];
                    string RoomName = ClientInformation[3];
                    int roomIndex = findRoom(RoomName);
                    response = "game;PacDirection;" + direction;
                    byte[] sendInfo = Encoding.Unicode.GetBytes(response);
                    for (int i = 0; i < GameRooms[roomIndex]._RoomUsers.Count; i++)
                    {
                        if (GameRooms[roomIndex]._RoomUsers[i]._ClientSocket != socket)
                            GameRooms[roomIndex]._RoomUsers[i]._ClientSocket.Send(sendInfo);
                    }

                }
                if (option.Equals("Wall"))
                {
                    string direction = ClientInformation[2];
                    string RoomName = ClientInformation[3];
                    int roomIndex = findRoom(RoomName);
                    response = "game;Wall;" + direction;
                    byte[] sendInfo = Encoding.Unicode.GetBytes(response);
                    for (int i = 0; i < GameRooms[roomIndex]._RoomUsers.Count; i++)
                    {
                        if (GameRooms[roomIndex]._RoomUsers[i]._ClientSocket != socket)
                            GameRooms[roomIndex]._RoomUsers[i]._ClientSocket.Send(sendInfo);
                    }

                }
                if (option.Equals("port"))
                {
                    string UserName = ClientInformation[2];
                    string RoomName = ClientInformation[3];
                    int roomIndex = findRoom(RoomName);
                    response = "game;port;true";
                    byte[] sendInfo = Encoding.Unicode.GetBytes(response);
                    for (int i = 0; i < GameRooms[roomIndex]._RoomUsers.Count; i++)
                    {
                        if (GameRooms[roomIndex]._RoomUsers[i]._ClientSocket != socket)
                            GameRooms[roomIndex]._RoomUsers[i]._ClientSocket.Send(sendInfo);
                    }
                    response = "game;port;false";
                }
            }
                returnInformationToClient(socket, response);
            */
        }
        private int findRoom(string v)
        {
            int roomIndex = 0;
            bool flag = false;

            while (roomIndex < GameRooms.Count && !flag)
            {
                if (GameRooms[roomIndex]._RoomName.Equals(v))
                    flag = true;
                else
                    roomIndex++;
            }
            return roomIndex;
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
                
            }

            fs = new FileStream(@"data/users.xml", FileMode.Create, FileAccess.Write);  // create nwe xml file
            string pname = clientInformaion[1], lname = clientInformaion[2], Email = clientInformaion[3], user = clientInformaion[4], 
                pass = clientInformaion[5], conpass = clientInformaion[6];
            UserData info = new UserData(pname,
                                         lname,
                                         Email,
                                         user,
                                         pass,
                                         conpass);
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

