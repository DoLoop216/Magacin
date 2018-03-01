using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Magacin
{
    public partial class Dokument1 : Form, MForm
    {
        public bool valid { get; set; }
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public int vrDok;
        public int brDok;
        public int flag;
        int magacinId;
        int pretvorenUVrDok;
        int pretvorenUBrDok;
        int pretvorenUVrDokKomercijalno;
        int pretvorenUBrDokKomercijalno;
        public string komentar;
        int ppid;
        
        private bool ucitano = false;
        private DataTable robaData;
        private DataTable izborRobeDT;

        public Dokument1(int vrdok)
        {
            InitializeComponent();

            InitializeForm = new M.Podesavanja.Forma(this, this);

            this.vrDok = vrdok;
            this.brDok = M.Baza.Magacin.Dokument.GetMaxBrDok(vrDok);

            Thread tr1;
            tr1 = new Thread(UcitajDTIzboraRobe);
            tr1.Start();

            sacuvaj_btn.Enabled = false;
            odbaci_btn.Enabled = false;
            magacini_cmb.Enabled = false;
            izborPartnera_cmb.Enabled = false;

            izborRobeDT = new DataTable();
            robaData = new DataTable();

            UcitajRobuKomercijalnog();
            switch(vrDok)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 3:
                    UcitajProizvodnje();
                    break;
                default:
                    UcitajMagacine();
                    break;
            }

            UcitajMagacine();
            RazvrstajDokument();
            UcitajPartnere();
        }
        private void Dokument1_Load(object sender, EventArgs e)
        {
            UcitajDokument();
        }

        private void RazvrstajDokument()
        {
            switch (vrDok)
            {
                case 0: //Zaduzenje
                    this.Text = "Dokument zaduzenja [0]";
                    break;
                case 1: //Razduzenje
                    this.Text = "Razduzenje [1]";
                    break;
            }
        }
        private void UcitajDokument()
        {
            ReSetupDokument();

            DataTable dt_Magacin = new DataTable();
            DataTable dt_Komercijalno = robaData.Clone();

            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();

                //=============================================================
                using (FbCommand cmd = new FbCommand("SELECT FLAG, PRETVOREN_U_VRDOK, PRETVOREN_U_BRDOK, PRETVOREN_U_VRDOK_KOMERCIJALNO, PRETVOREN_U_BRDOK_KOMERCIJALNO, ZA_MAGACINID, KOMENTAR, PPID FROM DOKUMENT WHERE VRDOK = @VrDok AND BRDOK = @BrDok", con))
                {
                    cmd.Parameters.AddWithValue("@VrDok", vrDok);
                    cmd.Parameters.AddWithValue("@BrDok", brDok);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        flag = Convert.ToInt32(dr[0]);
                        pretvorenUVrDok = (dr[1] is DBNull) ? -1 : Convert.ToInt32(dr[1]);
                        pretvorenUBrDok = (dr[2] is DBNull) ? -1 : Convert.ToInt32(dr[2]);
                        pretvorenUVrDokKomercijalno = (dr[3] is DBNull) ? -1 : Convert.ToInt32(dr[3]);
                        pretvorenUBrDokKomercijalno = (dr[4] is DBNull) ? -1 : Convert.ToInt32(dr[4]);
                        magacinId = Convert.ToInt32(dr[5]);
                        komentar = dr[6].ToString();
                        ppid = (dr[7] is DBNull) ? -1 : Convert.ToInt32(dr[7]);
                    }
                }

                //=============================================================
                using (FbDataAdapter da = new FbDataAdapter("SELECT STAVKAID, ROBAID, KOLICINA FROM STAVKA WHERE VRDOK = @VrDok AND BRDOK = @BrDok", con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@VrDok", vrDok);
                    da.SelectCommand.Parameters.AddWithValue("@BrDok", brDok);

                    da.Fill(dt_Magacin);
                }
               
                foreach(DataRow dr in dt_Magacin.Rows)
                {
                    DataRow dataRow = robaData.Select(String.Format("ROBAID = {0}", dr.Field<int>("ROBAID"))).FirstOrDefault();
                    dt_Komercijalno.Rows.Add(dataRow.ItemArray);
                }

                dt_Magacin.PrimaryKey = new DataColumn[] { dt_Magacin.Columns["ROBAID"] };
                dt_Komercijalno.PrimaryKey = new DataColumn[] { dt_Komercijalno.Columns["ROBAID"] };

                dt_Magacin.Merge(dt_Komercijalno);
                dataGridView1.DataSource = dt_Magacin;

                NamestiDataGridView();

                //=============================================================
                con.Close();
            }

            SetupDokument();
        }
        private void SetupDokument()
        {
            brDok_txt.Text = brDok.ToString();
            pretvorenUVrDokLok_txt.Text = (pretvorenUVrDok >= 0) ? pretvorenUVrDok.ToString() : "";
            pretvorenUBrDokLok_txt.Text = (pretvorenUBrDok >= 0) ? pretvorenUBrDok.ToString() : "";
            pretvorenUVrDokKom_txt.Text = (pretvorenUVrDokKomercijalno >= 0) ? pretvorenUVrDokKomercijalno.ToString() : "";
            pretvorenUBrDokKom_txt.Text = (pretvorenUBrDokKomercijalno >= 0) ? pretvorenUBrDokKomercijalno.ToString() : "";
            magacini_cmb.SelectedValue = magacinId;
            izborPartnera_cmb.SelectedValue = ppid;
            sacuvaj_btn.Enabled = false;
            odbaci_btn.Enabled = false;

            switch (flag)
            {
                case 0:
                    panel2.BackColor = Color.Green;
                    lock_btn.BackgroundImage = Properties.Resources.key_green;
                    magacini_cmb.Enabled = true;
                    izborPartnera_cmb.Enabled = true;
                    break;
                case 1:
                    panel2.BackColor = Color.Red;
                    lock_btn.BackgroundImage = Properties.Resources.key_red;
                    magacini_cmb.Enabled = false;
                    izborPartnera_cmb.Enabled = false;
                    break;
                case 2:
                    break;
                default:
                    panel2.BackColor = Color.Red;
                    lock_btn.BackgroundImage = Properties.Resources.key_red;
                    magacini_cmb.Enabled = false;
                    izborPartnera_cmb.Enabled = false;
                    break;
            }

            switch(vrDok)
            {
                case 1:
                    razduziRobuToolStripMenuItem.Visible = true;
                    break;
            }
            if(komentar != null && komentar.Length > 0)
            {
                komentar_btn.FlatAppearance.BorderColor = Color.Red;
            }
            else
            {
                komentar_btn.FlatAppearance.BorderColor = Color.White;
            }

            if(Korisnik.ImaPravo(22001) && flag == 0)
            {
                magacini_cmb.Enabled = true;
            }

            if(Korisnik.ImaPravo(22002) && flag == 0)
            {
                izborPartnera_cmb.Enabled = true;
            }

            ucitano = true;
        }
        private void UcitajMagacine()
        {
            magacini_cmb.DataSource = Komercijalno.UcitajMagacine();
            magacini_cmb.ValueMember = "_int";
            magacini_cmb.DisplayMember = "_string";
        }
        private void UcitajProizvodnje()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT POSLOVNAJEDINICAID, NAZIV FROM POSLOVNAJEDINICA WHERE VRSTA = 1", con))
                {
                    List<Int_String> list = new List<Int_String>();
                    FbDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
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
        private void UcitajPartnere()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT PPID, NAZIV FROM PARTNER ORDER BY NAZIV ASC", con))
                {
                    List<Int_String> list = new List<Int_String>();
                    FbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        list.Add(new Int_String { _int = Convert.ToInt32(dr[0]), _string = dr[1].ToString() });
                    }

                    izborPartnera_cmb.DataSource = list;
                    izborPartnera_cmb.ValueMember = "_int";
                    izborPartnera_cmb.DisplayMember = "_string";
                }
                con.Close();
            }
        }
        private void ReSetupDokument()
        {
            ucitano = false;
            sacuvaj_btn.Enabled = false;
            odbaci_btn.Enabled = false;
            magacini_cmb.Enabled = false;
            izborPartnera_cmb.Enabled = false;
        }

        private void UcitajRobuKomercijalnog()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT * FROM ROBA WHERE VRSTA = 1", con))
                {
                    da.Fill(robaData);
                }
                con.Close();
            }
        }
        private void NamestiDataGridView()
        {
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.ReadOnly = true;
            }
            if (flag == 0)
            {
                dataGridView1.Columns["KOLICINA"].ReadOnly = false;
            }
            dataGridView1.Columns["STAVKAID"].Visible = false;

            dataGridView1.Columns["ROBAID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ROBAID;
            dataGridView1.Columns["KATBR"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.KATBR;
            dataGridView1.Columns["KOLICINA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.KOLICINA;
            dataGridView1.Columns["KATBRPRO"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.KATBRPRO;
            dataGridView1.Columns["NAZIV"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.NAZIV;
            dataGridView1.Columns["VRSTA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.VRSTA;
            dataGridView1.Columns["AKTIVNA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.AKTIVNA;
            dataGridView1.Columns["GRUPAID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.GRUPAID;
            dataGridView1.Columns["PODGRUPA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.PODGRUPA;
            dataGridView1.Columns["PROID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.PROID;
            dataGridView1.Columns["JM"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.JM;
            dataGridView1.Columns["TARIFAID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.TARIFAID;
            dataGridView1.Columns["NABAVNACENA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.NABAVNACENA;
            dataGridView1.Columns["PRODAJNACENA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.PRODAJNACENA;
            dataGridView1.Columns["DEVNABCENA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.DEVNABCENA;
            dataGridView1.Columns["FABRCENA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.FABRCENA;
            dataGridView1.Columns["STANJE"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.STANJE;
            dataGridView1.Columns["NARUCENO"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.NARUCENO;
            dataGridView1.Columns["REZERVISANO"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.REZERVISANO;
            dataGridView1.Columns["STANJEPOOTP"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.STANJEPOOTP;
            dataGridView1.Columns["TAKSA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.TAKSA;
            dataGridView1.Columns["MARZA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.MARZA;
            dataGridView1.Columns["UVOZ"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.UVOZ;
            dataGridView1.Columns["TARBROJ"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.TARBROJ;
            dataGridView1.Columns["AKCIZA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.AKCIZA;
            dataGridView1.Columns["NAZIVZACARINU"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.NAZIVZACARINU;
            dataGridView1.Columns["NAZIVNAENG"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.NAZIVNAENG;
            dataGridView1.Columns["GARANTID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.GARANTID;
            dataGridView1.Columns["ALTJM"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ALTJM;
            dataGridView1.Columns["ALTKOL"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ALTKOL;
            dataGridView1.Columns["ALTNEDELJIVA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ALTNEDELJIVA;
            dataGridView1.Columns["TRPAK"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.TRPAK;
            dataGridView1.Columns["TRKOL"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.TRKOL;
            dataGridView1.Columns["JMSD"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.JMSD;
            dataGridView1.Columns["KOMENTAR"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.KOMENTAR;
            dataGridView1.Columns["XOD"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.XOD;
            dataGridView1.Columns["XDO"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.XDO;
            dataGridView1.Columns["YOD"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.YOD;
            dataGridView1.Columns["YDO"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.YDO;
            dataGridView1.Columns["ZOD"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ZOD;
            dataGridView1.Columns["ZDO"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ZDO;
            dataGridView1.Columns["IMAROKTRAJANJA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.IMAROKTRAJANJA;
            dataGridView1.Columns["NACENOVNIKU"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.NACENOVNIKU;
            dataGridView1.Columns["ZAPID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ZAPID;
            dataGridView1.Columns["NORMA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.NORMA;
            dataGridView1.Columns["KALO"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.KALO;
            dataGridView1.Columns["TEZINA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.TEZINA;
            dataGridView1.Columns["PIN"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.PIN;
            dataGridView1.Columns["KRITZAL"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.KRITZAL;
            dataGridView1.Columns["OPTZAL"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.OPTZAL;
            dataGridView1.Columns["KATEGORIJA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.KATEGORIJA;
            dataGridView1.Columns["IMASBROJ"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.IMASBROJ;
            dataGridView1.Columns["STANJEPOSER"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.STANJEPOSER;
            dataGridView1.Columns["ZAPREMINA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ZAPREMINA;
            dataGridView1.Columns["SLIKA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.SLIKA;
            dataGridView1.Columns["PPID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.PPID;
            dataGridView1.Columns["TRDECPAK"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.TRDECPAK;
            dataGridView1.Columns["PRODCENABP"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.PRODCENABP;
            dataGridView1.Columns["JMR"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.JMR;
            dataGridView1.Columns["STANJEPOREKLAM"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.STANJEPOREKLAM;
            dataGridView1.Columns["STANJEPOREVERSU"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.STANJEPOREVERSU;
            dataGridView1.Columns["ADR"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ADR;
            dataGridView1.Columns["STANJE_MOJE_EKSP"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.STANJEPOOTP_MOJE_EKSP;
            dataGridView1.Columns["VPCID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.VPCID;
            dataGridView1.Columns["PROCPC"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.PROCPC;
            dataGridView1.Columns["DATUM_ISPORUKE"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.DATUM_ISPORUKE;
            dataGridView1.Columns["REZERVISANO_MOJE_EKSP"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.REZERVISANO_MOJE_EKSP;
            dataGridView1.Columns["STANJEPOOTP_MOJE_EKSP"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.STANJEPOOTP_MOJE_EKSP;
            dataGridView1.Columns["STANJEPOSER_MOJE_EKSP"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.STANJEPOSER_MOJE_EKSP;
            dataGridView1.Columns["NAZIVZASTAMPU"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.NAZIVZASTAMPU;
            dataGridView1.Columns["ALTPIN"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ALTPIN;
            dataGridView1.Columns["TRPIN"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.TRPIN;
            dataGridView1.Columns["DRZAVAID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.DRZAVAID;
            dataGridView1.Columns["LINKED_ROBAID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.LINKED_ROBAID;
            dataGridView1.Columns["OBLIK"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.OBLIK;
            dataGridView1.Columns["REKLAM_PROC"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.REKLAM_PROC;
            dataGridView1.Columns["JM_POVRSINA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.JM_POVRSINA;
            dataGridView1.Columns["JM_ZAPREMINA"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.JM_ZAPREMINA;
            dataGridView1.Columns["X3"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.X3;
            dataGridView1.Columns["Y3"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.Y3;
            dataGridView1.Columns["Z3"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.Z3;
            dataGridView1.Columns["NAS_BARKOD"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.NAS_BARKOD;
            dataGridView1.Columns["REFVAL"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.REFVAL;
            dataGridView1.Columns["KGID"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.KGID;
            dataGridView1.Columns["STANJE_MOJE_EKSP"].Visible = M.Podesavanja.Kolona.Dokument1.Visible.ROBAID;



            dataGridView1.Columns["ROBAID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ROBAID;
            dataGridView1.Columns["KATBR"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.KATBR;
            dataGridView1.Columns["KATBRPRO"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.KATBRPRO;
            dataGridView1.Columns["NAZIV"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.NAZIV;
            dataGridView1.Columns["VRSTA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.VRSTA;
            dataGridView1.Columns["AKTIVNA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.AKTIVNA;
            dataGridView1.Columns["GRUPAID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.GRUPAID;
            dataGridView1.Columns["PODGRUPA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.PODGRUPA;
            dataGridView1.Columns["PROID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.PROID;
            dataGridView1.Columns["JM"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.JM;
            dataGridView1.Columns["TARIFAID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.TARIFAID;
            dataGridView1.Columns["NABAVNACENA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.NABAVNACENA;
            dataGridView1.Columns["PRODAJNACENA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.PRODAJNACENA;
            dataGridView1.Columns["DEVNABCENA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.DEVNABCENA;
            dataGridView1.Columns["FABRCENA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.FABRCENA;
            dataGridView1.Columns["STANJE"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.STANJE;
            dataGridView1.Columns["NARUCENO"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.NARUCENO;
            dataGridView1.Columns["REZERVISANO"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.REZERVISANO;
            dataGridView1.Columns["STANJEPOOTP"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.STANJEPOOTP;
            dataGridView1.Columns["TAKSA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.TAKSA;
            dataGridView1.Columns["MARZA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.MARZA;
            dataGridView1.Columns["UVOZ"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.UVOZ;
            dataGridView1.Columns["TARBROJ"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.TARBROJ;
            dataGridView1.Columns["AKCIZA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.AKCIZA;
            dataGridView1.Columns["NAZIVZACARINU"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.NAZIVZACARINU;
            dataGridView1.Columns["NAZIVNAENG"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.NAZIVNAENG;
            dataGridView1.Columns["GARANTID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.GARANTID;
            dataGridView1.Columns["ALTJM"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ALTJM;
            dataGridView1.Columns["ALTKOL"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ALTKOL;
            dataGridView1.Columns["ALTNEDELJIVA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ALTNEDELJIVA;
            dataGridView1.Columns["TRPAK"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.TRPAK;
            dataGridView1.Columns["TRKOL"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.TRKOL;
            dataGridView1.Columns["JMSD"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.JMSD;
            dataGridView1.Columns["KOMENTAR"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.KOMENTAR;
            dataGridView1.Columns["XOD"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.XOD;
            dataGridView1.Columns["XDO"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.XDO;
            dataGridView1.Columns["YOD"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.YOD;
            dataGridView1.Columns["YDO"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.YDO;
            dataGridView1.Columns["ZOD"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ZOD;
            dataGridView1.Columns["ZDO"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ZDO;
            dataGridView1.Columns["IMAROKTRAJANJA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.IMAROKTRAJANJA;
            dataGridView1.Columns["NACENOVNIKU"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.NACENOVNIKU;
            dataGridView1.Columns["ZAPID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ZAPID;
            dataGridView1.Columns["NORMA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.NORMA;
            dataGridView1.Columns["KALO"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.KALO;
            dataGridView1.Columns["TEZINA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.TEZINA;
            dataGridView1.Columns["PIN"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.PIN;
            dataGridView1.Columns["KRITZAL"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.KRITZAL;
            dataGridView1.Columns["OPTZAL"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.OPTZAL;
            dataGridView1.Columns["KATEGORIJA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.KATEGORIJA;
            dataGridView1.Columns["IMASBROJ"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.IMASBROJ;
            dataGridView1.Columns["STANJEPOSER"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.STANJEPOSER;
            dataGridView1.Columns["ZAPREMINA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ZAPREMINA;
            dataGridView1.Columns["SLIKA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.SLIKA;
            dataGridView1.Columns["PPID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.PPID;
            dataGridView1.Columns["TRDECPAK"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.TRDECPAK;
            dataGridView1.Columns["PRODCENABP"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.PRODCENABP;
            dataGridView1.Columns["JMR"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.JMR;
            dataGridView1.Columns["STANJEPOREKLAM"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.STANJEPOREKLAM;
            dataGridView1.Columns["STANJEPOREVERSU"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.STANJEPOREVERSU;
            dataGridView1.Columns["ADR"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ADR;
            dataGridView1.Columns["STANJE_MOJE_EKSP"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.STANJEPOOTP_MOJE_EKSP;
            dataGridView1.Columns["VPCID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.VPCID;
            dataGridView1.Columns["PROCPC"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.PROCPC;
            dataGridView1.Columns["DATUM_ISPORUKE"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.DATUM_ISPORUKE;
            dataGridView1.Columns["REZERVISANO_MOJE_EKSP"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.REZERVISANO_MOJE_EKSP;
            dataGridView1.Columns["STANJEPOOTP_MOJE_EKSP"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.STANJEPOOTP_MOJE_EKSP;
            dataGridView1.Columns["STANJEPOSER_MOJE_EKSP"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.STANJEPOSER_MOJE_EKSP;
            dataGridView1.Columns["NAZIVZASTAMPU"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.NAZIVZASTAMPU;
            dataGridView1.Columns["ALTPIN"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ALTPIN;
            dataGridView1.Columns["TRPIN"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.TRPIN;
            dataGridView1.Columns["DRZAVAID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.DRZAVAID;
            dataGridView1.Columns["LINKED_ROBAID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.LINKED_ROBAID;
            dataGridView1.Columns["OBLIK"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.OBLIK;
            dataGridView1.Columns["REKLAM_PROC"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.REKLAM_PROC;
            dataGridView1.Columns["JM_POVRSINA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.JM_POVRSINA;
            dataGridView1.Columns["JM_ZAPREMINA"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.JM_ZAPREMINA;
            dataGridView1.Columns["X3"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.X3;
            dataGridView1.Columns["Y3"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.Y3;
            dataGridView1.Columns["Z3"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.Z3;
            dataGridView1.Columns["NAS_BARKOD"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.NAS_BARKOD;
            dataGridView1.Columns["REFVAL"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.REFVAL;
            dataGridView1.Columns["KGID"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.KGID;
            dataGridView1.Columns["STANJE_MOJE_EKSP"].DisplayIndex = M.Podesavanja.Kolona.Dokument1.DisplayIndex.ROBAID;

            dataGridView1.Columns["KATBR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["KATBRPRO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["NAZIV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["KOLICINA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void prethodniDokument_btn_Click(object sender, EventArgs e)
        {
            if ((brDok - 1 ) <= (0))
            {
                return;
            }
            brDok -= 1;
            UcitajDokument();
        }
        private void sledeciDokument_btn_Click(object sender, EventArgs e)
        {
            if (M.Baza.Magacin.Dokument.GetMaxBrDok(vrDok) >= (brDok + 1))
            {
                brDok += 1;
                UcitajDokument();
            }
        }

        private void lock_btn_Click(object sender, EventArgs e)
        {
            if(flag == 0)
            {
                Zakljucaj();
                UcitajDokument();
            }
            else if (flag == 1)
            {
                Otkljucaj();
                UcitajDokument();
            }
        }

        private void Zakljucaj()
        {
            if (!ProveriPravoZakljucavanja())
                return;

            DialogResult dr = MessageBox.Show("Da li sigurno zelite zakljucati dokument?", "Potvrdi!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;

            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("UPDATE DOKUMENT SET FLAG = 1 WHERE VRDOK = @VrDok AND BRDOK = @BrDok", con))
                {
                    cmd.Parameters.AddWithValue("@VrDok", vrDok);
                    cmd.Parameters.AddWithValue("@BrDok", brDok);
                    
                    cmd.ExecuteNonQuery();

                    dataGridView1.Columns["KOLICINA"].ReadOnly = true;
                    magacini_cmb.Enabled = false;
                    izborPartnera_cmb.Enabled = false;

                    MessageBox.Show("Uspesno ste zakljucali dokument!");
                }
                con.Close();
            }
        }
        private void Otkljucaj()
        {
            if (!ProveriPravoOtkljucavanja())
                return;

            DialogResult dr = MessageBox.Show("Da li sigurno zelite otkljucati dokument?", "Potvrdi!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;

            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("UPDATE DOKUMENT SET FLAG = 0 WHERE VRDOK = @VrDok AND BRDOK = @BrDok", con))
                {
                    cmd.Parameters.AddWithValue("@VrDok", vrDok);
                    cmd.Parameters.AddWithValue("@BrDok", brDok);

                    cmd.ExecuteNonQuery();

                    dataGridView1.Columns["KOLICINA"].ReadOnly = false;
                    magacini_cmb.Enabled = true;
                    izborPartnera_cmb.Enabled = true;

                    MessageBox.Show("Uspesno ste otkljucali dokument!");
                }
                con.Close();
            }
        }

        private bool ProveriPravoZakljucavanja()
        {
            bool i = false;
            int pravo = -1;
            switch(vrDok)
            {
                case 1: //Dokument razduzenja
                    if (Korisnik.ImaPravo(20001))
                        i = true;
                    else
                        pravo = 20001;
                    break;
            }
            if(!i)
            {
                MessageBox.Show(String.Format("Nemate pravo pristupa modulu [{0}]", pravo));
            }
            return i;
        }
        private bool ProveriPravoOtkljucavanja()
        {
            bool i = false;
            int pravo = -1;
            switch (vrDok)
            {
                case 1: //Dokument razduzenja
                    if (Korisnik.ImaPravo(21001))
                        i = true;
                    else
                        pravo = 21001;
                    break;
            }
            if (!i)
            {
                MessageBox.Show(String.Format("Nemate pravo pristupa modulu [{0}]", pravo));
            }
            return i;
        }

        private void razduziRobuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(flag == 0)
            {
                MessageBox.Show("Dokument mora biti zakljucan!");
                return;
            }
            if (pretvorenUBrDokKomercijalno > 0)
            {
                MessageBox.Show("Vec ste razduzili robu po ovom dokumentu!");
                return;
            }
            


            if(flag != 1)
            {
                MessageBox.Show("Greska");
                return;
            }
            try
            {
                DialogResult d = MessageBox.Show("Pretvaranjem ovog dokumenta on ce biti zakljucan, a vas magacin ce biti razduzen. Da li zelite nastaviti?", "Potvrdi", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    WaitMsg wm = new WaitMsg();
                    wm.Show();
                    using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
                    {
                        con.Open();
                        using (FbCommand cmd = new FbCommand("NAPRAVIDOKUMENT", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("VRDOK", FbDbType.Integer).Value = 19;
                            cmd.Parameters.Add("BR_NAR", FbDbType.VarChar).Value = string.Format("M_1_{0}", brDok);
                            cmd.Parameters.Add("PPID", FbDbType.Integer).Value = null;
                            cmd.Parameters.Add("NAPOMENA", FbDbType.VarChar).Value = string.Format("{0} --- M_1_{1}", komentar, brDok);
                            cmd.Parameters.Add("NACUPLID", FbDbType.Integer).Value = 0;
                            cmd.Parameters.Add("MAGACINID", FbDbType.Integer).Value = 12;
                            cmd.Parameters.Add("BRDOK", FbDbType.Integer);
                            cmd.Parameters["BRDOK"].Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();

                            pretvorenUBrDokKomercijalno = Convert.ToInt32(cmd.Parameters["BRDOK"].Value);
                            pretvorenUVrDokKomercijalno = 19;
                        }

                        using (FbCommand cmd = new FbCommand("NAPRAVISTAVKU", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("VRDOK", FbDbType.Integer).Value = pretvorenUVrDokKomercijalno;
                            cmd.Parameters.Add("BRDOK", FbDbType.Integer).Value = pretvorenUBrDokKomercijalno;
                            cmd.Parameters.Add("ROBAID", FbDbType.Integer);
                            cmd.Parameters.Add("CENA_BEZ_PDV", FbDbType.Numeric).Value = 0;
                            cmd.Parameters.Add("KOL", FbDbType.Numeric);
                            cmd.Parameters.Add("RABAT", FbDbType.Numeric).Value = 0;

                            foreach(DataGridViewRow row in dataGridView1.Rows)
                            {
                                cmd.Parameters["ROBAID"].Value = Convert.ToInt32(row.Cells["ROBAID"].Value);
                                cmd.Parameters["KOL"].Value = Convert.ToInt32(row.Cells["KOLICINA"].Value);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        using (FbCommand cmd = new FbCommand("UPDATE DOKUMENT SET MAGID = @MagID, ZAPID = @ZapID, REFID = @ZapId WHERE VRDOK = @VrDok AND BRDOK = @BrDok", con))
                        {
                            cmd.Parameters.AddWithValue("@MagID", 6);
                            cmd.Parameters.AddWithValue("@ZapID", 5);
                            cmd.Parameters.AddWithValue("@BrDok", pretvorenUBrDokKomercijalno);
                            cmd.Parameters.AddWithValue("@VrDok", pretvorenUVrDokKomercijalno);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Magacin uspesno razduzen po internoj otpremnici br. " + pretvorenUBrDokKomercijalno);
                        con.Close();
                    }

                    using (FbConnection con = new FbConnection(M.Baza.connectionString))
                    {
                        con.Open();
                        using (FbCommand cmd = new FbCommand("UPDATE DOKUMENT SET PRETVOREN_U_VRDOK_KOMERCIJALNO = @PUVRDOK, PRETVOREN_U_BRDOK_KOMERCIJALNO = @PUBRDOK WHERE BRDOK = @BrDok AND VRDOK = @VrDok", con))
                        {
                            cmd.Parameters.AddWithValue("@PUVRDOK", pretvorenUVrDokKomercijalno);
                            cmd.Parameters.AddWithValue("@PUBRDOK", pretvorenUBrDokKomercijalno);
                            cmd.Parameters.AddWithValue("@VrDok", vrDok);
                            cmd.Parameters.AddWithValue("@BrDok", brDok);

                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }

                    UcitajDokument();
                    wm.Close();
                }
            }
            catch(FbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dokumentSearch_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if(Convert.ToInt32(dokumentSearch_txt.Text) > M.Baza.Magacin.Dokument.GetMaxBrDok(vrDok) || Convert.ToInt32(dokumentSearch_txt.Text) < 1)
                {
                    MessageBox.Show("Dokument ne postojI!");
                    return;
                }
                brDok = Convert.ToInt32(dokumentSearch_txt.Text);
                UcitajDokument();
            }
        }

        private void dokumentSearch_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void noviDokument_btn_Click(object sender, EventArgs e)
        {
            M.Baza.Magacin.Dokument.Novi(vrDok);
            brDok = M.Baza.Magacin.Dokument.GetMaxBrDok(vrDok);
            UcitajDokument();
        }

        private void magacini_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ucitano)
            {
                sacuvaj_btn.Enabled = true;
                odbaci_btn.Enabled = true;
            }
        }

        private void Dokument1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                UcitajDokument();
            }

            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                //Dodati help
            }
        }

        private void sacuvaj_btn_EnabledChanged(object sender, EventArgs e)
        {
            //Odnosi se i na sacuvaj i na odbaci
            if(sacuvaj_btn.Enabled)
            {
                sacuvaj_btn.BackColor = Color.White;
            }
            else
            {
                sacuvaj_btn.BackColor = Color.DimGray;
            }

            if (odbaci_btn.Enabled)
            {
                odbaci_btn.BackColor = Color.White;
            }
            else
            {
                odbaci_btn.BackColor = Color.DimGray;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(izborRobeDT == null)
            {
                MessageBox.Show("Greska!");
                return;
            }
            IzborRobe ir = new IzborRobe(izborRobeDT, this);
            ir.ShowDialog();
        }

        private void UcitajDTIzboraRobe()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT ROBA.ROBAID, ROBA.KATBR, ROBA.KATBRPRO, ROBA.NAZIV, ROBAUMAGACINU.STANJE FROM ROBAUMAGACINU INNER JOIN ROBA ON ROBAUMAGACINU.ROBAID = ROBA.ROBAID WHERE ROBAUMAGACINU.MAGACINID = @MagacinID AND ROBA.VRSTA = 1", con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@MagacinID", 12);

                    da.Fill(izborRobeDT);
                }
                con.Close();
            }
        }

        public void UnesiStavku(int robaId, double kolicina, string naziv)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("INSERT INTO STAVKA (STAVKAID, VRDOK, BRDOK, ROBAID, KOLICINA) VALUES (((SELECT MAX(STAVKAID) FROM STAVKA) + 1), @VrDok, @BrDok, @RobaID, @Kolicina)", con))
                {
                    cmd.Parameters.AddWithValue("@VrDok", vrDok);
                    cmd.Parameters.AddWithValue("@BrDok", brDok);
                    cmd.Parameters.AddWithValue("@RobaID", robaId);
                    cmd.Parameters.AddWithValue("@Kolicina", kolicina);
                    cmd.ExecuteNonQuery();

                    UcitajDokument();
                }
                con.Close();
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!ucitano)
                return;
            if (dataGridView1.Columns[e.ColumnIndex] == dataGridView1.Columns["KOLICINA"])
            {
                if (Convert.ToDouble(e.FormattedValue) != Convert.ToDouble(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["KOLICINA"].Value))
                {
                    using (FbConnection con = new FbConnection(M.Baza.connectionString))
                    {
                        con.Open();
                        using (FbCommand cmd = new FbCommand("UPDATE STAVKA SET KOLICINA = @Kolicina WHERE STAVKAID = @StavkaID", con))
                        {
                            cmd.Parameters.AddWithValue("@Kolicina", e.FormattedValue);
                            cmd.Parameters.AddWithValue("@StavkaID", Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["STAVKAID"].Value));

                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }
            }
        }

        private void komentar_btn_Click(object sender, EventArgs e)
        {
            Komentar k = new Komentar(this);
            k.ShowDialog();
        }

        public void SacuvajKomentar(string kom)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("UPDATE DOKUMENT SET KOMENTAR = @Komentar WHERE VRDOK = @VrDok AND BRDOK = @BrDok", con))
                {
                    cmd.Parameters.AddWithValue("@VrDok", vrDok);
                    cmd.Parameters.AddWithValue("@BrDok", brDok);
                    cmd.Parameters.AddWithValue("@Komentar", kom);
                    cmd.ExecuteNonQuery();
                    komentar = kom;
                    if (!string.IsNullOrWhiteSpace(kom))
                    {
                        komentar_btn.FlatAppearance.BorderColor = Color.Red;
                    }
                    else
                    {
                        komentar_btn.FlatAppearance.BorderColor = Color.Red;
                    }
                    MessageBox.Show("Komentar uspesno sacuvan!");
                }
                con.Close();
            }
        }

        private void sacuvaj_btn_Click(object sender, EventArgs e)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("UPDATE DOKUMENT SET ZA_MAGACINID = @MagacinID WHERE VRDOK = @VrDok AND BRDOK = @BrDok", con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacini_cmb.SelectedValue);
                    cmd.Parameters.AddWithValue("@VrDok", vrDok);
                    cmd.Parameters.AddWithValue("@BrDok", brDok);

                    cmd.ExecuteNonQuery();

                    UcitajDokument();
                    MessageBox.Show("Promene uspesno izvrsene!");
                }
                con.Close();
            }
        }

        private void odbaci_btn_Click(object sender, EventArgs e)
        {
            UcitajDokument();
        }

        private void obrisiStavkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("DELETE FROM STAVKA WHERE STAVKAID = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["STAVKAID"].Value));

                    cmd.ExecuteNonQuery();

                    UcitajDokument();
                }
                con.Close();
            }
        }
    }
}
