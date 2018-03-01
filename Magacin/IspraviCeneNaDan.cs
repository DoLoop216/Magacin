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
    public partial class IspraviCeneNaDan : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        DateTime datumDokumenta;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        private string currConString = M.Baza.connectionKomercijalno2018;

        public IspraviCeneNaDan()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            UcitajVrsteDokumenta();
            kandidati_btn.Enabled = false;
            ispravi_btn.Enabled = false;
        }

        private void IspraviCeneNaDan_Load(object sender, EventArgs e)
        {
            baze_cmb.SelectedIndex = 0;
            vrstaDokumenta_cmb.SelectedValue = 15;
        }

        private void UcitajVrsteDokumenta()
        {
            using (FbConnection con = new FbConnection(currConString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT VRDOK, NAZIVDOK FROM VRSTADOK ORDER BY VRDOK", con))
                {
                    FbDataReader dr = cmd.ExecuteReader();

                    List<Int_String> list = new List<Int_String>();

                    while(dr.Read())
                    {
                        list.Add(new Int_String { _int = Convert.ToInt32(dr[0]), _string = String.Format("{0} - {1}", dr[0].ToString(), dr[1].ToString()) });
                    }

                    vrstaDokumenta_cmb.DataSource = list;
                    vrstaDokumenta_cmb.DisplayMember = "_string";
                    vrstaDokumenta_cmb.ValueMember = "_int";
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Morate uneti broj dokumenta!");
                return;
            }
            if(vrstaDokumenta_cmb.SelectedValue == null)
            {
                MessageBox.Show("Morate izabrati vrstu dokumenta!");
                return;
            }
            using (FbConnection con = new FbConnection(currConString))
            {
                con.Open();
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                using (FbCommand cmd = new FbCommand("SELECT DATUM FROM DOKUMENT WHERE VRDOK = @VrDok AND BRDOK = @BrDok", con))
                {
                    cmd.Parameters.AddWithValue("@VrDok", vrstaDokumenta_cmb.SelectedValue);
                    cmd.Parameters.AddWithValue("@BrDok", textBox1.Text);

                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        datumDokumenta = Convert.ToDateTime(dr[0]);
                    }
                    else
                    {
                        MessageBox.Show("Doslo je do greske!");
                    }
                }
                using (FbDataAdapter da = new FbDataAdapter("SELECT * FROM STAVKA WHERE VRDOK = @VrDok AND BRDOK = @BrDok", con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@VrDok", vrstaDokumenta_cmb.SelectedValue);
                    da.SelectCommand.Parameters.AddWithValue("@BrDok", textBox1.Text);
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }

                ispravi_btn.Enabled = true;
                kandidati_btn.Enabled = true;
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FbConnection con = new FbConnection(currConString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("UPDATE STAVKA SET PRODAJNACENA = @ProdajnaCena, PRODCENABP = @ProdCenaBp WHERE VRDOK = @VrDok AND BRDOK = @BrDok AND ROBAID = @RobaID", con))
                {
                    cmd.Parameters.AddWithValue("@VrDok", vrstaDokumenta_cmb.SelectedValue);
                    cmd.Parameters.AddWithValue("@BrDok", textBox1.Text);
                    cmd.Parameters.Add("@ProdajnaCena", FbDbType.Decimal);
                    cmd.Parameters.Add("@ProdCenaBp", FbDbType.Decimal);
                    cmd.Parameters.Add("@RobaID", FbDbType.Integer);

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        cmd.Parameters["@ProdajnaCena"].Value = row.Cells["PRODAJNACENA"].Value;
                        cmd.Parameters["@ProdCenaBp"].Value = row.Cells["PRODCENABP"].Value;
                        cmd.Parameters["@RobaID"].Value = row.Cells["ROBAID"].Value;

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Gotovo!");
                con.Close();
            }
        }

        private void baze_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(baze_cmb.SelectedIndex)
            {
                case 0:
                    currConString = M.Baza.connectionKomercijalno2018;
                    break;
                case 1:
                    currConString = M.Baza.connectionKomercijalno2017;
                    break;
                case 2:
                    currConString = M.Baza.connectionKomercijalno2016;
                    break;
                case 3:
                    currConString = M.Baza.connectionKomercijalno2015;
                    break;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void kandidati_btn_Click(object sender, EventArgs e)
        {
            using (FbConnection con = new FbConnection(currConString))
            {
                con.Open();
                dt1 = dt.Copy();
                using (FbCommand cmd = new FbCommand("CENE_NA_DAN", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("MAGACINID", FbDbType.Integer).Value = 12;
                    cmd.Parameters.Add("ROBAID", FbDbType.Integer);
                    cmd.Parameters.Add("DATUM", FbDbType.Date).Value = datumDokumenta;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        cmd.Parameters["ROBAID"].Value = row.Cells["ROBAID"].Value;
                        using (FbDataReader dr = cmd.ExecuteReader())
                        {

                            if (dr.Read())
                            {
                                dt1.Rows[row.Index]["PRODAJNACENA"] = Convert.ToDecimal(dr[0]);
                                dt1.Rows[row.Index]["PRODCENABP"] = Convert.ToDecimal(dr[0]) - (Convert.ToDecimal(dr[0]) * 20 / 120);
                            }
                        }
                    }
                    dataGridView2.DataSource = dt1;
                }
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }
    }
}
