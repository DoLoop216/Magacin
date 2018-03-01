namespace Magacin
{
    partial class Dokument1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dokument1));
            this.dokumentSearch_txt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.magacini_cmb = new System.Windows.Forms.ComboBox();
            this.brDok_lbl = new System.Windows.Forms.Label();
            this.brDok_txt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.obrisiStavkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.akcijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.razduziRobuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretvorenUVrDokLok_txt = new System.Windows.Forms.TextBox();
            this.pretvorenUBrDokLok_txt = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pretvorenUVrDokKom_txt = new System.Windows.Forms.TextBox();
            this.pretvorenUBrDokKom_txt = new System.Windows.Forms.TextBox();
            this.sacuvaj_btn = new System.Windows.Forms.Button();
            this.komentar_btn = new System.Windows.Forms.Button();
            this.lock_btn = new System.Windows.Forms.Button();
            this.noviDokument_btn = new System.Windows.Forms.Button();
            this.sledeciDokument_btn = new System.Windows.Forms.Button();
            this.prethodniDokument_btn = new System.Windows.Forms.Button();
            this.odbaci_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.izborPartnera_cmb = new System.Windows.Forms.ComboBox();
            this.izborPartnera_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dokumentSearch_txt
            // 
            this.dokumentSearch_txt.Location = new System.Drawing.Point(119, 12);
            this.dokumentSearch_txt.Name = "dokumentSearch_txt";
            this.dokumentSearch_txt.Size = new System.Drawing.Size(100, 20);
            this.dokumentSearch_txt.TabIndex = 0;
            this.dokumentSearch_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dokumentSearch_txt_KeyDown);
            this.dokumentSearch_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dokumentSearch_txt_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.izborPartnera_btn);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.izborPartnera_cmb);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.magacini_cmb);
            this.panel1.Controls.Add(this.brDok_lbl);
            this.panel1.Controls.Add(this.brDok_txt);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 91);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Magacin:";
            // 
            // magacini_cmb
            // 
            this.magacini_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.magacini_cmb.FormattingEnabled = true;
            this.magacini_cmb.Location = new System.Drawing.Point(71, 29);
            this.magacini_cmb.Name = "magacini_cmb";
            this.magacini_cmb.Size = new System.Drawing.Size(227, 21);
            this.magacini_cmb.TabIndex = 7;
            this.magacini_cmb.SelectedIndexChanged += new System.EventHandler(this.magacini_cmb_SelectedIndexChanged);
            // 
            // brDok_lbl
            // 
            this.brDok_lbl.AutoSize = true;
            this.brDok_lbl.Location = new System.Drawing.Point(3, 6);
            this.brDok_lbl.Name = "brDok_lbl";
            this.brDok_lbl.Size = new System.Drawing.Size(46, 13);
            this.brDok_lbl.TabIndex = 6;
            this.brDok_lbl.Text = "Br. Dok.";
            // 
            // brDok_txt
            // 
            this.brDok_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.brDok_txt.Location = new System.Drawing.Point(55, 3);
            this.brDok_txt.Name = "brDok_txt";
            this.brDok_txt.Size = new System.Drawing.Size(109, 20);
            this.brDok_txt.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 186);
            this.panel2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(758, 180);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obrisiStavkuToolStripMenuItem,
            this.toolStripSeparator1,
            this.akcijaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 54);
            // 
            // obrisiStavkuToolStripMenuItem
            // 
            this.obrisiStavkuToolStripMenuItem.Name = "obrisiStavkuToolStripMenuItem";
            this.obrisiStavkuToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.obrisiStavkuToolStripMenuItem.Text = "Obrisi stavku";
            this.obrisiStavkuToolStripMenuItem.Click += new System.EventHandler(this.obrisiStavkuToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // akcijaToolStripMenuItem
            // 
            this.akcijaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.razduziRobuToolStripMenuItem});
            this.akcijaToolStripMenuItem.Name = "akcijaToolStripMenuItem";
            this.akcijaToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.akcijaToolStripMenuItem.Text = "Akcija";
            // 
            // razduziRobuToolStripMenuItem
            // 
            this.razduziRobuToolStripMenuItem.Name = "razduziRobuToolStripMenuItem";
            this.razduziRobuToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.razduziRobuToolStripMenuItem.Text = "Razduzi robu";
            this.razduziRobuToolStripMenuItem.Visible = false;
            this.razduziRobuToolStripMenuItem.Click += new System.EventHandler(this.razduziRobuToolStripMenuItem_Click);
            // 
            // pretvorenUVrDokLok_txt
            // 
            this.pretvorenUVrDokLok_txt.Location = new System.Drawing.Point(3, 38);
            this.pretvorenUVrDokLok_txt.Name = "pretvorenUVrDokLok_txt";
            this.pretvorenUVrDokLok_txt.ReadOnly = true;
            this.pretvorenUVrDokLok_txt.Size = new System.Drawing.Size(77, 20);
            this.pretvorenUVrDokLok_txt.TabIndex = 9;
            // 
            // pretvorenUBrDokLok_txt
            // 
            this.pretvorenUBrDokLok_txt.Location = new System.Drawing.Point(3, 64);
            this.pretvorenUBrDokLok_txt.Name = "pretvorenUBrDokLok_txt";
            this.pretvorenUBrDokLok_txt.ReadOnly = true;
            this.pretvorenUBrDokLok_txt.Size = new System.Drawing.Size(77, 20);
            this.pretvorenUBrDokLok_txt.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pretvorenUVrDokKom_txt);
            this.panel3.Controls.Add(this.pretvorenUBrDokKom_txt);
            this.panel3.Controls.Add(this.pretvorenUVrDokLok_txt);
            this.panel3.Controls.Add(this.pretvorenUBrDokLok_txt);
            this.panel3.Location = new System.Drawing.Point(15, 327);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 88);
            this.panel3.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Komercijalno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Lokalno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Pretvoren";
            // 
            // pretvorenUVrDokKom_txt
            // 
            this.pretvorenUVrDokKom_txt.Location = new System.Drawing.Point(111, 38);
            this.pretvorenUVrDokKom_txt.Name = "pretvorenUVrDokKom_txt";
            this.pretvorenUVrDokKom_txt.ReadOnly = true;
            this.pretvorenUVrDokKom_txt.Size = new System.Drawing.Size(77, 20);
            this.pretvorenUVrDokKom_txt.TabIndex = 11;
            // 
            // pretvorenUBrDokKom_txt
            // 
            this.pretvorenUBrDokKom_txt.Location = new System.Drawing.Point(111, 64);
            this.pretvorenUBrDokKom_txt.Name = "pretvorenUBrDokKom_txt";
            this.pretvorenUBrDokKom_txt.ReadOnly = true;
            this.pretvorenUBrDokKom_txt.Size = new System.Drawing.Size(77, 20);
            this.pretvorenUBrDokKom_txt.TabIndex = 12;
            // 
            // sacuvaj_btn
            // 
            this.sacuvaj_btn.BackColor = System.Drawing.Color.White;
            this.sacuvaj_btn.BackgroundImage = global::Magacin.Properties.Resources.saveIcon;
            this.sacuvaj_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sacuvaj_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sacuvaj_btn.Location = new System.Drawing.Point(38, 12);
            this.sacuvaj_btn.Name = "sacuvaj_btn";
            this.sacuvaj_btn.Size = new System.Drawing.Size(21, 20);
            this.sacuvaj_btn.TabIndex = 13;
            this.sacuvaj_btn.UseVisualStyleBackColor = false;
            this.sacuvaj_btn.EnabledChanged += new System.EventHandler(this.sacuvaj_btn_EnabledChanged);
            this.sacuvaj_btn.Click += new System.EventHandler(this.sacuvaj_btn_Click);
            // 
            // komentar_btn
            // 
            this.komentar_btn.BackColor = System.Drawing.Color.White;
            this.komentar_btn.BackgroundImage = global::Magacin.Properties.Resources.comment_png_22741;
            this.komentar_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.komentar_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.komentar_btn.FlatAppearance.BorderSize = 2;
            this.komentar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.komentar_btn.Location = new System.Drawing.Point(252, 12);
            this.komentar_btn.Name = "komentar_btn";
            this.komentar_btn.Size = new System.Drawing.Size(21, 20);
            this.komentar_btn.TabIndex = 12;
            this.komentar_btn.UseVisualStyleBackColor = false;
            this.komentar_btn.Click += new System.EventHandler(this.komentar_btn_Click);
            // 
            // lock_btn
            // 
            this.lock_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lock_btn.BackColor = System.Drawing.Color.Transparent;
            this.lock_btn.BackgroundImage = global::Magacin.Properties.Resources.key_green;
            this.lock_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lock_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lock_btn.Location = new System.Drawing.Point(752, 12);
            this.lock_btn.Name = "lock_btn";
            this.lock_btn.Size = new System.Drawing.Size(21, 20);
            this.lock_btn.TabIndex = 8;
            this.lock_btn.UseVisualStyleBackColor = false;
            this.lock_btn.Click += new System.EventHandler(this.lock_btn_Click);
            // 
            // noviDokument_btn
            // 
            this.noviDokument_btn.BackColor = System.Drawing.Color.White;
            this.noviDokument_btn.BackgroundImage = global::Magacin.Properties.Resources.newIcon;
            this.noviDokument_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noviDokument_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.noviDokument_btn.Location = new System.Drawing.Point(12, 12);
            this.noviDokument_btn.Name = "noviDokument_btn";
            this.noviDokument_btn.Size = new System.Drawing.Size(21, 20);
            this.noviDokument_btn.TabIndex = 4;
            this.noviDokument_btn.UseVisualStyleBackColor = false;
            this.noviDokument_btn.Click += new System.EventHandler(this.noviDokument_btn_Click);
            // 
            // sledeciDokument_btn
            // 
            this.sledeciDokument_btn.BackColor = System.Drawing.Color.White;
            this.sledeciDokument_btn.BackgroundImage = global::Magacin.Properties.Resources.arrow_right;
            this.sledeciDokument_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sledeciDokument_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sledeciDokument_btn.Location = new System.Drawing.Point(225, 12);
            this.sledeciDokument_btn.Name = "sledeciDokument_btn";
            this.sledeciDokument_btn.Size = new System.Drawing.Size(21, 20);
            this.sledeciDokument_btn.TabIndex = 3;
            this.sledeciDokument_btn.UseVisualStyleBackColor = false;
            this.sledeciDokument_btn.Click += new System.EventHandler(this.sledeciDokument_btn_Click);
            // 
            // prethodniDokument_btn
            // 
            this.prethodniDokument_btn.BackColor = System.Drawing.Color.White;
            this.prethodniDokument_btn.BackgroundImage = global::Magacin.Properties.Resources.arrow_left;
            this.prethodniDokument_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.prethodniDokument_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.prethodniDokument_btn.Location = new System.Drawing.Point(92, 12);
            this.prethodniDokument_btn.Name = "prethodniDokument_btn";
            this.prethodniDokument_btn.Size = new System.Drawing.Size(21, 20);
            this.prethodniDokument_btn.TabIndex = 2;
            this.prethodniDokument_btn.UseVisualStyleBackColor = false;
            this.prethodniDokument_btn.Click += new System.EventHandler(this.prethodniDokument_btn_Click);
            // 
            // odbaci_btn
            // 
            this.odbaci_btn.BackColor = System.Drawing.Color.White;
            this.odbaci_btn.BackgroundImage = global::Magacin.Properties.Resources.discardIcon;
            this.odbaci_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.odbaci_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.odbaci_btn.Location = new System.Drawing.Point(65, 12);
            this.odbaci_btn.Name = "odbaci_btn";
            this.odbaci_btn.Size = new System.Drawing.Size(21, 20);
            this.odbaci_btn.TabIndex = 14;
            this.odbaci_btn.UseVisualStyleBackColor = false;
            this.odbaci_btn.EnabledChanged += new System.EventHandler(this.sacuvaj_btn_EnabledChanged);
            this.odbaci_btn.Click += new System.EventHandler(this.odbaci_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Partner";
            // 
            // izborPartnera_cmb
            // 
            this.izborPartnera_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.izborPartnera_cmb.FormattingEnabled = true;
            this.izborPartnera_cmb.Location = new System.Drawing.Point(50, 56);
            this.izborPartnera_cmb.Name = "izborPartnera_cmb";
            this.izborPartnera_cmb.Size = new System.Drawing.Size(221, 21);
            this.izborPartnera_cmb.TabIndex = 9;
            // 
            // izborPartnera_btn
            // 
            this.izborPartnera_btn.BackColor = System.Drawing.Color.White;
            this.izborPartnera_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.izborPartnera_btn.FlatAppearance.BorderSize = 0;
            this.izborPartnera_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.izborPartnera_btn.Location = new System.Drawing.Point(277, 56);
            this.izborPartnera_btn.Name = "izborPartnera_btn";
            this.izborPartnera_btn.Size = new System.Drawing.Size(21, 21);
            this.izborPartnera_btn.TabIndex = 15;
            this.izborPartnera_btn.Text = "...";
            this.izborPartnera_btn.UseVisualStyleBackColor = false;
            // 
            // Dokument1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 427);
            this.Controls.Add(this.odbaci_btn);
            this.Controls.Add(this.sacuvaj_btn);
            this.Controls.Add(this.komentar_btn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lock_btn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.noviDokument_btn);
            this.Controls.Add(this.sledeciDokument_btn);
            this.Controls.Add(this.prethodniDokument_btn);
            this.Controls.Add(this.dokumentSearch_txt);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(649, 378);
            this.Name = "Dokument1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dokument1";
            this.Load += new System.EventHandler(this.Dokument1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dokument1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dokumentSearch_txt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button prethodniDokument_btn;
        private System.Windows.Forms.Button sledeciDokument_btn;
        private System.Windows.Forms.Button noviDokument_btn;
        private System.Windows.Forms.Label brDok_lbl;
        private System.Windows.Forms.TextBox brDok_txt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button lock_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem akcijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem razduziRobuToolStripMenuItem;
        private System.Windows.Forms.TextBox pretvorenUVrDokLok_txt;
        private System.Windows.Forms.TextBox pretvorenUBrDokLok_txt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pretvorenUVrDokKom_txt;
        private System.Windows.Forms.TextBox pretvorenUBrDokKom_txt;
        private System.Windows.Forms.Button komentar_btn;
        private System.Windows.Forms.ComboBox magacini_cmb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button sacuvaj_btn;
        private System.Windows.Forms.Button odbaci_btn;
        private System.Windows.Forms.ToolStripMenuItem obrisiStavkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button izborPartnera_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox izborPartnera_cmb;
    }
}