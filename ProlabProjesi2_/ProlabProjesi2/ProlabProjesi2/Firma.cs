using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public class Firma : User , IProfitable
    {
        public int kar { get; set; }
        public int gelir { get; set; }
        public int maliyet { get; set; }
        public string FirmaAdi { get; set; }
        public int AracSayi { get; set; }
        public List<Vehicle> araclar = new List<Vehicle>();
        public List<Trip> seferler = new List<Trip>();
        public int hizmetBedeli;
        Random rnd = new Random();

        public override void SetLogInInformations(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        public int KarHesapla()
        {
            kar = gelir - maliyet;
            return kar;
        }
        public Firma(string _username, string _password, string firmaAd,int hizmetBedeli)
        {
            SetLogInInformations(_username, _password);
            FirmaAdi = firmaAd;
            this.hizmetBedeli = hizmetBedeli;
        }
        public Firma(string _username, string _password,string firmaAd,int aracSayi,Vehicle[] aractur,YakıtTürü? yakit, int[] yakitÜcret) 
        {
            userName = _username;
            password = _password;   
            FirmaAdi = firmaAd;
            AracSayi = aracSayi;
            hizmetBedeli = 1000;
            foreach (var araç in aractur)
            {
                AracOlustur(araç, araç.aracinTürü, yakit, yakitÜcret);
            }
            int aracIndex=0;
            RoadType yolTur = new RoadType();
            int i;
            int baslamaVakti = rnd.Next(4, 11);

            for (i = 0; i < aractur[aracIndex].rota.Length; i++) // kombinasyonhn kadr donsun
            {
                if (aractur[aracIndex].aracinTürü == AracTür.Uçak)
                    yolTur = RoadType.Havayolu;
                else if (aractur[aracIndex].aracinTürü == AracTür.Otobüs)
                    yolTur = RoadType.Karayolu;
                else if (aractur[aracIndex].aracinTürü == AracTür.Tren)
                    yolTur = RoadType.Demiryolu;

                DefaultRoutes.taşımaTürü = yolTur;
                
                for (int j = i+1; j < aractur[aracIndex].rota.Length; j++)    // İSTİSNA ŞEHİRLERİ İFLE BREAK'E AT -- 
                {
                    if ((i != aractur[aracIndex].rota.Length / 2) && (j == (aractur[aracIndex].rota.Length + 1) / 2))
                        break;
                    if (aractur[aracIndex].rota[i] == aractur[aracIndex].rota[j])
                        continue;
                    if(DefaultRoutes.IgnoreRoutes(aractur[aracIndex].rota[i], aractur[aracIndex].rota[j],yolTur))
                        continue;
                    // GİRİSPANELİNDEN AL KARAYOLU HAVAYOLUNU SONRA BİTTİ                     // BURAYI AYARLA SONRA BITTI
                    Route rota = new Route(aractur[aracIndex].rota[i], aractur[aracIndex].rota[j], yolTur , aractur[aracIndex].rotaId);
                    aractur[aracIndex].SetRoute(aractur[aracIndex].rotaId);
                    Trip sefer = new Trip(this,aractur[aracIndex], rota,yolTur, aractur[aracIndex].rotaId , new DateTime(2023, 12, baslamaVakti)); // BURAYI AYARLA
                    sefer.yoltür = yolTur;
                    seferler.Add(sefer); 
                }
                if ((i + 1 == aractur[aracIndex].rota.Length) && (aractur.Length > aracIndex + 1))
                {
                    i = -1;
                    aracIndex++;
                    baslamaVakti = rnd.Next(4, 11);
                }
                else
                {

                    continue;
                }
            }
        }
        public void AracOlustur(Vehicle arac,AracTür tür,YakıtTürü? yakitTür, int[] yakitÜcret) // Default firmalar icin
        {
            if (tür == AracTür.Tren)
            {
                arac.yakıt = YakıtTürü.Elektrik;
                arac.kmÜcreti = yakitÜcret[0];
            }
            else if (tür == AracTür.Otobüs)
            {
                if (yakitTür == YakıtTürü.Motorin)
                {
                    arac.kmÜcreti = yakitÜcret[1];
                    arac.yakıt = YakıtTürü.Motorin;
                }
                else if (yakitTür == YakıtTürü.Benzin)
                {
                    arac.kmÜcreti = yakitÜcret[2];
                    arac.yakıt = YakıtTürü.Benzin;
                }

            }
            else if (tür == AracTür.Uçak)
            {
                arac.kmÜcreti = yakitÜcret[3];
                arac.yakıt = YakıtTürü.Gaz;
            }

            arac.SetRoute(arac.rotaId);
            PersonelOlustur(arac,arac.AracKullananUcret,arac.HizmetliUcret);
            araclar.Add(arac);
            
        }
        public void PersonelOlustur(Vehicle arac,int ArackullananUcret, int HizmetliUcret)
        {
            for (int i = 0; i < 2; i++)
            {
                Personel aracKullanan = new Personel("arac" + i , "kullanan" + i, PersonelTürü.AraçKullanan, ArackullananUcret);
                arac.personelList.Add(aracKullanan);
            }
            for (int i = 0; i < 2; i++)
            {
                Personel hizmetVeren = new Personel("hizmet" + i, "veren" + i, PersonelTürü.HizmetVeren, HizmetliUcret);
                arac.personelList.Add(hizmetVeren);
            }
        }
        public void AracOlustur(Vehicle Arac) => araclar.Add(Arac);
        // firma panelinden kayıtt edilenler için
    }
}
