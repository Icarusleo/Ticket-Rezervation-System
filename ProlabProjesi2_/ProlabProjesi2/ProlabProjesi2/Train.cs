using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    internal class Train : Vehicle
    {
        Random rnd = new Random();
        Random rnd2 = new Random();
        public Train(int id, int koltukSayısı)
        {
            rotaId = id;
            aracinTürü = AracTür.Tren;
            SetRoute(rotaId);
            SetSeatCount(koltukSayısı);
        }
        public Train()
        {
            aracinTürü = AracTür.Tren;
            SetRoute(rotaId);
        }
        public Train(int koltukSayısı)
        {
            aracinTürü = AracTür.Tren;
            SetRoute(rotaId);
            SetSeatCount(koltukSayısı); 
        }
        public override void SetSeatCount(int koltukSayısı)
        {
            koltukSayi = koltukSayısı;
            for (int i = 0; i < koltukSayi; i++)
            {
                Koltuk koltuk = new Koltuk();
                koltuk.koltukId = i;
                tümKoltuklar.Add(koltuk);
            }
        }
        public override void SetRoute(int rotaIndex)
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
    }
}
