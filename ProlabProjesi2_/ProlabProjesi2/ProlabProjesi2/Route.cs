using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public class Route
    {
        public Şehirler kalkış;
        public Şehirler varış;
        public Şehirler[] Rota;
        public RoadType taşımaTürü;
        public int mesafe;
        public int yolcuÜcret;

        public Route()  // default 
        {
            
        }
        public Route (Şehirler kalkış, Şehirler varış, RoadType taşımaTürü,int rotaIndex)
        {
            this.kalkış = kalkış;
            this.varış = varış;
            this.taşımaTürü = taşımaTürü;

            DefaultRoutes.CalcDistance(kalkış, varış);
            mesafe = DefaultRoutes.mesafe;
            yolcuÜcret = DefaultRoutes.yolcuÜcret;
            SetRouteIndex(rotaIndex);
        }
        public void SetRouteIndex(int rotaIndex)
        {
            if (rotaIndex == 1)
                Rota = DefaultRoutes.Route1;
            if (rotaIndex == 2)
                Rota = DefaultRoutes.Route2;
            if (rotaIndex == 3)
                Rota = DefaultRoutes.Route3;
            if (rotaIndex == 4)
                Rota = DefaultRoutes.Route4;
            if (rotaIndex == 5)
                Rota = DefaultRoutes.Route5;
            if (rotaIndex == 6)
                Rota = DefaultRoutes.Route6;
        }
    }
}
