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

namespace ProlabProjesi2
{
    public partial class BilgiPaneli : Form
    {
        public Transport taşıma = new Transport();
        public Customer müsteri = new Customer();

        public BilgiPaneli(Transport taşıma,Customer müsteri)
        {
            this.müsteri = müsteri;
            this.taşıma = taşıma;
            InitializeComponent();
        }
        

        private void BilgiPaneli_Load(object sender, EventArgs e)
        {
            LoadDataGridView1Datas();
            LoadDataGridView2Datas();
        }
        private void LoadDataGridView1Datas()
        {
            for (int i = 0; i < taşıma.araç.koltukSayi; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = taşıma.koltuk[i].koltukId.ToString();

                if (taşıma.koltuk[i].bosMu)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "Boş";
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[1].Value = "Dolu";
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Red;
                }
            }
        }
        private void LoadDataGridView2Datas()
        {
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Cells[0].Value = müsteri.yolcu.ad.ToString();
            dataGridView2.Rows[0].Cells[1].Value = müsteri.yolcu.soyad.ToString();
            dataGridView2.Rows[0].Cells[2].Value = müsteri.yolcuKoltuk.koltukId.ToString();
        }
    }
}
