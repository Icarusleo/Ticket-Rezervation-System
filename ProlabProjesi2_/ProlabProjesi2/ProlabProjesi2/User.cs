using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public abstract class User : ILoginable
    {
        public string userName { get; set; }
        public string password { get; set; }

        public virtual void SetLogInInformations(string userName,string password)
        {
            this.userName = userName;
            this.password = password;   
        }
    }
}
