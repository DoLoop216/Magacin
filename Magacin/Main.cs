using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Magacin
{
    public partial class Main : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public Main()
        {
            InitializeComponent();

            InitializeForm = new M.Podesavanja.Forma(this, this);

            UcitajPodatke();
            PokreniUpdate();
            UcitajTagoveModula();
        }

        private void UcitajPodatke()
        {
            bool test = false;
            var t1 = new Thread(
                () =>
                {
                    test = Komercijalno.Initialize(this);
                });
            t1.Start();
            t1.Join();
            if (test)
            {
                Obavestenje o = new Obavestenje(10, "Roba komercijalnog uspesno ucitana!");
                o.Show();
            }
            else
            {
                Obavestenje o = new Obavestenje(10, "Ucitavanje robe komercijalnog nije uspelo!");
                o.Show();
            }
        }
        private void PokreniUpdate()
        {
            new M.Update(60);
        }
        private void UcitajTagoveModula()
        {
            if (!Korisnik.ImaPravo(99999))
            {
                brzaPretragaModula_dgv.Visible = false;
                brzaPretragaModula_lbl.Visible = false;
                brzaPretragaModula_txt.Visible = false;
                return;
            }
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT DEST as PUTANJA, TAG, CLASSNAME, CLASSPAR1_V, CLASSPAR1_T FROM MODUL", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    brzaPretragaModula_dgv.DataSource = dt;
                    
                    brzaPretragaModula_dgv.Columns["PUTANJA"].Visible = false;
                    brzaPretragaModula_dgv.Columns["TAG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    brzaPretragaModula_dgv.Columns["TAG"].DisplayIndex = 0;
                    brzaPretragaModula_dgv.Columns["CLASSNAME"].Visible = false;
                    brzaPretragaModula_dgv.Columns["CLASSPAR1_V"].Visible = false;
                    brzaPretragaModula_dgv.Columns["CLASSPAR1_T"].Visible = false;
                }
                con.Close();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            korisnik_lbl.Text = String.Format("{0} [{1}]", Korisnik.nadimak, Korisnik.korisnikId);
            beleska_rtxt.Text = Korisnik.UcitajBelesku();
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void zaduzenjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Korisnik.ImaPravo(10000))
            {
                Dokument1 d1 = new Dokument1(0);
                if(!d1.IsDisposed)
                    d1.ShowDialog();
            }
            else
            {
                MessageBox.Show(String.Format("Nemate pravo pristupa modulu [{0}]", 10000));
            }
        }
        private void razduzenjeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Korisnik.ImaPravo(10001))
            {
                Dokument1 d1 = new Dokument1(1);
                if (!d1.IsDisposed)
                    d1.ShowDialog();
            }
            else
            {
                MessageBox.Show(String.Format("Nemate pravo pristupa modulu [{0}]", 10001));
            }
        }
        private void materijala3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Korisnik.ImaPravo(10003))
            {
                Dokument1 d = new Dokument1(3);
                if (!d.IsDisposed)
                    d.ShowDialog();
            }
            else
            {
                MessageBox.Show(String.Format("Nemate pravo pristupa modulu [{0}]", 10003));
            }
        }
        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Korisnik.ImaPravo(11000))
            {
                KorisniciPrograma kp = new KorisniciPrograma();
                if (!kp.IsDisposed)
                    kp.ShowDialog();
            }
            else
            {
                MessageBox.Show(String.Format("Nemate pravo pristupa modulu [{0}]", 11000));
            }
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.M)
            {
                if(Korisnik.ImaPravo(1))
                {
                    Menadzment m = new Menadzment();
                    m.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nemate prava pristupa ovom modulu [1]!");
                }
            }
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                helpWindow.ShowDialog();
            }
        }
        private void nedeljnaAkcijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Korisnik.ImaPravo(31001))
            {
                NedeljnaAkcija na = new NedeljnaAkcija();
                if (!na.IsDisposed)
                    na.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nemate prava pristupa ovom modulu [31001]!");
            }
        }
        private void pocetakGodineToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //Beleska
        private void sacuvajBelesku_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li sigurno zelite da sacuvate belesku?", "Potvrdi!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Korisnik.SacuvajBelesku(beleska_rtxt.Text);
            }
        }
        private void beleska_rtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                Korisnik.SacuvajBelesku(beleska_rtxt.Text);
            }
        }

        //Brza pretraga modula
        private void pokreniModulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(brzaPretragaModula_dgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Morate izabrati barem jedan modul!");
                return;
            }
            if (string.IsNullOrEmpty(brzaPretragaModula_dgv.SelectedRows[0].Cells["CLASSPAR1_V"].Value.ToString()))
            {
                M.KreirajFormu("Magacin", brzaPretragaModula_dgv.SelectedRows[0].Cells["CLASSNAME"].Value.ToString());
            }
            else
            {
                switch(brzaPretragaModula_dgv.SelectedRows[0].Cells["CLASSPAR1_T"].Value.ToString())
                {
                    case "int":
                        M.KreirajFormu("Magacin", brzaPretragaModula_dgv.SelectedRows[0].Cells["CLASSNAME"].Value.ToString(), Convert.ToInt32(brzaPretragaModula_dgv.SelectedRows[0].Cells["CLASSPAR1_V"].Value));
                        break;
                    default:
                        MessageBox.Show("Doslo je do greske!");
                        break;
                }
            }
        }
        private void brzaPretragaModula_txt_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)brzaPretragaModula_dgv.DataSource;
            dt.DefaultView.RowFilter = String.Format("TAG like '%{0}%'", brzaPretragaModula_txt.Text);
            brzaPretragaModula_dgv.Refresh();
        }
        private void informacijeOModuluToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uspesnostMagacinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UspesnostMagacina um = new UspesnostMagacina();
            if (!um.IsDisposed)
                um.ShowDialog();
        }

        private void pregledDanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Korisnik.ImaPravo(31003))
            {
                PregledDana pd = new PregledDana();
                if (!pd.IsDisposed)
                    pd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nemate pravo pristupa modulu 31003");
            }
        }

        private void kvizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kviz_Form kf = new Kviz_Form();
            if (!kf.IsDisposed)
                kf.ShowDialog();
        }

        private void kapitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sredstva s = new Sredstva();
            if (!s.IsDisposed)
                s.ShowDialog();
        }

        private void podesavanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Podesavanja p = new Podesavanja();
            if (!p.IsDisposed)
                p.ShowDialog();
        }
    }
}
