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
    public partial class Kviz_Pitanje1_Novo : Form
    {
        public Kviz_Pitanje1_Novo()
        {
            InitializeComponent();
        }

        private void Kviz_Pitanje1_Novo_Load(object sender, EventArgs e)
        {
            Ucitaj();
        }

        private void Ucitaj()
        {
            List<Int_String> grupe = Kviz.UcitajGrupe();

            checkedListBox1.DataSource = grupe;
            checkedListBox1.DisplayMember = "_string";
            checkedListBox1.ValueMember = "_int";
        }

        private void kreiraj_btn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(naslov_txt.Text))
            {
                MessageBox.Show("Morate uneti naslov pitanja!");
                return;
            }
            if(string.IsNullOrEmpty(pitanje_rtxt.Text))
            {
                MessageBox.Show("Morate uneti pitanje!");
                return;
            }
            if(string.IsNullOrEmpty(poena_txt.Text))
            {
                MessageBox.Show("Morate uneti broj poena!");
                return;
            }
            if(checkedListBox1.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Morate izabrati barem jednu grupu!");
                return;
            }
            if(string.IsNullOrEmpty(odgovor1_txt.Text) || string.IsNullOrEmpty(odgovor2_txt.Text))
            {
                MessageBox.Show("Morate uneti barem dva odgovora!");
                return;
            }
            if(checkBox1.Checked == false && checkBox2.Checked == false && checkBox4.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                MessageBox.Show("Morate izabrati barem jedan odgovor kao tacan!");
                return;
            }


            int tacanOdgovor = -1;
            if (checkBox1.Checked == true)
                tacanOdgovor = 1;
            if (checkBox2.Checked == true)
                tacanOdgovor = 2;
            if (checkBox3.Checked == true)
                tacanOdgovor = 3;
            if (checkBox4.Checked == true)
                tacanOdgovor = 4;
            if (checkBox5.Checked == true)
                tacanOdgovor = 5;

            Kviz.KreirajPitanje(naslov_txt.Text, pitanje_rtxt.Text, odgovor1_txt.Text, odgovor2_txt.Text, odgovor3_txt.Text, odgovor4_txt.Text, odgovor5_txt.Text, Convert.ToDouble(poena_txt.Text), (checkedListBox1.CheckedItems[0] as Int_String)._int, tacanOdgovor);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox5.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox5.Checked = false;
            checkBox4.Checked = false;
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox5.Checked = false;
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
    }
}
