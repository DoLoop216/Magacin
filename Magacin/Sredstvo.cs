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
    public partial class Sredstvo : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        int sredstvoId;

        public Sredstvo(int sredstvoId)
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            this.sredstvoId = sredstvoId;

            UcitajSredstvo();

            sacuvaj_btn.Enabled = false;
            odbaci_btn.Enabled = false;
        }        

        private void Sredstvo_Load(object sender, EventArgs e)
        {

        }

        private void noviDokument_btn_Click(object sender, EventArgs e)
        {
            Sredstva_novo sn = new Sredstva_novo();
            sn.ShowDialog();
        }

        private void UcitajSredstvo()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT * FROM SREDSTVO_TROSAK WHERE SREDSTVOID = @ID", con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@ID", sredstvoId);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                    con.Close();
            }
        }
    }
}
