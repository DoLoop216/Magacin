namespace Magacin
{
    partial class Sredstvo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sredstvo));
            this.id_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.opis_rtxt = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.noviDokument_btn = new System.Windows.Forms.Button();
            this.sacuvaj_btn = new System.Windows.Forms.Button();
            this.odbaci_btn = new System.Windows.Forms.Button();
            this.vrsta_cmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // id_txt
            // 
            this.id_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.id_txt.Location = new System.Drawing.Point(39, 42);
            this.id_txt.Name = "id_txt";
            this.id_txt.ReadOnly = true;
            this.id_txt.Size = new System.Drawing.Size(64, 20);
            this.id_txt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Naziv:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(55, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(185, 20);
            this.textBox1.TabIndex = 2;
            // 
            // opis_rtxt
            // 
            this.opis_rtxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.opis_rtxt.Location = new System.Drawing.Point(55, 94);
            this.opis_rtxt.Name = "opis_rtxt";
            this.opis_rtxt.Size = new System.Drawing.Size(445, 96);
            this.opis_rtxt.TabIndex = 4;
            this.opis_rtxt.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Opis:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.odbaci_btn);
            this.panel1.Controls.Add(this.sacuvaj_btn);
            this.panel1.Controls.Add(this.noviDokument_btn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 28);
            this.panel1.TabIndex = 6;
            // 
            // noviDokument_btn
            // 
            this.noviDokument_btn.BackColor = System.Drawing.Color.White;
            this.noviDokument_btn.BackgroundImage = global::Magacin.Properties.Resources.newIcon;
            this.noviDokument_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noviDokument_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.noviDokument_btn.Location = new System.Drawing.Point(3, 3);
            this.noviDokument_btn.Name = "noviDokument_btn";
            this.noviDokument_btn.Size = new System.Drawing.Size(21, 20);
            this.noviDokument_btn.TabIndex = 6;
            this.noviDokument_btn.UseVisualStyleBackColor = false;
            this.noviDokument_btn.Click += new System.EventHandler(this.noviDokument_btn_Click);
            // 
            // sacuvaj_btn
            // 
            this.sacuvaj_btn.BackColor = System.Drawing.Color.White;
            this.sacuvaj_btn.BackgroundImage = global::Magacin.Properties.Resources.saveIcon;
            this.sacuvaj_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sacuvaj_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sacuvaj_btn.Location = new System.Drawing.Point(30, 3);
            this.sacuvaj_btn.Name = "sacuvaj_btn";
            this.sacuvaj_btn.Size = new System.Drawing.Size(21, 20);
            this.sacuvaj_btn.TabIndex = 7;
            this.sacuvaj_btn.UseVisualStyleBackColor = false;
            // 
            // odbaci_btn
            // 
            this.odbaci_btn.BackColor = System.Drawing.Color.White;
            this.odbaci_btn.BackgroundImage = global::Magacin.Properties.Resources.discardIcon;
            this.odbaci_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.odbaci_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.odbaci_btn.Location = new System.Drawing.Point(57, 3);
            this.odbaci_btn.Name = "odbaci_btn";
            this.odbaci_btn.Size = new System.Drawing.Size(21, 20);
            this.odbaci_btn.TabIndex = 8;
            this.odbaci_btn.UseVisualStyleBackColor = false;
            // 
            // vrsta_cmb
            // 
            this.vrsta_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vrsta_cmb.FormattingEnabled = true;
            this.vrsta_cmb.Location = new System.Drawing.Point(55, 196);
            this.vrsta_cmb.Name = "vrsta_cmb";
            this.vrsta_cmb.Size = new System.Drawing.Size(207, 21);
            this.vrsta_cmb.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Vrsta:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 223);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(452, 141);
            this.dataGridView1.TabIndex = 9;
            // 
            // Sredstvo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 376);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vrsta_cmb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.opis_rtxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_txt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sredstvo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sredstvo";
            this.Load += new System.EventHandler(this.Sredstvo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox id_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox opis_rtxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button noviDokument_btn;
        private System.Windows.Forms.Button sacuvaj_btn;
        private System.Windows.Forms.Button odbaci_btn;
        private System.Windows.Forms.ComboBox vrsta_cmb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}