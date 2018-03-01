namespace Magacin
{
    partial class IspraviCeneNaDan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IspraviCeneNaDan));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ucitaj_btn = new System.Windows.Forms.Button();
            this.ispravi_btn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vrstaDokumenta_cmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.baze_cmb = new System.Windows.Forms.ComboBox();
            this.kandidati_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Broj dokumenta:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(505, 108);
            this.dataGridView1.TabIndex = 2;
            // 
            // ucitaj_btn
            // 
            this.ucitaj_btn.Location = new System.Drawing.Point(278, 66);
            this.ucitaj_btn.Name = "ucitaj_btn";
            this.ucitaj_btn.Size = new System.Drawing.Size(75, 20);
            this.ucitaj_btn.TabIndex = 3;
            this.ucitaj_btn.Text = "Ucitaj dokument";
            this.ucitaj_btn.UseVisualStyleBackColor = true;
            this.ucitaj_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ispravi_btn
            // 
            this.ispravi_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ispravi_btn.Location = new System.Drawing.Point(450, 344);
            this.ispravi_btn.Name = "ispravi_btn";
            this.ispravi_btn.Size = new System.Drawing.Size(75, 23);
            this.ispravi_btn.TabIndex = 4;
            this.ispravi_btn.Text = "Ispravi";
            this.ispravi_btn.UseVisualStyleBackColor = true;
            this.ispravi_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(505, 118);
            this.dataGridView2.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 92);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(513, 246);
            this.splitContainer1.SplitterDistance = 116;
            this.splitContainer1.TabIndex = 6;
            // 
            // vrstaDokumenta_cmb
            // 
            this.vrstaDokumenta_cmb.FormattingEnabled = true;
            this.vrstaDokumenta_cmb.Location = new System.Drawing.Point(108, 39);
            this.vrstaDokumenta_cmb.Name = "vrstaDokumenta_cmb";
            this.vrstaDokumenta_cmb.Size = new System.Drawing.Size(164, 21);
            this.vrstaDokumenta_cmb.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Vrsta dokumenta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Baza:";
            // 
            // baze_cmb
            // 
            this.baze_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baze_cmb.FormattingEnabled = true;
            this.baze_cmb.Items.AddRange(new object[] {
            "2018",
            "2017",
            "2016",
            "2015"});
            this.baze_cmb.Location = new System.Drawing.Point(52, 12);
            this.baze_cmb.Name = "baze_cmb";
            this.baze_cmb.Size = new System.Drawing.Size(79, 21);
            this.baze_cmb.TabIndex = 9;
            this.baze_cmb.SelectedIndexChanged += new System.EventHandler(this.baze_cmb_SelectedIndexChanged);
            // 
            // kandidati_btn
            // 
            this.kandidati_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kandidati_btn.Location = new System.Drawing.Point(366, 65);
            this.kandidati_btn.Name = "kandidati_btn";
            this.kandidati_btn.Size = new System.Drawing.Size(155, 23);
            this.kandidati_btn.TabIndex = 11;
            this.kandidati_btn.Text = "Prikazi kandidate ispravke";
            this.kandidati_btn.UseVisualStyleBackColor = true;
            this.kandidati_btn.Click += new System.EventHandler(this.kandidati_btn_Click);
            // 
            // IspraviCeneNaDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 379);
            this.Controls.Add(this.kandidati_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baze_cmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vrstaDokumenta_cmb);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ispravi_btn);
            this.Controls.Add(this.ucitaj_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(553, 418);
            this.Name = "IspraviCeneNaDan";
            this.Text = "Ispravi cene na dan [komercijalno]";
            this.Load += new System.EventHandler(this.IspraviCeneNaDan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ucitaj_btn;
        private System.Windows.Forms.Button ispravi_btn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox vrstaDokumenta_cmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox baze_cmb;
        private System.Windows.Forms.Button kandidati_btn;
    }
}