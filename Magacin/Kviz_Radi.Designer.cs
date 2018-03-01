namespace Magacin
{
    partial class Kviz_Radi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kviz_Radi));
            this.pokreni_btn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.brojPitanja_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pokreni_btn
            // 
            this.pokreni_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pokreni_btn.Location = new System.Drawing.Point(12, 219);
            this.pokreni_btn.Name = "pokreni_btn";
            this.pokreni_btn.Size = new System.Drawing.Size(415, 23);
            this.pokreni_btn.TabIndex = 0;
            this.pokreni_btn.Text = "Pokreni";
            this.pokreni_btn.UseVisualStyleBackColor = true;
            this.pokreni_btn.Click += new System.EventHandler(this.pokreni_btn_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(320, 199);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // brojPitanja_lbl
            // 
            this.brojPitanja_lbl.AutoSize = true;
            this.brojPitanja_lbl.Location = new System.Drawing.Point(338, 12);
            this.brojPitanja_lbl.Name = "brojPitanja_lbl";
            this.brojPitanja_lbl.Size = new System.Drawing.Size(77, 13);
            this.brojPitanja_lbl.TabIndex = 2;
            this.brojPitanja_lbl.Text = "Broj pitanja: 58";
            // 
            // Kviz_Radi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 254);
            this.Controls.Add(this.brojPitanja_lbl);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pokreni_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Kviz_Radi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kviz";
            this.Load += new System.EventHandler(this.RadiKviz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pokreni_btn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label brojPitanja_lbl;
    }
}