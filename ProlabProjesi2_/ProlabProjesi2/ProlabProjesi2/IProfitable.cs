using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public interface IProfitable
    {
        int kar { get; set; }
        int maliyet { get; set; }
        int gelir { get; set; }
    }
}
