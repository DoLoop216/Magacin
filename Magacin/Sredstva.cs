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
    public partial class Sredstva : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public Sredstva()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            UcitajSvaSredstva();
        }

        private void OdrzavanjeOsnovnihSredstava_Load(object sender, EventArgs e)
        {
            magacin_cmb.DataSource = Komercijalno.UcitajMagacine();
            magacin_cmb.ValueMember = "_int";
            magacin_cmb.DisplayMember = "_string";

        }

        private void UcitajSvaSredstva()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT SREDSTVO.SREDSTVOID, SREDSTVO.NAZIV, SREDSTVO.OPIS, SREDSTVO_VRSTA.NAZIV AS VRSTA FROM SREDSTVO INNER JOIN                         SREDSTVO_VRSTA ON SREDSTVO.SREDSTVO_VRSTAID = SREDSTVO_VRSTA.SREDSTVO_VRSTAID", con))
                {
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["SREDSTVOID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["NAZIV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["OPIS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns["VRSTA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                con.Close();
            }
        }

        private void magacin_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void noviDokument_btn_Click(object sender, EventArgs e)
        {
            Sredstva_novo sn = new Sredstva_novo();
            sn.ShowDialog();
            UcitajSvaSredstva();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DetaljiSredstva();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DetaljiSredstva();
        }

        private void DetaljiSredstva()
        {
            Sredstvo s = new Sredstvo(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SREDSTVOID"].Value));
            s.ShowDialog();
        }
    }
}
