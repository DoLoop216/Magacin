using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magacin
{
    class Komercijalno
    {
        public static DataTable robaTable;

        public static void Initialize()
        {
            Komercijalno.robaTable = UcitajRobuKomercijalnog(M.Baza.connectionKomercijalno2018);
        }
        public static bool Initialize(Form form)
        {
            Komercijalno.robaTable = UcitajRobuKomercijalnog(M.Baza.connectionKomercijalno2018);
            return true;
        }

        public static DataTable UcitajRobuKomercijalnog(string connString)
        {
            DataTable dt = new DataTable();
            using (FbConnection con = new FbConnection(connString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT ROBAID, NAZIV, KATBR, KATBRPRO, STANJE FROM ROBA", con))
                {
                    da.Fill(dt);
                }
                con.Close();
            }
            return dt;
        }
        public static List<Int_String> UcitajMagacine()
        {
            List<Int_String> list = new List<Int_String>();
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT MAGACINID, NAZIV FROM MAGACIN", con))
                {
                    FbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        list.Add(new Int_String { _int = Convert.ToInt32(dr[0]), _string = dr[1].ToString() });
                    }
                }
                con.Close();
            }
            return list;
        }

        public static double PrometMagacina(int magacinId)
        {
            double d = 0;
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT SUM(DUGUJE) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID", con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacinId);

                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        d = Convert.ToDouble(dr[0]);
                    }
                }
                con.Close();
            }
            return d;
        }
        public static double PrometMagacina(int magacinId, DateTime datum)
        {
            double d = 0;
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT SUM(DUGUJE) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID AND DATUM = @Datum", con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacinId);
                    cmd.Parameters.AddWithValue("@Datum", datum);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        d = (dr[0] is DBNull) ? 0 : Convert.ToDouble(dr[0]);
                    }
                }
                con.Close();
            }
            return d;
        }
        public static double PrometMagacina(int magacinId, NacinUplate nacinUplate)
        {
            double d = 0;
            int nuid = 5;

            switch (nacinUplate)
            {
                case NacinUplate.Gotovina:
                    nuid = 5;
                    break;
                case NacinUplate.Kartica:
                    nuid = 11;
                    break;
                case NacinUplate.Odlozeo:
                    nuid = 10;
                    break;
                case NacinUplate.Virman:
                    nuid = 1;
                    break;
            }

            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT SUM(DUGUJE) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID AND NUID = @NUID", con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacinId);
                    cmd.Parameters.AddWithValue("@NUID", nuid);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        d = (dr[0] is DBNull) ? 0 : Convert.ToDouble(dr[0]);
                    }
                }
                con.Close();
            }
            return d;
        }
        public static double PrometMagacina(int magacinId, DateTime datum, NacinUplate nacinUplate)
        {
            double d = 0;
            int nuid = 5;

            switch(nacinUplate)
            {
                case NacinUplate.Gotovina:
                    nuid = 5;
                    break;
                case NacinUplate.Kartica:
                    nuid = 11;
                    break;
                case NacinUplate.Odlozeo:
                    nuid = 10;
                    break;
                case NacinUplate.Virman:
                    nuid = 1;
                    break;
            }

            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT SUM(DUGUJE) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID AND DATUM = @Datum AND NUID = @NUID", con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacinId);
                    cmd.Parameters.AddWithValue("@Datum", datum.Date);
                    cmd.Parameters.AddWithValue("@NUID", nuid);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        d = (dr[0] is DBNull) ? 0 : Convert.ToDouble(dr[0]);
                    }
                }
                con.Close();
            }
            return d;
        }
        public static double PrometMagacina(int magacinId, Mesec mesec, int godina)
        {
            double d = 0;
            DateTime pocetak = M.Godina.PrviDanUMesecu(mesec, godina);
            DateTime kraj = M.Godina.PoslednjiDanUMesecu(mesec, godina);

            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT SUM(DUGUJE) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID AND DATUM >= @DatumP AND DATUM <= @DatumK", con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacinId);
                    cmd.Parameters.AddWithValue("@DatumP", pocetak);
                    cmd.Parameters.AddWithValue("@DatumK", kraj);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        d = (dr[0] is DBNull) ? 0 : Convert.ToDouble(dr[0]);
                    }
                }
                con.Close();
            }

            return d;
        }

        public static List<String_Double> DnevniPrometSvihMagacina()
        {
            List<String_Double> list = new List<String_Double>();
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT SUM(DUGUJE) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID", con))
                {
                    cmd.Parameters.Add("@MagacinID", FbDbType.Integer);

                    for(int i = 12; i < 29; i++)
                    {
                        cmd.Parameters["@MagacinID"].Value = i;
                        using (FbDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                list.Add(new String_Double { _string = String.Format("M{0}", i), _double = Convert.ToDouble(dr[0]) });
                            }
                        }
                    }
                }
                con.Close();
            }
            return list;
        }
        public static List<String_Double> DnevniPrometSvihMagacina(DateTime datum)
        {
            List<String_Double> list = new List<String_Double>();
            using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT SUM(DUGUJE) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID AND DATUM = @Datum", con))
                {
                    cmd.Parameters.Add("@MagacinID", FbDbType.Integer);
                    cmd.Parameters.AddWithValue("@Datum", datum);

                    for (int i = 12; i < 29; i++)
                    {
                        cmd.Parameters["@MagacinID"].Value = i;
                        using (FbDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                list.Add(new String_Double { _string = String.Format("M{0}", i), _double = (dr[0] is DBNull) ? 0 : Convert.ToDouble(dr[0]) });
                            }
                        }
                    }
                }
                con.Close();
            }
            return list;
        }
    }
}
