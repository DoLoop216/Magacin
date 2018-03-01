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
    public partial class UspesnostMagacina : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        bool ucitano = false;

        private double trenutnaGodinaUplaceno_Magacin = 0;
        private double jednaGodinaPreUplaceno_Magacin = 0;
        private double dveGodinePreUplaceno_Magacin = 0;
        private double triGodinePreUplaceno_Magacin = 0;

        private double trenutnaGodinaUplaceno_TD = 0;
        private double jednaGodinaPreUplaceno_TD = 0;
        private double dveGodinePreUplaceno_TD = 0;
        private double triGodinePreUplaceno_TD = 0;
        
        public UspesnostMagacina()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            UcitajMagacine();
            magacini_cmb.Enabled = false;
        }

        private void UspesnostMagacina_Load(object sender, EventArgs e)
        {
            Setup();
            SetupPoPravilima();

            ucitano = true;
        }

        private void Setup()
        {
            magacini_cmb.SelectedValue = Korisnik.magacinId;
            periodObracuna_cmb.SelectedIndex = 0;

            triGodPre_lbl.Text = M.Godina.triGodPre;
            dveGodPre_lbl.Text = M.Godina.dveGodPre;
            jednaGodPre_lbl.Text = M.Godina.jednaGodPre;
            trenutnaGodina_lbl.Text = M.Godina.trenutnaGodina;

            triGodPre1_lbl.Text = M.Godina.triGodPre;
            dveGodPre1_lbl.Text = M.Godina.dveGodPre;
            jednaGodPre1_lbl.Text = M.Godina.jednaGodPre;
            trenutnaGodina1_lbl.Text = M.Godina.trenutnaGodina;

            trenutnaGodina_txt.BackColor = Control.DefaultBackColor;
            trenutnaGodina1_txt.BackColor = Control.DefaultBackColor;
            jednaGodPre_txt.BackColor = Control.DefaultBackColor;
            jednaGodPre1_txt.BackColor = Control.DefaultBackColor;
            dveGodPre_txt.BackColor = Control.DefaultBackColor;
            dveGodPre1_txt.BackColor = Control.DefaultBackColor;
            triGodPre_txt.BackColor = Control.DefaultBackColor;
            triGodPre1_txt.BackColor = Control.DefaultBackColor;
        }
        private void SetupPoPravilima()
        {
            if(Korisnik.ImaPravo(22003))
            {
                magacini_cmb.Enabled = true;
            }
        }
        private void PostaviVrednosti()
        {
            double dv_M = (((dveGodinePreUplaceno_Magacin / triGodinePreUplaceno_Magacin) - 1) * 100);
            double jed_M = (((jednaGodinaPreUplaceno_Magacin / dveGodinePreUplaceno_Magacin) - 1) * 100);
            double tr_M = (((trenutnaGodinaUplaceno_Magacin / jednaGodinaPreUplaceno_Magacin) - 1) * 100);

            double dv_TD = (((dveGodinePreUplaceno_TD / triGodinePreUplaceno_TD) - 1) * 100);
            double jed_TD = (((jednaGodinaPreUplaceno_TD / dveGodinePreUplaceno_TD) - 1) * 100);
            double tr_TD = (((trenutnaGodinaUplaceno_TD / jednaGodinaPreUplaceno_TD) - 1) * 100);
            
            double cagr_TD = 0;
            double cagr_M = 0;
            trenutnaGodina_txt.Text = String.Format("{0:#.00}%", Math.Abs(tr_M));
            jednaGodPre_txt.Text = String.Format("{0:#.00}%", Math.Abs(jed_M));
            dveGodPre_txt.Text = String.Format("{0:#.00}%", Math.Abs(dv_M));
            triGodPre_txt.Text = String.Format("{0:#.00}%", 0);

            trenutnaGodina1_txt.Text = String.Format("{0:#.00}%", Math.Abs(tr_TD));
            jednaGodPre1_txt.Text = String.Format("{0:#.00}%", Math.Abs(jed_TD));
            dveGodPre1_txt.Text = String.Format("{0:#.00}%", Math.Abs(dv_TD));
            triGodPre1_txt.Text = String.Format("{0:#.00}%", 0);

            cagr_TD = Math.Pow((triGodinePreUplaceno_TD / trenutnaGodinaUplaceno_TD), 0.25) - 1;
            cagr_M = Math.Pow((triGodinePreUplaceno_Magacin / trenutnaGodinaUplaceno_Magacin), 0.25) - 1;

            cagr_M_txt.Text = String.Format("{0:#.00}%", Math.Abs(cagr_M));
            cagr_TD_txt.Text = String.Format("{0:#.00}%", Math.Abs(cagr_TD));

            for (int i = 0; i < 10; i++)
            {
                TextBox t = new TextBox();
                double v = 0;
                switch(i)
                {
                    case 0:
                        t = trenutnaGodina_txt;
                        v = tr_M;
                        break;
                    case 1:
                        t = jednaGodPre_txt;
                        v = jed_M;
                        break;
                    case 2:
                        t = dveGodPre_txt;
                        v = dv_M;
                        break;
                    case 3:
                        t = triGodPre_txt;
                        v = 0;
                        break;
                    case 4:
                        t = trenutnaGodina1_txt;
                        v = tr_TD;
                        break;
                    case 5:
                        t = jednaGodPre1_txt;
                        v = jed_TD;
                        break;
                    case 6:
                        t = dveGodPre1_txt;
                        v = dv_TD;
                        break;
                    case 7:
                        t = triGodPre1_txt;
                        v = 0;
                        break;
                    case 8:
                        t = cagr_TD_txt;
                        v = cagr_TD;
                        break;
                    case 9:
                        t = cagr_M_txt;
                        v = cagr_M;
                        break;
                }
            }
        }

        private void UcitajMagacine()
        {
            magacini_cmb.DataSource = Komercijalno.UcitajMagacine();
            magacini_cmb.ValueMember = "_int";
            magacini_cmb.DisplayMember = "_string";
        }

        private void GodinaUOdnosuNaPrethodnu()
        {
            string command_M = "SELECT SUM(UPLACENO) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID AND FLAG = 1 AND KODDOK = 0";
            string command_TD = "SELECT SUM(UPLACENO) FROM DOKUMENT WHERE VRDOK = 15 AND FLAG = 1 AND KODDOK = 0";

            switch (periodObracuna_cmb.SelectedIndex)
            {
                case 0: //Za period
                    command_M = "SELECT SUM(UPLACENO) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID AND FLAG = 1 AND KODDOK = 0";
                    command_TD = "SELECT SUM(UPLACENO) FROM DOKUMENT WHERE VRDOK = 15 AND FLAG = 1 AND KODDOK = 0";
                    break;
                case 1: //Za celu godinu
                    command_M = "SELECT SUM(UPLACENO) FROM DOKUMENT WHERE VRDOK = 15 AND MAGACINID = @MagacinID AND FLAG = 1 AND KODDOK = 0";
                    command_TD = "SELECT SUM(UPLACENO) FROM DOKUMENT WHERE VRDOK = 15 AND FLAG = 1 AND KODDOK = 0";
                    break;
            }
            
            //Trenutna godina
            using (FbConnection con = new FbConnection(M.Godina.trenutnaGodinaConnString))
            {
                con.Open();

                //Ceo termodom
                using (FbCommand cmd = new FbCommand(command_TD, con))
                {
                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        trenutnaGodinaUplaceno_TD = Convert.ToDouble(dr[0]);
                    }
                }
                //Magacin
                using (FbCommand cmd = new FbCommand(command_M, con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacini_cmb.SelectedValue);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        trenutnaGodinaUplaceno_Magacin = Convert.ToDouble(dr[0]);
                    }
                }

                con.Close();
            }

            //Jedna godina pre
            using (FbConnection con = new FbConnection(M.Godina.jednaGodPreConnString))
            {
                con.Open();

                //Ceo termodom
                using (FbCommand cmd = new FbCommand(command_TD, con))
                {
                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        jednaGodinaPreUplaceno_TD = Convert.ToDouble(dr[0]);
                    }
                }
                //Magacin
                using (FbCommand cmd = new FbCommand(command_M, con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacini_cmb.SelectedValue);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        jednaGodinaPreUplaceno_Magacin = Convert.ToDouble(dr[0]);
                    }
                }

                con.Close();
            }

            //Dve godina pre
            using (FbConnection con = new FbConnection(M.Godina.dveGodPreConnString))
            {
                con.Open();

                //Ceo termodom
                using (FbCommand cmd = new FbCommand(command_TD, con))
                {
                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        dveGodinePreUplaceno_TD = Convert.ToDouble(dr[0]);
                    }
                }
                //Magacin
                using (FbCommand cmd = new FbCommand(command_M, con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacini_cmb.SelectedValue);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        dveGodinePreUplaceno_Magacin = Convert.ToDouble(dr[0]);
                    }
                }

                con.Close();
            }

            //Tri godina pre
            using (FbConnection con = new FbConnection(M.Godina.triGodPreConnString))
            {
                con.Open();

                //Ceo termodom
                using (FbCommand cmd = new FbCommand(command_TD, con))
                {
                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        triGodinePreUplaceno_TD = Convert.ToDouble(dr[0]);
                    }
                }
                //Magacin
                using (FbCommand cmd = new FbCommand(command_M, con))
                {
                    cmd.Parameters.AddWithValue("@MagacinID", magacini_cmb.SelectedValue);

                    FbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        triGodinePreUplaceno_Magacin = Convert.ToDouble(dr[0]);
                    }
                }

                con.Close();
            }
        }

        private void magacini_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ucitano)
            {
                GodinaUOdnosuNaPrethodnu();
                PostaviVrednosti();
            }
        }
    }
}
