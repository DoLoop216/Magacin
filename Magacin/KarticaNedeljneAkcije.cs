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
    public partial class KarticaNedeljneAkcije : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public KarticaNedeljneAkcije()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
        }

        private void KarticaNedeljneAkcije_Load(object sender, EventArgs e)
        {
            UcitajKarticu();
        }

        private void UcitajKarticu()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT STAVKAKOM.VRDOKKOM AS VRDOK, STAVKAKOM.BRDOKKOM AS BRDOK, STAVKAKOM.NAZIV, STAVKAKOM.KOLICINA, STAVKAKOM.RABAT, KORISNICI.KORISNIK, STAVKAKOM.ROBAID, STAVKAKOM.DATUM FROM STAVKAKOM LEFT JOIN KORISNICI ON STAVKAKOM.KORISNIKID = KORISNICI.KORISNIKID ORDER BY DATUM DESC, BRDOK DESC", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["VRDOK"].DisplayIndex = 0;
                    dataGridView1.Columns["VRDOK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["BRDOK"].DisplayIndex = 1;
                    dataGridView1.Columns["BRDOK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["NAZIV"].DisplayIndex = 3;
                    dataGridView1.Columns["NAZIV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns["KOLICINA"].DisplayIndex = 4;
                    dataGridView1.Columns["KOLICINA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["RABAT"].DisplayIndex = 5;
                    dataGridView1.Columns["RABAT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["KORISNIK"].DisplayIndex = 6;
                    dataGridView1.Columns["KORISNIK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["DATUM"].DisplayIndex = 2;
                    dataGridView1.Columns["DATUM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["ROBAID"].Visible = false;
                }
                con.Close();
            }
        }

        private void KarticaNedeljneAkcije_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                //Dodati help
            }
        }
    }
}
