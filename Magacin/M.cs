using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Magacin
{
    public class M
    {
        public class Akcija
        {
            public class NedeljnaAkcija
            {
                public static void OduzmiSaStanja(int robaId, double kolicina)
                {
                    using (FbConnection con = new FbConnection(Baza.connectionString))
                    {
                        con.Open();
                        using (FbCommand cmd = new FbCommand("UPDATE LISTASTAVKE SET TRSTANJE = ((SELECT COALESCE(TRSTANJE, 0) FROM LISTASTAVKE WHERE LISTAID = 1 AND ROBAID = @RobaID) - @Kolicina) WHERE LISTAID = 1 AND ROBAID = @RobaID", con))
                        {
                            cmd.Parameters.AddWithValue("@RobaID", robaId);
                            cmd.Parameters.AddWithValue("@Kolicina", kolicina);

                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }
                public static double TrenutnoStanje(int robaId)
                {
                    double d = 0;
                    using (FbConnection con = new FbConnection(Baza.connectionString))
                    {
                        con.Open();
                        using (FbCommand cmd = new FbCommand("SELECT TRSTANJE FROM LISTASTAVKE WHERE ROBAID = @RobaID", con))
                        {
                            cmd.Parameters.AddWithValue("@RobaID", robaId);

                            FbDataReader dr = cmd.ExecuteReader();

                            if(dr.Read())
                            {
                                return (dr[0] is DBNull) ? 0 : Convert.ToDouble(dr[0]);
                            }
                        }
                        con.Close();
                    }
                    return d;
                }
            }
        }
        public class Baza
        {
            public static string connectionString;
            public static string connectionKomercijalno2018;
            public static string connectionKomercijalno2017;
            public static string connectionKomercijalno2016;
            public static string connectionKomercijalno2015;

            public class Magacin
            {
                public class Dokument
                    {
                        public static void Novi(int vrDok)
                        {
                            using (FbConnection con = new FbConnection(connectionString))
                            {
                                con.Open();
                                using (FbCommand cmd = new FbCommand("INSERT INTO DOKUMENT (ID, VRDOK, BRDOK, FLAG, ZA_MAGACINID) VALUES (((SELECT coalesce(MAX(ID), 0) FROM DOKUMENT) + 1), @VrDok, ((SELECT coalesce(MAX(BRDOK), 0) FROM DOKUMENT WHERE VRDOK = @VrDok) + 1), 0, 12)", con))
                                {
                                    cmd.Parameters.AddWithValue("@VrDok", vrDok);

                                    cmd.ExecuteNonQuery();
                                }
                                con.Close();
                            }
                        }

                        public static int GetMaxId()
                        {
                            int m = 0;
                            using (FbConnection con = new FbConnection(connectionString))
                            {
                                con.Open();
                                using (FbCommand cmd = new FbCommand("SELECT MAX(ID) FROM DOKUMENT", con))
                                {
                                    FbDataReader dr = cmd.ExecuteReader();

                                    if (dr.Read())
                                    {
                                        m = Convert.ToInt32(dr[0]);
                                    }
                                }
                                con.Close();
                            }
                            return m;
                        }
                        public static int GetMaxId(int vrDok)
                        {
                            int m = 0;
                            using (FbConnection con = new FbConnection(connectionString))
                            {
                                con.Open();
                                using (FbCommand cmd = new FbCommand("SELECT MAX(ID) FROM DOKUMENT WHERE VRDOK = @VrDok", con))
                                {
                                    cmd.Parameters.AddWithValue("@VrDok", vrDok);
                                    FbDataReader dr = cmd.ExecuteReader();

                                    if(dr.Read())
                                    {
                                        m = Convert.ToInt32(dr[0]);
                                    }
                                }
                                con.Close();
                            }
                            return m;
                        }

                        public static int GetMaxBrDok(int vrDok)
                        {
                            int m = 0;
                            using (FbConnection con = new FbConnection(connectionString))
                            {
                                con.Open();
                                using (FbCommand cmd = new FbCommand("SELECT MAX(BRDOK) FROM DOKUMENT WHERE VRDOK = @VrDok", con))
                                {
                                    cmd.Parameters.AddWithValue("@VrDok", vrDok);
                                    FbDataReader dr = cmd.ExecuteReader();

                                    if (dr.Read())
                                    {
                                        m = (dr[0] is DBNull) ? 0 : Convert.ToInt32(dr[0]);
                                    }
                                }
                                con.Close();
                            }
                            return m;
                        }

                        public static bool ImaStavku(int vrDok, int brDok, int robaId)
                        {
                            bool b = false;
                            using (FbConnection con = new FbConnection(connectionString))
                            {
                                con.Open();
                                using (FbCommand cmd = new FbCommand("SELECT ROBAID FROM STAVKA WHERE VRDOK = @VrDok AND BRDOK = @BrDok AND ROBAID = @RobaID", con))
                                {
                                    cmd.Parameters.AddWithValue("@VrDok", vrDok);
                                    cmd.Parameters.AddWithValue("@BrDok", brDok);
                                    cmd.Parameters.AddWithValue("@RobaID", robaId);

                                    FbDataReader dr = cmd.ExecuteReader();

                                    if(dr.Read())
                                    {
                                        b = true;
                                    }
                                }
                                con.Close();
                            }
                            return b;
                        }
                    }
                public class Json
                {
                }
                public static void ZapisiIstorijuKomercijalno(int modulId, int robaId, double kolicina, double rabat, int vrDokKom, int brDokKom, string naziv)
                {
                    using(FbConnection con = new FbConnection(connectionString))
                    {
                        con.Open();
                        using (FbCommand cmd = new FbCommand("INSERT INTO STAVKAKOM (STAVKAKOMID, MODULID, KORISNIKID, ROBAID, KOLICINA, RABAT, VRDOKKOM, BRDOKKOM, NAZIV, DATUM) VALUES (((SELECT COALESCE(MAX(STAVKAKOMID), 0) FROM STAVKAKOM) + 1), @ModulID, @KorisnikID, @RobaID, @Kolicina, @Rabat, @VrDokKom, @BrDokKom, @Naziv, @Datum)", con))
                        {
                            cmd.Parameters.AddWithValue("@ModulID", modulId);
                            cmd.Parameters.AddWithValue("@KorisnikID", Korisnik.korisnikId);
                            cmd.Parameters.AddWithValue("@RobaID", robaId);
                            cmd.Parameters.AddWithValue("@Kolicina", kolicina);
                            cmd.Parameters.AddWithValue("@Rabat", rabat);
                            cmd.Parameters.AddWithValue("@VrDokKom", vrDokKom);
                            cmd.Parameters.AddWithValue("@BrDokKom", brDokKom);
                            cmd.Parameters.AddWithValue("@Naziv", naziv);
                            cmd.Parameters.AddWithValue("@Datum", DateTime.Now);

                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }                
            }
        }
        public class Godina
        {
            public static string trenutnaGodina = "2018";
            public static string jednaGodPre = "2017";
            public static string dveGodPre = "2016";
            public static string triGodPre = "2015";

            public static string trenutnaGodinaConnString = Baza.connectionKomercijalno2018;
            public static string jednaGodPreConnString = Baza.connectionKomercijalno2017;
            public static string dveGodPreConnString = Baza.connectionKomercijalno2016;
            public static string triGodPreConnString = Baza.connectionKomercijalno2015;

            public static int godinaRada = 2017;

            public static DateTime PrviDanUMesecu(Mesec mesec, int godina)
            {
                DateTime dt = new DateTime();
                switch (mesec)
                {
                    case Mesec.Januar:
                        dt = new DateTime(godina, 1, 1);
                        break;
                    case Mesec.Februar:
                        dt = new DateTime(godina, 2, 1);
                        break;
                    case Mesec.Mart:
                        dt = new DateTime(godina, 3, 1);
                        break;
                    case Mesec.April:
                        dt = new DateTime(godina, 4, 1);
                        break;
                    case Mesec.Maj:
                        dt = new DateTime(godina, 5, 1);
                        break;
                    case Mesec.Jun:
                        dt = new DateTime(godina, 6, 1);
                        break;
                    case Mesec.Jul:
                        dt = new DateTime(godina, 7, 1);
                        break;
                    case Mesec.Avgust:
                        dt = new DateTime(godina, 8, 1);
                        break;
                    case Mesec.Septembar:
                        dt = new DateTime(godina, 9, 1);
                        break;
                    case Mesec.Oktobar:
                        dt = new DateTime(godina, 10, 1);
                        break;
                    case Mesec.Novembar:
                        dt = new DateTime(godina, 11, 1);
                        break;
                    case Mesec.Decembar:
                        dt = new DateTime(godina, 12, 1);
                        break;
                }
                return dt;
            }
            public static DateTime PoslednjiDanUMesecu(Mesec mesec, int godina)
            {
                DateTime dt = new DateTime();
                switch (mesec)
                {
                    case Mesec.Januar:
                        dt = new DateTime(godina, 1, 31);
                        break;
                    case Mesec.Februar:
                        dt = new DateTime(godina, 2, DateTime.DaysInMonth(godina, 2));
                        break;
                    case Mesec.Mart:
                        dt = new DateTime(godina, 3, 31);
                        break;
                    case Mesec.April:
                        dt = new DateTime(godina, 4, 30);
                        break;
                    case Mesec.Maj:
                        dt = new DateTime(godina, 5, 31);
                        break;
                    case Mesec.Jun:
                        dt = new DateTime(godina, 6, 30);
                        break;
                    case Mesec.Jul:
                        dt = new DateTime(godina, 7, 31);
                        break;
                    case Mesec.Avgust:
                        dt = new DateTime(godina, 8, 31);
                        break;
                    case Mesec.Septembar:
                        dt = new DateTime(godina, 9, 30);
                        break;
                    case Mesec.Oktobar:
                        dt = new DateTime(godina, 10, 31);
                        break;
                    case Mesec.Novembar:
                        dt = new DateTime(godina, 11, 30);
                        break;
                    case Mesec.Decembar:
                        dt = new DateTime(godina, 12, 31);
                        break;
                }
                return dt;
            }
            public static Mesec MesecGet(int mesec)
            {
                switch(mesec)
                {
                    case 1:
                        return Mesec.Januar;
                    case 2:
                        return Mesec.Februar;
                    case 3:
                        return Mesec.Mart;
                    case 4:
                        return Mesec.April;
                    case 5:
                        return Mesec.Maj;
                    case 6:
                        return Mesec.Jun;
                    case 7:
                        return Mesec.Jul;
                    case 8:
                        return Mesec.Avgust;
                    case 9:
                        return Mesec.Septembar;
                    case 10:
                        return Mesec.Oktobar;
                    case 11:
                        return Mesec.Novembar;
                    case 12:
                        return Mesec.Decembar;
                    default:
                        return Mesec.INVALID;
                }
            }
        }
        public class Korisnici
        {
            public static _Korisnik GetKorisnik(int korisnikId)
            {
                _Korisnik k = new _Korisnik();
                using (FbConnection con = new FbConnection(Baza.connectionString))
                {
                    con.Open();
                    using (FbCommand cmd = new FbCommand("SELECT KORISNIK, SIFRA FROM KORISNICI WHERE KORISNIKID = @KorisnikID", con))
                    {
                        cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);
                        FbDataReader dr = cmd.ExecuteReader();

                        if(dr.Read())
                        {
                            k.korisnikId = korisnikId;
                            k.korisnik = dr[0].ToString();
                            k.sifra = dr[1].ToString();
                        }
                    }
                    con.Close();
                }
                return k;
            }
            public static void Novi(string korisnickoIme, string sifra)
            {
                using (FbConnection con = new FbConnection(Baza.connectionString))
                {
                    con.Open();
                    using (FbCommand cmd = new FbCommand("INSERT INTO KORISNICI (KORISNIKID, KORISNIK, SIFRA) VALUES (((SELECT MAX(KORISNIKID) FROM KORISNICI) + 1), @Korisnik, @Sifra) RETURNING KORISNIKID", con))
                    {
                        cmd.Parameters.AddWithValue("@Korisnik", korisnickoIme);
                        cmd.Parameters.AddWithValue("@Sifra", sifra);
                        cmd.Parameters.Add("KORISNIKID", FbDbType.Integer).Direction = ParameterDirection.Output;

                        var id = (int)cmd.ExecuteScalar();

                        Prava.Dodaj(id, 0, 1);
                    }
                    con.Close();
                }
            }
        }
        public class Podesavanja
        {
            public static string path_podesavanja = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Magacin\\Podesavanja.txt";
            static string podesavanjaString = "Dokument1:ROBAID=0,KATBR=0";
            
            public static bool UcitajPodesavanja()
            {
                bool b = false;
                int i = 0;
                if(File.Exists(path_podesavanja))
                {
                    string[] lines = File.ReadAllLines(path_podesavanja);
                    foreach(string line in lines)
                    {
                        string[] data = line.Split('|');
                        switch(data[0])
                        {
                            case "Putanja baze magacin":
                                Baza.connectionString = String.Format(@"data source={3};initial catalog = {0};user={1};password={2}", data[1], data[2], data[3], data[4]);
                                i++;
                                break;
                            case "Putanja baze komercijalno 2018":
                                Baza.connectionKomercijalno2018 = String.Format(@"data source={3};initial catalog = {0};user={1};password={2}", data[1], data[2], data[3], data[4]);
                                i++;
                                break;
                            case "Putanja baze komercijalno 2017":
                                Baza.connectionKomercijalno2017 = String.Format(@"data source={3};initial catalog = {0};user={1};password={2}", data[1], data[2], data[3], data[4]);
                                i++;
                                break;
                            case "Putanja baze komercijalno 2016":
                                Baza.connectionKomercijalno2016 = String.Format(@"data source={3};initial catalog = {0};user={1};password={2}", data[1], data[2], data[3], data[4]);
                                i++;
                                break;
                            case "Putanja baze komercijalno 2015":
                                Baza.connectionKomercijalno2015 = String.Format(@"data source={3};initial catalog = {0};user={1};password={2}", data[1], data[2], data[3], data[4]);
                                i++;
                                break;
                            case "Podesavanja String":
                                podesavanjaString = data[1];
                                i++;
                                break;
                        }
                        if (i == 5)
                        {
                            b = true;
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Magacin");
                }

                return b;
            }
            
            public class Kolona
            {
                public class Dokument1
                {
                    public class Visible
                    {
                        public static bool ROBAID = false;
                        public static bool KATBR = true;
                        public static bool KOLICINA = true;
                        public static bool KATBRPRO = true;
                        public static bool NAZIV = true;
                        public static bool VRSTA = false;
                        public static bool AKTIVNA = false;
                        public static bool GRUPAID = false;
                        public static bool PODGRUPA = false;
                        public static bool PROID = false;
                        public static bool JM = false;
                        public static bool TARIFAID = false;
                        public static bool NABAVNACENA = false;
                        public static bool PRODAJNACENA = false;
                        public static bool DEVNABCENA = false;
                        public static bool FABRCENA = false;
                        public static bool STANJE = false;
                        public static bool NARUCENO = false;
                        public static bool REZERVISANO = false;
                        public static bool STANJEPOOTP = false;
                        public static bool TAKSA = false;
                        public static bool MARZA = false;
                        public static bool UVOZ = false;
                        public static bool TARBROJ = false;
                        public static bool AKCIZA = false;
                        public static bool NAZIVZACARINU = false;
                        public static bool NAZIVNAENG = false;
                        public static bool GARANTID = false;
                        public static bool ALTJM = false;
                        public static bool ALTKOL = false;
                        public static bool ALTNEDELJIVA = false;
                        public static bool TRPAK = false;
                        public static bool TRKOL = false;
                        public static bool JMSD = false;
                        public static bool KOMENTAR = false;
                        public static bool XOD = false;
                        public static bool XDO = false;
                        public static bool YOD = false;
                        public static bool YDO = false;
                        public static bool ZOD = false;
                        public static bool ZDO = false;
                        public static bool IMAROKTRAJANJA = false;
                        public static bool NACENOVNIKU = false;
                        public static bool ZAPID = false;
                        public static bool NORMA = false;
                        public static bool KALO = false;
                        public static bool TEZINA = false;
                        public static bool PIN = false;
                        public static bool KRITZAL = false;
                        public static bool OPTZAL = false;
                        public static bool KATEGORIJA = false;
                        public static bool IMASBROJ = false;
                        public static bool STANJEPOSER = false;
                        public static bool ZAPREMINA = false;
                        public static bool SLIKA = false;
                        public static bool PPID = false;
                        public static bool TRDECPAK = false;
                        public static bool PRODCENABP = false;
                        public static bool JMR = false;
                        public static bool STANJEPOREKLAM = false;
                        public static bool STANJEPOREVERSU = false;
                        public static bool ADR = false;
                        public static bool STANJE_MOJE_EKSP = false;
                        public static bool VPCID = false;
                        public static bool PROCPC = false;
                        public static bool DATUM_ISPORUKE = false;
                        public static bool REZERVISANO_MOJE_EKSP = false;
                        public static bool STANJEPOOTP_MOJE_EKSP = false;
                        public static bool STANJEPOSER_MOJE_EKSP = false;
                        public static bool NAZIVZASTAMPU = false;
                        public static bool ALTPIN = false;
                        public static bool TRPIN = false;
                        public static bool DRZAVAID = false;
                        public static bool LINKED_ROBAID = false;
                        public static bool OBLIK = false;
                        public static bool REKLAM_PROC = false;
                        public static bool JM_POVRSINA = false;
                        public static bool JM_ZAPREMINA = false;
                        public static bool X3 = false;
                        public static bool Y3 = false;
                        public static bool Z3 = false;
                        public static bool NAS_BARKOD = false;
                        public static bool REFVAL = false;
                        public static bool KGID = false;
                    }
                    public class DisplayIndex
                    {
                        public static int ROBAID = 83;
                        public static int KATBR = 0;
                        public static int KOLICINA = 3;
                        public static int KATBRPRO = 1;
                        public static int NAZIV = 2;
                        public static int VRSTA = 83;
                        public static int AKTIVNA = 83;
                        public static int GRUPAID = 83;
                        public static int PODGRUPA = 83;
                        public static int PROID = 83;
                        public static int JM = 83;
                        public static int TARIFAID = 83;
                        public static int NABAVNACENA = 83;
                        public static int PRODAJNACENA = 83;
                        public static int DEVNABCENA = 83;
                        public static int FABRCENA = 83;
                        public static int STANJE = 83;
                        public static int NARUCENO = 83;
                        public static int REZERVISANO = 83;
                        public static int STANJEPOOTP = 83;
                        public static int TAKSA = 83;
                        public static int MARZA = 83;
                        public static int UVOZ = 83;
                        public static int TARBROJ = 83;
                        public static int AKCIZA = 83;
                        public static int NAZIVZACARINU = 83;
                        public static int NAZIVNAENG = 83;
                        public static int GARANTID = 83;
                        public static int ALTJM = 83;
                        public static int ALTKOL = 83;
                        public static int ALTNEDELJIVA = 83;
                        public static int TRPAK = 83;
                        public static int TRKOL = 83;
                        public static int JMSD = 83;
                        public static int KOMENTAR = 83;
                        public static int XOD = 83;
                        public static int XDO = 83;
                        public static int YOD = 83;
                        public static int YDO = 83;
                        public static int ZOD = 83;
                        public static int ZDO = 83;
                        public static int IMAROKTRAJANJA = 83;
                        public static int NACENOVNIKU = 83;
                        public static int ZAPID = 83;
                        public static int NORMA = 83;
                        public static int KALO = 83;
                        public static int TEZINA = 83;
                        public static int PIN = 83;
                        public static int KRITZAL = 83;
                        public static int OPTZAL = 83;
                        public static int KATEGORIJA = 83;
                        public static int IMASBROJ = 83;
                        public static int STANJEPOSER = 83;
                        public static int ZAPREMINA = 83;
                        public static int SLIKA = 83;
                        public static int PPID = 83;
                        public static int TRDECPAK = 83;
                        public static int PRODCENABP = 83;
                        public static int JMR = 83;
                        public static int STANJEPOREKLAM = 83;
                        public static int STANJEPOREVERSU = 83;
                        public static int ADR = 83;
                        public static int STANJE_MOJE_EKSP = 83;
                        public static int VPCID = 83;
                        public static int PROCPC = 83;
                        public static int DATUM_ISPORUKE = 83;
                        public static int REZERVISANO_MOJE_EKSP = 83;
                        public static int STANJEPOOTP_MOJE_EKSP = 83;
                        public static int STANJEPOSER_MOJE_EKSP = 83;
                        public static int NAZIVZASTAMPU = 83;
                        public static int ALTPIN = 83;
                        public static int TRPIN = 83;
                        public static int DRZAVAID = 83;
                        public static int LINKED_ROBAID = 83;
                        public static int OBLIK = 83;
                        public static int REKLAM_PROC = 83;
                        public static int JM_POVRSINA = 83;
                        public static int JM_ZAPREMINA = 83;
                        public static int X3 = 83;
                        public static int Y3 = 83;
                        public static int Z3 = 83;
                        public static int NAS_BARKOD = 83;
                        public static int REFVAL = 83;
                        public static int KGID = 83;
                    }
                }
            }
            public class ListeID
            {
                public static int RobaAkcije = 1; //Lista za stavke vezane za Poslovanje/komercijalne akcije/nedeljna akcija
            }
            public class Forma
            {
                public Forma(Form form, MForm mForm)
                {
                    if (Valid(form.Name)) //proverava da li je klasa uopste registrovana u tabeli MODUL - svaka klas mora biti registrovana!
                    {
                        mForm.helpWindow = new Help(form.Name);

                        ToolStripMenuItem tag = new ToolStripMenuItem();
                        ContextMenuStrip menuStrip = new ContextMenuStrip();
                        menuStrip.Items.AddRange(new ToolStripItem[] { tag });

                        tag.Name = "tagToolStripMenuItem";
                        tag.Size = new System.Drawing.Size(152, 22);
                        tag.Text = "tag";
                        tag.Click += delegate (object sender, EventArgs e) { UrediTagModula(sender, e, form.Name); };

                        form.ContextMenuStrip = menuStrip;

                        if (!Korisnik.ImaPravo(99998))
                        {
                            tag.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ovaj modul nije registrovan u bazi pa ga ne mozete koristiti!");
                        form.Dispose();
                    }
                }

                private static bool Valid(string className)
                {
                    using (FbConnection con = new FbConnection(M.Baza.connectionString))
                    {
                        con.Open();
                        using (FbCommand cmd = new FbCommand("SELECT COUNT(CLASSNAME) FROM MODUL WHERE CLASSNAME = @ClassName", con))
                        {
                            cmd.Parameters.AddWithValue("@ClassName", className);

                            FbDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                if (Convert.ToInt32(dr[0]) == 0)
                                    return false;
                                else
                                    return true;
                            }
                            else
                                return false;
                        }
                        con.Close();
                    }
                }

                private static void UrediTagModula(object sender, EventArgs e, string modulName)
                {
                    UrediTagModula utm = new Magacin.UrediTagModula(modulName);
                    utm.ShowDialog();
                }
            }
        }
        public class Prava
        {
            public static void Toggle(int korisnikId, int pravoId)
            {
                int i = (Korisnik.ImaPravo(pravoId, korisnikId)) ? 0 : 1;

                using(FbConnection con = new FbConnection(Baza.connectionString))
                {
                    con.Open();
                    using (FbCommand cmd = new FbCommand("UPDATE PRAVA SET IMA = @Ima WHERE KORISNIKID = @KorisnikId AND PRAVOID = @PravoID", con))
                    {
                        cmd.Parameters.AddWithValue("@Ima", i);
                        cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);
                        cmd.Parameters.AddWithValue("@PravoID", pravoId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            public static void Dodaj(int korisnikId, int pravoId)
            {
                using (FbConnection con = new FbConnection(Baza.connectionString))
                {
                    con.Open();
                    using (FbCommand cmd = new FbCommand("INSERT INTO PRAVA (ID, PRAVOID, KORISNIKID, IMA) VALUES (((SELECT MAX(ID) FROM PRAVA) + 1), @PravoID, @KorisnikID, 0)", con))
                    {
                        cmd.Parameters.AddWithValue("@PravoID", pravoId);
                        cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }

            public static void Dodaj(int korisnikId, int pravoId, int ima)
            {
                using (FbConnection con = new FbConnection(Baza.connectionString))
                {
                    con.Open();
                    using (FbCommand cmd = new FbCommand("INSERT INTO PRAVA (ID, PRAVOID, KORISNIKID, IMA) VALUES (((SELECT MAX(ID) FROM PRAVA) + 1), @PravoID, @KorisnikID, @Ima)", con))
                    {
                        cmd.Parameters.AddWithValue("@PravoID", pravoId);
                        cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);
                        cmd.Parameters.AddWithValue("@Ima", ima);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }
        public class Update
        {
            private Timer timer1;
            public Update(double sekundi)
            {
                timer1 = new Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = (int)(sekundi * 1000);
                timer1.Start();
            }

            private void timer1_Tick(object sender, EventArgs e)
            {
                Komercijalno.Initialize();
            }
        }

        public static void KreirajFormu(string nameSpace, string formClassName)
        {
            //Dodati da gleda prava!
            var type = Type.GetType(nameSpace + "." + formClassName);
            var form = Activator.CreateInstance(type) as Form;

            if (form != null)
                form.ShowDialog();
        }
        public static void KreirajFormu(string nameSpace, string formClassName, int parameter1)
        {
            var type = Type.GetType(nameSpace + "." + formClassName);
            var form = Activator.CreateInstance(type, parameter1) as Form;

            if (form != null)
                form.ShowDialog();
        }

    }  

    public enum NacinUplate
    {
        Gotovina,
        Virman,
        Kartica,
        Odlozeo
    }
    public enum Mesec
    {
        Januar,
        Februar,
        Mart,
        April,
        Maj,
        Jun,
        Jul,
        Avgust,
        Septembar,
        Oktobar,
        Novembar,
        Decembar,
        INVALID
    }

    public class _Korisnik
    {
        public int korisnikId;
        public string korisnik;
        public string sifra;
    }
    public class CiljMagacina
    {
        // _V oznacava da je variabla vrednosni iskaz
        // _P oznacava da je variabla procentualni iskaz

        private int id;
        private bool isGlobal;

        public bool procentualno;
        public double godisnjiRabat { get; set; }
        public double godisnjiRast { get; set; }

        public void Initialize(int korisnikId, int magacinId)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT JSONSTRING, ID FROM JSON WHERE TITLE = 'CiljMagacina' AND KORISNIKID = @KorisnikID AND MAGACINID = @MagacinID", con))
                {
                    cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);
                    cmd.Parameters.AddWithValue("@MagacinID", magacinId);

                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        DesifrujJson(dr[0].ToString());
                        id = Convert.ToInt32(dr[1]);
                    }
                    else
                    {
                        this.isGlobal = false;
                    }
                }
                con.Close();
            }
        }
        public void Zapisi(bool isGlobal, int? korisnikId, int? magacinId)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                string tit = "ERROR";
                int? kId = -1;
                int? mId = -1;

                if(korisnikId == null || magacinId == null)
                {
                    string[] msg =
                    {
                        "Doslo je do greske.",
                        "KorisnikID: " + korisnikId.ToString(),
                        "MagacinID" + magacinId.ToString()
                    };
                    MessageBox.Show(string.Join(Environment.NewLine, msg));
                    return;
                }
                else
                {
                    tit = "CiljMagacina";
                    kId = (isGlobal == true) ? -1 : korisnikId;
                    mId = magacinId;
                }

                if (Postoji(tit, kId, mId))
                {
                    using (FbCommand cmd = new FbCommand("UPDATE JSON SET JSONSTRING = @String WHERE ID = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@String", JsonConvert.SerializeObject(this));

                        cmd.ExecuteNonQuery();

                        if(!isGlobal)
                            MessageBox.Show("Izmene uspesno sacuvane!");
                    }
                }
                else
                {
                    using (FbCommand cmd = new FbCommand("INSERT INTO JSON (ID, TITLE, JSONSTRING, KORISNIKID, MAGACINID) VALUES (((SELECT COALESCE(MAX(ID), 0) FROM JSON) + 1), @Title , @String, @KorisnikID, @MagacinID)", con))
                    {
                        cmd.Parameters.AddWithValue("@Title", tit);
                        cmd.Parameters.AddWithValue("@String", JsonConvert.SerializeObject(this));
                        cmd.Parameters.AddWithValue("@KorisnikID", kId);
                        cmd.Parameters.AddWithValue("@MagacinID", mId);

                        cmd.ExecuteNonQuery();

                        if (!isGlobal)
                            MessageBox.Show("Cilj magacina uspesno dodat!");
                    }
                }
                con.Close();
            }
        }

        private void DesifrujJson(string jsonString)
        {
            CiljMagacina cm = JsonConvert.DeserializeObject<CiljMagacina>(jsonString);
            this.id = cm.id;
            this.isGlobal = cm.isGlobal;
            this.godisnjiRabat = cm.godisnjiRabat;
            this.godisnjiRast = cm.godisnjiRast;
            this.procentualno = cm.procentualno;
        }
        private bool Postoji(string title, int? korisnikId,  int? magacinId)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT ID FROM JSON WHERE TITLE = @Title AND MAGACINID = @MagacinID AND KORISNIKID = @KorisnikID", con))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@MagacinID", magacinId);
                    cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);

                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                        return true;
                    else
                        return false;
                }
            }
        }
        
        public static double UcitajCilj(int? korisnikId, int? magacinId)
        {
            if(korisnikId == null || magacinId == null)
            {
                return -1;
            }

            double d = 0;
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT JSONSTRING FROM JSON WHERE TITLE = 'CiljMagacina' AND KORISNIKID = @KorisnikID AND MAGACINID = @MagacinID", con))
                {
                    cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);
                    cmd.Parameters.AddWithValue("@MagacinID", magacinId);

                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        CiljMagacina cm = JsonConvert.DeserializeObject<CiljMagacina>(dr[0].ToString());
                        d = cm.godisnjiRast;
                    }
                }
                con.Close();
            }
            return d;
        }
    }
    public class Pravo
    {
        public int pravoId;
        public string opis;
    }
    public class Modul
    {
        public string dest;
        public string tag;
        public string className;
        public string classPar1_V;
        public string classPar1_T;
        public string beleska;
    }

    public class Int_Int
    {
        public int _int1 { get; set; }
        public int _int2 { get; set; }
    }
    public class Int_String
    {
        public int _int { get; set; }
        public string _string { get; set; }
    }
    public class Int_Double
    {
        public int _int { get; set; }
        public double _double { get; set; }
    }
    public class String_Double
    {
        public string _string { get; set; }
        public double _double { get; set; }
    }
}
