namespace Magacin
{
    partial class RobaAkcije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobaAkcije));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.obrisiStavkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajRobu_btn = new System.Windows.Forms.Button();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(740, 245);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obrisiStavkuToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 26);
            // 
            // obrisiStavkuToolStripMenuItem
            // 
            this.obrisiStavkuToolStripMenuItem.Name = "obrisiStavkuToolStripMenuItem";
            this.obrisiStavkuToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.obrisiStavkuToolStripMenuItem.Text = "Obrisi stavku";
            this.obrisiStavkuToolStripMenuItem.Click += new System.EventHandler(this.obrisiStavkuToolStripMenuItem_Click);
            // 
            // dodajRobu_btn
            // 
            this.dodajRobu_btn.Location = new System.Drawing.Point(12, 12);
            this.dodajRobu_btn.Name = "dodajRobu_btn";
            this.dodajRobu_btn.Size = new System.Drawing.Size(75, 23);
            this.dodajRobu_btn.TabIndex = 1;
            this.dodajRobu_btn.Text = "Dodaj robu";
            this.dodajRobu_btn.UseVisualStyleBackColor = true;
            this.dodajRobu_btn.Click += new System.EventHandler(this.dodajRobu_btn_Click);
            // 
            // RobaAkcije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 298);
            this.Controls.Add(this.dodajRobu_btn);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "RobaAkcije";
            this.Text = "Roba akcije";
            this.Load += new System.EventHandler(this.RobaAkcije_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RobaAkcije_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button dodajRobu_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem obrisiStavkuToolStripMenuItem;
    }
}