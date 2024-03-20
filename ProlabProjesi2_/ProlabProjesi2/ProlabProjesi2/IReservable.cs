using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public interface IReservable
    {
        Koltuk[] koltuk { get; set; }
        Customer RezervasyonYap(Koltuk koltuk);
    }
}
