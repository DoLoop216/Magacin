using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json;
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
    public partial class Podesavanja : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public Podesavanja()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
        }

        private void Podesavanja_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode.Name.Equals("Prava_Izvezi"))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();

                List<Pravo> prava_Db = new List<Pravo>();

                using (FbConnection con = new FbConnection(M.Baza.connectionString))
                {
                    con.Open();
                    using (FbCommand cmd = new FbCommand("SELECT PRAVOID, OPIS FROM PRAVA_DB", con))
                    {
                        FbDataReader dr = cmd.ExecuteReader();

                        while(dr.Read())
                        {
                            prava_Db.Add(new Pravo { pravoId = Convert.ToInt32(dr[0]), opis = dr[1].ToString() });
                        }
                    }
                    con.Close();
                }
                System.IO.File.WriteAllText(fbd.SelectedPath + @"\Magacin_Tabela_PRAVA_DB.txt", JsonConvert.SerializeObject(prava_Db));
            }
            else if (treeView1.SelectedNode.Name.Equals("Prava_Uvezi"))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "txt files (*.txt)|*.txt";
                ofd.ShowDialog();
                string[] test = ofd.FileName.Split('\\');
                if (test[test.Length - 1].Equals("Magacin_Tabela_PRAVA_DB.txt"))
                {
                    string text = System.IO.File.ReadAllText(ofd.FileName);
                    List<Pravo> pravaDb = JsonConvert.DeserializeObject<List<Pravo>>(text);
                    using (FbConnection con = new FbConnection(M.Baza.connectionString))
                    {
                        con.Open();
                        using(FbCommand cmd = new FbCommand("DELETE FROM PRAVA_DB", con))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        using (FbCommand cmd = new FbCommand("INSERT INTO PRAVA_DB (PRAVOID, OPIS) VALUES (@ID, @OPIS)", con))
                        {
                            cmd.Parameters.Add("@ID", FbDbType.Integer);
                            cmd.Parameters.Add("@OPIS", FbDbType.VarChar);

                            foreach(Pravo p in pravaDb)
                            {
                                cmd.Parameters["@ID"].Value = p.pravoId;
                                cmd.Parameters["@OPIS"].Value = p.opis;

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("GOTOVO!");
                        }
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nepodrzan fajl!");
                }
            }
            else if (treeView1.SelectedNode.Name.Equals("Moduli_IDovi_Uvezi"))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "txt files (*.txt)|*.txt";
                ofd.ShowDialog();
                string[] test = ofd.FileName.Split('\\');
                if (test[test.Length - 1].Equals("Magacin_Tabela_MODUL.txt"))
                {
                    string text = System.IO.File.ReadAllText(ofd.FileName);
                    List<Modul> modulDb = JsonConvert.DeserializeObject<List<Modul>>(text);
                    using (FbConnection con = new FbConnection(M.Baza.connectionString))
                    {
                        con.Open();
                        using (FbCommand cmd = new FbCommand("DELETE FROM MODUL", con))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        using (FbCommand cmd = new FbCommand("INSERT INTO MODUL (DEST, TAG, CLASSNAME, CLASSPAR1_V, CLASSPAR1_T, BELESKA) VALUES (@DEST, @TAG, @CLASSNAME, @CLASSPAR1_V, @CLASSPAR1_T, @BELESKA)", con))
                        {
                            cmd.Parameters.Add("@DEST", FbDbType.VarChar);
                            cmd.Parameters.Add("@TAG", FbDbType.VarChar);
                            cmd.Parameters.Add("@CLASSNAME", FbDbType.VarChar);
                            cmd.Parameters.Add("@CLASSPAR1_V", FbDbType.VarChar);
                            cmd.Parameters.Add("@CLASSPAR1_T", FbDbType.VarChar);
                            cmd.Parameters.Add("@BELESKA", FbDbType.VarChar);

                            foreach (Modul m in modulDb)
                            {
                                cmd.Parameters["@DEST"].Value = m.dest;
                                cmd.Parameters["@TAG"].Value = m.tag;
                                cmd.Parameters["@CLASSNAME"].Value = m.className;
                                cmd.Parameters["@CLASSPAR1_V"].Value = m.classPar1_V;
                                cmd.Parameters["@CLASSPAR1_T"].Value = m.classPar1_T;
                                cmd.Parameters["@BELESKA"].Value = m.beleska;

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("GOTOVO!");
                        }
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nepodrzan fajl!");
                }
            }
            else if (treeView1.SelectedNode.Name.Equals("Moduli_IDovi_Izvezi"))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();

                List<Modul> prava_Db = new List<Modul>();

                using (FbConnection con = new FbConnection(M.Baza.connectionString))
                {
                    con.Open();
                    using (FbCommand cmd = new FbCommand("SELECT BELESKA, DEST, TAG, CLASSNAME, CLASSPAR1_V, CLASSPAR1_T FROM MODUL", con))
                    {
                        FbDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            prava_Db.Add(new Modul { dest = dr[1].ToString(), tag = dr[2].ToString(), className = dr[3].ToString(), classPar1_V = dr[4].ToString(), classPar1_T = dr[5].ToString(), beleska = dr[0].ToString()});
                        }
                    }
                    con.Close();
                }
                System.IO.File.WriteAllText(fbd.SelectedPath + @"\Magacin_Tabela_MODUL.txt", JsonConvert.SerializeObject(prava_Db));

                MessageBox.Show("GOTOVO!");
            }
            else
            {
                MessageBox.Show("Morate izabrati neku akciju!");
            }
        }
    }
}
