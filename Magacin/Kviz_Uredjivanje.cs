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
    public partial class Kviz_Uredjivanje : Form
    {
        public Kviz_Uredjivanje()
        {
            InitializeComponent();
        }

        private void grupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kviz_Grupe kg = new Kviz_Grupe();
            kg.ShowDialog();
        }

        private void classicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kviz_Pitanje1_Novo k = new Kviz_Pitanje1_Novo();
            k.ShowDialog();
        }

        private void pregledPitanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kviz_Pregled_Pitanja kpp = new Kviz_Pregled_Pitanja();
            kpp.Show();
        }
    }
}
