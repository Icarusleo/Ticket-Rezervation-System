using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public class Trip
    {
        public Vehicle araç;
        public Route güzergah;
        public DateTime gün;
        public int fiyat;
        public int rotaId;
        public int boşKoltuk;
        public int doluKoltuk;
        public List<Koltuk> tümKoltuklar = new List<Koltuk>();
        public Firma firma;
        public RoadType yoltür;
        public Trip(Firma firma,Vehicle araç,Route güzergah,RoadType yolTürü,int rotaId,DateTime gün)
        {
            this.firma = firma;
            this.araç = araç;
            this.güzergah = güzergah;
            this.gün = gün;
            this.yoltür = yolTürü;
            this.rotaId = rotaId;
            DefaultRoutes.CalcDistance(güzergah.kalkış, güzergah.varış);
            fiyat = DefaultRoutes.yolcuÜcret;
            SetSeatCount(araç, araç.koltukSayi);
        }
        public Trip()
        {
            
        }

        static Random rnd2 = new Random();
        public void SetSeatCount(Vehicle araç,int koltukSayısı)
        {
            for (int i = 0; i < araç.tümKoltuklar.Count; i++)
            {
                Koltuk koltuk = new Koltuk();
                koltuk.koltukId = i;
                tümKoltuklar.Add(koltuk);
            }
            for (int i = 0; i < araç.tümKoltuklar.Count; i++)
            {
                tümKoltuklar[i].bosMu = rnd2.Next(0, 2) % 2 == 0 ? true : false;

                if (tümKoltuklar[i].bosMu)
                    boşKoltuk++;
                else
                    doluKoltuk++;
            }
        }
    }
}
