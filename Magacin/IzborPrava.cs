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
    public partial class IzborPrava : Form, MForm
    {
        _Korisnik korisnik;
        PravaKorisnika pravaKorisnika;

        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public IzborPrava(_Korisnik korisnik, PravaKorisnika pravaKorisnika)
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            this.korisnik = korisnik;
            this.pravaKorisnika = pravaKorisnika;
        }

        private void IzborPrava_Load(object sender, EventArgs e)
        {
            UcitajPresotalaPrava();
        }

        private void UcitajPresotalaPrava()
        {
            DataTable Prava = new DataTable();
            List<int> pravaKorisnika = new List<int>();

            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT PRAVOID, OPIS FROM PRAVA_DB", con))
                {
                    da.Fill(Prava);
                }

                using (FbCommand cmd = new FbCommand("SELECT PRAVOID FROM PRAVA WHERE KORISNIKID = @KorisnikID", con))
                {
                    cmd.Parameters.AddWithValue("KorisnikID", korisnik.korisnikId);

                    FbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        pravaKorisnika.Add(Convert.ToInt32(dr[0]));
                    }
                }
                con.Close();
            }

            foreach(int p in pravaKorisnika)
            {
                foreach(DataRow d in Prava.Rows)
                {
                    if(Convert.ToInt32(d["PRAVOID"]) == p)
                    {
                        Prava.Rows.Remove(d);
                        break;
                    }
                }
            }

            dataGridView1.DataSource = Prava;
            dataGridView1.Columns["PRAVOID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["OPIS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Sort(dataGridView1.Columns["PRAVOID"], ListSortDirection.Ascending);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dr =MessageBox.Show("Da li zelite odmah omoguciti korisniku ovo pravo?", "Potvrdi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                M.Prava.Dodaj(korisnik.korisnikId, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PRAVOID"].Value), 1);
                pravaKorisnika.UpdatePravo(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PRAVOID"].Value), dataGridView1.Rows[e.RowIndex].Cells["OPIS"].Value.ToString(), 1);
            }
            else
            { 
                M.Prava.Dodaj(korisnik.korisnikId, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PRAVOID"].Value));
                pravaKorisnika.UpdatePravo(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PRAVOID"].Value), dataGridView1.Rows[e.RowIndex].Cells["OPIS"].Value.ToString(), 0);
            }
            dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
        }
    }
}
