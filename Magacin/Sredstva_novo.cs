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
    public partial class Sredstva_novo : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public Sredstva_novo()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
        }

        private void Sredstva_novo_Load(object sender, EventArgs e)
        {
            magacin_cmb.DataSource = Komercijalno.UcitajMagacine();
            magacin_cmb.DisplayMember = "_string";
            magacin_cmb.ValueMember = "_int";

            magacin_cmb.SelectedValue = (Korisnik.magacinId >= 12 && Korisnik.magacinId <= 28) ? Korisnik.magacinId : -1;

            UcitajVrste();

            ucitano = true;
        }

        private void UcitajVrste()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT SREDSTVO_VRSTAID, NAZIV FROM SREDSTVO_VRSTA", con))
                {
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Int_String> list = new List<Int_String>();

                    while(dr.Read())
                    {
                        list.Add(new Int_String { _int = Convert.ToInt32(dr[0]), _string = dr[1].ToString() });
                    }

                    vrsta_cmb.DataSource = list;
                    vrsta_cmb.DisplayMember = "_string";
                    vrsta_cmb.ValueMember = "_int";
                }
                con.Close();
            }
        }

        private void kreiraj_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(naziv_txt.Text))
            {
                MessageBox.Show("Morate uneti naziv sredstva!");
                return;
            }
            if((int)magacin_cmb.SelectedValue < 0)
            {
                MessageBox.Show("Morate izabrati magacin u kojem se sredstvo nalazi!");
                return;
            }
            if((int)vrsta_cmb.SelectedValue < 0)
            {
                MessageBox.Show("Morate izabrati vrstu sredstva!");
                return;
            }

            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("INSERT INTO SREDSTVO (SREDSTVOID, NAZIV, OPIS, SREDSTVO_VRSTAID, MAGACINID) VALUES (((SELECT COALESCE(MAX(SREDSTVOID), 0) FROM SREDSTVO) + 1), @Naziv, @Opis, @SREDSTVO_VRSTAID, @MAGACINID)", con))
                {
                    cmd.Parameters.AddWithValue("@Naziv", naziv_txt.Text);
                    cmd.Parameters.AddWithValue("@Opis", opis_rtxt.Text);
                    cmd.Parameters.AddWithValue("@SREDSTVO_VRSTAID", vrsta_cmb.SelectedValue);
                    cmd.Parameters.AddWithValue("@MAGACINID", magacin_cmb.SelectedValue);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Novo sredstvo uspesno kreirano!");
                }
                con.Close();
            }
        }
    }
}
