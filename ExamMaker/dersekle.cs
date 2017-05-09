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
    public partial class dersekle : Form
    {
        public dersekle()
        {
            InitializeComponent();
        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False");

        private void ekle_Click(object sender, EventArgs e)
        {
            if (ders_adi.Text == "") MessageBox.Show("Ders adını girin.");
            else
            {
                try
                {
                    //bilgi ekleme
                    connect.Open();
                    string add = "INSERT INTO dersler([ders]) VALUES('" + ders_adi.Text.ToString() + "') ";
                    OleDbCommand cmd = new OleDbCommand(add, connect);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ders başarıyla eklendi!");
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
