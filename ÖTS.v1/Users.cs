using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖTS.v1
{
    public class Users
    {
        public string UserFName;
        public string UserLName;
        public string Username;
        public string Password;

        // Ana programdan gelen parametrelere göre Class'daki değişgenleri doldurma.
        public Users(string pUserFName, string pUserLName, string pUsername, string pPassword)
        {
            UserFName=pUserFName;
            UserLName=pUserLName;
            Username = pUsername;
            Password = pPassword;
        }
    }
}
