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
    public partial class duzenle : Form
    {
        public duzenle()
        {
            //# Hcakkuzu 8.10.2014 - .Net 4.5
            InitializeComponent();
        }
        int soruid = 0;
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False");
        //veritabanı bağlantısı
        public void duzenle_Load(object sender, EventArgs e)
        {
            derslistele();
           soruid = sorulistele.glbdegiskenler.soruid; // listeden seçilen soru
           try
           {
               connect.Open();
               string readdata = "SELECT * FROM Sorular INNER JOIN dersler ON dersler.dersID=sorular.dersID WHERE sID=" + soruid + ""; 
               OleDbCommand cmd = new OleDbCommand(readdata, connect);
               OleDbDataReader reader = cmd.ExecuteReader();
               reader.Read();
               //duzenlenecek sorunun bilgilerinin listelenmesi
               stext.Text = reader.GetValue(1).ToString();
               c1.Text = reader.GetValue(2).ToString(); 
               c2.Text = reader.GetValue(3).ToString();
               c3.Text = reader.GetValue(4).ToString();
               c4.Text = reader.GetValue(5).ToString();
               c5.Text = reader.GetValue(6).ToString();
               switch (reader.GetValue(7).ToString())
               {
                   case "c1": dogrucevap.Text = "A"; break;
                   case "c2": dogrucevap.Text = "B"; break;
                   case "c3": dogrucevap.Text = "C"; break;
                   case "c4": dogrucevap.Text = "D"; break;
                   case "c5": dogrucevap.Text = "E"; break;
               }
               ders.Text = reader.GetValue(10).ToString();
               connect.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
               connect.Close();
           }

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
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (stext.Text == "" || c1.Text == "" || c2.Text == "" || c3.Text == "" || c4.Text == "" || dogrucevap.Text == "") MessageBox.Show("Lütfen Tüm Kutuları Doldurun..");
                else
                { 
                    try
                    {
                        // soru duzenleme işlemi
                        connect.Open();
                        string dogru_cevap = "";
                        switch(dogrucevap.Text)
                        {
                            case "A": dogru_cevap = "c1"; break;
                            case "B": dogru_cevap = "c2"; break;
                            case "C": dogru_cevap = "c3"; break;
                            case "D": dogru_cevap = "c4"; break;
                            case "E": dogru_cevap = "c5"; break;
                        }
                        string update = "UPDATE sorular SET sText='" + stext.Text.Replace("'", "''") + "',c1='" + c1.Text.Replace("'", "''") + "',c2='" + c2.Text.Replace("'", "''") + "',c3='" + c3.Text.Replace("'", "''") + "',c4='" + c4.Text.Replace("'", "''") + "',c5='" + c5.Text.Replace("'", "''") + "',dogru_cevap='" + dogru_cevap + "',dersID='" + dersid.Items[ders.SelectedIndex].ToString() + "' WHERE sID=" + soruid + "";
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


    }
}
