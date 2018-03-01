namespace Magacin
{
    partial class NoviKorisnik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoviKorisnik));
            this.kreiraj_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.korisnickoIme_txt = new System.Windows.Forms.TextBox();
            this.sifra_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kreiraj_btn
            // 
            this.kreiraj_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kreiraj_btn.Location = new System.Drawing.Point(226, 63);
            this.kreiraj_btn.Name = "kreiraj_btn";
            this.kreiraj_btn.Size = new System.Drawing.Size(75, 23);
            this.kreiraj_btn.TabIndex = 0;
            this.kreiraj_btn.Text = "Kreiraj";
            this.kreiraj_btn.UseVisualStyleBackColor = true;
            this.kreiraj_btn.Click += new System.EventHandler(this.kreiraj_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Korisnicko ime:";
            // 
            // korisnickoIme_txt
            // 
            this.korisnickoIme_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.korisnickoIme_txt.Location = new System.Drawing.Point(96, 12);
            this.korisnickoIme_txt.Name = "korisnickoIme_txt";
            this.korisnickoIme_txt.Size = new System.Drawing.Size(205, 20);
            this.korisnickoIme_txt.TabIndex = 2;
            // 
            // sifra_txt
            // 
            this.sifra_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sifra_txt.Location = new System.Drawing.Point(96, 38);
            this.sifra_txt.Name = "sifra_txt";
            this.sifra_txt.Size = new System.Drawing.Size(205, 20);
            this.sifra_txt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sifra:";
            // 
            // NoviKorisnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 94);
            this.Controls.Add(this.sifra_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.korisnickoIme_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kreiraj_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(329, 133);
            this.MinimumSize = new System.Drawing.Size(329, 133);
            this.Name = "NoviKorisnik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novi korisnik";
            this.Load += new System.EventHandler(this.NoviKorisnik_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kreiraj_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox korisnickoIme_txt;
        private System.Windows.Forms.TextBox sifra_txt;
        private System.Windows.Forms.Label label2;
    }
}