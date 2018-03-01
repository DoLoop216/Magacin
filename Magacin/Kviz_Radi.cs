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
    public partial class Kviz_Radi : Form
    {
        Random rnd = new Random();

        bool ucitano = false;

        public Kviz_Radi()
        {
            InitializeComponent();
        }

        private void RadiKviz_Load(object sender, EventArgs e)
        {
            Ucitaj();
            listBox1.SelectedIndex = 1; //Ovo stavljam jer je po defaultu 0
            ucitano = true;
            listBox1.SelectedIndex = 0; //Ovo stavljam da bi pokrenuo event koji osvezava label sa brojem pitanja
        }

        private void Ucitaj()
        {
            listBox1.DataSource = Kviz.UcitajGrupe();
            listBox1.DisplayMember = "_string";
            listBox1.ValueMember = "_int";
        }

        private void PokreniTest()
        {
            int nPitanja = Kviz.BrojPitanjaUGrupi((int)listBox1.SelectedValue);
            List<Pitanje> pitanja = Kviz.UcitajPitanja((int)listBox1.SelectedValue);
            if(pitanja.Count <= 0)
            {
                MessageBox.Show("Nijedno pitanje nije pronadjeno za ovu vrstu testa!");
                return;
            }
            Pitanje pitanje = pitanja[rnd.Next(0, pitanja.Count - 1)];

            Kviz_Pitanje1 k = new Kviz_Pitanje1(pitanje.naslov, pitanje.pitanje, pitanje.odgovor1, pitanje.odgovor2, pitanje.odgovor3, pitanje.odgovor4, pitanje.odgovor5, nPitanja - 1, 1);
            k.ShowDialog();
        }

        private void pokreni_btn_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count != 1)
            {
                MessageBox.Show("Morate izabrati jednu vrstu testa!");
                return;
            }

            PokreniTest();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ucitano)
                brojPitanja_lbl.Text = "Broj pitanja: " + Kviz.BrojPitanjaUGrupi((int)listBox1.SelectedValue).ToString();
        }
    }
}
