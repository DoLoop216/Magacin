namespace Magacin
{
    partial class PocetakGodine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocetakGodine));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pocni_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(456, 240);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Pocetak godine se radi samo kada se pocinje nova godina odnosno rad u novoj bazi " +
    "i zahteva da se korisnik trenutno nalazi u bazi prethodne (stare) godine.";
            // 
            // pocni_btn
            // 
            this.pocni_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pocni_btn.Location = new System.Drawing.Point(372, 258);
            this.pocni_btn.Name = "pocni_btn";
            this.pocni_btn.Size = new System.Drawing.Size(96, 23);
            this.pocni_btn.TabIndex = 1;
            this.pocni_btn.Text = "Pocni";
            this.pocni_btn.UseVisualStyleBackColor = true;
            // 
            // PocetakGodine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 293);
            this.Controls.Add(this.pocni_btn);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PocetakGodine";
            this.Text = "Pocetak godine";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button pocni_btn;
    }
}