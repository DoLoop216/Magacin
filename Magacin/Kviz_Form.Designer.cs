﻿namespace Magacin
{
    partial class Kviz_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kviz_Form));
            this.zapocni_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zapocni_btn
            // 
            this.zapocni_btn.Location = new System.Drawing.Point(12, 12);
            this.zapocni_btn.Name = "zapocni_btn";
            this.zapocni_btn.Size = new System.Drawing.Size(150, 150);
            this.zapocni_btn.TabIndex = 1;
            this.zapocni_btn.Text = "Zapocni kviz";
            this.zapocni_btn.UseVisualStyleBackColor = true;
            this.zapocni_btn.Click += new System.EventHandler(this.zapocni_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 150);
            this.button1.TabIndex = 2;
            this.button1.Text = "Pregled";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(324, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 150);
            this.button2.TabIndex = 3;
            this.button2.Text = "Menadzment";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "O korisniku";
            // 
            // Kviz_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 302);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zapocni_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(505, 341);
            this.MinimumSize = new System.Drawing.Size(505, 341);
            this.Name = "Kviz_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kviz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zapocni_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}