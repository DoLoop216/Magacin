namespace Magacin
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dokumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prirucniMagacinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaduzenjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.razduzenjeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.proizvodnjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prijemnicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materijala3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pocetakGodineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.podesavanjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poslovanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.akcijeKomercijalisteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nedeljnaAkcijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uspesnostMagacinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledDanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kapitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kvizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.korisnik_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.beleska_rtxt = new System.Windows.Forms.RichTextBox();
            this.sacuvajBelesku_btn = new System.Windows.Forms.Button();
            this.brzaPretragaModula_txt = new System.Windows.Forms.TextBox();
            this.brzaPretragaModula_lbl = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.brzaPretragaModula_dgv = new System.Windows.Forms.DataGridView();
            this.brzaPretragaModula_cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.informacijeOModuluToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pokreniModulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brzaPretragaModula_dgv)).BeginInit();
            this.brzaPretragaModula_cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dokumentToolStripMenuItem,
            this.programToolStripMenuItem,
            this.poslovanjeToolStripMenuItem,
            this.kapitalToolStripMenuItem,
            this.kvizToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dokumentToolStripMenuItem
            // 
            this.dokumentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prirucniMagacinToolStripMenuItem,
            this.proizvodnjaToolStripMenuItem});
            this.dokumentToolStripMenuItem.Name = "dokumentToolStripMenuItem";
            this.dokumentToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.dokumentToolStripMenuItem.Text = "Dokument";
            // 
            // prirucniMagacinToolStripMenuItem
            // 
            this.prirucniMagacinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zaduzenjeToolStripMenuItem,
            this.razduzenjeToolStripMenuItem1});
            this.prirucniMagacinToolStripMenuItem.Name = "prirucniMagacinToolStripMenuItem";
            this.prirucniMagacinToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.prirucniMagacinToolStripMenuItem.Text = "Prirucni magacin";
            // 
            // zaduzenjeToolStripMenuItem
            // 
            this.zaduzenjeToolStripMenuItem.Name = "zaduzenjeToolStripMenuItem";
            this.zaduzenjeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.zaduzenjeToolStripMenuItem.Text = "Zaduzenje [0]";
            this.zaduzenjeToolStripMenuItem.Click += new System.EventHandler(this.zaduzenjeToolStripMenuItem_Click);
            // 
            // razduzenjeToolStripMenuItem1
            // 
            this.razduzenjeToolStripMenuItem1.Name = "razduzenjeToolStripMenuItem1";
            this.razduzenjeToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.razduzenjeToolStripMenuItem1.Text = "Razduzenje [1]";
            this.razduzenjeToolStripMenuItem1.Click += new System.EventHandler(this.razduzenjeToolStripMenuItem1_Click);
            // 
            // proizvodnjaToolStripMenuItem
            // 
            this.proizvodnjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prijemnicaToolStripMenuItem});
            this.proizvodnjaToolStripMenuItem.Name = "proizvodnjaToolStripMenuItem";
            this.proizvodnjaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.proizvodnjaToolStripMenuItem.Text = "Proizvodnja";
            // 
            // prijemnicaToolStripMenuItem
            // 
            this.prijemnicaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materijala3ToolStripMenuItem});
            this.prijemnicaToolStripMenuItem.Name = "prijemnicaToolStripMenuItem";
            this.prijemnicaToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.prijemnicaToolStripMenuItem.Text = "Prijemnica";
            // 
            // materijala3ToolStripMenuItem
            // 
            this.materijala3ToolStripMenuItem.Name = "materijala3ToolStripMenuItem";
            this.materijala3ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.materijala3ToolStripMenuItem.Text = "Materijala [3]";
            this.materijala3ToolStripMenuItem.Click += new System.EventHandler(this.materijala3ToolStripMenuItem_Click);
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.pocetakGodineToolStripMenuItem,
            this.podesavanjaToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            this.korisniciToolStripMenuItem.Click += new System.EventHandler(this.korisniciToolStripMenuItem_Click);
            // 
            // pocetakGodineToolStripMenuItem
            // 
            this.pocetakGodineToolStripMenuItem.Name = "pocetakGodineToolStripMenuItem";
            this.pocetakGodineToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.pocetakGodineToolStripMenuItem.Text = "Pocetak godine";
            this.pocetakGodineToolStripMenuItem.Click += new System.EventHandler(this.pocetakGodineToolStripMenuItem_Click);
            // 
            // podesavanjaToolStripMenuItem
            // 
            this.podesavanjaToolStripMenuItem.Name = "podesavanjaToolStripMenuItem";
            this.podesavanjaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.podesavanjaToolStripMenuItem.Text = "Podesavanja";
            this.podesavanjaToolStripMenuItem.Click += new System.EventHandler(this.podesavanjaToolStripMenuItem_Click);
            // 
            // poslovanjeToolStripMenuItem
            // 
            this.poslovanjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.akcijeKomercijalisteToolStripMenuItem,
            this.uspesnostMagacinaToolStripMenuItem,
            this.pregledDanaToolStripMenuItem});
            this.poslovanjeToolStripMenuItem.Name = "poslovanjeToolStripMenuItem";
            this.poslovanjeToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.poslovanjeToolStripMenuItem.Text = "Poslovanje";
            // 
            // akcijeKomercijalisteToolStripMenuItem
            // 
            this.akcijeKomercijalisteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nedeljnaAkcijaToolStripMenuItem});
            this.akcijeKomercijalisteToolStripMenuItem.Name = "akcijeKomercijalisteToolStripMenuItem";
            this.akcijeKomercijalisteToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.akcijeKomercijalisteToolStripMenuItem.Text = "Komercijalne akcije";
            // 
            // nedeljnaAkcijaToolStripMenuItem
            // 
            this.nedeljnaAkcijaToolStripMenuItem.Name = "nedeljnaAkcijaToolStripMenuItem";
            this.nedeljnaAkcijaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.nedeljnaAkcijaToolStripMenuItem.Text = "Nedeljna akcija";
            this.nedeljnaAkcijaToolStripMenuItem.Click += new System.EventHandler(this.nedeljnaAkcijaToolStripMenuItem_Click);
            // 
            // uspesnostMagacinaToolStripMenuItem
            // 
            this.uspesnostMagacinaToolStripMenuItem.Name = "uspesnostMagacinaToolStripMenuItem";
            this.uspesnostMagacinaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.uspesnostMagacinaToolStripMenuItem.Text = "Uspesnost magacina";
            this.uspesnostMagacinaToolStripMenuItem.Click += new System.EventHandler(this.uspesnostMagacinaToolStripMenuItem_Click);
            // 
            // pregledDanaToolStripMenuItem
            // 
            this.pregledDanaToolStripMenuItem.Name = "pregledDanaToolStripMenuItem";
            this.pregledDanaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.pregledDanaToolStripMenuItem.Text = "Pregled dana";
            this.pregledDanaToolStripMenuItem.Click += new System.EventHandler(this.pregledDanaToolStripMenuItem_Click);
            // 
            // kapitalToolStripMenuItem
            // 
            this.kapitalToolStripMenuItem.Name = "kapitalToolStripMenuItem";
            this.kapitalToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.kapitalToolStripMenuItem.Text = "Sredstva";
            this.kapitalToolStripMenuItem.Click += new System.EventHandler(this.kapitalToolStripMenuItem_Click);
            // 
            // kvizToolStripMenuItem
            // 
            this.kvizToolStripMenuItem.Name = "kvizToolStripMenuItem";
            this.kvizToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.kvizToolStripMenuItem.Text = "Kviz";
            this.kvizToolStripMenuItem.Click += new System.EventHandler(this.kvizToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisnik_lbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 196);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(639, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // korisnik_lbl
            // 
            this.korisnik_lbl.Name = "korisnik_lbl";
            this.korisnik_lbl.Size = new System.Drawing.Size(66, 17);
            this.korisnik_lbl.Text = "korisnik_lbl";
            // 
            // beleska_rtxt
            // 
            this.beleska_rtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.beleska_rtxt.Location = new System.Drawing.Point(3, 0);
            this.beleska_rtxt.Name = "beleska_rtxt";
            this.beleska_rtxt.Size = new System.Drawing.Size(339, 124);
            this.beleska_rtxt.TabIndex = 2;
            this.beleska_rtxt.Text = "";
            this.beleska_rtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.beleska_rtxt_KeyDown);
            // 
            // sacuvajBelesku_btn
            // 
            this.sacuvajBelesku_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sacuvajBelesku_btn.Location = new System.Drawing.Point(3, 130);
            this.sacuvajBelesku_btn.Name = "sacuvajBelesku_btn";
            this.sacuvajBelesku_btn.Size = new System.Drawing.Size(339, 23);
            this.sacuvajBelesku_btn.TabIndex = 3;
            this.sacuvajBelesku_btn.Text = "Sacuvaj belesku";
            this.sacuvajBelesku_btn.UseVisualStyleBackColor = true;
            this.sacuvajBelesku_btn.Click += new System.EventHandler(this.sacuvajBelesku_btn_Click);
            // 
            // brzaPretragaModula_txt
            // 
            this.brzaPretragaModula_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brzaPretragaModula_txt.Location = new System.Drawing.Point(116, 3);
            this.brzaPretragaModula_txt.Name = "brzaPretragaModula_txt";
            this.brzaPretragaModula_txt.Size = new System.Drawing.Size(143, 20);
            this.brzaPretragaModula_txt.TabIndex = 4;
            this.brzaPretragaModula_txt.TextChanged += new System.EventHandler(this.brzaPretragaModula_txt_TextChanged);
            // 
            // brzaPretragaModula_lbl
            // 
            this.brzaPretragaModula_lbl.AutoSize = true;
            this.brzaPretragaModula_lbl.Location = new System.Drawing.Point(3, 6);
            this.brzaPretragaModula_lbl.Name = "brzaPretragaModula_lbl";
            this.brzaPretragaModula_lbl.Size = new System.Drawing.Size(107, 13);
            this.brzaPretragaModula_lbl.TabIndex = 5;
            this.brzaPretragaModula_lbl.Text = "Brza pretraga modula";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.beleska_rtxt);
            this.splitContainer1.Panel1.Controls.Add(this.sacuvajBelesku_btn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.brzaPretragaModula_dgv);
            this.splitContainer1.Panel2.Controls.Add(this.brzaPretragaModula_lbl);
            this.splitContainer1.Panel2.Controls.Add(this.brzaPretragaModula_txt);
            this.splitContainer1.Size = new System.Drawing.Size(615, 166);
            this.splitContainer1.SplitterDistance = 347;
            this.splitContainer1.TabIndex = 6;
            // 
            // brzaPretragaModula_dgv
            // 
            this.brzaPretragaModula_dgv.AllowUserToAddRows = false;
            this.brzaPretragaModula_dgv.AllowUserToDeleteRows = false;
            this.brzaPretragaModula_dgv.AllowUserToResizeColumns = false;
            this.brzaPretragaModula_dgv.AllowUserToResizeRows = false;
            this.brzaPretragaModula_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brzaPretragaModula_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.brzaPretragaModula_dgv.ContextMenuStrip = this.brzaPretragaModula_cms;
            this.brzaPretragaModula_dgv.Location = new System.Drawing.Point(3, 29);
            this.brzaPretragaModula_dgv.MultiSelect = false;
            this.brzaPretragaModula_dgv.Name = "brzaPretragaModula_dgv";
            this.brzaPretragaModula_dgv.ReadOnly = true;
            this.brzaPretragaModula_dgv.RowHeadersVisible = false;
            this.brzaPretragaModula_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.brzaPretragaModula_dgv.Size = new System.Drawing.Size(256, 132);
            this.brzaPretragaModula_dgv.TabIndex = 6;
            // 
            // brzaPretragaModula_cms
            // 
            this.brzaPretragaModula_cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacijeOModuluToolStripMenuItem,
            this.pokreniModulToolStripMenuItem});
            this.brzaPretragaModula_cms.Name = "brzaPretragaModula_cms";
            this.brzaPretragaModula_cms.Size = new System.Drawing.Size(190, 48);
            // 
            // informacijeOModuluToolStripMenuItem
            // 
            this.informacijeOModuluToolStripMenuItem.Name = "informacijeOModuluToolStripMenuItem";
            this.informacijeOModuluToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.informacijeOModuluToolStripMenuItem.Text = "Informacije o modulu";
            this.informacijeOModuluToolStripMenuItem.Click += new System.EventHandler(this.informacijeOModuluToolStripMenuItem_Click);
            // 
            // pokreniModulToolStripMenuItem
            // 
            this.pokreniModulToolStripMenuItem.Enabled = false;
            this.pokreniModulToolStripMenuItem.Name = "pokreniModulToolStripMenuItem";
            this.pokreniModulToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.pokreniModulToolStripMenuItem.Text = "Pokreni modul";
            this.pokreniModulToolStripMenuItem.Click += new System.EventHandler(this.pokreniModulToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 218);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(655, 214);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magacin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.brzaPretragaModula_dgv)).EndInit();
            this.brzaPretragaModula_cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dokumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prirucniMagacinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaduzenjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem razduzenjeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem proizvodnjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prijemnicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materijala3ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel korisnik_lbl;
        private System.Windows.Forms.ToolStripMenuItem poslovanjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem akcijeKomercijalisteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nedeljnaAkcijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pocetakGodineToolStripMenuItem;
        private System.Windows.Forms.RichTextBox beleska_rtxt;
        private System.Windows.Forms.Button sacuvajBelesku_btn;
        private System.Windows.Forms.TextBox brzaPretragaModula_txt;
        private System.Windows.Forms.Label brzaPretragaModula_lbl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView brzaPretragaModula_dgv;
        private System.Windows.Forms.ContextMenuStrip brzaPretragaModula_cms;
        private System.Windows.Forms.ToolStripMenuItem pokreniModulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacijeOModuluToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uspesnostMagacinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledDanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kvizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kapitalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem podesavanjaToolStripMenuItem;
    }
}