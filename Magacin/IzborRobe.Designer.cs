namespace Magacin
{
    partial class IzborRobe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzborRobe));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.filterKolone_txt = new System.Windows.Forms.TextBox();
            this.filterKolone_cmb = new System.Windows.Forms.ComboBox();
            this.kolicina_txt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(576, 289);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // filterKolone_txt
            // 
            this.filterKolone_txt.Location = new System.Drawing.Point(114, 12);
            this.filterKolone_txt.Name = "filterKolone_txt";
            this.filterKolone_txt.Size = new System.Drawing.Size(113, 20);
            this.filterKolone_txt.TabIndex = 1;
            this.filterKolone_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterKolone_txt_KeyDown);
            // 
            // filterKolone_cmb
            // 
            this.filterKolone_cmb.BackColor = System.Drawing.Color.White;
            this.filterKolone_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterKolone_cmb.FormattingEnabled = true;
            this.filterKolone_cmb.Location = new System.Drawing.Point(12, 12);
            this.filterKolone_cmb.Name = "filterKolone_cmb";
            this.filterKolone_cmb.Size = new System.Drawing.Size(96, 21);
            this.filterKolone_cmb.TabIndex = 2;
            // 
            // kolicina_txt
            // 
            this.kolicina_txt.Location = new System.Drawing.Point(12, 333);
            this.kolicina_txt.Name = "kolicina_txt";
            this.kolicina_txt.Size = new System.Drawing.Size(96, 20);
            this.kolicina_txt.TabIndex = 3;
            this.kolicina_txt.EnabledChanged += new System.EventHandler(this.kolicina_txt_EnabledChanged);
            this.kolicina_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kolicina_txt_KeyDown);
            this.kolicina_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.kolicina_txt.Leave += new System.EventHandler(this.kolicina_txt_Leave);
            // 
            // IzborRobe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 365);
            this.Controls.Add(this.kolicina_txt);
            this.Controls.Add(this.filterKolone_cmb);
            this.Controls.Add(this.filterKolone_txt);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IzborRobe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izbor robe";
            this.Load += new System.EventHandler(this.IzborRobe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox filterKolone_txt;
        private System.Windows.Forms.ComboBox filterKolone_cmb;
        private System.Windows.Forms.TextBox kolicina_txt;
    }
}