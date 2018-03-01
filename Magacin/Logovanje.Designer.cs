namespace Magacin
{
    partial class Logovanje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logovanje));
            this.loguj_btn = new System.Windows.Forms.Button();
            this.korisnik_lbl = new System.Windows.Forms.Label();
            this.korisnik_txt = new System.Windows.Forms.TextBox();
            this.lozinka_txt = new System.Windows.Forms.TextBox();
            this.lozinka_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loguj_btn
            // 
            this.loguj_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loguj_btn.Location = new System.Drawing.Point(180, 76);
            this.loguj_btn.Name = "loguj_btn";
            this.loguj_btn.Size = new System.Drawing.Size(92, 23);
            this.loguj_btn.TabIndex = 3;
            this.loguj_btn.Text = "Loguj se";
            this.loguj_btn.UseVisualStyleBackColor = true;
            this.loguj_btn.Click += new System.EventHandler(this.loguj_btn_Click);
            // 
            // korisnik_lbl
            // 
            this.korisnik_lbl.AutoSize = true;
            this.korisnik_lbl.Location = new System.Drawing.Point(12, 15);
            this.korisnik_lbl.Name = "korisnik_lbl";
            this.korisnik_lbl.Size = new System.Drawing.Size(47, 13);
            this.korisnik_lbl.TabIndex = 1;
            this.korisnik_lbl.Text = "Korisnik:";
            // 
            // korisnik_txt
            // 
            this.korisnik_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.korisnik_txt.Location = new System.Drawing.Point(65, 12);
            this.korisnik_txt.Name = "korisnik_txt";
            this.korisnik_txt.Size = new System.Drawing.Size(207, 20);
            this.korisnik_txt.TabIndex = 1;
            this.korisnik_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.korisnik_txt_KeyDown);
            // 
            // lozinka_txt
            // 
            this.lozinka_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lozinka_txt.Location = new System.Drawing.Point(65, 38);
            this.lozinka_txt.Name = "lozinka_txt";
            this.lozinka_txt.PasswordChar = '*';
            this.lozinka_txt.Size = new System.Drawing.Size(207, 20);
            this.lozinka_txt.TabIndex = 2;
            this.lozinka_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lozinka_txt_KeyDown);
            // 
            // lozinka_lbl
            // 
            this.lozinka_lbl.AutoSize = true;
            this.lozinka_lbl.Location = new System.Drawing.Point(12, 41);
            this.lozinka_lbl.Name = "lozinka_lbl";
            this.lozinka_lbl.Size = new System.Drawing.Size(47, 13);
            this.lozinka_lbl.TabIndex = 3;
            this.lozinka_lbl.Text = "Lozinka:";
            // 
            // Logovanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.lozinka_txt);
            this.Controls.Add(this.lozinka_lbl);
            this.Controls.Add(this.korisnik_txt);
            this.Controls.Add(this.korisnik_lbl);
            this.Controls.Add(this.loguj_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "Logovanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logovanje";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loguj_btn;
        private System.Windows.Forms.Label korisnik_lbl;
        private System.Windows.Forms.TextBox korisnik_txt;
        private System.Windows.Forms.TextBox lozinka_txt;
        private System.Windows.Forms.Label lozinka_lbl;
    }
}

