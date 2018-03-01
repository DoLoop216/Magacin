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
    public partial class NedeljnaAkcija : Form, MForm
    {
        private class AkcijskiArtikal
        {
            public int robaid { get; set; }
            public double mpCena { get; set; }
            public double akcijskaCena { get; set; }
            public double kolicina { get; set; }
            public double vrednost { get; set; }
            public double popust { get; set; }
            public double stanje { get; set; }
            public double maxKolicina { get; set; }
        }

        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        bool ucitano = false;
        DataTable dt1 = new DataTable(); //Sadrzi podatke o robi vezane za akciju

        AkcijskiArtikal aa = new AkcijskiArtikal();

        public NedeljnaAkcija()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
            UcitajRobuAkcije();
        }

        private void NedeljnaAkcija_Load(object sender, EventArgs e)
        {
            izborAkcije_cmb.SelectedIndex = -1;
            ucitano = true;
            izborAkcije_cmb.SelectedIndex = -1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        } //Dozvoljava samo unos cifara
        private void UcitajRobuAkcije()
        {
            DataTable dt_Komercijalno = Komercijalno.robaTable.Clone();
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT ROBAID, POPUST, KOLICINA, TRSTANJE, MAX_KOLICINA FROM LISTASTAVKE WHERE LISTAID = @ListaID", con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@ListaID", M.Podesavanja.ListeID.RobaAkcije);

                    da.Fill(dt1);
                }
            }
            
            foreach (DataRow dr in dt1.Rows)
            {
                DataRow dataRow = Komercijalno.robaTable.Select(String.Format("ROBAID = {0}", dr.Field<int>("ROBAID"))).FirstOrDefault();
                dt_Komercijalno.Rows.Add(dataRow.ItemArray);
            }

            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["ROBAID"] };
            dt_Komercijalno.PrimaryKey = new DataColumn[] { dt_Komercijalno.Columns["ROBAID"] };

            dt1.Merge(dt_Komercijalno);
                
            List<Int_String> list = new List<Int_String>();
            foreach (DataRow dr in dt1.Rows)
            {
                list.Add(new Int_String { _int = Convert.ToInt32(dr["ROBAID"]), _string = String.Format("{0}", dr["NAZIV"]) });
            }

            izborAkcije_cmb.DataSource = list;
            izborAkcije_cmb.DisplayMember = "_string";
            izborAkcije_cmb.ValueMember = "_int";
        } //Ucitava podatke o roobi vezane za akciju

        private void izborAkcije_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ucitano)
            {
                UcitajArtikal();
            }
        }

        private void UcitajArtikal()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("CENE_NA_DAN", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("MAGACINID", FbDbType.Integer).Value = 12;
                    cmd.Parameters.Add("ROBAID", FbDbType.Integer).Value = izborAkcije_cmb.SelectedValue;
                    cmd.Parameters.Add("DATUM", FbDbType.Date).Value = DateTime.Now;

                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        aa = IzdvojArtikal((int)izborAkcije_cmb.SelectedValue, Convert.ToDouble(dr["PRODAJNACENA"]));
                        mpCena_lbl.Text = String.Format("MP Cena: {0:#.00} din", aa.mpCena);
                        akcijskaCena_lbl.Text = String.Format("Akcijska cena: {0:#.00} din", aa.akcijskaCena);
                        popust_lbl.Text = String.Format("Popust: {0}%", aa.popust);
                        kolicina_lbl.Text = String.Format("Kolicina: {0}", aa.kolicina);
                        vrednost_lbl.Text = String.Format("Vrednost: {0:#.00} din", aa.vrednost);
                        preostalaKolicina_lbl.Text = String.Format("Preostala kolicina: {0:#.00}", aa.stanje);
                    }
                }
                con.Close();
            }
        }

        private AkcijskiArtikal IzdvojArtikal(int robaid, double prodajnaCena)
        {
            AkcijskiArtikal a = new AkcijskiArtikal();
            foreach(DataRow dr in dt1.Rows)
            {
                if(Convert.ToInt32(dr["ROBAID"]) == robaid)
                {
                    a.robaid = robaid;
                    a.mpCena = prodajnaCena;
                    a.popust = Convert.ToDouble(dr["POPUST"]);
                    a.akcijskaCena = a.mpCena - (a.mpCena * (a.popust / 100));
                    a.kolicina = Convert.ToDouble(dr["KOLICINA"]);
                    a.vrednost = a.kolicina * a.akcijskaCena;
                    a.stanje = (dr["TRSTANJE"] is DBNull) ? 0 : Convert.ToDouble(dr["TRSTANJE"]);
                    a.maxKolicina = Convert.ToDouble(dr["MAX_KOLICINA"]);
                    return a;
                }
            }
            return a;
        }

        private void izmeni_btn_Click(object sender, EventArgs e)
        {
            if(Korisnik.ImaPravo(99311))
            {
                RobaAkcije ra = new RobaAkcije();
                ra.ShowDialog();
                ucitano = false;
                UcitajRobuAkcije();
                ucitano = true;
            }
            else
            {
                MessageBox.Show("Nemate prava pristupa modulu [99311]!");
            }
        }

        private void unesi_btn_Click(object sender, EventArgs e)
        {
            if(izborAkcije_cmb.SelectedValue == null || Convert.ToInt32(izborAkcije_cmb.SelectedValue) <= 0)
            {
                MessageBox.Show("Morate izabrati barem jedan akcijski artika");
                return;
            }
            if(M.Akcija.NedeljnaAkcija.TrenutnoStanje(Convert.ToInt32(izborAkcije_cmb.SelectedValue)) <= 0)
            {
                MessageBox.Show("Nemate vise kolicina na raspolaganju!");
                return;
            }
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT FLAG, NUID FROM DOKUMENT WHERE VRDOK = 15 AND BRDOK = @BrDok", con))
                {
                    cmd.Parameters.AddWithValue("@BrDok", textBox1.Text);

                    FbDataReader dr = cmd.ExecuteReader();

                    if(!dr.Read())
                    {
                        MessageBox.Show("Racun nije pronadjen u bazi!");
                        return;
                    }
                    else
                    {
                        if(Convert.ToInt32(dr[0]) != 0)
                        {
                            MessageBox.Show("Dokument mora biti otkljucan!");
                            return;
                        }
                        if(Convert.ToInt32(dr[1]) != 5)
                        {
                            MessageBox.Show("Nacin uplate mora biti gotovinski!");
                            return;
                        }
                    }
                }
                double kol = aa.kolicina;
                double vred = aa.vrednost;
                if(aa.kolicina == 0)
                {
                    MessageBoxWithValue msg = new MessageBoxWithValue("Unesite kolicinu", "Unesite zeljenu kolicinu. Maksimum: " + ((aa.maxKolicina > aa.stanje) ? aa.stanje : aa.maxKolicina).ToString());
                    msg.brojevi = true;
                    msg.maxBroj = (aa.maxKolicina > aa.stanje) ? aa.stanje : aa.maxKolicina;
                    msg.ShowDialog();

                    if(msg.DialogResult == DialogResult.OK)
                    {
                        kol = Convert.ToDouble(msg.returnValue);
                        vred = Convert.ToDouble(msg.returnValue) * aa.mpCena;
                    }
                    else
                    {
                        return;
                    }
                }
                using (FbCommand cmd = new FbCommand("NAPRAVISTAVKU", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("VRDOK", FbDbType.Integer).Value = 15;
                    cmd.Parameters.Add("BRDOK", FbDbType.Integer).Value = Convert.ToInt32(textBox1.Text);
                    cmd.Parameters.Add("ROBAID", FbDbType.Integer).Value = Convert.ToInt32(izborAkcije_cmb.SelectedValue);
                    cmd.Parameters.Add("CENA_BEZ_PDV", FbDbType.Double).Value = 0;
                    cmd.Parameters.Add("KOL", FbDbType.Double).Value = kol;
                    cmd.Parameters.Add("RABAT", FbDbType.Double).Value = aa.popust;

                    int? result = Convert.ToInt32(cmd.ExecuteScalar());
                    if(result != null)
                    {
                        MessageBox.Show("Uspesno ste dodali akcijski artikal!");
                    }
                    Int_String selectedValue = izborAkcije_cmb.SelectedItem as Int_String;
                    M.Baza.Magacin.ZapisiIstorijuKomercijalno(modulId, Convert.ToInt32(izborAkcije_cmb.SelectedValue), kol, aa.popust, 15, Convert.ToInt32(textBox1.Text), selectedValue._string);
                    M.Akcija.NedeljnaAkcija.OduzmiSaStanja(Convert.ToInt32(izborAkcije_cmb.SelectedValue), kol);
                }
                using (FbCommand cmd = new FbCommand("PRESABERIDOKUMENT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("VRDOK", FbDbType.Integer).Value = 15;
                    cmd.Parameters.Add("BRDOK", FbDbType.Integer).Value = Convert.ToInt32(textBox1.Text);

                    cmd.ExecuteNonQuery();
                }
                using (FbCommand cmd = new FbCommand("UPDATE DOKUMENT SET FLAG = 1, UPLACENO = ((SELECT UPLACENO FROM DOKUMENT WHERE VRDOK = 15 AND BRDOK = @BrDok) + @Vrednost) WHERE VRDOK = 15 AND BRDOK = @BrDok", con))
                {
                    cmd.Parameters.AddWithValue("@BrDok", Convert.ToInt32(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Vrednost", vred);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                this.Close();
            }
        }

        private void NedeljnaAkcija_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                //Dodati help
            }

            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.K)
            {
                KarticaNedeljneAkcije kna = new KarticaNedeljneAkcije();
                kna.ShowDialog();
            }
        }
    }
}
