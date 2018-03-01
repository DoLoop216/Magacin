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
    public partial class Logovanje : Form
    {
        public Logovanje()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(M.Podesavanja.UcitajPodesavanja() == false)
            {
                MessageBox.Show("Niste definisali putanju do baze!");
                PutanjaBaze pb = new PutanjaBaze();
                pb.ShowDialog();
            }
        }

        private void loguj_btn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(korisnik_txt.Text))
            {
                MessageBox.Show("Morate uneti korisnicko ime!");
                return;
            }
            if(string.IsNullOrEmpty(lozinka_txt.Text))
            {
                MessageBox.Show("Morate uneti sifru!");
                return;
            }

            using(FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT KORISNIKID, SIFRA, MAGACINID FROM KORISNICI WHERE KORISNIK = @Korisnik", con))
                {
                    cmd.Parameters.AddWithValue("@Korisnik", korisnik_txt.Text);

                    FbDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        if(lozinka_txt.Text.Equals(dr[1].ToString()))
                        {
                            Korisnik.korisnikId = Convert.ToInt32(dr[0]);
                            Korisnik.nadimak = korisnik_txt.Text;
                            Korisnik.magacinId = (dr[2] is DBNull) ? -1 : Convert.ToInt32(dr[2]);
                            if(!Korisnik.ImaPravo(0))
                            {
                                MessageBox.Show("Korisnik nema pravo koriscenja programa!");
                                Application.Exit();
                            }
                            Main m = new Main();
                            if (m.IsDisposed)
                            {
                                Application.Exit();
                            }
                            else
                            {
                                m.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pogresna lozinka!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Korisnik ne postoji!");
                    }
                }
                con.Close();
            }
        }

        private void korisnik_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                loguj_btn.PerformClick();
            }
        }

        private void lozinka_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                loguj_btn.PerformClick();
            }
        }
    }
}
