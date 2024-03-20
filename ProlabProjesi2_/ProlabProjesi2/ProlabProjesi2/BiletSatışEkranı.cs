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
    public partial class BiletSatışEkranı : Form
    {
        Transport theTransport = new Transport();
        public int koltukSayısı = 0;
        private int secilmisKoltukSayısı = 0;
        private int alınacakKoltuk = 0;
        List<Koltuk> seçilmişKoltuklar = new List<Koltuk>();
        List<Firma> firmaList = new List<Firma>();
        public BiletSatışEkranı(List<Firma> firmaListesi,Transport taşıma,int alınacakKoltuk)
        {
            firmaList = firmaListesi;
            InitializeComponent();
            theTransport = taşıma;
            koltukSayısı = theTransport.seyahat.araç.koltukSayi;
            label1.Text = alınacakKoltuk.ToString();
            secilmisKoltukSayısı = alınacakKoltuk;
            this.alınacakKoltuk = alınacakKoltuk;
        }

        private void BiletSatışEkranı_Load(object sender, EventArgs e)
        {
            UploadDatas();
        }

        public void UploadDatas()
        {
            int index = 0;
            foreach (Koltuk koltuk in theTransport.seyahat.tümKoltuklar)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = theTransport.firma.FirmaAdi.ToString();
                dataGridView1.Rows[index].Cells[1].Value = theTransport.seyahat.araç.aracAd.ToString();
                if (koltuk.bosMu)
                {
                    dataGridView1.Rows[index].Cells[3].Value = "Boş";
                    dataGridView1.Rows[index].Cells[3].Style.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[index].Cells[3].Value = "Dolu";
                    dataGridView1.Rows[index].Cells[3].Style.BackColor = Color.Red;
                }
                dataGridView1.Rows[index].Cells[2].Value = koltuk.koltukId.ToString();
                index++;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Boş")
            {
                if (alınacakKoltuk == 0)
                    return;
                label1.Text = (--alınacakKoltuk).ToString();
                MessageBox.Show("Koltuk seçimleri başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);

                foreach (Firma firma in firmaList)
                {
                    for (int i = 0; i < firma.seferler.Count; i++)
                    {
                        if (firma.seferler[i] == theTransport.seyahat)
                        {
                            firma.seferler[i].tümKoltuklar[id].bosMu = false;
                            firma.seferler[i].boşKoltuk--;
                            firma.seferler[i].doluKoltuk++;
                        }
                    }
                }

                theTransport.seyahat.tümKoltuklar[id].bosMu = false;
                seçilmişKoltuklar.Add(theTransport.seyahat.tümKoltuklar[id]);

                dataGridView1.CurrentRow.Cells[3].Value = "Dolu";
                dataGridView1.CurrentRow.Cells[3].Style.BackColor = Color.Red;
                
            }
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Dolu")
            {
                MessageBox.Show("Lütfen boş bir koltuk seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (alınacakKoltuk == 0)
            {
                for (int i = 0; i < secilmisKoltukSayısı; i++)
                {
                    Customer müşteri = theTransport.RezervasyonYap(seçilmişKoltuklar[i]);
                    SatışPanel panel = new SatışPanel(müşteri, theTransport);
                    panel.Show();
                }
                return;
            }
        }
    }
}