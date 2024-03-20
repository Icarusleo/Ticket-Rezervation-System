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
    public partial class AdminGirisi : Form
    {
         
        Admin admin = new Admin("admin", "adminbaba123");
        List<Firma> firmas = new List<Firma>();
        public AdminGirisi(List<Firma> firmas)
        {
            InitializeComponent();
            this.firmas = firmas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kullaniciad.Text == admin.userName && sifre.Text == admin.password)
            {
                AdminPaneli panel = new AdminPaneli(firmas);
                this.Hide();
                panel.Show();
            }
            else
            {
                MessageBox.Show("HATALI GİRİŞ", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminGirisi_Load(object sender, EventArgs e)
        {

        }

        private void AdminGirisi_Load_1(object sender, EventArgs e)
        {
            sifre.PasswordChar = '*';
        }
    }
}
