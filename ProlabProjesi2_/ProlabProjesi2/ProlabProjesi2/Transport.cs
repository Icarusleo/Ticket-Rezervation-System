using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public class Transport : IReservable
    {
        public Firma firma { get; set; }
        public Vehicle araç { get; set; }

        public Trip seyahat = new Trip();
        public Reservation rezervasyonBilgi { get; set; }
        public Koltuk[] koltuk { get; set; }
        public Customer RezervasyonYap(Koltuk koltuk)
        {
            Customer müşteri = new Customer();
            müşteri.yolcu = new Passenger();
            müşteri.yolcuKoltuk = koltuk;

            return müşteri;
        }
    }
}
