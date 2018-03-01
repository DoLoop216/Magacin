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
    public partial class Help : Form
    {
        string modulName;

        public Help(string modulName)
        {
            InitializeComponent();
            this.modulName = modulName;
        }

        private void Help_Load(object sender, EventArgs e)
        {
            UcitajBelesku();
        }

        private void UcitajBelesku()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT BELESKA FROM MODUL WHERE CLASSNAME = @ModulName", con))
                {
                    cmd.Parameters.AddWithValue("@ModulName", modulName);

                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        richTextBox1.Text = dr[0].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Ovaj modul nije registrovan!");
                        this.Close();
                    }
                }
                con.Close();
            }
        }
        private void sacuvaj_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li sigurno zelite da sacuvate belesku?", "Potvrdi!", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                SacuvajBelesku();
            }
        }
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SacuvajBelesku();
            }
        }
        private void SacuvajBelesku()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("UPDATE MODUL SET BELESKA = @Beleska WHERE CLASSNAME = @ClassName", con))
                {
                    cmd.Parameters.AddWithValue("@Beleska", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@ClassName", modulName);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Beleska uspesno sacuvana!");
                }
                con.Close();
            }
        }
    }
}
