namespace Magacin
{
    partial class SvediPocetnoStanjeNaMinimum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SvediPocetnoStanjeNaMinimum));
            this.svedi_btn = new System.Windows.Forms.Button();
            this.baza_cmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.magacini_cmb = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // svedi_btn
            // 
            this.svedi_btn.Location = new System.Drawing.Point(283, 37);
            this.svedi_btn.Name = "svedi_btn";
            this.svedi_btn.Size = new System.Drawing.Size(75, 23);
            this.svedi_btn.TabIndex = 0;
            this.svedi_btn.Text = "Svedi";
            this.svedi_btn.UseVisualStyleBackColor = true;
            this.svedi_btn.Click += new System.EventHandler(this.svedi_btn_Click);
            // 
            // baza_cmb
            // 
            this.baza_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baza_cmb.FormattingEnabled = true;
            this.baza_cmb.Items.AddRange(new object[] {
            "2018",
            "2017",
            "2016",
            "2015"});
            this.baza_cmb.Location = new System.Drawing.Point(52, 12);
            this.baza_cmb.Name = "baza_cmb";
            this.baza_cmb.Size = new System.Drawing.Size(128, 21);
            this.baza_cmb.TabIndex = 2;
            this.baza_cmb.SelectedIndexChanged += new System.EventHandler(this.baza_cmb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baza:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Magacin:";
            // 
            // magacini_cmb
            // 
            this.magacini_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.magacini_cmb.FormattingEnabled = true;
            this.magacini_cmb.Location = new System.Drawing.Point(69, 39);
            this.magacini_cmb.Name = "magacini_cmb";
            this.magacini_cmb.Size = new System.Drawing.Size(190, 21);
            this.magacini_cmb.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 75);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(381, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel1.Text = "Spreman za rad.";
            // 
            // SvediPocetnoStanjeNaMinimum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 97);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.magacini_cmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.baza_cmb);
            this.Controls.Add(this.svedi_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(397, 136);
            this.Name = "SvediPocetnoStanjeNaMinimum";
            this.Text = "Svedi pocetno stanje na minimum";
            this.Load += new System.EventHandler(this.SvediPocetnoStanjeNaMinimum_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button svedi_btn;
        private System.Windows.Forms.ComboBox baza_cmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox magacini_cmb;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}