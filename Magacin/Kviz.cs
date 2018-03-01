using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Magacin
{
    class Kviz
    {
        public static DataTable UcitajPitanja()
        {
            DataTable dt = new DataTable(); ;
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT * FROM KVIZ_PITANJA", con))
                {
                    da.Fill(dt);
                }
                con.Close();
            }
            return dt;
        }
        public static List<Pitanje> UcitajPitanja(int grupaId)
        {
            List<Pitanje> l = new List<Pitanje>();
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT PITANJEID, NASLOV, ODGOVOR1, ODGOVOR2, ODGOVOR3, ODGOVOR4, ODGOVOR5, POENA, PITANJE FROM KVIZ_PITANJA WHERE KVIZ_GRUPA_ID = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", grupaId);

                    FbDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        l.Add(new Pitanje { id = Convert.ToInt32(dr[0]), naslov = dr[1].ToString(), odgovor1 = dr[2].ToString(), odgovor2 = dr[3].ToString(), odgovor3 = dr[4].ToString(), odgovor4 = dr[5].ToString(), odgovor5 = dr[6].ToString(), poena = Convert.ToDouble(dr[7]), pitanje = dr[8].ToString() });
                    }
                }
                con.Close();
            }
            return l;
        }
        public static void KreirajPitanje(string naslov, string pitanje, string odgovor1, string odgovor2, string odgovor3, string odgovor4, string odgovor5, double poena, int grupaId, int tacanOdgovor)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("INSERT INTO KVIZ_PITANJA (PITANJEID, NASLOV, PITANJE, ODGOVOR1, ODGOVOR2, ODGOVOR3, ODGOVOR4, ODGOVOR5, POENA, KVIZ_GRUPA_ID, TACAN_ODGOVOR) VALUES (((SELECT COALESCE(MAX(PITANJEID), 0) FROM KVIZ_PITANJA) + 1), @Naslov, @Pitanje, @Odgovor1, @Odgovor2, @Odgovor3, @Odgovor4, @Odgovor5, @Poena, @GrupaID, @TacanOdgovor)", con))
                {
                    cmd.Parameters.AddWithValue("@Naslov", naslov);
                    cmd.Parameters.AddWithValue("@Pitanje", pitanje);
                    cmd.Parameters.AddWithValue("@Odgovor1", odgovor1);
                    cmd.Parameters.AddWithValue("@Odgovor2", odgovor2);
                    cmd.Parameters.AddWithValue("@Odgovor3", odgovor3);
                    cmd.Parameters.AddWithValue("@Odgovor4", odgovor4);
                    cmd.Parameters.AddWithValue("@Odgovor5", odgovor5);
                    cmd.Parameters.AddWithValue("@Poena", poena);
                    cmd.Parameters.AddWithValue("@GrupaID", grupaId);
                    cmd.Parameters.AddWithValue("@TacanOdgovor", tacanOdgovor);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pitanje uspesno kreirano!");
                }
                con.Close();
            }
        }

        public static List<Int_String> UcitajGrupe()
        {
            List<Int_String> g = new List<Int_String>();
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using(FbCommand cmd = new FbCommand("SELECT KVIZ_GRUPA_ID, NAZIV FROM KVIZ_GRUPA", con))
                {
                    FbDataReader dr = cmd.ExecuteReader();
                    
                    while(dr.Read())
                    {
                        g.Add(new Int_String { _int = Convert.ToInt32(dr[0]), _string = dr[1].ToString() });
                    }
                }
                con.Close();
            }
            return g;
        }
        public static string FormaGrupe(int grupaId)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT FORMA_KVIZA FROM KVIZ_GRUPA WHERE KVIZ_GRUPA_ID = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", grupaId);

                    FbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        return dr[0].ToString();
                    else
                        return "ERROR";
                }
            }
        }
        public static bool GrupaPostoji(string naziv)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT KVIZ_GRUPA_ID FROM KVIZ_GRUPA WHERE NAZIV = @Naziv", con))
                {
                    cmd.Parameters.AddWithValue("@Naziv", naziv);

                    FbDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        return true;
                    }
                }
                con.Close();
            }
            return false;
        }
        public static void DodajGrupu(string naziv, string forma, int brojPitanja)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("INSERT INTO KVIZ_GRUPA (KVIZ_GRUPA_ID, NAZIV, FORMA_KVIZA, BROJ_PITANJA) VALUES (((SELECT COALESCE(MAX(KVIZ_GRUPA_ID), 0) FROM KVIZ_GRUPA) + 1), @Naziv, @Forma, @BP)", con))
                {
                    cmd.Parameters.AddWithValue("@Naziv", naziv);
                    cmd.Parameters.AddWithValue("@Forma", forma);
                    cmd.Parameters.AddWithValue("@BP", brojPitanja);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Grupa uspesno dodata!");
                }
                con.Close();
            }
        }
        public static void IzmeniGrupu(int id, string noviNaziv, string novaForma, int noviBrojPitanja)
        {
            using(FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("UPDATE KVIZ_GRUPA SET NAZIV = @Naziv, FORMA_KVIZA = @Forma, BROJ_PITANJA = @BP WHERE KVIZ_GRUPA_ID = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Naziv", noviNaziv);
                    cmd.Parameters.AddWithValue("@BP", noviBrojPitanja);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Grupa uspesno izmenjena!");
                }
                con.Close();
            }
        }
        public static void ObrisiGrupu(int id)
        {
            DialogResult dr = MessageBox.Show("Da li sigurno zelite obrisati ovu grupu?", "Potvrdi", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                using (FbConnection con = new FbConnection(M.Baza.connectionString))
                {
                    con.Open();
                    using (FbCommand cmd = new FbCommand("DELETE FROM KVIZ_GRUPA WHERE KVIZ_GRUPA_ID = @ID", con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Grupa uspesno obrisana!");
                    }
                    con.Close();
                }
            }
        }
        public static string[] FormeGrupe()
        {
            return new string[]
            {
                "CLASSIC"
            };
        }
        public static int BrojPitanjaUGrupi(int grupaId)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT BROJ_PITANJA FROM KVIZ_GRUPA WHERE KVIZ_GRUPA_ID = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", grupaId);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                        return Convert.ToInt32(dr[0]);
                    else
                        return 0;
                }
            }
        }
    }

    public class Pitanje
    {
        public int id;
        public string naslov;
        public string pitanje;
        public string odgovor1;
        public string odgovor2;
        public string odgovor3;
        public string odgovor4;
        public string odgovor5;
        public double poena;
    }
}
