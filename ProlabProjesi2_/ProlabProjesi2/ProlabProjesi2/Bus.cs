using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    internal class Bus : Vehicle
    {

        public Bus(int id,int koltukSayısı)
        {
            rotaId = id;
            aracinTürü = AracTür.Otobüs;
            SetRoute(rotaId);
            SetSeatCount(koltukSayısı);
        }
        public Bus()
        {
            aracinTürü = AracTür.Otobüs;
            SetRoute(rotaId);

        }
        public Bus(int koltukSayısı)
        {
            aracinTürü = AracTür.Otobüs;
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

