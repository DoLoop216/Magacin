namespace Magacin
{
    partial class RasporediUtovare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RasporediUtovare));
            this.magacini_cmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.meseci_cmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // magacini_cmb
            // 
            this.magacini_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.magacini_cmb.FormattingEnabled = true;
            this.magacini_cmb.Location = new System.Drawing.Point(69, 12);
            this.magacini_cmb.Name = "magacini_cmb";
            this.magacini_cmb.Size = new System.Drawing.Size(155, 21);
            this.magacini_cmb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Magacin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mesec:";
            // 
            // meseci_cmb
            // 
            this.meseci_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.meseci_cmb.FormattingEnabled = true;
            this.meseci_cmb.Items.AddRange(new object[] {
            "Januar",
            "Februar",
            "Mart",
            "April",
            "Maj",
            "Jun",
            "Jul",
            "Avgust",
            "Septembar",
            "Oktobar",
            "Novembar",
            "Decembar"});
            this.meseci_cmb.Location = new System.Drawing.Point(60, 39);
            this.meseci_cmb.Name = "meseci_cmb";
            this.meseci_cmb.Size = new System.Drawing.Size(155, 21);
            this.meseci_cmb.TabIndex = 2;
            // 
            // RasporediUtovare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 249);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.meseci_cmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.magacini_cmb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RasporediUtovare";
            this.Text = "Rasporedi utovare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox magacini_cmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox meseci_cmb;
    }
}