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
    public partial class IzborRobe : Form
    {
        private string[] Kolone;
        DataTable robaKomercijalnog;
        Dokument1 dokument;
        RobaAkcije robaAkcije;

        public IzborRobe(DataTable robaKomercijalnog, Dokument1 dokument)
        {
            InitializeComponent();
            this.robaKomercijalnog = robaKomercijalnog;
            this.dokument = dokument;
            kolicina_txt.Enabled = false;
        }

        public IzborRobe(DataTable robaKomercijalnog, RobaAkcije robaAkcije)
        {
            InitializeComponent();
            this.robaKomercijalnog = robaKomercijalnog;
            this.robaAkcije = robaAkcije;
            kolicina_txt.Enabled = false;
        }

        private void IzborRobe_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = robaKomercijalnog;
            PodesiKolone();
        }
        
        private void PodesiKolone()
        {
            Kolone = new string[dataGridView1.Columns.Count];

            for(int i = 0; i < Kolone.Length; i++)
            {
                Kolone[i] = dataGridView1.Columns[i].Name;
            }

            foreach(string s in Kolone)
            {
                filterKolone_cmb.Items.Add(s);
            }
            filterKolone_cmb.SelectedItem = "NAZIV";
            DataGridViewColumn c = dataGridView1.Columns[filterKolone_cmb.SelectedItem.ToString()];
            dataGridView1.Sort(c, ListSortDirection.Ascending);

            dataGridView1.Columns["ROBAID"].Visible = false;
            dataGridView1.Columns["NAZIV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["KATBR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["KATBRPRO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["STANJE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void filterKolone_txt_KeyDown(object sender, KeyEventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("{1} LIKE '%{0}%'", filterKolone_txt.Text, filterKolone_cmb.SelectedItem.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                kolicina_txt.Enabled = true;
                kolicina_txt.SelectAll();
                kolicina_txt.Focus();
                e.Handled = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            kolicina_txt.Enabled = true;
            kolicina_txt.SelectAll();
            kolicina_txt.Focus();
        }

        private void kolicina_txt_EnabledChanged(object sender, EventArgs e)
        {
            if(kolicina_txt.Enabled)
            {
                kolicina_txt.BackColor = Color.White;
            }
            else
            {
                kolicina_txt.BackColor = Color.DimGray;
            }
        }

        private void kolicina_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if(string.IsNullOrWhiteSpace(kolicina_txt.Text))
                {
                    MessageBox.Show("Morate uneti kolicinu!");
                    return;
                }
                if (dokument != null)
                {
                    if (M.Baza.Magacin.Dokument.ImaStavku(dokument.vrDok, dokument.brDok, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ROBAID"].Value)))
                    {
                        MessageBox.Show("Dokument vec sadrzi ovu stavku!");
                    }
                    else
                    {
                        dokument.UnesiStavku(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ROBAID"].Value), Convert.ToDouble(kolicina_txt.Text), dataGridView1.SelectedRows[0].Cells["NAZIV"].Value.ToString());
                    }
                }
                else if (robaAkcije != null)
                {
                    double procenat = 0;
                    MessageBoxWithValue msg = new MessageBoxWithValue("Izbor popusta", "Unesite zeljeni procenat popusta koji ne sme premasivati 100!");
                    msg.brojevi = true;
                    msg.maxBroj = 100;
                    msg.ShowDialog();
                    if(msg.DialogResult == DialogResult.OK)
                    {
                        procenat = Convert.ToDouble(msg.returnValue);
                        robaAkcije.DodajStavkuUAkciju(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ROBAID"].Value), Convert.ToDouble(kolicina_txt.Text), procenat);
                    }
                }
                else
                {
                    MessageBox.Show("Doslo je do greske!");
                }
                kolicina_txt.Enabled = false;
            }
        }

        private void kolicina_txt_Leave(object sender, EventArgs e)
        {
            kolicina_txt.Enabled = false;
        }
    }
}
