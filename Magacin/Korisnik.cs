using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magacin
{
    class Korisnik
    {
        public static int korisnikId;
        public static string nadimak;
        public static int magacinId;

        public static bool ImaPravo(int pravoId)
        {
            bool i = false;
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT IMA FROM PRAVA WHERE KORISNIKID = @KorisnikId AND PRAVOID = @PravoID", con))
                {
                    cmd.Parameters.AddWithValue("@KorisnikId", korisnikId);
                    cmd.Parameters.AddWithValue("@PravoID", pravoId);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        if (Convert.ToInt32(dr[0]) == 1)
                        {
                            i = true;
                        }
                    }
                }
            }
            return i;
        }

        public static bool ImaPravo(int pravoId, int korisnikId)
        {
            bool i = false;
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT IMA FROM PRAVA WHERE KORISNIKID = @KorisnikId AND PRAVOID = @PravoID", con))
                {
                    cmd.Parameters.AddWithValue("@KorisnikId", korisnikId);
                    cmd.Parameters.AddWithValue("@PravoID", pravoId);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        if (Convert.ToInt32(dr[0]) == 1)
                        {
                            i = true;
                        }
                    }
                }
            }
            return i;
        }

        public static string UcitajBelesku()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT BELESKA FROM KORISNICI WHERE KORISNIKID = @KorisnikID", con))
                {
                    cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        return dr[0].ToString();
                    }
                }
                con.Close();
            }
            return "";
        }
        public static void SacuvajBelesku(string beleska)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("UPDATE KORISNICI SET BELESKA = @Beleska WHERE KORISNIKID = @KorisnikID", con))
                {
                    cmd.Parameters.AddWithValue("@Beleska", beleska);
                    cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Beleska uspesno sacuvana!");
                }
                con.Close();
            }
        }
    }
}
