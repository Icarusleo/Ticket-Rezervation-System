using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public class Customer
    {
        public Passenger yolcu { get; set; }
        public Koltuk yolcuKoltuk { get; set; }

        public Customer()
        {
            
        }
        public Customer(string ad,string soyad,string tcNo,DateTime dogumTarih)
        {
            SetInfos(ad, soyad,  tcNo, dogumTarih);
        }
        public void SetInfos(string ad, string soyad, string tcNo, DateTime dogumTarih)
        {
            yolcu.ad = ad;
            yolcu.soyad = soyad;
            yolcu.tcNo = tcNo;
            yolcu.dogumTarih = dogumTarih;
        }
    }
}
