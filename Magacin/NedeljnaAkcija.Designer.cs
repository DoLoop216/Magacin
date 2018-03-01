namespace Magacin
{
    partial class NedeljnaAkcija
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NedeljnaAkcija));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.izborAkcije_cmb = new System.Windows.Forms.ComboBox();
            this.unesi_btn = new System.Windows.Forms.Button();
            this.mpCena_lbl = new System.Windows.Forms.Label();
            this.akcijskaCena_lbl = new System.Windows.Forms.Label();
            this.popust_lbl = new System.Windows.Forms.Label();
            this.kolicina_lbl = new System.Windows.Forms.Label();
            this.vrednost_lbl = new System.Windows.Forms.Label();
            this.izmeni_btn = new System.Windows.Forms.Button();
            this.preostalaKolicina_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maloprodajni racun:";
            // 
            // izborAkcije_cmb
            // 
            this.izborAkcije_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.izborAkcije_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.izborAkcije_cmb.FormattingEnabled = true;
            this.izborAkcije_cmb.Location = new System.Drawing.Point(187, 25);
            this.izborAkcije_cmb.Name = "izborAkcije_cmb";
            this.izborAkcije_cmb.Size = new System.Drawing.Size(261, 21);
            this.izborAkcije_cmb.TabIndex = 2;
            this.izborAkcije_cmb.SelectedIndexChanged += new System.EventHandler(this.izborAkcije_cmb_SelectedIndexChanged);
            // 
            // unesi_btn
            // 
            this.unesi_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unesi_btn.Location = new System.Drawing.Point(454, 26);
            this.unesi_btn.Name = "unesi_btn";
            this.unesi_btn.Size = new System.Drawing.Size(91, 23);
            this.unesi_btn.TabIndex = 3;
            this.unesi_btn.Text = "Unesi";
            this.unesi_btn.UseVisualStyleBackColor = true;
            this.unesi_btn.Click += new System.EventHandler(this.unesi_btn_Click);
            // 
            // mpCena_lbl
            // 
            this.mpCena_lbl.AutoSize = true;
            this.mpCena_lbl.ForeColor = System.Drawing.Color.Red;
            this.mpCena_lbl.Location = new System.Drawing.Point(184, 62);
            this.mpCena_lbl.Name = "mpCena_lbl";
            this.mpCena_lbl.Size = new System.Drawing.Size(54, 13);
            this.mpCena_lbl.TabIndex = 4;
            this.mpCena_lbl.Text = "MP Cena:";
            // 
            // akcijskaCena_lbl
            // 
            this.akcijskaCena_lbl.AutoSize = true;
            this.akcijskaCena_lbl.ForeColor = System.Drawing.Color.Green;
            this.akcijskaCena_lbl.Location = new System.Drawing.Point(184, 75);
            this.akcijskaCena_lbl.Name = "akcijskaCena_lbl";
            this.akcijskaCena_lbl.Size = new System.Drawing.Size(77, 13);
            this.akcijskaCena_lbl.TabIndex = 5;
            this.akcijskaCena_lbl.Text = "Akcijska cena:";
            // 
            // popust_lbl
            // 
            this.popust_lbl.AutoSize = true;
            this.popust_lbl.ForeColor = System.Drawing.Color.Green;
            this.popust_lbl.Location = new System.Drawing.Point(184, 49);
            this.popust_lbl.Name = "popust_lbl";
            this.popust_lbl.Size = new System.Drawing.Size(62, 13);
            this.popust_lbl.TabIndex = 6;
            this.popust_lbl.Text = "Popust: N%";
            // 
            // kolicina_lbl
            // 
            this.kolicina_lbl.AutoSize = true;
            this.kolicina_lbl.Location = new System.Drawing.Point(184, 88);
            this.kolicina_lbl.Name = "kolicina_lbl";
            this.kolicina_lbl.Size = new System.Drawing.Size(47, 13);
            this.kolicina_lbl.TabIndex = 7;
            this.kolicina_lbl.Text = "Kolicina:";
            // 
            // vrednost_lbl
            // 
            this.vrednost_lbl.AutoSize = true;
            this.vrednost_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vrednost_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.vrednost_lbl.Location = new System.Drawing.Point(184, 101);
            this.vrednost_lbl.Name = "vrednost_lbl";
            this.vrednost_lbl.Size = new System.Drawing.Size(61, 13);
            this.vrednost_lbl.TabIndex = 8;
            this.vrednost_lbl.Text = "Vrednost:";
            // 
            // izmeni_btn
            // 
            this.izmeni_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.izmeni_btn.Location = new System.Drawing.Point(12, 105);
            this.izmeni_btn.Name = "izmeni_btn";
            this.izmeni_btn.Size = new System.Drawing.Size(97, 23);
            this.izmeni_btn.TabIndex = 9;
            this.izmeni_btn.Text = "Izmeni akciju";
            this.izmeni_btn.UseVisualStyleBackColor = true;
            this.izmeni_btn.Click += new System.EventHandler(this.izmeni_btn_Click);
            // 
            // preostalaKolicina_lbl
            // 
            this.preostalaKolicina_lbl.AutoSize = true;
            this.preostalaKolicina_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preostalaKolicina_lbl.ForeColor = System.Drawing.Color.Fuchsia;
            this.preostalaKolicina_lbl.Location = new System.Drawing.Point(185, 114);
            this.preostalaKolicina_lbl.Name = "preostalaKolicina_lbl";
            this.preostalaKolicina_lbl.Size = new System.Drawing.Size(112, 13);
            this.preostalaKolicina_lbl.TabIndex = 10;
            this.preostalaKolicina_lbl.Text = "Preostala kolicina:";
            // 
            // NedeljnaAkcija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 140);
            this.Controls.Add(this.preostalaKolicina_lbl);
            this.Controls.Add(this.izmeni_btn);
            this.Controls.Add(this.vrednost_lbl);
            this.Controls.Add(this.kolicina_lbl);
            this.Controls.Add(this.popust_lbl);
            this.Controls.Add(this.akcijskaCena_lbl);
            this.Controls.Add(this.mpCena_lbl);
            this.Controls.Add(this.unesi_btn);
            this.Controls.Add(this.izborAkcije_cmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(491, 160);
            this.Name = "NedeljnaAkcija";
            this.Text = "Nedeljna akcija";
            this.Load += new System.EventHandler(this.NedeljnaAkcija_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NedeljnaAkcija_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox izborAkcije_cmb;
        private System.Windows.Forms.Button unesi_btn;
        private System.Windows.Forms.Label mpCena_lbl;
        private System.Windows.Forms.Label akcijskaCena_lbl;
        private System.Windows.Forms.Label popust_lbl;
        private System.Windows.Forms.Label kolicina_lbl;
        private System.Windows.Forms.Label vrednost_lbl;
        private System.Windows.Forms.Button izmeni_btn;
        private System.Windows.Forms.Label preostalaKolicina_lbl;
    }
}