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
    public partial class yenisoru : Form
    {
        public yenisoru()
        {
            //# Hcakkuzu 8.10.2014 - .Net 4.5
            InitializeComponent();
        }
        string sorumetni = "";
        string dc = "";
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False");

        private void button1_Click(object sender, EventArgs e)
        {
            sorumetni=sText.Text.Replace("'","''").ToString(); //metni değişkene aktarma
            if (sText.Text == "" || c1.Text == "" || c2.Text == "" || c3.Text == "" || c4.Text == "" || c5.Text == "" || dogrucevap.Text == "" || ders.Text == "") MessageBox.Show("Lütfen Tüm Kutuları Doldurun..");
            else
            {
                try
                {
                    //bilgi ekleme
                    connect.Open();
                    switch (dogrucevap.Text)
                    {
                        case "A": dc = "c1"; break;
                        case "B": dc = "c2"; break;
                        case "C": dc = "c3"; break;
                        case "D": dc = "c4"; break;
                        case "E": dc = "c5"; break;
                    }
                    string add = "INSERT INTO Sorular([sText],[c1],[c2],[c3],[c4],[c5],[dogru_cevap],[dersID]) VALUES('" + sorumetni + "','" + c1.Text.Replace("'", "''") + "','" + c2.Text.Replace("'", "''") + "','" + c3.Text.Replace("'", "''") + "','" + c4.Text.Replace("'", "''") + "','" + c5.Text.Replace("'", "''") + "','" + dc + "','" + dersid.Items[ders.SelectedIndex].ToString() +"') ";
                    OleDbCommand cmd = new OleDbCommand(add, connect);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Soru Başarıyla eklendi!");
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                    connect.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //temizleme işlemi
            sText.Text = "";
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
            c4.Text = "";
            c5.Text = "";
            dogrucevap.Text = "";
            ders.Text = "";
        }

        public void derslistele()
        {
            try
            {
                connect.Open();
                string readdata = "Select * FROM dersler";
                OleDbCommand cmd = new OleDbCommand(readdata, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dersid.Items.Add(reader.GetValue(0));
                    ders.Items.Add(reader.GetValue(1));
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                connect.Close();
            }
        }

        private void yenisoru_Load(object sender, EventArgs e)
        {
            derslistele();
        }

    }
}
