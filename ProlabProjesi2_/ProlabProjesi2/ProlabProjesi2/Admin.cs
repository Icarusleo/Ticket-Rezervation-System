using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    internal class Admin : User
    {
        public Admin(string getUserName , string getPassword)
        {
            SetLogInInformations(getUserName, getPassword); 
        }
        public override void SetLogInInformations(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
