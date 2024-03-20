using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProlabProjesi2
{
    public partial class FirmaPaneli : Form
    {
        private string AracTürü;
        public Firma theFirma;
        public GirişPaneli girişPaneli;
        public FirmaPaneli()
        {
            InitializeComponent();
        }
        public FirmaPaneli(Firma gelenFirma,GirişPaneli panel)
        {
            girişPaneli = panel;
            theFirma = gelenFirma;
            InitializeComponent();
        }
        private void LoadDatasGridView1(bool remove)
        {
            if (dataGridView1.Rows.Count == 1 && !remove)
            {
                if (theFirma.araclar.Count == 1)
                {
                    dataGridView1.Rows.Add(theFirma.araclar.Count);   // Firma listesi 1 olduğunda 1 tane fazladan boş row atmasın diye böyle uğraştık
                    UpdateVehicles();
                    return;
                }
                dataGridView1.Rows.Add(theFirma.araclar.Count - 1);
            }
            else if (dataGridView1.Rows.Count != 1 && !remove)
                dataGridView1.Rows.Add(1);
            else if ((dataGridView1.CurrentRow.Index == 0) && remove)
            {
                if (dataGridView1.Rows.Count == 1)
                {
                    dataGridView1.Rows.Clear();
                    return;
                }
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

            }
            else if (remove)
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index - 1);

            UpdateVehicles();
        }
        private void LoadDatasGridView2(bool remove)
        {
            if (dataGridView2.Rows.Count == 1 && !remove)
            {
                if (theFirma.seferler.Count == 1)
                {
                    dataGridView2.Rows.Add(theFirma.seferler.Count);   // Firma listesi 1 olduğunda 1 tane fazladan boş row atmasın diye böyle uğraştık
                    UpdateTrips();
                    return;
                }
                dataGridView2.Rows.Add(theFirma.seferler.Count - 1);
            }
            else if (dataGridView2.Rows.Count != 1 && !remove)
                dataGridView2.Rows.Add(1);
            else if ((dataGridView2.CurrentRow.Index == 0) && remove)
            {
                if (dataGridView2.Rows.Count == 1)
                {
                    dataGridView2.Rows.Clear();
                    return;
                }
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);

            }
            else if (remove)
                dataGridView1.Rows.RemoveAt(dataGridView2.CurrentRow.Index - 1);

            UpdateTrips();
        }
        private void FirmaPaneli_Load(object sender, EventArgs e)
        {
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadVehicles();
            LoadTrips();

            dateTimePicker1.MinDate = new DateTime(2023, 12, 4);
            dateTimePicker1.MaxDate = new DateTime(2023, 12, 10);

            UpdateComboboxes();
        }
        private void UpdateComboboxes()
        {
            comboBox5.Items.Clear();
            foreach (Vehicle arac in theFirma.araclar)
                if (!comboBox5.Items.Contains(arac.aracinTürü.ToString())) comboBox5.Items.Add(arac.aracinTürü.ToString());
        }
        private void LoadTrips()
        {
            for (int i = 0; i < theFirma.seferler.Count; i++)
            {
                dataGridView2.Rows.Add();
            }
            UpdateTrips();
        }
        private void LoadVehicles()
        {
            for (int i = 0; i < theFirma.araclar.Count; i++)
            {
                dataGridView1.Rows.Add();
            }
            UpdateVehicles();
        }
        private void UpdateTrips()
        {
            for (int i = 0; i < theFirma.seferler.Count; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = theFirma.seferler[i].araç.aracAd.ToString();
                dataGridView2.Rows[i].Cells[1].Value = theFirma.seferler[i].fiyat.ToString();
                dataGridView2.Rows[i].Cells[2].Value = theFirma.seferler[i].güzergah.kalkış.ToString();
                dataGridView2.Rows[i].Cells[3].Value = theFirma.seferler[i].güzergah.varış.ToString();
                dataGridView2.Rows[i].Cells[4].Value = theFirma.seferler[i].gün.ToString();
                dataGridView2.Rows[i].Cells[5].Value = theFirma.seferler[i].rotaId.ToString();
                dataGridView2.Rows[i].Cells[6].Value = theFirma.seferler[i].yoltür.ToString();

            }
        }
        private void UpdateVehicles()
        {
            for (int i = 0; i < theFirma.araclar.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = theFirma.araclar[i].aracId.ToString();
                dataGridView1.Rows[i].Cells[1].Value = theFirma.araclar[i].aracinTürü.ToString();
                dataGridView1.Rows[i].Cells[2].Value = theFirma.araclar[i].aracAd.ToString();
                dataGridView1.Rows[i].Cells[3].Value = theFirma.araclar[i].yakıt.ToString();
                dataGridView1.Rows[i].Cells[4].Value = theFirma.araclar[i].koltukSayi.ToString();
                dataGridView1.Rows[i].Cells[5].Value = theFirma.araclar[i].kmÜcreti.ToString();
                dataGridView1.Rows[i].Cells[6].Value = theFirma.araclar[i].AracKullananUcret.ToString();
                dataGridView1.Rows[i].Cells[7].Value = theFirma.araclar[i].HizmetliUcret.ToString();

            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            int sayi;
            if(comboBox1.Text == "")
                MessageBox.Show("Lütfen Yakıt Türü Seçiniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            if (textBox2.Text == "")
                MessageBox.Show("Lütfen Araç Adı Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (textBox1.Text == "")
                MessageBox.Show("Lütfen Kapasite Belirleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
           /* if (Convert.ToInt32(textBox3.Text) <= 0)
            {
                MessageBox.Show("Lütfen Geçerli Bir Değer Giriniz.","Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            foreach (Vehicle arac in theFirma.araclar)
            {
                if (arac.aracAd == textBox2.Text || arac.aracId == Convert.ToInt32(textBox4.Text))
                {
                    MessageBox.Show("Zaten var olan bir araç girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (AracTürü == "Uçak")
            {
                Airplane newUcak = new Airplane(Convert.ToInt32(textBox1.Text));
                newUcak.yakıt = YakıtTürü.Gaz;
                newUcak.aracAd = textBox2.Text;
                newUcak.koltukSayi = Convert.ToInt32(textBox1.Text);
                newUcak.kmÜcreti = Convert.ToInt32(textBox3.Text);
                newUcak.aracId = Convert.ToInt32(textBox4.Text);
                newUcak.AracKullananUcret = Convert.ToInt32(textBox5.Text);
                newUcak.HizmetliUcret = Convert.ToInt32(textBox6.Text);
                PersonelEkle(newUcak);
                theFirma.AracOlustur(newUcak);
            }
            else if (AracTürü == "Otobüs")
            {
                Bus newBus = new Bus(Convert.ToInt32(textBox1.Text));
                newBus.aracAd = textBox2.Text;
                newBus.koltukSayi = Convert.ToInt32(textBox1.Text);
                newBus.aracId = Convert.ToInt32(textBox4.Text);
                newBus.AracKullananUcret = Convert.ToInt32(textBox5.Text);
                newBus.HizmetliUcret = Convert.ToInt32(textBox6.Text);
                if (comboBox1.Text == "Motorin")
                {
                    newBus.kmÜcreti = Convert.ToInt32(textBox3.Text);
                    newBus.yakıt = YakıtTürü.Motorin;
                }
                else if (comboBox1.Text == "Benzin")
                {
                    newBus.kmÜcreti = Convert.ToInt32(textBox3.Text);
                    newBus.yakıt = YakıtTürü.Benzin;
                }
                PersonelEkle(newBus);
                theFirma.AracOlustur(newBus);
            }
            else if (AracTürü == "Tren")
            {
                Train newTrain = new Train(Convert.ToInt32(textBox1.Text));
                newTrain.yakıt = YakıtTürü.Elektrik;
                newTrain.aracAd = textBox2.Text;
                newTrain.koltukSayi = Convert.ToInt32(textBox1.Text);
                newTrain.kmÜcreti = Convert.ToInt32(textBox3.Text);
                newTrain.aracId = Convert.ToInt32(textBox4.Text);
                newTrain.AracKullananUcret = Convert.ToInt32(textBox5.Text);
                newTrain.HizmetliUcret = Convert.ToInt32(textBox6.Text);
                PersonelEkle(newTrain);
                theFirma.AracOlustur(newTrain);
            }

            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            UpdateComboboxes();

            LoadDatasGridView1(false);
            
        }
        public void PersonelEkle(Vehicle araç)
        {
            for (int i = 0; i < 2; i++)
            {
                Personel personel = new Personel("Arac" + i, "Kullanan" + i, PersonelTürü.AraçKullanan, Convert.ToInt32(textBox5.Text));
                araç.personelList.Add(personel);
            }
            for (int i = 0; i < 2; i++)
            {
                Personel personel = new Personel("Hizmet" + i, "Veren" + i, PersonelTürü.HizmetVeren, Convert.ToInt32(textBox6.Text));
                araç.personelList.Add(personel);
            }
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            AracTürü = comboBox2.Text;

            comboBox1.Items.Clear();

            if (AracTürü == "Uçak")
            {
                comboBox1.Items.Add("Gaz");
            }
            else if (AracTürü == "Otobüs")
            {
                comboBox1.Items.Add("Motorin");
                comboBox1.Items.Add("Benzin");
            }
            else if (AracTürü == "Tren")
            {
                comboBox1.Items.Add("Elektrik");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vehicle aracSil = theFirma.araclar.Where(x => x.aracAd == textBox2.Text).FirstOrDefault();

            if (aracSil == null)
            {
                MessageBox.Show("Aradığınız araç bulunamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            foreach (Trip trip in theFirma.seferler)
            {
                if (trip.araç.aracAd == aracSil.aracAd)
                {
                    MessageBox.Show("Lütfen ilk önce araca ait seferleri siliniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            theFirma.araclar.Remove(aracSil);

            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();

            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";

            LoadDatasGridView1(true);
            UpdateComboboxes();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }
        public string SelectedVehicle;
        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            SelectedVehicle = comboBox3.Text;
            comboBox4.Items.Clear();
            if (comboBox5.Text == "Otobüs")
            {
                comboBox4.Items.Add("3");
                comboBox4.Items.Add("4");
            }
            else if (comboBox5.Text == "Tren")
            {
                comboBox4.Items.Add("1");
                comboBox4.Items.Add("2");
            }
            else if (comboBox5.Text == "Uçak")
            {
                comboBox4.Items.Add("5");
                comboBox4.Items.Add("6");
            }

            comboBox4.Text = comboBox4.Items[0].ToString();

        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            comboBox5_TextChanged();
        }
        private void comboBox5_TextChanged()
        {
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();

            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            foreach (Vehicle araçlar in theFirma.araclar)
            {
                if (comboBox5.Text == "Otobüs" && araçlar.aracinTürü == AracTür.Otobüs)
                {
                    comboBox3.Items.Add(araçlar.aracAd);
                }
                else if (comboBox5.Text == "Tren" && araçlar.aracinTürü == AracTür.Tren)
                {
                    comboBox3.Items.Add(araçlar.aracAd);
                }
                else if (comboBox5.Text == "Uçak" && araçlar.aracinTürü == AracTür.Uçak)
                {
                    comboBox3.Items.Add(araçlar.aracAd);
                }
            }
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();

            Vehicle araç = GetCar();
            if (araç == null)
                return;
            araç.rotaId = Convert.ToInt32(comboBox4.Text);
            araç.SetRoute(araç.rotaId);

            if (araç.rota == null)
                return;
            GetRoutes(araç,0,false);
            comboBox6.Text = "";
            comboBox7.Text = "";
        }

        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            Vehicle araç = GetCar();
            int index = 0;
            if (araç == null || araç.rota == null)
            {
                comboBox7.Items.Clear();
                return;
            }

            for (int i = 0; i < araç.rota.Length; i++)
            {
                if (comboBox6.Text == araç.rota[i].ToString())
                {
                    index = i;
                    break;
                }
            }
            comboBox7.Items.Clear();
            GetRoutes2(araç, index,true);
        }
        public void GetRoutes2(Vehicle araç, int index, bool letPrintDestinationPoints)
        {
            int i = index;
            RoadType yolTur = new RoadType();

                if (araç.aracinTürü == AracTür.Uçak)
                    yolTur = RoadType.Havayolu;
                else if (araç.aracinTürü == AracTür.Otobüs)
                    yolTur = RoadType.Karayolu;
                else if (araç.aracinTürü == AracTür.Tren)
                    yolTur = RoadType.Demiryolu;

                if (!comboBox6.Items.Contains(araç.rota[i].ToString()))
                    comboBox6.Items.Add(araç.rota[i].ToString());

                for (int j = i + 1; j < araç.rota.Length; j++)    // İSTİSNA ŞEHİRLERİ İFLE BREAK'E AT -- 
                {
                    if ((i != araç.rota.Length / 2) && (j == (araç.rota.Length + 1) / 2))
                        continue;
                    if (araç.rota[i] == araç.rota[j])
                        continue;

                    if (DefaultRoutes.IgnoreRoutes(araç.rota[i], araç.rota[j], yolTur))
                        continue;

                    if (letPrintDestinationPoints)
                        if (!comboBox7.Items.Contains(araç.rota[j].ToString()))
                            comboBox7.Items.Add(araç.rota[j].ToString());

                    // GİRİSPANELİNDEN AL KARAYOLU HAVAYOLUNU SONRA BİTTİ                     // BURAYI AYARLA SONRA BITTI.

                }
            
        }
        public void GetRoutes(Vehicle araç,int index,bool letPrintDestinationPoints)
        {
            int i = index;
            RoadType yolTur = new RoadType();

            for (; i < araç.rota.Length; i++) // kombinasyonhn kadr donsun
            {
                if (araç.aracinTürü == AracTür.Uçak)
                    yolTur = RoadType.Havayolu;
                else if (araç.aracinTürü == AracTür.Otobüs)
                    yolTur = RoadType.Karayolu;
                else if (araç.aracinTürü == AracTür.Tren)
                    yolTur = RoadType.Demiryolu;

                if (!comboBox6.Items.Contains(araç.rota[i].ToString()))
                    comboBox6.Items.Add(araç.rota[i].ToString());

                for (int j = i + 1; j < araç.rota.Length; j++)    // İSTİSNA ŞEHİRLERİ İFLE BREAK'E AT -- 
                {
                    if ((i != araç.rota.Length / 2) && (j == (araç.rota.Length + 1) / 2))
                        break;
                    if (araç.rota[i] == araç.rota[j])
                        continue;

                    if (DefaultRoutes.IgnoreRoutes(araç.rota[i], araç.rota[j], yolTur))
                        continue;

                    if(letPrintDestinationPoints)
                    if (!comboBox7.Items.Contains(araç.rota[j].ToString()))
                        comboBox7.Items.Add(araç.rota[j].ToString());

                    // GİRİSPANELİNDEN AL KARAYOLU HAVAYOLUNU SONRA BİTTİ                     // BURAYI AYARLA SONRA BITTI.

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var sefer in theFirma.seferler)
            {
                if ((sefer.araç.aracAd == comboBox3.Text) &&
                   (sefer.rotaId == Convert.ToInt32(comboBox4.Text)) &&
                   (sefer.güzergah.kalkış.ToString() == comboBox6.Text) &&
                   (sefer.güzergah.varış.ToString() == comboBox7.Text) &&
                   (sefer.gün.Day == dateTimePicker1.Value.Day))
                {
                    MessageBox.Show("Eklenilmek istenen sefer halihazırda bulunmakta.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (comboBox5.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox6.Text == "" || comboBox7.Text == "")
            {
                MessageBox.Show("Lütfen tüm bilgileri eksiksiz giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            Vehicle araç = GetCar();

            RoadType yolTur = new RoadType();
            if (araç.aracinTürü == AracTür.Uçak)
                yolTur = RoadType.Havayolu;
            else if (araç.aracinTürü == AracTür.Otobüs)
                yolTur = RoadType.Karayolu;
            else if (araç.aracinTürü == AracTür.Tren)
                yolTur = RoadType.Demiryolu;

            DefaultRoutes.taşımaTürü = yolTur;

            Şehirler kalkış = new Şehirler();
            Şehirler varış = new Şehirler();
            for (int i = 0; i < araç.rota.Length; i++)
            {
                if (comboBox6.Text == araç.rota[i].ToString())
                {
                    kalkış = araç.rota[i];
                }
                if (comboBox7.Text == araç.rota[i].ToString())
                {
                    varış = araç.rota[i];
                }
            }
            Route yeniRota = new Route(kalkış,varış,yolTur,araç.rotaId);
            Trip yeniSefer = new Trip(theFirma,araç,yeniRota,yolTur,araç.rotaId,dateTimePicker1.Value);
            theFirma.seferler.Add(yeniSefer);

            LoadDatasGridView2(false);

        }

        Trip deleteTrip;

        private void button5_Click(object sender, EventArgs e)
        {

            foreach (var sefer in theFirma.seferler)
            {
                if((sefer.araç.aracAd == comboBox3.Text)                &&
                   (sefer.rotaId == Convert.ToInt32(comboBox4.Text))    &&
                   (sefer.güzergah.kalkış.ToString() == comboBox6.Text) &&
                   (sefer.güzergah.varış.ToString() == comboBox7.Text)  &&
                   (sefer.gün.Day == dateTimePicker1.Value.Day))
                {
                    deleteTrip = sefer;
                }
            }
            if (!theFirma.seferler.Contains(deleteTrip))
            {
                MessageBox.Show("Aranan sefer bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            theFirma.seferler.Remove(deleteTrip);

            LoadDatasGridView2(true);
        }
        private Vehicle GetCar()
        {
            return theFirma.araclar.Where(x => x.aracAd == SelectedVehicle).FirstOrDefault();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            girişPaneli.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            for(int i=0;i<theFirma.seferler.Count;i++)
            {
                theFirma.gelir += theFirma.seferler[i].fiyat*theFirma.seferler[i].doluKoltuk;
                theFirma.maliyet += (theFirma.seferler[i].araç.HizmetliUcret * 2 + theFirma.seferler[i].araç.AracKullananUcret * 2) +
                    theFirma.seferler[i].araç.kmÜcreti * theFirma.seferler[i].güzergah.mesafe;
            }
            
            theFirma.maliyet += theFirma.hizmetBedeli;

            theFirma.kar = theFirma.gelir - theFirma.maliyet;

            label15.Text = "Günlük kâr-zarar = " + theFirma.kar;
            label18.Text = "Günlük maaliyet = " + theFirma.maliyet;
            label20.Text = "Günlük gelir = " + theFirma.gelir;

            theFirma.gelir = 0;
            theFirma.maliyet = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int sayi;
            if (!int.TryParse(textBox3.Text, out sayi))
            {
                MessageBox.Show("Lütfen bir sayı giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox3.Text = ""; // veya istediğiniz bir işlem
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int sayi;
            if (!int.TryParse(textBox1.Text, out sayi))
            {
                MessageBox.Show("Lütfen bir sayı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = ""; // veya istediğiniz bir işlem
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int sayi;
            if (!int.TryParse(textBox4.Text, out sayi))
            {
                MessageBox.Show("Lütfen bir sayı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = ""; // veya istediğiniz bir işlem
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int sayi;
            if (!int.TryParse(textBox5.Text, out sayi))
            {
                MessageBox.Show("Lütfen bir sayı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Text = ""; // veya istediğiniz bir işlem
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int sayi;
            if (!int.TryParse(textBox6.Text, out sayi))
            {
                MessageBox.Show("Lütfen bir sayı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Text = ""; // veya istediğiniz bir işlem
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
