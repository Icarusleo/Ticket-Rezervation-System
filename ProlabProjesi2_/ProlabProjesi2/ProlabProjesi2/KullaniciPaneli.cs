using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProlabProjesi2
{
    public partial class KullaniciPaneli : Form
    {
        List<Firma> firmaListesi = new List<Firma>();
        public KullaniciPaneli(List<Firma> firmaListesi)
        {
            InitializeComponent();
            this.firmaListesi = firmaListesi;
        }

        private void KullaniciPaneli_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            dateTimePicker1.MinDate = new DateTime(2023, 12, 4);
            dateTimePicker1.MaxDate = new DateTime(2023, 12, 10);
            dateTimePicker2.MinDate = new DateTime(2023, 12, 4);
            dateTimePicker2.MaxDate = new DateTime(2023, 12, 10);

            GetRoutes(0,false);
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
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SetColumns();
        }
        private void SetColumns()
        {
            dataGridView2.Rows.Clear();

            int columnIndex = 0;
            for (int i = 0; i < firmaListesi.Count; i++)
            {
                for (int j = 0; j < firmaListesi[i].seferler.Count; j++)
                {

                    if (firmaListesi[i].seferler[j].gün.Day == dateTimePicker2.Value.Day)
                    {
                        dataGridView2.Rows.Add();

                        dataGridView2.Rows[columnIndex].Cells[0].Value = firmaListesi[i].FirmaAdi.ToString();
                        dataGridView2.Rows[columnIndex].Cells[1].Value = firmaListesi[i].seferler[j].araç.aracAd.ToString();
                        dataGridView2.Rows[columnIndex].Cells[2].Value = firmaListesi[i].seferler[j].gün.ToString();
                        columnIndex++;
                    }
                }
            }
        }
        public int FindIndex(Şehirler[] rota, string şehir)
        {
            for (int i = 0; i < rota.Length; i++)
            {
                if (rota[i].ToString() == şehir)
                    return i;
            }
            return -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int columnIndex = 0;

            dataGridView1.Rows.Clear();

            foreach (Firma firma in firmaListesi)
            {
                for (int i = 0; i < firma.seferler.Count; i++)
                {
                    try
                    {
                        if (firma.seferler[i].güzergah.kalkış.ToString() == comboBox1.Text &&
                            firma.seferler[i].güzergah.varış.ToString() == comboBox2.Text &&
                            firma.seferler[i].gün.Day == dateTimePicker1.Value.Day &&
                            firma.seferler[i].boşKoltuk >= Convert.ToInt32(textBox1.Text)
                           )
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[columnIndex].Cells[0].Value = firma.FirmaAdi.ToString();
                            dataGridView1.Rows[columnIndex].Cells[1].Value = firma.seferler[i].araç.aracAd.ToString();
                            dataGridView1.Rows[columnIndex].Cells[2].Value = firma.seferler[i].boşKoltuk.ToString();
                            dataGridView1.Rows[columnIndex].Cells[3].Value = firma.seferler[i].güzergah.kalkış.ToString();
                            dataGridView1.Rows[columnIndex].Cells[4].Value = firma.seferler[i].güzergah.varış.ToString();
                            dataGridView1.Rows[columnIndex].Cells[5].Value = firma.seferler[i].gün.ToString();
                            dataGridView1.Rows[columnIndex].Cells[6].Value = firma.seferler[i].fiyat.ToString();
                            columnIndex++;
                        }
                    }
                    catch (Exception c)
                    {
                        MessageBox.Show("Lütfen tüm bilgileri eksiksiz doldurunuz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void GetRoutes(int index, bool letPrintDestinationPoints)
        {
            int i = index;

            for (; i < DefaultRoutes.tümŞehirler.Length ; i++)
            {

                if (!comboBox1.Items.Contains(DefaultRoutes.tümŞehirler[i]))
                    comboBox1.Items.Add(DefaultRoutes.tümŞehirler[i].ToString());

                for (int j = i + 1; j < DefaultRoutes.tümŞehirler.Length; j++)    
                {
                    if (DefaultRoutes.tümŞehirler[i] == DefaultRoutes.tümŞehirler[j])
                        continue;



                    if (letPrintDestinationPoints)
                        if (!comboBox2.Items.Contains(DefaultRoutes.tümŞehirler[j].ToString()))
                            comboBox2.Items.Add(DefaultRoutes.tümŞehirler[j].ToString());
                }
            }
        }
        public void GetRoutes2(int index, bool letPrintDestinationPoints)
        {
                for (int j = 0; j < DefaultRoutes.tümŞehirler.Length; j++)    
                {
                    if (DefaultRoutes.tümŞehirler[index] == DefaultRoutes.tümŞehirler[j])
                        continue;
                    if (letPrintDestinationPoints)
                        if (!comboBox2.Items.Contains(DefaultRoutes.tümŞehirler[j].ToString()))
                            comboBox2.Items.Add(DefaultRoutes.tümŞehirler[j].ToString());
                }
        }
        Trip seçilenSefer;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Transport taşıma = new Transport();

            foreach (Firma firma in firmaListesi)
            {
                for (int i = 0; i < firma.seferler.Count; i++)
                {
                    try
                    {
                        if (firma.seferler[i].güzergah.kalkış.ToString() == dataGridView1.CurrentRow.Cells[3].Value.ToString() &&
                            firma.seferler[i].güzergah.varış.ToString() == dataGridView1.CurrentRow.Cells[4].Value.ToString() &&
                            firma.seferler[i].gün.Day == Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value).Day &&
                            firma.seferler[i].araç.aracAd == dataGridView1.CurrentRow.Cells[1].Value.ToString() &&
                            firma.seferler[i].boşKoltuk >= Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value)
                            )
                        {
                            seçilenSefer = firma.seferler[i];
                            taşıma.araç = firma.seferler[i].araç;
                            taşıma.koltuk = firma.seferler[i].tümKoltuklar.ToArray();
                            taşıma.firma = firma;
                            taşıma.seyahat = seçilenSefer;
                        }
                    }
                    catch (Exception f)
                    {
                        MessageBox.Show("Hatalı satır seçimi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (taşıma.araç == null)
            {
                MessageBox.Show("Rezervasyon yapmak istediğiniz seferin koltuklarında güncelleme yapılmıştır. Lütfen daha sonra tekrar deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                BiletSatışEkranı ekran = new BiletSatışEkranı(firmaListesi, taşıma, Convert.ToInt32(textBox1.Text));
                ekran.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GirişPaneli panel = new GirişPaneli(firmaListesi);
            panel.Show();
            this.Hide();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int index = 0;
            for (int i = 0; i < DefaultRoutes.tümŞehirler.Length; i++)
            {
                if (comboBox1.Text == DefaultRoutes.tümŞehirler[i].ToString())
                {
                    index = i;
                    break;
                }
            }
            comboBox2.Items.Clear();
            GetRoutes2(index, true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
