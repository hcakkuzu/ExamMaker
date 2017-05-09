using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ExamMaker
{
    public partial class anaekran : Form
    {
//# Hcakkuzu 13.10.2014 - .Net 4.5
        public anaekran()
        {
            InitializeComponent();
        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False");

        private void yenisoruBtn_Click(object sender, EventArgs e)
        {
            yenisoru yenisoru = new yenisoru();
            yenisoru.ShowDialog();

        }

        private void listeleBtn_Click(object sender, EventArgs e)
        {
            sorulistele sorulistele = new sorulistele();
            sorulistele.ShowDialog();
        }

        private void sinavBtn_Click(object sender, EventArgs e)
        {
            if (derslistesi.Text == "" || derslistesi.Text == "Seçiniz...") MessageBox.Show("Ders seçmediniz.");
            else
            { 
            sorulistele.glbdegiskenler.secilen_ders_id = Convert.ToInt32(dersid.Items[derslistesi.SelectedIndex].ToString());
            sinav sinav = new sinav();
            sinav.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Bu Yazılım 'Halil Çağrı Akkuzu' Tarafından Yazılmıştır. Bir Hata Yada Bir Sorunda ''hcakkuzu0@gmail.com'' Adresi İle İletişime Geçebilirsiniz.");
        }

        private void dersler_Click(object sender, EventArgs e)
        {
            dersler ders = new dersler();
            ders.ShowDialog();
        }

        private void anaekran_Load(object sender, EventArgs e)
        {
            derslistele();
        }

        public void derslistele()
        {
            derslistesi.Items.Clear();
            dersid.Items.Clear();
            try
            {
                connect.Open();
                string readdata = "Select * FROM dersler";
                OleDbCommand cmd = new OleDbCommand(readdata, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dersid.Items.Add(reader.GetValue(0));
                    derslistesi.Items.Add(reader.GetValue(1));
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                connect.Close();
            }
        }

        private void anaekran_Enter(object sender, EventArgs e)
        {
            derslistele();
        }

        private void anaekran_MouseDown(object sender, MouseEventArgs e)
        {
            derslistele();
        }

        private void derslistesi_MouseDown(object sender, MouseEventArgs e)
        {
            derslistele();
        }

     
    }
}
