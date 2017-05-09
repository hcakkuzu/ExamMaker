namespace ExamMaker
{
    partial class dersduzenle
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.duzenle = new System.Windows.Forms.Button();
            this.ders_adi = new System.Windows.Forms.TextBox();
            this.dersno = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ders NO : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ders Adı : ";
            // 
            // duzenle
            // 
            this.duzenle.Location = new System.Drawing.Point(245, 97);
            this.duzenle.Name = "duzenle";
            this.duzenle.Size = new System.Drawing.Size(107, 44);
            this.duzenle.TabIndex = 2;
            this.duzenle.Text = "Duzenle";
            this.duzenle.UseVisualStyleBackColor = true;
            this.duzenle.Click += new System.EventHandler(this.duzenle_Click);
            // 
            // ders_adi
            // 
            this.ders_adi.Location = new System.Drawing.Point(101, 51);
            this.ders_adi.Name = "ders_adi";
            this.ders_adi.Size = new System.Drawing.Size(468, 22);
            this.ders_adi.TabIndex = 3;
            // 
            // dersno
            // 
            this.dersno.Enabled = false;
            this.dersno.Location = new System.Drawing.Point(102, 17);
            this.dersno.Name = "dersno";
            this.dersno.Size = new System.Drawing.Size(468, 22);
            this.dersno.TabIndex = 4;
            // 
            // dersduzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 165);
            this.Controls.Add(this.dersno);
            this.Controls.Add(this.ders_adi);
            this.Controls.Add(this.duzenle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dersduzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ders Duzenle";
            this.Load += new System.EventHandler(this.dersduzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button duzenle;
        private System.Windows.Forms.TextBox ders_adi;
        private System.Windows.Forms.TextBox dersno;
    }
}