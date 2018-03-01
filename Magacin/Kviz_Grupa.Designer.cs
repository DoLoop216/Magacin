namespace Magacin
{
    partial class Kviz_Grupa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kviz_Grupa));
            this.sacuvaj_btn = new System.Windows.Forms.Button();
            this.id_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.naziv_txt = new System.Windows.Forms.TextBox();
            this.ponisti_btn = new System.Windows.Forms.Button();
            this.forma_cmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.brojPitanja_num = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.brojPitanja_num)).BeginInit();
            this.SuspendLayout();
            // 
            // sacuvaj_btn
            // 
            this.sacuvaj_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sacuvaj_btn.Location = new System.Drawing.Point(233, 115);
            this.sacuvaj_btn.Name = "sacuvaj_btn";
            this.sacuvaj_btn.Size = new System.Drawing.Size(75, 23);
            this.sacuvaj_btn.TabIndex = 0;
            this.sacuvaj_btn.Text = "Sacuvaj";
            this.sacuvaj_btn.UseVisualStyleBackColor = true;
            this.sacuvaj_btn.Click += new System.EventHandler(this.sacuvaj_btn_Click);
            // 
            // id_txt
            // 
            this.id_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.id_txt.Location = new System.Drawing.Point(39, 12);
            this.id_txt.Name = "id_txt";
            this.id_txt.Size = new System.Drawing.Size(86, 20);
            this.id_txt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Naziv:";
            // 
            // naziv_txt
            // 
            this.naziv_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.naziv_txt.Location = new System.Drawing.Point(55, 38);
            this.naziv_txt.Name = "naziv_txt";
            this.naziv_txt.Size = new System.Drawing.Size(253, 20);
            this.naziv_txt.TabIndex = 3;
            // 
            // ponisti_btn
            // 
            this.ponisti_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ponisti_btn.Location = new System.Drawing.Point(152, 115);
            this.ponisti_btn.Name = "ponisti_btn";
            this.ponisti_btn.Size = new System.Drawing.Size(75, 23);
            this.ponisti_btn.TabIndex = 5;
            this.ponisti_btn.Text = "Ponisti";
            this.ponisti_btn.UseVisualStyleBackColor = true;
            this.ponisti_btn.Click += new System.EventHandler(this.ponisti_btn_Click);
            // 
            // forma_cmb
            // 
            this.forma_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.forma_cmb.FormattingEnabled = true;
            this.forma_cmb.Location = new System.Drawing.Point(55, 64);
            this.forma_cmb.Name = "forma_cmb";
            this.forma_cmb.Size = new System.Drawing.Size(205, 21);
            this.forma_cmb.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Forma:";
            // 
            // brojPitanja_num
            // 
            this.brojPitanja_num.Location = new System.Drawing.Point(80, 91);
            this.brojPitanja_num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.brojPitanja_num.Name = "brojPitanja_num";
            this.brojPitanja_num.Size = new System.Drawing.Size(64, 20);
            this.brojPitanja_num.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Broj pitanja:";
            // 
            // Kviz_Grupa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 150);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.brojPitanja_num);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.forma_cmb);
            this.Controls.Add(this.ponisti_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.naziv_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_txt);
            this.Controls.Add(this.sacuvaj_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Kviz_Grupa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Izmeni grupu";
            this.Load += new System.EventHandler(this.Kviz_Grupa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brojPitanja_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox id_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox naziv_txt;
        private System.Windows.Forms.Button sacuvaj_btn;
        private System.Windows.Forms.Button ponisti_btn;
        private System.Windows.Forms.ComboBox forma_cmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown brojPitanja_num;
        private System.Windows.Forms.Label label4;
    }
}