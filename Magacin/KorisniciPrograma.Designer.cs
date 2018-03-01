namespace Magacin
{
    partial class KorisniciPrograma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KorisniciPrograma));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.podaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pravaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnik_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(707, 381);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.podaciToolStripMenuItem,
            this.pravaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 48);
            // 
            // podaciToolStripMenuItem
            // 
            this.podaciToolStripMenuItem.Name = "podaciToolStripMenuItem";
            this.podaciToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.podaciToolStripMenuItem.Text = "Podaci";
            this.podaciToolStripMenuItem.Click += new System.EventHandler(this.podaciToolStripMenuItem_Click);
            // 
            // pravaToolStripMenuItem
            // 
            this.pravaToolStripMenuItem.Name = "pravaToolStripMenuItem";
            this.pravaToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.pravaToolStripMenuItem.Text = "Prava";
            this.pravaToolStripMenuItem.Click += new System.EventHandler(this.pravaToolStripMenuItem_Click);
            // 
            // noviKorisnik_btn
            // 
            this.noviKorisnik_btn.BackColor = System.Drawing.Color.Transparent;
            this.noviKorisnik_btn.BackgroundImage = global::Magacin.Properties.Resources.newIcon;
            this.noviKorisnik_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noviKorisnik_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.noviKorisnik_btn.Location = new System.Drawing.Point(12, 12);
            this.noviKorisnik_btn.Name = "noviKorisnik_btn";
            this.noviKorisnik_btn.Size = new System.Drawing.Size(21, 20);
            this.noviKorisnik_btn.TabIndex = 6;
            this.noviKorisnik_btn.UseVisualStyleBackColor = false;
            this.noviKorisnik_btn.Click += new System.EventHandler(this.noviKorisnik_btn_Click);
            // 
            // KorisniciPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 431);
            this.Controls.Add(this.noviKorisnik_btn);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KorisniciPrograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Korisnici programa";
            this.Load += new System.EventHandler(this.KorisniciPrograma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem podaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pravaToolStripMenuItem;
        private System.Windows.Forms.Button noviKorisnik_btn;
    }
}