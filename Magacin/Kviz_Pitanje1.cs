using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magacin
{
    public partial class Kviz_Pitanje1 : Form
    {
        string naslov;
        string pitanje;
        string odgovor1;
        string odgovor2;
        string odgovor3;
        string odgovor4;
        string odgovor5;

        int nOdgovora = 0;
        int preostaloPitanja;
        int trenutnoPitanje;

        public Kviz_Pitanje1(string naslov, string pitanje, string odgovor1, string odgovor2, string odgovor3, string odgovor4, string odgovor5, int preostaloPitanja, int trenutnoPitanje)
        {
            InitializeComponent();
            this.naslov = naslov;
            this.pitanje = pitanje;
            this.odgovor1 = odgovor1;
            this.odgovor2 = odgovor2;
            this.odgovor3 = odgovor3;
            this.odgovor4 = odgovor4;
            this.odgovor5 = odgovor5;

            this.Text = naslov;
            this.preostaloPitanja = preostaloPitanja;
            this.trenutnoPitanje = trenutnoPitanje;

            richTextBox1.Text = pitanje;
            button1.Text = odgovor1;
            button2.Text = odgovor2;
            button3.Text = odgovor3;
            button4.Text = odgovor4;
            button5.Text = odgovor5;
        }

        private void Kviz1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("Pitanje {0}/{1}", trenutnoPitanje, preostaloPitanja + 1);

            if (!string.IsNullOrEmpty(odgovor1))
                nOdgovora++;
            if (!string.IsNullOrEmpty(odgovor2))
                nOdgovora++;
            if (!string.IsNullOrEmpty(odgovor3))
                nOdgovora++;
            if (!string.IsNullOrEmpty(odgovor4))
                nOdgovora++;
            if (!string.IsNullOrEmpty(odgovor5))
                nOdgovora++;

            switch (nOdgovora)
            {
                case 1:
                    button5.Visible = false;
                    button4.Visible = false;
                    button3.Visible = false;
                    button2.Visible = false;

                    button1.Width = 399;
                    button1.Location = new Point(12, 217);
                    break;
                case 2:
                    button5.Visible = false;
                    button4.Visible = false;
                    button3.Visible = false;

                    button1.Width = 196;
                    button1.Location = new Point(12, 217);
                    button2.Width = 197;
                    button2.Location = new Point(214, 217);

                    break;
                case 3:
                    button5.Visible = false;
                    button4.Visible = false;

                    button1.Width = 129;
                    button1.Location = new Point(12, 217);
                    button2.Width = 129;
                    button2.Location = new Point(147, 217);
                    button3.Width = 129;
                    button3.Location = new Point(282, 217);
                    break;
                case 4:
                    button5.Visible = false;

                    button1.Width = 95;
                    button1.Location = new Point(13, 217);
                    button2.Width = 95;
                    button2.Location = new Point(114, 217);
                    button3.Width = 95;
                    button3.Location = new Point(215, 217);
                    button4.Width = 95;
                    button4.Location = new Point(316, 217);
                    break;
                default:
                    button1.Width = 75;
                    button1.Location = new Point(13, 217);
                    button2.Width = 75;
                    button2.Location = new Point(94, 217);
                    button3.Width = 75;
                    button3.Location = new Point(175, 217);
                    button4.Width = 75;
                    button4.Location = new Point(256, 217);
                    button5.Width = 75;
                    button5.Location = new Point(335, 217);
                    break;
            }
        }
    }
}
