using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Magacin
{
    public partial class RobaAkcije : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public RobaAkcije()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            UcitajStavke();
        }

        private void RobaAkcije_Load(object sender, EventArgs e)
        {
        }

        private void UcitajStavke()
        {
            DataTable dt1 = new DataTable();
            DataTable dt_Komercijalno = Komercijalno.robaTable.Clone();
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbDataAdapter da = new FbDataAdapter("SELECT ROBAID, POPUST, KOLICINA, MAX_KOLICINA, TRSTANJE FROM LISTASTAVKE WHERE LISTAID = @ListaID", con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@ListaID", M.Podesavanja.ListeID.RobaAkcije);

                    da.Fill(dt1);
                }
            }

            foreach (DataRow dr in dt1.Rows)
            {
                DataRow dataRow = Komercijalno.robaTable.Select(String.Format("ROBAID = {0}", dr.Field<int>("ROBAID"))).FirstOrDefault();
                dt_Komercijalno.Rows.Add(dataRow.ItemArray);
            }

            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["ROBAID"] };
            dt_Komercijalno.PrimaryKey = new DataColumn[] { dt_Komercijalno.Columns["ROBAID"] };

            dt1.Merge(dt_Komercijalno);

            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["NAZIV"].DisplayIndex = 0;
            dataGridView1.Columns["NAZIV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["NAZIV"].ReadOnly = true;
            dataGridView1.Columns["KATBR"].ReadOnly = true;
            dataGridView1.Columns["ROBAID"].Visible = false;
            dataGridView1.Columns["STANJE"].Visible = false;
            dataGridView1.Columns["KATBRPRO"].Visible = false;
            dataGridView1.Columns["KOLICINA"].DisplayIndex = 2;
            dataGridView1.Columns["KOLICINA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["POPUST"].DisplayIndex = 3;
            dataGridView1.Columns["POPUST"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["KATBR"].DisplayIndex = 1;
            dataGridView1.Columns["KATBR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["POPUST"].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Columns["KOLICINA"].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Columns["MAX_KOLICINA"].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Columns["MAX_KOLICINA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["TRSTANJE"].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Columns["TRSTANJE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dodajRobu_btn_Click(object sender, EventArgs e)
        {
            IzborRobe ir = new IzborRobe(Komercijalno.robaTable, this);
            ir.ShowDialog();
        }

        public void DodajStavkuUAkciju(int robaId, double kolicina, double popustUProcentima)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("INSERT INTO LISTASTAVKE (ID, ROBAID, KOLICINA, POPUST, LISTAID) VALUES (((SELECT COALESCE(MAX(ID), 0) FROM LISTASTAVKE) + 1), @RobaID, @Kolicina, @Popust, 1)", con))
                {
                    cmd.Parameters.AddWithValue("@RobaID", robaId);
                    cmd.Parameters.AddWithValue("@Kolicina", kolicina);
                    cmd.Parameters.AddWithValue("@Popust", popustUProcentima);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            UcitajStavke();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (loaded)
            {
                if (e.ColumnIndex == dataGridView1.Columns["KOLICINA"].Index)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["KOLICINA"].Value) != Convert.ToDouble(e.FormattedValue))
                    {
                        using (FbConnection con = new FbConnection(M.Baza.connectionString))
                        {
                            con.Open();
                            using (FbCommand cmd = new FbCommand("UPDATE LISTASTAVKE SET KOLICINA = @Kolicina WHERE ROBAID = @RobaID AND LISTAID = 1", con))
                            {
                                cmd.Parameters.AddWithValue("@Kolicina", Convert.ToDouble(e.FormattedValue));
                                cmd.Parameters.AddWithValue("@RobaID", Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ROBAID"].Value));

                                cmd.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                    }
                }
                else if (e.ColumnIndex == dataGridView1.Columns["POPUST"].Index)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["POPUST"].Value) != Convert.ToDouble(e.FormattedValue))
                    {
                        using (FbConnection con = new FbConnection(M.Baza.connectionString))
                        {
                            con.Open();
                            using (FbCommand cmd = new FbCommand("UPDATE LISTASTAVKE SET POPUST = @Popust WHERE ROBAID = @RobaID AND LISTAID = 1", con))
                            {
                                cmd.Parameters.AddWithValue("@Popust", Convert.ToDouble(e.FormattedValue));
                                cmd.Parameters.AddWithValue("@RobaID", Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ROBAID"].Value));

                                cmd.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                    }
                }
                else if(e.ColumnIndex == dataGridView1.Columns["MAX_KOLICINA"].Index)
                {
                    if(Convert.ToDouble(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["MAX_KOLICINA"].Value) != Convert.ToDouble(e.FormattedValue))
                    {
                        using (FbConnection con = new FbConnection(M.Baza.connectionString))
                        {
                            con.Open();
                            using (FbCommand cmd = new FbCommand("UPDATE LISTASTAVKE SET MAX_KOLICINA = @MaxKol WHERE ROBAID = @RobaID AND LISTAID = 1", con))
                            {
                                cmd.Parameters.AddWithValue("@MaxKol", Convert.ToDouble(e.FormattedValue));
                                cmd.Parameters.AddWithValue("@RobaID", Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ROBAID"].Value));

                                cmd.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                    }
                }
                else if (e.ColumnIndex == dataGridView1.Columns["TRSTANJE"].Index)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["TRSTANJE"].Value) != Convert.ToDouble(e.FormattedValue))
                    {
                        using (FbConnection con = new FbConnection(M.Baza.connectionString))
                        {
                            con.Open();
                            using (FbCommand cmd = new FbCommand("UPDATE LISTASTAVKE SET TRSTANJE = @TrStanje WHERE ROBAID = @RobaID AND LISTAID = 1", con))
                            {
                                cmd.Parameters.AddWithValue("@TrStanje", Convert.ToDouble(e.FormattedValue));
                                cmd.Parameters.AddWithValue("@RobaID", Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ROBAID"].Value));

                                cmd.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                    }
                }
            }
        }

        private void obrisiStavkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("DELETE FROM LISTASTAVKE WHERE ROBAID = @RobaID AND LISTAID = 1", con))
                {
                    cmd.Parameters.AddWithValue("@RobaID", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ROBAID"].Value);

                    cmd.ExecuteNonQuery();

                    UcitajStavke();
                }
                con.Close();
            }
        }

        private void RobaAkcije_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                //Dodati help
            }
        }
    }
}
