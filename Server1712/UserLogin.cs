using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Server1712
{
    public class UserLogin
    {
        public string _username { get; set; }//שם משתמש
        public Socket _ClientSocket { get; set; }//החיבור לשרת
        
        public UserLogin()//בנאי ברירת מחדל
        {
            this._username = string.Empty;
            this._ClientSocket= new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp) ;
        }
        public UserLogin(string Name , Socket x)//בונה מעתיקה
        {
            _username = Name;
            _ClientSocket = x;
           
        }

    }
}
