namespace Magacin
{
    partial class Menadzment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menadzment));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.partneriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uporedjivanjePoGodinamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magaciniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.svediPocetnoStanjeNaMinimumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dokumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ispraviCeneNaDanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rasporediUtovareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partneriToolStripMenuItem,
            this.magaciniToolStripMenuItem,
            this.dokumentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(620, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // partneriToolStripMenuItem
            // 
            this.partneriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uporedjivanjePoGodinamaToolStripMenuItem});
            this.partneriToolStripMenuItem.Name = "partneriToolStripMenuItem";
            this.partneriToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.partneriToolStripMenuItem.Text = "Partneri";
            // 
            // uporedjivanjePoGodinamaToolStripMenuItem
            // 
            this.uporedjivanjePoGodinamaToolStripMenuItem.Name = "uporedjivanjePoGodinamaToolStripMenuItem";
            this.uporedjivanjePoGodinamaToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.uporedjivanjePoGodinamaToolStripMenuItem.Text = "Uporedjivanje po godinama";
            this.uporedjivanjePoGodinamaToolStripMenuItem.Click += new System.EventHandler(this.uporedjivanjePoGodinamaToolStripMenuItem_Click);
            // 
            // magaciniToolStripMenuItem
            // 
            this.magaciniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.svediPocetnoStanjeNaMinimumToolStripMenuItem,
            this.rasporediUtovareToolStripMenuItem});
            this.magaciniToolStripMenuItem.Name = "magaciniToolStripMenuItem";
            this.magaciniToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.magaciniToolStripMenuItem.Text = "Magacini";
            // 
            // svediPocetnoStanjeNaMinimumToolStripMenuItem
            // 
            this.svediPocetnoStanjeNaMinimumToolStripMenuItem.Name = "svediPocetnoStanjeNaMinimumToolStripMenuItem";
            this.svediPocetnoStanjeNaMinimumToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.svediPocetnoStanjeNaMinimumToolStripMenuItem.Text = "Svedi pocetno stanje na minimum";
            this.svediPocetnoStanjeNaMinimumToolStripMenuItem.Click += new System.EventHandler(this.svediPocetnoStanjeNaMinimumToolStripMenuItem_Click);
            // 
            // dokumentToolStripMenuItem
            // 
            this.dokumentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ispraviCeneNaDanToolStripMenuItem});
            this.dokumentToolStripMenuItem.Name = "dokumentToolStripMenuItem";
            this.dokumentToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.dokumentToolStripMenuItem.Text = "Dokument";
            // 
            // ispraviCeneNaDanToolStripMenuItem
            // 
            this.ispraviCeneNaDanToolStripMenuItem.Name = "ispraviCeneNaDanToolStripMenuItem";
            this.ispraviCeneNaDanToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ispraviCeneNaDanToolStripMenuItem.Text = "Ispravi cene na dan";
            this.ispraviCeneNaDanToolStripMenuItem.Click += new System.EventHandler(this.ispraviCeneNaDanToolStripMenuItem_Click);
            // 
            // rasporediUtovareToolStripMenuItem
            // 
            this.rasporediUtovareToolStripMenuItem.Name = "rasporediUtovareToolStripMenuItem";
            this.rasporediUtovareToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.rasporediUtovareToolStripMenuItem.Text = "Rasporedi utovare";
            this.rasporediUtovareToolStripMenuItem.Click += new System.EventHandler(this.rasporediUtovareToolStripMenuItem_Click);
            // 
            // Menadzment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 128);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menadzment";
            this.Text = "Menadzment";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Menadzment_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem partneriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uporedjivanjePoGodinamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magaciniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem svediPocetnoStanjeNaMinimumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dokumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ispraviCeneNaDanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rasporediUtovareToolStripMenuItem;
    }
}