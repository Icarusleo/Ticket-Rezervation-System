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
    public partial class SatışPanel : Form
    {
        public Customer müşteri;
        public Transport theTransport;
        public SatışPanel()
        {
            InitializeComponent();
        }
        public SatışPanel(Customer müşteri,Transport theTransport)
        {
            this.müşteri = müşteri;
            this.theTransport = theTransport;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long sayi;
            if (textBox3.Text.Length != 11 || long.TryParse(textBox3.Text, out sayi) != true)
            {
                MessageBox.Show("T.C. Kimlik No 11 Haneli Bir Sayı Olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            müşteri.SetInfos(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value);

            MessageBox.Show("Ödemeniz tamamlandı. Bilgi paneline aktarılıyorsunuz. İyi günler dileriz.","Başarılı İşlem",MessageBoxButtons.OK,MessageBoxIcon.Information);
            BilgiPaneli panel = new BilgiPaneli(theTransport,müşteri);
            panel.Show();
            this.Hide();
        }

        private void SatışPanel_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
