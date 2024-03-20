using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public class Personel : Person
    {
        PersonelTürü PersonelTürü { get; set; }
        int ücreti { get; set; }

        public Personel(string ad, string soyad, PersonelTürü personelTürü, int ücreti)
        {
            this.ad = ad;
            this.soyad = soyad;
            PersonelTürü = personelTürü;
            this.ücreti = ücreti;
        }
    }
    public enum PersonelTürü
    {
        AraçKullanan,
        HizmetVeren
    }
}
