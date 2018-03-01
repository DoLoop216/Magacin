using FirebirdSql.Data.FirebirdClient;
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
    public partial class KorisniciPrograma : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public KorisniciPrograma()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
        }

        private void KorisniciPrograma_Load(object sender, EventArgs e)
        {
            UcitajKorisnike();
        }

        private void UcitajKorisnike()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT * FROM KORISNICI", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["KORISNIKID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["KORISNIK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns["SIFRA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Sort(dataGridView1.Columns["KORISNIKID"], ListSortDirection.Ascending);
                }
                con.Close();
            }
        }

        private void pravaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Korisnik.ImaPravo(11002))
            {
                PravaKorisnika pk = new PravaKorisnika(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KORISNIKID"].Value));
                pk.Show();
            }
            else
            {
                MessageBox.Show(String.Format("Nemate prava pristupa modulu [{0}]", 11002));
            }
        }

        private void podaciToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void noviKorisnik_btn_Click(object sender, EventArgs e)
        {
            NoviKorisnik nk = new NoviKorisnik();
            nk.ShowDialog();
            UcitajKorisnike();
        }
    }
}
