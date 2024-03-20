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
    public partial class FirmaGiris : Form
    {
        public List<Firma> firmaListesi = new List<Firma>();
        public GirişPaneli panel;
        public FirmaGiris(List<Firma> firmaListesi,GirişPaneli panel)
        {
            InitializeComponent();
            this.firmaListesi = firmaListesi;
            this.panel = panel;
        }

        private void FirmaGiris_Load(object sender, EventArgs e)
        {
            sifre.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Firma girisYapilanFirma = firmaListesi.Where(x => x.userName == kullaniciAdi.Text && x.password == sifre.Text).FirstOrDefault();
            
            if (girisYapilanFirma != null)
            {
                MessageBox.Show("Giriş Başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FirmaPaneli firmaPanel = new FirmaPaneli(girisYapilanFirma,panel);
                this.Hide();
                firmaPanel.Show();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
