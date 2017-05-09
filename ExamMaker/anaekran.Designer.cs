namespace ExamMaker
{
    partial class anaekran
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sinavBtn = new System.Windows.Forms.Button();
            this.yenisoruBtn = new System.Windows.Forms.Button();
            this.listeleBtn = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dersler = new System.Windows.Forms.Button();
            this.derslistesi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dersid = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sinavBtn
            // 
            this.sinavBtn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sinavBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sinavBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sinavBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sinavBtn.Location = new System.Drawing.Point(26, 154);
            this.sinavBtn.Name = "sinavBtn";
            this.sinavBtn.Size = new System.Drawing.Size(308, 139);
            this.sinavBtn.TabIndex = 0;
            this.sinavBtn.Text = "Sınav Oluştur";
            this.sinavBtn.UseVisualStyleBackColor = false;
            this.sinavBtn.Click += new System.EventHandler(this.sinavBtn_Click);
            // 
            // yenisoruBtn
            // 
            this.yenisoruBtn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.yenisoruBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yenisoruBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yenisoruBtn.Location = new System.Drawing.Point(53, 49);
            this.yenisoruBtn.Name = "yenisoruBtn";
            this.yenisoruBtn.Size = new System.Drawing.Size(253, 101);
            this.yenisoruBtn.TabIndex = 1;
            this.yenisoruBtn.Text = "Yeni Soru Ekle";
            this.yenisoruBtn.UseVisualStyleBackColor = false;
            this.yenisoruBtn.Click += new System.EventHandler(this.yenisoruBtn_Click);
            // 
            // listeleBtn
            // 
            this.listeleBtn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listeleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.listeleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listeleBtn.Location = new System.Drawing.Point(53, 169);
            this.listeleBtn.Name = "listeleBtn";
            this.listeleBtn.Size = new System.Drawing.Size(253, 104);
            this.listeleBtn.TabIndex = 2;
            this.listeleBtn.Text = "Soruları Listele";
            this.listeleBtn.UseVisualStyleBackColor = false;
            this.listeleBtn.Click += new System.EventHandler(this.listeleBtn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(584, 426);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(153, 17);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "hcakkuzu0@gmail.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // dersler
            // 
            this.dersler.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dersler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dersler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dersler.Location = new System.Drawing.Point(53, 299);
            this.dersler.Name = "dersler";
            this.dersler.Size = new System.Drawing.Size(253, 104);
            this.dersler.TabIndex = 4;
            this.dersler.Text = "Dersler";
            this.dersler.UseVisualStyleBackColor = false;
            this.dersler.Click += new System.EventHandler(this.dersler_Click);
            // 
            // derslistesi
            // 
            this.derslistesi.Location = new System.Drawing.Point(26, 109);
            this.derslistesi.Name = "derslistesi";
            this.derslistesi.Size = new System.Drawing.Size(308, 24);
            this.derslistesi.TabIndex = 5;
            this.derslistesi.Text = "Seçiniz...";
            this.derslistesi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.derslistesi_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "Aşağıdan sınavı oluşturulacak dersi seçin ve \r\nsınav oluştur butonuna tıklayın";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.derslistesi);
            this.groupBox1.Controls.Add(this.sinavBtn);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(345, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 354);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sınav Oluşturma";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // dersid
            // 
            this.dersid.Location = new System.Drawing.Point(599, 12);
            this.dersid.Name = "dersid";
            this.dersid.Size = new System.Drawing.Size(79, 24);
            this.dersid.TabIndex = 7;
            this.dersid.Text = "Seçiniz...";
            this.dersid.Visible = false;
            // 
            // anaekran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(749, 452);
            this.Controls.Add(this.dersid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dersler);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listeleBtn);
            this.Controls.Add(this.yenisoruBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "anaekran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExamMaker V1.0";
            this.Load += new System.EventHandler(this.anaekran_Load);
            this.Enter += new System.EventHandler(this.anaekran_Enter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.anaekran_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sinavBtn;
        private System.Windows.Forms.Button yenisoruBtn;
        private System.Windows.Forms.Button listeleBtn;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button dersler;
        private System.Windows.Forms.ComboBox derslistesi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox dersid;
    }
}

