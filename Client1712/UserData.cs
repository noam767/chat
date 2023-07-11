using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server1712
{
    public class UserData
    {
        public string lname { get; set; }
        public string Email { get; set; }
        public string pname { get; set; }
        public string password { get; set; }
        public string userName { get; set; }
        public string conPass { get; set; }

        public UserData()
        { }

        public UserData(string pname, string lname, string pass, string Email, string user, string conpass)
        {
            this.lname = lname; this.pname = pname; this.Email = Email;
            this.userName = user; this.password = pass; this.conPass = conpass;
        }
    }
}
