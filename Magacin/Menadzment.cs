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
    public partial class Menadzment : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public Menadzment()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
        }

        private void uporedjivanjePoGodinamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UporedjivanjePartneraPoBazama uppb = new UporedjivanjePartneraPoBazama();
            uppb.ShowDialog();
        }

        private void svediPocetnoStanjeNaMinimumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SvediPocetnoStanjeNaMinimum spsnm = new SvediPocetnoStanjeNaMinimum();
            spsnm.ShowDialog();
        }

        private void ispraviCeneNaDanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IspraviCeneNaDan icnd = new IspraviCeneNaDan();
            icnd.ShowDialog();
        }

        private void Menadzment_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                //Dodati help
            }
        }

        private void rasporediUtovareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RasporediUtovare ru = new RasporediUtovare();
            ru.Show();
        }
    }
}
