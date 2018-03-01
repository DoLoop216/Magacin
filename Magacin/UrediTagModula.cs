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
    public partial class UrediTagModula : Form
    {
        string modulName;

        public UrediTagModula(string modulName)
        {
            InitializeComponent();
            this.modulName = modulName;
        }

        private void UrediTagModula_Load(object sender, EventArgs e)
        {
            UcitajTag();
        }

        private void UcitajTag()
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("SELECT TAG FROM MODUL WHERE CLASSNAME = @className", con))
                {
                    cmd.Parameters.AddWithValue("@className", modulName);

                    FbDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        textBox1.Text = dr[0].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Izabrani modul nema tag!");
                        this.Close();
                    }
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FbConnection con = new FbConnection(M.Baza.connectionString))
            {
                con.Open();
                using (FbCommand cmd = new FbCommand("UPDATE MODUL SET TAG = @Tag WHERE CLASSNAME = @ClassName", con))
                {
                    cmd.Parameters.AddWithValue("@Tag", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ClassName", modulName);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Izmena taga uspesno izvrsena!");
                }
                con.Close();
            }
        }
    }
}
