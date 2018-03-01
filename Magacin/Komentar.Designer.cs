namespace Magacin
{
    partial class Komentar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Komentar));
            this.komentar_rtxt = new System.Windows.Forms.RichTextBox();
            this.sacuvaj_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // komentar_rtxt
            // 
            this.komentar_rtxt.Location = new System.Drawing.Point(12, 12);
            this.komentar_rtxt.Name = "komentar_rtxt";
            this.komentar_rtxt.Size = new System.Drawing.Size(451, 228);
            this.komentar_rtxt.TabIndex = 0;
            this.komentar_rtxt.Text = "";
            // 
            // sacuvaj_btn
            // 
            this.sacuvaj_btn.Location = new System.Drawing.Point(388, 246);
            this.sacuvaj_btn.Name = "sacuvaj_btn";
            this.sacuvaj_btn.Size = new System.Drawing.Size(75, 23);
            this.sacuvaj_btn.TabIndex = 1;
            this.sacuvaj_btn.Text = "Sacuvaj";
            this.sacuvaj_btn.UseVisualStyleBackColor = true;
            this.sacuvaj_btn.Click += new System.EventHandler(this.sacuvaj_btn_Click);
            // 
            // Komentar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 281);
            this.Controls.Add(this.sacuvaj_btn);
            this.Controls.Add(this.komentar_rtxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Komentar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Komentar";
            this.Load += new System.EventHandler(this.Komentar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox komentar_rtxt;
        private System.Windows.Forms.Button sacuvaj_btn;
    }
}