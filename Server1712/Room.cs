using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Server1712
{
    public class Room
    {
        public string _RoomName { get; set; }//שם החדר
        public List<UserLogin> _RoomUsers { get; set; }//רשימת משתמשים בחדר
        public string _Owner { get; set; }//שם בעל החדר
        public Room(string roomName , string userName, Socket S)//בנאי
        {
            _RoomName = roomName;
            _RoomUsers = new List<UserLogin>();
            _RoomUsers.Add(new UserLogin(userName, S));
            _Owner = userName;
     
        }
        public void AddUser(string user_name , Socket s)//הוספת משתמש לרשימה
        {
            _RoomUsers.Add(new UserLogin(user_name, s));
        }
        public void RemoveUser(string userName)//מחיקת משתמש מהרשימה
        {
            bool fl = false;
            int index = 0;
            while(fl==false && index<_RoomUsers.Count)
            {
                if (_RoomUsers[index]._username.Equals(userName))
                    fl = true;
                else index++;
            }
            _RoomUsers.Remove(_RoomUsers[index]);
        }
    }
}
