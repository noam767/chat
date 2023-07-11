using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server1712
{
    public class UserData
    {
        public string lname { get; set; }//שם משפחה
        public string Email { get; set; }//אי מייל
        public string pname { get; set; }//שם פרטי
        public string password { get; set; }//סיסמא
        public string userName { get; set; }//שם משתמש
        public string conPass { get; set; }//אישור סיסמא 

        public UserData()//בנאי ברירת מחדל
        { this.lname = string.Empty;
            this.Email = string.Empty; this.pname = string.Empty; this.password = string.Empty; this.userName = string.Empty;
            this.conPass = string.Empty;
        }

        public UserData(string pname, string lname, string Email, string user, string pass, string conpass)//בנאי העתקה
        {
            this.lname = lname; this.pname = pname; this.Email = Email;
            this.userName = user; this.password = pass; this.conPass = conpass;
        }
    }
}
