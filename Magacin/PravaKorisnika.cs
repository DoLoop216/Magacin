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
    public partial class PravaKorisnika : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }
        private _Korisnik korisnik;

        public PravaKorisnika(int korisnikId)
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
            korisnik = M.Korisnici.GetKorisnik(korisnikId);
        }

        private void PravaKorisnika_Load(object sender, EventArgs e)
        {
            UcitajPrava();   
        }

        private void UcitajPrava()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter(@"SELECT PRAVA.PRAVOID, PRAVA_DB.OPIS, PRAVA.IMA 
                    FROM PRAVA INNER JOIN
                    PRAVA_DB ON PRAVA.PRAVOID = PRAVA_DB.PRAVOID WHERE KORISNIKID = @KorisnikID", con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@KorisnikID", korisnik.korisnikId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["PRAVOID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["PRAVOID"].ReadOnly = true;
                    dataGridView1.Columns["OPIS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns["OPIS"].ReadOnly = true;
                    dataGridView1.Columns["IMA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["IMA"].ReadOnly = false;
                    dataGridView1.Sort(dataGridView1.Columns["PRAVOID"], ListSortDirection.Ascending);
                }
                con.Close();
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex] == dataGridView1.Columns["IMA"])
            {
                if(Convert.ToInt32(e.FormattedValue) != Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["IMA"].Value))
                {
                    M.Prava.Toggle(korisnik.korisnikId, Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["PRAVOID"].Value));
                }
            }
        }

        private void novoPravoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IzborPrava ip = new IzborPrava(korisnik, this);
            ip.ShowDialog();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            IzborPrava ip = new IzborPrava(korisnik, this);
            ip.ShowDialog();
        }

        public void UpdatePravo(int pravoId, string opis, int ima)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;

            DataRow row = dt.NewRow();
            row["PRAVOID"] = pravoId;
            row["OPIS"] = opis;
            row["IMA"] = ima;

            dt.Rows.Add(row);
            dataGridView1.DataSource = dt;
        }
    }
}
