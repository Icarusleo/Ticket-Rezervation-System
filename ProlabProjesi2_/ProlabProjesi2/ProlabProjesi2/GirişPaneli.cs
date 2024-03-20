using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProlabProjesi2
{
    public partial class GirişPaneli : Form
    {
        public List<Firma> firmaListesi = new List<Firma>();
        bool letLoadDefaultData = true;
        public GirişPaneli(List<Firma> list)
        {
            letLoadDefaultData=false;
            firmaListesi = list;
            InitializeComponent();
        }
        public GirişPaneli()
        {
            InitializeComponent();
        }

        private void adminpanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminGirisi admingiris = new AdminGirisi(firmaListesi);
            admingiris.Show();
        }

        private void firmapanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            FirmaGiris firmagiris = new FirmaGiris(firmaListesi,this);
            firmagiris.Show();
        }

        private void kullanici_Click(object sender, EventArgs e)
        {
            this.Hide();
            KullaniciPaneli kullaniciPanel = new KullaniciPaneli(firmaListesi);
            kullaniciPanel.Show();
        }

        private void GirişPaneli_Load(object sender, EventArgs e)
        {
            if(letLoadDefaultData)
                LoadData();
        }
        public void LoadData()
        {
            Random rnd = new Random();

            Firma A = new Firma("a", "123", "A", 2, new Vehicle[] 
            { new Bus(3,20) { aracId = 0 ,aracAd = "Otobüs1",AracKullananUcret = 5000,HizmetliUcret = 2000 },
              new Bus(3,15) { aracId = 1,  aracAd = "Otobüs2",AracKullananUcret = 5000,HizmetliUcret = 2000}},
              YakıtTürü.Benzin, new int[] {0,0,10,0});
            Firma B = new Firma("b", "123", "B", 2, new Vehicle[] { 
                new Bus(3,15) { aracId = 0, aracAd = "Otobüs3",AracKullananUcret = 3000,HizmetliUcret = 1500 }, 
                new Bus(4,20) { aracId = 1, aracAd = "Otobüs4" ,AracKullananUcret = 3000,HizmetliUcret = 1500}}, 
                YakıtTürü.Motorin, new int[] { 0, 5, 0, 0 });
            Firma C = new Firma("c", "123", "C", 3, new Vehicle[] { 
                new Bus(4, 20) { aracId = 0,koltukSayi = 20, aracAd = "Otobüs5" ,AracKullananUcret = 4000,HizmetliUcret = 2000}, 
                new Airplane(5, 30) { aracId = 1, aracAd = "Ucak1",AracKullananUcret = 10000,HizmetliUcret = 6000}, 
                new Airplane(5, 30) { aracId = 2, aracAd = "Ucak2" ,AracKullananUcret = 10000,HizmetliUcret = 6000}}, 
                YakıtTürü.Motorin, new int[] { 0, 6, 0, 25 });
            Firma D = new Firma("d", "123", "D", 3, new Vehicle[] { 
                new Train(1,25) { aracId = 0, aracAd = "Tren1" ,AracKullananUcret = 2000,HizmetliUcret = 1000}, 
                new Train(2,25) { aracId = 1, aracAd = "Tren2" ,AracKullananUcret = 2000,HizmetliUcret = 1000}, 
                new Train(2,25) {aracId =  2, aracAd = "Tren3" ,AracKullananUcret = 2000,HizmetliUcret = 1000}}, 
                null, new int[] { 3, 0, 0, 0 });
            Firma F = new Firma("f", "123", "F", 2, new Vehicle[] { 
                new Airplane(6,30) {aracId = 0,aracAd = "Ucak3" ,AracKullananUcret = 7500,HizmetliUcret = 4000}, 
                new Airplane(6,30) {aracId = 1,aracAd = "Ucak4" ,AracKullananUcret = 7500,HizmetliUcret = 4000}}, 
                null, new int[] { 0, 0, 0, 20 });

            firmaListesi.Add(A);
            firmaListesi.Add(B);
            firmaListesi.Add(C);
            firmaListesi.Add(D);
            firmaListesi.Add(F);
        }
    }
}
