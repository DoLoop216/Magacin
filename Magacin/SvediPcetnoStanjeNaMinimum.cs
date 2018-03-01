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
    public partial class SvediPocetnoStanjeNaMinimum : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        private string currConString = M.Baza.connectionKomercijalno2018;
        private int brDokPocetnogStanja = -1;
        List<Int_Double> stavkePocetnogStanjaSaKolicinama = new List<Int_Double>();

        public SvediPocetnoStanjeNaMinimum()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            UcitajMagacine();
        }

        private void SvediPocetnoStanjeNaMinimum_Load(object sender, EventArgs e)
        {
            baza_cmb.SelectedIndex = 0;
            magacini_cmb.SelectedIndex = -1;
        }

        private void UcitajMagacine()
        {
            using (FbConnection con = new FbConnection(currConString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT MAGACINID, NAZIV FROM MAGACIN", con))
                {
                    List<Int_String> list = new List<Int_String>();
                    FbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        list.Add(new Int_String { _int = Convert.ToInt32(dr[0]), _string = dr[1].ToString() });
                    }

                    magacini_cmb.DataSource = list;
                    magacini_cmb.ValueMember = "_int";
                    magacini_cmb.DisplayMember = "_string";
                }
                con.Close();
            }
        }

        private void svedi_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li sigurno zelite da svedete kolicine pocetnog stanja za selektovani magacin na minimalne moguce? \nNakon pokretanja, ovu akciju ne mozete zaustaviti!", "Potvrdi!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                UcitajStavkePocetnogStanja();
            }
        }

        private void baza_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(baza_cmb.SelectedIndex)
            {
                case 0:
                    currConString = M.Baza.connectionKomercijalno2018;
                    break;
                case 1:
                    currConString = M.Baza.connectionKomercijalno2017;
                    break;
                case 2:
                    currConString = M.Baza.connectionKomercijalno2016;
                    break;
                case 3:
                    currConString = M.Baza.connectionKomercijalno2015;
                    break;

            }
        }

        private void UcitajStavkePocetnogStanja()
        {
            using (FbConnection con = new FbConnection(currConString))
            {
                con.Open();
                toolStripStatusLabel1.Text = "Provera broja dokumenta pocetnih stanja za magacin " + magacini_cmb.SelectedValue.ToString();
                //Prvo proveravam da li ima vise pocetnih stanja
                using (FbCommand cmd = new FbCommand("SELECT BRDOK, COUNT(BRDOK) FROM DOKUMENT WHERE VRDOK = 0 AND MAGACINID = @MagacinID GROUP BY BRDOK", con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacini_cmb.SelectedValue);

                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        if(Convert.ToInt32(dr[1]) > 1)
                        {
                            MessageBox.Show("Za ovaj magacin postoji vise od jednog dokumenta pocetnog stanja i akcija nece biti nastavljena!");
                            return;
                        }
                        else
                        {
                            brDokPocetnogStanja = Convert.ToInt32(dr[0]);
                        }
                    }
                }

                toolStripStatusLabel1.Text = "Selektovanje stavki iz pocetnog stanja broj " + brDokPocetnogStanja.ToString();
                //Selektujem stavke iz pocetnog stanja i uzimam samo one kojima je kolicina veca od 0
                using (FbCommand cmd = new FbCommand("SELECT ROBAID, KOLICINA FROM STAVKA WHERE VRDOK = 0 AND BRDOK = @BrDok AND KOLICINA > 0", con))
                {
                    cmd.Parameters.AddWithValue("@BrDok", brDokPocetnogStanja);

                    FbDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        stavkePocetnogStanjaSaKolicinama.Add(new Int_Double { _int = Convert.ToInt32(dr[0]), _double = Convert.ToDouble(dr[1]) });
                    }
                }

                toolStripStatusLabel1.Text = "Selektovanje brojeva sorniranih MP racuna magacina " + magacini_cmb.SelectedValue.ToString();
                List <int> storniraniMpRacuni = new List<int>();
                //Selektujem stornirane MP racune
                using (FbCommand cmd = new FbCommand("SELECT BRDOK FROM DOKUMENT WHERE KODDOK = 1 AND VRDOK = 15 AND MAGACINID = @MagacinId", con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacini_cmb.SelectedValue);

                    FbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        storniraniMpRacuni.Add(Convert.ToInt32(dr[0]));
                    }
                }

                toolStripStatusLabel1.Text = "Selektovanje minimalnih trenutnih stanja u trenutku za svaku stavku";
                //Selektujem minimalno trenutno stanje za svaku stavku
                using (FbCommand cmd = new FbCommand("SELECT VRDOK, BRDOK, TREN_STANJE FROM STAVKA WHERE MAGACINID = @MagacinID AND ROBAID = @RobaID AND TREN_STANJE = (SELECT MIN(TREN_STANJE) FROM STAVKA WHERE MAGACINID = @MagacinID AND ROBAID = @RobaID)", con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacini_cmb.SelectedValue);
                    cmd.Parameters.Add("@RobaID", FbDbType.Integer);

                    foreach (var stavkaPs in stavkePocetnogStanjaSaKolicinama)
                    {
                        cmd.Parameters["@RobaID"].Value = stavkaPs._int;

                        using (FbDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (Convert.ToInt32(dr[0]) == 15 && storniraniMpRacuni.Contains(Convert.ToInt32(dr[1])))
                                {
                                    if ((stavkaPs._double - GetTrenStanjeFromStorno(storniraniMpRacuni, (int)magacini_cmb.SelectedValue, stavkaPs._int)) < 0)
                                    {
                                        stavkaPs._double = 0;
                                    }
                                    else
                                    {
                                        stavkaPs._double = stavkaPs._double - GetTrenStanjeFromStorno(storniraniMpRacuni, (int)magacini_cmb.SelectedValue, stavkaPs._int);
                                    }
                                }
                                else
                                {
                                    if ((stavkaPs._double - Convert.ToDouble(dr[2])) < 0)
                                    {
                                        stavkaPs._double = 0;
                                    }
                                    else
                                    {
                                        stavkaPs._double = stavkaPs._double - Convert.ToDouble(dr[2]);
                                    }
                                }
                            }
                        }
                    }
                }

                toolStripStatusLabel1.Text = "Azuriranje dokumenta pocetnog stanja sa novim kolicinama";
                using (FbCommand cmd = new FbCommand("UPDATE STAVKA SET KOLICINA = @Kolicina WHERE VRDOK = 0 AND BRDOK = @BrDok AND ROBAID = @RobaID", con))
                {
                    cmd.Parameters.Add("@Kolicina", FbDbType.Decimal);
                    cmd.Parameters.AddWithValue("@BrDok", brDokPocetnogStanja);
                    cmd.Parameters.Add("@RobaID", FbDbType.Integer);

                    foreach(var item in stavkePocetnogStanjaSaKolicinama)
                    {
                        cmd.Parameters["@Kolicina"].Value = item._double;
                        cmd.Parameters["@RobaID"].Value = item._int;

                        cmd.ExecuteNonQuery();
                    }
                }
                toolStripStatusLabel1.Text = "Spreman za rad.";
                MessageBox.Show("Pocetno stanje svedeno na minimum kolicina!");
            }
        }

        public double GetTrenStanjeFromStorno(List<int> storniraniDokumenti, int magacinId, int robaId)
        {
            double minTrenStanje = double.MaxValue;
            using (FbConnection con = new FbConnection(currConString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT VRDOK, BRDOK, TREN_STANJE FROM STAVKA WHERE MAGACINID = @MagacinID AND ROBAID = @RobaID", con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@MagacinID", magacinId);
                    da.SelectCommand.Parameters.AddWithValue("@RobaID", robaId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach(DataRow row in dt.Rows)
                    {
                        if (Convert.ToInt32(row["VRDOK"]) == 15 && storniraniDokumenti.Contains(Convert.ToInt32(row["BRDOK"])))
                        {
                            row.Delete();
                        }
                        else
                        {
                            double trStanje = Convert.ToDouble(row.Field<decimal>("TREN_STANJE"));
                            minTrenStanje = Math.Min(minTrenStanje, trStanje);
                        }
                    }
                }
                con.Close();
            }
            return minTrenStanje;
        }
    }
}
