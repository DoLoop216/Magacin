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
    public partial class NoviKorisnik : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public NoviKorisnik()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
        }

        private void NoviKorisnik_Load(object sender, EventArgs e)
        {

        }

        private void kreiraj_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(korisnickoIme_txt.Text))
            {
                MessageBox.Show("Morate uneti korisnicko ime!");
                return;
            }
            if (string.IsNullOrWhiteSpace(sifra_txt.Text))
            {
                MessageBox.Show("Morate uneti lozinku!");
                return;
            }

            M.Korisnici.Novi(korisnickoIme_txt.Text, sifra_txt.Text);
            MessageBox.Show("Novi korisnik uspesno kreiran!");
        }
    }
}
