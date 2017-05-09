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
    public partial class incele : Form
    {
        public incele()
        {
            InitializeComponent();
            //# Hcakkuzu 11.10.2014 - .Net 4.5 _ Duzenlendi
        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False");
        //veritabanı bağlantısı
        int soruid = 0;

        void sorucek()
        {

            try
            { //veritabanı
                connect.Open();
                string readdata = "SELECT * FROM Sorular INNER JOIN dersler ON dersler.dersID=sorular.dersID WHERE sID=" + soruid + "";
                OleDbCommand cmd = new OleDbCommand(readdata, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                reader.Read();
                //duzenlenecek sorunun bilgilerinin listelenmesi
                sText.Text = reader.GetValue(1).ToString();
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
                ders_adi.Text = reader.GetValue(10).ToString();

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                connect.Close();
            }
        
        }

        

        private void incele_Load(object sender, EventArgs e)
        {
              soruid=sorulistele.glbdegiskenler.soruid;
              this.Text = soruid.ToString() + " No'lu Soruyu İnceliyorsunuz...";

              sorucek();

        }
    }
}
