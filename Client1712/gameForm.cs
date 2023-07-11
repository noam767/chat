using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client1712
{
    public partial class gameForm : Form
    {
        string userName;
        Socket _clientSocket;
        string result;
        Button BTWaitClient = new Button();
       
        Label LBClientStatus;
        int xBall, yBall, xHand, yHand;
        int counter = 0; int val = 1;
        PictureBox Hand = new PictureBox(), Ball = new PictureBox();
        int ShowNum;
        Thread gameThread;

        public gameForm(Socket s, string userName)
        {
            InitializeComponent();
            _clientSocket = s;
            this.userName = userName;
            darwButton();
        }
        private void darwButton()
        {
            LBClientStatus = new Label();
            LBClientStatus.Location = new Point(50, 330);
            LBClientStatus.Text = "waiting";
            this.Controls.Add(LBClientStatus);
            LBClientStatus.Size = new Size(100, 60);
            //"Waiting to start" button

            //show
            //BTShow.Location = new Point(400, 265);
            //BTShow.Text = "show num";
            //BTShow.Size = new Size(88, 25);
            //BTShow.Click += BTShow_Click;
            //this.Controls.Add(BTShow);

            BTWaitClient.Location = new Point(400, 450);
            BTWaitClient.Text = "start";
            BTWaitClient.Size = new Size(50, 25);
            BTWaitClient.Click += BTWaitClient_Click;
            this.Controls.Add(BTWaitClient);
            int tryconnect = 0;
        }
        private void drawClientBoard()
        {

            xBall = 500; yBall = 0; xHand = 500; yHand = 600;
            Hand.Location = new Point(xHand, yHand);
            Hand.Image = Image.FromFile(@"pics/hand.jfif");

            Hand.SizeMode = PictureBoxSizeMode.Zoom;
            Ball.SizeMode = PictureBoxSizeMode.Zoom;
            Ball.Location = new Point(xBall, yBall);
            Ball.Image = Image.FromFile(@"pics/ball.jfif");





            this.Controls.Add(Hand);
            this.Controls.Add(Ball);

        }
        private void ConnectToServer()
        {
            int tryconnect = 0;
            while (!_clientSocket.Connected && tryconnect < 10)
            {
                try
                {
                    _clientSocket.Connect(IPAddress.Loopback, 50000);
                    LBClientStatus.Text = "Connected";
                }
                catch (SocketException) // שגיאה שמקבלים כאשר לא מתלברים לשרת
                {
                    LBClientStatus.Text = "Not connected" + tryconnect;
                    tryconnect++;
                }
            }
            if (_clientSocket.Connected)
            {

                SendInformationToServer("Show;");
            }

        }
        private void BTWaitClient_Click(object sender, EventArgs e)
        {
            gameThread = new Thread(WaitForRecive);
            gameThread.Start();
            this.Height = 700;
            ConnectToServer();
            SendInformationToServer("UserNum;");
            //איך אני בקוד מחליט אצל מי הכדור עוצר או ממשיך
        }

        public void WaitForRecive()
        {

            while (_clientSocket.Connected)
            {
                string P = string.Empty;

                P = RecieveInformationFromServer();
                string[] ClientInfo = P.Split(';');


                if (ClientInfo[0].Equals("draw"))
                {
                    showTurn();
                }
                if (ClientInfo[0].Equals("UserNum"))
                {

                    showUserPlay(ClientInfo[1]);
                }




            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SendInformationToServer("start;");
        }

        private string RecieveInformationFromServer()
        {
            try
            { //1. preper byte array to get all the bytes from the servr
                byte[] reciveBuffer = new byte[1024];

                //2. recive the data from the server in to the byte array and return the size of bytes how recive 
                int rec = _clientSocket.Receive(reciveBuffer);

                //3. preper byte array with the size of bytes how recive from the servr
                byte[] data = new byte[rec];

                //4. copy the byte array who recived in to the byte array with the correct size
                Array.Copy(reciveBuffer, data, rec);
                //5. convert the byte array to Ascii
                result = Encoding.Unicode.GetString(data);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("The connection to the server is not good");
                return "error";
            }
        }
        private void SendInformationToServer(string UserInfo)
        {
            if (_clientSocket.Connected)
            {
                //convert the form's info to byte array
                byte[] UserData = Encoding.Unicode.GetBytes(UserInfo);
                //Send data to the server as byte array
                _clientSocket.Send(UserData);
            }
        }

        private void showTurn()
        {
            if (InvokeRequired)//אם יש קראיה מפונקצה חיצונית אז 
            {
                Invoke(new MethodInvoker(delegate { showTurn(); }));//מבצע קריאה נוספת אל לא מבחוץ
                return;
            }

            drawClientBoard();
        }

        private void showUserPlay(string v)
        {
            if (InvokeRequired)//אם יש קראיה מפונקצה חיצונית אז 
            {
                Invoke(new MethodInvoker(delegate { showUserPlay(v); }));//מבצע קריאה נוספת אל לא מבחוץ
                return;
            }

            LBClientStatus.Text = v;
        }
    }
}
