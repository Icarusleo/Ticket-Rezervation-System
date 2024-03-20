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
    public partial class AdminPaneli : Form
    {
        public List<Firma> firmaList = new List<Firma>();
        public AdminPaneli(List<Firma> firmaList)
        {
            InitializeComponent();
            this.firmaList = firmaList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Firma yeniFirma = new Firma(textBox2.Text,textBox3.Text,textBox1.Text, Convert.ToInt32(textBox4.Text));
            foreach(Firma firma in firmaList)
            {
                if (firma.FirmaAdi == yeniFirma.FirmaAdi || firma.userName == yeniFirma.userName)
                {
                    MessageBox.Show("Zaten var olan bir firma girdiniz!","Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            firmaList.Add(yeniFirma);
            LoadDatas(false);
        }

        private void AdminPaneli_Load(object sender, EventArgs e)
        {
            LoadDatas(false);
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
        private void UpdateCompanies()
        {
            for (int i = 0; i < firmaList.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = firmaList[i].FirmaAdi.ToString();
                dataGridView1.Rows[i].Cells[1].Value = firmaList[i].userName.ToString();
                dataGridView1.Rows[i].Cells[2].Value = firmaList[i].password.ToString();
                dataGridView1.Rows[i].Cells[3].Value = firmaList[i].hizmetBedeli.ToString();
            }
        }
        private void LoadDatas(bool remove)
        {
            if (dataGridView1.Rows.Count == 1 && !remove)
            {
                if (firmaList.Count == 1)
                {
                    dataGridView1.Rows.Add(firmaList.Count);   // Firma listesi 1 olduğunda 1 tane fazladan boş row atmasın diye böyle uğraştık
                    UpdateCompanies();
                    return;
                }
                dataGridView1.Rows.Add(firmaList.Count - 1);
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

            UpdateCompanies();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            GirişPaneli girişpanel = new GirişPaneli(firmaList);
            girişpanel.Show();
            this.Hide();
        }

        private void sil_Click(object sender, EventArgs e)
        {
            Firma firmaSil = firmaList.Where(x => x.FirmaAdi == textBox1.Text).FirstOrDefault();

            if (firmaSil == null)
            {
                MessageBox.Show("Aradığınız firma bulunamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            firmaList.Remove(firmaSil);

            LoadDatas(true);

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
