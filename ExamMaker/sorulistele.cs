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
{//# Hcakkuzu 12.10.2014 - .Net 4.5
    public partial class sorulistele : Form
    {
        public static class glbdegiskenler  // program içinde heryerden erişebilmek için
        {
            public static int soruid= 0;
            public static int dersid = 0;
            public static int secilen_ders_id = 0;
        }
        public sorulistele()
        {
            
            InitializeComponent();
        }

        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False");

        public void listele()
        {
            
            try
            {
                string query = "Select sID,sText,c1,c2,c3,c4,c5,dogru_cevap,ders FROM sorular INNER JOIN dersler ON sorular.dersID=dersler.dersID";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connect);
                connect.Open();
                //MessageBox.Show("Connection Open ! ");
                DataSet showing = new DataSet();
                adapter.Fill(showing, "sorular");
                dataGridView1.DataSource = showing.Tables["sorular"];

                this.dataGridView1.Columns["sID"].HeaderText = "SoruNO";
                this.dataGridView1.Columns["sText"].HeaderText = "SoruMetni";
                this.dataGridView1.Columns["c1"].HeaderText = "A";
                this.dataGridView1.Columns["c2"].HeaderText = "B";
                this.dataGridView1.Columns["c3"].HeaderText = "C";
                this.dataGridView1.Columns["c4"].HeaderText = "D";
                this.dataGridView1.Columns["c5"].HeaderText = "E";
                this.dataGridView1.Columns["dogru_cevap"].HeaderText = "Cevap";
                this.dataGridView1.Columns["ders"].HeaderText = "Ders";

                adapter.Dispose();
                connect.Close();
                sorusayisi.Text = dataGridView1.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                connect.Close();
            }
        }

        public void KayitSil(string x)
        {
            try
            {
            string sqldelete = x;
            connect.Open();
            OleDbCommand cmdDelete = new OleDbCommand(sqldelete, connect);
            cmdDelete.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Soru Başarıyla Silindi!...");
            sorusayisi.Text = dataGridView1.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                connect.Close();
            }
            
        }

        private void sorulistele_Load(object sender, EventArgs e)
        {
            listele();
            sorusayisi.Text = dataGridView1.RowCount.ToString();
        }



        private void soruyuİnceleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            incele incele = new incele();
            glbdegiskenler.soruid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            incele.ShowDialog();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                if (hti.ColumnIndex != -1 || hti.RowIndex != -1)
                dataGridView1.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Seçtiğiniz soru kaydi silinecek? Emin misiniz ?", "Emin misiniz ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                KayitSil("DELETE From sorular Where [sID]=" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "");
                listele();
                sorusayisi.Text = dataGridView1.RowCount.ToString();
            }
            else if (dialogResult == DialogResult.No)
            {
                listele();
                sorusayisi.Text = dataGridView1.RowCount.ToString();
            }

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            duzenle duzenle = new duzenle();
            glbdegiskenler.soruid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            duzenle.ShowDialog();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listele();
            sorusayisi.Text = dataGridView1.RowCount.ToString();
        }

      
    }
}
