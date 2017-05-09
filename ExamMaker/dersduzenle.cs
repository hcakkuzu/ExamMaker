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
    public partial class dersduzenle : Form
    {
        public dersduzenle()
        {
            InitializeComponent();
        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False");
        //veritabanı bağlantısı
        private void duzenle_Click(object sender, EventArgs e)
        {
            if (dersno.Text == "" || ders_adi.Text == "") MessageBox.Show("Geçerli bir değer girin.");
            else
            {
                try
                {
                    // soru duzenleme işlemi
                    connect.Open();
                    string update = "UPDATE dersler SET ders='" + ders_adi.Text + "' WHERE dersID=" + dersno.Text.ToString() + "";
                    OleDbCommand cmd = new OleDbCommand(update, connect);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Güncellendi!");
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                    connect.Close();
                }
            }
        }

        private void dersduzenle_Load(object sender, EventArgs e)
        {
            int dersid = sorulistele.glbdegiskenler.dersid; // listeden seçilen soru
            try
            {
                connect.Open();
                string readdata = "SELECT * FROM dersler WHERE dersID=" + dersid + "";
                OleDbCommand cmd = new OleDbCommand(readdata, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                reader.Read();
                //duzenlenecek sorunun bilgilerinin listelenmesi
                dersno.Text = reader.GetValue(0).ToString();
                ders_adi.Text = reader.GetValue(1).ToString();
                
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                connect.Close();
            }
        }


    }
}
