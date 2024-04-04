using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImAIdiot.Models
{
    [Serializable]
    public class PasswordInformation 
    {
        public String username { get; set; }
        public String websiteName {  get; set; }
        public String password {  get; set; }
        public String email { get; set; }

        public PasswordInformation(){}

        public PasswordInformation(string username, string websiteName, string password, string email)
        {
            this.username = username;
            this.websiteName = websiteName;
            this.password = password;
            this.email = email;
        }

        public override string ToString()
        {
            return username + ';' + websiteName + ';' + password + ';' + email + ';' ;
        }
    }
}
