using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProlabProjesi2
{
    static class DefaultRoutes
    {
        public static Şehirler[] Route1 =
        { Şehirler.İstanbul,Şehirler.Kocaeli,Şehirler.Bilecik,Şehirler.Eskişehir,Şehirler.Ankara,
            Şehirler.Eskişehir,Şehirler.Bilecik,Şehirler.Kocaeli,Şehirler.İstanbul};

        public static RoadType Route1RoadType = RoadType.Demiryolu;

        public static Şehirler[] Route2 =
        { Şehirler.İstanbul,Şehirler.Kocaeli,Şehirler.Bilecik,Şehirler.Eskişehir,Şehirler.Konya,
            Şehirler.Eskişehir,Şehirler.Bilecik,Şehirler.Kocaeli,Şehirler.İstanbul};
        public static RoadType Route2RoadType = RoadType.Demiryolu;

        public static Şehirler[] Route3 =
        { Şehirler.İstanbul,Şehirler.Kocaeli,Şehirler.Ankara,Şehirler.Kocaeli,Şehirler.İstanbul};
        public static RoadType Route3RoadType = RoadType.Karayolu;


        public static Şehirler[] Route4 =
        { Şehirler.İstanbul,Şehirler.Kocaeli,Şehirler.Eskişehir,Şehirler.Konya,
        Şehirler.Eskişehir,Şehirler.Kocaeli,Şehirler.İstanbul};
        public static RoadType Route4RoadType = RoadType.Karayolu;

        public static Şehirler[] Route5 =
        { Şehirler.İstanbul,Şehirler.Konya,Şehirler.İstanbul};
        public static RoadType Route5RoadType = RoadType.Havayolu;

        public static Şehirler[] Route6 =
        { Şehirler.İstanbul,Şehirler.Ankara,Şehirler.İstanbul};
        public static RoadType Route6RoadType = RoadType.Havayolu;

        public static Şehirler[] tümŞehirler =
            {Şehirler.İstanbul,Şehirler.Kocaeli,Şehirler.Ankara,Şehirler.Bilecik,Şehirler.Konya,Şehirler.Eskişehir};

        public static int mesafe { get; set; }
        public static int yolcuÜcret { get; set; }
        public static RoadType taşımaTürü;
        public static void CalcDistance(Şehirler k, Şehirler v)
        {
            if (taşımaTürü == RoadType.Karayolu)
            {
                if ((k == Şehirler.İstanbul && v == Şehirler.Kocaeli) || (k == Şehirler.Kocaeli && v == Şehirler.İstanbul))
                {
                    mesafe = 100;
                    yolcuÜcret = 50;
                }
                else if ((k == Şehirler.İstanbul && v == Şehirler.Ankara) || (k == Şehirler.Ankara && v == Şehirler.İstanbul))
                {
                    mesafe = 500;
                    yolcuÜcret = 300;
                }
                else if ((k == Şehirler.İstanbul && v == Şehirler.Eskişehir) || (k == Şehirler.Eskişehir && v == Şehirler.İstanbul))
                {
                    mesafe = 300;
                    yolcuÜcret = 150;
                }
                else if ((k == Şehirler.İstanbul && v == Şehirler.Konya) || (k == Şehirler.Konya && v == Şehirler.İstanbul))
                {
                    mesafe = 600;
                    yolcuÜcret = 300;
                }
                else if ((k == Şehirler.Kocaeli && v == Şehirler.Ankara) || (k == Şehirler.Ankara && v == Şehirler.Kocaeli))
                {
                    mesafe = 400;
                    yolcuÜcret = 400;
                }
                else if ((k == Şehirler.Kocaeli && v == Şehirler.Eskişehir) || (k == Şehirler.Eskişehir && v == Şehirler.Kocaeli))
                {
                    mesafe = 200;
                    yolcuÜcret = 100;
                }
                else if ((k == Şehirler.Kocaeli && v == Şehirler.Konya) || (k == Şehirler.Konya && v == Şehirler.Kocaeli))
                {
                    mesafe = 500;
                    yolcuÜcret = 250;
                }
                else if ((k == Şehirler.Konya && v == Şehirler.Eskişehir) || (k == Şehirler.Eskişehir && v == Şehirler.Konya))
                {
                    mesafe = 300;
                    yolcuÜcret = 150;
                }

            }
            else if (taşımaTürü == RoadType.Demiryolu)
            {
                if ((k == Şehirler.İstanbul && v == Şehirler.Kocaeli) || (k == Şehirler.Kocaeli && v == Şehirler.İstanbul))
                {
                    mesafe = 75;
                    yolcuÜcret = 50;
                }
                else if ((k == Şehirler.İstanbul && v == Şehirler.Ankara) || (k == Şehirler.Ankara && v == Şehirler.İstanbul))
                {
                    mesafe = 375;
                    yolcuÜcret = 250;
                }
                else if ((k == Şehirler.İstanbul && v == Şehirler.Eskişehir) || (k == Şehirler.Eskişehir && v == Şehirler.İstanbul))
                {
                    mesafe = 300;
                    yolcuÜcret = 200;
                }
                else if ((k == Şehirler.İstanbul && v == Şehirler.Konya) || (k == Şehirler.Konya && v == Şehirler.İstanbul))
                {
                    mesafe = 450;
                    yolcuÜcret = 300;
                }
                else if ((k == Şehirler.İstanbul && v == Şehirler.Bilecik) || (k == Şehirler.Bilecik && v == Şehirler.İstanbul))
                {
                    mesafe = 225;
                    yolcuÜcret = 150;
                }
                else if ((k == Şehirler.Kocaeli && v == Şehirler.Ankara) || (k == Şehirler.Ankara && v == Şehirler.Kocaeli))
                {
                    mesafe = 300;
                    yolcuÜcret = 200;
                }
                else if ((k == Şehirler.Kocaeli && v == Şehirler.Bilecik) || (k == Şehirler.Bilecik && v == Şehirler.Kocaeli))
                {
                    mesafe = 75;
                    yolcuÜcret = 50;
                }
                else if ((k == Şehirler.Kocaeli && v == Şehirler.Eskişehir) || (k == Şehirler.Eskişehir && v == Şehirler.Kocaeli))
                {
                    mesafe = 150;
                    yolcuÜcret = 100;
                }
                else if ((k == Şehirler.Kocaeli && v == Şehirler.Konya) || (k == Şehirler.Konya && v == Şehirler.Kocaeli))
                {
                    mesafe = 350;
                    yolcuÜcret = 250;
                }
                else if ((k == Şehirler.Konya && v == Şehirler.Eskişehir) || (k == Şehirler.Eskişehir && v == Şehirler.Konya))
                {
                    mesafe = 225;
                    yolcuÜcret = 150;
                }
                else if ((k == Şehirler.Bilecik && v == Şehirler.Ankara) || (k == Şehirler.Ankara && v == Şehirler.Bilecik))
                {
                    mesafe = 225;
                    yolcuÜcret = 150;
                }
                else if ((k == Şehirler.Bilecik && v == Şehirler.Eskişehir) || (k == Şehirler.Eskişehir && v == Şehirler.Bilecik))
                {
                    mesafe = 75;
                    yolcuÜcret = 50;
                }
                else if ((k == Şehirler.Bilecik && v == Şehirler.Konya) || (k == Şehirler.Konya && v == Şehirler.Bilecik))
                {
                    mesafe = 300;
                    yolcuÜcret = 200;
                }
                else if ((k == Şehirler.Eskişehir && v == Şehirler.Ankara) || (k == Şehirler.Ankara && v == Şehirler.Eskişehir))
                {
                    mesafe = 150;
                    yolcuÜcret = 100;
                }
            }
            else if (taşımaTürü == RoadType.Havayolu)
            {
                if ((k == Şehirler.İstanbul && v == Şehirler.Ankara) || (k == Şehirler.Ankara && v == Şehirler.İstanbul))
                {
                    mesafe = 375;
                    yolcuÜcret = 1000;
                }
                else if ((k == Şehirler.İstanbul && v == Şehirler.Konya) || (k == Şehirler.Konya && v == Şehirler.İstanbul))
                {
                    mesafe = 375;
                    yolcuÜcret = 1200;
                }
            }
        }
        public static bool IgnoreRoutes(Şehirler kalkış, Şehirler varış, RoadType yoltür)
        {
            if (yoltür == RoadType.Karayolu)
            {
                if ((varış == Şehirler.Ankara && kalkış == Şehirler.Konya) || (kalkış == Şehirler.Ankara && varış == Şehirler.Konya))
                    return true;
                else if ((varış == Şehirler.Ankara && kalkış == Şehirler.Eskişehir) || (kalkış == Şehirler.Eskişehir && varış == Şehirler.Ankara))
                    return true;
                else
                    return false;
            }
            else if (yoltür == RoadType.Demiryolu || yoltür == RoadType.Havayolu)
            {
                if ((varış == Şehirler.Ankara && kalkış == Şehirler.Konya) || (kalkış == Şehirler.Ankara && varış == Şehirler.Konya))
                    return true;
                else
                    return false;
            }
            return true;
        }
    }
    
    public enum RoadType
    {
        Demiryolu,
        Karayolu,
        Havayolu
    }
}
