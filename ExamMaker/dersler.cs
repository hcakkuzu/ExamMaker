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
    public partial class dersler : Form
    {
        public dersler()
        {
            InitializeComponent();
        }

        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False");

        public void listele()
        {

            try
            {
                string query = "Select * from dersler";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connect);
                connect.Open();
                //MessageBox.Show("Connection Open ! ");
                DataSet showing = new DataSet();
                adapter.Fill(showing, "dersler");
                dataGridView1.DataSource = showing.Tables["dersler"];

                this.dataGridView1.Columns["dersID"].HeaderText = "DersNO";
                this.dataGridView1.Columns["Ders"].HeaderText = "Ders";

                adapter.Dispose();
                connect.Close();
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
                MessageBox.Show("Ders Başarıyla Silindi!...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                connect.Close();
            }

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

            DialogResult dialogResult = MessageBox.Show("Seçtiğiniz ders kaydi silinecek? Emin misiniz ?", "Emin misiniz ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                KayitSil("DELETE From dersler Where [dersID]=" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "");
                listele();
            }
            else if (dialogResult == DialogResult.No)
            {
                listele();
            }

        }

        private void listeleYenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dersler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            sorulistele.glbdegiskenler.dersid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            dersduzenle duzenle = new dersduzenle();
            duzenle.ShowDialog();
            
        }

        private void yeniDersEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dersekle ekle = new dersekle();
            ekle.ShowDialog();
        }
    }
}
