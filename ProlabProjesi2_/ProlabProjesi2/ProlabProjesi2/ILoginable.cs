using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public interface ILoginable
    {
        string userName { get; set; }
        string password { get; set; }
    }
}
