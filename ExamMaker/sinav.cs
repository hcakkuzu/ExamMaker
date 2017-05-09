using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Novacode;
using System.Diagnostics;
using System.IO;
using System.Data.OleDb;

namespace ExamMaker
{
    public partial class sinav : Form
    {
        //# Hcakkuzu 13.10.2014 - .Net 4.5 -V0.9
        public sinav()
        {
            InitializeComponent();
        }
       public int[] soruno;
       public string[] stext;
       public string[] cevapa;
       public string[] cevapb;
       public string[] cevapc;
       public string[] cevapd;
       public string[] cevape;

       public Random rnd = new Random();

        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False");
        public void diziolustur()
        {
            
            stext = new string[Convert.ToInt32(sorusayisi.Text)];
            cevapa = new string[Convert.ToInt32(sorusayisi.Text)];
            cevapb = new string[Convert.ToInt32(sorusayisi.Text)];
            cevapc = new string[Convert.ToInt32(sorusayisi.Text)];
            cevapd = new string[Convert.ToInt32(sorusayisi.Text)];
            cevape = new string[Convert.ToInt32(sorusayisi.Text)];
            Array.Sort(soruno);

            for (int t = 0; t < soruno.Length; t++) //rastgele sıralama algoritması
            {
                
                int tmp = soruno[t];
                int r = rnd.Next(t, soruno.Length);
                soruno[t] = soruno[r];
                soruno[r] = tmp;
            }

            for(int i=0; i<soruno.Length;i++)
                {
                    try
                    {
                        connect.Open();
                        string readdata = "SELECT * FROM sorular WHERE sID="+soruno[i].ToString()+"";
                        OleDbCommand cmd = new OleDbCommand(readdata, connect);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {    stext[i] = reader["sText"].ToString();
                            cevapa[i] = reader["c1"].ToString();
                           cevapb[i] = reader["c2"].ToString();
                            cevapc[i] = reader["c3"].ToString();
                            cevapd[i] = reader["c4"].ToString();
                            cevape[i] = reader["c5"].ToString();
                        }
                        connect.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                        connect.Close();
                    }
                }
        }
        public void winwordcrt() //worde yazma işlemi
        {
            soruno = new int[Convert.ToInt32(sorusayisi.Text)];
            progressBar1.Maximum =Convert.ToInt32(sorusayisi.Text) * Convert.ToInt32(numericUpDown1.Value.ToString());
            progressBar1.Visible = true;

            // baslik bicimi:
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            headLineFormat.Size = 14D;
            headLineFormat.Position = 12;

            // text bicimi:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
            paraFormat.Size = 10D;
                 

            for (int i = 0; i < secilmissoru.Items.Count; i++) //id lerindiziye aktarılması
                {
                    soruno[i] = Convert.ToInt32(s_soruno.Items[i]);
                }


            for (int i=0;i<numericUpDown1.Value;i++) //kaç kopya
            {
                if (i != 0)
                {
                   fileName=fileName.Substring(0, fileName.Length - 4);
                    switch (i)
                    {
                        case 1: fileName += "A.doc"; break;
                        case 2:
                            {
                                fileName = fileName.Substring(0, fileName.Length - 1);
                                fileName += "B.doc"; break;
                            }
                        case 3:
                            {
                                fileName = fileName.Substring(0, fileName.Length - 1);
                                fileName += "C.doc"; break;
                            }
                        case 4:
                            {
                                fileName = fileName.Substring(0, fileName.Length - 1);
                                fileName += "D.doc"; break;
                            }
                        case 5:
                            {
                                fileName = fileName.Substring(0, fileName.Length - 1);
                                fileName += "E.doc"; break;
                            }
                        case 6:
                            {
                                fileName = fileName.Substring(0, fileName.Length - 1);
                                fileName += "F.doc"; break;
                            }
                    }
                    
                }
                
                var doc = DocX.Create(fileName); // RAM'de dökümanı oluştur:
                diziolustur();
                for(int j=0;j<soruno.Length;j++)
                {
                            string headlineText = baslik.Text;
            string soruText = ""
                + stext[j].ToString();
            string acevapText = ""
                + cevapa[j].ToString();
            string bcevapText = ""
                + cevapb[j].ToString();
            string ccevapText = ""
                + cevapc[j].ToString();
            string dcevapText = ""
                + cevapd[j].ToString();
            string ecevapText = ""
                + cevape[j].ToString();

            // yazıları dökümana ekle;
                    if(j==0) doc.InsertParagraph(headlineText, false, headLineFormat); //baslik 
            doc.InsertParagraph((j+1).ToString()+"- " + soruText, false, paraFormat).Bold(); //sorumetni
            doc.InsertParagraph("A-) "+acevapText, false, paraFormat);
            doc.InsertParagraph("B-) " + bcevapText, false, paraFormat); //cevaplar
            doc.InsertParagraph("C-) " + ccevapText, false, paraFormat);
            doc.InsertParagraph("D-) " + dcevapText, false, paraFormat);
            doc.InsertParagraph("E-) " + ecevapText, false, paraFormat);
      //      doc.InsertParagraph(Environment.NewLine);
            progressBar1.Value++;


            }
                doc.Save();      // masaüstüne kaydet:
                // WORD ile açmak için: Process.Start("WINWORD.EXE", fileName);
            }
            MessageBox.Show("Başarılı");
            progressBar1.Visible = false;

        }

        public void listele()
        {

            try //veritabanı
            {
                connect.Open();
                string readdata = "SELECT * FROM sorular where dersID=" + sorulistele.glbdegiskenler.secilen_ders_id + "";
                OleDbCommand cmd = new OleDbCommand(readdata, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["sText"].ToString().Length > 55)
                        havuz.Items.Add(reader["sText"].ToString().Substring(0, 50) + "...");
                    else
                        havuz.Items.Add(reader["sText"].ToString());
                    havuzno.Items.Add(reader["sID"].ToString());
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına Bağlanılamadı, Tekrar Deneyin.");
                connect.Close();
            }
        }
       public string fileName = "";
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (dosya_adi.Text == "")
            {
                fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\sinav.doc";
            }
            else
            {  fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + dosya_adi.Text.ToString() + ".doc"; }
            
            if (File.Exists(fileName))
            {
                DialogResult dialogResult = MessageBox.Show("Aynı Dosya Zaten Var , Üzerine Yazılsın mı ?", "Emin misiniz ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Lütfen başka bir dosya ismi girerek yeniden deneyiniz.");
                }
                else
                {
                    winwordcrt();
                }
            }
            else
            {

                winwordcrt();
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (havuz.SelectedIndex == -1) MessageBox.Show("Bir Soru Seçmelisiniz..");
            else
            {
                s_soruno.Items.Add(havuzno.Items[havuz.SelectedIndex].ToString());
                secilmissoru.Items.Add(havuz.SelectedItem.ToString());
                havuzno.Items.RemoveAt(havuz.SelectedIndex);
                havuz.Items.RemoveAt(havuz.SelectedIndex);
            }
            sorusayisi.Text = secilmissoru.Items.Count.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (secilmissoru.SelectedIndex == -1) MessageBox.Show("Bir Soru Seçmelisiniz..");
            else
            { 
                havuzno.Items.Add(s_soruno.Items[secilmissoru.SelectedIndex].ToString());
                havuz.Items.Add(secilmissoru.SelectedItem.ToString());
                s_soruno.Items.RemoveAt(secilmissoru.SelectedIndex);
                secilmissoru.Items.RemoveAt(secilmissoru.SelectedIndex);
            }
            sorusayisi.Text = secilmissoru.Items.Count.ToString();
        }

        private void sinav_Load(object sender, EventArgs e)
        {
            listele();
            baslik.Text += " - " + DateTime.Now.ToShortDateString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            incele incele = new incele();
            sorulistele.glbdegiskenler.soruid = Convert.ToInt32(havuzno.Items[havuz.SelectedIndex]);
            incele.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            incele incele = new incele();
            sorulistele.glbdegiskenler.soruid = Convert.ToInt32(s_soruno.Items[secilmissoru.SelectedIndex]);
            incele.ShowDialog();
        }


        //Halil Çağrı Akkuzu - hcakkuzu0@gmail.com
    }
}
