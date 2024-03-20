using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public abstract class Vehicle
    {
        public AracTür aracinTürü = new AracTür();
        public YakıtTürü yakıt = new YakıtTürü();
        public int koltukSayi;
        public string aracAd;
        public int aracId;
        public int kmÜcreti;
        public int AracKullananUcret;
        public int HizmetliUcret;
        public Şehirler[] rota;
        public int rotaId;
        public List<Koltuk> tümKoltuklar = new List<Koltuk>();
        public List<Personel> personelList = new List<Personel>();
        public virtual int CalculateFuelCost(int yol,int benzinUcret)
        {
            return yol * benzinUcret;
        }
        public virtual void SetRoute(int rotaIndex)
        {
            if (rotaIndex == 1)
                rota = DefaultRoutes.Route1;
            if (rotaIndex == 2)
                rota = DefaultRoutes.Route2;
            if (rotaIndex == 3)
                rota = DefaultRoutes.Route3;
            if (rotaIndex == 4)
                rota = DefaultRoutes.Route4;
            if (rotaIndex == 5)
                rota = DefaultRoutes.Route5;
            if (rotaIndex == 6)
                rota = DefaultRoutes.Route6;
        }
        public virtual void SetSeatCount(int koltukSayısı)
        {
            koltukSayi = koltukSayısı;
            for (int i = 0; i < koltukSayi; i++)
            {
                Koltuk koltuk = new Koltuk();
                koltuk.koltukId = i;
                tümKoltuklar.Add(koltuk);
            }
        }
    }
}
