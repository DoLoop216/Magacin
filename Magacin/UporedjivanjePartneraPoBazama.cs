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
    public partial class UporedjivanjePartneraPoBazama : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        private DataTable Partneri_2018 = new DataTable();
        private DataTable Partneri_2017 = new DataTable();
        private DataTable Partneri_2016 = new DataTable();
        private DataTable Partneri_2015 = new DataTable();
        public UporedjivanjePartneraPoBazama()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            uporedi_btn.Enabled = false;
        }

        private void UporedjivanjePartneraPoBazama_Load(object sender, EventArgs e)
        {
            UcitajBaze();
            PostaviBaze();
        }

        private void UcitajBaze()
        {
            try
            {
                using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
                {
                    con.Open();
                    using (FbDataAdapter da = new FbDataAdapter("SELECT PPID, NAZIV, PIB FROM PARTNER ORDER BY PPID ASCENDING", con))
                    {
                        da.Fill(Partneri_2018);
                    }
                    con.Close();
                }

                using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2017))
                {
                    con.Open();
                    using (FbDataAdapter da = new FbDataAdapter("SELECT PPID, NAZIV, PIB FROM PARTNER ORDER BY PPID ASCENDING", con))
                    {
                        da.Fill(Partneri_2017);
                    }
                    con.Close();
                }

                using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2016))
                {
                    con.Open();
                    using (FbDataAdapter da = new FbDataAdapter("SELECT PPID, NAZIV, PIB FROM PARTNER ORDER BY PPID ASCENDING", con))
                    {
                        da.Fill(Partneri_2016);
                    }
                    con.Close();
                }

                using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2015))
                {
                    con.Open();
                    using (FbDataAdapter da = new FbDataAdapter("SELECT PPID, NAZIV, PIB FROM PARTNER ORDER BY PPID ASCENDING", con))
                    {
                        da.Fill(Partneri_2015);
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            uporedi_btn.Enabled = true;
        }

        private void PostaviBaze()
        {
            comboBox1.SelectedIndex = 3;
            comboBox2.SelectedIndex = 2;

            dataGridView1.DataSource = Partneri_2017;
            dataGridView2.DataSource = Partneri_2016;
        }

        private void uporedi_btn_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Pink;
            DialogResult dr = MessageBox.Show("Ovom akcijom izdvojicete sve partnere sa neispravnim pibom i partnere ciji je pib neusaglasen odnosno cije se pib razlikuje iz godine u godinu. \nOvaj proces traje dugo i bice zavrsen tek kada prozor ponovo dobije belu boju. \nDa li zelite nastaviti?", "Potvrdi!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    string pib1;
                    if(row.Cells["PIB"].Value == null || string.IsNullOrWhiteSpace(row.Cells["PIB"].Value.ToString()) || row.Cells["PIB"].Value is DBNull)
                    {
                        pib1 = "0";
                    }
                    else
                    {
                        pib1 = row.Cells["PIB"].Value.ToString();
                    }
                    string pib2 = GetPib(Convert.ToInt32(row.Cells["PPID"].Value));
                    if(pib1.Equals("0") || pib2.Equals("0"))
                    {
                        string ppid = "";
                        string naziv = "";
                        if (row.Cells["NAZIV"].Value == null || string.IsNullOrWhiteSpace(row.Cells["NAZIV"].Value.ToString()) || row.Cells["NAZIV"].Value is DBNull)
                        {
                            naziv = "Greska!!!";
                        }
                        else
                        {
                            naziv = row.Cells["NAZIV"].Value.ToString();
                        }
                        if (row.Cells["PPID"].Value == null || string.IsNullOrWhiteSpace(row.Cells["PPID"].Value.ToString()) || row.Cells["PPID"].Value is DBNull)
                        {
                            ppid = "Greska!!!";
                        }
                        else
                        {
                            ppid = row.Cells["PPID"].Value.ToString();
                        }
                        richTextBox2.Text = richTextBox2.Text + Environment.NewLine + ppid + " - " + naziv;
                    }
                    else if (!pib1.Equals(pib2))
                    {
                        richTextBox1.Text = richTextBox1.Text + Environment.NewLine + row.Cells["PPID"].Value.ToString() + " - " + row.Cells["NAZIV"].Value.ToString();
                    }
                }
            }
            this.BackColor = Control.DefaultBackColor;
        }

        private string GetPib(int PPID)
        {
            string i = "0";
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if(Convert.ToInt32(row.Cells["PPID"].Value) == PPID)
                {
                    if (row.Cells["PIB"].Value == null || string.IsNullOrWhiteSpace(row.Cells["PIB"].Value.ToString()) || row.Cells["PIB"].Value is DBNull)
                    {
                        i = "0";
                        return i;
                    }
                    else
                    {
                        i = row.Cells["PIB"].Value.ToString();
                        return i;
                    }
                }
            }
            return i;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ukoliko partnerov pib iz baze jedan nije usaglasen sa pibom partnera iz baze dva na istom PPID-u izbacuje PPID baze 1 u 'NEUSAGLASEN PARTNER' \nUkoliko partner iz bilo koje baze nema PIB, izbacuje PPID baze 1 u 'NEISPRAVAN PIB'");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = Partneri_2015;
                    break;
                case 1:
                    dataGridView1.DataSource = Partneri_2016;
                    break;
                case 2:
                    dataGridView1.DataSource = Partneri_2017;
                    break;
                case 3:
                    dataGridView1.DataSource = Partneri_2018;
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    dataGridView2.DataSource = Partneri_2015;
                    break;
                case 1:
                    dataGridView2.DataSource = Partneri_2016;
                    break;
                case 2:
                    dataGridView2.DataSource = Partneri_2017;
                    break;
                case 3:
                    dataGridView2.DataSource = Partneri_2018;
                    break;
            }
        }
    }
}
