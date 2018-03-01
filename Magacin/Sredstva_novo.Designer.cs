namespace Magacin
{
    partial class Sredstva_novo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sredstva_novo));
            this.naziv_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.opis_rtxt = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.magacin_cmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.vrsta_cmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kreiraj_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // naziv_txt
            // 
            this.naziv_txt.Location = new System.Drawing.Point(55, 41);
            this.naziv_txt.MaxLength = 80;
            this.naziv_txt.Name = "naziv_txt";
            this.naziv_txt.Size = new System.Drawing.Size(234, 20);
            this.naziv_txt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv:";
            // 
            // opis_rtxt
            // 
            this.opis_rtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.opis_rtxt.Location = new System.Drawing.Point(55, 67);
            this.opis_rtxt.MaxLength = 2048;
            this.opis_rtxt.Name = "opis_rtxt";
            this.opis_rtxt.Size = new System.Drawing.Size(420, 170);
            this.opis_rtxt.TabIndex = 2;
            this.opis_rtxt.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Opis:";
            // 
            // magacin_cmb
            // 
            this.magacin_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.magacin_cmb.FormattingEnabled = true;
            this.magacin_cmb.Location = new System.Drawing.Point(69, 13);
            this.magacin_cmb.Name = "magacin_cmb";
            this.magacin_cmb.Size = new System.Drawing.Size(280, 21);
            this.magacin_cmb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Magacin:";
            // 
            // vrsta_cmb
            // 
            this.vrsta_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vrsta_cmb.FormattingEnabled = true;
            this.vrsta_cmb.Location = new System.Drawing.Point(55, 243);
            this.vrsta_cmb.Name = "vrsta_cmb";
            this.vrsta_cmb.Size = new System.Drawing.Size(176, 21);
            this.vrsta_cmb.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Vrsta:";
            // 
            // kreiraj_btn
            // 
            this.kreiraj_btn.Location = new System.Drawing.Point(400, 243);
            this.kreiraj_btn.Name = "kreiraj_btn";
            this.kreiraj_btn.Size = new System.Drawing.Size(75, 23);
            this.kreiraj_btn.TabIndex = 8;
            this.kreiraj_btn.Text = "Kreiraj";
            this.kreiraj_btn.UseVisualStyleBackColor = true;
            this.kreiraj_btn.Click += new System.EventHandler(this.kreiraj_btn_Click);
            // 
            // Sredstva_novo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 276);
            this.Controls.Add(this.kreiraj_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vrsta_cmb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.magacin_cmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.opis_rtxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.naziv_txt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sredstva_novo";
            this.Text = "Novo sredstvo";
            this.Load += new System.EventHandler(this.Sredstva_novo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox naziv_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox opis_rtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox magacin_cmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox vrsta_cmb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button kreiraj_btn;
    }
}